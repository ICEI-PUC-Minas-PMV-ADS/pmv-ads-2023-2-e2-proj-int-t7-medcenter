using medcenter_backend.Models.Pedidos;
using Microsoft.AspNetCore.Mvc;

namespace medcenter_backend.Controllers
{
    public class ResultController : Controller
    {
        private static List<Result> _result = null;

        public ResultController()
        {
            _result = new List<Result>();
            Result result1 = new Result { 
            PedidosAbertos = Guid.NewGuid().ToString() };

            _result.Add(result1);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listar()
        {
            return View(_result);
        }

    }
}
