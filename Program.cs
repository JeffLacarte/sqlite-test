using Microsoft.EntityFrameworkCore;
using sqlite_site.Data;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

string dbName = builder.Configuration.GetConnectionString("DbName") ?? "app-database.sqlite";

string sqliteDbPath = Path.Combine(
    Directory.GetCurrentDirectory(), dbName);

builder.Services.AddDbContext<SqliteDbContext>(options =>
    options.UseSqlite($"Data Source={sqliteDbPath}"));


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    SqliteDbContext dataContext = scope.ServiceProvider.GetRequiredService<SqliteDbContext>();
    dataContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
