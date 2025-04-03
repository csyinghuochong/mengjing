using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_RankPetItem))]
    [FriendOfAttribute(typeof(ES_RankPetItem))]
    public static partial class ES_RankPetItemSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RankPetItem self, Transform transform)
        {
            self.uiTransform = transform;

            self.ImageIconList = new GameObject[5];
            self.ImageIconList[0] = self.E_ImageIcon1Image.gameObject;
            self.ImageIconList[1] = self.E_ImageIcon2Image.gameObject;
            self.ImageIconList[2] = self.E_ImageIcon3Image.gameObject;
            self.ImageIconList[3] = self.E_ImageIcon4Image.gameObject;
            self.ImageIconList[4] = self.E_ImageIcon5Image.gameObject;
            self.ImageIconList[4].GetComponent<Button>().AddListener(() => { self.OnImageIconList(4).Coroutine(); });
            self.ImageIconList[3].GetComponent<Button>().AddListener(() => { self.OnImageIconList(3).Coroutine(); });
            self.ImageIconList[2].GetComponent<Button>().AddListener(() => { self.OnImageIconList(2).Coroutine(); });
            self.ImageIconList[1].GetComponent<Button>().AddListener(() => { self.OnImageIconList(1).Coroutine(); });
            self.ImageIconList[0].GetComponent<Button>().AddListener(() => { self.OnImageIconList(0).Coroutine(); });

            self.E_Btn_PVPButton.AddListener(self.OnBtn_PVPButton);
        }

        [EntitySystem]
        private static void Destroy(this ES_RankPetItem self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnImageIconList(this ES_RankPetItem self, int index)
        {
            if (self.RankPetInfo == null)
            {
                return;
            }

            if (self.PetIdList.Count <= index)
            {
                return;
            }

            long petid = self.PetIdList[index];
            if (petid == 0)
            {
                return;
            }

            long instanceid = self.InstanceId;
            long untiid = self.RankPetInfo.UserId;

            F2C_WatchPetResponse response = await FriendNetHelper.RequestWatchPet(self.Root(), untiid, petid);

            if (instanceid != self.InstanceId)
            {
                return;
            }

            if (response.RolePetInfos == null)
            {
                return;
            }

            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetInfo);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetInfo>()
                    .OnUpdateUI(response.RolePetInfos, response.PetHeXinList, response.Ks, response.Vs);
        }

        public static void OnInitUI(this ES_RankPetItem self, RankPetInfo rankPetInfo)
        {
            self.RankPetInfo = rankPetInfo;
            if (!CommonHelp.IfNull(rankPetInfo.TeamName))
            {
                self.E_Lab_TeamNameText.text = rankPetInfo.TeamName;
                self.E_Lab_OwnerText.text = "";
            }
            else
            {
                using (zstring.Block())
                {
                    self.E_Lab_TeamNameText.text = zstring.Format("{0}的队伍", rankPetInfo.PlayerName);
                }

                self.E_Lab_OwnerText.text = rankPetInfo.PlayerName;
            }

            int number = 0;
            self.PetIdList.Clear();
            for (int i = 0; i < rankPetInfo.PetConfigId.Count; i++)
            {
                if (rankPetInfo.PetConfigId[i] == 0 || number >= 5)
                {
                    continue;
                }

                PetConfig petConfig = PetConfigCategory.Instance.Get(rankPetInfo.PetConfigId[i]);
                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petConfig.HeadIcon);
                Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

                self.ImageIconList[number].SetActive(true);
                self.ImageIconList[number].GetComponent<Image>().sprite = sp;
                self.E_Lab_PaiMingText.text = rankPetInfo.RankId.ToString();
                self.PetIdList.Add(rankPetInfo.PetUId[i]);
                number++;
            }

            for (int i = number; i < 5; i++)
            {
                self.ImageIconList[i].SetActive(false);
            }

            self.E_Lab_CombatText.text = rankPetInfo.Combat.ToString();
        }

        public static void OnBtn_PVPButton(this ES_RankPetItem self)
        {
            int teamNumber = 0;
            List<long> teamList = self.Root().GetComponent<PetComponentC>().TeamPetList;
            for (int i = 0; i < teamList.Count; i++)
            {
                teamNumber += (teamList[i] != 0 ? 1 : 0);
            }

            if (teamNumber < 3)
            {
                FlyTipComponent.Instance.ShowFlyTip("上阵宠物不足三只!");
                return;
            }

            EnterMapHelper.RequestTransfer(self.Root(), MapTypeEnum.PetTianTi, BattleHelper.GetPetTianTiId(), 0, self.RankPetInfo.UserId.ToString()).Coroutine();
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Rank);
        }
    }
}
