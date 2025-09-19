using Microsoft.AspNetCore.Mvc;

namespace outletnerd.Controllers
{
    public class CarrinhoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
