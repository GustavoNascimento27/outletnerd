using Microsoft.AspNetCore.Mvc;
using outletnerd.Models;
using outletnerd.Rep;
using outletnerd.Rep.Interfaces;


namespace outletnerd.Controllers
{
    public class FuncionarioController : Controller
    {
        private InFuncionario _inFuncionario;

        public FuncionarioController (InFuncionario FuncionarioRep)
        {
            _inFuncionario = FuncionarioRep;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CadastrarF() 
        { 
            return View(); 
        }
        [HttpPost]
        public IActionResult CadastrarF(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                _inFuncionario.CadastrarFuncionario(funcionario);
            }
            return View();
        }
    }
}
