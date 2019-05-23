using Microsoft.AspNetCore.Mvc;

namespace Hamburgueria_Tarde.Controllers
{
    public class PedidoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}