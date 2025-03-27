using System;
using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{

    [EntitySystemOf(typeof(ReChargeIOSComponent))]
    [FriendOf(typeof(ReChargeIOSComponent))]
    public static partial class ReChargeIOSComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.ReChargeIOSComponent self)
        {
            self.PayLoadList.Clear();
        }
        [EntitySystem]
        private static void Destroy(this ET.Server.ReChargeIOSComponent self)
        {

        }
        
         public static async ETTask<int> OnIOSPayVerify(this ReChargeIOSComponent self, M2R_RechargeRequest request)
         {
             Log.Warning($"支付订单[IOS]回调执行 " + "id:" + request.UnitId);
             string verifyURL = string.Empty;
             if (request.UnitId == 2025124307608338432 )   //先锋一区 \敖安塔
             {
                 verifyURL = "https://sandbox.itunes.apple.com/verifyReceipt";
             }
             else
             {
                 verifyURL = "https://buy.itunes.apple.com/verifyReceipt";
             }

             string payLoad = request.payMessage;
             if (self.PayLoadList.Contains(payLoad))
             {
                 return ErrorCode.ERR_IOSVerify;
             }

             string sendStr = "{\"receipt-data\":\"" + payLoad + "\"}";

             string postReturnStr = await HttpHelper.GetIosPayParameter(verifyURL, sendStr);

             Log.Debug("##request.payMessage:" + request.payMessage);
             Log.Debug("#######postReturnStr:" + postReturnStr);

             Root rt = null;
             //Log.Warning($"IOS充值回调11 {postReturnStr}");
             try
             {
                 rt = MongoHelper.FromJson<Root>(postReturnStr);
             }
             catch (Exception ex)
             {
                 Log.Warning($"IOS充值回调11_1 {ex.ToString()}");
                 return ErrorCode.ERR_IOSVerify;
             }
             Log.Warning($"IOS充值回调22 {rt.status}");
             //交易失败，直接返回
             if (rt.status != 0)
             {
                 Log.Warning($"IOS充值回调ERROR1 {rt.status}");
                 return ErrorCode.ERR_IOSVerify;
             }

             if (rt.receipt.in_app == null || rt.receipt.in_app.Count == 0)
             {
                 Log.Warning($"IOS充值回调ERROR2 ");
                 return ErrorCode.ERR_IOSVerify;
             }

             //封号处理 使用IAPFree工具
             if (rt.receipt.in_app[0].product_id == "com.zeptolab.ctrbonus.superpower1")
             {
                 Log.Warning($"IOS充值回调ERROR3 ");
                 return ErrorCode.ERR_IOSVerify;
             }

             if (!string.IsNullOrEmpty(rt.receipt.bundle_id) && rt.receipt.bundle_id != "com.guangying.weijing2")
             {
                 Log.Warning($"IOS充值回调ERROR4");
                 return ErrorCode.ERR_IOSVerify;
             }

             string dingDanTime = rt.receipt.purchase_date_ms;
             //判断时间
             List<InApp> in_app_list = rt.receipt.in_app;
             Log.Warning($"IOS充值回调[inapp]: {in_app_list.Count}");
             for (int i = 0; i < in_app_list.Count; i++)
             {
                 InApp inApp = in_app_list[i];   
                 string product_id = inApp.product_id;

                 if (product_id.Contains("SG"))
                 {
                     Log.Warning($"IOS充值回调ERROR5 : SG");
                     continue;
                 }

                 int rechargeNumber = 0;

                 if (product_id.Equals("testpay1"))
                 {
                     rechargeNumber = 1;
                 }
                 else
                 {
                     if (!product_id.Contains("WJ"))
                     {
                         Log.Warning($"IOS充值回调ERROR6 : !WJ");
                         continue;
                     }

                     //testpay1
                     product_id = product_id.Substring(0, product_id.Length - 2);

                     try
                     {
                         rechargeNumber = int.Parse(product_id);
                     }
                     catch (Exception ex)
                     {
                         Log.Warning(ex.ToString());
                         continue;
                     }
                 }

                 self.PayLoadList.Add(payLoad);
                 if (self.PayLoadList.Count >= 100)
                 {
                     self.PayLoadList.RemoveAt(0);
                 }
                 string serverName = ServerHelper.GetServerItemByZone(VersionMode.Beta, request.Zone).ServerName;
                 Log.Warning($"支付订单[IOS]支付成功: 区：{serverName}    玩家名字：{request.UnitName}     充值额度：{rechargeNumber}");
                 Log.Console($"支付订单[IOS]支付成功: 区：{serverName}    玩家名字：{request.UnitName}     充值额度：{rechargeNumber}  时间:{TimeHelper.DateTimeNow().ToString()}");
                 //await RechargeHelp.OnPaySucessToGate(request.Zone, request.UnitId, rechargeNumber, postReturnStr, PayTypeEnum.IOSPay);
             }

             return ErrorCode.ERR_Success;
         }
    }

}