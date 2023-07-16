using Data;
using Data.Repositories;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using NursingHomeAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddLogging();

    services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

    services.AddTransient<IElderlyRepository, ElderlyRepository>();
    services.AddTransient<IElderlyMedicationRepository, ElderlyMedicationRepository>();
    
    services.AddTransient<ExceptionHandlingMiddleware>();

    services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining(typeof(Application.Application)));
}