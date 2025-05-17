namespace FarmaciaApp.Controllers
{
    public class CarritoController : Controller
    {
        private const string CarritoKey = "Carrito";

        public IActionResult Index()
        {
            var carrito = ObtenerCarritoDesdeSesion();
            return View(carrito);
        }

        [HttpPost]
        public IActionResult Agregar(int id, string nombre, decimal precio)
        {
            var carrito = ObtenerCarritoDesdeSesion();

            var itemExistente = carrito.FirstOrDefault(p => p.productoId == id);
            if (itemExistente != null)
            {
                itemExistente.cantidad++;
            }
            else
            {
                carrito.Add(new CarritoItem
                {
                    productoId = id,
                    nombre = nombre,
                    precio = precio,
                    cantidad = 1
                });
            }

            GuardarCarritoEnSesion(carrito);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var carrito = ObtenerCarritoDesdeSesion();
            var item = carrito.FirstOrDefault(p => p.productoId == id);
            if (item != null)
            {
                carrito.Remove(item);
            }
            GuardarCarritoEnSesion(carrito);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ActualizarCantidad(List<CarritoItem> items)
        {
            var carrito = ObtenerCarritoDesdeSesion();

            foreach (var item in items)
            {
                var existente = carrito.FirstOrDefault(p => p.productoId == item.productoId);
                if (existente != null)
                {
                    existente.cantidad = item.cantidad;
                }
            }

            GuardarCarritoEnSesion(carrito);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Pagar()
        {
            // Aquí podrías registrar la compra en la base de datos, enviar un comprobante, etc.

            // Vaciar el carrito
            GuardarCarritoEnSesion(new List<CarritoItem>());

            TempData["Mensaje"] = "¡Compra realizada con éxito!";
            return RedirectToAction("Index");
        }
        private List<CarritoItem> ObtenerCarritoDesdeSesion()
        {
            var data = HttpContext.Session.GetString(CarritoKey);
            if (string.IsNullOrEmpty(data))
                return new List<CarritoItem>();

            return System.Text.Json.JsonSerializer.Deserialize<List<CarritoItem>>(data);
        }

        private void GuardarCarritoEnSesion(List<CarritoItem> carrito)
        {
            var data = System.Text.Json.JsonSerializer.Serialize(carrito);
            HttpContext.Session.SetString(CarritoKey, data);
        }
    }
}

