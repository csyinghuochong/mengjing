using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_FirstWin))]
    [FriendOfAttribute(typeof(ES_FirstWin))]
    public static partial class ES_FirstWinSystem
    {
        [EntitySystem]
        private static void Awake(this ES_FirstWin self, Transform transform)
        {
            self.uiTransform = transform;
            ReferenceCollector rc = transform.GetComponent<ReferenceCollector>();

            self.SkillDescriptionList.Add(self.E_SkillDescriptionItemTextText.gameObject);

            self.E_Button_FirstWinButton.AddListenerAsync(self.OnButton_FirstWinButton);
            self.E_Button_FirstWinSelfButton.AddListenerAsync(self.OnButton_FirstWinSelfButton);

            self.ES_ModelShow.Camera.localPosition = new Vector3(0f, 115, 394f);
            self.TypeListNode = rc.Get<GameObject>("TypeListNode");
            self.UITypeViewComponent = self.AddChild<UITypeViewComponent, GameObject>(self.TypeListNode);
            self.UITypeViewComponent.TypeButtonItemAsset = ABPathHelper.GetUGUIPath("Common/UIFirstWinTypeItem");
            self.UITypeViewComponent.TypeButtonAsset = ABPathHelper.GetUGUIPath("Common/UIFirstWinType");
            self.UITypeViewComponent.ClickTypeItemHandler = (int typeid, int subtypeid) => { self.OnClickTypeItem(typeid, subtypeid); };
            self.UITypeViewComponent.TypeButtonInfos = self.InitTypeButtonInfos();

            self.ReqestFirstWinInfo().Coroutine();
        }

        [EntitySystem]
        private static void Destroy(this ES_FirstWin self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnButton_FirstWinButton(this ES_FirstWin self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_FirstWinReward);
            DlgFirstWinReward dlgFirstWinReward = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgFirstWinReward>();
            dlgFirstWinReward.OnUpdateUI(self.FirstWinId);
        }

        public static async ETTask OnButton_FirstWinSelfButton(this ES_FirstWin self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_FirstWinReward);
            DlgFirstWinReward dlgFirstWinReward = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgFirstWinReward>();
            dlgFirstWinReward.OnUpdateUISelf(self.FirstWinId);
        }

        public static async ETTask ReqestFirstWinInfo(this ES_FirstWin self)
        {
            try
            {
                long instance = self.InstanceId;
                A2C_FirstWinInfoResponse response = await ActivityNetHelper.FirstWinInfo(self.Root());
                if (instance != self.InstanceId)
                {
                    return;
                }
                
                self.FirstWinInfos = response.FirstWinInfos;
                KeyValuePairInt keyValuePairInt = FirstWinConfigCategory.Instance.GetBossChapter(self.BossId);
                if (keyValuePairInt != null)
                {
                    self.UITypeViewComponent.OnInitUI(keyValuePairInt.KeyId - 1, (int)keyValuePairInt.Value).Coroutine();
                }
                else
                {
                    self.UITypeViewComponent.OnInitUI().Coroutine();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }
        }

        public static List<TypeButtonInfo> InitTypeButtonInfos(this ES_FirstWin self)
        {
            Dictionary<int, List<int>> keyValuePairs = self.GetFirstWinList();

            List<TypeButtonInfo> typeButtonInfos = new List<TypeButtonInfo>();

            foreach (var item in keyValuePairs)
            {
                List<TypeButtonItem> typeButtonItems = new List<TypeButtonItem>();
                for (int b = 0; b < item.Value.Count; b++)
                {
                    int bossId = FirstWinConfigCategory.Instance.Get(item.Value[b]).BossID;
                    typeButtonItems.Add(new TypeButtonItem()
                    {
                        SubTypeId = item.Value[b], ItemName = MonsterConfigCategory.Instance.Get(bossId).MonsterName
                    });
                }

                using (zstring.Block())
                {
                    typeButtonInfos.Add(new TypeButtonInfo()
                            { TypeId = item.Key, TypeName = zstring.Format("第{0}章", item.Key), typeButtonItems = typeButtonItems });
                }
            }

            return typeButtonInfos;
        }

        public static Dictionary<int, List<int>> GetFirstWinList(this ES_FirstWin self)
        {
            Dictionary<int, List<int>> keyValuePairs = new Dictionary<int, List<int>>();
            List<FirstWinConfig> firstWinConfigs = FirstWinConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < firstWinConfigs.Count; i++)
            {
                FirstWinConfig firstWinConfig = firstWinConfigs[i];
                if (!keyValuePairs.ContainsKey(firstWinConfig.ChatperId))
                {
                    keyValuePairs.Add(firstWinConfig.ChatperId, new List<int>());
                }

                keyValuePairs[firstWinConfig.ChatperId].Add(firstWinConfig.Id);
            }

            return keyValuePairs;
        }

        public static void OnClickTypeItem(this ES_FirstWin self, int typeid, int firstwinId)
        {
            if (self.FirstWinId == firstwinId)
            {
                return;
            }

            if (TimeHelper.ServerNow() - self.LastUpdateTime < 500)
            {
                return;
            }

            self.LastUpdateTime = TimeHelper.ServerNow();
            self.FirstWinId = firstwinId;
            self.ChapterId = typeid;

            self.UpdateBossInfo(firstwinId);
        }

        public static FirstWinInfo GetFirstWinInfo(this ES_FirstWin self, int firstWinId, int difficulty)
        {
            for (int i = 0; i < self.FirstWinInfos.Count; i++)
            {
                if (self.FirstWinInfos[i].FirstWinId == firstWinId
                    && self.FirstWinInfos[i].Difficulty == difficulty)
                {
                    return self.FirstWinInfos[i];
                }
            }

            return null;
        }

        public static void UpdateBossInfo(this ES_FirstWin self, int firstwinId)
        {
            if (firstwinId == 0)
            {
                return;
            }

            int bossId = FirstWinConfigCategory.Instance.Get(firstwinId).BossID;
            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(bossId);
            self.E_Text_BossNameText.text = monsterConfig.MonsterName;
            using (zstring.Block())
            {
                self.E_Text_LvText.text = zstring.Format("等级:{0}", monsterConfig.Lv);
            }

            int[] skillIds = monsterConfig.SkillID;
            for (int i = 0; i < skillIds.Length; i++)
            {
                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillIds[i]);
                using (zstring.Block())
                {
                    string str = zstring.Format("{0}:{1}", skillConfig.SkillName, skillConfig.SkillDescribe);
                    float height = (str.Length / 30 + 1) * 40; // 16个字一行

                    if (i == 0)
                    {
                        self.SkillDescriptionList[i].GetComponent<RectTransform>().sizeDelta = new Vector2(750, height);
                        self.SkillDescriptionList[i].GetComponent<Text>().text = str;
                    }
                    else
                    {
                        if (self.SkillDescriptionList.Count > i)
                        {
                            self.SkillDescriptionList[i].GetComponent<RectTransform>().sizeDelta = new Vector2(750, height);
                            self.SkillDescriptionList[i].GetComponent<Text>().text = str;
                            self.SkillDescriptionList[i].SetActive(true);
                        }
                        else
                        {
                            GameObject obj = UnityEngine.Object.Instantiate(self.E_SkillDescriptionItemTextText.gameObject);
                            obj.SetActive(true);
                            CommonViewHelper.SetParent(obj, self.EG_SkillDescriptionListNodeRectTransform.gameObject);
                            self.SkillDescriptionList.Add(obj);
                            obj.GetComponent<RectTransform>().sizeDelta = new Vector2(750, height);
                            obj.GetComponent<Text>().text = str;
                        }
                    }
                }
            }

            if (self.SkillDescriptionList.Count > skillIds.Length)
            {
                for (int i = skillIds.Length; i < self.SkillDescriptionList.Count; i++)
                {
                    self.SkillDescriptionList[i].SetActive(false);
                }
            }

            // self.ES_ModelShow.ShowOtherModel("Monster/" + monsterConfig.MonsterModelID.ToString()).Coroutine();
            self.ES_ModelShow.ShowOtherModel("Monster/70001001").Coroutine();

            string skilldesc = "";
            int[] skilllist = monsterConfig.SkillID;
            for (int i = 0; i < skilllist.Length; i++)
            {
                if (skilllist[i] == 0)
                {
                    continue;
                }

                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skilllist[i]);
                using (zstring.Block())
                {
                    skilldesc += zstring.Format("{1} {2}\n", skillConfig.SkillName, skillConfig.SkillDescribe);
                }
            }

            self.E_Text_SkillJieShaoText.text = skilldesc;
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            bool noupdatestatus = userInfoComponent.GetReviveTime(bossId) > TimeHelper.ServerNow();
            DateTime dateTime = TimeInfo.Instance.ToDateTime(userInfoComponent.GetReviveTime(bossId));
            using (zstring.Block())
            {
                self.E_Text_UpdateStatusText.text = noupdatestatus ? zstring.Format("下次刷新时间\n{0}", dateTime.ToString()) : "(已刷新)";
            }

            self.E_Text_UpdateStatusText.color =
                    noupdatestatus ? new Color(164f / 255, 66f / 255f, 8f / 255f) : new Color(25f / 255, 180f / 255f, 25f / 255f);

            int killNumber = userInfoComponent.GetMonsterKillNumber(bossId);
            BossDevelopment bossDevelopment = ConfigHelper.GetBossDevelopmentByKill(self.ChapterId, killNumber);
            BossDevelopment bossDevelopmentNext = ConfigHelper.GetBossDevelopmentById(self.ChapterId, bossDevelopment.Level + 1);
            if (bossDevelopmentNext == null)
            {
                using (zstring.Block())
                {
                    self.E_Text_BossDevpText.text = zstring.Format("{0}", bossDevelopment.Name);
                }

                self.E_ImageProgressImage.fillAmount = 1f;
            }
            else
            {
                using (zstring.Block())
                {
                    self.E_Text_BossDevpText.text = zstring.Format("领主升级: {0}/{1}", killNumber, bossDevelopmentNext.KillNumber);
                }

                self.E_ImageProgressImage.fillAmount = killNumber * 1f / bossDevelopmentNext.KillNumber;
            }

            using (zstring.Block())
            {
                self.E_Text_BossExpText.text = zstring.Format("怪物经验:{0}", 1f * bossDevelopment.ExpAdd * monsterConfig.Exp);
                self.E_Text_BossDevpNameText.text = bossDevelopment.Name;
                long cdTime = (long)(monsterConfig.ReviveTime * 1000 * bossDevelopment.ReviveTimeAdd);
                self.E_Text_BossFreshTImeText.text = zstring.Format("冷却时间:{0}", TimeHelper.ShowLeftTime(cdTime));
            }

            List<RewardItem> droplist = DropHelper.Show_MonsterDrop(monsterConfig.Id, 1f, true);
            List<int> itemIdList = new List<int>();
            for (int i = droplist.Count - 1; i >= 0; i--)
            {
                if (itemIdList.Contains(droplist[i].ItemID))
                {
                    droplist.RemoveAt(i);
                    continue;
                }

                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(droplist[i].ItemID);
                if (itemConfig.ItemQuality < 4)
                {
                    droplist.RemoveAt(i);
                    continue;
                }

                itemIdList.Add(droplist[i].ItemID);
            }

            self.ES_RewardList.Refresh(droplist);

            FirstWinInfo firstWinInfo_1 = self.GetFirstWinInfo(firstwinId, 1);
            FirstWinInfo firstWinInfo_2 = self.GetFirstWinInfo(firstwinId, 2);
            FirstWinInfo firstWinInfo_3 = self.GetFirstWinInfo(firstwinId, 3);
            self.ShowJiShaTime(firstWinInfo_1, self.E_Text_JiSha_1Text.gameObject);
            self.ShowJiShaTime(firstWinInfo_2, self.E_Text_JiSha_2Text.gameObject);
            self.ShowJiShaTime(firstWinInfo_3, self.E_Text_JiSha_3Text.gameObject);
        }

        public static void ShowJiShaTime(this ES_FirstWin self, FirstWinInfo firstWinInfo, GameObject Text_JiSha_1)
        {
            if (firstWinInfo != null)
            {
                using (zstring.Block())
                {
                    Text_JiSha_1.GetComponent<Text>().text =
                            zstring.Format("{0} (时间： {1})", firstWinInfo.PlayerName, TimeInfo.Instance.ToDateTime(firstWinInfo.KillTime).ToString());
                }
            }
            else
            {
                Text_JiSha_1.GetComponent<Text>().text = "暂无上榜!";
            }
        }
    }
}
