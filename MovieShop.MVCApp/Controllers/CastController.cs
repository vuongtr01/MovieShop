using Microsoft.AspNetCore.Mvc;
using MovieShop.Core.Contracts.Services;
using MovieShop.Core.Models.ResponseModels;

namespace MovieShop.MVCApp.Controllers;

public class CastController : Controller
{
    private readonly ICastService _castService;

    // GET
    public CastController(ICastService service)
    {
        this._castService = service;
    }
    public async Task<IActionResult> Detail(int id)
    {
        CastResponseModel model = await _castService.GetById(id);

        return View(model);
    }
}