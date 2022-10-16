using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, PostgresProductRepository>();

var connStringBuilder = new NpgsqlConnectionStringBuilder();
connStringBuilder.ConnectionString = builder.Configuration.GetConnectionString("PostgreSqlConnection");
connStringBuilder.Username = builder.Configuration["UserID"];
connStringBuilder.Password = builder.Configuration["Password"];
builder.Services.AddDbContext<ProductContext>(opt => opt.UseNpgsql(connStringBuilder.ConnectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.MapGet("/", () => "Hello World!");
app.MapControllers();

app.Run();
