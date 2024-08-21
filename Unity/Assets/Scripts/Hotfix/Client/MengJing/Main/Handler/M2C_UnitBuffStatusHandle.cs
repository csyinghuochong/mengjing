namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_UnitBuffStatusHandle: MessageHandler<Scene, M2C_UnitBuffStatus>
    {
        protected override async ETTask Run(Scene root, M2C_UnitBuffStatus message)
        {
            Unit msgUnitBelongTo = root.CurrentScene()?.GetComponent<UnitComponent>().Get(message.UnitID);
            if (msgUnitBelongTo == null)
            {
               return;
            }
            EventSystem.Instance.Publish(root, new Now_Hp_Update()
            {
                Defend = msgUnitBelongTo,
                ChangeHpValue = 0,
                DamgeType =message.FlyType,
                SkillID = 0,
            });
            await ETTask.CompletedTask;
        }
    }
}