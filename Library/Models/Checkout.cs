using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Checkout
    {
        public int CheckoutID{get;set;}
        public int CopiesID{get;set;}
        public int PatronID{get;set;}
        [ForeignKey("CopiesID")]
        public Copies Copies {get;set;}
        [ForeignKey("PatronID")]
        public Patron Patron{get;set;}
        public string CheckoutDate{get;set;}
        public string DueDate{get;set;}
    }
}