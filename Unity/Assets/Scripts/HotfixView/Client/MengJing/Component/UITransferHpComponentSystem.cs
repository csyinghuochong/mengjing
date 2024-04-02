namespace ET.Client
{


    [EntitySystemOf(typeof(UITransferHpComponent))]
    [FriendOf(typeof(UITransferHpComponent))]
    public static partial class UITransferHpComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.UITransferHpComponent self)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Client.UITransferHpComponent self)
        {

        }

        public static async ETTask OnInitUI(this ET.Client.UITransferHpComponent self, int configId)
        {
            await ETTask.CompletedTask;
        }
    }

}