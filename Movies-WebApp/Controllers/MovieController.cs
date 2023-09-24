using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Movies_WebApp.Code;
using Movies_WebApp.Models;
using Movies_WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using NToastNotify;

namespace Movies_WebApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IToastNotification _toastNotification;

        public MovieController(AppDbContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
        }
        public async Task<IActionResult> Index()
        {
            var movies = await _context.Movies.OrderByDescending(m => m.Rate).ToListAsync();
            return View(movies);
        }

        public async Task<IActionResult> Create()
        {
            var countryData = new CountryData();
            var viewModel = new MovieViewModel
            {
                Countries = countryData.Countries.ToList(),
                CountryToLanguages = countryData.CountryToLanguages,
                Genres = await _context.Genres.Where(x => x.Active).OrderBy(x => x.Name).ToListAsync(),
            };
            return View("MovieForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieViewModel model)
        {
            var countryData = new CountryData();
            if(!ModelState.IsValid)
            {
                model.Countries = countryData.Countries.ToList();
                model.CountryToLanguages = countryData.CountryToLanguages;
                model.Genres = await _context.Genres.Where(x => x.Active).OrderBy(x => x.Name).ToListAsync();

                return View("MovieForm", model);
            }

            var files = Request.Form.Files;
            if (!files.Any())
            {
                model.Countries = countryData.Countries.ToList();
                model.CountryToLanguages = countryData.CountryToLanguages;
                model.Genres = await _context.Genres.Where(x => x.Active).OrderBy(x => x.Name).ToListAsync();
                ModelState.AddModelError("Poster", "Please select movie poster!");
                return View("MovieForm", model);
            }

            var poster = files.FirstOrDefault();
            var allowedExtentions = new List<string> { ".jpg", ".jpeg", ".png", ".webp", ".tiff", ".tif", ".bmp" };

            if (!allowedExtentions.Contains(Path.GetExtension(poster.FileName.ToLower())))
            {
                model.Countries = countryData.Countries.ToList();
                model.CountryToLanguages = countryData.CountryToLanguages;
                model.Genres = await _context.Genres.Where(x => x.Active).OrderBy(x => x.Name).ToListAsync();
                ModelState.AddModelError("Poster", $"Only {string.Join(", ", allowedExtentions)} are allowed!");
                return View("MovieForm", model);
            }

            int maxLength = 1_048_576;
            if (poster.Length > maxLength)
            {
                model.Countries = countryData.Countries.ToList();
                model.CountryToLanguages = countryData.CountryToLanguages;
                model.Genres = await _context.Genres.Where(x => x.Active).OrderBy(x => x.Name).ToListAsync();
                ModelState.AddModelError("Poster", "Poster cannot be more than 1 MB!");
                return View("MovieForm", model);
            }

            int imageWidth = 2000;
            int imageHeight = 2000;

            using (var stream = poster.OpenReadStream())
            using (var image = Image.FromStream(stream))
            {
                if (image.Height > imageHeight || image.Width > imageWidth)
                {
                    model.Countries = countryData.Countries.ToList();
                    model.CountryToLanguages = countryData.CountryToLanguages;
                    model.Genres = await _context.Genres.Where(x => x.Active).OrderBy(x => x.Name).ToListAsync();
                    ModelState.AddModelError("Poster", "Poster is larger than 2000px in either width or height!");
                    return View("MovieForm", model);
                }
            }

            using var dataStream = new MemoryStream();

            await poster.CopyToAsync(dataStream);


            var movies = new Movie
            {
                Title = model.Title,
                GenreId = model.GenreId,
                Year = model.Year,
                Rate = model.Rate,
                Storyline = model.Storyline,
                Country = model.Country,
                Language = model.Language,
                Url = model.Url,
                Poster = dataStream.ToArray()
            };

            _context.Movies.Add(movies);
            _context.SaveChanges();

            _toastNotification.AddSuccessToastMessage("Movie created successfully");

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return BadRequest();

            var movie = await _context.Movies.FindAsync(id);

            if(movie == null) return NotFound();

            var countryData = new CountryData();
            var viewModel = new MovieViewModel
            {
                Id = movie.Id,
                GenreId= movie.GenreId,
                Year = movie.Year,
                Rate = movie.Rate,
                Storyline = movie.Storyline,
                Title = movie.Title,
                Url = movie.Url,
                Poster = movie.Poster,
                Country = movie.Country,
                Language = movie.Language,
                Countries = countryData.Countries.ToList(),
                CountryToLanguages = countryData.CountryToLanguages,
                Genres = await _context.Genres.Where(x => x.Active).OrderBy(x => x.Name).ToListAsync(),
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MovieViewModel model)
        {
            if (model == null) return BadRequest();

            var movie = await _context.Movies.FindAsync(model.Id);

            if (movie == null) return NotFound();

            var countryData = new CountryData();
            if (!ModelState.IsValid)
            {
                model.Countries = countryData.Countries.ToList();
                model.CountryToLanguages = countryData.CountryToLanguages;
                model.Genres = await _context.Genres.Where(x => x.Active).OrderBy(x => x.Name).ToListAsync();

                return View("MovieForm", model);
            }

            var files = Request.Form.Files;
            if (files.Any())
            {
                var poster = files.FirstOrDefault();
                var allowedExtentions = new List<string> { ".jpg", ".jpeg", ".png", ".webp", ".tiff", ".tif", ".bmp" };

                if (!allowedExtentions.Contains(Path.GetExtension(poster.FileName.ToLower())))
                {
                    model.Poster = movie.Poster;
                    model.Countries = countryData.Countries.ToList();
                    model.CountryToLanguages = countryData.CountryToLanguages;
                    model.Genres = await _context.Genres.Where(x => x.Active).OrderBy(x => x.Name).ToListAsync();
                    ModelState.AddModelError("Poster", $"Only {string.Join(", ", allowedExtentions)} are allowed!");
                    return View("MovieForm", model);
                }

                int maxLength = 1_048_576;
                if (poster.Length > maxLength)
                {
                    model.Poster = movie.Poster;
                    model.Countries = countryData.Countries.ToList();
                    model.CountryToLanguages = countryData.CountryToLanguages;
                    model.Genres = await _context.Genres.Where(x => x.Active).OrderBy(x => x.Name).ToListAsync();
                    ModelState.AddModelError("Poster", "Poster cannot be more than 1 MB!");
                    return View("MovieForm", model);
                }

                int imageWidth = 2000;
                int imageHeight = 2000;

                using (var stream = poster.OpenReadStream())
                using (var image = Image.FromStream(stream))
                {
                    if (image.Height > imageHeight || image.Width > imageWidth)
                    {
                        model.Poster = movie.Poster;
                        model.Countries = countryData.Countries.ToList();
                        model.CountryToLanguages = countryData.CountryToLanguages;
                        model.Genres = await _context.Genres.Where(x => x.Active).OrderBy(x => x.Name).ToListAsync();
                        ModelState.AddModelError("Poster", "Poster is larger than 2000px in either width or height!");
                        return View("MovieForm", model);
                    }
                }

                using var dataStream = new MemoryStream();

                await poster.CopyToAsync(dataStream);

                model.Poster = dataStream.ToArray();

                movie.Poster = model.Poster;

            }


            movie.Id = model.Id;
            movie.Title = model.Title;
            movie.GenreId = model.GenreId;
            movie.Year = model.Year;
            movie.Rate = model.Rate;
            movie.Storyline = model.Storyline;
            movie.Country = model.Country;
            movie.Language = model.Language;
            movie.Url = model.Url;

           //_context.Movies.Update(movie);
            _context.SaveChanges();

            _toastNotification.AddSuccessToastMessage("Movie updated successfully");

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
