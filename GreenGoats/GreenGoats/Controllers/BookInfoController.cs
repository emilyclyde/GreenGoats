using GreenGoats.DAL;
using GreenGoats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenGoats.Controllers
{
    public class BookInfoController : Controller
    {
        // GET: BookInfo
      public ActionResult Index()
        {
          GrazingContext db = new GrazingContext();
          var authors = db.Authors.Include("Books"); //lamda expression not working here, used this " Authors" method instead

          //list of our book view model objects w/o scaffolding
          List<BookViewModel> vmList = new List<BookViewModel>();
          
          foreach(Author a in authors ) //where b is a single book from collection
          {
            
            var aBook = a.Books.FirstOrDefault(); //will take the first author

            vmList.Add(new BookViewModel()
            {
              Title =aBook.Title,
              Year = aBook.Year,
                 
              Author = new AuthorViewModel() //author is an object so we need a new list object here for author
                {
                Name=a.Name //here we set the name property of the author
                }
            });
          }
           return View(vmList);
        }
    }
  
}