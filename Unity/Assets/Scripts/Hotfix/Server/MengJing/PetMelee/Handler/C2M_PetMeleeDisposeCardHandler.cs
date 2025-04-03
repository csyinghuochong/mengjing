namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetMeleeDisposeCardHandler : MessageLocationHandler<Unit, C2M_PetMeleeDisposeCard, M2C_PetMeleeDisposeCard>
    {
        protected override async ETTask Run(Unit unit, C2M_PetMeleeDisposeCard request, M2C_PetMeleeDisposeCard response)
        {
            switch (request.MapType)
            {
                case MapTypeEnum.PetMelee:
                case MapTypeEnum.PetMatch:
                    PetMeleeDungeonComponent petMeleeDungeonComponent = unit.Scene().GetComponent<PetMeleeDungeonComponent>();
                    if (petMeleeDungeonComponent.IsGameOver())
                    {
                        response.Error = ErrorCode.ERR_Error;
                        return;
                    }

                    response.Error = petMeleeDungeonComponent.DisposeCard(request.CarId, unit);
                    break;
            }

            await ETTask.CompletedTask;
        }
    }
}