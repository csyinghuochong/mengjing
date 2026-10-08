using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace ET
{
    public static class ExcelExporter
    {
        private const string ClientGeneratedBytesDir = "../Config/Excel/c";
        private const string UnityClientBytesDir = "../Unity/Assets/Bundles/Config";
        private const string ClientGeneratedCodeDir = "../Unity/Assets/Scripts/Model/Generate/Client/Config";
        private const string ServerGeneratedCodeDir = "../Unity/Assets/Scripts/Model/Generate/Server/Config";
        private const string ClientServerGeneratedCodeDir = "../Unity/Assets/Scripts/Model/Generate/ClientServer/Config";

        public static void Export()
        {
            Dictionary<string, byte[]> metaFiles = BackupMetaFiles(
                ClientGeneratedCodeDir,
                ServerGeneratedCodeDir,
                ClientServerGeneratedCodeDir);

            try
            {
                string shellFilePath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? ".\\GenConfig.bat" : "./GenConfig.sh";
                using Process configProcess = CreateProcess(shellFilePath, "../Tools/Luban/");
                configProcess.Start();
                configProcess.WaitForExit();
                if (configProcess.ExitCode != 0)
                {
                    throw new Exception($"Luban export failed with exit code {configProcess.ExitCode}");
                }
            }
            finally
            {
                RestoreMetaFiles(metaFiles);
            }

            CopyClientBytesToUnity();
            RemoveUnusedMetaFiles(UnityClientBytesDir);
            RemoveUnusedMetaFiles(ClientGeneratedCodeDir);
            RemoveUnusedMetaFiles(ServerGeneratedCodeDir);
            RemoveUnusedMetaFiles(ClientServerGeneratedCodeDir);
        }

        private static Dictionary<string, byte[]> BackupMetaFiles(params string[] directories)
        {
            Dictionary<string, byte[]> metaFiles = new(StringComparer.OrdinalIgnoreCase);
            foreach (string directory in directories)
            {
                if (!Directory.Exists(directory))
                {
                    continue;
                }

                foreach (FileInfo info in new DirectoryInfo(directory).GetFiles("*.meta", SearchOption.AllDirectories))
                {
                    metaFiles[info.FullName] = File.ReadAllBytes(info.FullName);
                }
            }

            return metaFiles;
        }

        private static void RestoreMetaFiles(Dictionary<string, byte[]> metaFiles)
        {
            foreach ((string metaPath, byte[] bytes) in metaFiles)
            {
                string assetPath = metaPath[..metaPath.LastIndexOf(".meta", StringComparison.Ordinal)];
                if (!File.Exists(assetPath) && !Directory.Exists(assetPath))
                {
                    continue;
                }

                string directory = Path.GetDirectoryName(metaPath);
                if (!string.IsNullOrEmpty(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                File.WriteAllBytes(metaPath, bytes);
            }
        }

        private static void CopyClientBytesToUnity()
        {
            RemoveAllFilesExceptMeta(UnityClientBytesDir);
            FileHelper.CopyDirectory(ClientGeneratedBytesDir, UnityClientBytesDir);
        }

        private static void RemoveAllFilesExceptMeta(string directory)
        {
            if (!Directory.Exists(directory))
            {
                return;
            }

            foreach (FileInfo info in new DirectoryInfo(directory).GetFiles("*", SearchOption.AllDirectories))
            {
                if (!info.Name.EndsWith(".meta"))
                {
                    info.Delete();
                }
            }
        }

        private static void RemoveUnusedMetaFiles(string directory)
        {
            if (!Directory.Exists(directory))
            {
                return;
            }

            foreach (FileInfo info in new DirectoryInfo(directory).GetFiles("*.meta", SearchOption.AllDirectories))
            {
                string pathWithoutMeta = info.FullName[..info.FullName.LastIndexOf(".meta", StringComparison.Ordinal)];
                if (!File.Exists(pathWithoutMeta) && !Directory.Exists(pathWithoutMeta))
                {
                    info.Delete();
                }
            }
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
