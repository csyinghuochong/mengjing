namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_UnitBuffRemoveHandler: MessageHandler<Scene, M2C_UnitBuffRemove>
    {
        protected override async ETTask Run(Scene root, M2C_UnitBuffRemove message)
        {
            Unit msgUnitBelongTo = root.CurrentScene()?.GetComponent<UnitComponent>().Get(message.UnitIdBelongTo);
            if (msgUnitBelongTo == null)
            {
                return;
            }
            //移除
            msgUnitBelongTo.GetComponent<BuffManagerComponentC>().RemoveBuff(message.BuffID);
            await ETTask.CompletedTask;
        }
    }
}