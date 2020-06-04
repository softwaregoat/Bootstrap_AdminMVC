using admindx.Models;
using System.Linq;
using System.Web.Mvc;

namespace Gdocs.Controllers
{
    public class LoginController : Controller
    {
        private gdocxEntities db = new gdocxEntities();

        //
        // GET: /Login/
        public ActionResult Login()
        {
            return View();
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        [HttpPost]
        public ActionResult Login(string Usuario, string Clave)
        {
            var cla = Base64Encode(Base64Encode(Base64Encode(Clave)));
            var RSusr = db.p_usuario.Where(s => s.usuario == Usuario && s.clave == cla);
            foreach (var item in RSusr)
            {
                Session["usuario"] = new p_usuario() { id = item.id, usuario = item.usuario, nombres = item.nombres };
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ErrorLogueo = "Usuario o Clave incorrecto";
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}