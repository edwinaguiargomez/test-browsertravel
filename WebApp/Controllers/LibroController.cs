using Logic;
using Microsoft.AspNetCore.Mvc;
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
    public class LibroController : Controller
    {
        private readonly ILogger<LibroController> _logger;

        public LibroController(ILogger<LibroController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            LibroModel model = new LibroModel();
            var list = new LibroLogic().Get();
            return View("List", list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            LibroModel model = new LibroModel();
            model.Libro.IsNew = true;
            model.ListEditoriales = new EditorialLogic().Get();
            return View("Master", model);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            LibroModel model = new LibroModel();
            model.Libro = new LibroLogic().Get(id);
            model.Libro.IsNew = false;
            model.ListEditoriales = new EditorialLogic().Get();
            return View("Master", model);
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            try
            {
                LibroModel model = new LibroModel();
                model.Libro = new LibroLogic().Get(id);
                new LibroLogic().Remove(model.Libro);
                return Get();
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Error", e.Message);
                return Update(id);
            }
        }


        [HttpPost]
        public IActionResult Edit(LibroModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Libro.IsNew)
                    {
                        model.Libro = new LibroLogic().Create(model.Libro);
                    }
                    else
                    {
                        model.Libro = new LibroLogic().Update(model.Libro);
                    }
                    return Update(model.Libro.Id);
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
