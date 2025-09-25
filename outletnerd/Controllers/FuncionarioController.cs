using Microsoft.AspNetCore.Mvc;

namespace outletnerd.Controllers
{
    public class FuncionarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
