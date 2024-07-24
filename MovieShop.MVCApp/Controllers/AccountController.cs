using Microsoft.AspNetCore.Mvc;

namespace MovieShop.MVCApp.Controllers;

public class AccountController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}