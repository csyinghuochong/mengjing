using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_PetMiningItem))]
    [FriendOfAttribute(typeof(ES_PetMiningItem))]
    public static partial class ES_PetMiningItemSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetMiningItem self, Transform args2)
        {
            self.uiTransform = args2;

            self.E_ImageIcon.GetComponent<Button>().AddListenerAsync(self.OnImageIcon);
            for (int i = 0; i < self.E_PetIconList.Length; i++)
            {
                self.E_PetIconList[i] = self.E_PetList.transform.GetChild(i).Find("Icon").GetComponent<Image>();
            }
        }

        [EntitySystem]
        private static void Destroy(this ES_PetMiningItem self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnImageIcon(this ES_PetMiningItem self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetMiningChallenge);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetMiningChallenge>().OnInitUI(self.MineType, self.Position, self.PetMingPlayerInfo);
        }

        public static void OnInitUI(this ES_PetMiningItem self, int mingType, int index, bool hexin, List<KeyValuePairInt> petMineExtend)
        {
            self.MineType = mingType;
            self.Position = index;
            self.E_ImHeXinShow.gameObject.SetActive(hexin);
            MineBattleConfig mineBattleConfig = MineBattleConfigCategory.Instance.Get(mingType);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, mineBattleConfig.Icon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_ImageIcon.sprite = sp;

            using (zstring.Block())
            {
                self.E_TextMine.text = zstring.Format("{0}{1}", mineBattleConfig.Name, (hexin ? "(核心矿)" : string.Empty));
                
                int openDay = TimeHelper.GetServeOpenDay(self.Root().GetComponent<PlayerInfoComponent>().ServerItem.ServerOpenTime);
                float coffi = CommonHelp.GetMineCoefficient(openDay, mingType, index, petMineExtend);
                int chanchu = (int)(mineBattleConfig.GoldOutPut * coffi);
                self.E_TextChanChu.text = zstring.Format("{0}/小时", chanchu);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <param name="mingType">矿场类型</param>
        /// <param name="index">矿场序号</param>
        /// <param name="petMingPlayerInfo">占领者</param>
        public static void OnUpdateUI(this ES_PetMiningItem self, PetMingPlayerInfo petMingPlayerInfo)
        {
            self.PetMingPlayerInfo = petMingPlayerInfo;

            string playerName = string.Empty;
            List<int> confids = new List<int>();

            if (petMingPlayerInfo != null)
            {
                using (zstring.Block())
                {
                    playerName = zstring.Format("拥有者：{0}", petMingPlayerInfo.PlayerName);
                }

                confids = petMingPlayerInfo.PetConfig;

                for (int i = 0; i < self.E_PetIconList.Length; i++)
                {
                    if (confids[i] == 0)
                    {
                        self.E_PetIconList[i].gameObject.SetActive(false);
                    }
                    else
                    {
                        self.E_PetIconList[i].gameObject.SetActive(true);
                        PetConfig petConfig = PetConfigCategory.Instance.Get(confids[i]);
                        string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petConfig.HeadIcon);
                        Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

                        self.E_PetIconList[i].sprite = sp;
                    }
                }
            }
            else
            {
                playerName = "占领者：无";
                for (int i = 0; i < self.E_PetIconList.Length; i++)
                {
                    self.E_PetIconList[i].gameObject.SetActive(false);
                }
            }

            self.E_TextPlayer.text = playerName;
        }
    }
}