namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class Skill_OnSkillSound: AEvent<Scene, SkillSound>
    {
        protected override async ETTask Run(Scene scene, SkillSound args)
        {
            scene.GetComponent<SoundComponent>().PlayClip(args.Asset,"mp3").Coroutine();
            await ETTask.CompletedTask;
        }
    }
}
