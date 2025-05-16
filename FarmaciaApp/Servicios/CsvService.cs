namespace FarmaciaApp.Servicios
{
    public static class CsvService<T>
    {
        public static List<T> Leer(string ruta)
        {
            if (!File.Exists(ruta)) return new List<T>();

            using var reader = new StreamReader(ruta, Encoding.UTF8);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
            return csv.GetRecords<T>().ToList();
        }

        public static void Escribir(string ruta, List<T> datos)
        {
            using var writer = new StreamWriter(ruta, false, Encoding.UTF8);
            using var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture));
            csv.WriteRecords(datos);
        }
    }
}

