using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;


namespace ET.Server
{
    
    public static class FangchenmiHelper
    {
        
        //"{ ai = 1669902416, name = 唐春光, idNum = 429001198512282996 }"
        //"f6df1ff5f23285679037fef83c398fb18051c13549db60bba9887361e55316c6"
        //test
        //public const string FangChenMi_appid = "46d6895c5d544f1685f4cf343954c018";
        //public const string FangChenMi_secretkey = "f8dbf17bb15192931d4cc096e52f5104";
        //public const string FangChenMi_bizid = "1101999999";
        
        public static long SecondsFrom19700101ms()
        {
        	//var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
        	//return (long)(DateTime.Now - startTime).TotalMilliseconds; // 相差毫秒数
        	TimeSpan ts2 = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        	return new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds(); // Convert.ToInt64(ts2.TotalMilliseconds);
        }
        
        private const String host = "https://naidcard.market.alicloudapi.com/nidCard";
        private const String path = "/nidCard";
        private const String method = "GET";
        private const String appcode = "d59fefe68cf644f6a8f54dd039c3806f";//开通服务后 买家中心-查看AppCode

        //ai = ai,
        //name = request.Name,
        //idNum = request.IdCardNO,
        public static async ETTask<RealNameCode> OnDoFangchenmi_2(string idcard, string name)
        {
	        String querys = $"idCard={idcard}&name={name}";
	        String url = host + path;
	        if (0 < querys.Length)
	        {
		        url = url + "?" + querys;
	        }
	        Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
	        keyValuePairs.Add("idCard", idcard);
	        keyValuePairs.Add("name", name);
	        //keyValuePairs.Add("Authorization", "APPCODE " + appcode);
	        //httpContent.Headers.Add("Authorization", "APPCODE " + appcode);
	        string result = await HttpHelper.HttpClientDoGet(host, $"APPCODE {appcode}", keyValuePairs);
	        if (string.IsNullOrEmpty(result))
	        {
		        return null;
	        }
	        try
	        {
		        //  /*状态码  01: 通过，02: 不通过，202: 无法认证(库无) */
		        NidCardData result_1 = BsonSerializer.Deserialize<NidCardData>(result);
		        if (result_1.status == "01")
		        {
			        RealNameCode realNameCode = new RealNameCode();
			        realNameCode.errcode = 0;
			        realNameCode.data = new RealNameData();
			        realNameCode.data.result = new RealNameResult();
			        realNameCode.data.result.status = 0;
			        return realNameCode;
		        }
		        return null;
	        }
	        catch (Exception ex)
	        {
		        Log.Debug(ex.ToString());
		        return null;
	        }
        }

        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
	        return true;
        }
        
    }
}