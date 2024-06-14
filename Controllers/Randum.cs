using Microsoft.AspNetCore.Mvc;

namespace exo10._06.Controllers;

public class RandumController : Controller
{
    // GET: Randum
    public ActionResult Number()
    {
        /*exo1: return un Json avec un nombre aleatoir
        -generer un nombre aleatoire
        -retourner un json avec le number aleatoire
        -Json doit avoir le format {"number":123}  */

        Random random = new Random();
        int randomNumber = random.Next(0, 1000);

        return Json(new { number = randomNumber });
    }
//-----------------exo 2  10/06/24-----------------------------------------
    /*exo2: return les strings aleatoir - renvoir en Json les mots:
    -declaration le tableau
    -generer un nombre aleatoire
    -renvoyer le messages corresponde à l'index
    */
    /* public string[] rndstr = new string[]{
         "Bonjour", "Hello", "Hi" };*/
    
    string[] rndstr = ["Bonjour", "Hello", "Hi"];

     //L'attribut de la Root
    [HttpGet("{controller}/RndString/{valeur}")] 
    public ActionResult RndString(string valeur)
    {
        System.Console.WriteLine($"valeur : {valeur}");
        // Generate random indexes pour tableau rndstr.
        Random random = new Random();
        int rndInd = random.Next(0, rndstr.Length);
        string valeurStr = rndstr[rndInd];

        return Json(new { valeur = valeurStr }); // {"valeur": "Hi"}
    }

//------------------------------------------------------------------------
    string[] listStr = new string[] { "Bob", "Tom", "Dan" };
   

    [HttpGet("{controller}/listNom")]
    public ActionResult ListNom()
    {
        System.Console.WriteLine(listStr);

        return Json(new { nom = this.listStr });
    }

//-----------------------------------------------------------------------
string[] listStr1 = new string[] { "Bob", "Tom", "Dan" };
   

    [HttpGet("{controller}/listNom1/{index:int}")]
    public ActionResult ListNom1(int index)
    {
        System.Console.WriteLine(listStr1);

        return Json(new { nom = this.listStr1 });
    }


//------------------------------------------------------------------------
    // GET: Randum
    [HttpGet("{controller}/Number/{maxRang}")]
    public ActionResult Number(int maxRang)
    {
        /*exo1: return un Json avec un nombre aleatoir
        -generer un nombre aleatoire
        -retourner un json avec le number aleatoire
        -Json doit avoir le format {"number":123}  */

        Random random = new Random();
        int randomNumber = random.Next(0, maxRang);

        return Json(new { number = randomNumber });
    }
//--------------------------------------------------------------

    [HttpGet("{controller}/rndstrrayan/{number}")]
    public ActionResult rndstrrayan(string number)
    {
     
        System.Console.WriteLine("Gate");
        System.Console.WriteLine($"str: {number}");
        return Json(new { });
    }
}
