using Microsoft.AspNetCore.Mvc;
using outletnerd.Rep.Interfaces;
using outletnerd.Rep;
using outletnerd.Rep.Interfaces;
using outletnerd.Models;
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
