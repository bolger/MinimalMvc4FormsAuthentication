using System.Web.Mvc;

namespace MinimalMvc4FormsAuthentication.Controllers
{
    [Authorize]
    public class SecureController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
