using Ef_Core_HW_x.PublishingHouse.View;

namespace Ef_Core_HW_x
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new UserSettings());
           // Application.Run(new PublishingHouseView());
        }
    }
}