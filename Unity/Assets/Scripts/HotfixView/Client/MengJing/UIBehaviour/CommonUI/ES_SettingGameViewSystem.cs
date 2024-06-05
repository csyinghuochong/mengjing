using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_SettingGame))]
    [FriendOfAttribute(typeof (ES_SettingGame))]
    public static partial class ES_SettingGameSystem
    {
        [EntitySystem]
        private static void Awake(this ES_SettingGame self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_Btn_ClickButton.AddListener(self.OnBtn_Click);

            self.E_ButtonSkillSetButton.AddListener(self.OnButtonSkillSet);

            self.E_Btn_YinYingButton.AddListener(self.OnBtn_Shadow);

            self.EG_RandomHoreseRectTransform.Find("Btn_Click").GetComponent<Button>().AddListener(self.OnBtn_RandomHorese);

            self.EG_LenDepthSetRectTransform.GetComponentInChildren<Slider>().onValueChanged.AddListener((value) => { self.OnLenDepth(value); });

            self.EG_RotaAngleSetRectTransform.Find("Btn_Click").GetComponent<Button>().AddListener(self.OnBtn_RotaAngle);

            self.E_ReSetCameraBtnButton.AddListener(self.OnReSetCameraBtn);

            self.EG_ZhuBoSetRectTransform.Find("Btn_Click").GetComponent<Button>().AddListener(self.OnBtn_ZhuBo);

            self.EG_FirstUnionNameRectTransform.Find("Btn_Click").GetComponent<Button>().AddListener(self.OnBtn_FirstUnionName);

            self.EG_SkillAttackPlayerFirstRectTransform.Find("Btn_Click").GetComponent<Button>().AddListener(self.OnSkillAttackPlayerFirst);

            self.EG_HideLeftBottomRectTransform.Find("Btn_Click").GetComponent<Button>().AddListener(self.OnBtn_HideLeftBottom);

            self.EG_AutoAttackRectTransform.Find("Btn_Click").GetComponent<Button>().AddListener(self.OnBtn_AutoAttack);

            self.E_NoMovingButton.AddListener(self.OnBtn_NoMoving);

            // self.EG_HideNodeRectTransform.gameObject.SetActive(GlobalHelp.GetPlatform() != 5 && GlobalHelp.GetPlatform() != 6);

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

            self.E_Btn_FpsButton.AddListener(self.OnBtn_Fps);

            // self.E_Image_fpsImage.gameObject.SetActive(self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>().View.E_fp);

            self.E_InputFieldCNameInputField.onValueChanged.AddListener((text) => { self.CheckSensitiveWords(); });

            self.E_Btn_CloseGameButton.AddListener(self.OnCloseGame);
            self.E_Btn_ReturnDengLuButton.AddListener(self.OnReturnLogin);

            self.E_Btn_SoundButton.AddListener(self.OnBtn_Sound);
            self.E_Btn_YinYueButton.AddListener(self.OnBtn_YinYue);
            self.E_ButtonRnameButton.AddListenerAsync(self.OnButtonRname);
            
            self.EG_ButtonPhoneRectTransform
        }

        [EntitySystem]
        private static void Destroy(this ES_SettingGame self)
        {
            self.DestroyWidget();
        }

        public static void OnScreenToggle0_Ex(this ES_SettingGame self, bool value)
        {
            if (value)
            {
                self.SaveSettings(GameSettingEnum.FenBianlLv, "1");
                UIHelper.GetUI(self.ZoneScene(), UIType.UIMain).GetComponent<UIMainComponent>().SetFenBianLv1();
            }
        }

        public static void OnScreenToggle1_Ex(this ES_SettingGame self, bool value)
        {
            if (value)
            {
                self.SaveSettings(GameSettingEnum.FenBianlLv, "2");
                UIHelper.GetUI(self.ZoneScene(), UIType.UIMain).GetComponent<UIMainComponent>().SetFenBianLv2();
            }
        }

        public static void OnSliderSoundChange(this ES_SettingGame self, float value)
        {
            Game.Scene.GetComponent<SoundComponent>().ChangeSoundVolume(value);
        }

        public static void OnSliderMusicChange(this ES_SettingGame self, float value)
        {
            Game.Scene.GetComponent<SoundComponent>().ChangeMusicVolume(value);
        }

        public static void OnButtonSkillSet(this ES_SettingGame self)
        {
            UI uI = UIHelper.GetUI(self.ZoneScene(), UIType.UIMain);
            if (!uI.GetComponent<UIMainComponent>().UIMainSkill.activeSelf)
            {
                FloatTipManager.Instance.ShowFloatTip("请移动至有技能框的区域,比如探险地区进行更改");
                return;
            }

            uI.GetComponent<UIMainComponent>().UIMainButtonPositionComponent.ShowSkillPositionSet();
            UIHelper.Remove(self.ZoneScene(), UIType.UISetting);
        }

        public static void OnBtn_Click(this ES_SettingGame self)
        {
            string value = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.Click);
            self.Image_Click.SetActive(value == "0");
            self.SaveSettings(GameSettingEnum.Click, value == "0"? "1" : "0");
            self.ZoneScene().CurrentScene().GetComponent<OperaComponent>().UpdateClickMode();
        }

        public static void OnBtn_Shadow(this ES_SettingGame self)
        {
            string value = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.Shadow);
            self.Image_YinYing.SetActive(value == "0");
            self.SaveSettings(GameSettingEnum.Shadow, value == "0"? "1" : "0");
            UI uimain = UIHelper.GetUI(self.ZoneScene(), UIType.UIMain);
            uimain.GetComponent<UIMainComponent>().UpdateShadow(value == "0"? "1" : "0");
        }

        public static void UpdateShadow(this ES_SettingGame self)
        {
            UI uimain = UIHelper.GetUI(self.ZoneScene(), UIType.UIMain);
            uimain.GetComponent<UIMainComponent>().UpdateShadow();
        }

        public static void OnBtn_AttackMode(this ES_SettingGame self, string attackmode)
        {
            self.SaveSettings(GameSettingEnum.AttackMode, attackmode);
            self.UpdateAttackMode();
        }

        public static void OnActTargetSelect(this ES_SettingGame self, string attackmode)
        {
            self.SaveSettings(GameSettingEnum.AttackTarget, attackmode);
            self.ZoneScene().GetComponent<LockTargetComponent>().AttackTarget = int.Parse(attackmode);
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
            setvalues[index] = setvalues[index] == "1"? "0" : "1";

            value = $"{setvalues[0]}@{setvalues[1]}@{setvalues[2]}@{setvalues[3]}";

            self.OneSellSet.transform.Find($"Image_Click_{index}").gameObject.SetActive(setvalues[index] == "1");
            self.SaveSettings(GameSettingEnum.OneSellSet, value);
        }

        public static void OnBtn_PickSet(this ES_SettingGame self, int index)
        {
            string value = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.PickSet);
            string[] setvalues = value.Split('@');
            setvalues[index] = setvalues[index] == "1"? "0" : "1";
            value = $"{setvalues[0]}@{setvalues[1]}";

            self.PickSet.transform.Find($"Image_Click_{index}").gameObject.SetActive(setvalues[index] == "1");
            self.SaveSettings(GameSettingEnum.PickSet, value);
            self.UserInfoComponent.PickSet = value.Split('@');
        }

        public static void OnBtn_RotaAngle(this ES_SettingGame self)
        {
            int value = PlayerPrefsHelp.GetInt(PlayerPrefsHelp.RotaAngle);
            self.RotaAngleSet.transform.Find("Image_Click").gameObject.SetActive(value == 0);
            PlayerPrefsHelp.SetInt(PlayerPrefsHelp.RotaAngle, value == 0? 1 : 0);
            UIHelper.GetUI(self.ZoneScene(), UIType.UIMain).GetComponent<UIMainComponent>().DragPanel.SetActive(value == 0);
        }

        public static void OnBtn_ZhuBo(this ES_SettingGame self)
        {
            int value = PlayerPrefsHelp.GetInt(PlayerPrefsHelp.ZhuBo);
            self.ZhuBoSet.transform.Find("Image_Click").gameObject.SetActive(value == 0);
            PlayerPrefsHelp.SetInt(PlayerPrefsHelp.ZhuBo, value == 0? 1 : 0);
        }

        public static void OnBtn_RandomHorese(this ES_SettingGame self)
        {
            string value = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.RandomHorese);
            self.RandomHorese.transform.Find("Image_Click").gameObject.SetActive(value == "0");
            self.SaveSettings(GameSettingEnum.RandomHorese, value == "0"? "1" : "0");
        }

        public static void OnLenDepth(this ES_SettingGame self, float value)
        {
            float va = 0.1f + value * 2;
            PlayerPrefsHelp.SetFloat(PlayerPrefsHelp.LenDepth, va);
            self.ZoneScene().CurrentScene().GetComponent<CameraComponent>().LenDepth = va;
        }

        public static void OnReSetCameraBtn(this ES_SettingGame self)
        {
            PlayerPrefsHelp.SetFloat(PlayerPrefsHelp.LenDepth, 1f);
            self.ZoneScene().CurrentScene().GetComponent<CameraComponent>().LenDepth = 1f;
            self.ZoneScene().CurrentScene().GetComponent<CameraComponent>().OffsetPostion = new Vector3(0, 10f, -6f);

            float va = PlayerPrefsHelp.GetFloat(PlayerPrefsHelp.LenDepth);
            if (va <= 0)
            {
                self.LenDepthSet.transform.GetComponentInChildren<Slider>().value = 0.4f;
            }
            else
            {
                self.LenDepthSet.transform.GetComponentInChildren<Slider>().value = (va - 0.1f) / 2;
            }

            PlayerPrefsHelp.SetInt(PlayerPrefsHelp.RotaAngle, 0);
            self.RotaAngleSet.transform.Find("Image_Click").gameObject.SetActive(false);
            UIHelper.GetUI(self.ZoneScene(), UIType.UIMain).GetComponent<UIMainComponent>().DragPanel.SetActive(false);
        }

        public static void OnBtn_FirstUnionName(this ES_SettingGame self)
        {
            string value = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.FirstUnionName);
            self.FirstUnionName.transform.Find("Image_Click").gameObject.SetActive(value == "0");
            self.SaveSettings(GameSettingEnum.FirstUnionName, value == "0"? "1" : "0");
        }

        public static void OnSkillAttackPlayerFirst(this ES_SettingGame self)
        {
            string value = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.SkillAttackPlayerFirst);
            self.SkillAttackPlayerFirst.transform.Find("Image_Click").gameObject.SetActive(value == "0");
            self.SaveSettings(GameSettingEnum.SkillAttackPlayerFirst, value == "0"? "1" : "0");
            self.ZoneScene().GetComponent<LockTargetComponent>().SkillAttackPlayerFirst = int.Parse(value == "0"? "1" : "0");
        }

        public static void OnBtn_NoMoving(this ES_SettingGame self)
        {
            SettingHelper.ShowNoMoving = !SettingHelper.ShowNoMoving;
        }

        public static void OnBtn_HideLeftBottom(this ES_SettingGame self)
        {
            string value = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.HideLeftBottom);
            self.HideLeftBottom.transform.Find("Image_Click").gameObject.SetActive(value == "0");
            self.SaveSettings(GameSettingEnum.HideLeftBottom, value == "0"? "1" : "0");
        }

        public static void OnBtn_AutoAttack(this ES_SettingGame self)
        {
            string value = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.AutoAttack);
            self.AutoAttack.transform.Find("Image_Click").gameObject.SetActive(value == "0");
            self.SaveSettings(GameSettingEnum.AutoAttack, value == "0"? "1" : "0");

            AttackComponent attackComponent = self.ZoneScene().GetComponent<AttackComponent>();
            attackComponent.AutoAttack = value == "0";
        }

        public static void InitUI(this ES_SettingGame self)
        {
            self.Image_yinyu.SetActive(self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.Music) == "1");
            self.Image_Sound.SetActive(self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.Sound) == "1");
            self.Image_YinYing.SetActive(self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.Shadow) == "1");

            string music = PlayerPrefsHelp.GetString(PlayerPrefsHelp.MusicVolume);
            float musicvalue = string.IsNullOrEmpty(music)? 1f : float.Parse(music);
            self.SliderSound.GetComponent<Slider>().value = musicvalue;

            string sound = PlayerPrefsHelp.GetString(PlayerPrefsHelp.SoundVolume);
            float soundvalue = string.IsNullOrEmpty(sound)? 1f : float.Parse(sound);
            self.SliderMusic.GetComponent<Slider>().value = soundvalue;

            self.ScreenToggle0.isOn = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.FenBianlLv) == "1";
            self.ScreenToggle1.isOn = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.FenBianlLv) == "2";
            self.Image_Click.SetActive(self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.Click) == "1");

            self.RandomHorese.transform.Find("Image_Click").gameObject
                    .SetActive(self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.RandomHorese) == "1");
            self.FirstUnionName.transform.Find("Image_Click").gameObject
                    .SetActive(self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.FirstUnionName) == "1");
            self.SkillAttackPlayerFirst.transform.Find("Image_Click").gameObject
                    .SetActive(self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.SkillAttackPlayerFirst) == "1");
            self.AutoAttack.transform.Find("Image_Click").gameObject
                    .SetActive(self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.AutoAttack) == "1");
            self.HideLeftBottom.transform.Find("Image_Click").gameObject
                    .SetActive(self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.HideLeftBottom) == "1");
            self.NoShowOther.transform.Find("Image_Click").gameObject
                    .SetActive(self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.NoShowOther) == "1");
            self.RotaAngleSet.transform.Find("Image_Click").gameObject.SetActive(PlayerPrefsHelp.GetInt(PlayerPrefsHelp.RotaAngle) == 1);
            float va = PlayerPrefsHelp.GetFloat(PlayerPrefsHelp.LenDepth);
            if (va <= 0)
            {
                self.LenDepthSet.transform.GetComponentInChildren<Slider>().value = 0.4f;
            }
            else
            {
                self.LenDepthSet.transform.GetComponentInChildren<Slider>().value = (va - 0.1f) / 2;
            }

            self.ZhuBoSet.transform.Find("Image_Click").gameObject.SetActive(PlayerPrefsHelp.GetInt(PlayerPrefsHelp.ZhuBo) == 1);

            string value = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.OneSellSet);
            string[] setvalues = value.Split('@');

            self.OneSellSet.transform.Find("Image_Click_0").gameObject.SetActive(setvalues[0] == "1");
            self.OneSellSet.transform.Find("Image_Click_1").gameObject.SetActive(setvalues[1] == "1");
            self.OneSellSet.transform.Find("Image_Click_2").gameObject.SetActive(setvalues[2] == "1");

            if (setvalues.Length > 3)
            {
                self.OneSellSet.transform.Find("Image_Click_3").gameObject.SetActive(setvalues[3] == "1");
            }

            string value2 = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.PickSet);
            string[] setvalues2 = value2.Split('@');
            self.PickSet.transform.Find("Image_Click_0").gameObject.SetActive(setvalues2[0] == "1");
            self.PickSet.transform.Find("Image_Click_1").gameObject.SetActive(setvalues2[1] == "1");

            self.UpdateYaoGan();
            self.UpdateShadow();
            self.UpdateHighFps();
            self.UpdateSmooth();
            self.UpdateNoShowOther();
            self.UpdateAttackMode();
            self.UpdateAttackTarget();
            self.TextVersion.GetComponent<Text>().text = GlobalHelp.GetBigVersion().ToString();
            self.InputFieldCName.GetComponent<InputField>().text = self.UserInfoComponent.UserInfo.Name;
            Unit unit = UnitHelper.GetMyUnitFromZoneScene(self.ZoneScene());
            long lastTime = unit.GetComponent<NumericComponent>().GetAsLong(NumericType.LastGameTime);
            self.LastLoginTime.GetComponent<Text>().text = TimeInfo.Instance.ToDateTime(lastTime).ToString();
        }

        public static void UpdateAttackMode(this ES_SettingGame self)
        {
            string acttype = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.AttackMode);
            self.ActTypeSet.transform.Find("Image_Click_0").gameObject.SetActive(acttype == "0");
            self.ActTypeSet.transform.Find("Image_Click_1").gameObject.SetActive(acttype == "1");
            self.ActTypeSet.transform.Find("Image_Click_2").gameObject.SetActive(acttype == "2");
            self.ActTypeSet.transform.Find("Image_Click_3").gameObject.SetActive(acttype == "3");
        }

        public static void UpdateAttackTarget(this ES_SettingGame self)
        {
            string acttype = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.AttackTarget);
            self.ActTargetSelect.transform.Find("Image_Click_0").gameObject.SetActive(acttype == "0");
            self.ActTargetSelect.transform.Find("Image_Click_1").gameObject.SetActive(acttype == "1");
        }

        public static void OnBeforeClose(this ES_SettingGame self)
        {
            self.SendGameSetting().Coroutine();
        }

        public static void OnBtn_Fps(this ES_SettingGame self)
        {
            UI uimain = UIHelper.GetUI(self.DomainScene(), UIType.UIMain);
            self.Image_fps.SetActive(!self.Image_fps.activeSelf);
            uimain.GetComponent<UIMainComponent>().ShowPing();
        }

        public static async ETTask SendGameSetting(this ES_SettingGame self)
        {
            if (self.GameSettingInfos.Count > 0)
            {
                self.ZoneScene().GetComponent<UserInfoComponent>().UpdateGameSetting(self.GameSettingInfos);
                HintHelp.GetInstance().DataUpdate(DataType.SettingUpdate);
                C2M_GameSettingRequest c2M_GameSettingRequest = new C2M_GameSettingRequest() { GameSettingInfos = self.GameSettingInfos };
                M2C_GameSettingResponse r2c_roleEquip =
                        (M2C_GameSettingResponse)await self.DomainScene().GetComponent<SessionComponent>().Session.Call(c2M_GameSettingRequest);
            }
        }

        public static void OnCloseGame(this ES_SettingGame self)
        {
            PopupTipHelp.OpenPopupTip(self.ZoneScene(), "设置", "是否退出游戏?", () => { Application.Quit(); }).Coroutine();
        }

        public static void OnReturnLogin(this ES_SettingGame self)
        {
            self.HideDi.SetActive(true);
            //加载登录场景
            EventType.ReturnLogin.Instance.ZoneScene = self.DomainScene();
            Game.EventSystem.PublishClass(EventType.ReturnLogin.Instance);
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

            self.ZoneScene().GetComponent<UserInfoComponent>().UpdateGameSetting(self.GameSettingInfos);
        }

        public static void OnBtn_Sound(this ES_SettingGame self)
        {
            self.Image_Sound.SetActive(!self.Image_Sound.activeSelf);
            self.SaveSettings(GameSettingEnum.Sound, self.Image_Sound.activeSelf? "1" : "0");
        }

        public static void OnBtn_YinYue(this ES_SettingGame self)
        {
            self.Image_yinyu.SetActive(!self.Image_yinyu.activeSelf);
            self.SaveSettings(GameSettingEnum.Music, self.Image_yinyu.activeSelf? "1" : "0");
        }

        public static void OnBtn_Fixed(this ES_SettingGame self)
        {
            string value = self.Image_Fixed.gameObject.activeSelf? "1" : "0";
            self.SaveSettings(GameSettingEnum.YanGan, value);
            self.UpdateYaoGan();
        }

        public static void UpdateYaoGan(this ES_SettingGame self)
        {
            self.Image_Fixed.SetActive(self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.YanGan) == "0");
        }

        public static void OnHighFps(this ES_SettingGame self)
        {
            string oldValue = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.HighFps);
            if (oldValue == "0")
            {
                PopupTipHelp.OpenPopupTip(self.ZoneScene(), "系统提示", "开启高帧模式，根据手机的配置不同可能导致手机发热耗电的情况，如果出现此现象请及时关闭喔!", () =>
                {
                    self.SaveSettings(GameSettingEnum.HighFps, oldValue == "0"? "1" : "0");
                    self.UpdateHighFps();
                }, null).Coroutine();
            }
            else
            {
                self.SaveSettings(GameSettingEnum.HighFps, oldValue == "0"? "1" : "0");
                self.UpdateHighFps();
            }
        }

        public static void OnSmooth(this ES_SettingGame self)
        {
            string oldValue = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.Smooth);
            self.SaveSettings(GameSettingEnum.Smooth, oldValue == "0"? "1" : "0");
            self.UpdateSmooth();
            SettingHelper.OnSmooth(oldValue == "0"? "1" : "0");
        }

        public static void OnGameMemory(this ES_SettingGame self)
        {
            self.SendGameMemory().Coroutine();
        }

        public static async ETTask SendGameMemory(this ES_SettingGame self)
        {
            if (GlobalHelp.GetBigVersion() < 17)
            {
                return;
            }

            BattleMessageComponent battleMessage = self.ZoneScene().GetComponent<BattleMessageComponent>();
            if (TimeHelper.ServerNow() - battleMessage.UploadMemoryTime < TimeHelper.Minute)
            {
                FloatTipManager.Instance.ShowFloatTip("请不要频繁操作！");
                return;
            }

            long monouse = UnityEngine.Profiling.Profiler.GetMonoUsedSizeLong(); //使用的
            long totalallocated = UnityEngine.Profiling.Profiler.GetTotalAllocatedMemoryLong(); //unity分配的
            long totalreserved = UnityEngine.Profiling.Profiler.GetTotalReservedMemoryLong(); //总内存
            long unusedreserved = UnityEngine.Profiling.Profiler.GetTotalUnusedReservedMemoryLong(); //未使用的内存

            StringBuilder stringBuilder = StringBuilderHelper.stringBuilder;
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
            stringBuilder.Append("MonoPool:");
            stringBuilder.AppendLine();
            stringBuilder.Append(MonoPool.Instance.ToString());
            stringBuilder.Append("GameObjectPool:");
            stringBuilder.AppendLine();
            stringBuilder.Append(GameObjectPoolComponent.Instance.ToString2());

            battleMessage.UploadMemoryTime = TimeHelper.ServerNow();

            C2Popularize_UploadRequest request = new C2Popularize_UploadRequest() { MemoryInfo = stringBuilder.ToString() };
            Popularize2C_UploadResponse response =
                    (Popularize2C_UploadResponse)await self.ZoneScene().GetComponent<SessionComponent>().Session.Call(request);
        }

        public static void OnNoShowOther(this ES_SettingGame self)
        {
            string oldValue = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.NoShowOther);
            self.SaveSettings(GameSettingEnum.NoShowOther, oldValue == "0"? "1" : "0");
            self.UpdateNoShowOther();
            SettingHelper.OnShowOther(oldValue == "0"? "1" : "0");

            List<Unit> units = UnitHelper.GetUnitList(self.ZoneScene().CurrentScene(), UnitType.Player);
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
            self.HighFps.transform.Find("Image_Click").gameObject.SetActive(oldValue == "1");
            UICommonHelper.TargetFrameRate(oldValue == "1"? 60 : 30);
        }

        public static void UpdateSmooth(this ES_SettingGame self)
        {
            string oldValue = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.Smooth);
            self.Smooth.transform.Find("Image_Click").gameObject.SetActive(oldValue == "1");
        }

        public static void UpdateNoShowOther(this ES_SettingGame self)
        {
            string oldValue = self.UserInfoComponent.GetGameSettingValue(GameSettingEnum.NoShowOther);
            self.NoShowOther.transform.Find("Image_Click").gameObject.SetActive(oldValue == "1");
        }

        public static void CheckSensitiveWords(this ES_SettingGame self)
        {
            string text_new = "";
            string text_old = self.InputFieldCName.GetComponent<InputField>().text;
            MaskWordHelper.Instance.IsContainSensitiveWords(ref text_old, out text_new);
            self.InputFieldCName.GetComponent<InputField>().text = text_old;
        }

        public static void OnButtonPhone(this ES_SettingGame self)
        {
            PlayerInfo playerInfo = self.ZoneScene().GetComponent<AccountInfoComponent>().PlayerInfo;
            if (!string.IsNullOrEmpty(playerInfo.PhoneNumber))
            {
                FloatTipManager.Instance.ShowFloatTip($"已绑定手机号:{playerInfo.PhoneNumber}");
                return;
            }

            UIHelper.Create(self.ZoneScene(), UIType.UIPhoneCode).Coroutine();
        }

        public static async ETTask OnButtonRname(this ES_SettingGame self)
        {
            string text = self.InputFieldCName.GetComponent<InputField>().text;

            if (string.IsNullOrEmpty(text))
            {
                FloatTipManager.Instance.ShowFloatTip("名字不合法，请重新输入！");
                return;
            }

            if (text.Length >= 8)
            {
                FloatTipManager.Instance.ShowFloatTip("角色名字过长，请重新输入！");
                return;
            }

            if (text.Contains("*") || !StringHelper.IsSpecialChar(text))
            {
                FloatTipManager.Instance.ShowFloatTip("名字不合法，请重新输入！");
                return;
            }

            GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(70);
            BagComponent bagComponent = self.ZoneScene().GetComponent<BagComponent>();
            if (!bagComponent.CheckNeedItem(globalValueConfig.Value))
            {
                string needItem = UICommonHelper.GetNeedItemDesc(globalValueConfig.Value);
                FloatTipManager.Instance.ShowFloatTip($"需要 {needItem}");
                return;
            }

            C2M_ModifyNameRequest c2M_GameSettingRequest = new C2M_ModifyNameRequest() { NewName = text };
            M2C_ModifyNameResponse r2c_roleEquip =
                    (M2C_ModifyNameResponse)await self.DomainScene().GetComponent<SessionComponent>().Session.Call(c2M_GameSettingRequest);

            if (r2c_roleEquip.Error == ErrorCode.ERR_Success)
            {
                FloatTipManager.Instance.ShowFloatTip("修改名称成功！");
            }
        }
    }
}