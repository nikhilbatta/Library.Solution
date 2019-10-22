using System.Collections.Generic;

namespace Library.Models
{
    public class Book
    {
        public int BookID {get;set;}
        public string Title{get;set;}
        public string ReleaseDate {get;set;}
        public string Publisher{get;set;}
        public int CopyQuantity{get;set;}
        public virtual ICollection<AuthorBooks> Authors {get;set;}
        public virtual ICollection<Copies> Copies {get;set;}
        public Book()
        {
            this.Authors = new HashSet<AuthorBooks>();
            this.Copies = new HashSet<Copies>{};
            for(var i = 0; i < CopyQuantity; i++)
            {
                Copies.Add(new Copies());
            }
        }
    }
}