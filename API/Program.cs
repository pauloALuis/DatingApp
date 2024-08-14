using System.Text;
using API.Data;
using API.Extensions;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddApplicationServices(builder.Configuration);
//builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddDbContext<DataContext>(opts =>
        {
            opts.UseSqlite(builder.Configuration.
            GetConnectionString("DefaultConnection"));
        });
builder.Services.AddCors();
var app = builder.Build();

//num 24
// Configure the HTTP request pipeline.AlPlowAnyMethod
 app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod()
                                .WithOrigins("https://localhost:4200",
                                             "http://localhost:4200"));
//app.UseAuthentication();
//app.UseAuthorization();

app.MapControllers();

app.Run();
