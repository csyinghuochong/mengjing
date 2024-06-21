using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_UnionShow))]
    [FriendOfAttribute(typeof (ES_UnionShow))]
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

            self.E_Btn_CreateButton.AddListenerAsync(self.RequestCreateUnion);

            self.E_InputFieldPurposeInputField.onValueChanged.AddListener((string text) =>
            {
                self.CheckSensitiveWords(self.E_InputFieldPurposeInputField.gameObject);
            });

            self.E_UnionListItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnUnionListItemsRefresh);

            self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_UnionShow self)
        {
            self.DestroyWidget();
        }

        private static void OnUnionListItemsRefresh(this ES_UnionShow self, Transform transform, int index)
        {
            Scroll_Item_UnionListItem scrollItemUnionListItem = self.ScrollItemUnionListItems[index].BindTrans(transform);
            scrollItemUnionListItem.Refresh(self.ShowUnionListItems[index]);
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
        }

        public static void CheckSensitiveWords(this ES_UnionShow self, GameObject InputField)
        {
            string text_new = "";
            string text_old = InputField.GetComponent<InputField>().text;
            MaskWordComponent.Instance.IsContainSensitiveWords(ref text_old, out text_new);
            InputField.GetComponent<InputField>().text = text_old;
        }

        public static void OnInitUI(this ES_UnionShow self)
        {
            self.E_Text_Contion1Text.text = $"1. 角色等级达到{GlobalValueConfigCategory.Instance.Get(21).Value}级";
            self.E_Text_Contion2Text.text = $"2. 消耗{GlobalValueConfigCategory.Instance.Get(22).Value}钻石";
        }

        public static async ETTask RequestCreateUnion(this ES_UnionShow self)
        {
            string unionName = self.E_InputFieldNameInputField.text;
            bool mask = MaskWordComponent.Instance.IsContainSensitiveWords(unionName);
            if (mask || !StringHelper.IsSpecialChar(unionName))
            {
                FlyTipComponent.Instance.ShowFlyTipDi("家族名字有特殊字符！");
                return;
            }

            if (unionName.Length > 7)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("家族名字最多七个字！");
                return;
            }

            string purpose = self.E_InputFieldPurposeInputField.text;
            // mask = MaskWordComponent.Instance.IsContainSensitiveWords(purpose);
            //if (mask || !StringHelper.IsSpecialChar(purpose) || purpose.Length >= 200)
            //{
            //    FloatTipManager.Instance.ShowFloatTip("请重新输入！");
            //    return;
            //}
            // if (mask)
            // {
            //     FlyTipComponent.Instance.SpawnFlyTipDi("宣言有特殊字符！");
            //     return;
            // }
            //
            // if (purpose.Length >= 200)
            // {
            //     FlyTipComponent.Instance.SpawnFlyTipDi("宣言内容过长！");
            //     return;
            // }
            //
            // Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            // if (unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.UnionId_0) != 0)
            // {
            //     FlyTipComponent.Instance.SpawnFlyTipDi("请先退出公会！");
            //     return;
            // }

            // UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            // int needLevel = int.Parse(GlobalValueConfigCategory.Instance.Get(21).Value);
            // int needDiamond = int.Parse(GlobalValueConfigCategory.Instance.Get(22).Value);
            // if (userInfo.Lv < needLevel)
            // {
            //     FlyTipComponent.Instance.SpawnFlyTipDi("等级不足！");
            //     return;
            // }
            //
            // if (userInfo.Diamond < needDiamond)
            // {
            //     FlyTipComponent.Instance.SpawnFlyTipDi("钻石不足！");
            //     return;
            // }

            M2C_UnionCreateResponse response = await UnionNetHelper.UnionCreate(self.Root(), unionName, purpose);
            if (response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgFriend>().View.E_FunctionSetBtnToggleGroup.OnSelectIndex(4);

            await ETTask.CompletedTask;
        }
    }
}