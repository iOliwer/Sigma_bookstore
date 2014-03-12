using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookStore.Models
{
    /// <summary>
    /// Signaturerna av våra metoder som kommer att implementeras i vårt bookrepository
    /// </summary>
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        List<Book> SearchByTerm(string searchTerm);
        Book GetBookById(string id);
    }
}
