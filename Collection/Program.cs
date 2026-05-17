
using Collection.Repository.Device;
using Collection.Repository.DeviceTelemetry;
using Collection.Repository.Robot;
using Collection.Repository.RobotTelemetry;
using Collection.Repository.User;
using Collection.Service.Device;
using Collection.Service.DeviceTelemetry;
using Collection.Service.Hub;
using Collection.Service.Robot;
using Collection.Service.RobotTelemetry;
using Collection.Service.User;
using Collection.Persistence;
using Microsoft.EntityFrameworkCore;
using Collection.Repository.Hub;

namespace Collection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // DbContext — Npgsql
            builder.Services.AddDbContext<ApplicationDbContext>(opt =>
                opt.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

            // Repositories
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IHubRepository, HubRepository>();
            builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
            builder.Services.AddScoped<IDeviceTelemetry, DeviceTelemetryRepository>();
            builder.Services.AddScoped<IRobotTelemetry, RobotTelemetryRepository>();
            builder.Services.AddScoped<IRobotRepository, RobotRepositrory>();


            // Services
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IHubService, HubService>();
            builder.Services.AddScoped<IDeviceService, DeviceService>();
            builder.Services.AddScoped<IDeviceTelemetryService, DeviceTelemetryService>();
            builder.Services.AddScoped<IRobotService, RobotService>();
            builder.Services.AddScoped<IRobotTelemetryService, RobotTelemetryService>();
            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
