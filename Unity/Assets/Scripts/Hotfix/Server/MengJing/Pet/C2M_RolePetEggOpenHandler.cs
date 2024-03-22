using System;
using System.Collections.Generic;

namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_RolePetEggOpenHandler : MessageLocationHandler<Unit, C2M_RolePetEggOpen, M2C_RolePetEggOpen>
    {
        protected override async ETTask Run(Unit unit, C2M_RolePetEggOpen request, M2C_RolePetEggOpen response)
        {
            PetComponent_S petComponent = unit.GetComponent<PetComponent_S>();
            KeyValuePairInt rolePetEgg = petComponent.RolePetEggs[request.Index];
            if (rolePetEgg.KeyId == 0)
            {
                return;
            }

            ItemConfig itemConf = ItemConfigCategory.Instance.Get(rolePetEgg.KeyId);
            string[] petinfos = itemConf.ItemUsePar.Split('@');
            int needCost = ComHelp.ReturnPetOpenTimeDiamond(rolePetEgg.KeyId,rolePetEgg.Value);
            
            if (unit.GetComponent<UserInfoComponent_S>().GetDiamond() < needCost)
            {
                response.Error = ErrorCode.ERR_DiamondNotEnoughError;
                return;
            }
            unit.GetComponent<UserInfoComponent_S>().UpdateRoleMoneySub(UserDataType.Diamond, (needCost * -1).ToString(), true,ItemGetWay.PetChouKa);
            List<int> weights = new List<int>();
            List<int> petlists = new List<int>();
            for (int i = 2; i < petinfos.Length; i++)
            {
                string[] petitem = petinfos[i].Split(';');
                petlists.Add(int.Parse(petitem[0]));
                weights.Add(int.Parse(petitem[1]));
            }
            int index = RandomHelper.RandomByWeight(weights);
            if (petlists.Count <= index)
            {
                index = 0;
            }
            if (rolePetEgg.KeyId == 10010093)
            {
                unit.GetComponent<ChengJiuComponent_S>().TriggerEvent(ChengJiuTargetEnum.OpenZGPetEggNumber_306, 0, 1);
            }
            response.PetInfo =  unit.GetComponent<PetComponent_S>().OnAddPet(ItemGetWay.PetEggDuiHuan, petlists[index]);
            unit.GetComponent<TaskComponent_S>().TriggerTaskEvent( TaskTargetType.PetFuHuaNumber_34, 0, 1 );
            unit.GetComponent<TaskComponent_S>().TriggerTaskCountryEvent(TaskTargetType.PetFuHuaNumber_34, 0, 1);

            unit.GetComponent<TaskComponent_S>().TriggerTaskEvent(TaskTargetType.PetFuHuaId_35, rolePetEgg.KeyId, 1);
            unit.GetComponent<TaskComponent_S>().TriggerTaskCountryEvent(TaskTargetType.PetFuHuaId_35, rolePetEgg.KeyId, 1);

            rolePetEgg.KeyId = 0;
            rolePetEgg.Value = 0;
            await ETTask.CompletedTask;
        }
    }
}
