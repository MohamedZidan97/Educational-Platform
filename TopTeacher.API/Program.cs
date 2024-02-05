

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Text;
using TopTeacher.Application;
using TopTeacher.Persistance;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Application Container
builder.Services.AddApplicationService();









// Persistance Container
builder.Services.AddPersistenceService(builder.Configuration);










// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();






// Seed Defualt Roles & Users


//using var scope = app.Services.CreateScope();
//var services1 = scope.ServiceProvider;

//var loggerfactory = services1.GetRequiredService<ILoggerProvider>();
//var logger = loggerfactory.CreateLogger("App");

//try
//{
//    var userManager = services1.GetRequiredService<UserManager<IdentityUser>>();
//    var roleManager = services1.GetRequiredService<RoleManager<IdentityRole>>();
//    await DefaultRoles.SeedRoles(roleManager);
//    await DefualtUsers.SeedSuperAdminUserAsync(userManager, roleManager);

//    logger.LogInformation("Data Seeded");
//    logger.LogInformation("Application Started");

//}
//catch (Exception ex)
//{
//    logger.LogWarning(ex, "An error occurred while seeding data");
//}


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
