using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace BookStore.Models
{
    /// <summary>
    /// Samtliga egenskaper för Book.
    /// </summary>
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public string Genre { get; set; }
        public string Id { get; set; }
    }
}