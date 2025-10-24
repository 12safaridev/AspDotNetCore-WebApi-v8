using Microsoft.Extensions.Configuration;
using Learn_DotNetCore_WebApi_v8.Data;
using Microsoft.EntityFrameworkCore;
using Learn_DotNetCore_WebApi_v8.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

builder.Services.AddScoped<InitializeSeeder>();
builder.Services.AddTransient<BooksService>();
builder.Services.AddTransient<AuthorsService>();
builder.Services.AddTransient<PublishersService>();

var app = builder.Build();

//Seeder implementation
var scope = app.Services.CreateScope();
var seed = scope.ServiceProvider.GetRequiredService<InitializeSeeder>();
//await seed.Seed();


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
