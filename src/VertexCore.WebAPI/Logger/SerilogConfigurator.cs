using Serilog;

namespace VertexCore.WebAPI.Logger
{
    /* * 
     * SerilogConfigurator is responsible for configuring Serilog logging.
     * It sets up console and file sinks, enriches logs with context,
     * and sets the minimum log level to Information.
     */
    public class SerilogConfigurator
    {
        public static void Configure()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
                .Enrich.FromLogContext()
                .MinimumLevel.Information()
                .CreateLogger();
        }
    }
}