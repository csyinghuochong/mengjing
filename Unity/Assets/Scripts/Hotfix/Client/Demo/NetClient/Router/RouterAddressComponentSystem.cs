using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace ET.Client
{
    [EntitySystemOf(typeof(RouterAddressComponent))]
    [FriendOf(typeof(RouterAddressComponent))]
    public static partial class RouterAddressComponentSystem
    {
        [EntitySystem]
        private static void Awake(this RouterAddressComponent self, string address, int port)
        {
            self.RouterManagerHost = address;
            self.RouterManagerPort = port;
        }
        
        public static async ETTask Init(this RouterAddressComponent self)
        {
            self.RouterManagerIPAddress = NetworkHelper.GetHostAddress(self.RouterManagerHost);
            await self.GetAllRouter();
        }

        private static async ETTask GetAllRouter(this RouterAddressComponent self)
        {
            string domain =  "molongbanhao.weijinggame.com";
            //"weijinggameserver.weijinggame.com";
            //"molongbanhao.weijinggame.com";
            // "www.weijinggame.com"; // 要解析的域名

            // 获取域名对应的所有IP地址
            //IPAddress[] ipAddresses = Dns.GetHostAddresses(domain);

            //Log.Debug($"域名 {domain} 对应的IP地址：");
            //foreach (IPAddress ip in ipAddresses)
            //{
            //    // 区分IPv4和IPv6地址
            //    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            //    {
            //        Log.Debug($"IPv4: {ip}");
            //    }
            //    else if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
            //    {
            //        Log.Debug($"IPv6: {ip}");
            //    }
            //}
            IPAddress[] ipAddresses = Dns.GetHostAddresses(domain);
            IPAddress returnIpAddress = null;
            foreach (IPAddress ipAddress in ipAddresses)
            {
                returnIpAddress = ipAddress;
                if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
                {
                    Log.Debug($"ipAddress: {ipAddress.ToString()}");
                }
            }


            // string url = $"https://molongbanhao.weijinggame.com:30410/get_router?v={RandomGenerator.RandUInt32()}";
            //string url = $"https://www.weijinggame.com:30410/get_router?v={RandomGenerator.RandUInt32()}";

            string url = $"http://{self.RouterManagerHost}:{self.RouterManagerPort}/get_router?v={RandomGenerator.RandUInt32()}";

            Log.Debug($"start get router info: {url}");
            string routerInfo = await HttpClientHelper.Get(url);
            Log.Debug($"recv router info: {routerInfo}");
            HttpGetRouterResponse httpGetRouterResponse = MongoHelper.FromJson<HttpGetRouterResponse>(routerInfo);
            self.Info = httpGetRouterResponse;
            Log.Debug($"start get router info finish: {MongoHelper.ToJson(httpGetRouterResponse)}");
            
            // 打乱顺序
            RandomGenerator.BreakRank(self.Info.Routers);
            
            self.WaitTenMinGetAllRouter().Coroutine();
        }
        
        // 等10分钟再获取一次
        public static async ETTask WaitTenMinGetAllRouter(this RouterAddressComponent self)
        {
            await self.Root().GetComponent<TimerComponent>().WaitAsync(5 * 60 * 1000);
            if (self.IsDisposed)
            {
                return;
            }
            await self.GetAllRouter();
        }

        public static IPEndPoint GetAddress(this RouterAddressComponent self)
        {
            if (self.Info.Routers.Count == 0)
            {
                return null;
            }

            string address = self.Info.Routers[self.RouterIndex++ % self.Info.Routers.Count];
            Log.Info($"get router address: {self.RouterIndex - 1} {address}");
            string[] ss = address.Split(':');
            IPAddress ipAddress = IPAddress.Parse(ss[0]);
            if (self.RouterManagerIPAddress.AddressFamily == AddressFamily.InterNetworkV6)
            { 
                ipAddress = ipAddress.MapToIPv6();
            }
            return new IPEndPoint(ipAddress, int.Parse(ss[1]));
        }
        
        public static IPEndPoint GetRealmAddress(this RouterAddressComponent self)
        {
            string address = self.Info.Realms[0];
            string[] ss = address.Split(':');
            
            Log.Debug($"GetRealmAddress: {ss[0]}  {ss[1]}");
            IPAddress ipAddress = IPAddress.Parse(ss[0]);
            //if (self.IPAddress.AddressFamily == AddressFamily.InterNetworkV6)
            //{ 
            //    ipAddress = ipAddress.MapToIPv6();
            //}
            return new IPEndPoint(ipAddress, int.Parse(ss[1]));
        }

        public static IPEndPoint GetRealmAddress(this RouterAddressComponent self, string account, int zone)
        {
            int v = account.Mode(self.Info.Realms.Count);
            string address = self.Info.Realms[0]; //self.Info.Realms[zone - 1]
            string[] ss = address.Split(':');
            IPAddress ipAddress = IPAddress.Parse(ss[0]);
            //if (self.IPAddress.AddressFamily == AddressFamily.InterNetworkV6)
            //{ 
            //    ipAddress = ipAddress.MapToIPv6();
            //}
            return new IPEndPoint(ipAddress, int.Parse(ss[1]));
        }
    }
}