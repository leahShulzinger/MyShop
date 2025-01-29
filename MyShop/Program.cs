
using Microsoft.EntityFrameworkCore;

using MyShop;
using NLog.Web;
using Reposetories;
using Servicess;



var builder = WebApplication.CreateBuilder(args);
builder.Host.UseNLog();
builder.Services.AddScoped<IUseServices, UseServices>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddScoped<IRatingService, RatingService>();
builder.Services.AddScoped<IRatingReposetory, RatingReposetory>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserReposetory, UserReposetory>();
builder.Services.AddScoped<IProductReposotory, ProductReposotory>();
builder.Services.AddScoped<ICategoryReposetories, CategoryReposetories>();
builder.Services.AddScoped<IOrderReposetory,OrderReposetory>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//
builder.Services.AddDbContext<MyShop328120357Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConectionString")));
//("data source=srv2\\pupils;initial catalog=MyShop_328120357;Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=true"));

// Add services to the container.

builder.Services.AddControllers();

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
