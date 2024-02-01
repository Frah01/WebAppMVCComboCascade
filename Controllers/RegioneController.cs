using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppMVCComboCascade.Models;

namespace WebAppMVCComboCascade.Controllers
{
    public class RegioneController : Controller
    {
        List<Regione> listRegioni = null;
        Regione oReg = null;

        public RegioneController()
        {
            // VA BENE PER LIST, DETAILS, EDIT
            // NON VA BENE PER CREATE E DELETE: CI VUOLE IL DATABASE
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

        }

        // GET: RegioneController
        public ActionResult Index()
        {
            return View(listRegioni);
        }

        // GET: RegioneController/Details/5
        public ActionResult Details(int id)
        {
            oReg = listRegioni.Where(r => r.ID == id).FirstOrDefault();

            return View(oReg);
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
                var dicRegione = collection.ToDictionary(kvp => kvp.Key);
                oReg = new Regione();
                oReg.ID = Convert.ToInt32(dicRegione["ID"].Value);
                oReg.Nome = dicRegione["Nome"].Value.ToString();
                oReg.isAutonoma = Convert.ToBoolean(dicRegione["isAutonoma"].Value);
                oReg.NumAbitanti = Convert.ToInt32(dicRegione["NumAbitanti"].Value);
                listRegioni.Add(oReg);
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
            oReg = listRegioni.Where(r => r.ID == id).FirstOrDefault();
            return View(oReg);
        }

        // POST: RegioneController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // https://stackoverflow.com/questions/39123757/get-keyvaluepair-given-key
                var dicRegione = collection.ToDictionary(kvp => kvp.Key);

                oReg = listRegioni.Where(r => r.ID == id).FirstOrDefault();
                listRegioni.Remove(oReg);

                oReg = new Regione();
                oReg.ID = Convert.ToInt32(dicRegione["ID"].Value);
                oReg.Nome = dicRegione["Nome"].Value.ToString();
                oReg.isAutonoma = Convert.ToBoolean(dicRegione["isAutonoma"].Value);
                oReg.NumAbitanti = Convert.ToInt32(dicRegione["NumAbitanti"].Value);

                listRegioni.Add(oReg);
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
            oReg = listRegioni.Where(r => r.ID == id).FirstOrDefault();
            return View(oReg);
        }

        // POST: RegioneController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var dicRegione = collection.ToDictionary(kvp => kvp.Key);

                oReg = listRegioni.Where(r => r.ID == id).FirstOrDefault();
                listRegioni.Remove(oReg);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
