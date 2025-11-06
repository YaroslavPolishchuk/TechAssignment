using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using TechAssignment.TokenValidationService.Data;
using TechAssignment.TokenValidationService.MiddleWare;
using TechAssignment.TokenValidationService.Services;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(
    builder.Configuration.GetConnectionString("Default")
    ));
//

var publicKey = File.ReadAllText("res/public.pem");
using var rsa = RSA.Create();
rsa.ImportFromPem(publicKey);
var rsaKey = new RsaSecurityKey(rsa) { KeyId = "zxc" };

builder.Services.AddSingleton(rsaKey);
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<ValidateService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseMiddleware<JwtValidationMiddleware>();
app.MapControllers();

app.Run();
