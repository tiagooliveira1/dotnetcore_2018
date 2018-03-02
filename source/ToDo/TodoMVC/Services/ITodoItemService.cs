using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoMVC.Models;

namespace TodoMVC.Services
{
    public interface ITodoItemService
    {
        Task<IEnumerable<ToDoItem>> GetIncompleteItemsAsync();
    }
}