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
                //判断玩家是否已经有公会了
                NumericComponentS numericComponent_0 = await UnitCacheHelper.GetComponentCache<NumericComponentS>(scene.Root(), dBUnionInfo.UnionInfo.ApplyList[i]);
                if (numericComponent_0 == null ||  numericComponent_0.GetAsLong(NumericType.UnionId_0) > 0)
                {
                    dBUnionInfo.UnionInfo.ApplyList.RemoveAt(i);
                    continue;
                }
                
                UserInfoComponentS userInfoComponent = await UnitCacheHelper.GetComponentCache<UserInfoComponentS>(scene.Root(), dBUnionInfo.UnionInfo.ApplyList[i]);
                UserInfo unionInfoCache = userInfoComponent.ChildrenDB[0] as UserInfo;
                UnionPlayerInfo UnionPlayerInfo = UnionPlayerInfo.Create();
                UnionPlayerInfo.PlayerLevel = unionInfoCache.Lv;
                UnionPlayerInfo.PlayerName = unionInfoCache.Name;
                UnionPlayerInfo.Combat = unionInfoCache.Combat;
                UnionPlayerInfo.UserID = unionInfoCache.UserId;
                UnionPlayerInfo.Occ = unionInfoCache.Occ;
                UnionPlayerInfo.OccTwo = unionInfoCache.OccTwo;
                unionPlayers.Add( UnionPlayerInfo);
            }

            response.UnionPlayerList = unionPlayers;
        }
    }
}
