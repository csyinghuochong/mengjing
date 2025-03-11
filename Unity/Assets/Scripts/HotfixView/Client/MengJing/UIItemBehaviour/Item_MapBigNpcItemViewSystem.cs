using System;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_MapBigNpcItem))]
    [EntitySystemOf(typeof (Scroll_Item_MapBigNpcItem))]
    public static partial class Scroll_Item_MapBigNpcItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_MapBigNpcItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_MapBigNpcItem self)
        {
            self.DestroyWidget();
        }

        public static void OnImageDi(this Scroll_Item_MapBigNpcItem self)
        {
            self.ClickHandler(self.UnitType, self.ConfigId);
        }

        private static async ETTask OnFlyTo(this Scroll_Item_MapBigNpcItem self)
        {
            BagComponentC bagComponentC = self.Root().GetComponent<BagComponentC>();
            if (bagComponentC.GetItemNumber(ConfigData.FlyToItem) < 1)
            {
                FlyTipComponent.Instance.ShowFlyTip("道具不足");  
                return; 
            }

            EnterMapHelper.RequestFlyToPosition(self.Root(), self.ConfigId).Coroutine();
            await ETTask.CompletedTask; 
        }

        public static void SetClickHandler(this Scroll_Item_MapBigNpcItem self, int unittype, int npcId, Action<int, int> action)
        {
            self.E_ImageDiButton.AddListener(self.OnImageDi);
            self.E_FlyToButton.AddListenerAsync( self.OnFlyTo);

            self.ConfigId = npcId;
            self.ClickHandler = action;
            self.UnitType = unittype;

            if (unittype == UnitType.Npc)
            {
                self.E_TextNameText.text = NpcConfigCategory.Instance.Get(npcId).Name;
            }
            else
            {
                self.E_TextNameText.text = MonsterConfigCategory.Instance.Get(npcId).MonsterName;
            }
        }
    }
}