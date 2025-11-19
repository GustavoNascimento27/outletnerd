using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using outletnerd.Models;
using outletnerd.Rep;

namespace outletnerd.Controllers
{
    public class CompraController : Controller
    {
        private readonly ILogger<CompraController> _logger;
        private readonly ProdutoRep _produtoRep;

        public CompraController(ILogger<CompraController> logger, ProdutoRep produtoRep)
        {
            _logger = logger;
            _produtoRep = produtoRep;
        }

        // /Compra/Index/5
        //[Route("Compra/{id:int}")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var produto = await _produtoRep.ProdutoPorId(id);
            return RedirectToAction("Index", "Compra");
        }


    }
}
