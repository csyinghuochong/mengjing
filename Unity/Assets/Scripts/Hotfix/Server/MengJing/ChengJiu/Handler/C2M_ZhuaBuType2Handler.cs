using System;
using System.Collections.Generic;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(ChengJiuComponentS))]
    public class C2M_ZhuaBuType2Handler : MessageLocationHandler<Unit, C2M_ZhuaBuType2Request, M2C_ZhuaBuType2Response>
    {
        protected override async ETTask Run(Unit unit, C2M_ZhuaBuType2Request request, M2C_ZhuaBuType2Response response)
        {
            UserInfoComponentS userInfoComponentS = unit.GetComponent<UserInfoComponentS>();
            if (userInfoComponentS.UserInfo.Vitality < 5)
            {
                response.Error = ErrorCode.ERR_VitalityNotEnoughError;
                return;
            }
            
            Unit zhupuUnit = unit.GetParent<UnitComponent>().Get(request.JingLingId);
            if (zhupuUnit == null)
            {
                return;
            }
            
            NumericComponentS zhuabuNumeric = zhupuUnit.GetComponent<NumericComponentS>();
            if (zhuabuNumeric.GetAsInt(NumericType.ZhuaBuTime) >= 1)
            {
                response.Error = ErrorCode.ERR_ZhuaBuFail;
                return;
            }

            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(zhupuUnit.ConfigId);
            if(monsterConfig.QiYuPetId == 0)
            {
                return;
            }

            if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }

            if (request.ItemId != 0)
            {
                bool costresult =  unit.GetComponent<BagComponentS>().OnCostItemData($"{request.ItemId};1");
                if (costresult == false)
                {
                    response.Error = ErrorCode.ERR_ItemNotEnoughError;
                    return;
                }
            }

            // 捕捉有3种情况，
            // 捕捉成功，
            // 捕捉失败怪物死亡（就是隐藏 并播放特效）
            // 捕捉失败怪物逃跑（怪物随机出现在当前地图的任意一个位置）
          
            int gailv = CommonHelp.GetZhuPuType2_GaiLv(zhupuUnit.ConfigId, request.ItemId, int.Parse(request.OperateType));
             if (RandomHelper.RandFloat01() <= gailv * 0.0001f)
             {
                 response.Message = String.Empty;
                 
                 int babyType = zhuabuNumeric.GetAsInt(NumericType.BaByType);
                 ///此处普通怪物类型0 转换为 3 。。。
                 unit.GetComponent<PetComponentS>().OnAddPet(ItemGetWay.PickItem, monsterConfig.QiYuPetId, 0, 0, babyType == 0? 3: babyType, monsterConfig.Lv);
                 unit.GetParent<UnitComponent>().Remove(request.JingLingId);
             }
            else
            {
                int failType = RandomHelper.RandomNumber(1, 3);
                if (failType >= 1)
                {
                    zhupuUnit.GetComponent<HeroDataComponentS>().OnDead(unit ,true);
                }
                else
                {
                    MapComponent mapComponent = unit.Scene().GetComponent<MapComponent>();
                    if (mapComponent.SceneType == SceneTypeEnum.LocalDungeon)
                    {
                        string[] monsters = SceneConfigHelper.GetLocalDungeonMonsters_2(mapComponent.SceneId).Split('@');
                        int waveId = RandomHelper.RandomNumber(0, monsters.Length);
                        
                        string[] mondels = monsters[waveId].Split(';');
                        string[] position = mondels[1].Split(',');
                        zhupuUnit.Position = new Unity.Mathematics.float3(float.Parse(position[0]), float.Parse(position[1]), float.Parse(position[2]) );
                        zhupuUnit.Stop(-3);
                        zhuabuNumeric.ApplyValue(NumericType.ZhuaBuTime, 1, true);
                    }
                    else
                    {
                        unit.GetParent<UnitComponent>().Remove(request.JingLingId);
                    }
                }
                response.Message = failType.ToString();
            }

            userInfoComponentS.UpdateRoleMoneySub(UserDataType.Vitality, "-5");
            await ETTask.CompletedTask;
        }
    }
}