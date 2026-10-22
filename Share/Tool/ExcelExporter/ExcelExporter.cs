using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ET
{
    public static class ExcelExporter
    {
        /// <summary>
        /// 只负责启动导表脚本；备份 .meta、导表、同步 Unity 客户端配置、清理 .meta 都在
        /// Tools/Luban/GenConfig.bat (Windows) 与 GenConfig.sh (Linux) 里完成。
        /// </summary>
        public static void Export()
        {
            // 不带 --no-pause：导表结束（成功或失败）后脚本会 pause，窗口保留下来方便看日志。
            string shellFilePath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? ".\\GenConfig.bat" : "./GenConfig.sh";
            using Process configProcess = CreateProcess(shellFilePath, "../Tools/Luban/");
            configProcess.Start();
            configProcess.WaitForExit();
        }

        private static Process CreateProcess(string command, string workingDirectory)
        {
            bool windows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            return new Process
            {
                StartInfo = new ProcessStartInfo(windows ? "cmd.exe" : "bash")
                {
                    Arguments = windows ? $"/c \"{command}\"" : $"-c \"{command}\"",
                    CreateNoWindow = false,
                    UseShellExecute = true,
                    WorkingDirectory = workingDirectory,
                },
            };
        }
    }
}
