using Microsoft.AspNetCore.Mvc;

namespace codnity_todo_homework.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

