using AutoMapper;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PetStore.VeterinarioAPI.Data;
using PetStore.VeterinarioAPI.Extensions;
using PetStore.VeterinarioAPI.Mapper;
using PetStore.VeterinarioAPI.Models.Entities;

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
builder.Services.AddSwaggerGen();

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
builder.Services.AddJwt(builder.Configuration);

var app = builder.Build();
var scope = app.Services.CreateScope();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("./swagger/v1/swagger.json", "PetStore");
        options.RoutePrefix = string.Empty;
    });
}

// Configure the HTTP request pipeline.
UpdateDatabase(app);

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseCors("CorsLibera");

app.UseAuthorization();

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
            if (!context.Usuarios.Any())
            {
                context.Usuarios.Add(new Usuario()
                {
                    Login = "Master",
                    Senha = "AQAAAAEAACcQAAAAEANRCJM8tYz2tD2JeiByfFLTPLGrKjo5CdndcUAKVrSn9Uek59ymlGz4qXdKj89xUQ==",
                    PerfilId = PerfilUsuario.Master.Id,
                    Nome = "Master"
                });
                context.SaveChanges();
            }
        }
    }
}