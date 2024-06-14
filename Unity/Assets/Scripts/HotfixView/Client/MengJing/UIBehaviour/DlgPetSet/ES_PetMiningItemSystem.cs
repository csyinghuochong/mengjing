using System.Collections.Generic;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_PetMiningItem))]
    [FriendOfAttribute(typeof (ES_PetMiningItem))]
    public static partial class ES_PetMiningItemSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.ES_PetMiningItem self, UnityEngine.Transform args2)
        {
            self.uiTransform = args2;
        }

        [EntitySystem]
        private static void Destroy(this ET.Client.ES_PetMiningItem self)
        {
            self.DestroyWidget();
        }

        public static void OnInitUI(this ES_PetMiningItem self, int mingType, int index, bool hexin, List<KeyValuePairInt> petMineExtend)
        {
            // self.MineType = mingType;
            // self.Position = index;
            // self.ImHeXinShow.SetActive(hexin);
            // MineBattleConfig mineBattleConfig = MineBattleConfigCategory.Instance.Get(mingType);
            // string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, mineBattleConfig.Icon);
            // Sprite sp = ResourcesComponent.Instance.LoadAsset<Sprite>(path);
            //
            // self.ImageIcon.GetComponent<Image>().sprite = sp;
            //
            // self.TextMine.GetComponent<Text>().text = mineBattleConfig.Name + (hexin? "(核心矿)" : string.Empty);
            //
            // int zone = self.ZoneScene().GetComponent<AccountInfoComponent>().ServerId;
            // int openDay = ServerHelper.GetOpenServerDay(false, zone);
            // float coffi = ComHelp.GetMineCoefficient(openDay, mingType, index, petMineExtend);
            // int chanchu = (int)(mineBattleConfig.GoldOutPut * coffi);
            // self.TextChanChu.GetComponent<Text>().text = $"{chanchu}/小时";
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
            // self.PetMingPlayerInfo = petMingPlayerInfo;
            //
            // string playerName = string.Empty;
            // List<int> confids = new List<int>();
            //
            // if (petMingPlayerInfo != null)
            // {
            //     playerName = "拥有者：" + petMingPlayerInfo.PlayerName;
            //     confids = petMingPlayerInfo.PetConfig;
            //
            //     for (int i = 0; i < self.PetIconList.Length; i++)
            //     {
            //         if (confids[i] == 0)
            //         {
            //             self.PetIconList[i].gameObject.SetActive(false);
            //         }
            //         else
            //         {
            //             self.PetIconList[i].gameObject.SetActive(true);
            //             PetConfig petConfig = PetConfigCategory.Instance.Get(confids[i]);
            //             string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petConfig.HeadIcon);
            //             Sprite sp = ResourcesComponent.Instance.LoadAsset<Sprite>(path);
            //             if (!self.AssetPath.Contains(path))
            //             {
            //                 self.AssetPath.Add(path);
            //             }
            //
            //             self.PetIconList[i].sprite = sp;
            //         }
            //     }
            // }
            // else
            // {
            //     playerName = "占领者：无";
            //     for (int i = 0; i < self.PetIconList.Length; i++)
            //     {
            //         self.PetIconList[i].gameObject.SetActive(false);
            //     }
            // }
            //
            // self.TextPlayer.GetComponent<Text>().text = playerName;
        }
    }
}