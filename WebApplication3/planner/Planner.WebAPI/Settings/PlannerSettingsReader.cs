namespace Planner.WebAPI.Settings
{
    public static class PlannerSettingsReader
    {
        public static PlannerSettings Read(IConfiguration configuration)
        {
            //чтение настроек приложения из конфига
            return new PlannerSettings();
        }
    }
}