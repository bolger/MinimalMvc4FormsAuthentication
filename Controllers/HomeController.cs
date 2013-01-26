using System.Web.Mvc;

namespace MinimalMvc4FormsAuthentication.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
    }
}
