using System.Collections.Generic;
using System.Text;
using I2.Loc;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgMainViewComponent))]
    [FriendOf(typeof(MJCameraComponent))]
    [FriendOf(typeof(ES_MainSkill))]
    [EntitySystemOf(typeof(ES_SettingGame))]
    [FriendOfAttribute(typeof(ES_SettingGame))]
    public static partial class ES_SettingGameSystem
    {
        [EntitySystem]
        private static void Awake(this ES_SettingGame self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_BtnItemTypeSetToggleGroup.AddListener(self.OnItemTypeSet);
            
            self.EG_ClickRectTransform.Find("Btn_Click").GetComponent<Button>().AddListener(self.OnBtn_ClickButton);

            self.E_ButtonSkillSetButton.AddListenerAsync(self.OnButtonSkillSetButton);
            self.E_ButtonReSetButton.AddListener(self.OnButtonReSetButton);

            self.EG_YinYingRectTransform.Find("Btn_Click").GetComponent<Button>().AddListener(self.OnBtn_YinYingButton);

            self.EG_RandomHoreseRectTransform.Find("Btn_Click").GetComponent<Button>().AddListener(self.OnBtn_RandomHorese);

            self.EG_LenDepthSetRectTransform.GetComponentInChildren<Slider>().onValueChanged
                    .AddListener((value) => { self.OnLenDepth(value); });
            self.EG_CameraHorizontalOffsetRectTransform.GetComponentInChildren<Slider>().onValueChanged
                    .AddListener((value) => { self.CameraHorizontalOffset(value); });
            self.EG_CameraVerticalOffsetRectTransform.GetComponentInChildren<Slider>().onValueChanged
                    .AddListener((value) => { self.CameraVerticalOffset(value); });

            self.EG_RotaAngleSetRectTransform.Find("Btn_Click").GetComponent<Button>().AddListener(self.OnBtn_RotaAngle);

            self.E_LocalizationBtnButton.AddListener(self.OnLocalizationBtnButton);

            self.RefreshLocalizationBtn();
            self.E_ReSetCameraBtnButton.AddListener(self.OnReSetCameraBtnButton);
            self.E_TestViewBtnButton.AddListener(self.OnTestView);
            self.E_PrintViewBtnButton.AddListener(self.OnPrintView);

            self.EG_ZhuBoSetRectTransform.Find("Btn_Click").GetComponent<Button>().AddListener(self.OnBtn_ZhuBo);

            self.EG_FirstUnionNameRectTransform.Find("Btn_Click").GetComponent<Button>().AddListener(self.OnBtn_FirstUnionName);

            self.EG_SkillAttackPlayerFirstRectTransform.Find("Btn_Click").GetComponent<Button>().AddListener(self.OnSkillAttackPlayerFirst);

            self.EG_HideLeftBottomRectTransform.Find("Btn_Click").GetComponent<Button>().AddListener(self.OnBtn_HideLeftBottom);

            self.EG_AutoAttackRectTransform.Find("Btn_Click").GetComponent<Button>().AddListener(self.OnBtn_AutoAttack);

            self.E_NoMovingButton.AddListener(self.OnNoMovingButton);

            self.EG_HideNodeRectTransform.gameObject.SetActive(GlobalHelp.GetPlatform() != 5 && GlobalHelp.GetPlatform() != 6);

            self.EG_OneSellSetRectTransform.Find("Btn_Click_0").GetComponent<Button>().AddListener(() => { self.OnBtn_OneSellSet(0); });
            self.EG_OneSellSetRectTransform.Find("Btn_Click_1").GetComponent<Button>().AddListener(() => { self.OnBtn_OneSellSet(1); });
            self.EG_OneSellSetRectTransform.Find("Btn_Click_2").GetComponent<Button>().AddListener(() => { self.OnBtn_OneSellSet(2); });
            self.EG_OneSellSetRectTransform.Find("Btn_Click_3").GetComponent<Button>().AddListener(() => { self.OnBtn_OneSellSet(3); });

            self.EG_PickSetRectTransform.Find("Btn_Click_0").GetComponent<Button>().AddListener(() => { self.OnBtn_PickSet(0); });
            self.EG_PickSetRectTransform.Find("Btn_Click_1").GetComponent<Button>().AddListener(() => { self.OnBtn_PickSet(1); });

            self.EG_ActTypeSetRectTransform.Find("Btn_Click_0").GetComponent<Button>().AddListener(() => { self.OnBtn_AttackMode("0"); });
            self.EG_ActTypeSetRectTransform.Find("Btn_Click_1").GetComponent<Button>().AddListener(() => { self.OnBtn_AttackMode("1"); });
            self.EG_ActTypeSetRectTransform.Find("Btn_Click_2").GetComponent<Button>().AddListener(() => { self.OnBtn_AttackMode("2"); });
            self.EG_ActTypeSetRectTransform.Find("Btn_Click_3").GetComponent<Button>().AddListener(() => { self.OnBtn_AttackMode("3"); });

            self.EG_ActTargetSelectRectTransform.Find("Btn_Click_0").GetComponent<Button>().AddListener(() => { self.OnActTargetSelect("0"); });
            self.EG_ActTargetSelectRectTransform.Find("Btn_Click_1").GetComponent<Button>().AddListener(() => { self.OnActTargetSelect("1"); });

            self.E_SliderSoundSlider.onValueChanged.AddListener((float value) => { self.OnSliderSoundChange(value); });

            self.E_SliderMusicSlider.onValueChanged.AddListener((float value) => { self.OnSliderMusicChange(value); });

            self.EG_FpsRectTransform.Find("Btn_Click").GetComponent<Button>().AddListener(self.OnBtn_FpsButton);
            bool oldValue = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>().View.EG_FpsRectTransform.gameObject.activeSelf;
            self.EG_FpsRectTransform.Find("On").gameObject.SetActive(oldValue);
            self.EG_FpsRectTransform.Find("Off").gameObject.SetActive(!oldValue);

            self.E_InputFieldCNameInputField.onValueChanged.AddListener((text) => { self.CheckSensitiveWords(); });

            self.E_Btn_CloseGameButton.AddListener(self.OnBtn_CloseGameButton);
            self.E_Btn_ReturnDengLuButton.AddListener(self.OnBtn_ReturnDengLuButton);

            self.E_Btn_SoundButton.AddListener(self.OnBtn_SoundButton);
            self.E_Btn_YinYueButton.AddListener(self.OnBtn_YinYueButton);
            self.E_ButtonRnameButton.AddListenerAsync(self.OnButtonRnameButton);

            self.E_ButtonPhoneButton.AddListener(self.OnButtonPhoneButton);

            self.EG_HighFpsRectTransform.Find("Btn_Click").GetComponent<Button>().AddListener(self.OnHighFps);

            self.EG_SmoothRectTransform.Find("Btn_Click").GetComponent<Button>().AddListener(self.OnSmooth);

            self.EG_NoShowOtherRectTransform.Find("Btn_Click").GetComponent<Button>().AddListener(self.OnNoShowOther);

            self.E_GameMemoryButton.AddListener(self.OnGameMemoryButton);

            self.EG_FixedRectTransform.Find("Btn_Click").GetComponent<Button>().AddListener(self.OnBtn_FixedButton);

            self.E_ScreenToggle0Toggle.AddListener(self.OnScreenToggle0_Ex);
            self.E_ScreenToggle1Toggle.AddListener(self.OnScreenToggle1_Ex);

            self.UserInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            self.InitUI();
            
            self.E_BtnItemTypeSetToggleGroup.OnSelectIndex(0);
        }

        [EntitySystem]
        private static void Destroy(this ES_SettingGame self)
        {
            self.DestroyWidget();
        }

        private static void OnItemTypeSet(this ES_SettingGame self, int index)
        {
            self.E_ScrollView_0ScrollRect.gameObject.SetActive(index == 0);
            self.E_ScrollView_1ScrollRect.gameObject.SetActive(index == 1);
            self.E_ScrollView_2ScrollRect.gameObject.SetActive(index == 2);
            self.E_ScrollView_3ScrollRect.gameObject.SetActive(index == 3);
        }

        public static void OnScreenToggle0_Ex(this ES_SettingGame self, bool value)
        {
            if (value)
            {
                self.SaveSettings(GameSettingEnum.FenBianlLv, "1");
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>().SetFenBianLv1();
            }
        }

        public static void OnScreenToggle1_Ex(this ES_SettingGame self, bool value)
        {
            if (value)
            {
                self.SaveSettings(GameSettingEnum.FenBianlLv, "2");
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>().SetFenBianLv2();
            }
        }

        public static void OnSliderSoundChange(this ES_SettingGame self, float value)
        {
            SoundComponent.Instance.ChangeSoundVolume(value);
        }

        public static void OnSliderMusicChange(this ES_SettingGame self, float value)
        {
            SoundComponent.Instance.ChangeMusicVolume(value);
        }

        public static async ETTask OnButtonSkillSetButton(this ES_SettingGame self)
        {
            DlgMain dlgMain = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>();
            if (!dlgMain.View.ES_MainSkill.uiTransform.gameObject.activeSelf)
            {
                FlyTipComponent.Instance.ShowFlyTip("请移动至有技能框的区域，比如探险地区进行更改。");
                return;
            }

            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_ButtonPositionSet);
            DlgButtonPositionSet dlgButtonPositionSet = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgButtonPositionSet>();
            dlgButtonPositionSet.ShowSkillPositionSet();
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Setting);
        }

        private static void OnButtonReSetButton(this ES_SettingGame self)
        {
            UserInfoComponentC userInfoComponentC = self.Root().GetComponent<UserInfoComponentC>();
            self.SaveSettings(GameSettingEnum.Music, userInfoComponentC.GetDefaultGameSettingValue(GameSettingEnum.Music));
            self.SaveSettings(GameSettingEnum.Sound, userInfoComponentC.GetDefaultGameSettingValue(GameSettingEnum.Sound));
            self.SaveSettings(GameSettingEnum.YanGan, userInfoComponentC.GetDefaultGameSettingValue(GameSettingEnum.YanGan));
            self.SaveSettings(GameSettingEnum.MusicVolume, userInfoComponentC.GetDefaultGameSettingValue(GameSettingEnum.MusicVolume));
            self.SaveSettings(GameSettingEnum.SoundVolume, userInfoComponentC.GetDefaultGameSettingValue(GameSettingEnum.SoundVolume));
            self.SaveSettings(GameSettingEnum.FenBianlLv, userInfoComponentC.GetDefaultGameSettingValue(GameSettingEnum.FenBianlLv));
            self.SaveSettings(GameSettingEnum.HighFps, userInfoComponentC.GetDefaultGameSettingValue(GameSettingEnum.HighFps));
            self.SaveSettings(GameSettingEnum.Click, userInfoComponentC.GetDefaultGameSettingValue(GameSettingEnum.Click));
            self.SaveSettings(GameSettingEnum.Shadow, userInfoComponentC.GetDefaultGameSettingValue(GameSettingEnum.Shadow));
            self.SaveSettings(GameSettingEnum.RandomHorese, userInfoComponentC.GetDefaultGameSettingValue(GameSettingEnum.RandomHorese));
            self.SaveSettings(GameSettingEnum.OneSellSet, userInfoComponentC.GetDefaultGameSettingValue(GameSettingEnum.OneSellSet));
            self.SaveSettings(GameSettingEnum.AttackMode, userInfoComponentC.GetDefaultGameSettingValue(GameSettingEnum.AttackMode));
            self.SaveSettings(GameSettingEnum.AttackTarget, userInfoComponentC.GetDefaultGameSettingValue(GameSettingEnum.AttackTarget));
            self.SaveSettings(GameSettingEnum.Smooth, userInfoComponentC.GetDefaultGameSettingValue(GameSettingEnum.Smooth));
            self.SaveSettings(GameSettingEnum.NoShowOther, userInfoComponentC.GetDefaultGameSettingValue(GameSettingEnum.NoShowOther));
            self.SaveSettings(GameSettingEnum.AutoAttack, userInfoComponentC.GetDefaultGameSettingValue(GameSettingEnum.AutoAttack));
            self.SaveSettings(GameSettingEnum.OneSellSet2, userInfoComponentC.GetDefaultGameSettingValue(GameSettingEnum.OneSellSet2));
            self.SaveSettings(GameSettingEnum.HideLeftBottom, userInfoComponentC.GetDefaultGameSettingValue(GameSettingEnum.HideLeftBottom));
            self.SaveSettings(GameSettingEnum.FirstUnionName, userInfoComponentC.GetDefaultGameSettingValue(GameSettingEnum.FirstUnionName));
            self.SaveSettings(GameSettingEnum.SkillAttackPlayerFirst, userInfoComponentC.GetDefaultGameSettingValue(GameSettingEnum.SkillAttackPlayerFirst));
            self.SaveSettings(GameSettingEnum.PickSet, userInfoComponentC.GetDefaultGameSettingValue(GameSettingEnum.PickSet));
            
            PlayerPrefsHelp.SetString(PlayerPrefsHelp.MusicVolume, "1");
            PlayerPrefsHelp.SetString(PlayerPrefsHelp.SoundVolume, "1");

            self.OnReSetCameraBtnButton();

            PlayerPrefsHelp.SetInt(PlayerPrefsHelp.ZhuBo, 0);
            
            self.InitUI();
        }

        public static void OnBtn_ClickButton(this ES_SettingGame self)
        {
            string value = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.Click);
            self.EG_ClickRectTransform.Find("On").gameObject.SetActive(value == "0");
            self.EG_ClickRectTransform.Find("Off").gameObject.SetActive(value != "0");
            self.SaveSettings(GameSettingEnum.Click, value == "0" ? "1" : "0");
            self.Root().CurrentScene().GetComponent<OperaComponent>().UpdateClickMode();
        }

        public static void OnBtn_YinYingButton(this ES_SettingGame self)
        {
            string value = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.Shadow);
            self.EG_YinYingRectTransform.Find("On").gameObject.SetActive(value == "0");
            self.EG_YinYingRectTransform.Find("Off").gameObject.SetActive(value != "0");
            self.SaveSettings(GameSettingEnum.Shadow, value == "0" ? "1" : "0");
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>().UpdateShadow(value == "0" ? "1" : "0");
        }

        public static void UpdateShadow(this ES_SettingGame self)
        {
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>().UpdateShadow();
        }

        public static void OnBtn_AttackMode(this ES_SettingGame self, string attackmode)
        {
            self.SaveSettings(GameSettingEnum.AttackMode, attackmode);
            self.UpdateAttackMode();
        }

        public static void OnActTargetSelect(this ES_SettingGame self, string attackmode)
        {
            self.SaveSettings(GameSettingEnum.AttackTarget, attackmode);
            self.Root().GetComponent<LockTargetComponent>().AttackTarget = int.Parse(attackmode);
            self.UpdateAttackTarget();
        }

        public static void OnBtn_OneSellSet(this ES_SettingGame self, int index)
        {
            string value = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.OneSellSet);
            string[] setvalues = value.Split('@');
            if (setvalues.Length < 4)
            {
                value = "1@0@0@0";
            }

            setvalues = value.Split('@');
            setvalues[index] = setvalues[index] == "1" ? "0" : "1";

            value = $"{setvalues[0]}@{setvalues[1]}@{setvalues[2]}@{setvalues[3]}";

            using (zstring.Block())
            {
                self.EG_OneSellSetRectTransform.Find(zstring.Format("Image_Click_{0}", index)).gameObject.SetActive(setvalues[index] == "1");
                self.EG_OneSellSetRectTransform.Find(zstring.Format("Text_{0}", index)).gameObject.SetActive(setvalues[index] != "1");
            }

            self.SaveSettings(GameSettingEnum.OneSellSet, value);
        }

        public static void OnBtn_PickSet(this ES_SettingGame self, int index)
        {
            string value = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.PickSet);
            string[] setvalues = value.Split('@');
            setvalues[index] = setvalues[index] == "1" ? "0" : "1";
            value = $"{setvalues[0]}@{setvalues[1]}";

            using (zstring.Block())
            {
                self.EG_PickSetRectTransform.Find(zstring.Format("Image_Click_{0}", index)).gameObject.SetActive(setvalues[index] == "1");
                self.EG_PickSetRectTransform.Find(zstring.Format("Text_{0}", index)).gameObject.SetActive(setvalues[index] != "1");
            }

            self.SaveSettings(GameSettingEnum.PickSet, value);
            self.UserInfoComponent.PickSet = value.Split('@');
        }

        public static void OnBtn_ZhuBo(this ES_SettingGame self)
        {
            int value = PlayerPrefsHelp.GetInt(PlayerPrefsHelp.ZhuBo);
            self.EG_ZhuBoSetRectTransform.Find("On").gameObject.SetActive(value == 0);
            self.EG_ZhuBoSetRectTransform.Find("Off").gameObject.SetActive(value != 0);
            PlayerPrefsHelp.SetInt(PlayerPrefsHelp.ZhuBo, value == 0 ? 1 : 0);
        }

        public static void OnBtn_RandomHorese(this ES_SettingGame self)
        {
            string value = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.RandomHorese);
            self.EG_RandomHoreseRectTransform.Find("On").gameObject.SetActive(value == "0");
            self.EG_RandomHoreseRectTransform.Find("Off").gameObject.SetActive(value != "0");
            self.SaveSettings(GameSettingEnum.RandomHorese, value == "0" ? "1" : "0");
        }

        public static void OnReSetCameraBtnButton(this ES_SettingGame self)
        {
            PlayerPrefsHelp.SetFloat(PlayerPrefsHelp.LenDepth, PlayerPrefsHelp.LenDepth_Default);
            PlayerPrefsHelp.SetFloat(PlayerPrefsHelp.CameraHorizontalOffset, PlayerPrefsHelp.CameraHorizontalOffset_Default);
            PlayerPrefsHelp.SetFloat(PlayerPrefsHelp.CameraVerticalOffset, PlayerPrefsHelp.CameraVerticalOffset_Default);
            PlayerPrefsHelp.SetInt(PlayerPrefsHelp.RotaAngle, 0);
            PlayerPrefsHelp.SetFloat(PlayerPrefsHelp.OffsetPostion_X, PlayerPrefsHelp.OffsetPostion_X_Default);
            PlayerPrefsHelp.SetFloat(PlayerPrefsHelp.OffsetPostion_Y, PlayerPrefsHelp.OffsetPostion_Y_Default);
            PlayerPrefsHelp.SetFloat(PlayerPrefsHelp.OffsetPostion_Z, PlayerPrefsHelp.OffsetPostion_Z_Default);

            self.EG_LenDepthSetRectTransform.GetComponentInChildren<Slider>().SetValueWithoutNotify((PlayerPrefsHelp.LenDepth_Default - 0.1f) / 2);
            self.EG_CameraHorizontalOffsetRectTransform.GetComponentInChildren<Slider>().SetValueWithoutNotify((PlayerPrefsHelp.CameraHorizontalOffset_Default + 4) / 8);
            self.EG_CameraVerticalOffsetRectTransform.GetComponentInChildren<Slider>().SetValueWithoutNotify((PlayerPrefsHelp.CameraVerticalOffset_Default + 4) / 8);
            
            self.EG_RotaAngleSetRectTransform.Find("On").gameObject.SetActive(false);
            self.EG_RotaAngleSetRectTransform.Find("Off").gameObject.SetActive(true);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>().View.E_DragPanelImage.gameObject.SetActive(false);

            self.Root().CurrentScene().GetComponent<MJCameraComponent>()?.SetView();
        }

        private static void OnTestView(this ES_SettingGame self)
        {
            // 自定义视角后，可在设置界面点击打印镜头参数按钮，查看当前镜头参数
            // 打印信息在Console窗口中，类型为Warning
            float LenDepth = 0.6430578f; // 镜头纵深，值越大镜头离角色越远
            float3 OffsetPostion = new float3(0f, 1.0571f, -11.55173f); // 相机与人物的坐标的偏移量
            float CameraHorizontalOffset = 0f; // 看向角色的水平偏差，值越大镜头越右
            float CameraVerticalOffset = 1.808699f; // 看向角色的垂直偏差，值越大镜头越往上

            self.EG_LenDepthSetRectTransform.GetComponentInChildren<Slider>().SetValueWithoutNotify(LenDepth <= 0 ? 0.4f : (LenDepth - 0.1f) / 2);
            self.EG_CameraHorizontalOffsetRectTransform.GetComponentInChildren<Slider>().SetValueWithoutNotify((CameraHorizontalOffset + 4) / 8);
            self.EG_CameraVerticalOffsetRectTransform.GetComponentInChildren<Slider>().SetValueWithoutNotify((CameraVerticalOffset + 4) / 8);

            PlayerPrefsHelp.SetFloat(PlayerPrefsHelp.LenDepth, LenDepth);
            PlayerPrefsHelp.SetFloat(PlayerPrefsHelp.OffsetPostion_X, OffsetPostion.x);
            PlayerPrefsHelp.SetFloat(PlayerPrefsHelp.OffsetPostion_Y, OffsetPostion.y);
            PlayerPrefsHelp.SetFloat(PlayerPrefsHelp.OffsetPostion_Z, OffsetPostion.z);
            PlayerPrefsHelp.SetFloat(PlayerPrefsHelp.CameraHorizontalOffset, CameraHorizontalOffset);
            PlayerPrefsHelp.SetFloat(PlayerPrefsHelp.CameraVerticalOffset, CameraVerticalOffset);

            self.Root().CurrentScene().GetComponent<MJCameraComponent>()?.SetView();

            FlyTipComponent.Instance.ShowFlyTip("调整为测试视角");
        }

        public static void OnPrintView(this ES_SettingGame self)
        {
            MJCameraComponent cameraComponent = self.Root().CurrentScene().GetComponent<MJCameraComponent>();

            Log.Warning("================当前视角参数================");
            Log.Warning($"LenDepth : {cameraComponent.LenDepth}");
            Log.Warning($"OffsetPosition : {cameraComponent.OffsetPosition}");
            Log.Warning($"CameraHorizontalOffset : {cameraComponent.HorizontalOffset}");
            Log.Warning($"CameraVerticalOffset : {cameraComponent.VerticalOffset}");
            Log.Warning("==========================================");

            // FlyTipComponent.Instance.ShowFlyTip("视角参数打印成功，请在Console窗口中查看，类型Warning");
        }

        public static void OnLenDepth(this ES_SettingGame self, float value)
        {
            float va = 0.1f + value * 2;
            self.Root().CurrentScene().GetComponent<MJCameraComponent>().LenDepth = va;
            PlayerPrefsHelp.SetFloat(PlayerPrefsHelp.LenDepth, va);
        }

        public static void OnBtn_RotaAngle(this ES_SettingGame self)
        {
            int value = PlayerPrefsHelp.GetInt(PlayerPrefsHelp.RotaAngle);
            self.EG_RotaAngleSetRectTransform.Find("On").gameObject.SetActive(value == 0);
            self.EG_RotaAngleSetRectTransform.Find("Off").gameObject.SetActive(value != 0);
            PlayerPrefsHelp.SetInt(PlayerPrefsHelp.RotaAngle, value == 0 ? 1 : 0);

            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>().View.E_DragPanelImage.gameObject.SetActive(value == 0);
        }

        public static void CameraHorizontalOffset(this ES_SettingGame self, float value)
        {
            float va = -4 + value * 8;
            self.Root().CurrentScene().GetComponent<MJCameraComponent>().HorizontalOffset = va;
            PlayerPrefsHelp.SetFloat(PlayerPrefsHelp.CameraHorizontalOffset, va);
        }

        public static void CameraVerticalOffset(this ES_SettingGame self, float value)
        {
            float va = -4 + value * 8;
            self.Root().CurrentScene().GetComponent<MJCameraComponent>().VerticalOffset = va;
            PlayerPrefsHelp.SetFloat(PlayerPrefsHelp.CameraVerticalOffset, va);
        }

        public static void OnLocalizationBtnButton(this ES_SettingGame self)
        {
            string languageName = PlayerPrefsHelp.GetString(PlayerPrefsHelp.Localization, "Chinese");

            if (languageName == "Chinese")
            {
                languageName = "English";
                LanguageComponent.Instance.SetLanguage("English", true);
            }
            else
            {
                languageName = "Chinese";
                LanguageComponent.Instance.SetLanguage("Chinese", true);
            }

            FlyTipComponent.Instance.ShowFlyTip(ScriptLocalization.成功);

            PlayerPrefsHelp.SetString(PlayerPrefsHelp.Localization, languageName);
            self.RefreshLocalizationBtn();
        }

        public static void RefreshLocalizationBtn(this ES_SettingGame self)
        {
            string languageName = PlayerPrefsHelp.GetString(PlayerPrefsHelp.Localization, "Chinese");

            if (languageName == "Chinese")
            {
                self.E_LocalizationBtnButton.GetComponentInChildren<Text>().text = "切换成英文";
            }
            else
            {
                self.E_LocalizationBtnButton.GetComponentInChildren<Text>().text = "切换成中文";
            }
        }

        public static void OnBtn_FirstUnionName(this ES_SettingGame self)
        {
            string value = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.FirstUnionName);
            self.EG_FirstUnionNameRectTransform.Find("On").gameObject.SetActive(value == "0");
            self.EG_FirstUnionNameRectTransform.Find("Off").gameObject.SetActive(value != "0");
            self.SaveSettings(GameSettingEnum.FirstUnionName, value == "0" ? "1" : "0");
        }

        public static void OnSkillAttackPlayerFirst(this ES_SettingGame self)
        {
            string value = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.SkillAttackPlayerFirst);
            self.EG_SkillAttackPlayerFirstRectTransform.Find("On").gameObject.SetActive(value == "0");
            self.EG_SkillAttackPlayerFirstRectTransform.Find("Off").gameObject.SetActive(value != "0");
            self.SaveSettings(GameSettingEnum.SkillAttackPlayerFirst, value == "0" ? "1" : "0");
            self.Root().GetComponent<LockTargetComponent>().SkillAttackPlayerFirst = int.Parse(value == "0" ? "1" : "0");
        }

        public static void OnNoMovingButton(this ES_SettingGame self)
        {
            SettingData.HideNoMoving = !SettingData.HideNoMoving;
        }

        public static void OnBtn_HideLeftBottom(this ES_SettingGame self)
        {
            string value = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.HideLeftBottom);
            self.EG_HideLeftBottomRectTransform.Find("On").gameObject.SetActive(value == "0");
            self.EG_HideLeftBottomRectTransform.Find("Off").gameObject.SetActive(value != "0");
            self.SaveSettings(GameSettingEnum.HideLeftBottom, value == "0" ? "1" : "0");
        }

        public static void OnBtn_AutoAttack(this ES_SettingGame self)
        {
            string value = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.AutoAttack);
            self.EG_AutoAttackRectTransform.Find("On").gameObject.SetActive(value == "0");
            self.EG_AutoAttackRectTransform.Find("Off").gameObject.SetActive(value != "0");
            self.SaveSettings(GameSettingEnum.AutoAttack, value == "0" ? "1" : "0");

            AttackComponent attackComponent = self.Root().GetComponent<AttackComponent>();
            attackComponent.AutoAttack = value == "0";
        }

        public static void InitUI(this ES_SettingGame self)
        {
            self.E_Image_yinyuImage.gameObject.SetActive(self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.Music) == "1");
            self.E_Image_SoundImage.gameObject.SetActive(self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.Sound) == "1");
            
            self.EG_YinYingRectTransform.Find("On").gameObject.SetActive(self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.Shadow) == "1");
            self.EG_YinYingRectTransform.Find("Off").gameObject.SetActive(self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.Shadow) != "1");

            string music = PlayerPrefsHelp.GetString(PlayerPrefsHelp.MusicVolume);
            float musicvalue = string.IsNullOrEmpty(music) ? 1f : float.Parse(music);
            self.E_SliderSoundSlider.value = musicvalue;

            string sound = PlayerPrefsHelp.GetString(PlayerPrefsHelp.SoundVolume);
            float soundvalue = string.IsNullOrEmpty(sound) ? 1f : float.Parse(sound);
            self.E_SliderMusicSlider.value = soundvalue;

            self.E_ScreenToggle0Toggle.isOn = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.FenBianlLv) == "1";
            self.E_ScreenToggle1Toggle.isOn = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.FenBianlLv) == "2";
            
            self.EG_ClickRectTransform.Find("On").gameObject.SetActive(self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.Click) == "1");
            self.EG_ClickRectTransform.Find("Off").gameObject.SetActive(self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.Click) != "1");
            
            self.EG_RandomHoreseRectTransform.Find("On").gameObject.SetActive(self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.RandomHorese) == "1");
            self.EG_RandomHoreseRectTransform.Find("Off").gameObject.SetActive(self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.RandomHorese) != "1");
            
            self.EG_FirstUnionNameRectTransform.Find("On").gameObject.SetActive(self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.FirstUnionName) == "1");
            self.EG_FirstUnionNameRectTransform.Find("Off").gameObject.SetActive(self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.FirstUnionName) != "1");
            
            self.EG_SkillAttackPlayerFirstRectTransform.Find("On").gameObject.SetActive(self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.SkillAttackPlayerFirst) == "1");
            self.EG_SkillAttackPlayerFirstRectTransform.Find("Off").gameObject.SetActive(self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.SkillAttackPlayerFirst) != "1");
            
            self.EG_AutoAttackRectTransform.Find("On").gameObject.SetActive(self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.AutoAttack) == "1");
            self.EG_AutoAttackRectTransform.Find("Off").gameObject.SetActive(self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.AutoAttack) != "1");
            
            self.EG_HideLeftBottomRectTransform.Find("On").gameObject.SetActive(self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.HideLeftBottom) == "1");
            self.EG_HideLeftBottomRectTransform.Find("Off").gameObject.SetActive(self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.HideLeftBottom) != "1");
            
            self.EG_NoShowOtherRectTransform.Find("On").gameObject.SetActive(self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.NoShowOther) == "1");
            self.EG_NoShowOtherRectTransform.Find("Off").gameObject.SetActive(self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.NoShowOther) != "1");
            
            self.EG_RotaAngleSetRectTransform.Find("On").gameObject.SetActive(PlayerPrefsHelp.GetInt(PlayerPrefsHelp.RotaAngle) == 1);
            self.EG_RotaAngleSetRectTransform.Find("Off").gameObject.SetActive(PlayerPrefsHelp.GetInt(PlayerPrefsHelp.RotaAngle) != 1);

            float LenDepth = PlayerPrefsHelp.GetFloat(PlayerPrefsHelp.LenDepth);
            self.EG_LenDepthSetRectTransform.GetComponentInChildren<Slider>().SetValueWithoutNotify(LenDepth <= 0 ? 0.4f : (LenDepth - 0.1f) / 2);
            self.EG_CameraHorizontalOffsetRectTransform.GetComponentInChildren<Slider>().SetValueWithoutNotify(
                (PlayerPrefsHelp.GetFloat(PlayerPrefsHelp.CameraHorizontalOffset) + 4) / 8);
            self.EG_CameraVerticalOffsetRectTransform.GetComponentInChildren<Slider>().SetValueWithoutNotify(
                (PlayerPrefsHelp.GetFloat(PlayerPrefsHelp.CameraVerticalOffset) + 4) / 8);
            
            self.EG_ZhuBoSetRectTransform.Find("On").gameObject.SetActive(PlayerPrefsHelp.GetInt(PlayerPrefsHelp.ZhuBo) == 1);
            self.EG_ZhuBoSetRectTransform.Find("Off").gameObject.SetActive(PlayerPrefsHelp.GetInt(PlayerPrefsHelp.ZhuBo) != 1);

            string value = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.OneSellSet);
            string[] setvalues = value.Split('@');

            self.EG_OneSellSetRectTransform.Find("Image_Click_0").gameObject.SetActive(setvalues[0] == "1");
            self.EG_OneSellSetRectTransform.Find("Text_0").gameObject.SetActive(setvalues[0] != "1");
            self.EG_OneSellSetRectTransform.Find("Image_Click_1").gameObject.SetActive(setvalues[1] == "1");
            self.EG_OneSellSetRectTransform.Find("Text_1").gameObject.SetActive(setvalues[1] != "1");
            self.EG_OneSellSetRectTransform.Find("Image_Click_2").gameObject.SetActive(setvalues[2] == "1");
            self.EG_OneSellSetRectTransform.Find("Text_2").gameObject.SetActive(setvalues[2] != "1");

            if (setvalues.Length > 3)
            {
                self.EG_OneSellSetRectTransform.Find("Image_Click_3").gameObject.SetActive(setvalues[3] == "1");
                self.EG_OneSellSetRectTransform.Find("Text_3").gameObject.SetActive(setvalues[3] != "1");
            }

            string value2 = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.PickSet);
            string[] setvalues2 = value2.Split('@');
            self.EG_PickSetRectTransform.Find("Image_Click_0").gameObject.SetActive(setvalues2[0] == "1");
            self.EG_PickSetRectTransform.Find("Text_0").gameObject.SetActive(setvalues2[0] != "1");
            self.EG_PickSetRectTransform.Find("Image_Click_1").gameObject.SetActive(setvalues2[1] == "1");
            self.EG_PickSetRectTransform.Find("Text_1").gameObject.SetActive(setvalues2[1] != "1");

            //梦境版号服去掉这3个   
            if (GlobalHelp.GetVersionMode() == 2)
            {
                self.UITransform.Find("Right/E_ScrollView_1/Viewport/Content/SettingItem_4").gameObject.SetActive(false);
                self.UITransform.Find("Right/E_ScrollView_1/Viewport/Content/SettingItem_6").gameObject.SetActive(false);
                self.UITransform.Find("Right/E_ScrollView_1/Viewport/Content/SettingItem_7").gameObject.SetActive(false);
            }

            self.UpdateYaoGan();
            self.UpdateShadow();
            self.UpdateHighFps();
            self.UpdateSmooth();
            self.UpdateNoShowOther();
            self.UpdateAttackMode();
            self.UpdateAttackTarget();
            self.E_TextVersionText.text = GlobalHelp.GetBigVersion().ToString();
            self.E_InputFieldCNameInputField.text = self.UserInfoComponent.UserInfo.Name;
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            long lastTime = unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.LastLoginTime);
            self.E_LastLoginTimeText.text = TimeInfo.Instance.ToDateTime(lastTime).ToString();
        }

        public static void UpdateAttackMode(this ES_SettingGame self)
        {
            string acttype = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.AttackMode);
            self.EG_ActTypeSetRectTransform.Find("Image_Click_0").gameObject.SetActive(acttype == "0");
            self.EG_ActTypeSetRectTransform.Find("Image_Click_1").gameObject.SetActive(acttype == "1");
            self.EG_ActTypeSetRectTransform.Find("Image_Click_2").gameObject.SetActive(acttype == "2");
            self.EG_ActTypeSetRectTransform.Find("Image_Click_3").gameObject.SetActive(acttype == "3");
        }

        public static void UpdateAttackTarget(this ES_SettingGame self)
        {
            string acttype = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.AttackTarget);
            self.EG_ActTargetSelectRectTransform.Find("Image_Click_0").gameObject.SetActive(acttype == "0");
            self.EG_ActTargetSelectRectTransform.Find("Image_Click_1").gameObject.SetActive(acttype == "1");
        }

        public static void OnBeforeClose(this ES_SettingGame self)
        {
            self.SendGameSetting().Coroutine();
        }

        public static void OnBtn_FpsButton(this ES_SettingGame self)
        {
            bool oldValue = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>().View.EG_FpsRectTransform.gameObject.activeSelf;
            self.EG_FpsRectTransform.Find("On").gameObject.SetActive(!oldValue);
            self.EG_FpsRectTransform.Find("Off").gameObject.SetActive(oldValue);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>().ShowPing();
        }

        public static async ETTask SendGameSetting(this ES_SettingGame self)
        {
            if (self.GameSettingInfos.Count > 0)
            {
                await BagClientNetHelper.GameSetting(self.Root(), self.GameSettingInfos);
            }
        }

        public static void OnBtn_CloseGameButton(this ES_SettingGame self)
        {
            PopupTipHelp.OpenPopupTip(self.Root(), "设置", "是否退出游戏?", () => { Application.Quit(); }).Coroutine();
        }

        public static void OnBtn_ReturnDengLuButton(this ES_SettingGame self)
        {
            self.E_HideDiImage.gameObject.SetActive(true);
            //加载登录场景
            EventSystem.Instance.Publish(self.Root(), new ReturnLogin());
        }

        public static void SaveSettings(this ES_SettingGame self, GameSettingEnum gameSettingEnum, string value)
        {
            bool exit = false;
            for (int i = 0; i < self.GameSettingInfos.Count; i++)
            {
                if (self.GameSettingInfos[i].KeyId == (int)gameSettingEnum)
                {
                    self.GameSettingInfos[i].Value = value;
                    exit = true;
                    break;
                }
            }

            if (!exit)
            {
                self.GameSettingInfos.Add(new KeyValuePair() { KeyId = (int)gameSettingEnum, Value = value });
            }

            self.Root().GetComponent<UserInfoComponentC>().UpdateGameSetting(self.GameSettingInfos);
        }

        public static void OnBtn_SoundButton(this ES_SettingGame self)
        {
            self.E_Image_SoundImage.gameObject.SetActive(!self.E_Image_SoundImage.gameObject.activeSelf);
            self.SaveSettings(GameSettingEnum.Sound, self.E_Image_SoundImage.gameObject.activeSelf ? "1" : "0");
        }

        public static void OnBtn_YinYueButton(this ES_SettingGame self)
        {
            self.E_Image_yinyuImage.gameObject.SetActive(!self.E_Image_yinyuImage.gameObject.activeSelf);
            self.SaveSettings(GameSettingEnum.Music, self.E_Image_yinyuImage.gameObject.activeSelf ? "1" : "0");
        }

        public static void OnBtn_FixedButton(this ES_SettingGame self)
        {
            string value = self.EG_FixedRectTransform.Find("On").gameObject.gameObject.activeSelf ? "1" : "0";
            self.SaveSettings(GameSettingEnum.YanGan, value);
            self.UpdateYaoGan();
        }

        public static void UpdateYaoGan(this ES_SettingGame self)
        {
            self.EG_FixedRectTransform.Find("On").gameObject.SetActive(self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.YanGan) == "0");
            self.EG_FixedRectTransform.Find("Off").gameObject.SetActive(self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.YanGan) != "0");
        }

        public static void OnHighFps(this ES_SettingGame self)
        {
            string oldValue = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.HighFps);
            if (oldValue == "0")
            {
                PopupTipHelp.OpenPopupTip(self.Root(), "系统提示", "开启高帧模式，根据手机的配置不同可能导致手机发热耗电的情况，如果出现此现象请及时关闭喔!", () =>
                {
                    self.SaveSettings(GameSettingEnum.HighFps, oldValue == "0" ? "1" : "0");
                    self.UpdateHighFps();
                }, null).Coroutine();
            }
            else
            {
                self.SaveSettings(GameSettingEnum.HighFps, oldValue == "0" ? "1" : "0");
                self.UpdateHighFps();
            }
        }

        public static void OnSmooth(this ES_SettingGame self)
        {
            string oldValue = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.Smooth);
            self.SaveSettings(GameSettingEnum.Smooth, oldValue == "0" ? "1" : "0");
            self.UpdateSmooth();
            SettingHelper.OnSmooth(oldValue == "0" ? "1" : "0");
        }

        public static void OnGameMemoryButton(this ES_SettingGame self)
        {
            self.SendGameMemory().Coroutine();
        }

        public static async ETTask SendGameMemory(this ES_SettingGame self)
        {
            if (GlobalHelp.GetBigVersion() < 17)
            {
                return;
            }

            BattleMessageComponent battleMessage = self.Root().GetComponent<BattleMessageComponent>();
            if (TimeHelper.ServerNow() - battleMessage.UploadMemoryTime < TimeHelper.Minute)
            {
                FlyTipComponent.Instance.ShowFlyTip("请不要频繁操作！");
                return;
            }

            long monouse = Profiler.GetMonoUsedSizeLong(); //使用的
            long totalallocated = Profiler.GetTotalAllocatedMemoryLong(); //unity分配的
            long totalreserved = Profiler.GetTotalReservedMemoryLong(); //总内存
            long unusedreserved = Profiler.GetTotalUnusedReservedMemoryLong(); //未使用的内存

            StringBuilder stringBuilder = StringBuilderData.stringBuilder;
            stringBuilder.Clear();
            stringBuilder.Append(
                $"内存占用: 当前使用:{monouse / 1024 / 1024}MB Unity分配:{totalallocated / 1024 / 1024}MB 总内存:{totalreserved / 1024 / 1024}MB 空闲内存:{unusedreserved / 1024 / 1024}MB");
            stringBuilder.AppendLine();

            stringBuilder.Append("EventSystem:");
            stringBuilder.AppendLine();
            stringBuilder.Append(EventSystem.Instance.ToString());
            stringBuilder.Append("ObjectPool:");
            stringBuilder.AppendLine();
            stringBuilder.Append(ObjectPool.Instance.ToString());
            // stringBuilder.Append("MonoPool:");
            // stringBuilder.AppendLine();
            // stringBuilder.Append(MonoPool.Instance.ToString());
            stringBuilder.Append("GameObjectPool:");
            stringBuilder.AppendLine();

            battleMessage.UploadMemoryTime = TimeHelper.ServerNow();

            Popularize2C_UploadResponse response = await BagClientNetHelper.Upload(self.Root(), stringBuilder.ToString());
        }

        public static void OnNoShowOther(this ES_SettingGame self)
        {
            string oldValue = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.NoShowOther);
            self.SaveSettings(GameSettingEnum.NoShowOther, oldValue == "0" ? "1" : "0");
            self.UpdateNoShowOther();
            SettingHelper.OnShowOther(oldValue == "0" ? "1" : "0");

            List<Unit> units = UnitHelper.GetUnitList(self.Root().CurrentScene(), UnitType.Player);
            for (int i = units.Count - 1; i >= 0; i--)
            {
                if (!units[i].MainHero && units[i].Type == UnitType.Player)
                {
                    units[i].GetParent<UnitComponent>().Remove(units[i].Id);
                }
            }
        }

        public static void UpdateHighFps(this ES_SettingGame self)
        {
            string oldValue = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.HighFps);
            self.EG_HighFpsRectTransform.Find("On").gameObject.SetActive(oldValue == "1");
            self.EG_HighFpsRectTransform.Find("Off").gameObject.SetActive(oldValue != "1");
            CommonViewHelper.TargetFrameRate(oldValue == "1" ? 60 : 30);
        }

        public static void UpdateSmooth(this ES_SettingGame self)
        {
            string oldValue = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.Smooth);
            self.EG_SmoothRectTransform.Find("On").gameObject.SetActive(oldValue == "1");
            self.EG_SmoothRectTransform.Find("Off").gameObject.SetActive(oldValue != "1");
        }

        public static void UpdateNoShowOther(this ES_SettingGame self)
        {
            string oldValue = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.NoShowOther);
            self.EG_NoShowOtherRectTransform.Find("On").gameObject.SetActive(oldValue == "1");
            self.EG_NoShowOtherRectTransform.Find("Off").gameObject.SetActive(oldValue != "1");
        }

        public static void CheckSensitiveWords(this ES_SettingGame self)
        {
            string text_new = "";
            string text_old = self.E_InputFieldCNameInputField.text;
            MaskWordHelper.Instance.IsContainSensitiveWords(ref text_old, out text_new);
            self.E_InputFieldCNameInputField.text = text_old;
        }

        public static void OnButtonPhoneButton(this ES_SettingGame self)
        {
            PlayerInfo playerInfo = self.Root().GetComponent<PlayerInfoComponent>().PlayerInfo;
            if (!string.IsNullOrEmpty(playerInfo.PhoneNumber))
            {
                using (zstring.Block())
                {
                    FlyTipComponent.Instance.ShowFlyTip(zstring.Format("已绑定手机号:{0}", playerInfo.PhoneNumber));
                }

                return;
            }

            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PhoneCode).Coroutine();
        }

        public static async ETTask OnButtonRnameButton(this ES_SettingGame self)
        {
            string text = self.E_InputFieldCNameInputField.text;

            if (string.IsNullOrEmpty(text))
            {
                FlyTipComponent.Instance.ShowFlyTip("名字不合法，请重新输入！");
                return;
            }

            if (text.Length >= 8)
            {
                FlyTipComponent.Instance.ShowFlyTip("角色名字过长，请重新输入！");
                return;
            }

            if (text.Contains("*") || !StringHelper.IsSpecialChar(text))
            {
                FlyTipComponent.Instance.ShowFlyTip("名字不合法，请重新输入！");
                return;
            }

            GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(70);
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            if (!bagComponent.CheckNeedItem(globalValueConfig.Value))
            {
                string needItem = CommonViewHelper.GetNeedItemDesc(globalValueConfig.Value);
                using (zstring.Block())
                {
                    FlyTipComponent.Instance.ShowFlyTip(zstring.Format("需要 {0}", needItem));
                }

                return;
            }

            M2C_ModifyNameResponse response = await BagClientNetHelper.ModifyName(self.Root(), text);

            if (response.Error == ErrorCode.ERR_Success)
            {
                FlyTipComponent.Instance.ShowFlyTip("修改名称成功！");
            }
        }
    }
}
