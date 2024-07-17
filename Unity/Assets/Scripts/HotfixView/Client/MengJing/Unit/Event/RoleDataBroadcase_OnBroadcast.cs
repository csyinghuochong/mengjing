namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class RoleDataBroadcase_OnBroadcast: AEvent<Scene, RoleDataBroadcase>
    {
        protected override async ETTask Run(Scene scene, RoleDataBroadcase args)
        {
            switch (args.UserDataType)
            {
                case UserDataType.Name:
                case UserDataType.UnionName:
                case UserDataType.Lv:
                    args.Unit.GetComponent<UIPlayerHpComponent>()?.UpdateShow();
                    break;
                case UserDataType.DemonName:
                    args.Unit.GetComponent<UIPlayerHpComponent>()?.UpdateDemonName(args.UserDataValue);
                    break;
            }

            await ETTask.CompletedTask;
        }
    }
}