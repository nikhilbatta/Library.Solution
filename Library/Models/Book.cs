using System.Collections.Generic;
using System;
using System.Linq;

namespace Library.Models
{
    public class Book
    {
        public int BookID {get;set;}
        public string Title{get;set;}
        public virtual Author Author {get;set;}
        public virtual ICollection<Copies> Copies {get;set;}
        public Book()
        {
            
            this.Copies = new HashSet<Copies>{};  
        }
    }
}