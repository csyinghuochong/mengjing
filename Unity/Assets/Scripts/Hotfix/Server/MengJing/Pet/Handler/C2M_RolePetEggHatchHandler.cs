namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_RolePetEggHatchHandler : MessageLocationHandler<Unit, C2M_RolePetEggHatch, M2C_RolePetEggHatch>
    {
        protected override async ETTask Run(Unit unit, C2M_RolePetEggHatch request, M2C_RolePetEggHatch response)
        {
            PetComponentS petComponent = unit.GetComponent<PetComponentS>();
            KeyValuePairLong4 rolePetEgg = petComponent.RolePetEggs[request.Index];
            if (rolePetEgg.Value == 0 && rolePetEgg.KeyId!= 0)
            {
                string[] useparams = ItemConfigCategory.Instance.Get((int)rolePetEgg.KeyId).ItemUsePar.Split('@');
                long needTime = long.Parse(useparams[0]);
                rolePetEgg.Value = TimeHelper.ServerNow() + needTime * 1000;
            }

            response.RolePetEgg = rolePetEgg;
            await ETTask.CompletedTask;
        }
    }
}
