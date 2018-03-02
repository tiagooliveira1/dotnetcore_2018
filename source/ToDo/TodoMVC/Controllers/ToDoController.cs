using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoMVC.Models.View;
using TodoMVC.Services;

namespace TodoMVC.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ITodoItemService _todoItemsService;

        public ToDoController(ITodoItemService todoItemsService){
            _todoItemsService = todoItemsService;
        }
        public async Task<IActionResult> Index()
        {
            // Get ToDo items from "a database"
            var todoItems = await _todoItemsService.GetIncompleteItemsAsync();

            // Put into a model
            var viewModel = new ToDoViewModel{
                Items = todoItems
            };

            // Render view using the model
            return View(viewModel);
        }
    }
}