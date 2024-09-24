namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_StopResultHandler: MessageLocationHandler<Unit, C2M_StopResult>
    {
        protected override async ETTask Run(Unit unit, C2M_StopResult message)
        {
            int petfightindex = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.PetFightIndex);

            if (petfightindex == 0)
            {
                unit.StopResult(message.Position, 0);
            }
            else
            {
                PetComponentS petComponentS = unit.GetComponent<PetComponentS>();
                Unit petunit = petComponentS.GetFightPetByIndex(petfightindex);
                if (petunit == null)
                {
                    return;
                }
                
                petunit.StopResult(message.Position, 0);
            }
            
            await ETTask.CompletedTask;
        }
    }
}