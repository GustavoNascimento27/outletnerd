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
            if (ModelState.IsValid)
            {
                _inCliente.CadastrarCliente(cliente);
            }
            return View();
        }
        public IActionResult Compra()
        {
            return View();
        }
    }
}
