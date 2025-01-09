using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace ET
{
    /// <summary>
    /// 将png的文件名称改为小写
    /// </summary>
    public class PngCheckTool : MonoBehaviour
    {
        
        /// <summary>
        /// 获取路径下所有文件以及子文件夹中文件
        /// </summary>
        /// <param name="path">全路径根目录</param>
        /// <param name="FileList">存放所有文件的全路径</param>
        /// <returns></returns>
        public static List<string> GetFile(string path, List<string> FileList)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] fil = dir.GetFiles();
            DirectoryInfo[] dii = dir.GetDirectories();
            foreach (FileInfo f in fil)
            {
                //int size = Convert.ToInt32(f.Length);
                long size = f.Length;
                FileList.Add(f.FullName);//添加文件路径到列表中
            }
            //获取子文件夹内的文件列表，递归遍历
            foreach (DirectoryInfo d in dii)
            {
                GetFile(d.FullName, FileList);
            }
            return FileList;
        }
        
        [MenuItem("Tools/修改所有图标扩展名为.png")]
        static void RenamePngFilesInFolder()
        {
            // string folderPath = EditorUtility.OpenFolderPanel("Select Folder", "", "");
            // if (string.IsNullOrEmpty(folderPath))
            // {
            //     Debug.Log("Folder selection canceled.");
            //     return;
            // }
            //
            // Log.Debug("检测开始");
            //
            // string[] files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories)
            //         .Where(file => file.EndsWith(".PNG", System.StringComparison.OrdinalIgnoreCase)
            //                 && !file.EndsWith(".png"))
            //         .ToArray();
            //
            // foreach (string file in files)
            // {
            //     string newFilePath = Path.Combine(Path.GetDirectoryName(file) ?? string.Empty, Path.GetFileNameWithoutExtension(file) + ".png");
            //     File.Move(file, newFilePath);
            //     Debug.Log($"Renamed: {file} -> {newFilePath}");
            // }
            //
            // AssetDatabase.Refresh();

            List<string> fileList = new List<string> { };
            GetFile(Application.dataPath + "/Bundles/Icon", fileList);
            for (var index = 0; index < fileList.Count; index++)
            {
                string path = fileList[index];

                if (path.Contains(".meta"))
                {
                    continue;
                }

                string kzm = Path.GetExtension(path);
                if (kzm != ".png")
                {
                    UnityEngine.Debug.Log(path);
                    FileInfo file = new FileInfo(path);
                    file.MoveTo(Path.ChangeExtension(file.FullName, ".png"));
                }
            }
            

            Log.Debug("检测结束");
        }
    }
}