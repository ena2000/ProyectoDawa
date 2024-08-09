using Microsoft.EntityFrameworkCore;
using ProyectoDAW.Models;
using ProyectoDAW.Repository;
using ProyectoDAW.Repositorynamespace;

var builder = WebApplication.CreateBuilder(args);

//otros servicios
builder.Services.AddScoped<ICarritoRepository, CarritoRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<ICompraRepository, CompraRepository>();
builder.Services.AddScoped<IFacturacionRepository, FacturacionRepository>();
builder.Services.AddScoped<IPagoRepository, PagoRepository>();
builder.Services.AddScoped<IPerfilRepository, PerfilRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped <IReseñaRepository, ReseñaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IInventarioRepository, InventarioRepository>();
builder.Services.AddScoped<IProveedorRepository, ProveedorRepository>();



// Add services to the container.


// Agrega la conexión de la BD
var conectionString = builder.Configuration.GetConnectionString("Conexion");
builder.Services.AddDbContext<RestauranteDbContext>(options =>
    options.UseSqlServer(conectionString)
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add Cors
builder.Services.AddCors(options =>
    options.AddPolicy("AlloWebApp", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod()));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Aplicar la política CORS
app.UseCors("AlloWebApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
