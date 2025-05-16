namespace FarmaciaApp.Controllers
{
    public class FarmaciaAppController : Controller
    {
           private readonly string rutaProductos = "App_Data/productos.csv";
           private readonly string rutaSucursales = "App_Data/sucursales.csv";
        
            // Página principal
           public IActionResult Index()
           {
            var productos = CsvHelpers.LeerProductos(rutaProductos);

            var sucursales = CsvHelpers.LeerSucursales(rutaSucursales);

            var vm = new ProductosSucursalesViewModel
            {
                Productos = productos,
                Sucursales = sucursales
            };
            return View(vm);
           }

           // Página de privacidad
           public IActionResult Privacidad()
           {
               return View();
           }

           // Página de contacto
           public IActionResult Contacto()
           {
               return View();
           }

            // Página de sucursales
            public IActionResult Sucursales()
            {
                var Sucursales = new List<Sucursal>();
                if (System.IO.File.Exists(rutaSucursales))
                {
                    var lineas = System.IO.File.ReadAllLines(rutaSucursales);
                    for (int i = 1; i < lineas.Length; i++) // Empieza en 1 para saltar el encabezado
                    {
                        var campos = lineas[i].Split(',');
                        Sucursales.Add(new Sucursal
                        {
                            id = int.Parse(campos[0]),
                            nombre = campos[1],
                            direccion = campos[2]
                        });
                    }
                }   

                return View(Sucursales);
            }

            // Página de ofertas destacadas
            public IActionResult Ofertas()
            {
               return View();
            }
        
    }
}
