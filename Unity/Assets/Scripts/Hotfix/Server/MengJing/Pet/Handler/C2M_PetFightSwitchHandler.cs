using System;
using Unity.Mathematics;
using System.Collections.Generic;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetFightSwitchHandler : MessageLocationHandler<Unit, C2M_PetFightSwitch, M2C_PetFightSwitch>
    {
        protected override async ETTask Run(Unit unit, C2M_PetFightSwitch request, M2C_PetFightSwitch response)
        {
            PetComponentS petComponentS = unit.GetComponent<PetComponentS>();
            List<PetBarInfo> PetFightList = petComponentS.GetNowPetFightList();
            if (request.PetFightIndex < 0 || request.PetFightIndex > PetFightList.Count)
            {
                return;
            }
            int lastPetFightIndex = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.PetFightIndex);
            if (lastPetFightIndex == request.PetFightIndex)
            {
                return;
            }

            //切换宠物新模式：
            //切换为宠物模式 更改主角的模型和技能为宠物的。  移除宠物
            //切换为主角模式 重置主角的模型和技能，  添加宠物。。。。
            //宠物出生便携带无敌wuff。 无须改动。。
            UnitComponent unitComponent = unit.GetParent<UnitComponent>();
            int petconfigid = 0;
            string demonName = string.Empty;
              for (int i = 0; i < PetFightList.Count; i++)
            {
                RolePetInfo rolePetInfo = petComponentS.GetPetInfo(PetFightList[i].PetId);

                if (rolePetInfo == null)
                {
                    continue;
                }

                Unit petunit = unitComponent.Get(rolePetInfo.Id);
            
                if (petunit == null && request.PetFightIndex - 1 == i)
                {
                    response.Error = ErrorCode.ERR_Pet_Dead;
                    return;
                }

                if (request.PetFightIndex - 1 == i)
                {
                    if (petunit == null)
                    {
                        continue;
                    }
                    
                    // 切换到宠物
                    unit.GetComponent<MoveComponent>().Stop(true);
                    unit.Position = petunit.Position;
                    unit.Stop(-3);
                    
                    unitComponent.Remove(petunit.Id);
                    petconfigid = rolePetInfo.ConfigId;
                    demonName = rolePetInfo.PetName;
                    //客户端自己修改模型 和 技能。。。。
                }
                if(lastPetFightIndex - 1 == i)
                {
                    //重新创建之前的宠物
                    petunit =  UnitFactory.CreatePet(unit, rolePetInfo);
                    BuffData buffData_2 = new BuffData();
                    buffData_2.SkillId = 67000278;
                    buffData_2.BuffId = ConfigData.PetMianShangBuff; 
                    petunit.GetComponent<BuffManagerComponentS>().BuffFactory(buffData_2, unit, null);
                }
            }

            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.PetFightIndex, request.PetFightIndex);

            M2C_PetFightSwitchMessage fightSwitchMessage = M2C_PetFightSwitchMessage.Create();
            fightSwitchMessage.UnitId = unit.Id;
            fightSwitchMessage.PetConfigId = petconfigid; // > 0变身  == 0 回到主角
            fightSwitchMessage.DemonName = demonName;
            MapMessageHelper.Broadcast( unit, fightSwitchMessage );
            await ETTask.CompletedTask;
        }
    }
}