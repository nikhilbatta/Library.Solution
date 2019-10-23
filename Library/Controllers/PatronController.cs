using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using System;

namespace Library.Controllers
{
    public class PatronController : Controller
    {
        private readonly LibraryContext _db;
        public PatronController(LibraryContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            List<Patron> listOfPatrons = _db.Patrons.Include(p => p.Copies).ToList();
            return View(listOfPatrons);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Patron newPatron)
        {
            _db.Patrons.Add(newPatron);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Checkout(int bookid, int copyid)
        {
            Console.WriteLine(bookid);
            Console.WriteLine(copyid);
            ViewBag.PatronID = new SelectList(_db.Patrons, "PatronID", "FirstName");
            
            Copies foundCopy = _db.Copies.Include(c => c.Book).FirstOrDefault(c => c.CopiesID == copyid && c.Book.BookID == bookid);
           
            Console.WriteLine(foundCopy.CopiesID);
            ViewBag.CopyID = copyid;
            return View();
            
        }
        [HttpPost]
        public ActionResult Checkout(Checkout checkout)
        { 

            _db.Checkouts.Add(checkout);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        // public ActionResult CheckBackIn()
        // {

        // }
    }
    
}