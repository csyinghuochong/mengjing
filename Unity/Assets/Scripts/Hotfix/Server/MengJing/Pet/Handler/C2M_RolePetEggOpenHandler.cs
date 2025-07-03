using System.Collections.Generic;

namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_RolePetEggOpenHandler : MessageLocationHandler<Unit, C2M_RolePetEggOpen, M2C_RolePetEggOpen>
    {
        protected override async ETTask Run(Unit unit, C2M_RolePetEggOpen request, M2C_RolePetEggOpen response)
        {
            PetComponentS petComponent = unit.GetComponent<PetComponentS>();
            KeyValuePairLong4 rolePetEgg = petComponent.RolePetEggs[request.Index];
            if (rolePetEgg.KeyId == 0)
            {
                return;
            }

            ItemConfig itemConf = ItemConfigCategory.Instance.Get((int)rolePetEgg.KeyId);
            string[] petinfos = itemConf.ItemUsePar.Split('@');
            int needCost = CommonHelp.ReturnPetOpenTimeDiamond((int)rolePetEgg.KeyId,rolePetEgg.Value);
            
            if (unit.GetComponent<UserInfoComponentS>().GetDiamond() < needCost)
            {
                response.Error = ErrorCode.ERR_DiamondNotEnoughError;
                return;
            }
            unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneySub(UserDataType.Diamond, (needCost * -1).ToString(), true,ItemGetWay.PetChouKa);
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
            if (rolePetEgg.KeyId == 1000035)
            {
                unit.GetComponent<ChengJiuComponentS>().TriggerEvent(ChengJiuTargetEnum.OpenZGPetEggNumber_306, 0, 1);
            }
           
            unit.GetComponent<TaskComponentS>().TriggerTaskEvent( TaskTargetType.PetFuHuaNumber_34, 0, 1 );
            unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.PetFuHuaId_35, (int)rolePetEgg.KeyId, 1);
          
            rolePetEgg.KeyId = 0;
            rolePetEgg.Value = 0;
            response.PetInfo =  unit.GetComponent<PetComponentS>().OnAddPet(ItemGetWay.PetEggDuiHuan, petlists[index]);
            await ETTask.CompletedTask;
        }
    }
}
