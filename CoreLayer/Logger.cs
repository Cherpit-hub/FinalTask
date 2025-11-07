using Serilog;

namespace CoreLayer
{
    public static class LogConfig
    {
        public static void ConfigureLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug() // Set the minimum logging level
                .WriteTo.Console() // Log to the console
                .CreateLogger();
        }
    }
}
