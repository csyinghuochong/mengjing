namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_StopHandler: MessageLocationHandler<Unit, C2M_Stop>
    {
        protected override async ETTask Run(Unit unit, C2M_Stop message)
        {
            int petfightindex = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.PetFightIndex);

            if (petfightindex == 0)
            {
                if (message.YaoGan)
                {
                    unit.StopYaoGan(0);
                }
                else
                {
                    unit.Stop(0);
                } 
            }
            else
            {
                PetComponentS petComponentS = unit.GetComponent<PetComponentS>();
                Unit petunit = petComponentS.GetFightPetByIndex(petfightindex);
                if (petunit == null)
                {
                    return;
                }
                
                petunit.Stop(0);
            }
            
            await ETTask.CompletedTask;
        }
    }
}