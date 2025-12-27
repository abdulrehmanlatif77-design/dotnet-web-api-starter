using Serilog;
using VertexCore.Infrastructure.Identity.Seed;
using VertexCore.WebAPI.DependencyInjection;
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

// Add CORS policy (adjust origins as needed for production)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Custom Dependency Injections
builder.Services.AddCustomDbContext(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddCustomApiVersioning();
builder.Services.RegisterServices();

var app = builder.Build();

// Exception middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Enable CORS
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "VertexCore API V1");
    });
}
else
{
    app.UseHttpsRedirection();
}



app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// Seed identity data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await IdentitySeeder.SeedAsync(services);
}

app.Run();