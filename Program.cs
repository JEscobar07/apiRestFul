using apirestful.Data;
using apirestful.Repositories;
using apirestful.Services;
using apiRestFul.Repositories;
using apiRestFul.Services;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


Env.Load();

var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
var dbDatabaseName = Environment.GetEnvironmentVariable("DB_DATABASE");
var dbUser = Environment.GetEnvironmentVariable("DB_USERNAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
var conectionDB = $"server={dbHost};port={dbPort};database={dbDatabaseName};uid={dbUser};password={dbPassword}";

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(conectionDB, ServerVersion.Parse("8.0.20-mysql")));
builder.Services.AddControllers();

// ACA AGREGAMOS EL SERVICIO QUE NOS PERMITE TRABAJAR
builder.Services.AddScoped<ICategoryRepository, CategoriesServices>();
builder.Services.AddScoped<IProductRepository, ProductsServices>();
builder.Services.AddScoped<IOrderRepository, OrdersServices>();
// builder.Services.AddScoped<IGuestRepository, GuestServices>();
// builder.Services.AddScoped<IBookingRepository, BookingServices>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{

    c.EnableAnnotations();
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseWelcomePage(new WelcomePageOptions
{
    Path = "/"
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
