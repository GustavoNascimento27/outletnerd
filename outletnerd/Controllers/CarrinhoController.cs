using Microsoft.AspNetCore.Mvc;
using outletnerd.Rep;
using outletnerd.Models;
using Org.BouncyCastle.Tls;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Org.BouncyCastle.Asn1.X509;

namespace Toycom.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly CarrinhoRep _carrinhoRep;
        private readonly ProdutoRep _produtoRep;

        public CarrinhoController(CarrinhoRep carrinhoRep, ProdutoRep produtoRep)
        {
            _carrinhoRep = carrinhoRep;
            _produtoRep = produtoRep;
        }
        public async Task<IActionResult> Index()
        {
            var cartItems = _carrinhoRep.CarrinhoItens(HttpContext.Session);
            foreach (var item in cartItems)
            {
                item.Produto = await _produtoRep.ProdutoPorId(item.IdProduto);

                //if (item.Produto != null)
                //{

                //}
            }
            ViewBag.TotalCarrinho = _carrinhoRep.TotalCarrinho(HttpContext.Session);
            return View(cartItems);
        }
        [HttpPost]
        public async Task<IActionResult> AddCarrinho(int produtoId, int quantidade = 1)
        {
            var produto = await _produtoRep.ProdutoPorId(produtoId);
            if (produto == null)
            {
                TempData["Message"] = "Produto não encontrado."; // Use TempData para mensagens
                return RedirectToAction("Index", "Home");
            }
            else
            {
                _carrinhoRep.AddCarrinho(HttpContext.Session, produto, quantidade);
                return RedirectToAction("Index", "Carrinho");
            }
        }

        [HttpPost]
        public IActionResult AlterarQuantidadeItem(int produtoId, int novaQuantidade)
        {
            _carrinhoRep.AlterarQuantidadeItem(HttpContext.Session, produtoId, novaQuantidade);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int produtoId)
        {
            _carrinhoRep.RemoverItemCarrinho(HttpContext.Session, produtoId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult LimparCarrinho()
        {
            _carrinhoRep.LimparCarrinho(HttpContext.Session);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult RealizarCompra(Cliente cliente)
        {
            if(cliente == null)
            {
                return RedirectToAction("CadastrarC", cliente);
            }
            //return RedirectToAction("FinalizarPedido", pedido)
            return RedirectToAction("Index");
        }
    }
}