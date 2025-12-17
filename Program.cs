using ProjetoDS.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ProjetoDS.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ProjetoDS.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Configuração do MySQL
string mySqlConnection = builder.Configuration.GetConnectionString("DefaultDatabase");
builder.Services.AddDbContext<BibliotecaContext>(opt =>
    opt.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection))
);

// Identity com Roles
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<BibliotecaContext>()
.AddDefaultTokenProviders();


builder.Services.AddSingleton<Microsoft.AspNetCore.Identity.UI.Services.IEmailSender, FakeEmailSender>();

// Injeção de dependências
builder.Services.AddScoped<IBibliotecaRepository, BibliotecaRepository>();

var app = builder.Build();

// Criar roles e usuário admin automaticamente
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await DbInitializer.InitializeAsync(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.MapRazorPages();

app.Run();

