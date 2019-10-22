using System.Collections.Generic;

namespace Library.Models
{
    public class Author
    {
        public int AuthorID{get;set;}
        public string FirstName{get;set;}
        public string LastName{get;set;}
        public virtual ICollection<AuthorBooks> Books{get;set;}
        public Author()
        {
            this.Books = new HashSet<AuthorBooks>();
        }
    }
}