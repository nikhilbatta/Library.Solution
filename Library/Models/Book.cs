using System.Collections.Generic;

namespace Library.Models
{
    public class Book
    {
        public int BookID {get;set;}
        public string Title{get;set;}
        public string ReleaseDate {get;set;}
        public string Publisher{get;set;}
        public virtual ICollection<AuthorBooks> Authors {get;set;}
        public Book()
        {
            this.Authors = new HashSet<AuthorBooks>();
        }
    }
}