using System.Diagnostics.Eventing.Reader;
using exo10._06.Models;
using Microsoft.AspNetCore.Mvc;

namespace exo10._06.Controllers
{
    public class LivresController : Controller
    {
        public static List<Book> Books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "AAA",
                Author = "BBB"
            },
            new Book
            {
                Id = 2,
                Title = "DDDD",
                Author = "HHH"
            },
        };

        //----------------------------------------!!!!!

        [HttpGet("LivresController")]
        //[HttpGet("LivresController/ListLivres")]
        public IActionResult ListLivres()
        {
            // Retourner une liste de tout les utilisateurs
            // Permet de convertir un objet en JSON
            //string jsonstring = JsonSerializer.Serialize(this._users);

            return Json(LivresController.Books);
        }

        //-----------------------------!!!!

        [HttpGet("LivresController/{id}")]
        //[HttpGet("LivresController/BookId/{id}")]
        public IActionResult BookId(int id)
        {
            Book realBook = new Book();
            foreach (Book bookQ in LivresController.Books)
            {
                if (bookQ.Id == id)
                {
                    realBook = bookQ;
                    break;
                }
            }
            return Json(realBook);
        }

        //---------------------version 2 prof
        /* [HttpGet("LivresController/BookId/{id}")]
         public IActionResult BookId2(int id)
         {
             Book? bookQ = LivresController.Books.Find(bk =>bk.id == id)
             {
                 if (bookQ.Id == id)
                 {
                     bk= bookQ;
                     break;
                 }
             }
             return Json(bk);
         }*/

        //-------------------------!!!!
        [HttpPost("LivresController/NewBook")]
        // [HttpGet("LivresController/Add/")]
        // book de [FromQuery]  pour GET, [FromBody] pour POST
        public IActionResult NewBook([FromBody] Book book)
        {
            Book newBook = new Book
            {
                Id = LivresController.Books.Count + 1,
                Title = book.Title,
                Author = book.Author
            };
            LivresController.Books.Add(newBook);

            return Json(newBook);
        }

        [HttpPost("LivresController/")]
        //[HttpPost("LivresController/NewBookAdd")] //!!!!!
        // Sur Thunder Client book de [fromQuery]  pour GET, [fromBody] pour POST
        public IActionResult NewBookAdd([FromBody] Book book)
        {
            if (book.Id == 0)
                book.Id = LivresController.Books.Count + 1;
            Book newBook = new Book
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author
            };
            LivresController.Books.Add(newBook);

            return Json(newBook);
        }

        //-----------------------------
        // [HttpGet("LivresController/Add")]
        // public IActionResult AddBook(Book book)
        // {
        //     Books.Add(book);
        //     return Json(book);
        // }

        //---------------------------------------

        [HttpPut("LivresController/{id}")]
        //[HttpPut("LivresController/UpdateBook/{id}")]   //!!!!
        //[HttpGet("LivresController/Update/{id}")]   //!!!!
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            Book bookUpdate = new Book();
            foreach (Book bookUp in LivresController.Books)
            {
                if (bookUp.Id == id)
                {
                    bookUpdate = bookUp;
                    break;
                }
            }
            bookUpdate.Title = book.Title;
            bookUpdate.Author = book.Author;
            return Json(bookUpdate);
        }

        /*public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            Book bookUpdate = new Book();
            foreach (Book bookUp in LivresController.Books)
            {
                if (bookUp.Id == id)
                {
                    bookUpdate = bookUp;
                    break;
                }
            }
            bookUpdate.Title = book.Title;
            bookUpdate.Author = book.Author;
            return Json(bookUpdate);
        } */

        //-------------------------------

        [HttpDelete("LivresController/{id}")]
        //[HttpDelete("LivresController/DeleteBook/{id}")]
        //[HttpGet("LivresController/Delete/{id}")]
        public IActionResult DeleteBook(int id)
        {
            ///Book book = LivresController.Books.Find(id);

            // if (book == null)
            // {
            //     return Json(new { message = $"Book is deleted" });
            // }
            // return Json(book);
            return Json(new { message = "Book is deleted" });
        }
    }
}
