using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Persistence.Contexts;
using Supermarket.API.Domain.Services;
using Supermarket.API.Services;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Domain.Persistence.Repositories;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Connect")));
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddCors(options =>
    options.AddDefaultPolicy(builder => builder.AllowAnyOrigin()
    ));

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//using (var context = scope.ServiceProvider.GetService<AppDbContext>())
//{
//    context?.Database.EnsureCreated();
//}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();   
    app.UseSwaggerUI();
}
app.UseCors();

app.UseHttpsRedirection();  

app.UseAuthorization();

app.MapControllers();

app.Run();
// Commit before Close