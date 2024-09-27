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
                RolePetInfo rolePetInfo = petComponentS.GetPetInfo(petComponentS.PetFightList[i]);

                if (rolePetInfo == null)
                {
                    continue;
                }

                Unit petunit = unit.GetParent<UnitComponent>().Get(rolePetInfo.Id);

                if (petunit == null)
                {
                    continue;
                }

                if (request.PetFightIndex - 1 == i)
                {
                    petunit.GetComponent<AIComponent>().Stop_2();
                    Log.Console($"切换到宠物:  {petunit.Id}");
                }
                else
                {
                    petunit.GetComponent<AIComponent>().Begin();
                }
            }

            //主控切换到玩家。则停止玩家托管
            //主动切换到宠物。则停止该宠物的AI.  
            if (request.PetFightIndex == 0)
            {
                unit.GetComponent<AIComponent>().Stop_2();
                Function_Fight.UnitUpdateProperty_Base(unit, true, true); // 重置速度
            }
            else
            {
                unit.GetComponent<AIComponent>().InitHero(unit);
                unit.GetComponent<AIComponent>().Begin();
            }

            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.PetFightIndex, request.PetFightIndex);

            await ETTask.CompletedTask;
        }
    }
}