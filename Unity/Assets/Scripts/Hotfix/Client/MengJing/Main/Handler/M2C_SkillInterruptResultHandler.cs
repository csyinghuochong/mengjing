
namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_SkillInterruptResultHandler: MessageHandler<Scene, M2C_SkillInterruptResult>
    {
        protected override async ETTask Run(Scene root, M2C_SkillInterruptResult message)
        {
            Unit unit = root.CurrentScene().GetComponent<UnitComponent>().Get(message.UnitId);
            if (unit == null)
            {
                return;
            }
            unit.GetComponent<SkillManagerComponentC>().InterruptSkill(message.SkillId);
            
            EventSystem.Instance.Publish(root, new SkillInterrup());

            await ETTask.CompletedTask;
        }
    }
}