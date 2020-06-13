using MCM.Abstractions.Settings.Base.Global;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace JTSwingFaster
{
    public static class Logs
    {
        public static void log(string message)
        {
            InformationManager.DisplayMessage(new InformationMessage(message));
        }
        public static void log(string message, Color color)
        {
            InformationManager.DisplayMessage(new InformationMessage(message, color));
        }
        public static void percentMessage(string message)
        {
            if (GlobalSettings<Settings>.Instance.ShowPercentMessages)
            {
                log(message);
            }
        }
    }
}
