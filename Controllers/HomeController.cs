using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GamersPlace.Models;
using GamersPlace.Repositories;

namespace GamersPlace.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Game> repository;

        public HomeController(IRepository<Game> repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GameView(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Game game = this.repository.FindOneById((int)id);
            return View(game);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
