using System;
using System.Collections.Generic;
using System.Linq;
using GamersPlace.Data;
using GamersPlace.Models;
using Microsoft.EntityFrameworkCore;

namespace GamersPlace.Repositories
{
    public class GamesRepositoryImpl : IRepository<Game>
    {
        ApplicationDbContext dbContext;

        public GamesRepositoryImpl(ApplicationDbContext applicationDbContext)
        {
            this.dbContext = applicationDbContext;
        }

        public Game DeleteOneById(int id)
        {
            Game gameToDelete = this.dbContext.Games.Include("GameGenre").FirstOrDefault(g => g.GameId == id);
            this.dbContext.Remove(gameToDelete);
            this.dbContext.SaveChanges();
            return gameToDelete;
        }

        public List<Game> FindAll()
        {
            return this.dbContext.Games.Include("GameGenre").ToList();
        }

        public Game FindOneById(int id)
        {
            return this.dbContext.Games.Include("GameGenre").FirstOrDefault(g => g.GameId == id);
        }

        public Game Insert(Game item)
        {
            Game createdGenre = this.dbContext.Games.Add(item).Entity;
            this.dbContext.SaveChanges();
            return createdGenre;
        }

        public Game Update(Game item)
        {
            this.dbContext.Games.Update(item);
            this.dbContext.SaveChanges();
            return item;
        }
    }
}
