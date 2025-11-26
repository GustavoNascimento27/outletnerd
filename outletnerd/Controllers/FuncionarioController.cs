using Microsoft.AspNetCore.Mvc;
using outletnerd.Models;
using outletnerd.Rep;
using outletnerd.Rep.Interfaces;


namespace outletnerd.Controllers
{
    public class FuncionarioController : Controller
    {
        private InFuncionario _inFuncionario;
        private InProduto _produtoRep;

        public FuncionarioController (InFuncionario FuncionarioRep, InProduto ProdutoRep)
        {
            _inFuncionario = FuncionarioRep;
            _produtoRep = ProdutoRep;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CadastrarF() 
        {
            var funcionarios = await _inFuncionario.ListarTodos();   
            return View(funcionarios);
        }
        [HttpPost]
        public IActionResult CadastrarF(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                _inFuncionario.CadastrarFuncionario(funcionario);
            }
            return RedirectToAction("CadastrarF");
        }
        [HttpGet]
        public async Task<IActionResult> CadastrarP()
        {
            var produtos = await _produtoRep.TodosProdutos();
            return View(produtos);
        }
        [HttpPost]
        public async Task<IActionResult> CadastrarP(Produto produto)
        {

            if (ModelState.IsValid)
            {
                _inFuncionario.CadastrarProduto(produto);
            }

            var produtos = await _produtoRep.TodosProdutos();
            return View(produtos);
        }
        [HttpPost]
        public async Task<IActionResult> Excluir(int id)
        {
            var produtoExcluido = await _produtoRep.Excluir(id);

            if (produtoExcluido == null) { 
                return NotFound();
            }
            return RedirectToAction("CadastrarP");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Funcionario funcionario)
        {
            if (!ModelState.IsValid)
            {
                _inFuncionario.Login(funcionario.Email, funcionario.Senha);
                
            }
            return RedirectToAction("CadastrarP", "Funcionario");
        }
        [HttpPost]
        public async Task<IActionResult> ExcluirF(int id)
        {
            var produtoExcluido = await _inFuncionario.ExcluirF(id);

            if (produtoExcluido == null)
                return NotFound();

            return RedirectToAction("CadastrarF");
        }
    }
}
