var builder = WebApplication.CreateBuilder(args);

// Agregar sesión
builder.Services.AddSession();

// MVC
builder.Services.AddControllersWithViews();

Console.WriteLine("Cadena de conexión:");
Console.WriteLine(builder.Configuration.GetConnectionString("DataBaseConnection"));

var app = builder.Build();

// Manejo de errores y seguridad
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/FarmaciaApp/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Activar sesiones
app.UseSession();

// Ruta por defecto (usando FarmaciaAppController)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=FarmaciaApp}/{action=Index}/{id?}");

app.Run();

