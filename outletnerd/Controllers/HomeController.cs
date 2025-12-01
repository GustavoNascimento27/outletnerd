using Microsoft.AspNetCore.Mvc;
using outletnerd.Models;
using outletnerd.Rep;
using outletnerd.Rep.Interfaces;
using System.Diagnostics;

namespace outletnerd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InProduto _produtoRep;

        public HomeController(ILogger<HomeController> logger, ProdutoRep produtoRep)
        {
            _logger = logger;
            _produtoRep = produtoRep;
        }

        public async Task<IActionResult> Index()
        {
            var produto = await _produtoRep.TodosProdutos();
            return View(produto);
        }

        public async Task<IActionResult> Decoracoes()
        {
            var Dec = await _produtoRep.Decoracoes();
            return View(Dec);
        }
        public async Task<IActionResult> Brinquedos()
        {
            var Bri = await _produtoRep.Brinquedos();
            return View(Bri);
        }
        public async Task<IActionResult> Livros()
        {
            var Liv = await _produtoRep.Livros();
            return View(Liv);
        }
        public async Task<IActionResult> Roupas()
        {
            var Rou = await _produtoRep.Roupas();
            return View(Rou);
        }
        [HttpGet]
        public async Task<IActionResult> ProdutoUnico(int id)
        {
            var ProdUnic = await _produtoRep.ProdutoPorId(id);
            return View(ProdUnic);
        }
        [HttpGet]
        public IActionResult Buscar(string termo)
        {
            if (string.IsNullOrWhiteSpace(termo))
                return RedirectToAction("Index");

            var prod = _produtoRep.BuscarPorNome(termo);

            if (prod == null)
                return RedirectToAction("Index"); // ou uma página "não encontrado"

            return RedirectToAction("ProdutoUnico", new { id = prod.IdProduto });
        }
        [HttpGet]
        public async Task<IActionResult> BuscarList(string termo)
        {
            var produtos = await _produtoRep.Buscar(termo);
            ViewBag.Termo = termo;
            return View(produtos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
