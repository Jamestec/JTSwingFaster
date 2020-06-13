using HarmonyLib;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace JTSwingFaster
{
    public class SubModule : MBSubModuleBase
    {
        private bool done = false;
        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            if (done)
            {
                // Logs.log($"JTForeverLearning min={GlobalSettings<Settings>.Instance.MinLearningRate}", new Color(0, 1, 0));
            }
            else
            {
                var harmony = new Harmony("JTSwingFaster");
                harmony.PatchAll();
                done = true;
                Logs.log($"JTSwingFaster has patched", new Color(0, 1, 0));
            }
        }
    }
}
