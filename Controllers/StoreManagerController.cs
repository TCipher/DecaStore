using DecaStore.Data.IServices;
using Microsoft.AspNetCore.Mvc;

namespace DecaStore.Controllers
{
    public class StoreManagerController : Controller
    {
        private readonly IGenreService _genreService;
        private readonly IAlbumService _albumService;
      

        public StoreManagerController(IGenreService genreService, IAlbumService albumService)
        {
            _genreService = genreService;
            _albumService = albumService;
        }

        // GET: StoreManager
        public async Task<IActionResult> Index()
        {
            var SM = await _albumService.StoreMangerAsync();
            return View(SM);
        }

        // GET: StoreManager/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _albumService.GetByAlbumIDAsync(id);
               
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        //        // GET: StoreManager/Create
        //        public IActionResult Create()
        //        {
        //            ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "Country");
        //            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "Description");
        //            return View();
        //        }

        //        // POST: StoreManager/Create
        //        // To protect from overposting attacks, enable the specific properties you want to bind to.
        //        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public async Task<IActionResult> Create([Bind("AlbumId,Title,Price,DateReleased,AlbumArtUrl,GenreId,ArtistId")] Album album)
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                album.AlbumId = Guid.NewGuid();
        //                _context.Add(album);
        //                await _context.SaveChangesAsync();
        //                return RedirectToAction(nameof(Index));
        //            }
        //            ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "Country", album.ArtistId);
        //            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "Description", album.GenreId);
        //            return View(album);
        //        }

        //        // GET: StoreManager/Edit/5
        //        public async Task<IActionResult> Edit(Guid? id)
        //        {
        //            if (id == null || _context.Albums == null)
        //            {
        //                return NotFound();
        //            }

        //            var album = await _context.Albums.FindAsync(id);
        //            if (album == null)
        //            {
        //                return NotFound();
        //            }
        //            ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "Country", album.ArtistId);
        //            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "Description", album.GenreId);
        //            return View(album);
        //        }

        //        // POST: StoreManager/Edit/5
        //        // To protect from overposting attacks, enable the specific properties you want to bind to.
        //        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public async Task<IActionResult> Edit(Guid id, [Bind("AlbumId,Title,Price,DateReleased,AlbumArtUrl,GenreId,ArtistId")] Album album)
        //        {
        //            if (id != album.AlbumId)
        //            {
        //                return NotFound();
        //            }

        //            if (ModelState.IsValid)
        //            {
        //                try
        //                {
        //                    _context.Update(album);
        //                    await _context.SaveChangesAsync();
        //                }
        //                catch (DbUpdateConcurrencyException)
        //                {
        //                    if (!AlbumExists(album.AlbumId))
        //                    {
        //                        return NotFound();
        //                    }
        //                    else
        //                    {
        //                        throw;
        //                    }
        //                }
        //                return RedirectToAction(nameof(Index));
        //            }
        //            ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "Country", album.ArtistId);
        //            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "Description", album.GenreId);
        //            return View(album);
        //        }

        //        // GET: StoreManager/Delete/5
        //        public async Task<IActionResult> Delete(Guid? id)
        //        {
        //            if (id == null || _context.Albums == null)
        //            {
        //                return NotFound();
        //            }

        //            var album = await _context.Albums
        //                .Include(a => a.Artist)
        //                .Include(a => a.Genre)
        //                .FirstOrDefaultAsync(m => m.AlbumId == id);
        //            if (album == null)
        //            {
        //                return NotFound();
        //            }

        //            return View(album);
        //        }

        //        // POST: StoreManager/Delete/5
        //        [HttpPost, ActionName("Delete")]
        //        [ValidateAntiForgeryToken]
        //        public async Task<IActionResult> DeleteConfirmed(Guid id)
        //        {
        //            if (_context.Albums == null)
        //            {
        //                return Problem("Entity set 'ApplicationDbContext.Albums'  is null.");
        //            }
        //            var album = await _context.Albums.FindAsync(id);
        //            if (album != null)
        //            {
        //                _context.Albums.Remove(album);
        //            }

        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }

        //        private bool AlbumExists(Guid id)
        //        {
        //          return _context.Albums.Any(e => e.AlbumId == id);
        //        }
    }
}
