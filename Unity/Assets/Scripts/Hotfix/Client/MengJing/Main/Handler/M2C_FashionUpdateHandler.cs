namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_FashionUpdateHandler : MessageHandler<Scene, M2C_FashionUpdate>
    {
        protected override async ETTask Run(Scene root, M2C_FashionUpdate message)
        {
            Unit unit = root.CurrentScene().GetComponent<UnitComponent>().Get(message.UnitID);
            if (unit == null)
            {
                return;
            }

            if (unit.MainHero)
            {
                root.GetComponent<BagComponentC>().FashionEquipList = message.FashionEquipList;
            }

            unit.GetComponent<UnitInfoComponent>().FashionEquipList = message.FashionEquipList;

            EventSystem.Instance.Publish(root, new FashionUpdate() { Unit = unit });

            await ETTask.CompletedTask;
        }
    }
}