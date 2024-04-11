namespace ET.Client
{
    
    [MessageHandler(SceneType.Demo)]
    public class M2C_UnitUseSkillHandler: MessageHandler<Scene, M2C_UnitUseSkill>
    {
        protected override async ETTask Run(Scene root, M2C_UnitUseSkill message)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(root);
            unit.GetComponent<SkillManagerComponentC>().OnUseSkill(message);
            await ETTask.CompletedTask;
        }
    }
}