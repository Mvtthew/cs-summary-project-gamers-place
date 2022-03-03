using GamersPlace.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace GamersPlace.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }

        public string Name { get; set; }

        public string CoverImageUrl { get; set; }
    }
}
