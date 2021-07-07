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
    public class AutorController : Controller
    {
        private readonly ILogger<AutorController> _logger;

        public AutorController(ILogger<AutorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            AutorModel model = new AutorModel();
            var list = new AutorLogic().Get();
            return View("List", list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            AutorModel model = new AutorModel();
            model.Autor.IsNew = true;
            return View("Master", model);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            AutorModel model = new AutorModel();
            model.Autor = new AutorLogic().Get(id);
            model.Autor.IsNew = false;
            model.ListLibros = new AutoresHasLibrosLogic().Table().Include(x => x.Libro.Editorial).Where(x => x.AutorId == id).Select(x => x.Libro).ToList(); 
            return View("Master", model);
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            AutorModel model = new AutorModel();
            model.Autor = new AutorLogic().Get(id);
            new AutorLogic().Remove(model.Autor);
            return Get();
        }


        [HttpPost]
        public IActionResult Edit(AutorModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Autor.IsNew)
                    {
                        model.Autor = new AutorLogic().Create(model.Autor);
                    }
                    else
                    {
                        model.Autor = new AutorLogic().Update(model.Autor);
                    }
                    return Update(model.Autor.Id);
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
