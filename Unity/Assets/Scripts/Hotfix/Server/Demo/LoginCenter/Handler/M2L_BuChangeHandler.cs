using System.Collections.Generic;

namespace ET.Server
{

    [MessageHandler(SceneType.LoginCenter)]
    public class M2L_BuChangeHandler : MessageHandler<Scene, M2L_BuChangeRequest, L2M_BuChangeResponse>
    {

        protected override async ETTask Run(Scene scene, M2L_BuChangeRequest request, L2M_BuChangeResponse response)
        {
            Log.Warning($"M2Center_BuChangeRequest:{request.AccountId}");
            DBManagerComponent dbManagerComponent = scene.Root().GetComponent<DBManagerComponent>();
            DBComponent dbComponent = dbManagerComponent.GetZoneDB( scene.Zone() );
            
            List<DBCenterAccountInfo> centerAccountInfoList = await dbComponent.Query<DBCenterAccountInfo>(scene.Zone(), d => d.Id == request.AccountId);
            PlayerInfo playerInfo = centerAccountInfoList[0].PlayerInfo;

            //指定某个角色
            if (request.BuChangId > 0)
            {
                for (int i = 0; i < playerInfo.RechargeInfos.Count; i++)
                {
                    RechargeInfo rechargeInfo = playerInfo.RechargeInfos[i];
                    if (rechargeInfo.UnitId == request.BuChangId)
                    {
                        response.BuChangRecharge += rechargeInfo.Amount;
                        response.BuChangDiamond += ConfigHelper.GetDiamondNumber(rechargeInfo.Amount);
                    }
                }
                playerInfo.DeleteUserList.Clear();
            }
            else
            {
                KeyValuePairInt keyValuePairInt = BuChangHelper.GetBuChangRecharge(playerInfo);
                response.BuChangRecharge = keyValuePairInt.KeyId;
                response.BuChangDiamond = (int)keyValuePairInt.Value;
                playerInfo.BuChangZone.Add(scene.Zone());
            }

            dbComponent.Save<DBCenterAccountInfo>(scene.Zone(), centerAccountInfoList[0]).Coroutine();
            response.PlayerInfo = playerInfo;

            await ETTask.CompletedTask;
        }
    }
}
