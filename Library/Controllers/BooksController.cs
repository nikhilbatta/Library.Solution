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

namespace ToDoList.Controllers
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
       List<Book> listOfBooks =  _db.Books.Include(c=> c.Author).ToList();
       return View(listOfBooks);
    }
    [HttpGet]
    public ActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public ActionResult Create(Book book)
    {
        _db.Books.Add(book);
        foreach(Copies copy in book.Copies)
        {
                 Console.WriteLine(copy);
        }
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
      Console.WriteLine(BookID);
      Console.WriteLine(foundBook.Title);
      for(var i = 0; i < numberofcopies; i++)
            {
                Console.WriteLine("loophit");
                foundBook.Copies.Add(new Copies());
                Console.WriteLine(foundBook.Copies.ElementAt(0));
            }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpGet]
    public ActionResult Details(int id)
    {
      Book foundBook = _db.Books.FirstOrDefault(b => b.BookID == id);
      return View(foundBook);
    }
  }
}
