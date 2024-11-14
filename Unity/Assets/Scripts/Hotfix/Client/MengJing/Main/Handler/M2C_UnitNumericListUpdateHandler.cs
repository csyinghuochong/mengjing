namespace ET.Client
{
    //接受属性改变消息
    [MessageHandler(SceneType.Demo)]
    public class M2C_UnitNumericListUpdateHandler : MessageHandler<Scene, M2C_UnitNumericListUpdate>
    {
        protected override async ETTask Run(Scene root, M2C_UnitNumericListUpdate message)
        {
            Scene currentScene = root.CurrentScene();
            if (currentScene == null)
            {
                return;
            }

            Unit nowNunt = currentScene.GetComponent<UnitComponent>().Get(message.UnitID);
            if (nowNunt == null)
            {
                return;
            }

            NumericComponentC numericComponent = nowNunt.GetComponent<NumericComponentC>();
            for (int i = 0; i < message.Vs.Count; i++)
            {
                numericComponent.ApplyValue(message.Ks[i], message.Vs[i], true);
            }
            
            if (nowNunt.MainHero)
            {
                //自己的属性派发时间更新属性界面
                EventSystem.Instance.Publish(root, new DataUpdate_UpdateRoleProper());
            }
            await ETTask.CompletedTask;
        }
    }
}