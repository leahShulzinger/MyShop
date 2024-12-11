using Microsoft.EntityFrameworkCore;
using Reposetories;
using Servicess;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IUseServices, UseServices>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserReposetory, UserReposetory>();
builder.Services.AddScoped<IProductReposotory, ProductReposotory>();
builder.Services.AddScoped<ICategoryReposetories, CategoryReposetories>();
builder.Services.AddScoped<IOrderReposetory,OrderReposetory>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<MyShop328120357Context>(options => options.UseSqlServer
("data source=srv2\\pupils;initial catalog=MyShop_328120357;Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=true"));

// Add services to the container.

builder.Services.AddControllers();

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
