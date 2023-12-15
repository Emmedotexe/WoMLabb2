﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using TodoREST.Data;
using TodoREST.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TodoAPI.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
    public class ConcertsController : Controller
    {
        private readonly ConcertContext _context;

        public ConcertsController(ConcertContext context)
        {
            _context = context;
        }

        // GET: Concerts
        [HttpGet]
        public IActionResult List()
        {
            return Ok(PopulateGenres());

        }
        public List<Concert> PopulateGenres() {
            List<Concert> concerts = new List<Concert>(); 
           
            foreach (var item in _context.Concerts)
            {
                item.Genres = new List<Genre>();
                var concertGenresQuery =
            from cg in _context.ConcertGenres
            where cg.ConcertId == item.ID
            join g in _context.Genres on cg.GenreId equals g.GenreId
            select g;

                foreach (Genre g in concertGenresQuery)
                {
                    
                    item.Genres.Add(g);
                }
                concerts.Add(item);
            }
            return concerts;
        }

        [Route("Shows")]
        public IActionResult Shows()
        {
            return Ok(PopulateConcerts());
        }

        public List<Show> PopulateConcerts()
        {
            var showWithConcert = _context.Shows.Include(s => s.ConcertToShow);

            return PopulateGenres(showWithConcert.ToList());
        }

        public List<Show> PopulateGenres(List<Show> shows)
        {
            
            foreach (var show in shows)
            {
                show.ConcertToShow.Genres = new List<Genre>();

                var concertGenresQuery =
                from cg in _context.ConcertGenres
                where cg.ConcertId == show.ConcertToShow.ID
                join g in _context.Genres on cg.GenreId equals g.GenreId
                select g;

                    foreach (Genre g in concertGenresQuery)
                    {
                       show.ConcertToShow.Genres.Add(g);
                    }
            }
            return shows;
        }
            
        


        public async Task<IActionResult> Index()
        {
            return View(await _context.Concerts.ToListAsync());
        }

        // GET: Concerts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concert = await _context.Concerts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (concert == null)
            {
                return NotFound();
            }

            return View(concert);
        }

        // GET: Concerts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Concerts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Titel,Description,Length,Price")] Concert concert)
        {
            if (ModelState.IsValid)
            {
                _context.Add(concert);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(concert);
        }

        // GET: Concerts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concert = await _context.Concerts.FindAsync(id);
            if (concert == null)
            {
                return NotFound();
            }
            return View(concert);
        }

        // POST: Concerts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Titel,Description,Length,Price")] Concert concert)
        {
            if (id != concert.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(concert);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConcertExists(concert.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(concert);
        }

        // GET: Concerts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concert = await _context.Concerts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (concert == null)
            {
                return NotFound();
            }

            return View(concert);
        }

        // POST: Concerts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var concert = await _context.Concerts.FindAsync(id);
            _context.Concerts.Remove(concert);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConcertExists(int id)
        {
            return _context.Concerts.Any(e => e.ID == id);
        }
    }
}
