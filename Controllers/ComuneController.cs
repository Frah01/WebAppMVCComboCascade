using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAppMVCComboCascade.Models;

namespace WebAppMVCComboCascade.Controllers
{
    public class ComuneController : Controller
    {
        private const string SESSIONCOMUNI = "_Comuni";
        List<Comune> listComuni = null;
        Comune oCom = null;
        // GET: ComuneController
        private List<Comune> getDatiComune()
        {
            List<Comune> alistComuni = null;
            string? jsonComuni = HttpContext.Session.GetString(SESSIONCOMUNI);
            if (jsonComuni == null)
            {
                alistComuni = new List<Comune>();
                oCom = new Comune();
                oCom.ID = 1;
                oCom.Nome = "Gubbio";
                oCom.IdComune = 1;
                oCom.NumAbitanti = 30000;
                alistComuni.Add(oCom);

                oCom = new Comune();
                oCom.ID = 2;
                oCom.Nome = "Narni";
                oCom.IdComune = 2;
                oCom.NumAbitanti = 28000;
                alistComuni.Add(oCom);

                oCom = new Comune();
                oCom.ID = 3;
                oCom.Nome = "Roma";
                oCom.IdComune = 3;
                oCom.NumAbitanti = 5000000;
                alistComuni.Add(oCom);

                oCom = new Comune();
                oCom.ID = 4;
                oCom.Nome = "Tivoli";
                oCom.IdComune = 3;
                oCom.NumAbitanti = 15000;
                alistComuni.Add(oCom);
            }
            else
            {
                alistComuni = (List<Comune>)JsonConvert.DeserializeObject<List<Comune>>(jsonComuni);
            }
            return alistComuni;
        }
        public ActionResult Index()
        {
            listComuni = getDatiComune();
            string? jsonComune = JsonConvert.SerializeObject(listComuni);
            HttpContext.Session.SetString(SESSIONCOMUNI, jsonComune);
            return View(listComuni);
        }

        // GET: ComuneController/Details/5
        public ActionResult Details(int id)
        {
            string? jsonComuni = HttpContext.Session.GetString(SESSIONCOMUNI);

            if (jsonComuni != null)
            {
                var alistComuni = (List<Comune>)JsonConvert.DeserializeObject<List<Comune>>(jsonComuni);
                oCom = alistComuni.Where(r => r.ID == id).FirstOrDefault();
            }


            return View(oCom);
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
            string? jsonComuni = HttpContext.Session.GetString(SESSIONCOMUNI);
            try
            {
                if (jsonComuni != null)
                {
                    //DESERIALIZZO I DATI

                    listComuni = (List<Comune>)JsonConvert.DeserializeObject<List<Comune>>(jsonComuni);
                    var dicComune = collection.ToDictionary(kvp => kvp.Key);
                    oCom = new Comune();
                    oCom.ID = Convert.ToInt32(dicComune["ID"].Value);
                    oCom.ID = Convert.ToInt32(dicComune["IdProvincia"].Value);
                    oCom.Nome = dicComune["Nome"].Value.ToString();
                    oCom.NumAbitanti = Convert.ToInt32(dicComune["NumAbitanti"].Value);
                    listComuni.Add(oCom);
                    //RISERIALIZZO I DATI IN CACHE / SESSIONE
                    jsonComuni = JsonConvert.SerializeObject(listComuni);

                    //RISETTO LA STRINGA
                    HttpContext.Session.SetString(SESSIONCOMUNI, jsonComuni);
                }
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
            string? jsonComuni = HttpContext.Session.GetString(SESSIONCOMUNI);

            if (jsonComuni != null)
            {
                var alistComuni = (List<Comune>)JsonConvert.DeserializeObject<List<Comune>>(jsonComuni);
                oCom = alistComuni.Where(r => r.ID == id).FirstOrDefault();
            }


            return View(oCom);
        }

        // POST: ComuneController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                string? jsonComuni = HttpContext.Session.GetString(SESSIONCOMUNI);

                if (jsonComuni != null)
                {
                    //DESERIALIZZO I DATI

                    listComuni = (List<Comune>)JsonConvert.DeserializeObject<List<Comune>>(jsonComuni);
                    oCom = listComuni.Where(r => r.ID == id).FirstOrDefault();
                    var dicComune = collection.ToDictionary(kvp => kvp.Key);
                    
                    listComuni.Remove(oCom);

                    oCom = new Comune();
                    oCom.ID = Convert.ToInt32(dicComune["ID"].Value);
                    oCom.IdComune = Convert.ToInt32(dicComune["IdProvincia"].Value);
                    oCom.Nome = dicComune["Nome"].Value.ToString();
                    oCom.NumAbitanti = Convert.ToInt32(dicComune["NumAbitanti"].Value);

                    listComuni.Add(oCom);
                    //RISERIALIZZO I DATI IN CACHE / SESSIONE
                    jsonComuni = JsonConvert.SerializeObject(listComuni);

                    //RISETTO LA STRINGA
                    HttpContext.Session.SetString(SESSIONCOMUNI, jsonComuni);
                }     
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
            string? jsonComuni = HttpContext.Session.GetString(SESSIONCOMUNI);

            if (jsonComuni != null)
            {
                var alistComuni = (List<Comune>)JsonConvert.DeserializeObject<List<Comune>>(jsonComuni);
                oCom = alistComuni.Where(r => r.ID == id).FirstOrDefault();
            }


            return View(oCom);
        }

        // POST: ComuneController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                string? jsonComuni = HttpContext.Session.GetString(SESSIONCOMUNI);

                if (jsonComuni != null)
                {
                    //DESERIALIZZO I DATI

                    listComuni = (List<Comune>)JsonConvert.DeserializeObject<List<Comune>>(jsonComuni);
                    var dicComune = collection.ToDictionary(kvp => kvp.Key);

                    oCom = listComuni.Where(r => r.ID == id).FirstOrDefault();
                    listComuni.Remove(oCom);
                    //RISERIALIZZO I DATI IN CACHE / SESSIONE
                    jsonComuni = JsonConvert.SerializeObject(listComuni);

                    //RISETTO LA STRINGA
                    HttpContext.Session.SetString(SESSIONCOMUNI, jsonComuni);
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
