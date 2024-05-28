using System;

namespace ET.Server
{
    [MessageHandler(SceneType.JiaYuan)]
    public class M2M_JiaYuanOperateHandler : MessageHandler<Unit, M2M_JiaYuanOperateMessage>
    {
        protected override async ETTask Run(Unit unit, M2M_JiaYuanOperateMessage message)
        {
            JiaYuanComponentS jiaYuanComponent = unit.GetComponent<JiaYuanComponentS>();
            JiaYuanOperate jiaYuanOperate = message.JiaYuanOperate;
            switch (jiaYuanOperate.OperateType)
            {
                case JiaYuanOperateType.Visit:
                    jiaYuanComponent.AddJiaYuanRecord( new JiaYuanRecord()
                    {
                        OperateType = JiaYuanOperateType.Visit,
                        OperateId = 0,
                        PlayerName = jiaYuanOperate.PlayerName,
                        Time = TimeHelper.ServerNow(),
                    });
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
                    JiaYuanRecord jiaYuanRecord = new JiaYuanRecord()
                    {
                        OperateType = JiaYuanOperateType.GatherPlant,
                        OperateId = jiaYuanPlan.ItemId,
                        PlayerName = jiaYuanOperate.PlayerName,
                        Time = TimeHelper.ServerNow(),
                        PlayerId = jiaYuanOperate.PlayerId,
                    };
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

                    jiaYuanComponent.AddJiaYuanRecord(new JiaYuanRecord()
                    {
                        OperateType = JiaYuanOperateType.GatherPasture,
                        OperateId = jiaYuanPasture.ConfigId,
                        PlayerName = jiaYuanOperate.PlayerName,
                        Time = TimeHelper.ServerNow(),
                    });
                    break;
                case JiaYuanOperateType.Pick:
                    unit.GetComponent<JiaYuanComponentS>().OnRemoveUnit(jiaYuanOperate.UnitId);
                    jiaYuanComponent.AddJiaYuanRecord(new JiaYuanRecord()
                    {
                        OperateType = JiaYuanOperateType.Pick,
                        OperateId = jiaYuanOperate.OperateId,
                        PlayerName = jiaYuanOperate.PlayerName,
                        Time = TimeHelper.ServerNow(),
                    });
                    break;
            }

            await  UnitCacheHelper.SaveComponentCache( unit.Root(), jiaYuanComponent );
        }
    }
}
