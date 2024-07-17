namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetMingOccupyHandler : MessageLocationHandler<Unit, C2M_PetMingOccupyRequest, M2C_PetMingOccupyResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PetMingOccupyRequest request, M2C_PetMingOccupyResponse response)
        {
            if (request.Operate == 0)
            {
                return;
            }
            PetMingDungeonComponent petMingDungeon  = unit.Root().GetComponent<PetMingDungeonComponent>();
            if (petMingDungeon == null )
            {
                return;
            }
            
            await ETTask.CompletedTask;
        }
    }
}
