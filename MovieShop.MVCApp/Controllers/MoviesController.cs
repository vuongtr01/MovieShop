using Microsoft.AspNetCore.Mvc;
using MovieShop.Core.Contracts.Services;
using MovieShop.Infrastructure.Services;

namespace MovieShop.MVCApp.Controllers;

public class MoviesController : Controller
{
    private readonly IMovieService _service;

    public MoviesController(IMovieService service)
    {
        this._service = service;
    }
    // GET
    public async Task<IActionResult> Index(int pageSize = 20, int pageIndex = 1)
    {
        var movies = await _service.GetAllMovies(pageSize, pageIndex);
        ViewBag.hasNextPage = movies.HasNextPage;
        ViewBag.hasPreviousPage = movies.HasPreviousPage;
        ViewBag.totalPages = movies.TotalPages;
        ViewBag.currentIndex = movies.PageIndex;
        ViewBag.Action = "Index";
        return View(movies.Data);
    }

    public async Task<IActionResult> Detail(int id)
    {
        var movie = await _service.GetById(id);

        if (movie != null)
        {
            ViewBag.castsList = await _service.GetCastsList(id);
            return View(movie);
        }

        return RedirectToAction("Index");
    }
    
    public async Task<IActionResult> Genre(int id, int pageSize = 30, int pageIndex = 1)
    {
        var movies = await _service.GetMoviesByGenre(id, pageSize, pageIndex);
        ViewBag.hasNextPage = movies.HasNextPage;
        ViewBag.hasPreviousPage = movies.HasPreviousPage;
        ViewBag.totalPages = movies.TotalPages;
        ViewBag.currentIndex = movies.PageIndex;
        ViewBag.Action = "Genre";
        return View("Index", movies.Data);
    }
}