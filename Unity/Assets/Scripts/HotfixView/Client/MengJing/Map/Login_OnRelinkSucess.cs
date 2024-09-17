namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class Login_OnRelinkSucess : AEvent<Scene, RelinkSucess>
    {
        protected override async ETTask Run(Scene scene, RelinkSucess args)
        {
            scene.GetComponent<RelinkComponent>().OnRelinkSucess().Coroutine();

            await ETTask.CompletedTask;
        }
    }
}