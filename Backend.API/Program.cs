using Backend.API.Filters;
using Backend.API.Middlewares;
using Backend.Business.Config;
using Backend.Business.Prueba;
using Backend.Business.Interface.Config;
using Backend.Business.Interface.Prueba;
using Backend.Repository;
using Backend.Repository.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var configurationManager = new Backend.Utilities.ConfigurationManager();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IPruebaRepository, PruebaRepository>();
builder.Services.AddScoped<ILoginBusiness, LoginBusiness>();
builder.Services.AddScoped<IPruebaBusiness, PruebaBusines>();
builder.Services.AddTransient<EjemploFilter>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// --
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configurationManager.ConfigJwtValues.JwtKey))
        };
    }
    );
// --
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(confi =>
{
    confi.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Backend API DEV",
        Description = "Backend API, .NET 8",
    });

    var security = new Dictionary<string, IEnumerable<string>>
    {
        {"Bearer", new string[]{} }
    };

    confi.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization Headers",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    confi.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme,
                }
            },
            new List<string>()
        }
    });
});

var corsName = "Corspolicy";

// Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsName, builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<EjemploMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
