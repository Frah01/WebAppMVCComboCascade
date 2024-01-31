using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppMVCComboCascade.Models;

namespace WebAppMVCComboCascade.Controllers
{
    public class ProvinciaController : Controller
    {

        List<Provincia> listProvince = null;
        Provincia oProv = null;
        // GET: ProvinciaController
        public ActionResult Index()
        {
            listProvince = new List<Provincia>();
            oProv = new Provincia();
            oProv.ID = 1;
            oProv.Nome = "Perugia";
            oProv.IdRegione = 1;
            oProv.isCapoluogo = true;
            oProv.NumAbitanti = 150000;
            listProvince.Add(oProv);

            oProv = new Provincia();
            oProv.ID = 2;
            oProv.Nome = "Terni";
            oProv.IdRegione = 1;
            oProv.isCapoluogo = false;
            oProv.NumAbitanti = 100000;
            listProvince.Add(oProv);

            oProv = new Provincia();
            oProv.ID = 3;
            oProv.Nome = "Roma";
            oProv.IdRegione = 2;
            oProv.isCapoluogo = true;
            oProv.NumAbitanti = 5000000;
            listProvince.Add(oProv);
            return View(listProvince);
        }

        // GET: ProvinciaController/Details/5
        public ActionResult Details(int id)
        {
            listProvince = new List<Provincia>();
            oProv = new Provincia();
            oProv.ID = 1;
            oProv.Nome = "Perugia";
            oProv.IdRegione = 1;
            oProv.isCapoluogo = true;
            oProv.NumAbitanti = 150000;
            listProvince.Add(oProv);

            oProv = new Provincia();
            oProv.ID = 2;
            oProv.Nome = "Terni";
            oProv.IdRegione = 1;
            oProv.isCapoluogo = false;
            oProv.NumAbitanti = 100000;
            listProvince.Add(oProv);

            oProv = new Provincia();
            oProv.ID = 3;
            oProv.Nome = "Roma";
            oProv.IdRegione = 2;
            oProv.isCapoluogo = true;
            oProv.NumAbitanti = 5000000;
            listProvince.Add(oProv);
            return View(listProvince[id - 1]);
        }

        // GET: ProvinciaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProvinciaController/Create
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

        // GET: ProvinciaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProvinciaController/Edit/5
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

        // GET: ProvinciaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProvinciaController/Delete/5
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
