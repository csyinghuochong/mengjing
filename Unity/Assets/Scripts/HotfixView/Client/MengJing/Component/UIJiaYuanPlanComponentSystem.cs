using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [Invoke(TimerInvokeType.JiaYuanPlanTimer)]
    public class JiaYuanPlanTimer : ATimer<UIJiaYuanPlanComponent>
    {
        protected override void Run(UIJiaYuanPlanComponent self)
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

    [FriendOf(typeof(UIJiaYuanPlanComponent))]
    [EntitySystemOf(typeof(UIJiaYuanPlanComponent))]
    public static partial class UIJiaYuanPlanComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIJiaYuanPlanComponent self)
        {
            self.GameObject = null;
            self.PlanStage = -1;
            self.UICamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            self.MainCamera = self.Root().GetComponent<GlobalComponent>().MainCamera.GetComponent<Camera>();

            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.JiaYuanPlanTimer, self);

            self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this UIJiaYuanPlanComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static void OnInitUI(this UIJiaYuanPlanComponent self)
        {
            Unit unit = self.GetParent<Unit>();
            self.NumericComponent = unit.GetComponent<NumericComponentC>();
            self.PlanStage = self.GetPlanStage();

            self.UIPosition = unit.GetComponent<GameObjectComponent>().GameObject.transform.Find("Head");
            string path = ABPathHelper.GetUGUIPath("Blood/UIEnergyTable");
            GameObject prefab = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
            self.GameObject = UnityEngine.Object.Instantiate(prefab, GlobalComponent.Instance.BloodMonster.transform);
            self.GameObject.transform.localScale = Vector3.one;
            self.HeadBarUI = self.GameObject.GetComponent<HeadBarUI>();
            self.HeadBarUI.enabled = true;
            self.HeadBarUI.HeadPos = self.UIPosition;
            self.HeadBarUI.HeadBar = self.GameObject;
            self.GameObject.transform.SetAsFirstSibling();
            self.UpdateShouHuoTime();
            JiaYuanFarmConfig jiaYuanFarmConfig = JiaYuanFarmConfigCategory.Instance.Get(unit.ConfigId);
            self.GameObject.Get<GameObject>("Lal_Name").GetComponent<Text>().text = jiaYuanFarmConfig.Name;
        }

        public static int GetPlanStage(this UIJiaYuanPlanComponent self)
        {
            Unit unit = self.GetParent<Unit>();
            long startTime = self.NumericComponent.GetAsLong(NumericType.StartTime);
            int gatherNumber = self.NumericComponent.GetAsInt(NumericType.GatherNumber);
            return ET.JiaYuanHelper.GetPlanStage(unit.ConfigId, startTime, gatherNumber);
        }

        public static void OnTimer(this UIJiaYuanPlanComponent self)
        {
            self.UpdateShouHuoTime();
            int state = self.GetPlanStage();
            if (state != self.PlanStage)
            {
                self.PlanStage = state;
                Unit unit = self.GetParent<Unit>();
                unit.GetComponent<GameObjectComponent>().OnUpdatePlan();
            }
        }

        public static void UpdateShouHuoTime(this UIJiaYuanPlanComponent self)
        {
            if (self.GameObject == null)
            {
                return;
            }

            Unit unit = self.GetParent<Unit>();
            NumericComponentC numericComponent = self.NumericComponent;
            long startTime = numericComponent.GetAsLong(NumericType.StartTime);
            int gatherNumber = numericComponent.GetAsInt(NumericType.GatherNumber);
            long gatherLastTime = numericComponent.GetAsLong(NumericType.GatherLastTime);
            if (ET.JiaYuanHelper.GetPlanShouHuoItem(unit.ConfigId, startTime, gatherNumber, gatherLastTime) == 0)
            {
                self.GameObject.Get<GameObject>("Lal_Desc").GetComponent<Text>().text = "可收获";
                self.GameObject.Get<GameObject>("Lal_Desc").GetComponent<Text>().color = new Color(170f / 255f, 1, 0);
            }
            else
            {
                if (self.PlanStage == 3)
                {
                    long shouhuoTime = ET.JiaYuanHelper.GetPlanNextShouHuoTime(unit.ConfigId, startTime, gatherNumber, gatherLastTime);
                    System.TimeSpan chaDate = TimeInfo.Instance.ToDateTime(shouhuoTime) - TimeHelper.DateTimeNow();
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
                    self.GameObject.Get<GameObject>("Lal_Desc").GetComponent<Text>().text = ET.JiaYuanHelper.GetPlanStageName(self.PlanStage);
                }
            }
        }
    }
}