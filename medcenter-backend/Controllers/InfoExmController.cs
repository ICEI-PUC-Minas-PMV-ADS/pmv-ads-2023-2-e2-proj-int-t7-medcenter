using Microsoft.AspNetCore.Mvc;

namespace medcenter_backend.Controllers {
    public class InfoExmController : Controller {
        public IActionResult Index() {
            return View();
        }

        public IActionResult Imagem() {
            return View();
        }

        public IActionResult Clinico() {
            return View();
        }
    }
}
