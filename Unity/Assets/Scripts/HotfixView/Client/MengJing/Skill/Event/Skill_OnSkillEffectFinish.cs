
namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class Skill_OnSkillEffectFinish : AEvent<Scene, SkillEffectFinish>
    {
        protected override async ETTask Run(Scene scene, SkillEffectFinish args)
        {
            EffectViewComponent effectViewComponent = args.Unit.GetComponent<EffectViewComponent>();
            if (effectViewComponent == null)
            {
                return;
            }

            effectViewComponent.RemoveEffectId(args.EffectInstanceId);

            await ETTask.CompletedTask;
        }
    }
}