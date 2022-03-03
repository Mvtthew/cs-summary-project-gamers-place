using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GamersPlace.Data;
using GamersPlace.Models;
using GamersPlace.Repositories;
using GamersPlace.Controllers.Dto;
using Microsoft.AspNetCore.Authorization;

namespace GamersPlace.Controllers
{
    public class GameController : Controller
    {
        private readonly IRepository<Game> repository;
        private readonly IRepository<Genre> genresRepository;

        public GameController(IRepository<Game> repository, IRepository<Genre> genresRepository)
        {
            this.repository = repository;
            this.genresRepository = genresRepository;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View(this.repository.FindAll());
        }

        [Authorize]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = this.repository.FindOneById((int)id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        [Authorize]
        public IActionResult Create()
        {
            List<Genre> genres = genresRepository.FindAll();

            return View(new CreateGameDto(new Game(), genres));
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("GameId,GameGenreId,Name,Score,description,YearReleased,CoverImageUrl")] Game game)
        {
            if (ModelState.IsValid)
            {
                this.repository.Insert(game);
                return RedirectToAction(nameof(Index));
            }

            List<Genre> genres = genresRepository.FindAll();

            return View(new CreateGameDto(game, genres));
        }

        [Authorize]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = this.repository.FindOneById((int)id);
            if (game == null)
            {
                return NotFound();
            }

            List<Genre> genres = genresRepository.FindAll();

            return View(new CreateGameDto(game, genres));
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(
            int id,
            [Bind("GameId,GameGenreId,Name,Score,description,YearReleased,CoverImageUrl")] Game game)
        {
            if (id != game.GameId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this.repository.Update(game);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (this.repository.FindOneById(game.GameId) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }

        [Authorize]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = this.repository.FindOneById((int)id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            this.repository.DeleteOneById(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
