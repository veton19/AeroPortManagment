using AeroPortManagment.Data;
using AeroPortManagment.Interface;
using AeroPortManagment.MockData;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddSingleton<IAirportRepository, AirportMockRepository>();
        builder.Services.AddSingleton<IAirlineRepository, AirlineMockRepository>();
        builder.Services.AddSingleton<IBookingRepository, BookingMockRepository>();
        builder.Services.AddSingleton<ICommercialActivityRepository, CommercialActivityMockRepository>();
        builder.Services.AddSingleton<IEmployeeRepository, EmployeeMockRepository>();
        builder.Services.AddSingleton<IFlightRepository, FlightMockRepository>();
        builder.Services.AddSingleton<IPassengerRepository, PassengerMockRepository>();
        builder.Services.AddSingleton<IRealTimeUpdateRepository, RealTimeUpdateMockRepository>();
        builder.Services.AddSingleton<IResourceAllocationRepository, ResourceAllocationMockRepository>();
        builder.Services.AddSingleton<ISecurityRepository, SecurityMockRepository>();

        //builder.Services.AddDbContext<AeroPortContext>(opt =>
        //               opt.UseSqlServer(builder.Configuration.GetConnectionString("aero")));

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddDbContext<AeroPortContext>(opt =>
        {
            var constrbuilder = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("aero"));
            constrbuilder.UserID = builder.Configuration["userid"];
            constrbuilder.Password = builder.Configuration["password"];
            opt.UseSqlServer(constrbuilder.ConnectionString);
        }
        );

        builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
    .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
    .Build();

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}