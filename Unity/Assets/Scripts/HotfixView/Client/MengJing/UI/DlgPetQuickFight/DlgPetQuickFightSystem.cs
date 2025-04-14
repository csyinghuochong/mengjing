using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ET.Client
{
    [Invoke(TimerInvokeType.PetQuickFightTimer)]
    public class PetQuickFightTimer : ATimer<DlgPetQuickFight>
    {
        protected override void Run(DlgPetQuickFight self)
        {
            try
            {
                self.OnTimer();
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

    [FriendOf(typeof(Scroll_Item_PetQuickFightItem))]
    [FriendOf(typeof(DlgPetQuickFight))]
    public static class DlgPetQuickFightSystem
    {
        public static void RegisterUIEvent(this DlgPetQuickFight self)
        {
            self.View.E_PetQuickFightItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPetQuickFightItemsRefresh);

            self.View.E_ImageButtonButton.AddListener(() =>
            {
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetQuickFight);
            });
        }

        public static void ShowWindow(this DlgPetQuickFight self, Entity contextData = null)
        {
        }

        public static void BeforeUnload(this DlgPetQuickFight self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static void OnTimer(this DlgPetQuickFight self)
        {
            long curTime = TimeHelper.ClientNow();
            Dictionary<long, long> PetFightTime = self.Root().GetComponent<BattleMessageComponent>().PetFightCD;

            if (self.ScrollItemPetQuickFightItems != null)
            {
                foreach (var value in self.ScrollItemPetQuickFightItems.Values)
                {
                    Scroll_Item_PetQuickFightItem item = value;
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    long petid = item.PetId;
                    long cdTime = 0;
                    PetFightTime.TryGetValue(petid, out cdTime);
                    long leftTime = cdTime - curTime;

                    item.OnTimer(leftTime);
                }
            }
        }

        public static void OnClickHandler(this DlgPetQuickFight self, long petid)
        {
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            RolePetInfo rolePetInfo = petComponent.GetPetInfoByID(petid);
            Dictionary<long, long> PetFightTime = self.Root().GetComponent<BattleMessageComponent>().PetFightCD;
            long huishouid = 0;
            //出战
            if (rolePetInfo.PetStatus == 0)
            {
                long cdTime = 0;
                PetFightTime.TryGetValue(petid, out cdTime);

                if (TimeHelper.ClientNow() - cdTime < 0)
                {
                    FlyTipComponent.Instance.ShowFlyTip("出战冷却中！");
                    return;
                }

                huishouid = petComponent.GetFightPetId();
            }

            //收回
            if (rolePetInfo.PetStatus == 1)
            {
                huishouid = petid;
            }

            if (PetFightTime.ContainsKey(huishouid))
            {
                PetFightTime[huishouid] = TimeHelper.ClientNow() + 180 * TimeHelper.Second;
            }
            else
            {
                PetFightTime.Add(huishouid, TimeHelper.ClientNow() + 180 * TimeHelper.Second);
            }

            self.RequestPetFight(petid).Coroutine();
        }

        public static async ETTask RequestPetFight(this DlgPetQuickFight self, long petid)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int petfightindex = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.PetFightIndex);
            if (petfightindex == self.FightIndex)
            {
                // 先切换回英雄
                await PetNetHelper.RequestPetFightSwitch(self.Root(), 0);
            }

            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            
            petComponent.GetNowPetFightList()[self.FightIndex - 1].PetId = petid;
            var petBarInfos = petComponent.GetNowPetFightList().Where(p => p.PetId == petid && (petComponent.GetNowPetFightList().IndexOf(p) != self.FightIndex - 1)).ToList();
            for (int i = 0; i < petBarInfos.Count; i++)
            {
                petBarInfos[i].PetId = 0;
            }


            await PetNetHelper.RequestPetBarSet(self.Root(), petComponent.GetNowPetFightList());
            
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetQuickFight);
        }

        public static void OnUpdateUI(this DlgPetQuickFight self)
        {
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            long petId = petComponent.GetNowPetFightList()[self.FightIndex - 1].PetId;

            if (self.ScrollItemPetQuickFightItems != null)
            {
                foreach (var value in self.ScrollItemPetQuickFightItems.Values)
                {
                    Scroll_Item_PetQuickFightItem item = value;

                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    item.OnUpdateUI(petId);
                }
            }
        }

        private static void OnPetQuickFightItemsRefresh(this DlgPetQuickFight self, Transform transform, int index)
        {
            foreach (Scroll_Item_PetQuickFightItem item in self.ScrollItemPetQuickFightItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_PetQuickFightItem scrollItemPetQuickFightItem = self.ScrollItemPetQuickFightItems[index].BindTrans(transform);
            scrollItemPetQuickFightItem.OnInitUI2(self.ShowRolePetInfos[index], self.OnClickHandler);
        }

        public static void OnInitUI(this DlgPetQuickFight self, int index)
        {
            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(600, TimerInvokeType.PetQuickFightTimer, self);

            self.FightIndex = index;
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            long petId = petComponent.GetNowPetFightList()[self.FightIndex - 1].PetId;

            List<RolePetInfo> rolePetInfos = petComponent.RolePetInfos;
            self.ShowRolePetInfos.Clear();
            for (int i = 0; i < rolePetInfos.Count; i++)
            {
                if (rolePetInfos[i].PetStatus == 3 || rolePetInfos[i].PetStatus == 2)
                {
                    continue;
                }

                if (rolePetInfos[i].Id != petId && petComponent.GetNowPetFightList().Where(p=>p.PetId ==rolePetInfos[i].Id).Count( ) > 0)
                {
                    continue;
                }

                self.ShowRolePetInfos.Add(rolePetInfos[i]);
            }

            self.AddUIScrollItems(ref self.ScrollItemPetQuickFightItems, self.ShowRolePetInfos.Count);
            self.View.E_PetQuickFightItemsLoopVerticalScrollRect.SetVisible(true, self.ShowRolePetInfos.Count);
            self.OnUpdateUI();
        }
    }
}