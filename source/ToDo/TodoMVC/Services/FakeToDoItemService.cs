using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoMVC.Models;

namespace TodoMVC.Services
{
    public class FakeToDoItemService : ITodoItemService
    {
        public Task<IEnumerable<ToDoItem>> GetIncompleteItemsAsync(){
            IEnumerable<ToDoItem> items = new[]{
                new ToDoItem{
                    Title = "Learns ASP.Net CORE",
                    DueAt = DateTimeOffset.Now.AddDays(1)
                },
                new ToDoItem{
                    Title = "Build Awesome apps",
                    DueAt = DateTimeOffset.Now.AddDays(2)
                }
            };

            return Task.FromResult(items);

        }
    }
}