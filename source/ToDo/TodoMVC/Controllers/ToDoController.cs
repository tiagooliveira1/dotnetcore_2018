using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoMvc.Services;
using TodoMvc.Models.View;
using TodoMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


namespace TodoMvc.Controllers {
    [Authorize]
    public class TodoController : Controller {
        private readonly ITodoItemService _todoItemService;
        private readonly UserManager<ApplicationUser> _userManager;


        public TodoController(ITodoItemService todoItemsService,
            UserManager<ApplicationUser> userManager) {
            _todoItemService = todoItemsService;
            _userManager = userManager;

        }

        // Action GET
        public async Task<IActionResult> Index() {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return Challenge();
            }
            var todoItems = await _todoItemService.GetIncompleteItemsAsync(currentUser);
            
            var viewModel = new TodoViewModel{
                Items = todoItems
            };

            return View(viewModel);
        }

        // Action POST
        public async Task<ActionResult> AddItem(NewTodoItem newTodoItem) {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) {
                return Unauthorized();
            }
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var successful = await _todoItemService.AddItemAsync(newTodoItem, currentUser);

            if(!successful) {
                return BadRequest(new { Error= "Could not add item"});
            }
            return Redirect("/todo");
            //return Ok();
        }

        // Action GET
        public async Task<IActionResult> MarkDone(Guid id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return Unauthorized();
            }
            if (id == Guid.Empty)
                return BadRequest();
            var sucessful = await _todoItemService
                .MarkDoneAsync(id, currentUser);
            return Ok();
            
        }
    }
}