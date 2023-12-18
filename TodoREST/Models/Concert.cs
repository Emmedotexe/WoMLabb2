using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TodoREST.Models
{
    public class Concert
    {
        
        public int ID { get; set; }
        public string Titel { get; set; }
        public string Description { get; set; }
        public string Length { get; set; }
        public int Price { get; set; }
        [NotMapped]
        public List<Genre> Genres { get; set; }

        public ICollection<ConcertGenre> ConcertGenres { get; set; }

    }
}
