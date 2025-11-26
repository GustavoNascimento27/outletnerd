using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
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
            if (!ModelState.IsValid)
            {
                _inCliente.CadastrarCliente(cliente);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string Email, string Senha, Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Senha))
            {
                TempData["Mensagem"] = "Preencha todos os campos.";
                TempData["TipoMensagem"] = "warning";
                return RedirectToAction("Login", "Cliente");
            }
            var result = _inCliente.Login(Email, Senha);


            if (result == null)
            {
                TempData["Mensagem"] = "Email/Senha incorretos";
                TempData["TipoMensagem"] = "warning";
                return RedirectToAction("Login", "Cliente");
            }

            HttpContext.Session.SetInt32("UserId", cliente.IdCliente);
            HttpContext.Session.SetString("UserEmail", cliente.Email);
            HttpContext.Session.SetString("UserSenha", cliente.Senha);
            return RedirectToAction("Index", "Cliente");
        }
        public IActionResult Compra()
        {
            return View();
        }
    }
}
