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
                if (math.distance(unit.Position, message.Position) < 0.3f)
                {
                    MoveComponent moveComponent = unit.GetComponent<MoveComponent>();
                    moveComponent.Stop(message.Error == 0);
                    unit.Position = message.Position;
                    // unit.Rotation = message.Rotation;
                    EventSystem.Instance.Publish(root.CurrentScene(), new MoveStop() { Unit = unit });
                }
                else
                {
                    float speed = unit.GetComponent<NumericComponentC>().GetAsFloat(NumericType.Now_Speed);
                    using var list = ListComponent<float3>.Create();
                    list.Add(unit.Position + (message.Position - unit.Position) * 0.5f);
                    list.Add(message.Position);
                    unit.GetComponent<MoveComponent>().MoveToAsync(list, speed * 1.5f).Coroutine();
                }
            }
            
            await ETTask.CompletedTask;
        }
    }
}