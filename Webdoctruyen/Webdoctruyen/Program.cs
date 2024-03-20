using Google.Api;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Webdoctruyen.Interface;
using Webdoctruyen.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApptruyenContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
builder.Services.AddMvc(); 
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddHttpClient<IServiceProvider, ServiceProvider>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddSession(option =>
{
    option.Cookie.IsEssential = true;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{  
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.Run();
