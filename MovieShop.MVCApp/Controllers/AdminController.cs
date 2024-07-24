using Microsoft.AspNetCore.Mvc;

namespace MovieShop.MVCApp.Controllers;

public class AdminController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}