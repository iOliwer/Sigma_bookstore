using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace BookStore.Models
{
    /// <summary>
    /// Implemation av IBookRepository
    /// </summary>
    public class BookRepository : IBookRepository
    {
        //Skapar ett privatfält för att göra den tillgänlig över hela scopet.
        private IEnumerable<XElement> booksInStore;


        public BookRepository()
        {
            //Läser in datan från datakällan
            XElement books = XElement.Load(HttpContext.Current.Server.MapPath("~/Data/books.xml"));
            booksInStore = books.Elements();//Placerar en samling av alla childélement
        }

        /// <summary>
        /// Metod för att hämta ut all våra böcker.
        /// </summary>
        /// <returns>Retunerar IENumerble av typen Book</returns>
        public IEnumerable<Book> GetAll()
        {
            return (from b in booksInStore
                select new Book
                {
                    Title = (string) b.Element("title"),
                    Author = (string) b.Element("author"),
                    Genre = (string) b.Element("genre"),
                    Price = (decimal) b.Element("price"),
                    PublishDate = (DateTime) b.Element("publish_date"),
                    Description = (string) b.Element("description"),
                    Id = (string) b.Attribute("id")
                });
        }

        /// <summary>
        /// Metod för att hämta ut de böckerna som matchar vår sökterm
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns>Retunerar en lista av objektet Book</returns>
        public List<Book> SearchByTerm(string searchTerm)
        {
            var booksFromXml =
                booksInStore
                    .Where(x => x.ToString().ToLower().Contains(searchTerm.ToLower()))
                    .Select(x => new Book
                    {
                        Title = (string) x.Element("title"),
                        Author = (string) x.Element("author"),
                        Genre = (string) x.Element("genre"),
                        Price = (decimal) x.Element("price"),
                        PublishDate = (DateTime) x.Element("publish_date"),
                        Description = (string) x.Element("description"),
                        Id = (string) x.Attribute("id")
                    }).ToList();

            return booksFromXml;
        }

        /// <summary>
        /// Hämtar ut ett specifikt bokobjekt medhjälp av inskickat id
        /// </summary>
        /// <para>Hämtar ett bokobjekt efter önskat id</para>
        /// <param name="id"></param>
        /// <returns>Retunerar ett bokobjekt.</returns>
        public Book GetBookById(string id)
        {
            var booksFromXml =
                booksInStore
                    .Where(x => x.Attribute("id").Value == id.ToUpper())
                    .Select(x => new Book
                    {
                        Title = (string) x.Element("title"),
                        Author = (string) x.Element("author"),
                        Genre = (string) x.Element("genre"),
                        Price = (decimal) x.Element("price"),
                        PublishDate = (DateTime) x.Element("publish_date"),
                        Description = (string) x.Element("description"),
                        Id = (string) x.Attribute("id")
                    }).FirstOrDefault(); //Retunerar ett defaultvärde om inte matchning sker tidigare.

            return booksFromXml;
        }
    }
}