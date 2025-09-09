using CityPulse.API.Extensions;
using CityPulse.API.Middlewares;
using CityPulse.Application.Interfaces.Auth;
using CityPulse.Application.Interfaces.Repositories;
using CityPulse.Application.Services;
using CityPulse.Persistence;
using CityPulse.Persistence.Repositories;
using CityPulse.Infrastructure;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddMemoryCache(); 


services.AddApiAuthentication(configuration);

services.AddEndpointsApiExplorer();

services.AddSwaggerGen();

services.AddTransient<ExceptionMiddleware>();

services.AddDbContext<CityPulseDbContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString(nameof(CityPulseDbContext)));
});

services.AddScoped<IJwtProvider, JwtProvider>();
services.AddScoped<IPasswordHasher, PasswordHasher>();

//services.AddScoped<ICourseRepository, CourseRepository>();
//services.AddScoped<ILessonsRepository, LessonsRepository>();
services.AddScoped<IUsersRepository, UsersRepository>();

//services.AddScoped<CoursesService>();
//services.AddScoped<LessonsService>();
services.AddScoped<UserService>();
// в цеорм не налр просто мусор services.AddScoped<QuizService>();

services.AddAutoMapper(typeof(DataBaseMappings));

/*
services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
*/

builder.Services.AddSignalR();


var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always
});

app.UseAuthentication();

app.UseAuthorization();

app.AddMappedEndpoints();

app.Run();

