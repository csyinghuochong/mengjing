namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_PetMeleeDealCardsHandler : MessageHandler<Scene, M2C_PetMeleeDealCards>
    {
        protected override async ETTask Run(Scene root, M2C_PetMeleeDealCards message)
        {
            EventSystem.Instance.Publish(root, new PetMeleeDealCards() { PetMeleeCards = message.PetMeleeCardList });

            await ETTask.CompletedTask;
        }
    }
}