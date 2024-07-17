namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_JiaYuanMysteryListHandler : MessageLocationHandler<Unit, C2M_JiaYuanMysteryListRequest, M2C_JiaYuanMysteryListResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_JiaYuanMysteryListRequest request, M2C_JiaYuanMysteryListResponse response)
        {
            //家园商店
            if (request.NpcID == 30000001)
            {
                response.MysteryItemInfos .AddRange( unit.GetComponent<JiaYuanComponentS>().PlantGoods_7);
            }
            //牧场商店
            if (request.NpcID == 30000013)
            {
                response.MysteryItemInfos .AddRange(unit.GetComponent<JiaYuanComponentS>().JiaYuanStore); 
            }

            unit.GetComponent<JiaYuanComponentS>().NowOpenNpcId = request.NpcID;
            await ETTask.CompletedTask;
        }
    }
}
