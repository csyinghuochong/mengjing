namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_PetDataBroadcastHandler: MessageHandler<Scene, M2C_PetDataBroadcast>
    {
        protected override async ETTask Run(Scene root, M2C_PetDataBroadcast message)
        {
            Unit unit = root.CurrentScene().GetComponent<UnitComponent>().Get(message.PetId);
            if (unit == null)
            {
                return;
            }

            switch (message.UpdateType)
            {
                case (int)UserDataType.Name:
                    unit.GetComponent<UnitInfoComponent>().UnitName = message.UpdateTypeValue;
                    break;
            }

            EventSystem.Instance.Publish(root,
                new RolePetUpdate { UpdateType = message.UpdateType, PetId = message.PetId, UpdateValue = message.UpdateTypeValue });

            await ETTask.CompletedTask;
        }
    }
}