using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ET.Server
{
    public static class ServerLogHelper
    {

        /// 每小时执行一次
        /// </summary>
        public static void CheckLogSize()
        {
            if (ConfigData.LogLevel == 0)
            {
                return;
            }

            string logFolderPath = "../Logs/";
            
            // 大于1G的日志直接删除
            if (Directory.Exists(logFolderPath))
            {
                try
                {
                    string[] logFiles = Directory.GetFiles(logFolderPath, "*.log");
                    foreach (string logFilePath in logFiles)
                    {
                        long fileSizeInBytes = new FileInfo(logFilePath).Length;
                        
                        if (fileSizeInBytes >= 1073741824) // 1G = 1024 * 1024 * 1024 = 1073741824
                        {
                            File.Delete(logFilePath);
                            // File.WriteAllText(logFilePath, string.Empty); // 清空
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("日志文件不存在!");
            }
        }
        
        public static void LogWarning(string msg, bool log = false)
        {
            if (ConfigData.LogLevel >= 3 && log)
            {
                Log.Warning(msg);
            }
        }

        public static void LogDebug(string msg)
        {
            if (ConfigData.LogLevel >= 2)
            {
                Log.Debug(msg);
            }
        }


        public static void KillPlayerInfo(Unit attack, Unit defend)
        {
            if (ConfigData.LogLevel == 0)
            {
                return;
            }
            
            if (attack.IsRobot() || defend.IsRobot())
            {
                return;
            }
            int zone = attack.Zone();
            ServerItem serverItem  = ServerHelper.GetServerItemByZone(VersionMode.Beta, zone);
            if (serverItem == null)
            {
                return;
            }
            
            MapComponent mapComponent = attack.Scene().GetComponent<MapComponent>();
            if (!SceneConfigHelper.UseSceneConfig(mapComponent.MapType))
            {
                return;
            }
            string serverName = serverItem.ServerName;
            string sceneName = SceneConfigCategory.Instance.Get(mapComponent.SceneId).Name;

            UserInfoComponentS attackUserinfo = attack.GetComponent<UserInfoComponentS>();
            UserInfoComponentS defendUserinfo = defend.GetComponent<UserInfoComponentS>();
            string attackName = attackUserinfo.UserInfo.Name;
            string defendName = defendUserinfo.UserInfo.Name;
            attackName = attack.IsRobot() ? $"{attackName}（人机）" : attackName;
            defendName = defend.IsRobot() ? $"{defendName}（人机）" : defendName;
            int attackOcc = attackUserinfo.UserInfo.OccTwo > 0 ? attackUserinfo.UserInfo.OccTwo : attackUserinfo.UserInfo.Occ;
            int defendOcc = defendUserinfo.UserInfo.OccTwo > 0 ? defendUserinfo.UserInfo.OccTwo : defendUserinfo.UserInfo.Occ;

            string log = $"{TimeHelper.DateTimeNow().ToString()}:  {serverName}：{sceneName}： {attackName} 等级({attackUserinfo.UserInfo.Lv}) 职业:({attackOcc}) 战力:({attackUserinfo.UserInfo.Combat}) 击杀了： {defendName} 等级({defendUserinfo.UserInfo.Lv}) 职业:({defendOcc}) 战力:({defendUserinfo.UserInfo.Combat})";
            ConfigData.KillInfoList.Add(log);
            if (ConfigData.KillInfoList.Count >= 10)
            {
                string filePath = "../Logs/WJ_KillPlayer.txt";
                WriteLogList(ConfigData.KillInfoList, filePath);
                ConfigData.KillInfoList.Clear();
            }
        }

        public static void TrialBattleInfo(int zone, string loginfo)
        {
            ServerItem serverItem = ServerHelper.GetServerItemByZone(VersionMode.Beta, zone);
            if (serverItem == null)
            {
                return;
            }

            string log = $"{TimeHelper.DateTimeNow().ToString()}: {serverItem.ServerName} {loginfo}";
            ConfigData.KillInfoList.Add(log);
            if (ConfigData.KillInfoList.Count >= 10)
            {
                string filePath = "../Logs/WJ_KillPlayer.txt";
                WriteLogList(ConfigData.KillInfoList, filePath);
                ConfigData.KillInfoList.Clear();
            }
        }

        public static void PetMingBattleInfo(int zone, string loginfo)
        {
            ServerItem serverItem = ServerHelper.GetServerItemByZone(VersionMode.Beta, zone);
            if (serverItem == null)
            {
                return;
            }

            string log = $"{TimeHelper.DateTimeNow().ToString()}: {serverItem.ServerName} {loginfo}";
            ConfigData.KillInfoList.Add(log);
            if (ConfigData.KillInfoList.Count >= 10)
            {
                string filePath = "../Logs/WJ_KillPlayer.txt";
                WriteLogList(ConfigData.KillInfoList, filePath);
                ConfigData.KillInfoList.Clear();
            }
        }

        
        public static string GetNoticeNew()
        {
            long serverTime = TimeHelper.ServerNow();
            if (serverTime - ConfigData.NoticeLastGetTime < TimeHelper.Minute * 10
                && !string.IsNullOrEmpty(ConfigData.NoticeLastContent))
            {
                return ConfigData.NoticeLastContent;
            }


            string filePath = "../Logs/WJ_Notice.txt";
            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath, Encoding.Default);
                string notice = string.Empty;
                string content = string.Empty;
                int index = 0;
                while ((content = sr.ReadLine()) != null)
                {
                    if (index == 0)
                    {
                        notice = $"{content}";
                    }
                    if (index == 1)
                    {
                        notice += $"@{content}";
                    }
                    if (index >= 2)
                    {
                        notice += $"\r\n{content}";
                    }
                    index++;
                }
                ConfigData.NoticeLastContent = notice;
            }
            else
            {
                ConfigData.NoticeLastContent = "0@公告未配置";
            }

            ConfigData.NoticeLastGetTime = serverTime;
            return ConfigData.NoticeLastContent;
        }

        public static string GetNotice()
        {
            string filePath = "../Logs/WJ_Notice.txt";
            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath, Encoding.Default);
                string notice = string.Empty;
                string content = string.Empty;
                int index = 0;
                while ((content = sr.ReadLine()) != null)
                {
                    if (index == 0)
                    {
                        notice = $"{content}";
                    }
                    if (index == 1)
                    {
                        notice += $"@{content}";
                    }
                    if (index >= 2)
                    {
                        notice += $"\r\n{content}";
                    }
                    index++;
                }
                return  notice;
            }
            else
            {
                 return string.Empty;
            }
        }

        public static void OnStopServer()
        {
            string filePath = "../Logs/WJ_login.txt";
            WriteLogList(ConfigData.LoginInfoList, filePath);
            ConfigData.LoginInfoList.Clear();

            filePath = "../Logs/WJ_ZuoBi.txt";
            WriteLogList(ConfigData.ZuobiInfoList, filePath);
            ConfigData.ZuobiInfoList.Clear();
            
            filePath = "../Logs/WJ_KillPlayer.txt";
            WriteLogList(ConfigData.KillInfoList, filePath);
            ConfigData.KillInfoList.Clear();
        }

        public static void WriteLogList(List<string> infolist, string filePath, bool add = true)
        {
            string text = string.Empty;
            for (int i = 0; i < infolist.Count; i++)
            {
                text += infolist[i];
                text += "\r\n";
            }

            if (!add && File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            if (File.Exists(filePath))
            {
                StreamWriter sw = File.AppendText(filePath);
                sw.WriteLine(text);
                sw.Flush();
                sw.Close();
            }
            else
            {
                FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(fs);
                //开始写入
                sw.WriteLine(text);
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();
            }
        }

     
        public static void LoginInfo(string log)
        {
            if (ConfigData.LogLevel == 0)
            {
                return;
            }
            log = TimeHelper.DateTimeNow().ToString() + " " + log;
            ConfigData.LoginInfoList.Add(log);
            if (ConfigData.LoginInfoList.Count >= 100)
            {
                string filePath = "../Logs/WJ_login.txt";
                WriteLogList(ConfigData.LoginInfoList, filePath);

                ConfigData.LoginInfoList.Clear();
            }
        }

     
        public static void ZuobiInfo(string log)
        {
            //if (LogLevel == 0)
            //{
            //    return;
            //}
            log = TimeHelper.DateTimeNow().ToString() + " " + log;
            ConfigData.ZuobiInfoList.Add(log);
            if (ConfigData.ZuobiInfoList.Count >= 10)
            {
                string filePath = "../Logs/WJ_ZuoBi.txt";
                WriteLogList(ConfigData.ZuobiInfoList, filePath);
                ConfigData.ZuobiInfoList.Clear();
            }
        }

        public static void OnLineInfo(string log)
        {
            log = TimeHelper.DateTimeNow().ToString() + " " + log;
            ConfigData.ZuobiInfoList.Add(log);
            if (ConfigData.ZuobiInfoList.Count >= 10)
            {
                string filePath = "../Logs/WJ_ZuoBi.txt";
                WriteLogList(ConfigData.ZuobiInfoList, filePath);
                ConfigData.ZuobiInfoList.Clear();
            }
        }

        public static void PaiMaiInfo(string log)
        {
            log = TimeHelper.DateTimeNow().ToString() + " " + log;
            string filePath = "../Logs/WJ_PaiMai.txt";
            WriteLogList(new List<string>() { log }, filePath);
        }

        //self.Id, itemID, rewardItems[i].ItemNum, getType
        public static void GetItemInfo(long unitid, int itmeid, int itemnum, int getway)
        {
            string getwaystr = ItemHelper.ItemGetWayName(getway);
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itmeid);
            string loginfo = $"玩家:{unitid}  获得道具:{itmeid} ({itemConfig.ItemName})  数量:{itemnum} ";

            loginfo =  TimeHelper.DateTimeNow().ToString() + " " + loginfo;
            string filePath = "../Logs/WJ_GetItem.txt";
            WriteLogList(new List<string>() { loginfo }, filePath);
        }

        /// <summary>
        /// 今日拍卖金币大于一亿 和   充值 100 并且 金币大于5亿
        /// </summary>
        /// <param name="log"></param>
        public static void PaiMai2Info(string log)
        {
            log =  TimeHelper.DateTimeNow().ToString() + " " + log;
            string filePath = "../Logs/WJ_PaiMai2.txt";
            WriteLogList(new List<string>() { log }, filePath, false);
        }

        public static void ChatInfo(string log)
        {
            log = TimeHelper.DateTimeNow().ToString() + " " + log;
            string filePath = "../Logs/WJ_Chat.txt";
            WriteLogList(new List<string>() { log }, filePath, true);
        }

        public static void GongZuoShi(string log)
        {
            log = TimeHelper.DateTimeNow().ToString() + " " + log;
            string filePath = "../Logs/WJ_ZuoBi.txt";
            WriteLogList(new List<string>() { log }, filePath);
        }

        public static void SoloInfo(string soloInfo, int zone)
        { 
            
        }

        /// <summary>
        /// 检测小黑屋
        /// </summary>
        /// <param name="unit"></param>
        public static void CheckBlackRoom(Unit unit)
        {
            
        }

        /// <summary>
        /// 每小时检测一次
        /// </summary>
        /// <param name="unit"></param>
        public static void CheckZuoBi(Unit unit)
        {
            //if (LogLevel == 0)
            //{
            //    return;
            //}
            UserInfoComponentS userInfo = unit.GetComponent<UserInfoComponentS>();

            long rechargeValue = unit.GetComponent<NumericComponentS>().GetAsLong(NumericType.RechargeNumber);

            //GM账号免于检测
            if (GMData.GmAccount.Contains(userInfo.Account)) {
                return;
            }

            int openDay = ServerHelper.GetServeOpenDay( unit.Zone());
            //钻石线
            if (userInfo.UserInfo.Diamond >= unit.GetComponent<NumericComponentS>().GetAsLong(NumericType.RechargeNumber) * 150 + 50000)
            {
                ZuobiInfo("钻石作弊:" + userInfo.UserInfo.Diamond + " 服务器:" + unit.Zone() + " 名字:" + userInfo.UserName + " 等级:" + userInfo.UserInfo.Lv + " 充值:" + unit.GetComponent<NumericComponentS>().GetAsLong(NumericType.RechargeNumber));
            }

            //等级线
            ServerInfo serverInfo = ConfigData.ServerInfoList[unit.Zone()];
            if (userInfo.UserInfo.Lv > serverInfo.WorldLv) 
            {
                ZuobiInfo("玩家等级超过服务器等级限制:" + userInfo.UserInfo.Lv + " 服务器:" + unit.Zone() + " 名字:" + userInfo.UserName + " 等级:" + userInfo.UserInfo.Lv + " 充值:" + unit.GetComponent<NumericComponentS>().GetAsLong(NumericType.RechargeNumber));
            }

            if (openDay <= 180 || userInfo.UserInfo.Lv < 60)
            {
                //金币线
                if (userInfo.UserInfo.Gold >= unit.GetComponent<NumericComponentS>().GetAsLong(NumericType.RechargeNumber) * 300000 + 5000000 + userInfo.UserInfo.Lv * 500000)
                {
                    ZuobiInfo("金币作弊:" + userInfo.UserInfo.Gold + " 服务器:" + unit.Zone() + " 名字:" + userInfo.UserName + " 等级:" + userInfo.UserInfo.Lv + " 充值:" + unit.GetComponent<NumericComponentS>().GetAsLong(NumericType.RechargeNumber));
                }

                //道具线
                if (unit.GetComponent<BagComponentS>().GetItemNumber(10010083) > 1000 + unit.GetComponent<NumericComponentS>().GetAsLong(NumericType.RechargeNumber) * 10) {
                    ZuobiInfo("洗练石作弊:" + unit.GetComponent<BagComponentS>().GetItemNumber(10010083) + " 服务器:" + unit.Zone() + " 名字:" + userInfo.UserName + " 等级:" + userInfo.UserInfo.Lv + " 充值:" + unit.GetComponent<NumericComponentS>().GetAsLong(NumericType.RechargeNumber));
                }
            }

            //查找神兽
            int  shenshouNumber = unit.GetComponent<PetComponentS>().GetShenShouNumber();    
            if (shenshouNumber > 0 && shenshouNumber * 4000 > rechargeValue)
            {
                //if (PetHelper.IsHaveShenShou(unit.GetComponent<PetComponent>().GetAllPets()))
                {
                    ZuobiInfo("低充值有神兽需核查! " + " 服务器:" + unit.Zone() + " 名字:" + userInfo.UserName + " 充值:" + rechargeValue);
                }
            }

            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
            List<ItemInfo> bagInfos =  bagComponent.GetAllItems();
            for (int i = 0; i < bagInfos.Count; i++)
            {
                if (bagInfos[i].ItemID > 100 && bagInfos[i].ItemNum >= 10000)
                {
                    ZuobiInfo($"道具数量异常： {unit.Zone()} {unit.Id} {bagInfos[i].ItemID} {bagInfos[i].ItemNum} ");
                }
            }
        }
    }
}
