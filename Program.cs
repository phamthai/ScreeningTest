using Microsoft.EntityFrameworkCore;
using ScreeningTest;
using ScreeningTest.Entities;
using ScreeningTest.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase(databaseName: "ScreeningTest"));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Add sample data
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApiContext>();
    var product1 = new Product
    {
        Id = 1,
        Name = "Product 1",
        Description = "Product 1 description",
        Price = 100M
    };
    var product2 = new Product
    {
        Id = 2,
        Name = "Product 2",
        Description = "Product 2 description",
        Price = 120M
    };
    dbContext.Products.Add(product1);
    dbContext.Products.Add(product2);

    dbContext.SaveChanges();
}

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
