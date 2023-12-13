using System;
using System.Collections.Generic;
using System.Text;

namespace TodoREST.Models
{
    public class ConcertGenre
    {
        public int ConcertId { get; set; }
        public int GenreId { get; set; }
        public Concert Concert { get; set; }
        public Genre Genre { get; set; }
    }
}
