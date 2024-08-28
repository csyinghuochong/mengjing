using System;
using System.Collections.Generic;
using System.IO;

namespace ET
{
    
    [Code]
    public class RandNameComponent : Singleton<RandNameComponent>, ISingletonAwake
    {
      
        public List<string> RandNameNameList = new List<string>();
        public List<string> RandNameXing = new List<string>();

        public void Awake()
        { 
            this.RandNameXing = this.ReadFile("../Config/Name/RandName_Xing.txt");
            this.RandNameNameList = this.ReadFile("../Config/Name/RandName_Name.txt");
        }

        public List<string> ReadFile( string path)
        {
            List<string> vs = new List<string>();
            string ReadLine;
            string[] array;
            StreamReader reader = new StreamReader(path, System.Text.Encoding.Default);
            while (reader.Peek() >= 0)
            {
                try
                {
                    ReadLine = reader.ReadLine();
                    if (ReadLine != "")
                    {
                        ReadLine = ReadLine.Replace("\"", "");
                        array = ReadLine.Split('@');
                        if (array.Length == 0)
                        {
                            break;
                        }
                        vs.Add(array[0]);
                    }
                }
                catch (Exception ex)
                {
                    Log.Debug(ex.ToString());
                    break;
                }
            }
       
            return vs;
        }
       
        public string GetRandomName()
        {
            int xingXuHao = RandomHelper.RandomNumber(0, this.RandNameXing.Count);
            int nameXuHao = RandomHelper.RandomNumber(0, this.RandNameNameList.Count);
            return RandNameXing[xingXuHao] + RandNameNameList[nameXuHao];
        }
    }
}

