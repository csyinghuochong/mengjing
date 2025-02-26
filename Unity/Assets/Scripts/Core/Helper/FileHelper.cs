using System;
using System.Collections.Generic;
using System.IO;

namespace ET
{
	public static class FileHelper
	{
		public static List<string> GetAllFiles(string dir, string searchPattern = "*")
		{
			List<string> list = new List<string>();
			GetAllFiles(list, dir, searchPattern);
			return list;
		}
		
		public static void GetAllFiles(List<string> files, string dir, string searchPattern = "*")
		{
			string[] fls = Directory.GetFiles(dir);
			foreach (string fl in fls)
			{
				files.Add(fl);
			}

			string[] subDirs = Directory.GetDirectories(dir);
			foreach (string subDir in subDirs)
			{
				GetAllFiles(files, subDir, searchPattern);
			}
		}
		
		 /// <summary>
    /// 移动文件
    /// </summary>
    /// <param name="sourceFile"></param>
    /// <param name="destinationFile"></param>
    /// <returns></returns>
    public  static bool MoveFile(string sourceFile, string destinationFile)
    {
        try
        {
            // 确保目标路径存在
            var destinationDirectory = Path.GetDirectoryName(destinationFile);

            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }

            if (File.Exists(destinationFile))
            {
                return true;
            }

            // 移动文件
            File.Move(sourceFile, destinationFile);
            Log.Debug("文件移动成功:" + destinationFile);
            return true;
        }
        catch (Exception ex)
        {
            Log.Error("文件移动失败: " + ex.Message);
            return false;
        }
    }
    
    /// <summary>
    /// 拷贝文件夹
    /// </summary>
    /// <param name="sourceFolder"></param>
    /// <param name="destinationFolder"></param>
    /// <exception cref="DirectoryNotFoundException"></exception>
    public static void CopyFolderContents(string sourceFolder, string destinationFolder)
    {
        // 检查源文件夹是否存在
        if (!Directory.Exists(sourceFolder))
        {
            throw new DirectoryNotFoundException($"源文件夹 {sourceFolder} 不存在。");
        }

        // 如果目标文件夹不存在，则创建它
        if (!Directory.Exists(destinationFolder))
        {
            Directory.CreateDirectory(destinationFolder);
        }

        // 复制文件
        string[] files = Directory.GetFiles(sourceFolder);
        foreach (string file in files)
        {
            string fileName = Path.GetFileName(file);
            string destFile = Path.Combine(destinationFolder, fileName);
            
            File.Copy(file, destFile, true);
        }

        // 递归复制子文件夹
        string[] subFolders = Directory.GetDirectories(sourceFolder);
        foreach (string subFolder in subFolders)
        {
            string folderName = Path.GetFileName(subFolder);
            string destSubFolder = Path.Combine(destinationFolder, folderName);
            CopyFolderContents(subFolder, destSubFolder);
        }
    }
    
    /// <summary>
    /// 移动文件夹
    /// </summary>
    /// <param name="sourceFolder"></param>
    /// <param name="destinationFolder"></param>
    /// <exception cref="DirectoryNotFoundException"></exception>
    public static void MoveFolderContents(string sourceFolder, string destinationFolder)
    {
        // 检查源文件夹是否存在
        if (!Directory.Exists(sourceFolder))
        {
            throw new DirectoryNotFoundException($"源文件夹 {sourceFolder} 不存在。");
        }

        // 如果目标文件夹不存在，则创建它
        if (!Directory.Exists(destinationFolder))
        {
            Directory.CreateDirectory(destinationFolder);
        }

        // 移动文件
        string[] files = Directory.GetFiles(sourceFolder);
        foreach (string file in files)
        {
            string fileName = Path.GetFileName(file);
            string destFile = Path.Combine(destinationFolder, fileName);
            File.Move(file, destFile);
        }

        // 递归移动子文件夹
        string[] subDirectories = Directory.GetDirectories(sourceFolder);
        foreach (string subDirectory in subDirectories)
        {
            string subDirectoryName = Path.GetFileName(subDirectory);
            string destSubDirectory = Path.Combine(destinationFolder, subDirectoryName);
            MoveFolderContents(subDirectory, destSubDirectory);
        }

        // 移动完成后删除空的源文件夹
        Directory.Delete(sourceFolder);
    }
    
		
		public static void CleanDirectory(string dir)
		{
			if (!Directory.Exists(dir))
			{
				return;
			}
			foreach (string subdir in Directory.GetDirectories(dir))
			{
				Directory.Delete(subdir, true);		
			}

			foreach (string subFile in Directory.GetFiles(dir))
			{
				File.Delete(subFile);
			}
		}

		public static void CopyDirectory(string srcDir, string tgtDir)
		{
			DirectoryInfo source = new DirectoryInfo(srcDir);
			DirectoryInfo target = new DirectoryInfo(tgtDir);
	
			if (target.FullName.StartsWith(source.FullName, StringComparison.CurrentCultureIgnoreCase))
			{
				throw new Exception("父目录不能拷贝到子目录！");
			}
	
			if (!source.Exists)
			{
				return;
			}
	
			if (!target.Exists)
			{
				target.Create();
			}
	
			FileInfo[] files = source.GetFiles();
	
			for (int i = 0; i < files.Length; i++)
			{
				File.Copy(files[i].FullName, Path.Combine(target.FullName, files[i].Name), true);
			}
	
			DirectoryInfo[] dirs = source.GetDirectories();
	
			for (int j = 0; j < dirs.Length; j++)
			{
				CopyDirectory(dirs[j].FullName, Path.Combine(target.FullName, dirs[j].Name));
			}
		}
		
		public static void ReplaceExtensionName(string srcDir, string extensionName, string newExtensionName)
		{
			if (Directory.Exists(srcDir))
			{
				string[] fls = Directory.GetFiles(srcDir);

				foreach (string fl in fls)
				{
					if (fl.EndsWith(extensionName))
					{
						File.Move(fl, fl.Substring(0, fl.IndexOf(extensionName)) + newExtensionName);
						File.Delete(fl);
					}
				}

				string[] subDirs = Directory.GetDirectories(srcDir);

				foreach (string subDir in subDirs)
				{
					ReplaceExtensionName(subDir, extensionName, newExtensionName);
				}
			}
		}
	}
}
