using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(optionsAction  =>{
    optionsAction.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
} );
//services.AddDbContext<YourContextClassName>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors();
var app = builder.Build();


//app.UseHttpsRedirection();

//app.UseAuthorization();
// Configure the HTTP request pipeline.
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));
app.MapControllers();

app.Run();
