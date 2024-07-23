using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_PetMiningChallengeItem))]
    [EntitySystemOf(typeof(Scroll_Item_PetMiningChallengeItem))]
    public static partial class Scroll_Item_PetMiningChallengeItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_PetMiningChallengeItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_PetMiningChallengeItem self)
        {
            self.DestroyWidget();
        }

        public static void OnButtonSelect(this Scroll_Item_PetMiningChallengeItem self)
        {
            if (self.PetNumber == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("出战队伍不能为空！");
                return;
            }

            if (self.Defend)
            {
                FlyTipComponent.Instance.ShowFlyTip("抢矿后原占有矿会变成无人看守的矿！");
            }

            self.SelectHandler.Invoke(self.TeamId);
        }

        public static void OnUpdateUI(this Scroll_Item_PetMiningChallengeItem self, bool defend)
        {
            self.TextTip11 = self.uiTransform.Find("TextTip11").gameObject;
            self.TextTip12 = self.uiTransform.Find("TextTip12").gameObject;
            self.TextTip13 = self.uiTransform.Find("TextTip13").gameObject;

            for (int i = 0; i < self.PetIcon_List.Length; i++)
            {
                GameObject iconitem = self.uiTransform.Find($"PetIcon_{i}").gameObject;
                self.PetIcon_List[i] = iconitem.GetComponent<Image>();
            }

            self.ButtonSelect = self.uiTransform.Find("ButtonSelect").gameObject;
            self.ButtonSelect.GetComponent<Button>().onClick.AddListener(self.OnButtonSelect);

            self.ImageSelect = self.uiTransform.Find("ImageSelect").gameObject;

            self.PetComponent = self.Root().GetComponent<PetComponentC>();

            self.Defend = defend;

            int playerLv = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv;
            int openLv = ConfigData.PetMiningTeamOpenLevel[self.TeamId];
            using (zstring.Block())
            {
                self.TextTip12.GetComponent<Text>().text = zstring.Format("{0}级开启", openLv);
            }

            bool isopen = playerLv >= openLv;

            for (int i = 0; i < 5; i++)
            {
                if (!isopen)
                {
                    self.PetIcon_List[i].gameObject.SetActive(false);
                    continue;
                }

                long petid = self.PetComponent.PetMingList[i + self.TeamId * 5];
                RolePetInfo rolePetInfo = self.PetComponent.GetPetInfoByID(petid);
                if (rolePetInfo == null)
                {
                    self.PetIcon_List[i].gameObject.SetActive(false);
                }
                else
                {
                    self.PetIcon_List[i].gameObject.SetActive(true);
                    PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);
                    string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petConfig.HeadIcon);
                    Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

                    self.PetIcon_List[i].sprite = sp;
                    self.PetNumber++;
                }
            }

            self.TextTip13.SetActive(defend);
            self.ButtonSelect.SetActive(true);
            self.ImageSelect.SetActive(false);

            self.TextTip12.gameObject.SetActive(!isopen);
        }
    }
}