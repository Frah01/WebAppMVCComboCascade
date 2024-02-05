using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAppMVCComboCascade.Models;

namespace WebAppMVCComboCascade.Controllers
{
    public class RegioneController : Controller
    {

        private const string SESSIONREGIONI = "_Regioni";
        List<Regione> listRegioni = null;
        Regione oReg = null;
        private List<Regione> getDatiRegione()
        {
            List<Regione> alistRegioni = null;
            string? jsonRegioni = HttpContext.Session.GetString(SESSIONREGIONI);
            if (jsonRegioni == null)
            {
                alistRegioni = new List<Regione>();
                oReg = new Regione();
                oReg.ID = 1;
                oReg.Nome = "Umbria";
                oReg.isAutonoma = false;
                oReg.NumAbitanti = 500000;
                alistRegioni.Add(oReg);

                oReg = new Regione();
                oReg.ID = 2;
                oReg.Nome = "Lazio";
                oReg.isAutonoma = false;
                oReg.NumAbitanti = 6500000;

                alistRegioni.Add(oReg);

                oReg = new Regione();
                oReg.ID = 3;
                oReg.Nome = "Friuli Venezia Giulia";
                oReg.isAutonoma = true;
                oReg.NumAbitanti = 1150000;

                alistRegioni.Add(oReg);
            }
            else
            {
                alistRegioni = (List<Regione>)JsonConvert.DeserializeObject<List<Regione>>(jsonRegioni);
            }
            return alistRegioni;

        }

        // GET: RegioneController
        public ActionResult Index()
        {
            listRegioni = getDatiRegione();
            string jsonRegioni = JsonConvert.SerializeObject(listRegioni);
            HttpContext.Session.SetString(SESSIONREGIONI, jsonRegioni);
            return View(listRegioni);
        }

        // GET: RegioneController/Details/5
        public ActionResult Details(int id)
        {
            string? jsonRegioni = HttpContext.Session.GetString(SESSIONREGIONI);

            if (jsonRegioni != null)
            {
                var alistRegioni = (List<Regione>)JsonConvert.DeserializeObject<List<Regione>>(jsonRegioni);
                oReg = alistRegioni.Where(r => r.ID == id).FirstOrDefault();
            }


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
            //PRENDO I DATI DALLA CACHE / SESSIONE
            string? jsonRegioni = HttpContext.Session.GetString(SESSIONREGIONI);

            try
            {
                if (jsonRegioni != null)
                {
                    //DESERIALIZZO I DATI

                    listRegioni = (List<Regione>)JsonConvert.DeserializeObject<List<Regione>>(jsonRegioni);
                    var dicRegione = collection.ToDictionary(kvp => kvp.Key);
                    oReg = new Regione();
                    oReg.ID = Convert.ToInt32(dicRegione["ID"].Value);
                    oReg.Nome = dicRegione["Nome"].Value.ToString();
                    oReg.isAutonoma = Convert.ToBoolean(dicRegione["isAutonoma"].Value);
                    oReg.NumAbitanti = Convert.ToInt32(dicRegione["NumAbitanti"].Value);
                    listRegioni.Add(oReg);

                    //RISERIALIZZO I DATI IN CACHE / SESSIONE
                    jsonRegioni = JsonConvert.SerializeObject(listRegioni);

                    //RISETTO LA STRINGA
                    HttpContext.Session.SetString(SESSIONREGIONI, jsonRegioni);
                }

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
            string? jsonRegioni = HttpContext.Session.GetString(SESSIONREGIONI);
            if (jsonRegioni != null)
            {
                listRegioni = (List<Regione>)JsonConvert.DeserializeObject<List<Regione>>(jsonRegioni);
                oReg = listRegioni.Where(r => r.ID == id).FirstOrDefault();
            }
            return View(oReg);
        }

        // POST: RegioneController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                string? jsonRegioni = HttpContext.Session.GetString(SESSIONREGIONI);
                if (jsonRegioni != null)
                {
                    listRegioni = (List<Regione>)JsonConvert.DeserializeObject<List<Regione>>(jsonRegioni);
                    oReg = listRegioni.Where(r => r.ID == id).FirstOrDefault();

                    var dicRegione = collection.ToDictionary(kvp => kvp.Key);


                    listRegioni.Remove(oReg);

                    oReg = new Regione();
                    oReg.ID = Convert.ToInt32(dicRegione["ID"].Value);
                    oReg.Nome = dicRegione["Nome"].Value.ToString();
                    oReg.isAutonoma = Convert.ToBoolean(dicRegione["isAutonoma"].Value);
                    oReg.NumAbitanti = Convert.ToInt32(dicRegione["NumAbitanti"].Value);

                    listRegioni.Add(oReg);

                    //RISERIALIZZO IN CACHE
                    jsonRegioni = JsonConvert.SerializeObject(listRegioni);
                    HttpContext.Session.SetString(SESSIONREGIONI, jsonRegioni);


                }
                // https://stackoverflow.com/questions/39123757/get-keyvaluepair-given-key

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
            string? jsonRegioni = HttpContext.Session.GetString(SESSIONREGIONI);

            if (jsonRegioni != null)
            {
                listRegioni = (List<Regione>)JsonConvert.DeserializeObject<List<Regione>>(jsonRegioni);
                oReg = listRegioni.Where(r => r.ID == id).FirstOrDefault();
            }
            return View(oReg);
        }

        // POST: RegioneController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            string? jsonRegioni = HttpContext.Session.GetString(SESSIONREGIONI);
            try
            {
                if (jsonRegioni != null)
                {
                    //DESERIALIZZO IN CHACHE
                    listRegioni = (List<Regione>)JsonConvert.DeserializeObject<List<Regione>>(jsonRegioni);
                    var dicRegione = collection.ToDictionary(kvp => kvp.Key);

                    oReg = listRegioni.Where(r => r.ID == id).FirstOrDefault();
                    listRegioni.Remove(oReg);

                    //RISERIALIZZO IN CACHE
                    jsonRegioni = JsonConvert.SerializeObject(listRegioni);

                    //SETTO NUOVMAENTE LA STRING JSONREGIONI
                    HttpContext.Session.SetString(SESSIONREGIONI, jsonRegioni);


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
