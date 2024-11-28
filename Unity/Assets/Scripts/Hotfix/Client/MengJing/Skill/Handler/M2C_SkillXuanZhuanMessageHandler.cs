using Unity.Mathematics;

namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_SkillXuanZhuanMessageHandler: MessageHandler<Scene, M2C_SkillXuanZhuanMessage>
    {
        protected override async ETTask Run(Scene root, M2C_SkillXuanZhuanMessage message)
        {
            Unit unit = root.CurrentScene().GetComponent<UnitComponent>().Get(message.UnitID);
            if (unit == null)
            {
                return;
            }
            unit.Rotation =  quaternion.Euler(0, math.radians(message.Angle), 0);
            
            await ETTask.CompletedTask;
        }
    }
}