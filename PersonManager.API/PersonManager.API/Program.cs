using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonManager.API;
using PersonManager.Data;
using PersonManager.Data.Entities;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// --- AutoMapper ---
var mappingConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new PersonManager.API.MappingProfile());
});

IMapper mapper = mappingConfig.CreateMapper();

builder.Services.AddSingleton(mapper);



builder.Services.AddDbContext<PersonDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});




var app = builder.Build();

// ===== 2. Seed + Migrations =====
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PersonDbContext>();
    db.Database.Migrate();       // создаёт/обновляет БД
    DbInitializer.Seed(db);      // заполняет тестовыми данными
}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PersonManager API V1");
        c.RoutePrefix = ""; // https://localhost:xxxx/
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
