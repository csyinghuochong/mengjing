namespace ET.Server
{
    /// <summary>
    /// 开启孔位：玩家等级和符文总等级都够了就永久解锁
    /// </summary>
    [MessageHandler(SceneType.Map)]
    public class C2M_RuneUnlockSlotHandler : MessageLocationHandler<Unit, C2M_RuneUnlockSlotRequest, M2C_RuneUnlockSlotResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_RuneUnlockSlotRequest request, M2C_RuneUnlockSlotResponse response)
        {
            RuneComponent runeComponent = unit.GetComponent<RuneComponent>();

            response.Error = runeComponent.OnUnlockSlot(request.SlotId);
            response.Info = runeComponent.GetInfo();
            await ETTask.CompletedTask;
        }
    }
}
