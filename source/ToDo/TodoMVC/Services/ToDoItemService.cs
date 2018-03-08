using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoMVC.Models;
using TodoMVC.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TodoMVC.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ApplicationDbContext _context;

        public TodoItemService(ApplicationDbContext context){
            _context = context;
        }
        public async Task<IEnumerable<ToDoItem>> GetIncompleteItemsAsync(){
            return await _context.Items.Where(x => x.IsDone == false).ToArrayAsync();
        }
    }
}