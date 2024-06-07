namespace ET.Client
{
    //角色信息广播
    [MessageHandler(SceneType.Demo)]
    public class M2C_RoleDataBroadcastHandler: MessageHandler<Scene, M2C_RoleDataBroadcast>
    {
        protected override async ETTask Run(Scene root, M2C_RoleDataBroadcast message)
        {
            Unit unit = root.CurrentScene().GetComponent<UnitComponent>().Get(message.UnitId);
            if (unit == null)
            {
                return;
            }

            switch (message.UpdateType)
            {
                //更新角色名称
                case UserDataType.Name:
                    unit.GetComponent<UnitInfoComponent>().UnitName = message.UpdateTypeValue;
                    break;
                case UserDataType.Lv:
                    //int.Parse(message.UpdateTypeValue);
                    break;
                case UserDataType.UnionName:
                    unit.GetComponent<UnitInfoComponent>().UnionName = message.UpdateTypeValue;
                    break;
                case UserDataType.DemonName:
                    unit.GetComponent<UnitInfoComponent>().DemonName = message.UpdateTypeValue;
                    break;
                default:
                    break;
            }

            EventSystem.Instance.Publish(root,
                new RoleDataBroadcase() { Unit = unit, UserDataType = message.UpdateType, UserDataValue = message.UpdateTypeValue });

            await ETTask.CompletedTask;
        }
    }
}