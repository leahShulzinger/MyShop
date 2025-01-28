using Microsoft.EntityFrameworkCore;
using MyShop;
using NLog.Web;
using Reposetories;
using Servicess;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseNLog();
builder.Services.AddScoped<IUserServicess, UserServicess>();
builder.Services.AddScoped<IUserReposetory, UserReposetory>();
builder.Services.AddScoped<IProductServicess, ProductServicess>();
builder.Services.AddScoped<IProductReposetories, ProductReposetories>();
builder.Services.AddScoped<ICategoryServicess, CategoryServicess>();
builder.Services.AddScoped<ICategoryReposetories, CategoryReposetories>();
builder.Services.AddScoped<IOrderServicess, OrderServicess>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IOrderReposetories, OrderReposetories>();
builder.Services.AddScoped<IRatingServicess, RatingServicess>();
builder.Services.AddScoped<IRatingReposetories, RatingReposetories>();
builder.Services.AddDbContext<MyShop214935017Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("School")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseErrorHandlingMiddleware();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseMiddlewareRating();
app.UseAuthorization();

app.MapControllers();

app.Run();
