using CleanArchitecture.Infrastructure.Context;
using CleanArchitecture.Web.Extentions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseMySql("Server=localhost;Port=3306;Database=clean;Uid=root;Pwd=07431131100;",
                            ServerVersion.AutoDetect("Server=localhost;Port=3306;Database=clean;Uid=root;Pwd=07431131100;"),
                            b => b.MigrationsAssembly("CleanArchitecture.Web"));
    Console.WriteLine("Database connection");
});
builder.AddDI();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
