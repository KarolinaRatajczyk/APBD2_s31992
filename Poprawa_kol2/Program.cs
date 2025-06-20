using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Poprawa_kol2.Data;

var builder = WebApplication.CreateBuilder(args);

//to zapewnia ze z AccessList w json bedzue access_list
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
});//nie jest konieczne

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

// builder.Services.AddScoped<IDbService, DbService>();

var app = builder.Build();

app.MapControllers();

app.Run();