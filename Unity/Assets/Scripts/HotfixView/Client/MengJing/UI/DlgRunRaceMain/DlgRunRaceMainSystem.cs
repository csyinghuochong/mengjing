using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class OnSkillUse_DlgRunRaceMainRefresh : AEvent<Scene, OnSkillUse>
    {
        protected override async ETTask Run(Scene scene, OnSkillUse args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgRunRaceMain>()?.OnSkillUse(args.SkillId);
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class UpdateUserBuffSkill_DlgRunRaceMainRefresh : AEvent<Scene, UpdateUserBuffSkill>
    {
        protected override async ETTask Run(Scene scene, UpdateUserBuffSkill args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgRunRaceMain>()?.OnUpdateUserBuffSkill(args.UpdateValue);
            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof(DlgRunRaceMainViewComponent))]
    [FriendOf(typeof(ES_SkillGrid))]
    [FriendOf(typeof(DlgRunRaceMain))]
    public static class DlgRunRaceMainSystem
    {
        public static void RegisterUIEvent(this DlgRunRaceMain self)
        {
            self.Rankings.Add(self.View.EG_PlayerInfoItem_1RectTransform.gameObject);
            self.Rankings.Add(self.View.EG_PlayerInfoItem_2RectTransform.gameObject);
            self.Rankings.Add(self.View.EG_PlayerInfoItem_3RectTransform.gameObject);
            self.Rankings.Add(self.View.EG_PlayerInfoItem_OtherRectTransform.gameObject);

            self.View.EG_PlayerInfoItem_1RectTransform.gameObject.SetActive(false);
            self.View.EG_PlayerInfoItem_2RectTransform.gameObject.SetActive(false);
            self.View.EG_PlayerInfoItem_3RectTransform.gameObject.SetActive(false);
            self.View.EG_PlayerInfoItem_OtherRectTransform.gameObject.SetActive(false);

            FuntionConfig funtionConfig = FuntionConfigCategory.Instance.Get(1058);
            string[] openTimes = funtionConfig.OpenTime.Split('@');
            self.ReadyTime = (int.Parse(openTimes[1].Split(';')[0]) * 60 + int.Parse(openTimes[1].Split(';')[1])) * 60;
            self.EndTime = (int.Parse(openTimes[2].Split(';')[0]) * 60 + int.Parse(openTimes[2].Split(';')[1])) * 60;

            self.UISkillGrids.Clear();

            ES_MainSkill esMainSkill = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>().View.ES_MainSkill;

            ES_SkillGrid uiSkillGridComponent_1 = self.AddChild<ES_SkillGrid, Transform>(esMainSkill.ES_SkillGrid_Transforms_1.uiTransform);
            uiSkillGridComponent_1.SkillCancelHandler = self.ShowCancelButton;
            uiSkillGridComponent_1.UseSkillHandler = self.OnUseSkill;
            uiSkillGridComponent_1.uiTransform.gameObject.SetActive(false);
            uiSkillGridComponent_1.Index = 0;
            self.UISkillGrids.Add(uiSkillGridComponent_1);

            ES_SkillGrid uiSkillGridComponent_2 = self.AddChild<ES_SkillGrid, Transform>(esMainSkill.ES_SkillGrid_Transforms_2.uiTransform);
            uiSkillGridComponent_2.SkillCancelHandler = self.ShowCancelButton;
            uiSkillGridComponent_2.UseSkillHandler = self.OnUseSkill;
            uiSkillGridComponent_2.uiTransform.gameObject.SetActive(false);
            uiSkillGridComponent_2.Index = 1;
            self.UISkillGrids.Add(uiSkillGridComponent_2);
            
            self.OnInitUI();
            self.UpdateRanking().Coroutine();
            self.ShoweEndTime().Coroutine();
        }

        public static void ShowWindow(this DlgRunRaceMain self, Entity contextData = null)
        {
        }

        public static void OnUseSkill(this DlgRunRaceMain self, int index)
        {
            self.Index = index;
        }

        public static void OnSkillUse(this DlgRunRaceMain self, long skillId)
        {
            for (int i = 0; i < self.UISkillGrids.Count; i++)
            {
                ES_SkillGrid esSkillGrid = self.UISkillGrids[i];

                if (esSkillGrid.SkillPro == null)
                {
                    continue;
                }

                if (esSkillGrid.SkillPro.SkillID != skillId)
                {
                    continue;
                }

                if (i == self.Index || i == self.UISkillGrids.Count - 1)
                {
                    esSkillGrid.RemoveSkillInfoShow();
                    esSkillGrid.uiTransform.gameObject.SetActive(false);
                    break;
                }
            }
        }

        public static void OnUpdateUserBuffSkill(this DlgRunRaceMain self, long skillId)
        {
            int addIndex = 0;
            for (int i = 0; i < self.UISkillGrids.Count; i++)
            {
                ES_SkillGrid esSkillGrid = self.UISkillGrids[i];
                if (esSkillGrid.uiTransform.gameObject.activeSelf)
                {
                    continue;
                }

                addIndex = i;

                break;
            }

            ES_SkillGrid grid = self.UISkillGrids[addIndex];
            grid.uiTransform.gameObject.SetActive(true);
            SkillPro skillPro = SkillPro.Create();
            skillPro.SkillID = (int)skillId;
            skillPro.SkillSetType = (int)SkillSetEnum.Skill;
            skillPro.SkillSource = (int)SkillSourceEnum.Buff;
            grid.UpdateSkillInfo(skillPro);

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            FunctionEffect.PlaySelfEffect(unit, 60000002);
        }

        public static void OnInitUI(this DlgRunRaceMain self)
        {
            BattleMessageComponent battleMessageComponent = self.Root().GetComponent<BattleMessageComponent>();
            self.UpdateNextTransformTime(battleMessageComponent.M2C_RunRaceBattleInfo);
        }

        public static async ETTask ShoweEndTime(this DlgRunRaceMain self)
        {
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            while (!self.IsDisposed)
            {
                DateTime dateTime = TimeInfo.Instance.ToDateTime(TimeHelper.ServerNow());
                long curTime = (dateTime.Hour * 60 + dateTime.Minute) * 60 + dateTime.Second;
                long endTime = self.EndTime - curTime;
                long leftTime = (self.NextTransformTime - TimeHelper.ServerNow()) / 1000;

                long readyTime = self.ReadyTime - curTime;
                if (readyTime > 0)
                {
                    using (zstring.Block())
                    {
                        self.View.E_ReadyTimeTextText.text = zstring.Format($"奔跑准备时间 {0}:{1}", readyTime / 60, readyTime % 60);
                    }

                    self.View.E_TransformTimeTextText.text = string.Empty;
                }
                else if (endTime > 0)
                {
                    using (zstring.Block())
                    {
                        self.View.E_ReadyTimeTextText.text = zstring.Format("活动结束倒计时 {0}:{1}", endTime / 60, endTime % 60);
                        self.View.E_TransformTimeTextText.text = zstring.Format("下次变身时间:  {0}:{1}", leftTime / 60, leftTime % 60);
                    }
                }

                await timerComponent.WaitAsync(1000);
                if (self.IsDisposed)
                {
                    break;
                }
            }
        }

        public static void UpdateNextTransformTime(this DlgRunRaceMain self, M2C_RunRaceBattleInfo message)
        {
            using (zstring.Block())
            {
                Log.Debug(zstring.Format("下次变身时间:  {0}", message.NextTransforTime - TimeHelper.ServerNow()));
            }

            self.NextTransformTime = message.NextTransforTime;
        }

        public static async ETTask UpdateRanking(this DlgRunRaceMain self)
        {
            long instacnid = self.InstanceId;
            R2C_RankRunRaceResponse response = await ActivityNetHelper.RankRunRaceRequest(self.Root());

            if (instacnid != self.InstanceId)
            {
                return;
            }

            self.View.uiTransform.SetAsFirstSibling();
            if (response.RankList == null || response.RankList.Count < 1)
            {
                return;
            }

            self.UpdateRanking(response.RankList);
            await ETTask.CompletedTask;
        }

        public static async ETTask WaitExitFuben(this DlgRunRaceMain self)
        {
            long instanceid = self.InstanceId;
            await self.Root().GetComponent<TimerComponent>().WaitAsync(TimeHelper.Second * 5);
            if (instanceid != self.InstanceId)
            {
                return;
            }

            EnterMapHelper.RequestQuitFuben(self.Root());
        }

        public static void ShowPlayerInfo(this DlgRunRaceMain self, int i, GameObject gameObject, RankingInfo rankingInfo)
        {
            if (rankingInfo.PlayerLv < 0)
            {
                using (zstring.Block())
                {
                    gameObject.GetComponentInChildren<Text>().text = zstring.Format("第{0}名 {1}  还剩:{2}", i + 1, rankingInfo.PlayerName,
                        (rankingInfo.Combat * 0.01).ToString());
                }
            }
            else
            {
                DateTime dateTime = TimeInfo.Instance.ToDateTime(rankingInfo.Combat);
                using (zstring.Block())
                {
                    string showTime = zstring.Format("{0}:{1}:{2}", dateTime.Hour, dateTime.Minute, dateTime.Second);
                    gameObject.GetComponentInChildren<Text>().text = zstring.Format("第{0}名 {1}  时间:{2}", i + 1, rankingInfo.PlayerName, showTime);
                }
            }
        }

        public static void UpdateRanking(this DlgRunRaceMain self, List<RankingInfo> rankingInfos)
        {
            int num = 0;
            for (int i = 0; i < rankingInfos.Count; i++)
            {
                if (i == 0)
                {
                    self.ShowPlayerInfo(i, self.View.EG_PlayerInfoItem_1RectTransform.gameObject, rankingInfos[i]);
                    self.View.EG_PlayerInfoItem_1RectTransform.gameObject.SetActive(true);
                }
                else if (i == 1)
                {
                    self.ShowPlayerInfo(i, self.View.EG_PlayerInfoItem_2RectTransform.gameObject, rankingInfos[i]);
                    self.View.EG_PlayerInfoItem_1RectTransform.gameObject.SetActive(true);
                }
                else if (i == 2)
                {
                    self.ShowPlayerInfo(i, self.View.EG_PlayerInfoItem_3RectTransform.gameObject, rankingInfos[i]);
                    self.View.EG_PlayerInfoItem_1RectTransform.gameObject.SetActive(true);
                }
                else
                {
                    if (num < self.Rankings.Count)
                    {
                        self.ShowPlayerInfo(i, self.Rankings[i], rankingInfos[i]);
                        self.Rankings[i].SetActive(true);
                    }
                    else
                    {
                        GameObject go = UnityEngine.Object.Instantiate(self.View.EG_PlayerInfoItem_OtherRectTransform.gameObject);
                        self.ShowPlayerInfo(i, go, rankingInfos[i]);
                        go.SetActive(true);
                        CommonViewHelper.SetParent(go, self.View.EG_RankingListNodeRectTransform.gameObject);
                        self.Rankings.Add(go);
                    }
                }

                num++;
            }

            for (int i = num; i < self.Rankings.Count; i++)
            {
                self.Rankings[i].SetActive(false);
            }
        }

        public static void ShowCancelButton(this DlgRunRaceMain self, bool show)
        {
        }
    }
}
