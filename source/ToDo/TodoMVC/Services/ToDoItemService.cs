using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoMvc.Models;
using TodoMvc.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TodoMvc.Services {
    public class TodoItemService : ITodoItemService {
        private readonly ApplicationDbContext _context;
        

        public TodoItemService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TodoItem>> GetIncompleteItemsAsync(ApplicationUser currentuser) {
            var items = await _context
                .Items
                .Where(x => x.IsDone == false && x.OwnerId == currentuser.Id)
                .ToArrayAsync();
            return items;
        }
        public async Task<bool> AddItemAsync(NewTodoItem newTodoItem, ApplicationUser currentUser) { 
            var entity = new TodoItem {
                Id = Guid.NewGuid(),
                IsDone = false,
                Title = newTodoItem.Title,
                DueAt =newTodoItem.DueAt,
                OwnerId = currentUser.Id
                //DueAt = DateTimeOffset.Now.AddDays(3)
            };

            _context.Items.Add(entity);

            var saveResult = await _context.SaveChangesAsync();
            
            return saveResult == 1;
        }
        public async Task<bool> MarkDoneAsync(Guid id, ApplicationUser currentUser)
        {
            var item = await _context.Items
                .Where(x => x.Id == id && x.OwnerId == currentUser.Id)
                .SingleOrDefaultAsync();

            if (item == null)
                return false;
            item.IsDone = true;

            var saveResult = await _context
                .SaveChangesAsync();

            return saveResult == 1;
        }

        



        
    }
}