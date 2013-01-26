using System.Web.Mvc;
using System.Web.Security;
using MinimalMvc4FormsAuthentication.Models;

namespace MinimalMvc4FormsAuthentication.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid && IsValidLogin(model.UserName, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.UserName, true);
                return Redirect(returnUrl);
            }

            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }

        private bool IsValidLogin(string userName, string password)
        {
            // This is where you would put your custom login code to ensure the provided
            // username/password is valid. You could check against a database, an LDAP 
            // directory, or anything you like.
            return true;
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
