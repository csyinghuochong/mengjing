using System;
using System.Collections.Generic;
using Unity.Mathematics;

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
            
            Unit unitzhuabu = unit.GetParent<UnitComponent>().Get(request.JingLingId);
            if (unitzhuabu == null)
            {
                return;
            }
            
            NumericComponentS zhuabuNumeric = unitzhuabu.GetComponent<NumericComponentS>();


            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(unitzhuabu.ConfigId);
            if(!PetHelper.IsHaveQiYuPetId( monsterConfig.QiYuPetId) )
            {
                return;
            }

            if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }
            
      
            //2000102
            C2M_SkillCmd cmd = C2M_SkillCmd.Create();
            cmd.SkillID = 80000202;
            cmd.TargetID = request.JingLingId;
            float3 direction = unitzhuabu.Position - unit.Position;
            cmd.TargetAngle=  (int)math.degrees(math.atan2(direction.x, direction.z));
            cmd.TargetDistance = PositionHelper.Distance2D(unitzhuabu.Position,unit.Position);
            unit.GetComponent<SkillManagerComponentS>().OnUseSkill(cmd, false);
            
            bool costresult =  unit.GetComponent<BagComponentS>().OnCostItemData($"{ConfigData.ZhuaBuQiItemId};1");
            request.ItemId = costresult ? ConfigData.ZhuaBuQiItemId : 0;
            // 捕捉有3种情况，
            // 捕捉成功，
            // 捕捉失败怪物死亡（就是隐藏 并播放特效）
            // 捕捉失败怪物逃跑（怪物随机出现在当前地图的任意一个位置）
            int babyType = zhuabuNumeric.GetAsInt(NumericType.BaByType);
             int gailv = CommonHelp.GetZhuPuType2_GaiLv(unitzhuabu.ConfigId,babyType, request.ItemId, int.Parse(request.OperateType));
             if (RandomHelper.RandFloat01() <= gailv * 0.0001f)
             {
                 response.Message = String.Empty;
                
                 
                 ///此处普通怪物类型0  生成宠物的时候转换为 3 以作区分。。。
                 unit.GetComponent<PetComponentS>().OnAddPet(ItemGetWay.PickItem,  PetHelper.GetQiYuPetId(monsterConfig.QiYuPetId, babyType), 0, 0, babyType == 0? 3: babyType, monsterConfig.Lv);
                 unit.GetParent<UnitComponent>().Remove(request.JingLingId);
             }
            else
            {
                int failType = RandomHelper.RandomNumber(1, 3);
                if (failType == 1)
                {
                    unitzhuabu.GetComponent<HeroDataComponentS>().OnDead(unit ,true);
                }
                else
                {
                    MapComponent mapComponent = unit.Scene().GetComponent<MapComponent>();
                    if (mapComponent.MapType == MapTypeEnum.LocalDungeon)
                    {
                        string[] monsters = SceneConfigHelper.GetLocalDungeonMonsters_2(mapComponent.SceneId).Split('@');
                        int waveId = RandomHelper.RandomNumber(0, monsters.Length);
                        
                        string[] mondels = monsters[waveId].Split(';');
                        string[] position = mondels[1].Split(',');
                        unitzhuabu.GetComponent<MoveComponent>().Stop(true);
                        unitzhuabu.GetComponent<AIComponent>().Stop_2();
                        unitzhuabu.Position = new Unity.Mathematics.float3(float.Parse(position[0]), float.Parse(position[1]), float.Parse(position[2]) );
                        unitzhuabu.Stop(-3);
                        unitzhuabu.GetComponent<AIComponent>().Begin();
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