namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_UnitFinishSkillHandler: MessageHandler<Scene, M2C_UnitFinishSkill>
    {
        protected override async ETTask Run(Scene root, M2C_UnitFinishSkill message)
        {
            Scene curScene = root.CurrentScene();
            if (curScene == null)
            {
                return;
            }
            Unit unit = curScene.GetComponent<UnitComponent>().Get(message.UnitId);
            if (unit != null)
            {
                unit.GetComponent<SkillManagerComponentC>().OnFinish();
            }
            
            await ETTask.CompletedTask;
        }
    }
}