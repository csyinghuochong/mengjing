namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetTakeOutBagHandler : MessageLocationHandler<Unit, C2M_PetTakeOutBag, M2C_PetTakeOutBag>
    {
        protected override async ETTask Run(Unit unit, C2M_PetTakeOutBag request, M2C_PetTakeOutBag response)
        {
            unit.GetComponent<PetComponentS>().TakeOutBag(request.PetInfoId);
            await ETTask.CompletedTask;
        }
    }
}
