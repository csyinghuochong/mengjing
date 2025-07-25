﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ET.Client
{
    [Invoke(TimerInvokeType.PetEquipMakeCDTimer)]
    public class PetEquipMakeCDTimer : ATimer<DlgPetEquipMake>
    {
        protected override void Run(DlgPetEquipMake self)
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

    [FriendOf(typeof(Scroll_Item_MakeItem))]
    [FriendOf(typeof(ES_CommonItem))]
    [FriendOf(typeof(DlgPetEquipMake))]
    public static class DlgPetEquipMakeSystem
    {
        public static void RegisterUIEvent(this DlgPetEquipMake self)
        {
            self.View.E_Btn_MakeButton.AddListenerAsync(self.OnBtn_MakeButton);
            
            IPHoneHelper.SetPosition(self.View.E_FunctionSetBtnToggleGroup.gameObject, new Vector2(220f, 0f));

            self.OnInitUI();
            int showValue = NpcConfigCategory.Instance.Get(self.Root().GetComponent<UIComponent>().CurrentNpcId).ShopValue;
            self.InitMakeList(showValue).Coroutine();
        }

        public static void ShowWindow(this DlgPetEquipMake self, Entity contextData = null)
        {
        }

        public static void BeforeUnload(this DlgPetEquipMake self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static void OnInitUI(this DlgPetEquipMake self)
        {
            self.UpateMakeItemUI();
        }

        public static async ETTask OnBtn_MakeButton(this DlgPetEquipMake self)
        {
            if (self.MakeId == 0)
            {
                return;
            }

            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            long cdEndTime = userInfoComponent.GetMakeTime(self.MakeId);
            if (cdEndTime > TimeHelper.ServerNow())
            {
                HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_InMakeCD);
                return;
            }

            EquipMakeConfig equipMakeConfig = EquipMakeConfigCategory.Instance.Get(self.MakeId);
            if (self.Root().GetComponent<UserInfoComponentC>().UserInfo.Gold < equipMakeConfig.MakeNeedGold)
            {
                FlyTipComponent.Instance.ShowFlyTip("金币不足！");
                return;
            }

            bool success = self.Root().GetComponent<BagComponentC>().CheckNeedItem(equipMakeConfig.NeedItems);
            if (!success)
            {
                FlyTipComponent.Instance.ShowFlyTip("材料不足！");
                return;
            }

            await BagClientNetHelper.RequestEquipMake(self.Root(), 0, self.MakeId, 1);
            self.OnCostItemUpdate();
        }

        public static void UpateMakeItemUI(this DlgPetEquipMake self)
        {
            if (self.MakeId == 0)
            {
                self.View.ES_CommonItem.uiTransform.gameObject.SetActive(false);
                return;
            }

            self.View.ES_CommonItem.uiTransform.gameObject.SetActive(true);
            EquipMakeConfig equipMakeConfig = EquipMakeConfigCategory.Instance.Get(self.MakeId);
            if (self.View.ES_CommonItem.uiTransform.gameObject != null)
            {
                ItemInfo bagInfo = new ItemInfo();
                bagInfo.ItemID = equipMakeConfig.MakeItemID;
                self.View.ES_CommonItem.UpdateItem(bagInfo, ItemOperateEnum.MakeItem);
                self.View.ES_CommonItem.E_ItemNumText.gameObject.SetActive(false);
            }
        }

        public static void OnCostItemUpdate(this DlgPetEquipMake self)
        {
            EquipMakeConfig equipMakeConfig = EquipMakeConfigCategory.Instance.Get(self.MakeId);

            string needItems = equipMakeConfig.NeedItems;
            self.View.ES_CostList.Refresh(needItems);

            //显示名称
            self.View.E_Lab_MakeNameText.text = ItemConfigCategory.Instance.Get(equipMakeConfig.MakeItemID).ItemName;
            self.View.E_Lab_MakeNameText.color =
                    CommonViewHelper.QualityReturnColor(ItemConfigCategory.Instance.Get(equipMakeConfig.MakeItemID).ItemQuality);
            self.View.E_Lab_MakeNumText.text = equipMakeConfig.MakeEquipNum.ToString();

            //显示消耗活力
            self.View.E_TextVitalityText.text = equipMakeConfig.MakeNeedGold.ToString();
            using (zstring.Block())
            {
                self.View.E_Text_CurrentText.text = zstring.Format("当前金币:  {0}", self.Root().GetComponent<UserInfoComponentC>().UserInfo.Gold);
            }
        }

        public static void OnUpdate(this DlgPetEquipMake self)
        {
            int makeId = self.MakeId;
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            long cdEndTime = userInfoComponent.GetMakeTime(makeId);
            if (cdEndTime <= TimeHelper.ServerNow())
            {
                self.View.E_Lab_MakeCDTimeText.gameObject.SetActive(false);
                self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
                return;
            }

            self.View.E_Lab_MakeCDTimeText.text = TimeHelper.ShowLeftTime(cdEndTime - TimeHelper.ServerNow());
        }

        public static void ShowCDTime(this DlgPetEquipMake self)
        {
            self.View.E_Lab_MakeCDTimeText.gameObject.SetActive(false);
            self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
            int makeId = self.MakeId;
            if (makeId == 0)
            {
                return;
            }

            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            long cdEndTime = userInfoComponent.GetMakeTime(makeId);
            if (cdEndTime <= TimeHelper.ServerNow())
            {
                return;
            }

            self.View.E_Lab_MakeCDTimeText.gameObject.SetActive(true);
            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.PetEquipMakeCDTimer, self);
            self.OnUpdate();
        }

        public static void OnSelectMakeItem(this DlgPetEquipMake self, int makeid)
        {
            self.MakeId = makeid;
            self.View.EG_MakeINeedNodeRectTransform.gameObject.SetActive(makeid != 0);
            self.ShowCDTime();
            self.UpateMakeItemUI();
            self.OnCostItemUpdate();

            //设置选中框
            for (int k = 0; k < self.ChapterListUI.Count; k++)
            {
                UIPetEquipChapterComponent ui = self.ChapterListUI[k];
                ui.OnSelectMakeItem(makeid);
            }
        }

        public static async ETTask InitMakeList(this DlgPetEquipMake self, int makeType)
        {
            long instanceid = self.InstanceId;
            var path = ABPathHelper.GetUGUIPath("Common/UIPetEquipChapter");
            var bundleGameObject = await self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(path);
            if (instanceid != self.InstanceId)
            {
                return;
            }

            List<EquipMakeConfig> makeList = EquipMakeConfigCategory.Instance.GetAll().Values.ToList();
            Dictionary<int, List<int>> chapterMakeids = new Dictionary<int, List<int>>();
            chapterMakeids.Add(0, new List<int>());

            for (int i = 0; i < makeList.Count; i++)
            {
                EquipMakeConfig equipMakeConfig = makeList[i];
                if (equipMakeConfig.ProficiencyType != makeType)
                {
                    continue;
                }

                chapterMakeids[0].Add(equipMakeConfig.Id);
            }

            foreach (var item in chapterMakeids)
            {
                GameObject itemSpace = UnityEngine.Object.Instantiate(bundleGameObject, self.View.EG_MakeListNodeRectTransform);
                itemSpace.SetActive(true);
                UIPetEquipChapterComponent ui_2 = self.AddChild<UIPetEquipChapterComponent, GameObject>(itemSpace);
                ui_2.SetClickAction(self.OnSelectMakeItem);
                ui_2.OnInitUI(item.Key, item.Value);
                self.ChapterListUI.Add(ui_2);

                await self.Root().GetComponent<TimerComponent>().WaitFrameAsync();
            }
        }
    }
}