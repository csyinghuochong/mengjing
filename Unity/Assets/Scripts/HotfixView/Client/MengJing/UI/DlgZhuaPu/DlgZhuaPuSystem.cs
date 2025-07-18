using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [FriendOf(typeof(DlgZhuaPu))]
    public static class DlgZhuaPuSystem
    {
        [Invoke(TimerInvokeType.UIZhuaPuTimer)]
        public class UIZhuaPuTimer : ATimer<DlgZhuaPu>
        {
            protected override void Run(DlgZhuaPu self)
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

        public static void RegisterUIEvent(this DlgZhuaPu self)
        {
            self.View.E_ButtonDigButton.AddListener(self.OnButtonDig);
            self.View.E_ButtonCloseButton.AddListener(() => { self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ZhuaPu); });
            self.View.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);

        }

        public static void ShowWindow(this DlgZhuaPu self, Entity contextData = null)
        {
        }

        public static void HideWindow(this DlgZhuaPu self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        private static void OnBagItemsRefresh(this DlgZhuaPu self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(self.ShowBagInfos[index], ItemOperateEnum.None, self.OnClickItem);
            scrollItemCommonItem.ShowTip = false;
        }
        
        public static void UpdateItemList(this DlgZhuaPu self)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            if (self.ScrollItemCommonItems != null)
            {
                foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    int itemid = item.ItemID;
                    long number = bagComponent.GetItemNumber(itemid);
                    
                    Log.Debug($"itemid: {itemid}   number:{number}" );

                    item.E_ItemNumText.text = ItemViewHelp.ReturnNumStr(number);
                    CommonViewHelper.SetImageGray(self.Root(), item.E_ItemIconImage.gameObject, number <= 0);
                    CommonViewHelper.SetImageGray(self.Root(), item.E_ItemQualityImage.gameObject, number <= 0);
                }
            }
        }

        public static void SelectItemList(this DlgZhuaPu self, int itemid)
        {
            if (self.ScrollItemCommonItems != null)
            {
                foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    item.E_XuanZhongImage.gameObject.SetActive(itemid == item.ItemID);
                }
            }
        }

        public static void OnClickItem(this DlgZhuaPu self, ItemInfo bagInfo)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            long leftnumber = bagComponent.GetItemNumber(bagInfo.ItemID);
            if (leftnumber <= 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("道具不足！");
                return;
            }

            if (self.ItemId == bagInfo.ItemID)
            {
                self.ItemId = 0;
            }
            else
            {
                self.ItemId = bagInfo.ItemID;
            }

            self.SelectItemList(self.ItemId);
            if (self.ZhuaBuType == 1)
            {
                self.UpdateTyp1_Gailv();
            }

            if (self.ZhuaBuType == 2)
            {
                self.UpdateTyp2_Gailv();
            }
        }

        public static void  OnButtonDig(this DlgZhuaPu self)
        {
            if (self.ZhuaBuType == 1)
            {
                self.OnType1_ButtonDig().Coroutine();
            }

            if (self.ZhuaBuType == 2)
            {
                //self.OnType2_ButtonDig().Coroutine();
            }
        }
        
        public static void OnTimer(this DlgZhuaPu self)
        {
            self.PassTime += Time.deltaTime;
            float posX = self.PassTime * self.MoveSpeed;
            if (posX > 580f)
            {
                posX = 0;
                self.PassTime = 0;
            }

            self.View.E_Img_ChanZiImage.transform.localPosition = new Vector3(posX, 0f, 0f);
        }
        
        public static void OnInitUI(this DlgZhuaPu self, Unit unitmonster)
        {
            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(unitmonster.ConfigId);
            self.MonsterId = unitmonster.ConfigId;
            self.MonsterUnitid = unitmonster.Id;
            self.BabyType = unitmonster.GetComponent<NumericComponentC>().GetAsInt(NumericType.BaByType);
            float size = RandomHelper.RandFloat01();
            self.View.E_Img_PosImage.transform.localPosition = new Vector3(size * 300f, 0f, 0f);
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.UIZhuaPuTimer, self);

            if (monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_58
                || monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_59)
            {
                self.ZhuaBuType = 1;
                
                self.UpdateTyp1_Gailv();
                self.InitType1_Itemlist();
                self.UpdateItemList();
            }
            else
            {
                self.ZhuaBuType = 2;
                self.UpdateTyp2_Gailv();
                self.InitType1_Itemlist();
                self.UpdateItemList();
            }
        }

        #region 新的抓捕逻辑
        public static void UpdateTyp2_Gailv(this DlgZhuaPu self)
        {
            if (self.MonsterId == 0)
            {
                return;
            }

            int gailv = CommonHelp.GetZhuPuType2_GaiLv(self.MonsterId,self.BabyType , self.ItemId, 1);
            using (zstring.Block())
            {
                self.View.E_TextGaiLvText.text = zstring.Format("抓捕成功率： {0}%", gailv * 0.01f);
            }
        }
        
        #endregion
        
        #region 旧的抓捕逻辑
        public static void UpdateTyp1_Gailv(this DlgZhuaPu self)
        {
            if (self.MonsterId == 0)
            {
                return;
            }

            int gailv = CommonHelp.GetZhuPuType1_GaiLv(self.MonsterId, self.ItemId, 1);
            using (zstring.Block())
            {
                self.View.E_TextGaiLvText.text = zstring.Format("抓捕成功率： {0}%", gailv * 0.01f);
            }
        }
        
        public static void InitType1_Itemlist(this DlgZhuaPu self)
        {
            self.ShowBagInfos.Clear();
            foreach (var item in GlobalValueConfigCategory.Instance.ZhuaPuItem)
            {
                ItemInfo bagInfo = new ItemInfo();
                bagInfo.ItemID = item.Key;
                self.ShowBagInfos.Add(bagInfo);
            }

            self.AddUIScrollItems(ref self.ScrollItemCommonItems, self.ShowBagInfos.Count);
            self.View.E_BagItemsLoopVerticalScrollRect.SetVisible(true, self.ShowBagInfos.Count);
        }

        private static async ETTask OnType1_ButtonDig(this DlgZhuaPu self)
        {
            Unit zhupuUnit = self.Root().CurrentScene().GetComponent<UnitComponent>().Get(self.MonsterUnitid);
            if (zhupuUnit == null || zhupuUnit.Type != UnitType.Monster)
            {
                return;
            }

            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(zhupuUnit.ConfigId);
            if (monsterConfig.MonsterType == 5 && monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_58)
            {
                Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
                UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
                int petexpendNumber = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.PetExtendNumber);
                int maxNum = PetHelper.GetPetMaxNumber(userInfo.Lv, petexpendNumber);
                if (PetHelper.GetBagPetNum(self.Root().GetComponent<PetComponentC>().RolePetInfos) >= maxNum)
                {
                    FlyTipComponent.Instance.ShowFlyTip("宠物格子不足！");
                    return;
                }
            }

            float distance = Vector3.Distance(self.View.E_Img_ChanZiImage.transform.localPosition, self.View.E_Img_PosImage.transform.localPosition);
            string jiacheng = distance <= 10f ? "2" : "1";
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);

            M2C_ZhuaBuType1Response response = await JingLingNetHelper.ZhuaBuType1Request(self.Root(), self.MonsterUnitid, self.ItemId, jiacheng);
            if (response.Error == ErrorCode.ERR_Success && response.Message != "1")
            {
                FlyTipComponent.Instance.ShowFlyTip("恭喜你，抓捕成功！");
            }

            if (response.Error == ErrorCode.ERR_ZhuaBuFail)
            {
                List<string> strList = new List<string>();
                strList.Add("它趁你不注意，偷偷的溜走了!");
                strList.Add("抓铺的动作太大，被他发现后马上的逃走了!");

                int randInt = RandomHelper.RandomNumber(0, strList.Count);
                FlyTipComponent.Instance.ShowFlyTip(strList[randInt]);
            }

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ZhuaPu);
        }

        #endregion
    }
}
