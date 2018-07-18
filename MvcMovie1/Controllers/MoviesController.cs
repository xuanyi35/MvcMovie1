using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie1.Models;
using System.Web;
using HtmlAgilityPack;

namespace MvcMovie1.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MvcMovie1Context _context;

        public MoviesController(MvcMovie1Context context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {

            //return View(await _context.Movie.ToListAsync());

            var movies = from m in _context.Movie
                         select m;
            object uid = TempData.Peek("UserID");
            if (uid != null)
            {
                movies = movies.Where(s => s.UserID == Convert.ToInt32(uid));
            }

            return View(await movies.ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .SingleOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,ReleaseDate,Genre,Homepage")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                movie.UserID = Convert.ToInt32(TempData.Peek("Userid"));
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.SingleOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,ReleaseDate,Genre,Homepage")] Movie movie)
        {
            if (id != movie.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    movie.UserID = Convert.ToInt32(TempData.Peek("Userid"));
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.ID))
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
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .SingleOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.SingleOrDefaultAsync(m => m.ID == id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.ID == id);
        }

    

      
        // POST: Movies/CreateFromApi
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> CreateFromApi(int id , Movie movie)
         {



             if (TempData.Peek("UserId") == null)
             {
            
                 return RedirectToAction("About", "Home");
             }
             else
             {

                //HtmlWeb page = new HtmlWeb();
                //HtmlDocument document = page.Load("http://localhost:50450/Home/MovieDetail");

              



                movie.Title = Convert.ToString(ViewData["Title"]);
                   movie.ReleaseDate = Convert.ToDateTime(ViewData["ReleaseDate"]);
                   movie.Genre = Convert.ToString(ViewData["Genre"]);
                   movie.UserID = Convert.ToInt32(TempData.Peek("UserId"));
                    movie.Homepage = Convert.ToString(ViewData["Homepage "]);

                 /*movie.Title = "xxxxx";
                 movie.ReleaseDate = DateTime.Parse("2018-9-3");
                 movie.UserID = Convert.ToInt32(TempData.Peek("UserId"));
                 movie.Genre = "Romantic Comedy";
                 */
                 _context.Add(movie);
                 await _context.SaveChangesAsync();
                 return RedirectToAction("Index", "Home");

            }

         }
         








    }
}
