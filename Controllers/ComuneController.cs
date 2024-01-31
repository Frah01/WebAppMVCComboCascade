﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppMVCComboCascade.Models;

namespace WebAppMVCComboCascade.Controllers
{
    public class ComuneController : Controller
    {
        List<Comune> listComuni = null;
        Comune oCom = null;
        // GET: ComuneController
        public ActionResult Index()
        {
            listComuni = new List<Comune>();
            oCom = new Comune();
            oCom.ID = 1;
            oCom.Nome = "Gubbio";
            oCom.IdProvincia = 1;
            oCom.NumAbitanti = 30000;
            listComuni.Add(oCom);

            oCom = new Comune();
            oCom.ID = 2;
            oCom.Nome = "Narni";
            oCom.IdProvincia = 2;
            oCom.NumAbitanti = 28000;
            listComuni.Add(oCom);

            oCom = new Comune();
            oCom.ID = 3;
            oCom.Nome = "Roma";
            oCom.IdProvincia = 3;
            oCom.NumAbitanti = 5000000;
            listComuni.Add(oCom);

            oCom = new Comune();
            oCom.ID = 4;
            oCom.Nome = "Tivoli";
            oCom.IdProvincia = 3;
            oCom.NumAbitanti = 15000;
            listComuni.Add(oCom);
            return View(listComuni);
        }

        // GET: ComuneController/Details/5
        public ActionResult Details(int id)
        {
            listComuni = new List<Comune>();
            oCom = new Comune();
            oCom.ID = 1;
            oCom.Nome = "Gubbio";
            oCom.IdProvincia = 1;
            oCom.NumAbitanti = 30000;
            listComuni.Add(oCom);

            oCom = new Comune();
            oCom.ID = 2;
            oCom.Nome = "Narni";
            oCom.IdProvincia = 2;
            oCom.NumAbitanti = 28000;
            listComuni.Add(oCom);

            oCom = new Comune();
            oCom.ID = 3;
            oCom.Nome = "Roma";
            oCom.IdProvincia = 3;
            oCom.NumAbitanti = 5000000;
            listComuni.Add(oCom);

            oCom = new Comune();
            oCom.ID = 4;
            oCom.Nome = "Tivoli";
            oCom.IdProvincia = 3;
            oCom.NumAbitanti = 15000;
            listComuni.Add(oCom);
            return View(listComuni[id - 1]);
        }

        // GET: ComuneController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComuneController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ComuneController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ComuneController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ComuneController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ComuneController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}