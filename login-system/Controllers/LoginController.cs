using login_system.Models;
using login_system.Repository;
using Microsoft.AspNetCore.Mvc;

namespace login_system.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;

        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Access(UserModel userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel user = _userRepository.SearchUser(userModel.Email);

                    if (user != null)
                    {
                        if (user.ValidatePassword(userModel.Password))
                        {
                            return RedirectToAction("Index", "Home");
                        }

                    }

                    TempData["ErrorMessage"] = "E-mail e/ou senha inválidos(s), tente novamente";
                }

                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["ErrorMessage"] = $"Não foi possível realizar o login, tente novamente, datalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
