namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class Skill_SkillEffectMove : AEvent<Scene, SkillEffectMove>
    {
        protected override async ETTask Run(Scene scene, SkillEffectMove args)
        {
            EffectViewComponent effectViewComponent = args.Unit.GetComponent<EffectViewComponent>();
            if (effectViewComponent == null)
            {
                return;
            }

            Effect effect = effectViewComponent.GetEffect(args.EffectInstanceId);
            if (effect != null)
            {
                effect.UpdateEffectPosition(args.Postion, args.Angle);
            }

            await ETTask.CompletedTask;
        }
    }
}