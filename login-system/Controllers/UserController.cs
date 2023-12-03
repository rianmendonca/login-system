using login_system.Models;
using login_system.Repository;
using Microsoft.AspNetCore.Mvc;

namespace login_system.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterUser(UserModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    user = _userRepository.RegisterUser(user);

                    TempData["SuccessMessage"] = "Cadastro realizado com sucesso.";
                    return RedirectToAction("Index", "Login");
                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["ErrorMessage"] = $"Não foi possivel realizar o cadastro, detalhe do erro: {erro.Message}.";
                return RedirectToAction("Index");
            }
        }
    }
}
