using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PetStore.VeterinarioAPI.Data;
using PetStore.VeterinarioAPI.Mapper;
using PetStore.VeterinarioAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);
     
    // Add services to the container.
    var connection = builder.Configuration["MySqlConnection:MysqlConnectionString"];
     
    builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 25))));


    IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
    builder.Services.AddSingleton(mapper);
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    builder.Services.AddScoped<IVeterinarioRepository, VeterinarioRepository>();
    
    builder.Services.AddControllersWithViews();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "PetStore", Version = "v1" });
    });

    
     
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
     
    // var dbInitializer = scope.ServiceProvider.GetService<IDbInitializer>();
     
    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
    }
    app.UseHttpsRedirection();
     
    app.UseStaticFiles();
     
    app.UseRouting();

// app.UseIdentityServer();
     
    app.UseAuthorization();
     
     
    // dbInitializer.Initialize();
     
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
     
    app.Run();