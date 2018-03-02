using System.Collections.Generic;

namespace TodoMVC.Models.View
{
    public class ToDoViewModel
    {
        public IEnumerable<ToDoItem> Items { get; set; }
        
    }
}