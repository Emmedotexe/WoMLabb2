using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using TodoREST.Models;

namespace TodoREST.Data
{
    public class DbInitializer
    {
        public static void Initialize(ConcertContext context)
        {
            context.Database.EnsureCreated();

            if (context.Concerts.Any())
            {
                return;
            }

            Genre rock = new Genre();
            rock.Title = "Rock";
            Genre pop = new Genre();
            pop.Title = "Pop";
            Genre house = new Genre();
            house.Title = "House";
            Genre rap = new Genre();
            rap.Title = "Rap";
            Genre epadunk = new Genre();
            epadunk.Title = "Epa-Dunk";
            context.Genres.Add(rock);
            context.Genres.Add(pop);
            context.Genres.Add(house);
            context.Genres.Add(rap);
            context.Genres.Add(epadunk);
            



            Concert concert1 = new Concert
            {
                Titel = "RockTorsdag!",
                Description = "Rocka på, rocka på!",
                Length = "3H",
                Price = 500,
                ConcertGenres = new List<ConcertGenre> { }
                
            };

            //-------------------Many-to-Many relationship-------------------------
            ConcertGenre cGenre1 = new ConcertGenre();
            cGenre1.Concert = concert1;
            cGenre1.Genre = rock;
            concert1.ConcertGenres.Add(cGenre1);
            //---------------------------------------------------------------------

            Concert concert2 = new Concert
            {
                Titel = "EPA Fredag",
                Description = "EPA dunk till öronen faller av.",
                Length = "2H",
                Price = 400,
                ConcertGenres = new List<ConcertGenre> { }
            };

            //-------------------Many-to-Many relationship-------------------------
            ConcertGenre cGenre2 = new ConcertGenre();
            cGenre2.Concert = concert2;
            cGenre2.Genre = epadunk;
            concert2.ConcertGenres.Add(cGenre2);
            //---------------------------------------------------------------------

            Concert concert3 = new Concert
            {
                Titel = "SMASHED",
                Description = "Bästa NPC blandningen för riktiga normies",
                Length = "8H",
                Price = 3000,
                ConcertGenres = new List<ConcertGenre> { }
            };

            //-------------------Many-to-Many relationship-------------------------
            ConcertGenre cGenre3 = new ConcertGenre();
            cGenre3.Concert = concert3;
            cGenre3.Genre = pop;
            ConcertGenre cGenre4 = new ConcertGenre();
            cGenre4.Concert = concert3;
            cGenre4.Genre = rap; 
            ConcertGenre cGenre5 = new ConcertGenre();
            cGenre5.Concert = concert3;
            cGenre5.Genre = house;
            concert3.ConcertGenres.Add(cGenre3);
            concert3.ConcertGenres.Add(cGenre4);
            concert3.ConcertGenres.Add(cGenre5);
            //---------------------------------------------------------------------


            context.Concerts.Add(concert1);
            context.Concerts.Add(concert2);
            context.Concerts.Add(concert3);



            Show show1 = new Show { Location = "Ullevi", ConcertToShow = concert1, Date = new DateTime(2023, 06, 15, 16, 00, 00) };
            Show show15 = new Show { Location = "Ullevi", ConcertToShow = concert1, Date = new DateTime(2023, 06, 17, 16, 00, 00) };
            Show show155 = new Show { Location = "Ullevi", ConcertToShow = concert1, Date = new DateTime(2023, 06, 20, 16, 00, 00) };

            Show show2 = new Show { Location = "Bakgården", ConcertToShow = concert2, Date = new DateTime(2023, 08, 20, 22, 00, 00) };
            Show show25 = new Show { Location = "Bakgården", ConcertToShow = concert2, Date = new DateTime(2023, 08, 22, 22, 00, 00) };
            Show show255 = new Show { Location = "Bakgården", ConcertToShow = concert2, Date = new DateTime(2023, 08, 30, 22, 00, 00) };

            Show show3 = new Show { Location = "Avicii Arena", ConcertToShow = concert3, Date = new DateTime(2023, 10, 5, 18, 00, 00) };
            Show show35 = new Show { Location = "Avicii Arena", ConcertToShow = concert3, Date = new DateTime(2023, 10, 7, 18, 00, 00) };
            Show show355 = new Show { Location = "Avicii Arena", ConcertToShow = concert3, Date = new DateTime(2023, 10, 15, 18, 00, 00) };


            context.Shows.Add(show1);
            context.Shows.Add(show15);
            context.Shows.Add(show155);

            context.Shows.Add(show2);
            context.Shows.Add(show25);
            context.Shows.Add(show255);

            context.Shows.Add(show3);
            context.Shows.Add(show35);
            context.Shows.Add(show355);


            var Bookings = new Booking[]
            {
                new Booking{BookingNumber=1, CustomerName="Clas Göran", CustomerMail="classe61@hotmail.com", BookedShow=show1},
                new Booking{BookingNumber=2, CustomerName="Fabian Sundin", CustomerMail="xSnipe@gmail.com", BookedShow=show2}
            };
            foreach (Booking b in Bookings)
            {
                context.Bookings.Add(b);
            }
            context.ConcertGenres.AddRange(cGenre1, cGenre2, cGenre3, cGenre4, cGenre5);


            context.SaveChanges();
        }
    }
}
