using System;

namespace ET.Server
{
    [MessageHandler(SceneType.JiaYuan)]
    public class M2J_JiaYuanOperateHandler : MessageHandler<Scene, M2J_JiaYuanOperateRequest, J2M_JiaYuanOperateResponse>
    {
        protected override async ETTask Run(Scene scene, M2J_JiaYuanOperateRequest request, J2M_JiaYuanOperateResponse response)
        {
            JiaYuanComponentS jiaYuanComponent =
                    await UnitCacheHelper.GetComponentCache<JiaYuanComponentS>(scene.Root(), request.JiaYuanOperate.MasterId);
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
                    jiaYuanRecord.PlayerId = jiaYuanOperate.UnitId;
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
                    jiaYuanComponent.OnRemoveUnit(jiaYuanOperate.UnitId);
                    JiaYuanRecord = JiaYuanRecord.Create();
                    JiaYuanRecord.OperateType = JiaYuanOperateType.Pick;
                    JiaYuanRecord.OperateId = jiaYuanOperate.OperateId;
                    JiaYuanRecord.PlayerName = jiaYuanOperate.PlayerName;
                    JiaYuanRecord.Time = TimeHelper.ServerNow();
                    jiaYuanComponent.AddJiaYuanRecord(JiaYuanRecord);
                    break;
            }

            await  UnitCacheHelper.SaveComponentCache( scene.Root(), jiaYuanComponent );
        }
    }
}
