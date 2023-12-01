using login_system.Helper;
using login_system.Models;
using login_system.Repository;
using Microsoft.AspNetCore.Mvc;

namespace login_system.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserSession _userSession;

        public LoginController(IUserRepository userRepository, IUserSession userSession)
        {
            _userRepository = userRepository;
            _userSession = userSession;
        }
        public IActionResult Index()
        {
            if (_userSession.SearchSession() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public IActionResult Access(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel user = _userRepository.SearchUser(loginModel.Email);

                    if (user != null)
                    {
                        if (user.ValidatePassword(loginModel.Password))
                        {
                            _userSession.CreateSession(user);
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

        public IActionResult EndSession()
        {
            _userSession.RemoveSession();
            return RedirectToAction("Index", "Login");
        }
    }
}
