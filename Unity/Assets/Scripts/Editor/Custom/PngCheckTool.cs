using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace ET
{
    /// <summary>c
    /// 将png的文件名称改为小写
    /// </summary>
    public class PngCheckTool : MonoBehaviour
    {

        [MenuItem("Tools/修改所有图标扩展名为.png")]
        static void RenamePngFilesInFolder()
        {
            string folderPath = Application.dataPath + "/Bundles/Icon";
            if (string.IsNullOrEmpty(folderPath))
            {
                Debug.Log("Folder selection canceled.");
                return;
            }
            
            Log.Debug("检测开始");
            
            string[] files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories)
                    .Where(file => file.EndsWith(".PNG", System.StringComparison.OrdinalIgnoreCase)
                            && !file.EndsWith(".png"))
                    .ToArray();
            
            foreach (string file in files)
            {
                string newFilePath = Path.Combine(Path.GetDirectoryName(file) ?? string.Empty, Path.GetFileNameWithoutExtension(file) + ".png");
                File.Move(file, newFilePath);
                Debug.Log($"Renamed: {file} -> {newFilePath}");
            }
            
            AssetDatabase.Refresh();
            
            Log.Debug("检测结束");
        }
    }
}