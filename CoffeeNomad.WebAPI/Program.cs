
using CoffeeNomad.Contracts.Mapping;
using CoffeeNomad.DataBase;
using CoffeeNomad.DataBase.Entities;
using CoffeeNomad.DataBase.Repositories;
using CoffeeNomad.DataBase.Repositories.Interfaces;
using CoffeeNomad.Infrastructure.Password;
using CoffeeNomad.Services;
using CoffeeNomad.WebAPI.AuthCheck;
using CoffeeNomad.WebAPI.Middlewares;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace CoffeeNomad.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllersWithViews();

            builder.Services.Configure<JwtOption>(builder.Configuration.GetSection(nameof(JwtOption)));

            builder.Services.AddDbContext<ApplicationDBContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("MyDbContext")));

            builder.Services
                   .AddControllers()
                   .AddJsonOptions(opts =>
                   {
                       opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                   });

            builder.Services.AddScoped<ApplicationDBContext>();
            builder.Services.AddScoped<CartService>();
            builder.Services.AddScoped<OrderService>();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<ProductMenuService>();

            builder.Services.AddScoped<ICartRepository, CartRepository>();
            builder.Services.AddScoped<IGenericRepository<ProductMenu>, ProductMenuRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.AddScoped<JwtOption>();
            builder.Services.AddScoped<JwtProvider>();
            builder.Services.AddScoped<PasswordHasher>();


            builder.Services.AddAutoMapper(typeof(AutoMapping));
            builder.Services.AddAuthOption(builder.Configuration);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseCors("AllowAll");
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();

            app.MapControllers();

            app.Run();
        }
    }
}
