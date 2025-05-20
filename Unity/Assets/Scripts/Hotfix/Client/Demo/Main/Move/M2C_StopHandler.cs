using Unity.Mathematics;

namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_StopHandler : MessageHandler<Scene, M2C_Stop>
    {
        protected override async ETTask Run(Scene root, M2C_Stop message)
        {
            Unit unit = root.CurrentScene().GetComponent<UnitComponent>().Get(message.Id);
            if (unit == null)
            {
                return;
            }

            //移动停止，插值同步
            if (message.Error == 0 )
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

            //message.Error == -1移动异常立即停止
            if (message.Error == -1)
            {
                MoveComponent moveComponent = unit.GetComponent<MoveComponent>();
                moveComponent.Stop(message.Error == 0);
                return;
            }

            //message.Error == -2立即停止且同步坐标
            if (message.Error == -2)
            {
                MoveComponent moveComponent = unit.GetComponent<MoveComponent>();
                moveComponent.Stop(message.Error == 0);
                unit.Position = message.Position;
                // unit.Rotation = message.Rotation;
                EventSystem.Instance.Publish(root.CurrentScene(), new MoveStop() { Unit = unit });
            }

            //message.Error == -3立即停止且同步坐标
            if (message.Error == -3)
            {
                MoveComponent moveComponent = unit.GetComponent<MoveComponent>();
                moveComponent.Stop(message.Error == 0);
                unit.Position = message.Position;
            }

            //message.Error > 1释放技能立即停止
            if (message.Error > 1)
            {
                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(message.Error);
                MoveComponent moveComponent = unit.GetComponent<MoveComponent>();
                moveComponent.SkillStop(unit, skillConfig).Coroutine();
                moveComponent.Stop(message.Error == 0);
                if (!unit.MainHero && math.distance(unit.Position , message.Position) > 0.5f)
                {
                    unit.Position = message.Position;
                }
            }

            unit.GetComponent<ObjectWait>()?.Notify(new Wait_UnitStop() { Error = message.Error });
            await ETTask.CompletedTask;
        }
    }
}