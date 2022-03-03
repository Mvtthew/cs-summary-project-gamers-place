using GamersPlace.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GamersPlace.Models
{
    public class Game
    {
        public int GameId { get; set; }

        public Genre GameGenre { get; set; }

        public int GameGenreId { get; set; }

        public string Name { get; set; }

        public int Score { get; set; }

        public string description { get; set; }

        public string YearReleased { get; set; }

        public string CoverImageUrl { get; set; }
    }
}
