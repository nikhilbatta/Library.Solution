using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class AuthorBooks
    {
        public int AuthorBooksID {get;set;}
        public int BookID {get;set;}
        public int AuthorID {get;set;}
        [ForeignKey("AuthorID")]
        public Author Author {get;set;}
        [ForeignKey("BookID")]
        public Book Book {get;set;}
    }
}
