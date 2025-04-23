using System;
using System.Collections.Generic;

namespace ET
{
    public static class ServerHelper
    {
      
        public const string LogicServer = "weijinggameserver.weijinggame.com";//"weijinggameserver.weijinggame.com"
        public const string LogicServerBanHao = "47.94.107.92";

        public static int UpdateServerList()
        {
            return 0;
        }

        //Alpha = 0,              //仅内部人员使用。一般不向外部发布
        //Beta = 1,               //公开测试版
        //BanHao = 2,

        public static ServerItem GetServerItemByZone( int versionMode,int zone)
        {
            ServerItem serverItem = null;
            List<ServerItem> serverItems = GetServerList( zone);
            for (int i = 0; i < serverItems.Count; i++)
            {
                if (serverItems[i].ServerId == zone)
                {
                    serverItem = serverItems[i];
                }
            }
            return serverItem;
        }

        public static long GetServerOpenTime(int zone)
        { 
            ServerItem serverItem = GetServerItemByZone(VersionMode.Beta, zone);
            if (serverItem == null)
            {
                Log.Debug($"serverItem == null {zone}");
                return 0;
            }
            return serverItem.ServerOpenTime;   
        }

        public static int GetServeOpenDay(int zone)
        {
            long serverNow = TimeHelper.ServerNow();
            long openSerTime = GetServerOpenTime( zone);
            if (openSerTime == 0 || serverNow < openSerTime)
            {
                return 0;
            }

            return TimeHelper.GetServeOpenDay(openSerTime);
        }
        /// <summary>
        /// 合区后的区
        /// </summary>
        /// <param name="banhao"></param>
        /// <param name="zone"></param>
        /// <returns></returns>
        public static int GetNewServerId(int zone)
        {
            List<ServerItem> serverItems_1 = GetServerList(VersionMode.Beta);

            string serverip = string.Empty;
            for (int i = 0; i < serverItems_1.Count; i++)
            {
                if (serverItems_1[i].ServerId == zone)
                {
                    serverip = serverItems_1[i].ServerIp;
                    break;
                }
            }
            for (int i = 0; i < serverItems_1.Count; i++)
            {
                if (serverItems_1[i].ServerIp == serverip && serverItems_1[i].Show == 1)
                {
                    zone = serverItems_1[i].ServerId;
                    break;
                }
            }
            return zone;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="innerNet"></param>
        /// <param name="zone"></param>
        /// <returns></returns>
        public static int GetOldServerId(int zone)
        {
            bool banhao = CommonHelp.IsBanHaoZone(zone);
            List<ServerItem> serverItems_1 = GetServerList(VersionMode.BanHao);

            string serverip = string.Empty;
            for (int i = 0; i < serverItems_1.Count; i++)
            {
                if (serverItems_1[i].ServerId == zone)
                {
                    serverip = serverItems_1[i].ServerIp;
                    break;
                }
            }
            for (int i = 0; i < serverItems_1.Count; i++)
            {
                if (serverItems_1[i].ServerIp == serverip)
                {
                    zone = serverItems_1[i].ServerId;
                }
            }
            return zone;
        }

        public static bool IsOldServer(int zone)
        {
            List<ServerItem> serverItems_1 = GetServerList(VersionMode.Beta);
            string serverip = string.Empty;
            for (int i = 0; i < serverItems_1.Count; i++)
            {
                if (serverItems_1[i].ServerId == zone)
                {
                    serverip = serverItems_1[i].ServerIp;
                    break;
                }
            }

            int servernumber = 0;
            for (int i = 0; i < serverItems_1.Count; i++)
            {
                if (serverItems_1[i].ServerIp == serverip)
                {
                    servernumber++;
                }
            }
            return servernumber > 1;
        }

        public static string GetRouterHttpHost(int versionMode)
        {
            if (versionMode == VersionMode.Beta)
            {
                return ConstValue.RouterHttpHostOuter;
            }

            return ConstValue.RouterHttpHostInter;
        }

        public static ServerItem GetServerItem(int id, string ip, string name, long openTime, int show)
        {
            ServerItem serverItem = ServerItem.Create();
            serverItem.ServerId = id;
            serverItem.ServerIp = ip;
            serverItem.ServerName = name;
            serverItem.ServerOpenTime = openTime;
            serverItem.New = 0;
            serverItem.Show = show;
            return serverItem;
        }

        public static void CheckServerIds(List<ServerItem> allserverList)
        {
            Dictionary<string, List<int>> servertozone = new Dictionary<string, List<int>>();
            for (int i  = 0; i < allserverList.Count; i++)
            {
                ServerItem serverItem = allserverList[i];
                
                if (!servertozone.ContainsKey(serverItem.ServerIp))
                {
                    servertozone.Add( serverItem.ServerIp, new  List<int>());
                }
                if (servertozone[serverItem.ServerIp].Contains(serverItem.ServerId))
                {
                    Console.WriteLine("ServerItem 配置重复: " + serverItem.ServerIp );
                    Log.Error("ServerItem 配置重复: " + serverItem.ServerIp);
                    break;
                }

                servertozone[serverItem.ServerIp].Add(serverItem.ServerId);
            }
        }

        public static List<ServerItem> GetServerList(int  versionMode)
        {
            //object padlock = new object();
            if (ConfigData.ServerItems.Count > 0 )
            { 
                return ConfigData.ServerItems;
            }
            //Log.Debug("UpdateServerList");
            
            string ip = GetRouterHttpHost(versionMode);
  
            List<ServerItem> serverItems = new List<ServerItem>();
            serverItems.Add( GetServerItem( 1, $"{ip}:20325", "封测一区", 1720782000000, 1 ) );
            serverItems.Add( GetServerItem( 2, $"{ip}:20335", "封测二区", 1720954800000, 1 ) );
            serverItems.Add( GetServerItem( 3, $"{ip}:20345", "封测三区", 1721041200000, 1 ) );
            serverItems.Add( GetServerItem( 1011, $"{ip}:20355", "版号服", 1744974000000, 1 ) );
            ConfigData.ServerItems = serverItems;
         
            CheckServerIds(ConfigData.ServerItems);
            
            ///PlatformHelper.GetPlatformName(); 所有渠道ID定义
            return ConfigData.ServerItems;
        }
    }
}
