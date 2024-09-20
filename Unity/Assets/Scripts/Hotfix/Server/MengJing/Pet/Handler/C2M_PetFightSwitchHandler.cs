using System;

namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetFightSwitchHandler : MessageLocationHandler<Unit, C2M_PetFightSwitch, M2C_PetFightSwitch>
    {
        protected override async ETTask Run(Unit unit, C2M_PetFightSwitch request, M2C_PetFightSwitch response)
        {
            int petfightindex = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.PetFightIndex);
            PetComponentS petComponentS = unit.GetComponent<PetComponentS>();
            if (petfightindex < 0 || petfightindex >= petComponentS.PetFightList.Count)
            {
                return;
            }

            for (int i = 0; i < petComponentS.PetFightList.Count; i++)
            {
                RolePetInfo rolePetInfo = petComponentS.GetPetInfo(petComponentS.PetFightList[petfightindex]);
                Unit petunit = unit.GetParent<UnitComponent>().Get(rolePetInfo.Id);
                
                if ( petfightindex - 1 == i )
                {
                    petunit.GetComponent<AIComponent>().Stop_2();
                    Console.WriteLine($"切换到宠物:  {petunit.Id}");
                }
                else
                {
                    petunit.GetComponent<AIComponent>().Begin();
                }
            }

            if (request.PetFightIndex == 0)
            {
                unit.GetComponent<AIComponent>().Stop_2();   
            }
            else
            {
                unit.GetComponent<AIComponent>().Begin();   
            }

            unit.GetComponent<NumericComponentS>().ApplyValue( NumericType.PetFightIndex, request.PetFightIndex );
           
            await ETTask.CompletedTask;
        }
    }
}