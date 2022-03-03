using System;
using System.Collections.Generic;
using System.Linq;
using GamersPlace.Data;
using GamersPlace.Models;

namespace GamersPlace.Repositories
{
    public class GenresRepositoryImpl : IRepository<Genre>
    {
        ApplicationDbContext dbContext;

        public GenresRepositoryImpl(ApplicationDbContext applicationDbContext)
        {
            this.dbContext = applicationDbContext;
        }

        public Genre DeleteOneById(int id)
        {
            Genre genreToDelete = this.dbContext.Genres.FirstOrDefault(g => g.GenreId == id);
            this.dbContext.Remove(genreToDelete);
            this.dbContext.SaveChanges();
            return genreToDelete;
        }

        public List<Genre> FindAll()
        {
            return this.dbContext.Genres.ToList();
        }

        public Genre FindOneById(int id)
        {
            return this.dbContext.Genres.FirstOrDefault(g => g.GenreId == id);
        }

        public Genre Insert(Genre item)
        {
            Genre createdGenre = this.dbContext.Genres.Add(item).Entity;
            this.dbContext.SaveChanges();
            return createdGenre;
        }

        public Genre Update(Genre item)
        {
            this.dbContext.Genres.Update(item);
            this.dbContext.SaveChanges();
            return item;
        }
    }
}
