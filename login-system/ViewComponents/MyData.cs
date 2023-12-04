using login_system.Helper;
using login_system.Models;
using Microsoft.AspNetCore.Mvc;

namespace login_system.ViewComponents
{
    public class MyData : ViewComponent
    {
        private readonly IUserSession _userSession;

        public MyData(IUserSession userSession)
        {
            _userSession = userSession;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            UserModel user = _userSession.SearchSession();

            if (user == null) return null;

            return View(user);
        }
    }
}
