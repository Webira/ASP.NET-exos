using exo10._06.Controllers;
using exo10._06.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Namespace
{
    public class AuteursController : Controller
    {
        private readonly ILogger<AuteursController> _logger;

        //creer une variable  pour stocker les Data de Modele: Livre
        private readonly BiblioContext bddAuteurLivre;

        public AuteursController(ILogger<AuteursController> logger, BiblioContext AuteurLivre)
        {
            _logger = logger;
            bddAuteurLivre = AuteurLivre;
        }

        [HttpGet("Auteurs")]
        // GET: AuteursController
        public ActionResult Index()
        {
            List<Auteur> auteurs = bddAuteurLivre.Auteurs.Include(auteur => auteur.Livres).ToList();
            
            return Json(auteurs);
        }

        // POST

        //[HttpPost("Auteurs")]
        [HttpPost("AuteursController")]
        public IActionResult NewAuteurAdd([FromBody] Auteur auteurAdd)
        {
            Auteur newAuteur = new Auteur
            {
                //IdAuteur = auteurAdd.IdAuteur, //???
                NomAuteur = auteurAdd.NomAuteur,
                PrenomAuteur = auteurAdd.PrenomAuteur,
                Livres = auteurAdd.Livres
            };

            bddAuteurLivre.Auteurs.Add(newAuteur);
            bddAuteurLivre.SaveChanges(); //sovgard dans BD
            return Json(newAuteur);
        }

        // Get id

        [HttpGet("Auteurs/{IdAuteur}")]
        // GET: AuteursController
        public ActionResult FindAuteur(int IdAuteur)
        {
            Auteur auteur = bddAuteurLivre.Auteurs.Find(IdAuteur);

            List<Livre> all_livres_from_author = bddAuteurLivre
             .Livres.Where(livre => livre.IdAuteur == auteur.IdAuteur).ToList();

            return Json(auteur);
        }

        [HttpPut("Auteurs/{id}")]
        public ActionResult UpdateAuteur([FromBody] Auteur NewAuthorFromBody, int id)
        {
            Auteur FoundAuthor = bddAuteurLivre.Auteurs.Find(id);

            if (FoundAuthor == null)
            {
                return NotFound();
            }

            FoundAuthor.NomAuteur = NewAuthorFromBody.NomAuteur;
            FoundAuthor.PrenomAuteur = NewAuthorFromBody.PrenomAuteur;
            FoundAuthor.Livres = NewAuthorFromBody.Livres;

//One to many
            List<Livre> all_livres_from_author = bddAuteurLivre
             .Livres.Where(livre => livre.IdAuteur == FoundAuthor.IdAuteur).ToList();
            
            bddAuteurLivre.SaveChanges();
            return Json(FoundAuthor);
        }

        [HttpDelete("Auteurs/{id}")]
        public IActionResult DeleteAuteur(int id)
        {
            Auteur autCherch = bddAuteurLivre.Auteurs.Find(id);

            if (autCherch == null)
            {
                return NotFound();
            }
            bddAuteurLivre.Auteurs.Remove(autCherch);
            bddAuteurLivre.SaveChanges();
            return Json(new { message = "Auteur is deleted" });
        }
    }
}



// List<Livre> all_livres_from_author = bddAuteurLivre
//     .Livres.Where(livre => livre.IdAuteur == FoundAuthor.IdAuteur)
//     .ToList();
