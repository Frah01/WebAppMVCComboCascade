using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Net;
using System.Reflection;
using WebAppMVCComboCascade.Models; //AGGIUNTO PER RICHIAMARE  List<Regione> A RIGA 9

namespace WebAppMVCComboCascade.Controllers
{
    public class RegioneController : Controller
    {
        List<Regione> listRegioni = null;
        Regione oReg = null;
       
        // GET: RegioneController
        public ActionResult Index()
        {
            listRegioni = new List<Regione>();
            oReg = new Regione();
            oReg.ID = 1;
            oReg.Nome = "Umbria";
            oReg.isAutonoma = false;
            oReg.NumAbitanti = 500000;
            listRegioni.Add(oReg);

            oReg = new Regione();
            oReg.ID = 2;
            oReg.Nome = "Lazio";
            oReg.isAutonoma = false;
            oReg.NumAbitanti = 6500000;

            listRegioni.Add(oReg);

            oReg = new Regione();
            oReg.ID = 3;
            oReg.Nome = "Friuli Venezia Giulia";
            oReg.isAutonoma = true;
            oReg.NumAbitanti = 1150000;

            listRegioni.Add(oReg);
            return View(listRegioni);
        }

        // GET: RegioneController/Details/5
        public ActionResult Details(int id)
        {
            listRegioni = new List<Regione>();
            oReg = new Regione();
            oReg.ID = 1;
            oReg.Nome = "Umbria";
            oReg.isAutonoma = false;
            oReg.NumAbitanti = 500000;
            listRegioni.Add(oReg);

            oReg = new Regione();
            oReg.ID = 2;
            oReg.Nome = "Lazio";
            oReg.isAutonoma = false;
            oReg.NumAbitanti = 6500000;

            listRegioni.Add(oReg);

            oReg = new Regione();
            oReg.ID = 3;
            oReg.Nome = "Friuli Venezia Giulia";
            oReg.isAutonoma = true;
            oReg.NumAbitanti = 1150000;

            listRegioni.Add(oReg);
            return View(listRegioni[id - 1]);
        }

        // GET: RegioneController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegioneController/Create
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

        // GET: RegioneController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegioneController/Edit/5
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

        // GET: RegioneController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegioneController/Delete/5
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
