using System;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_TaskFubenItem))]
    [EntitySystemOf(typeof(Scroll_Item_TaskFubenItem))]
    public static partial class Scroll_Item_TaskFubenItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_TaskFubenItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_TaskFubenItem self)
        {
            self.DestroyWidget();
        }

        public static void OnInitData(this Scroll_Item_TaskFubenItem self, Action<int, int> action, int npcType, int fubenId)
        {
            switch (npcType)
            {
                case 1:
                    self.E_TextFubenNameText.text = "兑换神兽";//ItemViewHelp.ShowDuiHuanPet(fubenId);
                    break;
                case 2:
                    self.E_TextFubenNameText.text = SceneConfigCategory.Instance.Get(fubenId).Name;
                    break;
                default:
                    break;
            }

            self.ClickHandler = action;
            self.NpcType = npcType;
            self.FubenId = fubenId;

            self.E_ImageButtonButton.AddListener(() => { self.ClickHandler(self.NpcType, self.FubenId); });
        }

        public static void OnInitUI(this Scroll_Item_TaskFubenItem self, Action<long> action, KeyValuePair keyValuePair)
        {
            self.ClickHandler2 = action;
            self.UserId = long.Parse(keyValuePair.Value);
            self.E_TextFubenNameText.text = keyValuePair.Value2;

            self.E_ImageButtonButton.AddListener(() => { self.ClickHandler2(self.UserId); });
        }

        public static void OnInitUI_2(this Scroll_Item_TaskFubenItem self, Action<long> action, int number)
        {
            self.ClickHandler2 = action;
            self.UserId = 0;
            using (zstring.Block())
            {
                self.E_TextFubenNameText.text = zstring.Format("补偿金额:{0}", number);
            }

            self.E_ImageButtonButton.AddListener(() => { self.ClickHandler2(self.UserId); });
        }
    }
}