using Microsoft.AspNetCore.Mvc;

namespace outletnerd.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
