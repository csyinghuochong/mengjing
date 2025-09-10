using System;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Runtime.ConstrainedExecution;

namespace ET.Server
{
    
    [EntitySystemOf(typeof(HttpComponent))]
    [FriendOf(typeof(HttpComponent))]
    public static partial class HttpComponentSystem
    {

        [EntitySystem]
        private static void Awake(this HttpComponent self, string address)
        {
            //try
            //{

            //    string absolutePath = @"D:\mycert.pfx";
            //    string password = "tcg19851228";
            //    X509Certificate2 serverCert = X509Certificate2Helper.LoadCertificateWithRetry(absolutePath, password);
            //    Console.WriteLine($"成功加载证书: {serverCert.Subject}");
            //    var domainInfo = X509Certificate2Helper.GetCertificateDomains(serverCert);
            //    // 打印结果
            //    Console.WriteLine($"证书主题名称 (CN): {domainInfo.CommonName}");
            //    Console.WriteLine("主题备用名称 (SANs):");
            //    foreach (var san in domainInfo.SubjectAlternativeNames)
            //    {
            //        Console.WriteLine($"  - {san}");
            //    }

            //    // 验证域名是否匹配
            //    string targetDomain = "yourdomain.com";
            //    bool domainMatch = domainInfo.CommonName.Equals(targetDomain, StringComparison.OrdinalIgnoreCase) ||
            //                      domainInfo.SubjectAlternativeNames.Contains(targetDomain, StringComparer.OrdinalIgnoreCase);

            //    Console.WriteLine($"证书是否匹配 '{targetDomain}': {domainMatch}");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}


            try
            {
                self.Listener = new HttpListener();
                Console.WriteLine($"HttpComponent: Awake");
                foreach (string s in address.Split(';'))
                {
                    if (s.Trim() == "")
                    {
                        continue;
                    }
                    Console.WriteLine($"HttpComponent: {s}  ");

                    self.Listener.Prefixes.Add(s);
                }

                self.Listener.Start();

                self.Accept().Coroutine();
            }
            catch (HttpListenerException e)
            {
                throw new Exception($"请先在cmd中运行: netsh http add urlacl url=http://*:你的address中的端口/ user=Everyone， address: {address}", e);
            }
        }

        [EntitySystem]
        private static void Destroy(this HttpComponent self)
        {
            self.Listener.Stop();
            self.Listener.Close();
        }

        private static async ETTask Accept(this HttpComponent self)
        {
            long instanceId = self.InstanceId;
            while (self.InstanceId == instanceId)
            {
                try
                {
                    HttpListenerContext context = await self.Listener.GetContextAsync();
                    self.Handle(context).Coroutine();
                }
                catch (ObjectDisposedException)
                {
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
            }
        }

        private static async ETTask Handle(this HttpComponent self, HttpListenerContext context)
        {
            try
            {
                IHttpHandler handler = HttpDispatcher.Instance.Get(self.IScene.SceneType, context.Request.Url.AbsolutePath);
                await handler.Handle(self.Scene(), context);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            context.Request.InputStream.Dispose();
            context.Response.OutputStream.Dispose();
        }
    }


    public static class X509Certificate2Helper
    {

        static string GetCommonName(string subject)
        {
            return subject?
                .Split(',')
                .Select(part => part.Trim())
                .FirstOrDefault(part => part.StartsWith("CN=", StringComparison.OrdinalIgnoreCase))?
                .Substring(3);
        }

        // 从证书中提取 SAN 域名
        static string[] GetSanDomains(X509Certificate2 cert)
        {
            // 查找 SAN 扩展 (OID 2.5.29.17)
            var sanExtension = cert.Extensions.OfType<X509Extension>()
                .FirstOrDefault(e => e.Oid?.Value == "2.5.29.17");

            if (sanExtension == null) return Array.Empty<string>();

            // 解析 SAN 扩展内容
            return new AsnEncodedData(sanExtension.Oid, sanExtension.RawData)
                .Format(false) // 获取可读字符串
                .Split(new[] { '\n', '\r', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(line => line.StartsWith("DNS Name="))
                .Select(line => line.Replace("DNS Name=", "").Trim())
                .ToArray();
        }


        public static X509Certificate2 LoadCertificateWithRetry(string path, string password)
        {
            // 尝试不同加载方法
            try
            {
                // 方法1: 使用用户密钥集
                return new X509Certificate2(path, password,
                    X509KeyStorageFlags.UserKeySet |
                    X509KeyStorageFlags.PersistKeySet |
                    X509KeyStorageFlags.Exportable);
            }
            catch (Exception)
            {
                try
                {
                    // 方法2: 使用临时密钥集（内存中）
                    return new X509Certificate2(path, password,
                        X509KeyStorageFlags.EphemeralKeySet);
                }
                catch (Exception ex)
                {
                    // 方法3: 作为字节数组加载
                    Console.WriteLine(ex);
                    byte[] certData = File.ReadAllBytes(path);
                    return new X509Certificate2(certData, password,
                        X509KeyStorageFlags.UserKeySet |
                        X509KeyStorageFlags.Exportable);
                }
            }
        }

        public static CertificateDomainInfo GetCertificateDomains(X509Certificate2 cert)
        {
            var info = new CertificateDomainInfo();

            // 获取主题中的CN（Common Name）
            info.CommonName = GetCommonNameFromSubject(cert.Subject);

            // 获取SANs（主题备用名称）
            var sanExtension = cert.Extensions["2.5.29.17"] as X509SubjectAlternativeNameExtension;
            if (sanExtension != null)
            {
                info.SubjectAlternativeNames.AddRange(ParseSubjectAlternativeNames(sanExtension));
            }

            return info;
        }

        private static string GetCommonNameFromSubject(string subject)
        {
            // 主题格式示例: "CN=yourdomain.com, O=Your Organization, L=City, C=Country"
            var parts = subject.Split(',');
            foreach (var part in parts)
            {
                var trimmed = part.Trim();
                if (trimmed.StartsWith("CN=", StringComparison.OrdinalIgnoreCase))
                {
                    return trimmed.Substring(3);
                }
            }
            return string.Empty;
        }

        private static IEnumerable<string> ParseSubjectAlternativeNames(X509SubjectAlternativeNameExtension sanExtension)
        {
            var asnData = sanExtension.RawData;
            // SAN扩展的OID是2.5.29.17

            // 使用AsnReader解析扩展数据（需要.NET Core 3.0+）
            var reader = new AsnReader(asnData, AsnEncodingRules.DER);
            var sequenceReader = reader.ReadSequence();

            while (sequenceReader.HasData)
            {
                var tag = sequenceReader.PeekTag();

                if (tag.TagClass == TagClass.ContextSpecific)
                {
                    switch (tag.TagValue)
                    {
                        case 2: // DNS名称
                                // 修复后（正确）：
                            Asn1Tag dnsTag = new Asn1Tag(tag.TagClass, tag.TagValue);
                            string dnsName = sequenceReader.ReadCharacterString(UniversalTagNumber.IA5String, dnsTag);
                            yield return dnsName;
                            break;
                        case 7: // IP地址（跳过）
                            sequenceReader.ReadEncodedValue();
                            break;
                        default:
                            sequenceReader.ReadEncodedValue();
                            break;
                    }
                }
                else
                {
                    sequenceReader.ReadEncodedValue();
                }
            }
        }

        // 兼容旧版.NET Framework的方法
        private static IEnumerable<string> ParseSubjectAlternativeNamesLegacy(X509SubjectAlternativeNameExtension sanExtension)
        {
            var asnData = sanExtension.Format(false);

            // 示例格式: "DNS Name=example.com, DNS Name=www.example.com"
            var entries = asnData.Split(new[] { '\r', '\n', ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var entry in entries)
            {
                var trimmed = entry.Trim();
                if (trimmed.StartsWith("DNS Name=", StringComparison.OrdinalIgnoreCase))
                {
                    yield return trimmed.Substring(9);
                }
            }
        }

    }
}
