using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgMainViewComponent))]
    [FriendOf(typeof(DlgButtonPositionSetViewComponent))]
    [FriendOf(typeof(DlgButtonPositionSet))]
    public static class DlgButtonPositionSetSystem
    {
        public static void RegisterUIEvent(this DlgButtonPositionSet self)
        {
            self.View.E_SkillPositionSetImage.gameObject.SetActive(false);

            self.View.E_Btn_SkilPositionResetButton.AddListener(self.OnBtn_SkilPositionResetButton);

            self.View.E_Btn_SkilPositionCancelButton.AddListener(self.OnBtn_SkilPositionCancelButton);

            self.View.E_Btn_SkilPositionSaveButton.AddListener(self.OnBtn_SkilPositionSaveButton);
            
            self.InitButtons();
        }

        public static void ShowWindow(this DlgButtonPositionSet self, Entity contextData = null)
        {
            
        }

        public static void HideWindow(this DlgButtonPositionSet self)
        {
            self.SetViewActive(false);
        }

        public static void InitButtons(this DlgButtonPositionSet self)
        {
            self.UIMain = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>().View.uiTransform.gameObject;
            self.View.uiTransform.SetParent(self.UIMain.transform);
            self.View.uiTransform.SetSiblingIndex(0);
            
            self.View.EG_TopRectTransform.SetParent(self.UIMain.transform);
            self.View.EG_TopRectTransform.SetAsLastSibling();

            self.SkillPositionList.Clear();
            ReferenceCollector rc = self.UIMain.GetComponent<ReferenceCollector>();

            ReferenceCollector rc_skill = rc.Get<GameObject>("UIMainSkill").GetComponent<ReferenceCollector>();
            for (int i = 0; i < 10; i++)
            {
                GameObject go = rc_skill.Get<GameObject>($"UI_MainRoseSkill_item_{i}");

                self.AddSkillDragItem(i, go);
            }

            self.AddSkillDragItem(10, rc_skill.Get<GameObject>("UI_MainRose_attack"));
            self.AddSkillDragItem(11, rc_skill.Get<GameObject>("UI_MainRose_FanGun"));

            self.AddSkillDragItem(12, rc.Get<GameObject>("Btn_RoseEquip"));
            self.AddSkillDragItem(13, rc.Get<GameObject>("Btn_Pet"));
            self.AddSkillDragItem(14, rc.Get<GameObject>("Btn_RoseSkill"));
            self.AddSkillDragItem(15, rc.Get<GameObject>("Btn_ChengJiu"));
            self.AddSkillDragItem(16, rc.Get<GameObject>("Btn_Friend"));
            self.AddSkillDragItem(17, rc.Get<GameObject>("Btn_Task"));

            self.AddSkillDragItem(18, rc.Get<GameObject>("UIMainChat"));

            self.AddSkillDragItem(19, rc_skill.Get<GameObject>("Btn_CancleSkill"));

            self.AddSkillDragItem(20, rc.Get<GameObject>("YaoGanDiFix"));

            self.AddSkillDragItem(21, rc_skill.Get<GameObject>("UI_MainRoseSkill_item_juexing"));

            self.CheckSkilPositionSet();

            self.UpdateSkillPosition();
        }

        public static void AddSkillDragItem(this DlgButtonPositionSet self, int i, GameObject go)
        {
            UISkillDragComponent uISkillDrag = self.AddChild<UISkillDragComponent, int, GameObject>(i, go);
            uISkillDrag.BeginDrag_TriggerHandler = self.OnBeginDrag_TriggerHandler;
            uISkillDrag.Drag_TriggerHandler = self.OnDrag_TriggerHandler;
            uISkillDrag.EndDrag_TriggerHandler = self.OnEndDrag_TriggerHandler;
            uISkillDrag.OnCancel_TriggerHandler = self.OnOnCancel_TriggerHandler;
            self.UISkillDragList.Add(uISkillDrag);
            self.SkillPositionList.Add(go.transform.localPosition);
            self.InitPositionList.Add(go.transform.localPosition);
        }

        public static void ShowSkillPositionSet(this DlgButtonPositionSet self)
        {
            self.SetViewActive(true);    
            
            for (int i = 0; i < self.UISkillDragList.Count; i++)
            {
                UISkillDragComponent uiSkillDragComponent = self.UISkillDragList[i];
                if (i == 20)
                {
                    UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
                    int operatMode = int.Parse(userInfoComponent.GetGameSettingValue(GameSettingEnum.YanGan));
                    uiSkillDragComponent.Img_EventTrigger.SetActive(operatMode == 0);
                }
                else
                {
                    uiSkillDragComponent.Img_EventTrigger.SetActive(true);
                }
            }

            ReferenceCollector rc_skill = self.UIMain.Get<GameObject>("UIMainSkill").GetComponent<ReferenceCollector>();
            rc_skill.Get<GameObject>("Btn_CancleSkill").SetActive(true);
            rc_skill.Get<GameObject>("UI_MainRoseSkill_item_juexing").SetActive(true);
        }

        public static void CheckSkilPositionSet(this DlgButtonPositionSet self)
        {
            long userid = self.Root().GetComponent<UserInfoComponentC>().UserInfo.UserId;
            string positonlist;
            using (zstring.Block())
            {
                positonlist = PlayerPrefsHelp.GetString(zstring.Format("PlayerPrefsHelp.SkillPostion_{0}", userid));
            }

            string[] vector2list = positonlist.Split('@');

            self.SkillPositionList.Clear();
            for (int i = 0; i < vector2list.Length; i++)
            {
                string[] vectorinfo = vector2list[i].Split(';');
                if (vectorinfo.Length < 2)
                {
                    continue;
                }

                self.SkillPositionList.Add(new Vector2() { x = float.Parse(vectorinfo[0]), y = float.Parse(vectorinfo[1]) });
            }

            for (int i = self.SkillPositionList.Count; i < self.InitPositionList.Count; i++)
            {
                self.SkillPositionList.Add(self.InitPositionList[i]);
            }

            self.TempPositionList.Clear();
            for (int i = 0; i < self.SkillPositionList.Count; i++)
            {
                self.TempPositionList.Add(self.SkillPositionList[i]);
            }
        }

        public static void UpdateSkillPosition(this DlgButtonPositionSet self)
        {
            for (int i = 0; i < self.UISkillDragList.Count; i++)
            {
                UISkillDragComponent uiSkillDragComponent = self.UISkillDragList[i];
                uiSkillDragComponent.GameObject.transform.localPosition = self.TempPositionList[i];
            }
        }

        public static void OnBtn_SkilPositionResetButton(this DlgButtonPositionSet self)
        {
            self.TempPositionList.Clear();
            self.SkillPositionList.Clear();
            for (int i = 0; i < self.InitPositionList.Count; i++)
            {
                self.TempPositionList.Add(self.InitPositionList[i]);
                self.SkillPositionList.Add(self.InitPositionList[i]);
            }

            self.UpdateSkillPosition();
            self.OnBtn_SkilPositionSaveButton();
            self.SetViewActive(true);
            
            for (int i = 0; i < self.UISkillDragList.Count; i++)
            {
                UISkillDragComponent uiSkillDragComponent = self.UISkillDragList[i];
                uiSkillDragComponent.Img_EventTrigger.SetActive(false);
            }
        }

        public static void OnBtn_SkilPositionCancelButton(this DlgButtonPositionSet self)
        {
            self.TempPositionList.Clear();
            for (int i = 0; i < self.SkillPositionList.Count; i++)
            {
                self.TempPositionList.Add(self.SkillPositionList[i]);
            }

            self.UpdateSkillPosition();

            self.HideEventTrigger();
        }

        private static void SetViewActive(this DlgButtonPositionSet self, bool isActive)
        {
            self.View.uiTransform.gameObject.SetActive(isActive);
            self.View.E_SkillPositionSetImage.gameObject.SetActive(isActive);
            self.View.EG_TopRectTransform.gameObject.SetActive(isActive);
        }

        public static void HideEventTrigger(this DlgButtonPositionSet self)
        {
            self.SetViewActive(false);
            
            for (int i = 0; i < self.UISkillDragList.Count; i++)
            {
                UISkillDragComponent uiSkillDragComponent = self.UISkillDragList[i];
                uiSkillDragComponent.Img_EventTrigger.SetActive(false);
            }

            ReferenceCollector rc_skill = self.UIMain.Get<GameObject>("UIMainSkill").GetComponent<ReferenceCollector>();
            rc_skill.Get<GameObject>("Btn_CancleSkill").SetActive(false);
            rc_skill.Get<GameObject>("UI_MainRoseSkill_item_juexing").SetActive(false);
        }

        public static void OnBtn_SkilPositionSaveButton(this DlgButtonPositionSet self)
        {
            string positonlist = string.Empty;
            self.SkillPositionList.Clear();
            for (int i = 0; i < self.TempPositionList.Count; i++)
            {
                self.SkillPositionList.Add(self.TempPositionList[i]);
            }

            for (int i = 0; i < self.SkillPositionList.Count; i++)
            {
                Vector2 vector2 = self.SkillPositionList[i];
                positonlist += $"{vector2.x};{vector2.y}@";
            }

            positonlist = positonlist.Substring(0, positonlist.Length - 1);
            long userid = self.Root().GetComponent<UserInfoComponentC>().UserInfo.UserId;
            using (zstring.Block())
            {
                PlayerPrefsHelp.SetString(zstring.Format("PlayerPrefsHelp.SkillPostion_{0}", userid), positonlist);
            }

            self.HideEventTrigger();
        }

        public static void OnBeginDrag_TriggerHandler(this DlgButtonPositionSet self, int skillIndex)
        {
            self.CurDragIndex = skillIndex;

            UISkillDragComponent uiSkillDragComponent = self.UISkillDragList[skillIndex];
            self.SkillIconItemCopy = UnityEngine.Object.Instantiate(uiSkillDragComponent.GameObject);
            self.SkillIconItemCopy.SetActive(true);
            CommonViewHelper.SetParent(self.SkillIconItemCopy, self.UIMain);
        }

        public static void OnDrag_TriggerHandler(this DlgButtonPositionSet self, PointerEventData pdata)
        {
            Vector2 localPoint = Vector2.zero;
            RectTransform canvas = self.SkillIconItemCopy.transform.parent.GetComponent<RectTransform>();
            Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, uiCamera, out localPoint);

            self.SkillIconItemCopy.transform.localPosition = new Vector3(localPoint.x, localPoint.y, 0f);
        }

        public static void OnEndDrag_TriggerHandler(this DlgButtonPositionSet self, PointerEventData pdata)
        {
            self.OnOnCancel_TriggerHandler(pdata);
        }

        public static void OnOnCancel_TriggerHandler(this DlgButtonPositionSet self, PointerEventData pdata)
        {
            RectTransform canvas = self.SkillIconItemCopy.transform.parent.GetComponent<RectTransform>();
            GraphicRaycaster gr = canvas.GetComponent<GraphicRaycaster>();
            List<RaycastResult> results = new List<RaycastResult>();
            gr.Raycast(pdata, results);

            for (int i = 0; i < results.Count; i++)
            {
                string name = results[i].gameObject.name;

                bool collide = name.Contains("E_ImageSkillPositionSet") && (self.CurDragIndex < 12
                    || self.CurDragIndex == 19 || self.CurDragIndex == 21 || self.CurDragIndex == 22);

                if (name.Contains("E_ImageLeftBottomBtns") &&
                    ((self.CurDragIndex >= 12 && self.CurDragIndex < 19) || self.CurDragIndex == 20))
                {
                    collide = true;
                }

                if (!collide)
                {
                    continue;
                }

                Camera UiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
                Camera MainCamera = self.Root().GetComponent<GlobalComponent>().MainCamera.GetComponent<Camera>();

                Vector3 uiPos_2 = Vector3.one;
                RectTransformUtility.ScreenPointToWorldPointInRectangle(results[i].gameObject.transform as RectTransform,
                    Input.mousePosition, MainCamera, out uiPos_2);

                Vector2 OldPosition = WorldPosiToUIPos.WorldPosiToUIPosition(uiPos_2, results[i].gameObject, UiCamera, MainCamera, false);
                self.TempPositionList[self.CurDragIndex] = OldPosition;

                self.UpdateSkillPosition();
                break;
            }

            if (self.SkillIconItemCopy != null)
            {
                UnityEngine.Object.Destroy(self.SkillIconItemCopy);
                self.SkillIconItemCopy = null;
            }
        }
    }
}