namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class Skill_OnSkillEffect: AEvent<Scene, SkillEffect>
    {
        protected override async ETTask Run(Scene scene, SkillEffect args)
        {
            EffectViewComponent effectViewComponent = args.Unit.GetComponent<EffectViewComponent>();
            effectViewComponent?.EffectFactory(args.EffectData);
            await ETTask.CompletedTask;
        }
    }
}
