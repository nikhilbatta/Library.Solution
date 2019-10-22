using System.Collections.Generic;
using System;
using System.Linq;

namespace Library.Models
{
    public class Book
    {
        public int BookID {get;set;}
        public string Title{get;set;}
        public int CopyQuantity{get;set;}
        public virtual ICollection<AuthorBooks> Authors {get;set;}
        public virtual ICollection<Copies> Copies {get;set;}
        public Book()
        {
            this.Authors = new HashSet<AuthorBooks>();
        }
        public static Copy FindCopy(int ID)
        {
            return Book.Copies.FirstOrDefault(c => c.CopiesID == ID);

        }
        public static void AddCopies(int ID)
        {

            this.Copies = new HashSet<Copies>{};
            for(var i = 0; i < this.CopyQuantity; i++)
            {
                Console.WriteLine("loophit");
                this.Copies.Add(new Copies());
                Console.WriteLine(this.Copies.ElementAt(0));
            }
        }
    }
}