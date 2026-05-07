using Microsoft.EntityFrameworkCore;
using GuayabitosMvc.Models;
using Microsoft.Extensions.Options;
using GuayabitosMvc.Services;
using GuayabitosMvc.Filters;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<GuayabitosDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//==========================================
//Sesiones (para el login)
//==========================================

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(Options=>
{
   Options.IdleTimeout = TimeSpan.FromMinutes(30);
   Options.Cookie.HttpOnly = true;
   Options.Cookie.IsEssential= true;
   Options.Cookie.Name = "Guayabito.Sesion"; 
});
//==========================================
//Sesiones (para el login)
//==========================================
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<AuthService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Add services to the container.
builder.Services.AddControllersWithViews(Options =>
{
    Options.Filters.Add<AutorizacionFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Guayabitos API v1");
    });
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
