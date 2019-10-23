namespace Library.Models
{
    public class Copies
    {
        public int CopiesID{get;set;}
        public Book Book {get;set;}
        public Patron Patron {get;set;}
        public bool isCheckedOut{get;set;}
    }
}