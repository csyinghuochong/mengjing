using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_DonationShowItem))]
    [EntitySystemOf(typeof(Scroll_Item_DonationShowItem))]
    public static partial class Scroll_Item_DonationShowItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_DonationShowItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_DonationShowItem self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnButtonWatch(this Scroll_Item_DonationShowItem self)
        {
            C2F_WatchPlayerRequest request = new() { UserId = self.RankingInfo.UserId };
            F2C_WatchPlayerResponse response =
                    (F2C_WatchPlayerResponse)await self.Root().GetComponent<ClientSenderCompnent>().Call(request);
            if (self.IsDisposed)
            {
                return;
            }

            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Watch);
            if (self.IsDisposed)
            {
                return;
            }

            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgWatch>().OnUpdateUI(response);
        }

        public static void OnUpdateUI(this Scroll_Item_DonationShowItem self, int rank, RankingInfo rankingInfo)
        {
            self.E_Button_WatchEquipButton.AddListenerAsync(self.OnButtonWatch);
            self.RankingInfo = rankingInfo;

            using (zstring.Block())
            {
                self.E_Text_CombatText.text = zstring.Format("{0}金币", rankingInfo.Combat);
                self.E_Text_DonationText.text = zstring.Format("{0}级", rankingInfo.PlayerLv);
            }

            self.E_Text_NameText.text = rankingInfo.PlayerName;
            self.E_Text_RankText.text = rank.ToString();
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            self.E_ImageHeadIconImage.sprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, rankingInfo.Occ.ToString()));
        }
    }
}