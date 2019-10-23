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
  [Authorize] //new line
  public class BooksController : Controller
  {
    private readonly LibraryContext _db;
    private readonly UserManager<LibraryManager> _userManager; //new line

    //updated constructor
    public BooksController(UserManager<LibraryManager> userManager, LibraryContext db)
    {
      _userManager = userManager;
      _db = db;
    }
    public ActionResult Index()
    {
       List<Book> listOfBooks =  _db.Books.Include(p => p.Author).ToList();
       return View(listOfBooks);
    }
    [HttpGet]
    public ActionResult Create()
    {
        ViewBag.ListOfAuthors = _db.Authors.ToList();
        return View();
    }
    [HttpPost]
    public ActionResult Create(Book book)
    {
        _db.Books.Add(book);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    [HttpGet]
    public ActionResult AddCopies(int id)
    {
      Book foundBook = _db.Books.FirstOrDefault(b => b.BookID == id);
      return View(foundBook);
    }
    [HttpPost]
    public ActionResult AddCopies(int numberofcopies, int BookID)
    {
      Book foundBook = _db.Books.FirstOrDefault(b => b.BookID == BookID);
      for(var i = 0; i < numberofcopies; i++)
            {
                
                foundBook.Copies.Add(new Copies());
                
            }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpGet]
    public ActionResult Details(int id)
    {
      Book foundBook = _db.Books.Include(c => c.Author).Include(c => c.Copies).FirstOrDefault(b => b.BookID == id);
      return View(foundBook);
    }
  }
}
