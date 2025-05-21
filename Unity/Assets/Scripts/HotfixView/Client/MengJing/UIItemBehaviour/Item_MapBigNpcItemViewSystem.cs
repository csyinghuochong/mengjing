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

        private static  void OnFlyTo(this Scroll_Item_MapBigNpcItem self)
        {
            self.FlyToHandler(self.UnitType, self.ConfigId);
        }

        public static void SetFlyToHandler(this Scroll_Item_MapBigNpcItem self,  Action<int, int> action)
        {
            self.FlyToHandler = action;
        }

        public static void SetClickHandler(this Scroll_Item_MapBigNpcItem self, int unittype, int npcId, Action<int, int> action)
        {
            self.E_ImageDiButton.AddListener(self.OnImageDi);
            self.E_FlyToButton.AddListener( self.OnFlyTo);

            self.ConfigId = npcId;
            self.ClickHandler = action;
            self.UnitType = unittype;
            self.E_ImageDi_npc.gameObject.SetActive(false);
            self.E_ImageDi_boss.gameObject.SetActive(false);
            if (unittype == UnitType.Npc)
            {
                self.E_TextNameText.text = NpcConfigCategory.Instance.Get(npcId).Name;
                self.E_ImageDi_npc.gameObject.SetActive(true);
            }
            else
            {
                self.E_TextNameText.text = MonsterConfigCategory.Instance.Get(npcId).MonsterName;
                self.E_ImageDi_boss.gameObject.SetActive(true);
            }
        }
    }
}