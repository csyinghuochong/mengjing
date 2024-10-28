using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgSettingSkill))]
    public static class DlgSettingSkillSystem
    {
        public static void RegisterUIEvent(this DlgSettingSkill self)
        {
            self.View.E_CloseBtnButton.AddListenerAsync(self.OnCloseBtnButton);
            self.View.E_ResetBtnButton.AddListener(self.OnResetBtnButton);
            
            self.View.E_Img_MaskImage.gameObject.SetActive(false);
            self.View.EG_SkillIconItemRectTransform.gameObject.SetActive(false);
            self.Init();
            self.UpdataSkillLeft();
            self.UpdataSkillSetRight();
        }

        public static void ShowWindow(this DlgSettingSkill self, Entity contextData = null)
        {
        }

        public static void Init(this DlgSettingSkill self)
        {
            int childCount = self.View.EG_SkillIPositionSetLeftRectTransform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                GameObject go = UnityEngine.Object.Instantiate(self.View.EG_SkillIconItemRectTransform.gameObject);
                go.SetActive(false);
                CommonViewHelper.SetParent(go, self.View.EG_SkillIPositionSetLeftRectTransform.GetChild(i).gameObject);
                self.SkillSetIconLeftList.Add(go);
                int i1 = i;
                // itemgo.GetComponentInChildren<Button>().onClick.AddListener(() => { self.OnClick(i1); });
                ReferenceCollector rc = go.GetComponent<ReferenceCollector>();
                GameObject Img_Mask = rc.Get<GameObject>("Img_Mask");
                Img_Mask.GetComponent<EventTrigger>()
                        .RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.OnPointerDown(pdata as PointerEventData); });
                Img_Mask.GetComponent<EventTrigger>()
                        .RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.OnPointerUp(pdata as PointerEventData, i1); });
                Img_Mask.GetComponent<EventTrigger>().RegisterEvent(EventTriggerType.BeginDrag,
                    (pdata) => { self.OnBeginDrag(pdata as PointerEventData, Img_Mask); });
                Img_Mask.GetComponent<EventTrigger>().RegisterEvent(EventTriggerType.Drag, (pdata) => { self.OnDraging(pdata as PointerEventData); });
                Img_Mask.GetComponent<EventTrigger>()
                        .RegisterEvent(EventTriggerType.EndDrag, (pdata) => { self.OnEndDrag(pdata as PointerEventData, i1, 1); });
            }

            int childCount1 = self.View.EG_SkillIPositionSetRightRectTransform.childCount;
            for (int i = 0; i < childCount1; i++)
            {
                GameObject go = UnityEngine.Object.Instantiate(self.View.EG_SkillIconItemRectTransform.gameObject);
                go.SetActive(false);
                CommonViewHelper.SetParent(go, self.View.EG_SkillIPositionSetRightRectTransform.GetChild(i).gameObject);
                self.SkillSetIconRightList.Add(go);
                int i1 = i;
                ReferenceCollector rc = go.GetComponent<ReferenceCollector>();
                GameObject Img_Mask = rc.Get<GameObject>("Img_Mask");
                Img_Mask.GetComponent<EventTrigger>().RegisterEvent(EventTriggerType.BeginDrag,
                    (pdata) => { self.OnBeginDrag(pdata as PointerEventData, Img_Mask); });
                Img_Mask.GetComponent<EventTrigger>().RegisterEvent(EventTriggerType.Drag, (pdata) => { self.OnDraging(pdata as PointerEventData); });
                Img_Mask.GetComponent<EventTrigger>()
                        .RegisterEvent(EventTriggerType.EndDrag, (pdata) => { self.OnEndDrag(pdata as PointerEventData, i1, 2); });
            }

            self.SkillSet.Clear();
            string[] skillIndexs = self.Root().GetComponent<UserInfoComponentC>().GetGameSettingValue(GameSettingEnum.GuaJiAutoUseSkill)
                    .Split('@');
            if (skillIndexs.Length > 0)
            {
                foreach (string skill in skillIndexs)
                {
                    if (skill == "")
                    {
                        continue;
                    }

                    self.SkillSet.Add(int.Parse(skill));
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (i >= self.SkillSet.Count)
                {
                    self.SkillSet.Add(-1);
                }
            }
        }

        public static void UpdataSkillLeft(this DlgSettingSkill self)
        {
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();
            for (int i = 0; i < self.SkillSetIconLeftList.Count; i++)
            {
                GameObject itemgo = self.SkillSetIconLeftList[i];
                GameObject addImage = itemgo.transform.parent.GetChild(0).gameObject;
                SkillPro skillPro = skillSetComponent.GetByPosition(i + 1);

                if (skillPro == null)
                {
                    addImage.GetComponent<Image>().fillAmount = 1;
                    itemgo.SetActive(false);
                    continue;
                }

                addImage.GetComponent<Image>().fillAmount = 0;
                itemgo.SetActive(true);
                if (skillPro.SkillSetType == SkillSetEnum.Skill)
                {
                    SkillConfig skillConfig = SkillConfigCategory.Instance.Get(SkillHelp.GetWeaponSkill(skillPro.SkillID,
                        UnitHelper.GetEquipType(self.Root()), skillSetComponent.SkillList));
                    string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, skillConfig.SkillIcon);
                    Sprite sp = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);

                    itemgo.transform.Find("Img_Mask/Img_SkillIcon").GetComponent<Image>().sprite = sp;
                }
            }
        }

        public static void OnPointerDown(this DlgSettingSkill self, PointerEventData pdata)
        {
            self.ClickTime = TimeHelper.ServerNow();
        }

        public static void OnPointerUp(this DlgSettingSkill self, PointerEventData pdata, int index1)
        {
            if (TimeHelper.ServerNow() - self.ClickTime <= 500)
            {
                self.OnClick(index1);
            }

            self.ClickTime = 0;
        }

        public static void OnBeginDrag(this DlgSettingSkill self, PointerEventData pdata, GameObject go)
        {
            self.View.E_Img_MaskImage.gameObject.SetActive(true);
            self.View.E_Img_MaskImage.transform.Find("Img_SkillIcon").GetComponent<Image>().sprite =
                    go.transform.Find("Img_SkillIcon").GetComponent<Image>().sprite;
            // self.View.E_Img_MaskImage.transform.SetParent(UIEventComponent.Instance.UILayers[(int)UILayer.Mid]);
            self.View.E_Img_MaskImage.transform.localScale = Vector3.one;
        }

        public static void OnDraging(this DlgSettingSkill self, PointerEventData pdata)
        {
            if (self.View.E_Img_MaskImage == null)
            {
                return;
            }

            Vector2 localPoint = new Vector3();
            RectTransform canvas = self.View.E_Img_MaskImage.transform.parent.GetComponent<RectTransform>();
            Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, uiCamera, out localPoint);

            self.View.E_Img_MaskImage.transform.localPosition = new Vector3(localPoint.x, localPoint.y, 0f);
        }

        public static void OnEndDrag(this DlgSettingSkill self, PointerEventData pdata, int index1, int type)
        {
            if (self.View.E_Img_MaskImage == null)
            {
                return;
            }

            RectTransform canvas = self.View.E_Img_MaskImage.transform.parent.GetComponent<RectTransform>();
            GraphicRaycaster gr = canvas.GetComponent<GraphicRaycaster>();
            List<RaycastResult> results = new List<RaycastResult>();
            gr.Raycast(pdata, results);

            for (int i = 0; i < results.Count; i++)
            {
                string name = results[i].gameObject.name;
                if (!name.Contains("Right_Skill_Icon_"))
                {
                    continue;
                }

                int index = int.Parse(name.Substring(17, name.Length - 17)) - 1;
                if (index >= 9)
                {
                    continue;
                }

                if (type == 1)
                {
                    self.SetSkill(index, index1);
                }
                else
                {
                    // self.SetSkill(index, self.SkillSet[index1]);
                    // 交换
                    (self.SkillSet[index1], self.SkillSet[index]) = (self.SkillSet[index], self.SkillSet[index1]);
                    self.UpdataSkillSetRight();
                }

                break;
            }

            // self.View.E_Img_MaskImage.transform.SetParent(self.GetParent<UI>().GameObject.transform);
            self.View.E_Img_MaskImage.gameObject.SetActive(false);
        }

        public static void UpdataSkillSetRight(this DlgSettingSkill self)
        {
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();

            SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();
            for (int i = 0; i < self.SkillSetIconRightList.Count; i++)
            {
                GameObject itemgo = self.SkillSetIconRightList[i];
                GameObject addImage = itemgo.transform.parent.GetChild(0).gameObject;

                itemgo.SetActive(false);
                addImage.GetComponent<Image>().fillAmount = 1;

                if (i >= self.SkillSet.Count)
                {
                    continue;
                }

                if (self.SkillSet[i] == -1)
                {
                    continue;
                }

                SkillPro skillPro = skillSetComponent.GetByPosition(self.SkillSet[i] + 1);

                if (skillPro == null)
                {
                    addImage.GetComponent<Image>().fillAmount = 1;
                    itemgo.SetActive(false);
                    continue;
                }

                addImage.GetComponent<Image>().fillAmount = 0;
                itemgo.SetActive(true);
                if (skillPro.SkillSetType == SkillSetEnum.Skill)
                {
                    SkillConfig skillConfig = SkillConfigCategory.Instance.Get(SkillHelp.GetWeaponSkill(skillPro.SkillID,
                        UnitHelper.GetEquipType(self.Root()), skillSetComponent.SkillList));
                    string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, skillConfig.SkillIcon);
                    Sprite sp = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);

                    itemgo.transform.Find("Img_Mask/Img_SkillIcon").GetComponent<Image>().sprite = sp;
                }
            }
        }

        public static void OnClick(this DlgSettingSkill self, int index)
        {
            Log.Debug($"点击技能{index}");
            if (self.SkillSet.Contains(index))
            {
                FlyTipComponent.Instance.ShowFlyTip("已放置该技能！");
                return;
            }

            self.SetSkill(-1, index);
        }

        public static void SetSkill(this DlgSettingSkill self, int targetIndex, int myIndex)
        {
            if (targetIndex == -1) // 有空位就加进去
            {
                for (int i = 0; i < self.SkillSet.Count; i++)
                {
                    if (self.SkillSet[i] == -1)
                    {
                        self.SkillSet[i] = myIndex;
                        break;
                    }
                }
            }
            else // 放到指定位置
            {
                for (int i = 0; i < self.SkillSet.Count; i++)
                {
                    if (self.SkillSet[i] == myIndex)
                    {
                        self.SkillSet[i] = -1;
                        break;
                    }
                }

                self.SkillSet[targetIndex] = myIndex;
            }

            self.UpdataSkillSetRight();
        }

        public static async ETTask OnCloseBtnButton(this DlgSettingSkill self)
        {
            string skillSet = string.Empty;
            if (self.SkillSet.Count > 0)
            {
                foreach (int i in self.SkillSet)
                {
                    skillSet += i + "@";
                }

                skillSet = skillSet.Substring(0, skillSet.Length - 1);
            }

            self.GameSettingInfos.Add(new KeyValuePair() { KeyId = (int)GameSettingEnum.GuaJiAutoUseSkill, Value = skillSet });
            self.Root().GetComponent<UserInfoComponentC>().UpdateGameSetting(self.GameSettingInfos);
            EventSystem.Instance.Publish(self.Root(), new SettingUpdate());

            await BagClientNetHelper.GameSetting(self.Root(), self.GameSettingInfos);

            self.CloseAction?.Invoke();
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_SettingSkill);
        }

        public static void OnResetBtnButton(this DlgSettingSkill self)
        {
            for (int i = 0; i < self.SkillSet.Count; i++)
            {
                self.SkillSet[i] = -1;
            }

            self.UpdataSkillSetRight();
        }
    }
}
