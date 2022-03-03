using System;
using System.Collections.Generic;
using GamersPlace.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GamersPlace.Controllers.Dto
{
    public class CreateGameDto
    {
        public Game game { get; set; }
        public List<Genre> genres { get; set; }

        public CreateGameDto(Game game, List<Genre> genres)
        {
            this.game = game;
            this.genres = genres;
        }
    }
}
