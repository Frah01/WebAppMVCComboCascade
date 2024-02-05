using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAppMVCComboCascade.Models;

namespace WebAppMVCComboCascade.Controllers
{
    public class ProvinciaController : Controller
    {
        private const string SESSIONPROVINCE = "_Provincia";
        List<Provincia> listProvince = null;
        Provincia oPro = null;

        private List<Provincia> getDatiProvincia()
        {
            List<Provincia> alistProvince = null;
            string? jsonProvincia = HttpContext.Session.GetString(SESSIONPROVINCE);
            if (jsonProvincia == null)
            {
                alistProvince = new List<Provincia>();

                oPro = new Provincia();           //  PRIMA PROVINCIA

                oPro.ID = 1;
                oPro.IdRegione = 1;
                oPro.Nome = "Perugia";
                oPro.isCapoluogo = true;
                oPro.NumAbitanti = 20000;

                alistProvince.Add(oPro);

                oPro = new Provincia();           //  SECONDA PROVINCIA

                oPro.ID = 2;
                oPro.IdRegione = 1;
                oPro.Nome = "Terni";
                oPro.isCapoluogo = false;
                oPro.NumAbitanti = 40000;

                alistProvince.Add(oPro);

                oPro = new Provincia();           //  TERZA PROVINCIA

                oPro.ID = 3;
                oPro.IdRegione = 2;
                oPro.Nome = "Roma";
                oPro.isCapoluogo = true;
                oPro.NumAbitanti = 1000000;

                alistProvince.Add(oPro);
            }
            else
            {
                alistProvince = (List<Provincia>)JsonConvert.DeserializeObject<List<Provincia>>(jsonProvincia);
            }
            return alistProvince;
        }
        
        // GET: ProvinciaController
        public ActionResult Index()
        {
            listProvince = getDatiProvincia();
            string jsonProvincia = JsonConvert.SerializeObject(listProvince);
            HttpContext.Session.SetString(SESSIONPROVINCE, jsonProvincia);
            return View(listProvince);
        }

        // GET: ProvinciaController/Details/5
        public ActionResult Details(int id)
        {
            string? jsonProvince = HttpContext.Session.GetString(SESSIONPROVINCE);

            if (jsonProvince != null)
            {
                var alistProvince = (List<Provincia>)JsonConvert.DeserializeObject<List<Provincia>>(jsonProvince);
                oPro = alistProvince.Where(r => r.ID == id).FirstOrDefault();
            }


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
            //PRENDO I DATI DALLA CACHE / SESSIONE
            string? jsonProvince = HttpContext.Session.GetString(SESSIONPROVINCE);
            try
            {
                if (jsonProvince != null)
                {

                    //DESERIALIZZO I DATI

                    listProvince = (List<Provincia>)JsonConvert.DeserializeObject<List<Provincia>>(jsonProvince);
                    var dicProvincia = collection.ToDictionary(kvp => kvp.Key);
                    oPro = new Provincia();
                    oPro.ID = Convert.ToInt32(dicProvincia["ID"].Value);
                    oPro.IdRegione = Convert.ToInt32(dicProvincia["IdRegione"].Value);
                    oPro.Nome = dicProvincia["Nome"].Value.ToString();
                    oPro.isCapoluogo = Convert.ToBoolean(dicProvincia["isCapoluogo"].Value);
                    oPro.NumAbitanti = Convert.ToInt32(dicProvincia["NumAbitanti"].Value);
                    listProvince.Add(oPro);
                    //RISERIALIZZO I DATI IN CACHE / SESSIONE
                    jsonProvince = JsonConvert.SerializeObject(listProvince);

                    //RISETTO LA STRINGA
                    HttpContext.Session.SetString(SESSIONPROVINCE, jsonProvince);
                }
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
            string? jsonProvince = HttpContext.Session.GetString(SESSIONPROVINCE);

            if (jsonProvince != null)
            {
                var alistProvince = (List<Provincia>)JsonConvert.DeserializeObject<List<Provincia>>(jsonProvince);
                oPro = alistProvince.Where(r => r.ID == id).FirstOrDefault();
            }
            return View(oPro);
        }

        // POST: ProvinciaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            //PRENDO I DATI DALLA CACHE / SESSIONE
            string? jsonProvince = HttpContext.Session.GetString(SESSIONPROVINCE);
            try
            {
                if (jsonProvince != null)
                {
                    //DESERIALIZZO I DATI

                    listProvince = (List<Provincia>)JsonConvert.DeserializeObject<List<Provincia>>(jsonProvince);
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
                    //RISERIALIZZO I DATI IN CACHE / SESSIONE
                    jsonProvince = JsonConvert.SerializeObject(listProvince);

                    //RISETTO LA STRINGA
                    HttpContext.Session.SetString(SESSIONPROVINCE, jsonProvince);
                }
                
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
            string? jsonProvince = HttpContext.Session.GetString(SESSIONPROVINCE);

            if (jsonProvince != null)
            {
                var alistProvince = (List<Provincia>)JsonConvert.DeserializeObject<List<Provincia>>(jsonProvince);
                oPro = alistProvince.Where(r => r.ID == id).FirstOrDefault();
            }
            return View(oPro);
        }

        // POST: ProvinciaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                string? jsonProvince = HttpContext.Session.GetString(SESSIONPROVINCE);
                if (jsonProvince != null)
                {
                    //DESERIALIZZO I DATI

                    listProvince = (List<Provincia>)JsonConvert.DeserializeObject<List<Provincia>>(jsonProvince);
                    var dicProvincia = collection.ToDictionary(kvp => kvp.Key);

                    oPro = listProvince.Where(r => r.ID == id).FirstOrDefault();
                    listProvince.Remove(oPro);
                    //RISERIALIZZO I DATI IN CACHE / SESSIONE
                    jsonProvince = JsonConvert.SerializeObject(listProvince);

                    //RISETTO LA STRINGA
                    HttpContext.Session.SetString(SESSIONPROVINCE, jsonProvince);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
