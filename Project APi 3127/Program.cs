using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Project_APi_3127.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
{
ValidateIssuer = true,
ValidIssuer = AuthOptions.ISSUER,
ValidateAudience = true,
ValidAudience = AuthOptions.AUDIENCE,
ValidateLifetime = true,
IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
ValidateIssuerSigningKey = true
};
});
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

IServiceCollection serviceCollection = builder.Services.AddDbContext<ProkatContext>(options => options.UseSqlServer(connection));

// Использую Swagger чтобы посмотреть работоспособность
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
c.SwaggerDoc("v1", new OpenApiInfo { Title = "Project API 2", Version = "v1" });
});

var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapPost("/login", async (User loginData, ProkatContext db) =>
{
User? person = await db.Users!.FirstOrDefaultAsync(p => p.Email == loginData.Email &&
p.Password == loginData.Password);
if (person is null) return Results.Unauthorized();
var claims = new List<Claim> { new Claim(ClaimTypes.Email, person.Email!) };
var jwt = new JwtSecurityToken(issuer: AuthOptions.ISSUER,
audience: AuthOptions.AUDIENCE,
claims: claims,
expires: DateTime.Now.Add(TimeSpan.FromMinutes(2)),
signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
);
var encoderJWT = new JwtSecurityTokenHandler().WriteToken(jwt);
var response = new
{
access_token = encoderJWT,
username = person.Email
};
return Results.Json(response);
});

// Проверка и заполнение БД
using (var scope = app.Services.CreateScope())
{
var services = scope.ServiceProvider;
var context = services.GetRequiredService<ProkatContext>();
context.Database.EnsureCreated();

}

if (app.Environment.IsDevelopment())
{
app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Project API 2"));
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/api/Клиенты", async (ProkatContext db) =>
{
var клиенты = await db.Клиентыs
.ToListAsync();

var salesReport = клиенты
.GroupBy(s => s.Фио)
.Select(g => new
{
SellerFullName = g.Key,
TotalRevenue = g.Sum(s => s.Скидка)
});

return Results.Json(salesReport);
});

app.Run();
public class AuthOptions
{
    public const string ISSUER = "MyAuthServer"; // издатель токена
    public const string AUDIENCE = "MyAuthClient"; // потребитель токена
    const string KEY = "mysupersecret_secretsecretsecretkey!123"; // ключ для шифрации
    public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}