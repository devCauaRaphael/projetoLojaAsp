using projetoLojaAsp.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//adicionando UsuarioRepositorio
builder.Services.AddScoped<UsuarioRepositorio>();

//adicionando FuncionarioRepositorio
builder.Services.AddScoped<FuncionarioRepositorio>();

//adicionando ProdutoRepositorio
builder.Services.AddScoped<ProdutoRepositorio>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();