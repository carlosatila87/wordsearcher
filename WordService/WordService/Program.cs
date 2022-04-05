using WordService.DBContexts;
using WordService.Repository;
using WordService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll",
                      builder =>
                      {
                          builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                      });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WordContext>();
builder.Services.AddTransient<ISingleWordRepository, SingleWordRepository>();

var app = builder.Build();

app.MigrateDatabase<WordContext>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.MapControllers();

app.Run();
