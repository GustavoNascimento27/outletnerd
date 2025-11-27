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
            if (ModelState.IsValid)
            {
                _inCliente.CadastrarCliente(cliente);
                return RedirectToAction("Index", "Home");
            }
            return View(cliente);
        }
        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            ViewBag.Nome = HttpContext.Session.GetString("UserNome");
            ViewBag.Email = HttpContext.Session.GetString("UserEmail");
            
            return View();
        }
        [HttpPost]
        public IActionResult Login(string Email, string Senha, string Nome, Cliente cliente)
        {
            var result = _inCliente.Login(Email, Senha, Nome);

            if (result == null)
            {
                TempData["Mensagem"] = "Email/Senha incorretos";
                TempData["TipoMensagem"] = "warning";
                return RedirectToAction("Login", "Cliente");
            }

            HttpContext.Session.SetInt32("UserId", result.IdCliente);
            HttpContext.Session.SetString("UserEmail", result.Email);
            HttpContext.Session.SetString("UserNome", result.Nome);

            return RedirectToAction("Login", "Cliente");
        }
        public IActionResult Perfil()
        {
            int? id = HttpContext.Session.GetInt32("UserId");
            string nome = HttpContext.Session.GetString("UserNome");
            string email = HttpContext.Session.GetString("UserEmail");

            
            if (id == null)
            {
                return RedirectToAction("Login", "Cliente");
            }

            ViewBag.UserId = id;
            ViewBag.Nome = nome;
            ViewBag.Email = email;

            return View();

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Cliente");
        }
        public IActionResult Compra()
        {
            return View();
        }
    }
}
