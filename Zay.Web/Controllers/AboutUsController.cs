using Microsoft.AspNetCore.Mvc;

namespace Zay.Web.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
