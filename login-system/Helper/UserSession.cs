using login_system.Models;
using Newtonsoft.Json;

namespace login_system.Helper
{
    public class UserSession : IUserSession
    {
        private readonly IHttpContextAccessor _httpContext;

        public UserSession(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public UserModel SearchSession()
        {
            string userSession = _httpContext.HttpContext.Session.GetString("userSession");

            if (string.IsNullOrEmpty(userSession)) return null;

            return JsonConvert.DeserializeObject<UserModel>(userSession);
        }

        public void CreateSession(UserModel user)
        {
            string stringForCreateSession = JsonConvert.SerializeObject(user);

            _httpContext.HttpContext.Session.SetString("userSession", stringForCreateSession);
        }

        public void RemoveSession()
        {
            _httpContext.HttpContext.Session.Remove("userSession");
        }
    }
}
