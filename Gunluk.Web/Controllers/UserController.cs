using Microsoft.AspNetCore.Mvc;

namespace Gunluk.Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
