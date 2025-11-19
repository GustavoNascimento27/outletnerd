using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using outletnerd.Models;
using outletnerd.Rep;
using outletnerd.Rep.Interfaces;

namespace outletnerd.Controllers
{
    public class CompraController : Controller
    {
        private readonly ILogger<CompraController> _logger;
        private readonly ProdutoRep _produtoRep;
        private readonly CompraRep _Compra;

        public CompraController(ILogger<CompraController> logger, ProdutoRep produtoRep, CompraRep compraRep)
        {
            _logger = logger;
            _produtoRep = produtoRep;
            _Compra = compraRep;
        }

        // /Compra/Index/5
        //[Route("Compra/{id:int}")]
        public async Task<IActionResult> Index(int id)
        {
            var produto = await _Compra.ItemCompra(id);
            return View(produto);
        }


    }
}
