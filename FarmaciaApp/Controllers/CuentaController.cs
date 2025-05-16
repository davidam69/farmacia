public class CuentaController : Controller
{
    private readonly string rutaUsuarios = "App_Data/usuarios.csv";

    [HttpGet]
    public IActionResult Registro() => View();

    [HttpPost]
    public IActionResult Registro(Usuarios usuario)
    {
        var usuarios = CsvService<Usuarios>.Leer(rutaUsuarios);

        if (usuarios.Any(u => u.email == usuario.email))
        {
            ViewBag.Mensaje = "Ya existe un usuario con ese email.";
            return View();
        }

        usuario.id = usuarios.Count > 0 ? usuarios.Max(u => u.id) + 1 : 1;
        usuario.passwordHash = BCrypt.Net.BCrypt.HashPassword(usuario.passwordHash);
        usuarios.Add(usuario);
        CsvService<Usuarios>.Escribir(rutaUsuarios, usuarios);

        return RedirectToAction("Login");
    }

    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public IActionResult Login(string email, string passwordHash)
    {
        var usuarios = CsvService<Usuarios>.Leer(rutaUsuarios);
        var usuario = usuarios.FirstOrDefault(u => u.email == email);

        if (usuario != null && BCrypt.Net.BCrypt.Verify(passwordHash, usuario.passwordHash))
        {
            HttpContext.Session.SetString("Usuario", usuario.nombre);
            HttpContext.Session.SetString("Rol", usuario.rol);
            return RedirectToAction("Index", "FarmaciaApp");
        }

        ViewBag.Mensaje = "Email o contraseña incorrecta.";
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}
