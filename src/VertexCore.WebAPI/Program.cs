using Serilog;
using VertexCore.Application.DependencyInjection;
using VertexCore.Infrastructure.DependencyInjection;
using VertexCore.Infrastructure.Identity.Seed;
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

// Add API versioning
builder.Services.AddApplicationServices();
builder.Services.AddApplicationServices();
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

// Seed identity data
using (var scope = app.Services.CreateScope())
{
    // Ensure the database is created and seed initial data
    // If you don't have a database context yet, please comment this out in order to avoid errors
    var services = scope.ServiceProvider;
    await IdentitySeeder.SeedAsync(services);
}

app.Run();
