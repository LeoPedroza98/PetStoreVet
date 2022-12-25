using System;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using PetStore.VeterinarioAPI.Data;
using PetStore.VeterinarioAPI.Extensions;
using PetStore.VeterinarioAPI.Identity;
using PetStore.VeterinarioAPI.Mapper;
using PetStore.VeterinarioAPI.Models.Entities;
using PetStore.VeterinarioAPI.Utils;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
var connection = builder.Configuration["MySqlConnection:MysqlConnectionString"];

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 25)))
);


IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Pet Store Vet",
            Version = "v1"
        }
    );
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Header de autorização JWT usando o esquema Bearer. Digite 'Bearer' seguido do JWT para autorizar.",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },new String[]{}
        }
    });
});

builder.Services.AddControllers(mvc => mvc.EnableEndpointRouting = false)
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        options.UseCamelCasing(true);
    });

builder.Services.AddCors(o => o.AddPolicy("CorsLibera", builder =>
{
    builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

builder.Services.AddInjections();
builder.Services.AddODataQueryFilter();
builder.Configuration.AddEnvironmentVariables(prefix: "MySqlConnection:MysqlConnectionString");

builder.Services.AddIdentity<Usuario, Role>()
    .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders()
    .AddErrorDescriber<IdentityDescricaoDeErroEmPtBr>();

builder.Services.AddAuthentication(
    JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    options =>
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidAudience = builder.Configuration["TokenConfigurations:Audience"],
            ValidIssuer = builder.Configuration["TokenConfigurations:Issuer"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
        }
);

var app = builder.Build();
var scope = app.Services.CreateScope();

app.UseSwagger();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("./swagger/v1/swagger.json", "PetStore");
    options.RoutePrefix = string.Empty;
});


// Configure the HTTP request pipeline.
UpdateDatabase(app);


app.UseStaticFiles();

app.UseRouting();
app.UseCors("CorsLibera");

app.UseAuthorization();
app.UseMiddleware(typeof(ErrorHandlingMiddleware));
app.UseMiddleware<TokenValidationMiddleware>();
app.UseConfiguracaoSessao();
app.MapControllers();
app.UseAuthentication();


app.Run();

void UpdateDatabase(IApplicationBuilder app)
{
    using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
    {
        using (var context = serviceScope.ServiceProvider.GetService<AppDbContext>())
        {
            context.Database.Migrate();
            new IdentityInitializer(serviceScope.ServiceProvider.GetService<AppDbContext>(), serviceScope.ServiceProvider.GetService<UserManager<Usuario>>()).Initialize().Wait();
        }
    }
}