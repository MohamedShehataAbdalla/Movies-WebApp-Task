using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies_WebApp.Code;
using Movies_WebApp.Models;
using Movies_WebApp.ViewModels;
using NToastNotify;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_WebApp.Controllers
{
    public class MovieCleanCodeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IToastNotification _toastNotification;
        private readonly CountryData _countryData;
        private readonly int _imageWidth = 2000;
        private readonly int _imageHeight = 2000;
        private readonly int _maxLength = 1_048_576; // 1 MB
        private readonly List<string> _allowedExtensions = new List<string> { ".jpg", ".jpeg", ".png", ".webp", ".tiff", ".tif", ".bmp" };

        public MovieCleanCodeController(AppDbContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
            _countryData = new CountryData();
        }
        private async Task<MovieViewModel> PopulateMovieViewModelAsync(MovieViewModel model)
        {
            model.Countries = _countryData.Countries.ToList();
            model.CountryToLanguages = _countryData.CountryToLanguages;
            model.Genres = await _context.Genres.Where(x => x.Active).OrderBy(x => x.Name).ToListAsync();

            return model;
        }

        private async Task<IActionResult> ValidatePosterAsync(MovieViewModel model)
        {
            var files = Request.Form.Files;

            if (!files.Any())
            {
                ModelState.AddModelError("Poster", "Please select a movie poster!");
                await PopulateMovieViewModelAsync(model);
                return View("MovieForm", model);
            }

            var poster = files.FirstOrDefault();

            if (!_allowedExtensions.Contains(Path.GetExtension(poster.FileName.ToLower())))
            {
                ModelState.AddModelError("Poster", $"Only {string.Join(", ", _allowedExtensions)} are allowed!");
                await PopulateMovieViewModelAsync(model);
                return View("MovieForm", model);
            }

            
            if (poster.Length > _maxLength)
            {
                ModelState.AddModelError("Poster", "Poster cannot be more than 1 MB!");
                await PopulateMovieViewModelAsync(model);
                return View("MovieForm", model);
            }

            

            using (var stream = poster.OpenReadStream())
            using (var image = Image.FromStream(stream))
            {
                if (image.Height > _imageHeight || image.Width > _imageWidth)
                {
                    ModelState.AddModelError("Poster", "Poster is larger than 2000px in either width or height!");
                    await PopulateMovieViewModelAsync(model);
                    return View("MovieForm", model);
                }
            }

            using var dataStream = new MemoryStream();
            await poster.CopyToAsync(dataStream);
            model.Poster = dataStream.ToArray();

            return null; // Validation passed
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _context.Movies.OrderByDescending(m => m.Rate).ToListAsync();
            return View(movies);
        }

        

        public async Task<IActionResult> Create()
        {
            var viewModel = new MovieViewModel();
            await PopulateMovieViewModelAsync(viewModel);
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await PopulateMovieViewModelAsync(model);
                return View("MovieForm", model);
            }

            var validationErrorResult = await ValidatePosterAsync(model);
            if (validationErrorResult != null)
            {
                return validationErrorResult;
            }

            var movie = new Movie
            {
                Title = model.Title,
                GenreId = model.GenreId,
                Year = model.Year,
                Rate = model.Rate,
                Storyline = model.Storyline,
                Country = model.Country,
                Language = model.Language,
                Url = model.Url,
                Poster = model.Poster,

            };

            _context.Movies.Add(movie);
            _context.SaveChanges();

            _toastNotification.AddSuccessToastMessage("Movie created successfully");

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return BadRequest();

            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
                return NotFound();

            var countryData = new CountryData();
            var viewModel = new MovieViewModel
            {
                Id = movie.Id,
                GenreId = movie.GenreId,
                Year = movie.Year,
                Rate = movie.Rate,
                Storyline = movie.Storyline,
                Title = movie.Title,
                Url = movie.Url,
                Poster = movie.Poster,
                Country = movie.Country,
                Language = movie.Language,
            };
            await PopulateMovieViewModelAsync(viewModel);

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MovieViewModel model)
        {
            if (model == null)
                return BadRequest();

            var movie = await _context.Movies.FindAsync(model.Id);

            if (movie == null)
                return NotFound();

            if (!ModelState.IsValid)
            {
                await PopulateMovieViewModelAsync(model);
                return View("MovieForm", model);
            }

            

            var files = Request.Form.Files;
            if (files.Any())
            {
                var validationErrorResult = await ValidatePosterAsync(model);
                if (validationErrorResult != null)
                {
                    model.Poster = movie.Poster;
                    return validationErrorResult;
                }
                
            }

            movie.Title = model.Title;
            movie.GenreId = model.GenreId;
            movie.Year = model.Year;
            movie.Rate = model.Rate;
            movie.Storyline = model.Storyline;
            movie.Country = model.Country;
            movie.Language = model.Language;
            movie.Url = model.Url;
            movie.Poster = model.Poster;

            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            _toastNotification.AddSuccessToastMessage("Movie edited successfully");

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return BadRequest();

            var movie = await _context.Movies.Include(x => x.Genres).SingleOrDefaultAsync(x => x.Id == id);

            if (movie == null)
                return NotFound();

            return View(movie);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
                return NotFound();

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return Ok();
        }

    }
}
