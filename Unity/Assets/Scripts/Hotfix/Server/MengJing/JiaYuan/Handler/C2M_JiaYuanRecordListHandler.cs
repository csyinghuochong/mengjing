namespace ET.Server
{
    [MessageHandler(SceneType.Map)]

    public class C2M_JiaYuanRecordListHandler : MessageLocationHandler<Unit, C2M_JiaYuanRecordListRequest, M2C_JiaYuanRecordListResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_JiaYuanRecordListRequest request, M2C_JiaYuanRecordListResponse response)
        {
            JiaYuanComponentS jiaYuanComponent = unit.GetComponent<JiaYuanComponentS>();
            response.JiaYuanRecordList .AddRange(jiaYuanComponent.JiaYuanRecordList_1); 
            await ETTask.CompletedTask;
        }
    }
}
