namespace FarmaciaApp.Helpers
{
    public static class CsvHelpers
    {
        public static List<Productos> LeerProductos(string ruta)
        {
            var productos = new List<Productos>();

            try
            {
                if (!System.IO.File.Exists(ruta))
                    throw new FileNotFoundException("El archivo CSV de productos no fue encontrado.", ruta);

                var lineas = System.IO.File.ReadAllLines(ruta);
                for (int i = 1; i < lineas.Length; i++) // salta encabezado
                {
                    var campos = lineas[i].Split(',');

                    // Asegura que haya al menos 4 columnas
                    if (campos.Length < 4)
                        continue;

                    productos.Add(new Productos
                    {
                        id = int.Parse(campos[0]),
                        nombre = campos[1],
                        marca = campos[2],
                        categoria = campos[3],
                        precio = decimal.Parse(campos[4]),
                        imagenUrl = campos.Length > 5 ? campos[6] : null,
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error leyendo CSV: {ex.Message}");
                throw; // Opcional: volver a lanzar para que el navegador lo muestre
            }

            return productos;
        }

        public static List<Sucursal> LeerSucursales(string ruta)
        {
            var sucursales = new List<Sucursal>();
            if (File.Exists(ruta))
            {
                var lineas = File.ReadAllLines(ruta);
                for (int i = 1; i < lineas.Length; i++)
                {
                    var campos = lineas[i].Split(',');
                    sucursales.Add(new Sucursal
                    {
                        id = int.Parse(campos[0]),
                        nombre = campos[1],
                        direccion = campos[2],
                        telefono = campos[3],
                    });
                }
            }
            return sucursales;
        }
    }
}

