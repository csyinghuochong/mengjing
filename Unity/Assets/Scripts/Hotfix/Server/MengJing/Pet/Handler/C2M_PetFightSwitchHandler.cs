namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetFightSwitchHandler : MessageLocationHandler<Unit, C2M_PetFightSwitch, M2C_PetFightSwitch>
    {
        protected override async ETTask Run(Unit unit, C2M_PetFightSwitch request, M2C_PetFightSwitch response)
        {
            unit.GetComponent<NumericComponentS>().ApplyValue( NumericType.PetFightIndex, request.PetFightIndex );
           
            await ETTask.CompletedTask;
        }
    }
}