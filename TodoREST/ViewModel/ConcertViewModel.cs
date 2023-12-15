using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TodoREST.Models;

namespace TodoREST.ViewModel
{
    
    class ConcertViewModel
    {
        public List<Concert> Concerts { get; set; }
        public List<Genre> GenreList{ get; set; }
        public ConcertViewModel(List<Concert> concerts) 
        {
            Concerts = concerts;
            foreach (Concert item in Concerts)
            {
                foreach (Genre g in item.Genres)
                {
                    GenreList.Add(g);
                }
            }
            GenreList.Distinct().ToList();

        }
    }
}
