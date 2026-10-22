using System.Diagnostics;
using System.IO;
using UnityEngine;

namespace ET
{
    public static class ToolsEditor
    {
        private static Process exportProcess;

        public static void ExcelExporter()
        {
#if UNITY_EDITOR_OSX || UNITY_EDITOR_LINUX
            // 非 Windows 仍走 Tool.exe，脚本的控制台窗口没法从编辑器里弹出来
            ShellHelper.Run("./Tool --AppType=ExcelExporter --Console=1", "../Bin/");
#else
            if (IsExporting())
            {
                UnityEngine.Debug.LogError("导表正在进行中，先关掉导表窗口再点");
                return;
            }

            // Assets 往上两级就是工程根目录
            string lubanDir = Path.GetFullPath(Path.Combine(Application.dataPath, "..", "..", "Tools", "Luban"));
            string scriptPath = Path.Combine(lubanDir, "GenConfig.bat");
            if (!File.Exists(scriptPath))
            {
                UnityEngine.Debug.LogError($"找不到导表脚本: {scriptPath}");
                return;
            }

            // Unity 没有控制台，UseShellExecute 会给 cmd 新开一个窗口，
            // 脚本自己的 pause 负责把窗口留住；不 WaitForExit，编辑器不会卡住
            exportProcess = Process.Start(new ProcessStartInfo("cmd.exe")
            {
                Arguments = $"/c \"\"{scriptPath}\"\"",
                WorkingDirectory = lubanDir,
                UseShellExecute = true,
                CreateNoWindow = false,
            });
#endif
        }

        private static bool IsExporting()
        {
            if (exportProcess == null)
            {
                return false;
            }

            if (!exportProcess.HasExited)
            {
                return true;
            }

            exportProcess.Dispose();
            exportProcess = null;
            return false;
        }

        public static void Proto2CS()
        {
#if UNITY_EDITOR_OSX || UNITY_EDITOR_LINUX
            const string tools = "./Tool";
#else
            const string tools = ".\\Tool.exe";
#endif
            ShellHelper.Run($"{tools} --AppType=Proto2CS --Console=1", "../Bin/");
        }
    }
}
