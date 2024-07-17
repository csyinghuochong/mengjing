using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{
    /// <summary>
    /// 战场召唤记录
    /// </summary>
    [MessageHandler(SceneType.Map)]
    public class C2M_BattleSummonRecordHandler : MessageLocationHandler<Unit, C2M_BattleSummonRecord, M2C_BattleSummonRecord>
    {
        protected override async ETTask Run(Unit unit, C2M_BattleSummonRecord request, M2C_BattleSummonRecord response)
        {
            AttackRecordComponent attackRecordComponent = unit.GetComponent<AttackRecordComponent>();
            List<BattleSummonInfo> BattleSummonList = attackRecordComponent.BattleSummonList;

            int sceneid = unit.Scene().GetComponent<MapComponent>().SceneId;
            //默认给个冷却时间
            List<BattleSummonConfig> battleSummonInfos = BattleSummonConfigCategory.Instance.GetAll().Values.ToList();

            if (BattleSummonList.Count == 0)
            {
                for (int i = 0; i < battleSummonInfos.Count; i++)
                {
                    if (battleSummonInfos[i].SceneId != sceneid)
                    {
                        continue;
                    }

                    BattleSummonInfo BattleSummonInfo = BattleSummonInfo.Create();
                    BattleSummonInfo.SummonId = battleSummonInfos[i].Id;
                    BattleSummonInfo.SummonTime = unit.Scene().GetComponent<BattleDungeonComponent>().BattleOpenTime;
                    BattleSummonInfo.SummonNumber = 0;
                    BattleSummonList.Add(BattleSummonInfo);
                }
            }

            response.BattleSummonList .AddRange(BattleSummonList); 
            await ETTask.CompletedTask;
        }
    }
}
