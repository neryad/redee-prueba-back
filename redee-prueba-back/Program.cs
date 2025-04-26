using redee_prueba_back.Data;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Services Area

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("DefaultConnection"));

var app = builder.Build();

//Area de middleares

app.MapControllers();

app.Run();
