using Indasoft.Zhoglo.TestTask.GoodsbatchAPI.Repository;
using Indasoft.Zhoglo.TestTask.GoodsbatchAPI.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Indasoft.TestTask.Zhoglo.GoodsbatchAPI.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new PatchRequestContractResolver();
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseSerilog((context, services, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
});
builder.Services.AddDbContext<shaguarContext>(optionsBuilder => optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IShaguarRepository, ShaguarRepository>();

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
