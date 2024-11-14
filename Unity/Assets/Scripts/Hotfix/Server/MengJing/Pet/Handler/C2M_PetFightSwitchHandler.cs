using System;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetFightSwitchHandler : MessageLocationHandler<Unit, C2M_PetFightSwitch, M2C_PetFightSwitch>
    {
        protected override async ETTask Run(Unit unit, C2M_PetFightSwitch request, M2C_PetFightSwitch response)
        {
            PetComponentS petComponentS = unit.GetComponent<PetComponentS>();
            if (request.PetFightIndex < 0 || request.PetFightIndex > petComponentS.PetFightList.Count)
            {
                return;
            }

            for (int i = 0; i < petComponentS.PetFightList.Count; i++)
            {
                RolePetInfo rolePetInfo = petComponentS.GetPetInfo(petComponentS.PetFightList[i].PetId);

                if (rolePetInfo == null)
                {
                    continue;
                }

                Unit petunit = unit.GetParent<UnitComponent>().Get(rolePetInfo.Id);

                if (petunit == null && request.PetFightIndex - 1 == i)
                {
                    response.Error = ErrorCode.ERR_Pet_Dead;
                    return;
                }
                
                if (petunit == null)
                {
                    continue;
                }

                if (request.PetFightIndex - 1 == i)
                {
                    // 切换到宠物
                    petunit.GetComponent<AIComponent>().Stop_2();
                }
                else
                {
                    petunit.GetComponent<AIComponent>().Begin();
                }
            }

            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.PetFightIndex, request.PetFightIndex);
            

            if (request.PetFightIndex == 0)
            {
                unit.GetComponent<AIComponent>().Stop_2();
                unit.GetComponent<BuffManagerComponentS>().BuffRemoveByUnit(0, 97009002);
            }
            else
            {
                unit.GetComponent<AIComponent>().Stop_2();
                unit.GetComponent<AIComponent>().InitHeroTuoGuan(unit);
                unit.GetComponent<AIComponent>().Begin();
                BuffData buffData_2 = new BuffData();
                buffData_2.SkillId = 67000278;
                buffData_2.BuffId = 97009002; 
                unit.GetComponent<BuffManagerComponentS>().BuffFactory(buffData_2, unit, null);
            }

            await ETTask.CompletedTask;
        }
    }
}