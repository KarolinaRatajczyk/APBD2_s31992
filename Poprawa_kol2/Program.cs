using Microsoft.EntityFrameworkCore;
using Poprawa_kol2.Data;
using Poprawa_kol2.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddScoped<IDbService, DbService>();

var app = builder.Build();

app.MapControllers();

app.Run();