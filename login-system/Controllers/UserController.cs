using login_system.Helper;
using login_system.Models;
using login_system.Repository;
using Microsoft.AspNetCore.Mvc;

namespace login_system.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserSession _userSession;

        public UserController(IUserRepository userRepository, IUserSession userSession)
        {
            _userRepository = userRepository;
            _userSession = userSession;
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

                    TempData["SuccessMessage"] = "Cadastro realizado com sucesso, realize login.";
                    return RedirectToAction("Index", "Login");
                }
                return View("Index");
            }
            catch (Exception error)
            {
                TempData["ErrorMessage"] = $"{error.Message}.";
                return RedirectToAction("Index");
            }
        }

        public IActionResult MyData()
        {
            UserModel user = _userSession.SearchSession();

            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Change(ChangePasswordModel changePasswordModel)
        {
            try
            {
                UserModel loggedInUser = _userSession.SearchSession();
                changePasswordModel.Id = loggedInUser.Id;

                if (ModelState.IsValid)
                {
                    _userRepository.ChangePassword(changePasswordModel);
                    TempData["SuccessMessage"] = "Senha alterada com sucesso.";
                    return RedirectToAction("MyData", "User", new { id = changePasswordModel.Id });
                }

                return View("ChangePassword", changePasswordModel);
            }
            catch (Exception error)
            {
                TempData["ErrorMessage"] = $"{error.Message}";
                return View("ChangePassword", changePasswordModel);
            }
        }

        public IActionResult UserDeletion()
        {
            UserModel user = _userSession.SearchSession();

            if (user == null)
            {
                return RedirectToAction("MyData", "User");
            }

            return View(user);
        }

        public IActionResult Deletion(int id)
        {
            try
            {
                _userRepository.DeleteUser(id);
                _userSession.RemoveSession();

                TempData["SuccessMessage"] = "Conta excluída com sucesso.";
                return RedirectToAction("Index", "Login");
            }
            catch (Exception error)
            {
                TempData["ErrorMessage"] = $"{error.Message}";
                return View("MyData");
            }
        }
    }
}

