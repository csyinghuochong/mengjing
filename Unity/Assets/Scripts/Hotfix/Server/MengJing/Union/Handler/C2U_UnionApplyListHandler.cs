using System.Collections.Generic;

namespace ET.Server
{

    [MessageHandler(SceneType.Union)]
    public class C2U_UnionApplyListHandler : MessageHandler<Scene, C2U_UnionApplyListRequest, U2C_UnionApplyListResponse>
    {

        protected override async ETTask Run(Scene scene, C2U_UnionApplyListRequest request, U2C_UnionApplyListResponse response)
        {
            DBUnionInfo dBUnionInfo = await UnitCacheHelper.GetComponent<DBUnionInfo>(scene.Root(), request.UnionId);

            List<UnionPlayerInfo> unionPlayers = new List<UnionPlayerInfo>();
            for(int i = dBUnionInfo.UnionInfo.ApplyList.Count - 1; i >= 0; i--)
            {
                //判断玩家是否已经有家族了
                NumericComponentS numericComponent_0 = await UnitCacheHelper.GetComponentCache<NumericComponentS>(scene.Root(), dBUnionInfo.UnionInfo.ApplyList[i]);
                if (numericComponent_0 == null ||  numericComponent_0.GetAsLong(NumericType.UnionId_0) > 0)
                {
                    dBUnionInfo.UnionInfo.ApplyList.RemoveAt(i);
                    continue;
                }
                
                UserInfoComponentS userInfoComponent = await UnitCacheHelper.GetComponentCache<UserInfoComponentS>(scene.Root(), dBUnionInfo.UnionInfo.ApplyList[i]);
                UnionPlayerInfo UnionPlayerInfo = UnionPlayerInfo.Create();
                UnionPlayerInfo.PlayerLevel = userInfoComponent.UserInfo.Lv;
                UnionPlayerInfo.PlayerName = userInfoComponent.UserInfo.Name;
                UnionPlayerInfo.Combat = userInfoComponent.UserInfo.Combat;
                UnionPlayerInfo.UserID = userInfoComponent.UserInfo.UserId;
                UnionPlayerInfo.Occ = userInfoComponent.UserInfo.Occ;
                UnionPlayerInfo.OccTwo = userInfoComponent.UserInfo.OccTwo;
                unionPlayers.Add( UnionPlayerInfo);
            }

            response.UnionPlayerList = unionPlayers;
        }
    }
}
