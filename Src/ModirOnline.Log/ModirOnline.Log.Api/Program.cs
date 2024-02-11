

using ModirOnline.Log.Application.Interface;
using ModirOnline.Log.Application.Services.SysLogsServices;
using ModirOnline.Log.Persistence;
using ModirOnline.Log.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);
var databaseSettings = builder.Configuration.GetSection("DatabaseSettings").Get<DatabaseSetting>();


builder.Services.AddSingleton(databaseSettings);

builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<ISysLogServices, SysLogServices>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
