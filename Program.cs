using AgroConnect.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<AgroConnectDbContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("AgroConnect")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();


//// Código para fazer o Add-Migration e o Update-Database automaticamente ao rodar a aplicação
//using (var scope = app.Services.CreateScope())
//{
//    var db = scope.ServiceProvider.GetRequiredService<AgroConnectDbContext>();
//    db.Database.Migrate();
//}

app.Run();
