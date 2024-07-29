namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_UnionApplyHandler : MessageHandler<Scene, M2C_UnionApplyResult>
    {
        protected override async ETTask Run(Scene root, M2C_UnionApplyResult message)
        {
            root.GetComponent<ReddotComponentC>().AddReddont(ReddotType.UnionApply);

            await ETTask.CompletedTask;
        }
    }
}