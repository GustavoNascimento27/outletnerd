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
            else
            {
                //RedirectToAction()
            }
                return View();
        }
        public IActionResult Compra()
        {
            return View();
        }
    }
}
