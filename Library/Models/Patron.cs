using System.Collections.Generic;

namespace Library.Models
{
    public class Patron
    {
        public int PatronID {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public ICollection<Checkout> Copies{get;set;}
        public Patron()
        {
            this.Copies = new HashSet<Checkout>();
        }
    }
}