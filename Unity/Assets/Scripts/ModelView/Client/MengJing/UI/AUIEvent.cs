namespace ET.Client
{
    public abstract class AUIEvent
    {
        public abstract ETTask<UI> OnCreate(MJUIComponent uiComponent);
        public abstract void OnRemove(MJUIComponent uiComponent);
    }
}