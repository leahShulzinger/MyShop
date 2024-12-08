using Microsoft.EntityFrameworkCore;

using Reposetories;
using Servicess;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IUserServicess, UserServicess>();
builder.Services.AddScoped<IUserReposetory, UserReposetory>();
builder.Services.AddScoped<IProductServicess, ProductServicess>();
builder.Services.AddScoped<IProductReposetories, ProductReposetories>();
builder.Services.AddScoped<ICategoryServicess, CategoryServicess>();
builder.Services.AddScoped<ICategoryReposetories, CategoryReposetories>();
builder.Services.AddScoped<IOrderServicess, OrderServicess>();
builder.Services.AddScoped<IOrderReposetories, OrderReposetories>();
builder.Services.AddDbContext<MyShop214935017Context>(options => options.UseSqlServer
("data source=srv2\\pupils;initial catalog=MyShop_214935017;Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=true"));
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
