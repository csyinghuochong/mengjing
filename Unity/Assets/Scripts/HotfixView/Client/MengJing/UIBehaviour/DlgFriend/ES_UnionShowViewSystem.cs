using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_UnionShow))]
    [FriendOfAttribute(typeof(ES_UnionShow))]
    [FriendOf(typeof(Scroll_Item_UnionListItem))]
    public static partial class ES_UnionShowSystem
    {
        [EntitySystem]
        private static void Awake(this ES_UnionShow self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ButtonCreateButton.AddListener(() =>
            {
                self.EG_UIUnionListRectTransform.gameObject.SetActive(false);
                self.EG_UIUnionCreateRectTransform.gameObject.SetActive(true);
            });

            self.E_Btn_ReturnButton.AddListener(() =>
            {
                self.EG_UIUnionListRectTransform.gameObject.SetActive(true);
                self.EG_UIUnionCreateRectTransform.gameObject.SetActive(false);
            });

            self.E_InputFieldNameInputField.onValueChanged.AddListener((string text) =>
            {
                self.CheckSensitiveWords(self.E_InputFieldNameInputField.gameObject);
            });

            self.E_Btn_CreateButton.AddListenerAsync(self.OnBtn_CreateButton);
            self.E_ButtonJoinButton.AddListenerAsync(self.OnButtonJoin);

            self.E_InputFieldPurposeInputField.onValueChanged.AddListener((string text) =>
            {
                self.CheckSensitiveWords(self.E_InputFieldPurposeInputField.gameObject);
            });

            self.E_UnionListItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnUnionListItemsRefresh);

            self.OnInitUI();
            self.ResetUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_UnionShow self)
        {
            self.DestroyWidget();
        }

        private static void OnUnionListItemsRefresh(this ES_UnionShow self, Transform transform, int index)
        {
            foreach (Scroll_Item_UnionListItem item in self.ScrollItemUnionListItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_UnionListItem scrollItemUnionListItem = self.ScrollItemUnionListItems[index].BindTrans(transform);
            scrollItemUnionListItem.Refresh(self.ShowUnionListItems[index], self.OnSelectUnionItem);

            if (index == 0)
            {
                self.OnSelectUnionItem(self.ShowUnionListItems[index]); 
            }
        }

        public static void OnCreateUnion(this ES_UnionShow self)
        {
            self.EG_UIUnionListRectTransform.gameObject.SetActive(true);
            self.EG_UIUnionCreateRectTransform.gameObject.SetActive(false);
            self.ResetUI();
            self.OnUpdateListUI().Coroutine();
        }

        public static void OnUpdateUI(this ES_UnionShow self)
        {
            self.EG_UIUnionListRectTransform.gameObject.SetActive(true);
            self.EG_UIUnionCreateRectTransform.gameObject.SetActive(false);

            self.OnUpdateListUI().Coroutine();
        }
        

        public static void OnSelectUnionItem(this ES_UnionShow self, UnionListItem unionListItem)
        {
            long userid = UnitHelper.GetMyUnitId(self.Root());
            
            self.UnionListItem = unionListItem;
            self.E_Text_InfoText.text = unionListItem.UnionPurpose;
            self.E_Text_RequestText.text = "等级>=1";    
            self.E_ButtonJoinButton.gameObject.SetActive(!unionListItem.ApplyList.Contains(userid));  
            
            foreach (Scroll_Item_UnionListItem scrollItemUnionListItem in self.ScrollItemUnionListItems.Values)
            {
                if (scrollItemUnionListItem.uiTransform == null)
                {
                    continue;   
                }
                scrollItemUnionListItem.SetSelected(unionListItem.UnionId);
            }
        }

        public static async ETTask OnButtonJoin(this ES_UnionShow self)
        {
            if (self.UnionListItem == null)
            {
                return;
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            long unionId = numericComponent.GetAsLong(NumericType.UnionId_0);
            if (unionId != 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("请先退出公会");
                return;
            }

            long leaveTime = numericComponent.GetAsLong(NumericType.UnionIdLeaveTime);
            if (TimeHelper.ServerNow() - leaveTime < TimeHelper.Hour * 8)
            {
                string tip = TimeHelper.ShowLeftTime(TimeHelper.Hour * 8 - (TimeHelper.ServerNow() - leaveTime));
                using (zstring.Block())
                {
                    FlyTipComponent.Instance.ShowFlyTip(zstring.Format("{0} 后才能加入公会！", tip));
                }

                return;
            }

            await UnionNetHelper.UnionApplyRequest(self.Root(), self.UnionListItem.UnionId, unit.Id);
            if (self.IsDisposed)
            {
                return;
            }
            self.UnionListItem.ApplyList.Add(unit.Id);
            self.E_ButtonJoinButton.gameObject.SetActive(false);  
            FlyTipComponent.Instance.ShowFlyTip("已申请加入");
        }
        
        public static async ETTask OnUpdateListUI(this ES_UnionShow self)
        {
            if (self.ShowUnionListItems == null)
            {
                U2C_UnionListResponse response = await UnionNetHelper.UnionList(self.Root());

                if (response.Error != ErrorCode.ERR_Success)
                {
                    return;
                }

                self.ShowUnionListItems = response.UnionList;
            }

            self.ShowUnionListItems.Sort(delegate(UnionListItem a, UnionListItem b)
            {
                int unionlevela = a.UnionLevel;
                int unionlevelb = b.UnionLevel;
                int numbera = a.PlayerNumber;
                int numberb = b.PlayerNumber;

                if (numbera == numberb)
                {
                    return unionlevelb - unionlevela;
                }
                else
                {
                    return numberb - numbera;
                }
            });

            self.AddUIScrollItems(ref self.ScrollItemUnionListItems, self.ShowUnionListItems.Count);
            self.E_UnionListItemsLoopVerticalScrollRect.SetVisible(true, self.ShowUnionListItems.Count);

            await ETTask.CompletedTask;
        }

        public static void ResetUI(this ES_UnionShow self)
        {
            // self.UnionList = null;
            self.E_Text_InfoText.text = string.Empty;
            self.E_Text_RequestText.text = string.Empty;    
            self.E_ButtonJoinButton.gameObject.SetActive(false);  
            self.UnionListItem = null;  
        }

        public static void CheckSensitiveWords(this ES_UnionShow self, GameObject InputField)
        {
            string text_new = "";
            string text_old = InputField.GetComponent<InputField>().text;
            MaskWordHelper.Instance.IsContainSensitiveWords(ref text_old, out text_new);
            InputField.GetComponent<InputField>().text = text_old;
        }

        public static void OnInitUI(this ES_UnionShow self)
        {
            using (zstring.Block())
            {
                self.E_Text_Contion1Text.text = zstring.Format("1. 角色等级达到{0}级", GlobalValueConfigCategory.Instance.Get(21).Value);
                self.E_Text_Contion2Text.text = zstring.Format("2. 消耗{0}钻石", GlobalValueConfigCategory.Instance.Get(22).Value);
            }
            
        }

        public static async ETTask OnBtn_CreateButton(this ES_UnionShow self)
        {
            string unionName = self.E_InputFieldNameInputField.text;
            bool mask = MaskWordHelper.Instance.IsContainSensitiveWords(unionName);
            if (mask || unionName.Contains("*"))
            {
                FlyTipComponent.Instance.ShowFlyTip("公会名字不能包含特殊字符！");
                return;
            }

            if (unionName.Length > 7)
            {
                FlyTipComponent.Instance.ShowFlyTip("公会名字最多七个字！");
                return;
            }

             string purpose = self.E_InputFieldPurposeInputField.text;
             mask = MaskWordHelper.Instance.IsContainSensitiveWords(purpose);
             if (mask|| purpose.Contains("*"))
             {
                 FlyTipComponent.Instance.ShowFlyTip("宣言不能包含特殊字符！");
                 return;
             }
             if (purpose.Length >= 500)
             {
                 FlyTipComponent.Instance.ShowFlyTip("宣言内容过长！");
                 return;
             }
            
             Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
             if (unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.UnionId_0) != 0)
             {
                 FlyTipComponent.Instance.ShowFlyTip("请先退出公会！");
                 return;
             }

            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            int needLevel = GlobalValueConfigCategory.Instance.UnionCreateNeedLv;
            int needDiamond = GlobalValueConfigCategory.Instance.UnionCreateNeedDiamond;
            if (userInfo.Lv < needLevel)
            {
                FlyTipComponent.Instance.ShowFlyTip("等级不足！");
                return;
            }
            
            if (userInfo.Diamond < needDiamond)
            {
                FlyTipComponent.Instance.ShowFlyTip("钻石不足！");
                return;
            }

            M2C_UnionCreateResponse response = await UnionNetHelper.UnionCreate(self.Root(), unionName, purpose);
            if (response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgUnion>().View.E_FunctionSetBtnToggleGroup.OnSelectIndex(1);

            await ETTask.CompletedTask;
        }
    }
}
