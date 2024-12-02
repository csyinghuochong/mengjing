namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetMeleeBeginHandler : MessageLocationHandler<Unit, C2M_PetMeleeBegin, M2C_PetMeleeBegin>
    {
        protected override async ETTask Run(Unit unit, C2M_PetMeleeBegin request, M2C_PetMeleeBegin response)
        {
            PetMeleeDungeonComponent petMeleeDungeonComponent = unit.Scene().GetComponent<PetMeleeDungeonComponent>();
            if (petMeleeDungeonComponent.IsGameOver())
            {
                response.Error = ErrorCode.ERR_Error;
                return;
            }

            if (petMeleeDungeonComponent.IsGameStart())
            {
                response.Error = ErrorCode.ERR_Error;
                return;
            }

            petMeleeDungeonComponent.SetGameStart();

            await ETTask.CompletedTask;
        }
    }
}