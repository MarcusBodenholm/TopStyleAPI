using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TopStyleAPI.Data;
using TopStyleAPI.Domain.Entities;
using TopStyleAPI.ExceptionHandler;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TopStyleDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequiredUniqueChars = 0;

})
    .AddEntityFrameworkStores<TopStyleDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = "",
        ValidIssuer = "",
        RequireExpirationTime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is the key that we will use in the encryption.")),
        ValidateIssuerSigningKey = true,

    };
});


var app = builder.Build();
app.ConfigureExceptionHandler();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints => endpoints.MapControllers());
app.UseSwagger();
app.UseSwaggerUI();


app.Run();
