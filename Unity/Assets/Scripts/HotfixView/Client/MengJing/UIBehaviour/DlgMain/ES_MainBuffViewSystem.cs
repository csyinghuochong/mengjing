using System;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(UIMainBuffItemComponent))]
    [EntitySystemOf(typeof(ES_MainBuff))]
    [FriendOfAttribute(typeof(ES_MainBuff))]
    public static partial class ES_MainBuffSystem
    {
        [Invoke(TimerInvokeType.MainBuffTimer)]
        public class MainBuffTimer : ATimer<ES_MainBuff>
        {
            protected override void Run(ES_MainBuff self)
            {
                try
                {
                    self.OnUpdate();
                }
                catch (Exception e)
                {
                    using (zstring.Block())
                    {
                        Log.Error(zstring.Format("move timer error: {0}\n{1}", self.Id, e.ToString()));
                    }
                }
            }
        }

        [EntitySystem]
        private static void Awake(this ES_MainBuff self, Transform transform)
        {
            self.uiTransform = transform;
            ReferenceCollector rc = transform.GetComponent<ReferenceCollector>();
            self.UIMainBuffItem = rc.Get<GameObject>("UIMainBuffItem");
            self.UIMainBuffItem.SetActive(false);
        }

        [EntitySystem]
        private static void Destroy(this ES_MainBuff self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            self.DestroyWidget();
        }

        public static void InitMainHero(this ES_MainBuff self)
        {
            Unit main = UnitHelper.GetMyUnitFromClientScene(self.Root());
            BuffManagerComponentC buffManagerComponentC = main.GetComponent<BuffManagerComponentC>();
            for (int i = 0;i < buffManagerComponentC.m_Buffs.Count; i++)
            {
                self.OnAddBuff(buffManagerComponentC.m_Buffs[i]);
            }
        }

        public static void OnUpdate(this ES_MainBuff self)
        {
            int buffcnt = self.MainBuffUIList.Count;
            for (int i = buffcnt - 1; i >= 0; i--)
            {
                UIMainBuffItemComponent uIMainBuffItemComponent = self.MainBuffUIList[i];
                bool update = uIMainBuffItemComponent.OnUpdate();
                if (!update)
                {
                    uIMainBuffItemComponent.BeforeRemove();
                    uIMainBuffItemComponent.BuffID = 0;

                    UIMainBuffItemComponent uiMainBuffItemComponent = self.MainBuffUIList[i];
                    uiMainBuffItemComponent.GameObject.SetActive(false);

                    self.CacheUIList.Add(self.MainBuffUIList[i]);
                    self.MainBuffUIList.RemoveAt(i);
                }
            }

            if (self.MainBuffUIList.Count == 0)
            {
                self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            }
        }

        public static void OnBuffUpdate(this ES_MainBuff self, BuffC aBuffHandler, int operatetype)
        {
            //1添加  2移除 3重置

            switch (operatetype)
            {
                case 1:
                    self.OnAddBuff(aBuffHandler);
                    break;
                case 2:
                    self.OnRemoveBuff(aBuffHandler);
                    break;
                case 3:
                    self.OnResetBuff(aBuffHandler);
                    break;
            }
        }

        public static void ResetUI(this ES_MainBuff self)
        {
            for (int i = 0; i < self.MainBuffUIList.Count; i++)
            {
                UIMainBuffItemComponent uiMainBuffItemComponent = self.MainBuffUIList[i];
                uiMainBuffItemComponent.BuffID = 0;
                uiMainBuffItemComponent.GameObject.SetActive(false);

                self.CacheUIList.Add(self.MainBuffUIList[i]);
            }

            self.MainBuffUIList.Clear();
            if (self.MainBuffUIList.Count == 0)
            {
                self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            }
        }

        public static void OnAddBuff(this ES_MainBuff self, BuffC buffHandler)
        {
            if (self.MainBuffUIList.Count >= 8 || buffHandler.mSkillBuffConf.IfShowIconTips == 0)
            {
                return;
            }

            if (!self.AddSameBuff(buffHandler))
            {
                UIMainBuffItemComponent ui_buff = self.CacheUIList.Count > 0 ? self.CacheUIList[0] : null;
                if (ui_buff == null)
                {
                    ui_buff = self.AddChild<UIMainBuffItemComponent, GameObject>(GameObject.Instantiate(self.UIMainBuffItem));
                }
                else
                {
                    self.CacheUIList.RemoveAt(0);
                }

                self.MainBuffUIList.Add(ui_buff);
                ui_buff.GameObject.SetActive(true);
                ui_buff.OnAddBuff(buffHandler);
                CommonViewHelper.SetParent(ui_buff.GameObject, self.uiTransform.gameObject);
            }

            if (self.Timer == 0)
            {
                self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(500, TimerInvokeType.MainBuffTimer, self);
            }
        }

        public static bool AddSameBuff(this ES_MainBuff self, BuffC buffHandler)
        {
            for (int i = 0; i < self.MainBuffUIList.Count; i++)
            {
                UIMainBuffItemComponent uIMainBuffItemComponent = self.MainBuffUIList[i];
                if (uIMainBuffItemComponent.BuffID == buffHandler.BuffData.BuffId && uIMainBuffItemComponent.UnitId == buffHandler.TheUnitBelongto.Id)
                {
                    uIMainBuffItemComponent.UpdateBuffNumber(buffHandler, 0);
                    uIMainBuffItemComponent.EndTime = buffHandler.BuffEndTime;
                    return true;
                }
            }

            return false;
        }

        public static bool HaveSameBuff(this ES_MainBuff self, int buffID)
        {
            for (int i = 0; i < self.MainBuffUIList.Count; i++)
            {
                UIMainBuffItemComponent uIMainBuffItemComponent = self.MainBuffUIList[i];
                if (uIMainBuffItemComponent.BuffID == buffID)
                {
                    return true;
                }
            }

            return false;
        }

        public static void OnResetBuff(this ES_MainBuff self, BuffC buffHandler)
        {
            for (int i = 0; i < self.MainBuffUIList.Count; i++)
            {
                UIMainBuffItemComponent uIMainBuffItemComponent = self.MainBuffUIList[i];
                if (uIMainBuffItemComponent.BuffID == buffHandler.BuffData.BuffId)
                {
                    uIMainBuffItemComponent.OnResetBuff(buffHandler);
                }
            }
        }

        public static void OnRemoveBuff(this ES_MainBuff self, BuffC buffHandler)
        {
            for (int i = self.MainBuffUIList.Count - 1; i >= 0; i--)
            {
                UIMainBuffItemComponent uIMainBuffItemComponent = self.MainBuffUIList[i];
                if (uIMainBuffItemComponent.BuffID == buffHandler.BuffData.BuffId)
                {
                    uIMainBuffItemComponent.UpdateBuffNumber(buffHandler, -1);
                }
            }

            self.OnUpdate();
        }
    }
}