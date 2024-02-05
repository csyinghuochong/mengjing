using System;
using System.Collections.Generic;

namespace ET.Server
{

    [FriendOf(typeof(DBCenterAccountInfo))]
    [FriendOf(typeof(FangChenMiComponent))]
    [MessageHandler(SceneType.AccountCenter)]
    public class A2Center_RegisterAccountHandler : MessageHandler<Scene, A2Center_RegisterAccount, Center2A_RegisterAccount>
    {
        protected override async ETTask Run(Scene scene, A2Center_RegisterAccount request, Center2A_RegisterAccount response)
        {

            using (await scene.GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Register, request.AccountName.GetHashCode()))
            {
                DBComponent dBComponent = DBManagerComponent.Instance.GetZoneDB(scene.Zone());
                List<DBCenterAccountInfo> result = await dBComponent.Query<DBCenterAccountInfo>(scene.Zone(), _account => _account.Account == request.AccountName);

                //如果查询数据不为空,表示当前账号已经被注册
                if (result.Count > 0)
                {
                    response.Message = result[0].Id.ToString();
                    return;
                }

                //创建一条数据库信息,创建账号信息
                DBCenterAccountInfo newAccount = scene.AddChild<DBCenterAccountInfo>();
                newAccount.Account = request.AccountName;
                newAccount.Password = request.Password;
                newAccount.PlayerInfo = new PlayerInfo();

                //抖音账户直接实名
                if (request.LoginType == LoginTypeEnum.TikTok && request.age_type > 0)
                {
                    DateTime dateTime = TimeInfo.Instance.ToDateTime(TimeHelper.ServerNow());
                    int year = dateTime.Year - request.age_type;
                    newAccount.PlayerInfo.Name = "抖音用户";
                    newAccount.PlayerInfo.RealName = 1;
                    newAccount.PlayerInfo.IdCardNo = string.Empty;
                }
                if (newAccount.PlayerInfo.RealName == 0)
                {
                    newAccount.PlayerInfo.Name = "测试";
                    newAccount.PlayerInfo.RealName = 1;
                    newAccount.PlayerInfo.IdCardNo = "429001198010012996";
                }

                //Log.Warning($"注册三方账号: {MongoHelper.ToJson(newAccount)}");
                Log.Warning($"Save<DBCenterAccountInfo>222: {scene.Zone()}");
                await dBComponent.Save(scene.Zone(), newAccount);
                newAccount.Dispose();
                response.AccountId = newAccount.Id;
            }
        }
    }
}
