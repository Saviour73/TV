using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TVApi.DataLayer;
using TVApi.Model;
using TVApi.Repository;
using TVApi.TVRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TVDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("TVApiConnectionString")));

builder.Services.AddScoped<IRepository<TV>, TVRepository>();

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
