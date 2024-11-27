namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_PetTuJianActiveHandler : MessageHandler<Scene, M2C_PetTuJianActiveMessage>
    {
        protected override async ETTask Run(Scene root, M2C_PetTuJianActiveMessage message)
        {
            root.GetComponent<ChengJiuComponentC>().PetTuJianActives = message.PetTuJianActives;

            await ETTask.CompletedTask;
        }
    }
}