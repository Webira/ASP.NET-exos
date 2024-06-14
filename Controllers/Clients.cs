using Microsoft.AspNetCore.Mvc;

namespace exo10._06.Controllers
{
    public class Clients : Controller
    {
        public string[] nom = new string[] { "jean", "Paul" };

        // GET: Clients
        public ActionResult Index()
        {
            //return View();
            return Json(new { message = "Hello" });
        }

        public ActionResult Pierre()
        {
            int indexDePierre = Array.IndexOf(nom, "Pierre");

            return Json(new { index = indexDePierre });
        }

        public ActionResult ListNom()
        {
            return Json(this.nom);
        }

        //----------exo 1  11/06/24-----------------------

        // Declaration un dictionnaire
        public ActionResult NumberStr(string maxrangStr)
        {
            Dictionary<string, int> troisLists = new Dictionary<string, int>
            {
                { "hundrid", 100 },
                { "mille", 1000 },
                { "million", 1000000 }
            };

            if (!troisLists.ContainsKey(maxrangStr))
            {
                return Json(new { error = $"Le valeur n'a pas autorisé" });
            }
            ;
            int maxrange = troisLists[maxrangStr];
            Random random = new Random();
            int randomNumber = random.Next(0, maxrange);
            return Json(new { number = randomNumber });
        }
    }
}
