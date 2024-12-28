using Serilog;
using System.Reflection;

namespace OpenLuckyRandom
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("olr.log")
                .CreateLogger();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            try
            {
                Log.Information($"Starting OpenLuckyRandom {Assembly.GetExecutingAssembly().GetName().Version}; {Misc.Runtime.GetArch()}; {(Misc.Runtime.IsDebug() ? "Debug" : "Release")}");
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                ApplicationConfiguration.Initialize();
                Application.Run(new WndMain());
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application terminated unexpectedly");
            }
            finally
            {
                Log.Information("----------");
                Log.CloseAndFlush();
            }
        }
    }
}