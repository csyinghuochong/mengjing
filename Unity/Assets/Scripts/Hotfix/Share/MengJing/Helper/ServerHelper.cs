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
        public static string GetServerIpList(bool innerNet, int zone)
        {
            ServerItem serverItem = GetGetServerItem(innerNet, zone);
            return serverItem.ServerIp;
        }

        public static ServerItem GetGetServerItem(bool innerNet, int zone)
        {
            ServerItem serverItem = null;
            List<ServerItem> serverItems = ServerHelper.GetServerList(innerNet, zone);
            for (int i = 0; i < serverItems.Count; i++)
            {
                if (serverItems[i].ServerId == zone)
                {
                    serverItem = serverItems[i];
                }
            }
            return serverItem;
        }

        public static long GetOpenServerTime(bool innerNet, int zone)
        { 
            ServerItem serverItem = GetGetServerItem(innerNet, zone);
            if (serverItem == null)
            {
                Log.Debug($"serverItem == null {zone}");
                return 0;
            }
            return serverItem.ServerOpenTime;   
        }

        public static int GetOpenServerDay(bool innerNet, int zone)
        {
            long serverNow = TimeHelper.ServerNow();
            long openSerTime = GetOpenServerTime(innerNet, zone);
            if (openSerTime == 0 || serverNow < openSerTime)
            {
                return 0;
            }

            int openserverDay = DateDiff_Time(serverNow, openSerTime);
            return openserverDay;
        }

        public static int DateDiff_Time(long time1, long time2)
        {
            DateTime d1 = TimeInfo.Instance.ToDateTime(time1);
            DateTime d2 = TimeInfo.Instance.ToDateTime(time2);
            DateTime d3 = Convert.ToDateTime(string.Format("{0}-{1}-{2}", d1.Year, d1.Month, d1.Day));

            DateTime d4 = Convert.ToDateTime(string.Format("{0}-{1}-{2}", d2.Year, d2.Month, d2.Day));
            int days = (d3 - d4).Days + 1;
            return days;
        }
        
        public static string GetLogicServer(bool innerNet,  VersionMode versionMode)
        {
            switch (versionMode)
            {
                case VersionMode.BanHao:
                    return innerNet ? ComHelp.LocalIp : LogicServerBanHao;
                default:
                    return innerNet ? ComHelp.LocalIp : LogicServer;

            }
        }

        /// <summary>
        /// 合区后的区
        /// </summary>
        /// <param name="banhao"></param>
        /// <param name="zone"></param>
        /// <returns></returns>
        public static int GetNewServerId(int zone)
        {
            bool banhao = ComHelp.IsBanHaoZone(zone);

            List<ServerItem> serverItems_1 = new List<ServerItem>();
            if (banhao)
            {
                serverItems_1 = GetServerList(false, 201);
            }
            else
            {
                serverItems_1 = GetServerList(false, 1);
            }

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
            bool banhao = ComHelp.IsBanHaoZone(zone);
            List<ServerItem> serverItems_1 = new List<ServerItem>();
            if (banhao)
            {
                serverItems_1 = GetServerList(false, 201);
            }
            else
            {
                serverItems_1 = GetServerList(false, 1);
            }

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
            List<ServerItem> serverItems_1 = GetServerList(false, 1);
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

        public static List<ServerItem> GetServerList(bool innerNet, int zone)
        {
            List<ServerItem> ServerItems = ConfigData.ServerItems;
            if (ServerItems.Count > 0 )
            { 
                return ServerItems;
            }
            //Log.Debug("UpdateServerList");
            ServerItems.Clear();

            VersionMode versionMode = ComHelp.IsBanHaoZone(zone) ? VersionMode.BanHao : VersionMode.Beta;
            string ip =  GetLogicServer(innerNet, versionMode);
            List<ServerItem> serverItems_1 = ServerItems;

            serverItems_1.Add(new ServerItem()
            {
                ServerId = 1,
                ServerIp = $"{ip}:20325",
                ServerName = "封测区",
                ServerOpenTime = 1662189906681,
                New = 0,
                Show = 1,
                PlatformList = new List<int>()
                {
                    0,
                    1,
                    2,
                    3,
                    4,
                    5,
                    6,
                    20001
                }
            });

            ///PlatformHelper.GetPlatformName(); 所有渠道ID定义
            return serverItems_1;
        }
    }
}
