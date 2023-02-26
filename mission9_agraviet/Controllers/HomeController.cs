using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mission9_agraviet.Models;
using mission9_agraviet.Models.ViewModels;

namespace mission9_agraviet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IBookstoreRepository repo;

        public HomeController(ILogger<HomeController> logger, IBookstoreRepository temp)
        {
            _logger = logger;
            repo = temp;
        }

        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 10;

            var books = new BooksViewModel
            {
                Books = repo.Books
                .OrderBy(p => p.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),
                PageInfo = new PageInfo
                {
                    TotalNumBooks = repo.Books.Count(),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };
            return View(books);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

