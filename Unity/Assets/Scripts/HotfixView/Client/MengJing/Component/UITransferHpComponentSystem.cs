namespace ET.Client
{


    [EntitySystemOf(typeof(UITransferHpComponent))]
    [FriendOf(typeof(UITransferHpComponent))]
    public static partial class UITransferHpComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UITransferHpComponent self)
        {

        }
        [EntitySystem]
        private static void Destroy(this UITransferHpComponent self)
        {

        }

        public static async ETTask OnInitUI(this UITransferHpComponent self, int configId)
        {
            await ETTask.CompletedTask;
        }
    }

}