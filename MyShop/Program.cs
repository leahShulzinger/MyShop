using Reposetories;
using Servicess;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IUseServices, UseServices>();
builder.Services.AddScoped<IUserReposetory, UserReposetory>();


// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
