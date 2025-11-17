using Microsoft.AspNetCore.Mvc;
using outletnerd.Models;
using outletnerd.Rep;
using outletnerd.Rep.Interfaces;

namespace outletnerd.Controllers
{
    public class ClienteController : Controller
    {
        private InCliente _inCliente;

        public ClienteController (InCliente ClienteRep)
        {
            _inCliente = ClienteRep;
        }
        public IActionResult Index()
        {
            return View(_inCliente.ObterCliente());
        }
        [HttpGet]
        public IActionResult CadastrarC()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CadastrarC(Cliente cliente)
        {
            var clienteId = cliente.IdCliente;
            if (_inCliente.ObterCliente(clienteId) == null)
            {
                _inCliente.CadastrarCliente(cliente);
            }
                return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return View(cliente);
            }

            // 1. Busca o cliente pelo e-mail
            var clienteExistente = _inCliente.BuscaEmailCliente(cliente.Email);

            // 2. Verifica se existe
            if (clienteExistente == null)
            {
                ModelState.AddModelError("", "E-mail ou senha incorretos.");
                return View(cliente);
            }

            var clienteLogado = _inCliente.Login(cliente.Email, cliente.Senha);

            if (clienteLogado != null)
            {
                HttpContext.Session.SetInt32("ClienteId", cliente.IdCliente);
                HttpContext.Session.SetString("ClienteEmail", cliente.Email);
                HttpContext.Session.SetString("ClienteNome", cliente.Nome ?? "Cliente");

                return RedirectToAction("Compra", "Cliente");
            }
            else
            {
                ModelState.AddModelError("", "E-mail ou senha incorretos.");
                return View(cliente);
            }
        }
        public IActionResult Compra()
        {
            return View();
        }
    }
}
