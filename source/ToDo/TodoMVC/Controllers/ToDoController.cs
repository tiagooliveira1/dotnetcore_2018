using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TodoMVC.Controllers
{
    public class ToDoController : Controller
    {
        //action
        public IActionResult Index()
        {
            // Get ToDo items from "a database"
            // Put into a model
            // Render view using the model
            return View();
        }
    }
}