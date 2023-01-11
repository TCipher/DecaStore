using DecaStore.Data.IServices;
using Microsoft.AspNetCore.Mvc;

namespace DecaStore.Controllers
{
    public class StoreController : Controller
    {
        private readonly IGenreService _genreService;
        private readonly IAlbumService _albumService;
        public StoreController(IGenreService genreService, IAlbumService albumService)
        {
            _genreService = genreService;
            _albumService = albumService;
        }
        //GET: /Store/
        public async Task<IActionResult> Index()
        {
            try
            {
                var genre = await _genreService.GetAllGenreAsnyc();
                return View(genre);
            }
            catch (System.Exception)
            {

                throw;
            }


        }


        //
        //GET: /Store/Browse?genre= genre Name
        public async Task<ActionResult> Browse(string genre)
        {

            try
            {
                var genreModel = await _genreService.GetByNameAsync(genre);
                return View(genreModel);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> Details(Guid id)
        {
            try
            {
                var album = await _albumService.GetByAlbumIDAsync(id);
                return View(album);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
