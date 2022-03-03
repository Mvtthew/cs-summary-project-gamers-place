using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamersPlace.Models;
using GamersPlace.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamersPlace.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameApiController : ControllerBase
    {

        private readonly IRepository<Game> repository;

        public GameApiController(IRepository<Game> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public List<Game> Get()
        {
            return this.repository.FindAll();
        }

        [HttpGet("{id}", Name = "Get")]
        public Game Get(int id)
        {
            return this.repository.FindOneById((int)id);
        }
    }
}
