using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppMVCComboCascade.Models;

namespace WebAppMVCComboCascade.Controllers
{
    public class ProvinciaController : Controller
    {
        List<Provincia> listProvince = null;
        Provincia oPro = null;
        public ProvinciaController()
        {
            listProvince = new List<Provincia>();

            oPro = new Provincia();           //  PRIMA PROVINCIA

            oPro.ID = 1;
            oPro.IdRegione = 1;
            oPro.Nome = "Perugia";
            oPro.isCapoluogo = true;
            oPro.NumAbitanti = 20000;

            listProvince.Add(oPro);

            oPro = new Provincia();           //  SECONDA PROVINCIA

            oPro.ID = 2;
            oPro.IdRegione = 1;
            oPro.Nome = "Terni";
            oPro.isCapoluogo = false;
            oPro.NumAbitanti = 40000;

            listProvince.Add(oPro);

            oPro = new Provincia();           //  TERZA PROVINCIA

            oPro.ID = 3;
            oPro.IdRegione = 2;
            oPro.Nome = "Roma";
            oPro.isCapoluogo = true;
            oPro.NumAbitanti = 1000000;

            listProvince.Add(oPro);
        }
        // GET: ProvinciaController
        public ActionResult Index()
        {
            return View(listProvince);
        }

        // GET: ProvinciaController/Details/5
        public ActionResult Details(int id)
        {
            oPro = listProvince.Where(provincia => provincia.ID == id).FirstOrDefault();

            return View(oPro);
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
                var dicProvincia = collection.ToDictionary(kvp => kvp.Key);
                oPro = new Provincia();
                oPro.ID = Convert.ToInt32(dicProvincia["ID"].Value);
                oPro.IdRegione = Convert.ToInt32(dicProvincia["IdRegione"].Value);
                oPro.Nome = dicProvincia["Nome"].Value.ToString();
                oPro.isCapoluogo = Convert.ToBoolean(dicProvincia["isCapoluogo"].Value);
                oPro.NumAbitanti = Convert.ToInt32(dicProvincia["NumAbitanti"].Value);
                listProvince.Add(oPro);
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
            oPro = listProvince.Where(r => r.ID == id).FirstOrDefault();
            return View(oPro);
        }

        // POST: ProvinciaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var dicProvincia = collection.ToDictionary(kvp => kvp.Key);
                oPro = listProvince.Where(r => r.ID == id).FirstOrDefault();
                listProvince.Remove(oPro);

                oPro = new Provincia();
                oPro.ID = Convert.ToInt32(dicProvincia["ID"].Value);
                oPro.IdRegione = Convert.ToInt32(dicProvincia["IdRegione"].Value);
                oPro.Nome = dicProvincia["Nome"].Value.ToString();
                oPro.isCapoluogo = Convert.ToBoolean(dicProvincia["isCapoluogo"].Value);
                oPro.NumAbitanti = Convert.ToInt32(dicProvincia["NumAbitanti"].Value);

                listProvince.Add(oPro);
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
            oPro = listProvince.Where(r => r.ID == id).FirstOrDefault();
            return View(oPro);
        }

        // POST: ProvinciaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var dicProvincia = collection.ToDictionary(kvp => kvp.Key);

                oPro = listProvince.Where(r => r.ID == id).FirstOrDefault();
                listProvince.Remove(oPro);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
