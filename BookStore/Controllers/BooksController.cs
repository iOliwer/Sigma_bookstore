using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;
using BookStore.Models;
using Microsoft.Ajax.Utilities;

namespace BookStore.Controllers
{
    public class BooksController : ApiController
    {
        /// <summary>
        /// Nytt objekt med metoder från BookRepository
        /// </summary>
        readonly IBookRepository _repository = new BookRepository();

        /// <summary>
        /// Hämtar alla ut alla böckerna som finns i vår datakälla
        /// </summary>
        /// <returns>Retunerar en IEnumerable av typen Book</returns>
        public IEnumerable<Book> GetAllBooks()
        {
            return _repository.GetAll();
        }

        /// <summary>
        /// Hämtar ut alla böckerna som passar in på söktermen. 
        /// </summary>
        /// <param>searchTerm</param>
        /// <returns>Retunerar en Lista med böcker</returns>
        public List<Book> GetBooksByTitle(string searchTerm)
        {
            return _repository.SearchByTerm(searchTerm);
        }

        /// <summary>
        /// Hämtar ut en ett bokobjekt med inskickat id innehållande samtliga egenskaper
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Retunerar ett bokobjekt</returns>
        public HttpResponseMessage GetBookById(string id)
        {
            var book = _repository.GetBookById(id);

            return book == null
                ? Request.CreateResponse(HttpStatusCode.NotFound) //Skickar statuskod 404 om defaultvärde skickas från GetBookById i BookStore.models
                : Request.CreateResponse(HttpStatusCode.OK, book); //Skickar statuskod 200 med objektet Book om id fanns.
        }
    }
}
