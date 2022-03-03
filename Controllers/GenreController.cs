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
using Microsoft.AspNetCore.Authorization;

namespace GamersPlace.Controllers
{
    public class GenreController : Controller
    {
        private readonly IRepository<Genre> repository;

        public GenreController(IRepository<Genre> repository)
        {
            this.repository = repository;
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

            var genre = this.repository.FindOneById((int)id);
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("GenreId,Name,CoverImageUrl")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                this.repository.Insert(genre);
                return RedirectToAction(nameof(Index));
            }
            return View(genre);
        }

        [Authorize]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = this.repository.FindOneById((int)id);
            if (genre == null)
            {
                return NotFound();
            }
            return View(genre);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("GenreId,Name,CoverImageUrl")] Genre genre)
        {
            if (id != genre.GenreId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this.repository.Update(genre);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (this.repository.FindOneById(genre.GenreId) == null)
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
            return View(genre);
        }

        [Authorize]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = this.repository.FindOneById((int)id);
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
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
