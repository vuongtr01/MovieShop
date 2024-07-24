using Microsoft.AspNetCore.Mvc;

namespace MovieShop.MVCApp.Controllers;

public class UsersController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}