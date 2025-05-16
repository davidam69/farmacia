namespace FarmaciaApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private List<Productos> LeerProductosDesdeCSV()
        {
            var rutaCsv = Path.Combine(Directory.GetCurrentDirectory(), "Datos", "productos.csv");
            var lista = new List<Productos>();

            if (System.IO.File.Exists(rutaCsv))
            {
                var lineas = System.IO.File.ReadAllLines(rutaCsv);
                for (int i = 1; i < lineas.Length; i++)
                {
                    var campos = lineas[i].Split(',');
                    lista.Add(new Productos
                    {
                        id = int.Parse(campos[0]),
                        nombre = campos[1],
                       // descripcion = campos[2],
                        precio = decimal.Parse(campos[3])
                    });
                }
            }

            return lista;
        }
        public IActionResult Index()
        {
            var productos = LeerProductosDesdeCSV();
            var sucursales = LeerSucursalesDesdeCSV();

            var modelo = new ProductosSucursalesViewModel
            {
                Productos = productos,
                Sucursales = sucursales
            };

            return View(modelo); 
        }

        private List<Sucursal> LeerSucursalesDesdeCSV()
        {
            var rutaCsv = Path.Combine(Directory.GetCurrentDirectory(), "Datos", "sucursales.csv");
            var lista = new List<Sucursal>();

            if (System.IO.File.Exists(rutaCsv))
            {
                var lineas = System.IO.File.ReadAllLines(rutaCsv);
                for (int i = 1; i < lineas.Length; i++)
                {
                    var campos = lineas[i].Split(',');
                    lista.Add(new Sucursal
                    {
                        id = int.Parse(campos[0]),
                        nombre = campos[1],
                        direccion = campos[2]
                    });
                }
            }

            return lista;
        }
    



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
