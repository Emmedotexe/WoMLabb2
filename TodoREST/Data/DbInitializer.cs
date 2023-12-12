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

           
            Concert concert1 = new Concert
            {
                Titel = "RockTorsdag!",
                Description = "Rocka på, rocka på!",
                Length = "3H",
                Price = 500
            };
            concert1.Genres.Add(Genre.Rock);

            Concert concert2 = new Concert
            {
                Titel = "EPA Fredag",
                Description = "EPA dunk till öronen faller av.",
                Length = "2H",
                Price = 400
            };
            concert2.Genres.Add(Genre.EPA_Dunk);

            Concert concert3 = new Concert
            {
                Titel = "SMASHED",
                Description = "Bästa NPC blandningen för riktiga normies",
                Length = "8H",
                Price = 3000
            };
            concert3.Genres.Add(Genre.Pop);
            concert3.Genres.Add(Genre.Rap);
            concert3.Genres.Add(Genre.House);

            context.Concerts.Add(concert1);
            context.Concerts.Add(concert2);
            context.Concerts.Add(concert3);
            context.SaveChanges();


            Show show1 = new Show { Location = "Ullevi", ConcertToShow = concert1, Date = new DateTime(2023, 06, 15, 16, 00, 00) };
            Show show2 = new Show { Location = "Backgården", ConcertToShow = concert2, Date = new DateTime(2023, 08, 20, 22, 00, 00) };
            Show show3 = new Show { Location = "Avicii Arena", ConcertToShow = concert3, Date = new DateTime(2023, 10, 5, 18, 00, 00) };

            context.Shows.Add(show1);
            context.Shows.Add(show2);
            context.Shows.Add(show3);
            context.SaveChanges();

            var Bookings = new Booking[]
            {
                new Booking{BookingNumber=1, CustomerName="Clas Göran", CustomerMail="classe61@hotmail.com", BookedShow=show1},
                new Booking{BookingNumber=2, CustomerName="Fabian Sundin", CustomerMail="xSnipe@gmail.com", BookedShow=show2}
            };
            foreach (Booking b in Bookings)
            {
                context.Bookings.Add(b);
            }
            context.SaveChanges();
        }
    }
}
