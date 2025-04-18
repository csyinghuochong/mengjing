using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_MainSkillGrid))]
    [FriendOfAttribute(typeof(ES_MainSkillGrid))]
    public static partial class ES_MainSkillGridSystem
    {
        [EntitySystem]
        private static void Awake(this ES_MainSkillGrid self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_SkillSecondCD.gameObject.SetActive(false);
            self.E_Button_Cancle.gameObject.SetActive(false);
            self.E_SkillYanGan.gameObject.SetActive(false);
            self.E_Text_SkillItemNum.gameObject.SetActive(false);

            self.RemoveEventTriggers();

            self.E_Button_Cancle.GetComponent<Button>().AddListener(self.SendCancleSkill);

            EventTrigger eventTrigger = self.E_Btn_SkillStart.GetComponent<EventTrigger>();
            eventTrigger.RegisterEvent(EventTriggerType.Drag, (pdata) => { self.Draging(pdata as PointerEventData); });
            eventTrigger.RegisterEvent(EventTriggerType.EndDrag, (pdata) => { self.EndDrag(pdata as PointerEventData); });
            eventTrigger.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.OnPointDown(pdata as PointerEventData); });
            eventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.PointerUp(pdata as PointerEventData); });
            eventTrigger.RegisterEvent(EventTriggerType.Cancel, (pdata) => { self.OnCancel(pdata as PointerEventData); });

            self.LockTargetComponent = self.Scene().GetComponent<LockTargetComponent>();
            self.SkillIndicatorComponent = self.Scene().GetComponent<SkillIndicatorComponent>();
        }

        [EntitySystem]
        private static void Destroy(this ES_MainSkillGrid self)
        {
        }

        public static void RemoveEventTriggers(this ES_MainSkillGrid self)
        {
            EventTrigger eventTrigger = self.E_Btn_SkillStart.GetComponent<EventTrigger>();
            eventTrigger.triggers.RemoveRange(0, eventTrigger.triggers.Count);
            eventTrigger.triggers.Clear();
            self.E_Button_Cancle.GetComponent<Button>().onClick.RemoveAllListeners();
        }

        public static void OnCancel(this ES_MainSkillGrid self, PointerEventData eventData)
        {
        }

        public static int GetSkillId(this ES_MainSkillGrid self)
        {
            return self.SkillBaseConfig != null ? self.SkillBaseConfig.Id : 0;
        }

        public static void OnUpdate(this ES_MainSkillGrid self, long leftCDTime, long pulicCd)
        {
            //显示冷却CD
            if (leftCDTime > 0)
            {
                int showCostTime = (int)(leftCDTime / 1000) + 1;
                self.E_Text_SkillCD.text = showCostTime.ToString();
                float proValue = (float)leftCDTime / ((float)self.SkillBaseConfig.SkillCD * 1000f);
                self.E_Img_SkillCD.fillAmount = proValue;
                if (self.SkillSecond == 1) //已释放二段斩 进入CD
                {
                    self.SkillSecond = 0;
                    self.E_SkillSecondCD.gameObject.SetActive(false);
                }
            }
            else
            {
                self.E_Img_SkillCD.fillAmount = 0f;
                self.E_Text_SkillCD.text = string.Empty;
            }

            //显示公共CD
            if (pulicCd > 0)
            {
                float proValue = (float)(pulicCd / 800f); //1秒公共CD
                self.E_Img_PublicSkillCD.fillAmount = proValue;
            }
            else
            {
                self.E_Img_PublicSkillCD.fillAmount = 0f;
            }
        }

        public static void RemoveSkillInfoShow(this ES_MainSkillGrid self)
        {
            if (self.SkillInfoShowTimer != 0)
            {
                self.Root().GetComponent<TimerComponent>().Remove(ref self.SkillInfoShowTimer);
                self.SkillInfoShowTimer = 0;
            }
            //UIHelper.Remove(self.DomainScene(), UIType.UISkillTips);
        }

        public static void Draging(this ES_MainSkillGrid self, PointerEventData eventData)
        {
            if (self.SkillInfoShowTimer != 0)
            {
                self.Root().GetComponent<TimerComponent>().Remove(ref self.SkillInfoShowTimer);
                self.SkillInfoShowTimer = 0;
            }

            if (self.IfShowSkillZhishi() == false || !self.UseSkill)
            {
                return;
            }

            self.SkillIndicatorComponent.OnMouseDrag(eventData.delta);
        }

        /// <summary>
        /// 0  立即释放,自身中心点
        /// 1  技能指示器
        /// 2  立即释放,目标中心点[需要传目标ID]
        /// </summary>
        /// <returns></returns>
        public static bool IfShowSkillZhishi(this ES_MainSkillGrid self)
        {
            if (self.SkillWuqiConfig == null)
                return false;
            if (self.SkillWuqiConfig.SkillTargetType == 7)
                return true;
            return self.SkillWuqiConfig.SkillZhishiType > 0;
        }

        public static void SendUseSkill(this ES_MainSkillGrid self, int angle, float distance)
        {
            self.SkillCancelHandler(false);
            if (self.CancelSkill)
            {
                return;
            }

            Unit myUnit = UnitHelper.GetMyUnitFromClientScene(self.Scene());
            long targetId = self.LockTargetComponent.LastLockId;

            if (self.SkillWuqiConfig.SkillTargetType == (int)SkillTargetType.TargetOnly)
            {
                Unit targetUnit = null;
                if (targetId == 0)
                {
                    FlyTipComponent.Instance.ShowFlyTip(LanguageComponent.Instance.LoadLocalization("请选中施法目标"));
                    return;
                }

                targetUnit = myUnit.GetParent<UnitComponent>().Get(targetId);

                // 判断施法距离
                //if (direction.sqrMagnitude > self.SkillWuqiConfig.SkillRangeSize * 20)
                //{
                //    FloatTipManager.Instance.ShowFloatTip("施法距离太远");
                //    return;
                //}
                if (targetUnit == null || PositionHelper.Distance2D(targetUnit.Position, myUnit.Position) > self.SkillWuqiConfig.SkillRangeSize)
                {
                    FlyTipComponent.Instance.ShowFlyTip(LanguageComponent.Instance.LoadLocalization("施法距离太远"));
                    return;
                }

                Vector3 direction = targetUnit.Position - myUnit.Position;
                angle = Mathf.FloorToInt(Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg);
            }

            EventSystem.Instance.Publish(self.Root(), new BeforeSkill());
            if (self.SkillPro.SkillSetType == (int)SkillSetEnum.Skill)
            {
                int skillId = self.SkillBaseConfig.Id;
                SkillManagerComponentC skillManagerComponent = myUnit.GetComponent<SkillManagerComponentC>();
                if (self.SkillSecond == 1)
                {
                    //用二段技能
                    skillId = (int)SkillConfigCategory.Instance.BuffSecondSkill[skillId].Value2;
                    skillManagerComponent.AddSkillSecond(self.SkillBaseConfig.Id, skillId);
                }

                skillManagerComponent.SendUseSkill(skillId, 0, angle, targetId, distance).Coroutine();
            }
            else
            {
                ItemInfo bagInfo = self.Root().GetComponent<BagComponentC>().GetBagInfo(self.SkillPro.SkillID);
                if (bagInfo == null)
                {
                    return;
                }

                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.SkillPro.SkillID);
                if (itemConfig.ItemSubType == 101) // 药剂、鞭炮 走的使用技能的流程
                {
                    myUnit.GetComponent<SkillManagerComponentC>()
                            .SendUseSkill(int.Parse(itemConfig.ItemUsePar), self.SkillPro.SkillID, angle, targetId, distance).Coroutine();
                }
                else // 道具 走的使用道具的流程
                {
                    //self.Root().GetComponent<BagComponentC>().SendUseItem(bagInfo, null).Coroutine();
                    BagClientNetHelper.RequestUseItem(self.Root(), bagInfo, null).Coroutine();
                }
            }

            if (self.SkillPro.SkillSource == SkillSourceEnum.Buff)
            {
                self.UseSkillHandler?.Invoke(self.Index);
            }
        }

        public static void EndDrag(this ES_MainSkillGrid self, PointerEventData eventData)
        {
            self.RemoveSkillInfoShow();
            self.SkillCancelHandler(false);
            if (self.SkillWuqiConfig != null && self.SkillWuqiConfig.SkillZhishiType == 1)
            {
                self.E_SkillYanGan.gameObject.SetActive(false);
            }

            if (self.IfShowSkillZhishi() == false || !self.UseSkill)
            {
                return;
            }

            self.UseSkill = false;
            self.SendUseSkill(self.GetTargetAngle(), self.GetTargetDistance());
            self.SkillIndicatorComponent.RecoveryEffect();
        }

        public static void PointerUp(this ES_MainSkillGrid self, PointerEventData eventData)
        {
            self.RemoveSkillInfoShow();
            if (self.SkillWuqiConfig != null && self.SkillWuqiConfig.SkillZhishiType == 1)
            {
                self.E_SkillYanGan.gameObject.SetActive(false);
            }

            if (!self.UseSkill)
            {
                return;
            }

            self.UseSkill = false;
            self.SendUseSkill(self.GetTargetAngle(), self.GetTargetDistance());
            self.Root().GetComponent<SkillIndicatorComponent>().RecoveryEffect();
        }

        public static void OnPointDown(this ES_MainSkillGrid self, PointerEventData eventData)
        {
            if (self.SkillBaseConfig == null)
            {
                return;
            }

            self.RemoveSkillInfoShow();
            self.SkillInfoShowTimer = self.Root().GetComponent<TimerComponent>()
                    .NewOnceTimer(TimeHelper.ServerNow() + 2000, TimerInvokeType.SkillInfoShowTimer, self);
            if (self.SkillWuqiConfig.SkillZhishiType == 1)
            {
                self.E_SkillYanGan.gameObject.SetActive(true);
            }

            self.CancelSkill = false;
            Unit myUnit = UnitHelper.GetMyUnitFromClientScene(self.Scene());

            //锁定目标
            self.LockTargetComponent.SkillLock(myUnit, self.SkillWuqiConfig);

            if (!self.IfShowSkillZhishi())
            {
                self.UseSkill = false;
                self.SkillCancelHandler(false);
                self.SendUseSkill((int)MathHelper.QuaternionToEulerAngle_Y(myUnit.Rotation), 0);
                self.SkillIndicatorComponent.RecoveryEffect();
                return;
            }

            //long targetId = self.LockTargetComponent.LastLockId;
            //UnitComponent unitComponent = myUnit.GetParent<UnitComponent>();
            //Unit targetUnit = unitComponent.Get(targetId);
            ////获取当前目标和自身目标的距离
            //if (targetUnit == null || (PositionHelper.Distance2D(targetUnit, myUnit) + 4) > self.SkillWuqiConfig.SkillRangeSize)
            //{
            //    //获取当前最近的单位
            //    Unit enemy = AIHelp.GetNearestEnemy_Client(myUnit, (float)self.SkillWuqiConfig.SkillRangeSize + 4);
            //    //设置目标
            //    if (targetUnit == null && enemy != null)
            //    {
            //        self.LockTargetComponent.LockTargetUnitId(enemy.Id);
            //    }
            //}

            self.UseSkill = true;
            self.SkillCancelHandler(true);
            self.SkillIndicatorComponent.ShowSkillIndicator(self.SkillWuqiConfig);
            self.SkillIndicatorComponent.OnMouseDown(self.LockTargetComponent.LastLockId);
        }

        public static int GetTargetAngle(this ES_MainSkillGrid self)
        {
            return self.Scene().GetComponent<SkillIndicatorComponent>().GetIndicatorAngle();
        }

        //X100
        public static float GetTargetDistance(this ES_MainSkillGrid self)
        {
            return self.Scene().GetComponent<SkillIndicatorComponent>().GetIndicatorDistance();
        }

        public static void OnEnterCancelButton(this ES_MainSkillGrid self)
        {
            self.CancelSkill = true;
        }

        public static void UpdateItemNumber(this ES_MainSkillGrid self)
        {
            if (self.SkillPro == null)
            {
                return;
            }

            if (self.SkillPro.SkillSetType != (int)SkillSetEnum.Item)
            {
                return;
            }

            long number = self.Root().GetComponent<BagComponentC>().GetItemNumber(self.SkillPro.SkillID);
            self.E_Text_SkillItemNum.gameObject.SetActive(true);
            self.E_Text_SkillItemNum.GetComponent<Text>().text = number.ToString();

            CommonViewHelper.SetImageGray(self.Root(), self.E_SkillDi.gameObject, number == 0);
            CommonViewHelper.SetImageGray(self.Root(), self.E_Img_SkillIcon.gameObject, number == 0);
        }

        public static void SendCancleSkill(this ES_MainSkillGrid self)
        {
            // C2M_SkillInterruptRequest request = new C2M_SkillInterruptRequest() { SkillID = self.SkillPro.SkillID };
            // self.ZoneScene().GetComponent<SessionComponent>().Session.Send(request);
            // Unit unit = UnitHelper.GetMyUnitFromZoneScene(self.ZoneScene());
            // unit.GetComponent<SkillManagerComponent>()
            //         .AddSkillCD(self.SkillPro.SkillID, TimeHelper.ServerNow() + 10000, TimeHelper.ServerNow() + 1000);
            // self.Button_Cancle.SetActive(false);
        }

        public static void OnSkillSecondResult(this ES_MainSkillGrid self, M2C_SkillSecondResult message)
        {
            if (self.SkillPro == null)
            {
                return;
            }

            if (message != null && message.HurtIds.Count > 0)
            {
                ///可以释放二段技能
                if (self.SkillSecond == 0)
                {
                    self.SkillSecond = 1;
                    self.E_SkillSecondCD.gameObject.SetActive(true);
                    Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Scene());
                    unit.GetComponent<SkillManagerComponentC>().ClearSkillCD(message.SkillId);
                    self.ShowSkillSecondCD(self.SkillPro.SkillID).Coroutine();
                }
            }

            if (message == null)
            {
                //未及时释放二段斩，进入CD
                self.SkillSecond = 0;
                self.E_SkillSecondCD.gameObject.SetActive(false);
                Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Scene());
                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(self.SkillPro.SkillID);
                unit.GetComponent<SkillManagerComponentC>().AddSkillCD(self.SkillPro.SkillID, TimeHelper.ServerNow() + (skillConfig.SkillLiveTime),
                    TimeHelper.ServerNow() + 500);
            }
        }

        public static async ETTask ShowSkillSecondCD(this ES_MainSkillGrid self, int skillId)
        {
            KeyValuePairLong4 keyValuePairLong = null;
            SkillConfigCategory.Instance.BuffSecondSkill.TryGetValue(skillId, out keyValuePairLong);
            if (keyValuePairLong == null)
            {
                return;
            }

            long allTime = SkillBuffConfigCategory.Instance.Get((int)keyValuePairLong.KeyId).BuffTime;
            long passTime = 0;
            while (true)
            {
                if (self.IsDisposed)
                {
                    self.SkillSecond = 0;
                    break;
                }

                if (self.SkillPro == null || self.SkillPro.SkillID != skillId)
                {
                    self.SkillSecond = 0;
                    self.E_SkillSecondCD.gameObject.SetActive(false);
                    break;
                }

                if (passTime >= allTime)
                {
                    self.OnSkillSecondResult(null);
                    break;
                }

                if (self.SkillSecond == 0)
                {
                    break;
                }

                self.E_SkillSecondCD.fillAmount = 1f * (allTime - passTime) / allTime;
                await self.Root().GetComponent<TimerComponent>().WaitAsync(100);
                passTime += 100;
            }
        }

        public static void UpdateSkillInfo(this ES_MainSkillGrid self, SkillPro skillpro)
        {
            self.SkillPro = skillpro;
            if (skillpro == null)
            {
                self.SkillWuqiConfig = null;
                self.SkillBaseConfig = null;
                self.SkillPro = null;
                self.E_Img_PublicSkillCD.fillAmount = 0;
                self.E_Img_SkillIcon.gameObject.SetActive(false);
                self.E_Img_Mask.gameObject.SetActive(false);
                return;
            }

            if (skillpro.SkillSetType == (int)SkillSetEnum.Skill)
            {
                BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
                SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();
                int skillid = SkillHelp.GetWeaponSkill(skillpro.SkillID, UnitHelper.GetEquipType(self.Root()), skillSetComponent.SkillList);
                if (!SkillConfigCategory.Instance.Contain(skillid))
                {
                    using (zstring.Block())
                    {
                        Log.Error(zstring.Format("skillid == null: {0} {1}", skillpro.SkillID, skillid));
                    }

                    self.SkillPro = null;
                    return;
                }

                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillid);
                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, skillConfig.SkillIcon);
                Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
                if (!self.AssetPath.Contains(path))
                {
                    self.AssetPath.Add(path);
                }

                self.E_Img_SkillIcon.gameObject.GetComponent<Image>().sprite = sp;

                self.SkillWuqiConfig = skillConfig;
                self.SkillBaseConfig = SkillConfigCategory.Instance.Get(skillpro.SkillID);
            }
            else
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(skillpro.SkillID);
                if (itemConfig.ItemSubType == 101) // 药剂、鞭炮 走的使用技能的流程
                {
                    int skillid = int.Parse(itemConfig.ItemUsePar);
                    if (!SkillConfigCategory.Instance.Contain(skillid))
                    {
                        self.SkillPro = null;
                        using (zstring.Block())
                        {
                            Log.Error(zstring.Format("skillid == null: {0} {1}", skillpro.SkillID, skillid));
                        }

                        return;
                    }

                    self.SkillWuqiConfig = SkillConfigCategory.Instance.Get(skillid);
                    self.SkillBaseConfig = self.SkillWuqiConfig;
                }
                else // 道具 走的使用道具的流程
                {
                    self.SkillWuqiConfig = new SkillConfig();
                    self.SkillBaseConfig = self.SkillWuqiConfig;
                }

                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon);
                Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
                if (!self.AssetPath.Contains(path))
                {
                    self.AssetPath.Add(path);
                }

                self.E_Img_SkillIcon.GetComponent<Image>().sprite = sp;
            }

            self.E_Button_Cancle.gameObject.SetActive(false);
            self.E_Img_SkillIcon.gameObject.SetActive(true);
            self.E_Img_Mask.gameObject.SetActive(true);
            self.E_Text_SkillCD.text = string.Empty;
            self.E_Text_SkillItemNum.gameObject.SetActive(false);
            self.UpdateItemNumber();
        }
    }
}