using System.Web.Mvc;
using map = Asp.Net_MVC.Mapa;

namespace Asp.Net_MVC.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            map.Mapear.CrearMapa();
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
    }
}