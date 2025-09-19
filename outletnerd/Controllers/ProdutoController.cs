using Microsoft.AspNetCore.Mvc;

namespace outletnerd.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
