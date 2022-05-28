using business_logic.services;
using business_logic.services.interfaces;
using data.context;
using data.repositories;
using data.repositories.interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency injections
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IEducationService, EducationService>();
builder.Services.AddScoped<IEducationRepository, EducationRepository>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IProjectRepository,ProjectRepository>();

//Add newtonsoft
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseContext")));
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
