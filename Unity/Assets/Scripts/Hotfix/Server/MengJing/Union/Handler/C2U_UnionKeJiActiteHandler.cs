namespace ET.Server
{
    [MessageHandler(SceneType.Union)]
    public class C2U_UnionKeJiActiteHandler : MessageHandler<Scene, C2U_UnionKeJiActiteRequest, U2C_UnionKeJiActiteResponse>
    {
        protected override async ETTask Run(Scene scene, C2U_UnionKeJiActiteRequest request, U2C_UnionKeJiActiteResponse response)
        {
            DBUnionInfo dBUnionInfo = await UnitCacheHelper.GetComponent<DBUnionInfo>(scene.Root(),  request.UnionId);
            if (dBUnionInfo == null)
            {
                response.Error = ErrorCode.ERR_Union_Not_Exist;
                return;
            }

            int keijiId = dBUnionInfo.UnionInfo.UnionKeJiList[request.Position];
            UnionKeJiConfig unionKeJiConfig = UnionKeJiConfigCategory.Instance.Get(keijiId);
            if (unionKeJiConfig.NextID == 0)
            {
                response.Error = ErrorCode.ERR_Union_NotKeJi;
                return;
            }
            if(dBUnionInfo.UnionInfo.UnionGold < unionKeJiConfig.CostUnionGold)
            {
                response.Error = ErrorCode.ERR_GoldNotEnoughError;
                return;
            }

            if (dBUnionInfo.UnionInfo.KeJiActiteTime != 0)
            {
                response.UnionInfo = dBUnionInfo.UnionInfo;
                response.Error = ErrorCode.ERR_Union_HavKeJi;
                return;
            }
            dBUnionInfo.UnionInfo.UnionGold -= unionKeJiConfig.CostUnionGold;
            dBUnionInfo.UnionInfo.KeJiActitePos = request.Position;
            dBUnionInfo.UnionInfo.KeJiActiteTime = TimeHelper.ServerNow();
            response.UnionInfo = dBUnionInfo.UnionInfo;
            UnitCacheHelper.SaveComponent(scene.Root(), dBUnionInfo.Id, dBUnionInfo).Coroutine(); ;
        }
    }
}
