namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class J2M_JiaYuanOperateHandler : MessageHandler<Unit, J2M_JiaYuanOperateRequest, M2J_JiaYuanOperateResponse>
    {
        protected override async ETTask Run(Unit unit, J2M_JiaYuanOperateRequest request, M2J_JiaYuanOperateResponse response)
        {
            JiaYuanComponentS jiaYuanComponent = unit.GetComponent<JiaYuanComponentS>();
            JiaYuanOperate jiaYuanOperate = request.JiaYuanOperate;
            switch (jiaYuanOperate.OperateType)
            {
                case JiaYuanOperateType.Visit:
                    JiaYuanRecord JiaYuanRecord = JiaYuanRecord.Create();
                    JiaYuanRecord.OperateType = JiaYuanOperateType.Visit;
                    JiaYuanRecord.OperateId = 0;
                    JiaYuanRecord.PlayerName = jiaYuanOperate.PlayerName;
                    JiaYuanRecord.Time = TimeHelper.ServerNow();
                    jiaYuanComponent.AddJiaYuanRecord( JiaYuanRecord);
                    break;
                case JiaYuanOperateType.GatherPlant:
                    JiaYuanPlant jiaYuanPlan = jiaYuanComponent.GetJiaYuanPlant(jiaYuanOperate.UnitId);
                    if (jiaYuanPlan == null)
                    {
                        return;
                    }
                    jiaYuanPlan.StealNumber += 1;
                    jiaYuanPlan.GatherNumber += 1;
                    jiaYuanPlan.GatherLastTime = TimeHelper.ServerNow();
                    JiaYuanRecord jiaYuanRecord = JiaYuanRecord.Create();
                    jiaYuanRecord.OperateType = JiaYuanOperateType.GatherPlant;
                    jiaYuanRecord.OperateId = jiaYuanPlan.ItemId;
                    jiaYuanRecord.PlayerName = jiaYuanOperate.PlayerName;
                    jiaYuanRecord.Time = TimeHelper.ServerNow();
                    jiaYuanRecord.PlayerId = jiaYuanOperate.PlayerId;
                    jiaYuanComponent.AddJiaYuanRecord(jiaYuanRecord);
                    break;
                case JiaYuanOperateType.GatherPasture:
                    JiaYuanPastures jiaYuanPasture = jiaYuanComponent.GetJiaYuanPastures(jiaYuanOperate.UnitId);
                    if (jiaYuanPasture == null)
                    {
                         return;
                    }
                    jiaYuanPasture.StealNumber += 1;
                    jiaYuanPasture.GatherNumber += 1;
                    jiaYuanPasture.GatherLastTime = TimeHelper.ServerNow();
                    JiaYuanRecord = JiaYuanRecord.Create();
                    JiaYuanRecord.OperateType = JiaYuanOperateType.GatherPasture;
                    JiaYuanRecord.OperateId = jiaYuanPasture.ConfigId;
                    JiaYuanRecord.PlayerName = jiaYuanOperate.PlayerName;
                    JiaYuanRecord.Time = TimeHelper.ServerNow();
                    jiaYuanComponent.AddJiaYuanRecord(JiaYuanRecord);
                    break;
                case JiaYuanOperateType.Pick:
                    unit.GetComponent<JiaYuanComponentS>().OnRemoveUnit(jiaYuanOperate.UnitId);
                    JiaYuanRecord = JiaYuanRecord.Create();
                    JiaYuanRecord.OperateType = JiaYuanOperateType.Pick;
                    JiaYuanRecord.OperateId = jiaYuanOperate.OperateId;
                    JiaYuanRecord.PlayerName = jiaYuanOperate.PlayerName;
                    JiaYuanRecord.Time = TimeHelper.ServerNow();
                    jiaYuanComponent.AddJiaYuanRecord(JiaYuanRecord);
                    break;
            }

            await  UnitCacheHelper.SaveComponentCache( unit.Root(), jiaYuanComponent );
        }
    }
}
