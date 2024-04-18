namespace ET.Client
{
    
    [MessageHandler(SceneType.Demo)]
    public class M2C_UnitUseSkillHandler: MessageHandler<Scene, M2C_UnitUseSkill>
    {
        protected override async ETTask Run(Scene root, M2C_UnitUseSkill message)
        {
            Scene curScene = root.CurrentScene();
            if (curScene == null)
            {
                return;
            }
            Unit unit = curScene.GetComponent<UnitComponent>().Get(message.UnitId);
            if (unit != null)
            {
                unit.GetComponent<SkillManagerComponentC>().OnUseSkill(message);
            }
            else
            {
                Log.Debug("unit == null  " + message.UnitId);
            }
            await ETTask.CompletedTask;
        }
    }
}