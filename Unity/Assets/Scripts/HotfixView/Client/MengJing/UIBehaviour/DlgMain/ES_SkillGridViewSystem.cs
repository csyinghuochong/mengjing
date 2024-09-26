using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ET.Client
{
    [Invoke(TimerInvokeType.SkillInfoShowTimer)]
    public class SkillInfoShowTimer : ATimer<ES_SkillGrid>
    {
        protected override void Run(ES_SkillGrid self)
        {
            try
            {
                self.SkillInfoShow().Coroutine();
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

    [EntitySystemOf(typeof(ES_SkillGrid))]
    [FriendOfAttribute(typeof(ES_SkillGrid))]
    public static partial class ES_SkillGridSystem
    {
        [EntitySystem]
        private static void Awake(this ES_SkillGrid self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_SkillSecondCDImage.gameObject.SetActive(false);
            self.E_Button_CancleButton.gameObject.SetActive(false);
            self.E_SkillYanGanImage.gameObject.SetActive(false);
            self.E_Text_SkillItemNumText.gameObject.SetActive(false);

            self.RemoveEventTriggers();

            self.E_Button_CancleButton.AddListener(self.OnButton_CancleButton);

            self.E_Btn_SkillStartEventTrigger.RegisterEvent(EventTriggerType.Drag, (pdata) => { self.Draging(pdata as PointerEventData); });
            self.E_Btn_SkillStartEventTrigger.RegisterEvent(EventTriggerType.EndDrag, (pdata) => { self.EndDrag(pdata as PointerEventData); });
            self.E_Btn_SkillStartEventTrigger.RegisterEvent(EventTriggerType.PointerDown,
                (pdata) => { self.OnPointDown(pdata as PointerEventData); });
            self.E_Btn_SkillStartEventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.PointerUp(pdata as PointerEventData); });
            self.E_Btn_SkillStartEventTrigger.RegisterEvent(EventTriggerType.Cancel, (pdata) => { self.OnCancel(pdata as PointerEventData); });

            self.LockTargetComponent = self.Root().GetComponent<LockTargetComponent>();
            self.SkillIndicatorComponent = self.Root().GetComponent<SkillIndicatorComponent>();
            self.E_Btn_SkillStartButton.AddListener(self.OnBtn_SkillStartButton);
        }

        [EntitySystem]
        private static void Destroy(this ES_SkillGrid self)
        {
            self.DestroyWidget();
        }

        public static void RemoveEventTriggers(this ES_SkillGrid self)
        {
            EventTrigger eventTrigger = self.E_Btn_SkillStartEventTrigger;
            eventTrigger.triggers.RemoveRange(0, eventTrigger.triggers.Count);

            self.E_Button_CancleButton.onClick.RemoveAllListeners();
        }

        public static async ETTask SkillInfoShow(this ES_SkillGrid self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_SkillTips);

            Vector2 localPoint;
            RectTransform canvas = self.Root().GetComponent<GlobalComponent>().NormalRoot.GetComponent<RectTransform>();
            Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, Input.mousePosition, uiCamera, out localPoint);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgSkillTips>()
                    .OnUpdateData(self.SkillPro.SkillID, new Vector3(localPoint.x, localPoint.y, 0f));
        }

        public static void OnCancel(this ES_SkillGrid self, PointerEventData eventData)
        {
        }

        public static int GetSkillId(this ES_SkillGrid self)
        {
            return self.SkillBaseConfig != null ? self.SkillBaseConfig.Id : 0;
        }

        public static void OnUpdate(this ES_SkillGrid self, long leftCDTime, long pulicCd)
        {
            //显示冷却CD
            if (leftCDTime > 0)
            {
                int showCostTime = (int)(leftCDTime / 1000) + 1;
                self.E_Text_SkillCDText.text = showCostTime.ToString();
                float proValue = (float)leftCDTime / ((float)self.SkillBaseConfig.SkillCD * 1000f);
                self.E_Img_SkillCDImage.fillAmount = proValue;
                if (self.SkillSecond == 1) //已释放二段斩 进入CD
                {
                    self.SkillSecond = 0;
                    self.E_SkillSecondCDImage.gameObject.SetActive(false);
                }
            }
            else
            {
                self.E_Img_SkillCDImage.fillAmount = 0f;
                self.E_Text_SkillCDText.text = string.Empty;
            }

            //显示公共CD
            if (pulicCd > 0)
            {
                float proValue = (float)(pulicCd / 800f); //1秒公共CD
                self.E_Img_PublicSkillCDImage.fillAmount = proValue;
            }
            else
            {
                self.E_Img_PublicSkillCDImage.fillAmount = 0f;
            }
        }

        public static void RemoveSkillInfoShow(this ES_SkillGrid self)
        {
            if (self.SkillInfoShowTimer != 0)
            {
                self.Root().GetComponent<TimerComponent>().Remove(ref self.SkillInfoShowTimer);
                self.SkillInfoShowTimer = 0;
            }

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_SkillTips);
        }

        public static void Draging(this ES_SkillGrid self, PointerEventData eventData)
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
        public static bool IfShowSkillZhishi(this ES_SkillGrid self)
        {
            if (self.SkillWuqiConfig == null)
                return false;
            if (self.SkillWuqiConfig.SkillTargetType == 7)
                return true;
            return self.SkillWuqiConfig.SkillZhishiType > 0;
        }

        public static void SendUseSkill(this ES_SkillGrid self, int angle, float distance)
        {
            self.SkillCancelHandler(false);
            if (self.CancelSkill)
            {
                return;
            }

            Unit myUnit = self.GetParent<ES_MainSkill>().MainUnit;
            long targetId = self.LockTargetComponent.LastLockId;

            if (self.SkillWuqiConfig.SkillTargetType == (int)SkillTargetType.TargetOnly)
            {
                Unit targetUnit = null;
                if (targetId == 0)
                {
                    FlyTipComponent.Instance.ShowFlyTip("请选中施法目标");
                    return;
                }

                targetUnit = myUnit.GetParent<UnitComponent>().Get(targetId);

                if (targetUnit == null || Vector3.Distance(targetUnit.Position, myUnit.Position) > self.SkillWuqiConfig.SkillRangeSize)
                {
                    FlyTipComponent.Instance.ShowFlyTip("施法距离太远");
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
                ItemInfo bagInfo = self.Root().GetComponent<BagComponentC>().GetBagInfoByConfigId(self.SkillPro.SkillID);
                if (bagInfo == null)
                {
                    using (zstring.Block())
                    {
                        FlyTipComponent.Instance.ShowFlyTip(zstring.Format("道具 {0} 不足",
                            ItemConfigCategory.Instance.Get(self.SkillPro.SkillID).ItemName));
                    }

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
                    BagClientNetHelper.RequestUseItem(self.Root(), bagInfo, null).Coroutine();
                }
            }

            if (self.SkillPro.SkillSource == SkillSourceEnum.Buff)
            {
                self.UseSkillHandler?.Invoke(self.Index);
            }
        }

        public static void EndDrag(this ES_SkillGrid self, PointerEventData eventData)
        {
            self.RemoveSkillInfoShow();
            self.SkillCancelHandler(false);
            if (self.SkillWuqiConfig != null && self.SkillWuqiConfig.SkillZhishiType == 1)
            {
                self.E_SkillYanGanImage.gameObject.SetActive(false);
            }

            if (self.IfShowSkillZhishi() == false || !self.UseSkill)
            {
                return;
            }

            self.UseSkill = false;
            self.SendUseSkill(self.GetTargetAngle(), self.GetTargetDistance());
            self.SkillIndicatorComponent.RecoveryEffect();
        }

        public static void PointerUp(this ES_SkillGrid self, PointerEventData eventData)
        {
            self.RemoveSkillInfoShow();
            if (self.SkillWuqiConfig != null && self.SkillWuqiConfig.SkillZhishiType == 1)
            {
                self.E_SkillYanGanImage.gameObject.SetActive(false);
            }

            if (!self.UseSkill)
            {
                return;
            }

            self.UseSkill = false;
            self.SendUseSkill(self.GetTargetAngle(), self.GetTargetDistance());
            self.Root().GetComponent<SkillIndicatorComponent>().RecoveryEffect();
        }

        public static void OnPointDown(this ES_SkillGrid self, PointerEventData eventData)
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
                self.E_SkillYanGanImage.gameObject.SetActive(true);
            }

            self.CancelSkill = false;
            Unit myUnit = self.GetParent<ES_MainSkill>().MainUnit;

            //锁定目标
            self.LockTargetComponent.SkillLock(myUnit, self.SkillWuqiConfig);

            if (!self.IfShowSkillZhishi())
            {
                self.UseSkill = false;
                self.SkillCancelHandler(false);
                Quaternion rotate = myUnit.Rotation;
                self.SendUseSkill((int)rotate.eulerAngles.y, 0);
                self.SkillIndicatorComponent.RecoveryEffect();
                return;
            }

            self.UseSkill = true;
            self.SkillCancelHandler(true);
            self.SkillIndicatorComponent.ShowSkillIndicator(self.SkillWuqiConfig);
            self.SkillIndicatorComponent.OnMouseDown(self.LockTargetComponent.LastLockId);
        }

        public static int GetTargetAngle(this ES_SkillGrid self)
        {
            return self.Root().GetComponent<SkillIndicatorComponent>().GetIndicatorAngle();
        }

        //X100
        public static float GetTargetDistance(this ES_SkillGrid self)
        {
            return self.Root().GetComponent<SkillIndicatorComponent>().GetIndicatorDistance();
        }

        public static void OnEnterCancelButton(this ES_SkillGrid self)
        {
            self.CancelSkill = true;
        }

        public static void UpdateItemNumber(this ES_SkillGrid self)
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
            self.E_Text_SkillItemNumText.gameObject.SetActive(true);
            self.E_Text_SkillItemNumText.text = number.ToString();

            CommonViewHelper.SetImageGray(self.Root(), self.E_E_SkillDiImage.gameObject, number == 0);
            CommonViewHelper.SetImageGray(self.Root(), self.E_Img_SkillIconImage.gameObject, number == 0);
        }

        public static void OnButton_CancleButton(this ES_SkillGrid self)
        {
            C2M_SkillInterruptRequest request = new() { SkillID = self.SkillPro.SkillID };
            self.Root().GetComponent<ClientSenderCompnent>().Send(request);
            Unit unit = self.GetParent<ES_MainSkill>().MainUnit;
            unit.GetComponent<SkillManagerComponentC>()
                    .AddSkillCD(self.SkillPro.SkillID, TimeHelper.ServerNow() + 10000, TimeHelper.ServerNow() + 1000);
            self.E_Button_CancleButton.gameObject.SetActive(false);
        }

        public static void CheckSkillSecond(this ES_SkillGrid self)
        {
            Unit main = self.GetParent<ES_MainSkill>().MainUnit;
            //有对应的buff才能触发二段斩
            int buffId = (int)SkillConfigCategory.Instance.BuffSecondSkill[self.SkillPro.SkillID].KeyId;

            bool havebuff  = false;
            List<EntityRef<Unit>> allunits = main.GetParent<UnitComponent>().GetAll();
            for (int defend = 0; defend < allunits.Count; defend++)
            {
                Unit unititem = allunits[defend];
                BuffManagerComponentC buffManagerComponent = unititem.GetComponent<BuffManagerComponentC>();
                if (buffManagerComponent == null || unititem.Id == main.Id) //|| allDefend[defend].Id == request.TargetID 
                {
                    continue;
                }
                int buffNum = buffManagerComponent.GetBuffSourceNumber(main.Id, buffId);
                if (buffNum <= 0)
                {
                    continue;
                }

                havebuff = true;
                break;
            }

            if (!havebuff)
            {
                self.OnSkillSecondResult(null);
            }
        }
        
        public static void OnSkillSecondResult(this ES_SkillGrid self, M2C_SkillSecondResult message)
        {
            if (self.SkillPro == null)
            {
                return;
            }

            if (message != null && message.HurtIds.Count > 0)
            {
                // 可以释放二段技能
                if (self.SkillSecond == 0)
                {
                    self.SkillSecond = 1;
                    self.E_SkillSecondCDImage.gameObject.SetActive(true);
                    Unit unit = self.GetParent<ES_MainSkill>().MainUnit;
                    unit.GetComponent<SkillManagerComponentC>().ClearSkillCD(message.SkillId);
                    self.ShowSkillSecondCD(self.SkillPro.SkillID).Coroutine();
                }
            }

            if (message == null)
            {
                //未及时释放二段斩，进入CD
                self.SkillSecond = 0;
                self.E_SkillSecondCDImage.gameObject.SetActive(false);
                Unit unit = self.GetParent<ES_MainSkill>().MainUnit;
                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(self.SkillPro.SkillID);
                unit.GetComponent<SkillManagerComponentC>().AddSkillCD(self.SkillPro.SkillID, TimeHelper.ServerNow() + (long)(skillConfig.SkillCD * 1000),
                    TimeHelper.ServerNow() + 500);
            }
        }

        public static void ResetSkillSecond(this ES_SkillGrid self)
        {
            self.SkillSecond = 0;
            self.E_SkillSecondCDImage.gameObject.SetActive(false);
        }
        
        public static async ETTask ShowSkillSecondCD(this ES_SkillGrid self, int skillId)
        {
            KeyValuePairLong4 keyValuePairLong = null;
            SkillConfigCategory.Instance.BuffSecondSkill.TryGetValue(skillId, out keyValuePairLong);
            if (keyValuePairLong == null)
            {
                return;
            }

            long allTime = SkillBuffConfigCategory.Instance.Get((int)keyValuePairLong.KeyId).BuffTime;
            long passTime = 0;
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
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
                    self.E_SkillSecondCDImage.gameObject.SetActive(false);
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

                self.E_SkillSecondCDImage.fillAmount = 1f * (allTime - passTime) / allTime;
                await timerComponent.WaitAsync(100);
                passTime += 100;
            }
        }

        public static void UpdateSkillInfo(this ES_SkillGrid self, SkillPro skillpro)
        {
            self.SkillPro = skillpro;
            if (skillpro == null)
            {
                self.SkillWuqiConfig = null;
                self.SkillBaseConfig = null;
                self.SkillPro = null;
                self.E_Img_SkillCDImage.fillAmount = 0;
                self.E_Img_SkillIconImage.gameObject.SetActive(false);
                self.E_Img_MaskImage.gameObject.SetActive(false);
                self.E_Text_SkillCDText.text = string.Empty;
                return;
            }

            if (skillpro.SkillSetType == (int)SkillSetEnum.Skill)
            {
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

                self.E_Img_SkillIconImage.sprite = sp;

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
                            Log.Error(zstring.Format("skillid == null: 药剂道具ID： {0}   技能ID：{1}", skillpro.SkillID, skillid));
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

                self.E_Img_SkillIconImage.sprite = sp;
            }

            self.E_Button_CancleButton.gameObject.SetActive(false);
            self.E_Img_SkillIconImage.gameObject.SetActive(true);
            self.E_Img_MaskImage.gameObject.SetActive(true);
            self.E_Text_SkillCDText.text = string.Empty;
            self.E_Text_SkillItemNumText.gameObject.SetActive(false);
            self.UpdateItemNumber();
        }
        public static void OnBtn_SkillStartButton(this ES_SkillGrid self)
        {
        }
    }
}
