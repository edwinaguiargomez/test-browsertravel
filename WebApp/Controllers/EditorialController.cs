using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("[controller]/[action]")]
    public class EditorialController : Controller
    {
        private readonly ILogger<EditorialController> _logger;

        public EditorialController(ILogger<EditorialController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            EditorialModel model = new EditorialModel();
            var list = new EditorialLogic().Get();
            return View("List", list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            EditorialModel model = new EditorialModel();
            model.Editorial.IsNew = true;
            return View("Master", model);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            EditorialModel model = new EditorialModel();
            model.Editorial = new EditorialLogic().Get(id);
            model.Editorial.IsNew = false;
            model.ListLibros = new LibroLogic().Get(x => x.EditorialId == id);
            return View("Master", model);
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            EditorialModel model = new EditorialModel();
            model.Editorial = new EditorialLogic().Get(id);
            new EditorialLogic().Remove(model.Editorial);
            return Get();
        }


        [HttpPost]
        public IActionResult Edit(EditorialModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Editorial.IsNew)
                    {
                        model.Editorial = new EditorialLogic().Create(model.Editorial);
                    }
                    else
                    {
                        model.Editorial = new EditorialLogic().Update(model.Editorial);
                    }
                    return Update(model.Editorial.Id);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Error", e.Message);
            }
            
            return View("Master", model);
        }
    }
}
