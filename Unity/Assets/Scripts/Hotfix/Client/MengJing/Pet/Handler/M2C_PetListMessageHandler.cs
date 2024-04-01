namespace ET.Client
{
    [FriendOf(typeof (PetComponentC))]
    [MessageHandler(SceneType.Demo)]
    public class M2C_PetListMessageHandler: MessageHandler<Scene, M2C_PetListMessage>
    {
        protected override async ETTask Run(Scene root, M2C_PetListMessage message)
        {
            PetComponentC petComponent = root.GetComponent<PetComponentC>();
            petComponent.RolePetInfos = message.PetList;

            petComponent.ResetFormation(petComponent.TeamPetList, message.RemovePetId);
            petComponent.ResetFormation(petComponent.PetFormations, message.RemovePetId);

            await ETTask.CompletedTask;
        }
    }
}