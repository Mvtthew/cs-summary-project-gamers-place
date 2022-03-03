using System;
using System.Collections.Generic;
using System.Text;
using GamersPlace.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GamersPlace.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {


        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}
