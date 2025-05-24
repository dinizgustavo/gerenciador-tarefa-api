using GerenciadorTarefa.API.Middlewares;
using GerenciadorTarefa.Application.Interfaces;
using GerenciadorTarefa.Application.Services;
using GerenciadorTarefa.Domain.Interfaces;
using GerenciadorTarefa.Infrastructure.Data;
using GerenciadorTarefa.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();
builder.Services.AddScoped<ITarefaService, TarefaService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodoMundo", policy =>
    {
        policy.AllowAnyOrigin()    
              .AllowAnyHeader()    
              .AllowAnyMethod();   
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated(); 
}

app.UseHttpsRedirection();

app.UseCors("PermitirTodoMundo");

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
