using Gunluk.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Gunluk.Web.Controllers
{
    public class ContentController : Controller
    { 
        

        public IActionResult Index()
        {
           
            return View();
        }

        
    }
}
