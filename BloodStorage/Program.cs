using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using BloodStorage.Data;
using BloodStorage.Data.Repositories;
using BloodStorage.Models;
using BloodStorage.Services;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICrudRepository<Patient, int>, PatientRepository>();
builder.Services.AddScoped<ICrudService<Patient, int>, PatientService>();
builder.Services.AddScoped<ICrudRepository<Doctor, int>,DoctorRepository>();
builder.Services.AddScoped<ICrudService<Doctor, int>, DoctorService>();


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TodoRestAPI",
        Version =
    "v1"
    });
});

var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);//To EnableCors - CrossOrigin

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
