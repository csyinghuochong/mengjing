using TrueSync;

namespace ET.Server
{
    [MessageHandler(SceneType.RoomRoot)]
    [FriendOf(typeof (RoomServerComponent))]
    public class C2Room_ChangeSceneFinishHandler: MessageHandler<Scene, C2Room_ChangeSceneFinish>
    {
        protected override async ETTask Run(Scene root, C2Room_ChangeSceneFinish message)
        {
            Room room = root.GetComponent<Room>();
            RoomServerComponent roomServerComponent = room.GetComponent<RoomServerComponent>();
            RoomPlayer roomPlayer = room.GetComponent<RoomServerComponent>().GetChild<RoomPlayer>(message.PlayerId);
            roomPlayer.Progress = 100;
            
            if (!roomServerComponent.IsAllPlayerProgress100())
            {
                return;
            }
            
            await room.Fiber.Root.GetComponent<TimerComponent>().WaitAsync(1000);

            Room2C_Start room2CStart = new() { StartTime = TimeInfo.Instance.ServerFrameTime() };
            foreach (RoomPlayer rp in roomServerComponent.Children.Values)
            {
                LockStepUnitInfo LockStepUnitInfo = LockStepUnitInfo.Create();
                LockStepUnitInfo.PlayerId = rp.Id;
                LockStepUnitInfo.Position = new TSVector(20, 0, -10);
                LockStepUnitInfo.Rotation = TSQuaternion.identity;
                room2CStart.UnitInfo.Add(LockStepUnitInfo);
            }

            room.Init(room2CStart.UnitInfo, room2CStart.StartTime);

            room.AddComponent<LSServerUpdater>();

            RoomMessageHelper.BroadCast(room, room2CStart);
        }
    }
}