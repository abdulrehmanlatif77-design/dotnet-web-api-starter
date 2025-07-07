using Serilog;
using VertexCore.Infrastructure.DependencyInjection;
using VertexCore.WebAPI.Logger;
using VertexCore.WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Configure logging
SerilogConfigurator.Configure();
builder.Host.UseSerilog();

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddJwtAuthentication(builder.Configuration);

var app = builder.Build();

// Use exception handling first
app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // optional
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VertexCore.WebAPI v1"));
}
else
{
    app.UseHttpsRedirection(); // production only
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
