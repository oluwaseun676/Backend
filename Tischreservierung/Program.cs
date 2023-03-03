using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tischreservierung.Data;
using Tischreservierung.Data.RestaurantRepo;
using Core.Contracts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<OnlineReservationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TischreservierungContext") ?? throw new InvalidOperationException("Connection string 'TischreservierungContext' not found.")));

// Add services to the container.
//Services.AddScopped
builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddScoped<IRestaurantTableRepository, RestaurantTableRepository>();
builder.Services.AddScoped<IOpeningTimeRepository, OpeningTimeRepository>();
builder.Services.AddScoped<IRestaurantCategoryRepository, RestaurantCategoryRepository>();
builder.Services.AddScoped<IZipCodeRepository, ZipCodeRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
