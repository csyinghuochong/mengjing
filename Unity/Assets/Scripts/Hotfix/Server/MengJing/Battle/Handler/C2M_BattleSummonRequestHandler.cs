using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    /// <summary>
    /// 战场召唤记录
    /// </summary>
    [MessageHandler(SceneType.Map)]
    public class C2M_BattleSummonRequestHandler : MessageLocationHandler<Unit, C2M_BattleSummonRequest, M2C_BattleSummonResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_BattleSummonRequest request, M2C_BattleSummonResponse response)
        {
            MapComponent mapComponent = unit.Scene().GetComponent<MapComponent>();
            if (mapComponent.MapType != MapTypeEnum.Battle)
            {
                Log.Error($"C2M_BattleSummonRequest.1");
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            int sceneid = mapComponent.SceneId;
            AttackRecordComponent attackRecordComponent = unit.GetComponent<AttackRecordComponent>();
            List<BattleSummonInfo> BattleSummonList = attackRecordComponent.BattleSummonList;

            BattleSummonConfig battleSummonConfig = BattleSummonConfigCategory.Instance.Get(request.SummonId);

            //检测金币
            long costgold = 0;
            long lastsummonTime = 0;
            for (int i = 0; i < BattleSummonList.Count; i++)
            {
                if (BattleSummonList[i].SummonId == request.SummonId)
                {
                    lastsummonTime = BattleSummonList[i].SummonTime;
                }
            }
            if (TimeHelper.ServerNow() - lastsummonTime >= battleSummonConfig.FreeResetTime * TimeHelper.Second)
            {
                costgold = 0;
            }
            else
            {
                costgold = battleSummonConfig.CostGold;
            }

            //判断金币
            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();  
            if(userInfoComponent.UserInfo.Gold < costgold)
            {
                response.Error = ErrorCode.ERR_GoldNotEnoughError;
                return;
            }

            //判断人口上限
            int cursummonnumber = BattleHelper.GetSummonNumber( BattleSummonList );
            if (cursummonnumber + battleSummonConfig.MonsterNumber > int.Parse( GlobalValueConfigCategory.Instance.Get(91).Value ))
            {
                response.Error = ErrorCode.ERR_PeopleNumber;
                return;
            }


            bool have = false;
            for (int i = 0; i < BattleSummonList.Count; i++)
            {
                if (BattleSummonList[i].SummonId == request.SummonId)
                {
                    BattleSummonList[i].SummonNumber++;
                    BattleSummonList[i].SummonTime = TimeHelper.ServerNow();
                    have = true;
                    break;
                }
            }
            
            if (!have)
            {
                BattleSummonInfo BattleSummonInfo = BattleSummonInfo.Create();
                BattleSummonInfo.SummonId = request.SummonId;
                BattleSummonInfo.SummonTime = TimeHelper.ServerNow();
                BattleSummonInfo.SummonNumber = 1;
                BattleSummonList.Add( BattleSummonInfo);
            }

            //发兵
            int camp = unit.GetBattleCamp();
            int monsterid = battleSummonConfig.MonsterIds[camp - 1];
            int monsternum = battleSummonConfig.MonsterNumber;
            SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(sceneid);

            for (int i = 0;i <monsternum; i++)
            {
                float range = 2f;
                //随机坐标
                float ran_x = RandomHelper.RandomNumberFloat(-1 * range, range);
                float ran_z = RandomHelper.RandomNumberFloat(-1 * range, range);
                int startIndex = camp == 1 ? 0 : 3;
                float3 initPosi = new float3(sceneConfig.InitPos[startIndex + 0] * 0.01f + ran_x, sceneConfig.InitPos[startIndex + 1] * 0.01f, sceneConfig.InitPos[startIndex + 2] * 0.01f + ran_z);

                Unit unitMonster = UnitFactory.CreateMonster(unit.Scene(), monsterid, initPosi, new CreateMonsterInfo()
                { Camp = camp });
            }

            response.BattleSummonList .AddRange(BattleSummonList); 
            await ETTask.CompletedTask;
        }
    }

}