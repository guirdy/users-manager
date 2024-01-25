using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using UsersManagerApi.Data;
using UsersManagerApi.Repositories;
using UsersManagerApi.Repositories.Interfaces;
using UsersManagerApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add Controllers and NewtonsoftJson
builder.Services.AddControllers().AddNewtonsoftJson();

// Register the Swagger generator, and xml comments
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "User Manager API", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

// Add Database Context
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// Add Auto Mapper Config
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add Repositories and Services Injection
builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<PhysicalPersonServices>();
builder.Services.AddScoped<ContactServices>();
builder.Services.AddScoped<AddressServices>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPhysicalPersonRepository, PhysicalPersonRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
