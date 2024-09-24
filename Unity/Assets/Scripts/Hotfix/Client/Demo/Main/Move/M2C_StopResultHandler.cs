using Unity.Mathematics;

namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_StopResultHandler : MessageHandler<Scene, M2C_StopResult>
    {
        protected override async ETTask Run(Scene root, M2C_StopResult message)
        {
            Unit unit = root.CurrentScene().GetComponent<UnitComponent>().Get(message.Id);
            if (unit == null)
            {
                return;
            }

            if(!unit.MainHero)
            {
                float speed = unit.GetComponent<NumericComponentC>().GetAsFloat(NumericType.Now_Speed);
                using var list = ListComponent<float3>.Create();
                list.Add(unit.Position + (message.Position - unit.Position) * 0.5f);
                list.Add(message.Position);
                unit.GetComponent<MoveComponent>().MoveToAsync(list, speed * 1.5f).Coroutine();
            }
            EventSystem.Instance.Publish(root.CurrentScene(), new MoveStop() { Unit = unit });
            await ETTask.CompletedTask;
        }
    }
}