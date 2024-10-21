using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(UIJiaYuanPastureComponent))]
    [EntitySystemOf(typeof(UIJiaYuanPastureComponent))]
    public static partial class UIJiaYuanPastureComponentSystem
    {
        [Invoke(TimerInvokeType.JiaYuanPastureTimer)]
        public class JiaYuanPastureTimer : ATimer<UIJiaYuanPastureComponent>
        {
            protected override void Run(UIJiaYuanPastureComponent self)
            {
                try
                {
                    self.OnTimer();
                }
                catch (Exception e)
                {
                    Log.Error($"move timer error: {self.Id}\n{e}");
                }
            }
        }

        [EntitySystem]
        private static void Awake(this UIJiaYuanPastureComponent self)
        {
            self.GameObject = null;
            self.PlanStage = -1;
            self.MainUnitEnter = false;

            self.MainUnitExit = false;
            self.EnterPassTime = 0f;
            self.MyUnit = self.GetParent<Unit>();

            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.JiaYuanPastureTimer, self);
            self.OnInitUI().Coroutine();
        }

        [EntitySystem]
        private static void Destroy(this UIJiaYuanPastureComponent self)
        {
            if (self.GameObject != null)
            {
                UnityEngine.Object.Destroy(self.GameObject);
                self.GameObject = null;
            }

            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static async ETTask OnInitUI(this UIJiaYuanPastureComponent self)
        {
            string path = ABPathHelper.GetUGUIPath("Blood/UISceneItem");
            Unit myUnit = self.MyUnit;
            self.UIPosition = myUnit.GetComponent<GameObjectComponent>().GameObject.transform.Find("NamePosi");
            GameObject prefab = await ResourcesComponent.Instance.LoadAssetAsync<GameObject>(path);
            self.GameObject = UnityEngine.Object.Instantiate(prefab, GlobalComponent.Instance.Unit, true);
            self.GameObject.transform.SetParent(GlobalComponent.Instance.BloodMonster.transform);
            self.GameObject.transform.localScale = Vector3.one;

            self.HeadBarUI = self.GameObject.GetComponent<HeadBarUI>();
            self.HeadBarUI.enabled = true;
            self.HeadBarUI.HeadPos = self.UIPosition;
            self.HeadBarUI.HeadBar = self.GameObject;
            self.GameObject.transform.SetAsFirstSibling();

            self.NumericComponent = self.GetParent<Unit>().GetComponent<NumericComponentC>();
            int configId = myUnit.ConfigId;
            JiaYuanPastureConfig jiaYuanFarmConfig = JiaYuanPastureConfigCategory.Instance.Get(configId);
            self.GameObject.Get<GameObject>("Lal_Name").GetComponent<Text>().text = jiaYuanFarmConfig.Name;
            self.OnUpdateUI();
        }

        public static void OnTimer(this UIJiaYuanPastureComponent self)
        {
            self.OnUpdateUI();
        }

        public static void OnUpdateNpcTalk(this UIJiaYuanPastureComponent self, Unit mainUnit)
        {
            if (self.GameObject == null)
            {
                return;
            }

            Unit unit = self.GetParent<Unit>();
            float distance = PositionHelper.Distance2D(mainUnit.Position, unit.Position);
            if (distance < 3f && !self.MainUnitEnter)
            {
                self.MainUnitEnter = true;
                self.MainUnitExit = false;

                JiaYuanPastureConfig jiaYuanPastureConfig = JiaYuanPastureConfigCategory.Instance.Get(unit.ConfigId);
                self.GameObject.Get<GameObject>("TalkNode").SetActive(true);
                self.GameObject.Get<GameObject>("Lal_Talk").GetComponent<Text>().text = $"{jiaYuanPastureConfig.Speak}";
            }

            if (distance > 3f && !self.MainUnitExit)
            {
                self.MainUnitEnter = false;
                self.MainUnitExit = true;
                self.EnterPassTime = 0f;
                self.GameObject.Get<GameObject>("TalkNode").SetActive(false);
            }

            if (self.MainUnitEnter)
            {
                self.EnterPassTime += Time.deltaTime;
            }

            if (self.MainUnitEnter && self.EnterPassTime >= 3f)
            {
                self.GameObject.Get<GameObject>("TalkNode").SetActive(false);
            }
        }

        public static void OnUpdateUI(this UIJiaYuanPastureComponent self)
        {
            if (self.GameObject == null)
            {
                return;
            }

            NumericComponentC numericComponent = self.NumericComponent;
            long startTime = numericComponent.GetAsLong(NumericType.StartTime);
            int gatherNumber = numericComponent.GetAsInt(NumericType.GatherNumber);
            long gatherLastTime = numericComponent.GetAsLong(NumericType.GatherLastTime);
            int stage = ET.JiaYuanHelper.GetPastureState(self.GetParent<Unit>().ConfigId, startTime, gatherNumber);

            if (ET.JiaYuanHelper.GetPastureShouHuoItem(self.GetParent<Unit>().ConfigId, startTime, gatherNumber, gatherLastTime) == 0)
            {
                self.GameObject.Get<GameObject>("Lal_Desc").GetComponent<Text>().text = "可收获";
                self.GameObject.Get<GameObject>("Lal_Desc").GetComponent<Text>().color = new Color(170f / 255f, 1, 0);
            }
            else
            {
                if (stage == 3)
                {
                    long shouhuoTime =
                            ET.JiaYuanHelper.GetPastureNextShouHuoTime(self.GetParent<Unit>().ConfigId, startTime, gatherNumber, gatherLastTime);
                    TimeSpan chaDate = TimeInfo.Instance.ToDateTime(shouhuoTime) - TimeHelper.DateTimeNow();
                    string showStr = String.Empty;
                    if (chaDate.Days > 0)
                    {
                        showStr = chaDate.Days + "天" + chaDate.Hours + "时" + chaDate.Minutes + "分" + chaDate.Seconds + "秒";
                    }
                    else
                    {
                        showStr = chaDate.Hours + "时" + chaDate.Minutes + "分" + chaDate.Seconds + "秒";
                    }

                    self.GameObject.Get<GameObject>("Lal_Desc").GetComponent<Text>().text = $"收获计时: {showStr}";
                }
                else
                {
                    self.GameObject.Get<GameObject>("Lal_Desc").GetComponent<Text>().text = ET.JiaYuanHelper.GetPastureStageName(stage);
                }
            }

            if (self.PlanStage != stage)
            {
                GameObject gameObject = self.GetParent<Unit>().GetComponent<GameObjectComponent>().GameObject;
                gameObject.transform.localScale = ET.JiaYuanHelper.GetPastureStageScale(stage) * Vector3.one;
            }

            self.PlanStage = stage;
        }
    }
}