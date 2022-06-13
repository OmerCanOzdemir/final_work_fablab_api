using api.Middlewares;
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

builder.Services.AddScoped<IUserProjectRepository, UserProjectRepository>();
builder.Services.AddScoped<IUserProjectService, UserProjectService>();

builder.Services.AddScoped<IStatisticsDataService, StatisticsDataService>();
builder.Services.AddScoped<IStatisticsDataRepository, StatisticsDataRepository>();

builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();


//Add newtonsoft
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseContext")));

//Add cors services
var MyAllowSpecificOrigins = "ReactApp";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:3000", "https://finalworkfrontend.azurewebsites.net").AllowAnyHeader()
                                .AllowAnyMethod()
                                ;
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
//Using middleware only for controllers 
app.UseWhen(context => context.Request.Path.StartsWithSegments("/api"), appBuilder => appBuilder.UseMiddleware<AuthorisationMiddleware>());
app.Run();
