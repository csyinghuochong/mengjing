using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ET
{
    public static class HexConverter
    {
        public static char ToCharUpper(int value)
        {
            value &= 0xF;
            value += '0';

            if (value > '9')
            {
                value += ('A' - ('9' + 1));
            }

            return (char)value;
        }
    }
    
    public static class HttpHelper
    {
        
        /// <summary>
        /// 判断是不是周末/节假日
        /// </summary>
        /// <param name="date">日期</param>
        /// <returns>周末和节假日返回true，工作日返回false</returns>
        public static async ETTask<bool> IsHolidayByDate(DateTime date)
        {
            try
            {
                var isHoliday = false;
                var httpClient = new HttpClient();

                List<KeyValuePair<string, string>> param = new List<KeyValuePair<string, string>>();
                param.Add(new KeyValuePair<string, string>("d", date.ToString("yyyyMMdd")));

                var day = date.DayOfWeek;
                //周五一点可以进
                if (day == DayOfWeek.Friday)
                    return true;
                string str = "";
                HttpContent httpContent = new StringContent(str);
                HttpResponseMessage response = await httpClient.PostAsync("http://tool.bitefu.net/jiari/", new FormUrlEncodedContent(param));
                response.EnsureSuccessStatusCode();//用来抛异常的
                string responseBody = await response.Content.ReadAsStringAsync();
                //0为工作日，1为周末，2为法定节假日
                if (responseBody == "1" || responseBody == "2")
                    isHoliday = true;

                return isHoliday;
            }
            catch (Exception ex)
            {
                Log.Debug(ex.ToString());
            }
            return false;
        }
        
        public static async ETTask<string> GetIosPayParameter_Test1()
        {
            //-----------------------------------第一步:创建Htt请求----------------------//
            //向Appstpre发起支付参数的请求
            string result = "";
            try
            {
                System.Net.ServicePointManager.SecurityProtocol = 
                        SecurityProtocolType.Tls12 | 
                        SecurityProtocolType.Tls13;
                
                var handler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
                    {
                        // 手动构建证书链
                        var newChain = new X509Chain
                        {
                            ChainPolicy = 
                            {
                                RevocationMode = X509RevocationMode.NoCheck,
                                ExtraStore = 
                                {
                                    new X509Certificate2("C:\\certs\\USERTrustRSA.cer")
                                }
                            }
                        };
                        return newChain.Build(cert);
                    }
                };

                using var client = new HttpClient(handler);
                
                string url = "https://buy.itunes.apple.com/verifyReceipt";
                string postData = "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";
                
                HttpClient httpClient = new HttpClient();
                httpClient.Timeout = TimeSpan.FromMinutes(100);
                HttpContent httpContent = new StringContent(postData);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                HttpResponseMessage response = await httpClient.PostAsync(url, httpContent);
                response.EnsureSuccessStatusCode();//用来抛异常的
                result = await response.Content.ReadAsStringAsync();
                
                Console.WriteLine($"result:  {result}");
            }
            catch (Exception ex)
            {
                Log.Info($"Exception ex: {ex}");
                return "";
            }
            return result;//读取微信返回的数据
        }
        
        public static async ETTask<string> GetIosPayParameter(string url, string postData)
        {
            //-----------------------------------第一步:创建Htt请求----------------------//
            //向Appstpre发起支付参数的请求
            string result = "";
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.Timeout = TimeSpan.FromMinutes(100);
                HttpContent httpContent = new StringContent(postData);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                HttpResponseMessage response = await httpClient.PostAsync(url, httpContent);
                response.EnsureSuccessStatusCode();//用来抛异常的
                result = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Log.Info($"Exception ex: {ex}");
                return "";
            }
            return result;//读取微信返回的数据
        }

        public static string OnWebRequestPost_Form(string url, Dictionary<string, string> paramList)
        {
            string result = string.Empty;

            try
            {
                HttpClient httpClient = new HttpClient();
                var multipartFormDataContent = new MultipartFormDataContent();
                foreach (var keyValuePair in paramList)
                {
                    httpClient.DefaultRequestHeaders.Add(keyValuePair.Key, keyValuePair.Value);
                }
                multipartFormDataContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                HttpResponseMessage response = httpClient.PostAsync(url, multipartFormDataContent).Result;
                result = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;  
        }

        public static string OnWebRequestPost_Form2(string url, Dictionary<string, string> paramList)
        {
            string result = string.Empty;

            try
            {
                var formData = new MultipartFormDataContent();
                HttpContent content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("rPath",  "/RootFolder/"),
                    new KeyValuePair<string, string>("nName", "TestFolder"),
                    new KeyValuePair<string, string>("type", "Folder")
                });

                content.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");
                content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
                formData.Add(content);

                HttpResponseMessage response = new HttpResponseMessage();
                using (var client = new HttpClient() { })
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "xxxxxxx=");
                    response = client.PostAsync(url, content).Result;
                }

                string statusCode = response.StatusCode.ToString();
                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsStringAsync().Result;
                    return result;
                }
                else
                {
                    return statusCode;
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        public static string UrlEncode_2(string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            int safeCount = 0;
            int spaceCount = 0;
            for (int i = 0; i < value.Length; i++)
            {
                char ch = value[i];
                if (IsUrlSafeChar(ch))
                {
                    safeCount++;
                }
                else if (ch == ' ')
                {
                    spaceCount++;
                }
            }

            int unexpandedCount = safeCount + spaceCount;
            if (unexpandedCount == value.Length)
            {
                if (spaceCount != 0)
                {
                    // Only spaces to encode
                    return value.Replace(' ', '+');
                }

                // Nothing to expand
                return value;
            }

            int byteCount = Encoding.UTF8.GetByteCount(value);
            int unsafeByteCount = byteCount - unexpandedCount;
            int byteIndex = unsafeByteCount * 2;

            // Instead of allocating one array of length `byteCount` to store
            // the UTF-8 encoded bytes, and then a second array of length
            // `3 * byteCount - 2 * unexpandedCount`
            // to store the URL-encoded UTF-8 bytes, we allocate a single array of
            // the latter and encode the data in place, saving the first allocation.
            // We store the UTF-8 bytes to the end of this array, and then URL encode to the
            // beginning of the array.
            byte[] newBytes = new byte[byteCount + byteIndex];
            Encoding.UTF8.GetBytes(value, 0, value.Length, newBytes, byteIndex);

            GetEncodedBytes(newBytes, byteIndex, byteCount, newBytes);
            return Encoding.UTF8.GetString(newBytes);
        }

        private static bool IsUrlSafeChar(char ch)
        {
            // Set of safe chars, from RFC 1738.4 minus '+'
            /*
            if (ch >= 'a' && ch <= 'z' || ch >= 'A' && ch <= 'Z' || ch >= '0' && ch <= '9')
                return true;

            switch (ch)
            {
                case '-':
                case '_':
                case '.':
                case '!':
                case '*':
                case '(':
                case ')':
                    return true;
            }

            return false;
            */
            // Optimized version of the above:

            int code = (int)ch;

            const int safeSpecialCharMask = 0x03FF0000 | // 0..9
                1 << ((int)'!' - 0x20) | // 0x21
                1 << ((int)'(' - 0x20) | // 0x28
                1 << ((int)')' - 0x20) | // 0x29
                1 << ((int)'*' - 0x20) | // 0x2A
                1 << ((int)'-' - 0x20) | // 0x2D
                1 << ((int)'.' - 0x20); // 0x2E

            return IsAsciiLetter(ch) ||
                   ((uint)(code - 0x20) <= (uint)('9' - 0x20) && ((1 << (code - 0x20)) & safeSpecialCharMask) != 0) ||
                   (code == (int)'_');
        }

        private static void GetEncodedBytes(byte[] originalBytes, int offset, int count, byte[] expandedBytes)
        {
            int pos = 0;
            int end = offset + count;
            //Debug.Assert(offset < end && end <= originalBytes.Length);
            for (int i = offset; i < end; i++)
            {
#if DEBUG
                // Make sure we never overwrite any bytes if originalBytes and
                // expandedBytes refer to the same array
                if (originalBytes == expandedBytes)
                {
                    //Debug.Assert(i >= pos);
                }
#endif

                byte b = originalBytes[i];
                char ch = (char)b;
                if (IsUrlSafeChar(ch))
                {
                    expandedBytes[pos++] = b;
                }
                else if (ch == ' ')
                {
                    expandedBytes[pos++] = (byte)'+';
                }
                else
                {
                    expandedBytes[pos++] = (byte)'%';
                    expandedBytes[pos++] = (byte)HexConverter.ToCharUpper(b >> 4);
                    expandedBytes[pos++] = (byte)HexConverter.ToCharUpper(b);
                }
            }
        }

        public static bool IsAsciiLetter(char c)
        {
            return (uint)((c | 0x20) - 'a') <= 'z' - 'a';
        }

#if SERVER

        public static string UrlEncodeInterface(string str)
        {
            return Uri.EscapeDataString(str);
            //int useType = TimeHelper.DateTimeNow().Minute % 3;
            //Log.Console($"useType:  {useType}");
            //if (useType == 0)
            //{
            //    return UrlEncode_2(str);
            //}
            //if (useType == 1)
            //{
            //    return Uri.EscapeDataString(str);
            //}
            //if (useType == 2)
            //{
            //    return System.Web.HttpUtility.UrlEncode(str, System.Text.Encoding.UTF8);
            //}
            //return Uri.EscapeDataString(str);
        }

        public static string OnWebRequestPost_TikTokLogin(string url, Dictionary<string, string> dic)
        {
            string result = "";
            try
            {
                string url_access_token = UrlEncodeInterface(dic["access_token"]);
                string url_app_id = UrlEncodeInterface(dic["app_id"]);
                string url_ts = UrlEncodeInterface(dic["ts"]);
                string url_sign = UrlEncodeInterface(dic["sign"]);

                string postData = $"access_token={url_access_token}&app_id={url_app_id}&ts={url_ts}&sign={url_sign}";
                HttpClient httpClient = new HttpClient();
                httpClient.Timeout = TimeSpan.FromMinutes(100);
                HttpContent httpContent = new StringContent(postData);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;
                response.EnsureSuccessStatusCode();//用来抛异常的
                result = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                Log.Info($"Exception ex: {ex}");
                return "";
            }
            return result;//读取微信返回的数据
        }

        public static string OnWebRequestPost_Pay(string url, Dictionary<string, string> dic)
        {
            string result = "";
            try
            {
                string postData = string.Empty;

                foreach (var item in dic)
                {
                    if (item.Key.Equals("sign"))
                    {
                        dic[item.Key] = UrlEncodeInterface(item.Value);
                        postData = postData + $"{item.Key}={dic[item.Key]}";
                    }
                    else
                    {
                        dic[item.Key] = UrlEncodeInterface(item.Value);
                        postData = postData + $"{item.Key}={dic[item.Key]}&";
                    }
                }
                //Log.Console($"OnWebRequestPost_Pay:  {postData}");
                //Log.Warning($"OnWebRequestPost_Pay:  {postData}");

                HttpClient httpClient = new HttpClient();
                httpClient.Timeout = TimeSpan.FromMinutes(100);
                HttpContent httpContent = new StringContent(postData);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                HttpResponseMessage response =  httpClient.PostAsync(url, httpContent).Result;
                response.EnsureSuccessStatusCode();//用来抛异常的
                result =  response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                Log.Info($"Exception ex: {ex}");
                return "";
            }
            return result;//读取微信返回的数据
        }
#else

        public static string OnWebRequestPost_TikTokLogin(string url, Dictionary<string, string> dic)
        {
            string result = "";
            try
            {
                string url_access_token = Uri.EscapeDataString(dic["access_token"]);
                string url_app_id = Uri.EscapeDataString(dic["app_id"]);
                string url_ts = Uri.EscapeDataString(dic["ts"]);
                string url_sign = Uri.EscapeDataString(dic["sign"]);

                string postData = $"access_token={url_access_token}&app_id={url_app_id}&ts={url_ts}&sign={url_sign}";

                HttpClient httpClient = new HttpClient();
                httpClient.Timeout = TimeSpan.FromMinutes(100);
                HttpContent httpContent = new StringContent(postData);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;
                response.EnsureSuccessStatusCode();//用来抛异常的
                result = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                Log.Info($"Exception ex: {ex}");
                return "";
            }
            return result;//读取微信返回的数据
        }
#endif

        public static string UrlEncode_1(string str)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byStr = Encoding.UTF8.GetBytes(str); //默认是System.Text.Encoding.Default.GetBytes(str)
            for (int i = 0; i < byStr.Length; i++)
            {
                sb.Append(@"%" + Convert.ToString(byStr[i], 16));
            }

            return (sb.ToString());
        }

        //计算签名的时候不需要对参数进行urlencode处理（"application/x-www-form-urlencoded"编码），但是发送请求的时候需要进行urlencode处理
        //sign参数不参与签名，其他字段都会参与验签
        //urlencode处理时，不要对sign重复编码

        //POST http://www.xxx.com HTTP/1.1
        //Content-Type: application/x-www-form-urlencoded;charset=utf-8
        //access_token=q3fafa33sHFU%2BV9h32h0v8weVEH%2F04hgsrHFHOHNNQOBC9fnwejasubw%3D%3D&app_id=1234&ts=1555912969&sign=sTFH83DV%2BVamgr6SRsC%2FNNjw0%2BQ%3D

        public static string OnWebRequestPost_1(string url, Dictionary<string, string> dic)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Clear();
                foreach (var kv in dic)
                {
                    httpClient.DefaultRequestHeaders.Add(kv.Key, kv.Value);
                }
                HttpContent httpContent = new StringContent("");
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

                HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;
                string statusCode = response.StatusCode.ToString();
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    return result;
                }
                else
                {
                    return statusCode;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return "";
            }
        }

        public static async ETTask<string> HttpClientDoGet(string uri, string appcode,  Dictionary<string, string> keyValuePairs)
        {
            string paramss = string.Empty;
            foreach (var item in keyValuePairs)
            {
                paramss += $"{item.Key}={item.Value}&";
            }
            paramss = paramss.Substring(0, paramss.Length - 1);
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.None };

            using (var httpclient = new HttpClient(handler))
            {
                httpclient.BaseAddress = new Uri(uri);
                httpclient.DefaultRequestHeaders.Accept.Clear();
                httpclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpclient.DefaultRequestHeaders.Add("Authorization", appcode);

                HttpResponseMessage response = await httpclient.GetAsync($"?{paramss}");

                if (response.IsSuccessStatusCode)
                {
                    Stream myResponseStream = await response.Content.ReadAsStreamAsync();
                    StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                    string retString = myStreamReader.ReadToEnd();
                    myStreamReader.Close();
                    myResponseStream.Close();
                    return retString;
                }
                return string.Empty;
            }
        }

    }
}
