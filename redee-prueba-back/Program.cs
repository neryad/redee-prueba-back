using redee_prueba_back.Data;
using Microsoft.EntityFrameworkCore;
using Octetus.ConsultasDgii.Services;
var builder = WebApplication.CreateBuilder(args);

// Services Area
//Esta de esta forma para que se pueda probar
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("name=DefaultConnection"));
builder.Services.AddScoped<ServicioConsultasWebDgii>();

var app = builder.Build();

//Area de middleares
app.UseCors();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();


app.Run();
