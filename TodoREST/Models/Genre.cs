using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TodoREST.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Title { get; set; }

        public ICollection<ConcertGenre> ConcertGenres { get; set; }

    }
}
