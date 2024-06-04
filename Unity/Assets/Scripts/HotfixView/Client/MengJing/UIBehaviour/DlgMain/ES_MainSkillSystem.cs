using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_MainSkill))]
    [FriendOfAttribute(typeof (ES_MainSkill))]
    public static partial class ES_MainSkillSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.ES_MainSkill self, UnityEngine.Transform transform)
        {
            self.uiTransform = transform;

            self.E_Btn_Target.GetComponent<Button>().onClick.AddListener(self.OnLockTargetUnit);
            self.E_shiquButton.GetComponent<Button>().onClick.AddListener(() => { self.OnShiquItem(3f); });
            self.E_Btn_NpcDuiHua.GetComponent<Button>().onClick.AddListener(self.OnBtn_NpcDuiHua);
            self.E_Button_ZhuaPu.GetComponent<Button>().onClick.AddListener(self.OnButton_ZhuaPu);
            self.E_Btn_PetTarget.GetComponent<Button>().onClick.AddListener(() => { self.OnBtn_PetTarget().Coroutine(); });

            EventTrigger eventTrigger = self.E_Btn_CancleSkill.GetComponent<EventTrigger>();
            eventTrigger.RegisterEvent(EventTriggerType.PointerEnter, (pdata) => { self.OnEnterCancelButton(); });

            self.E_Btn_JingLing.onClick.AddListener(() => { self.OnBtn_JingLing().Coroutine(); });
            self.E_Button_Switch_0.onClick.AddListener(() => { self.OnButton_Switch().Coroutine(); });

            self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this ET.Client.ES_MainSkill self)
        {
            self.DestroyWidget();
        }

        private static void OnInitUI(this ET.Client.ES_MainSkill self)
        {
            List<Vector3> positionList = new List<Vector3>()
            {
                new Vector3(-148.7f, 302.2f, 0f),
                new Vector3(-306.2f, 271.9f, 0f),
                new Vector3(-382.7f, 153.4f, 0f),
                new Vector3(-112.2f, 434.5f, 0f),
                new Vector3(-253.6f, 425.5f, 0f),
                new Vector3(-407.7f, 367.8f, 0f),
                new Vector3(-493.7f, 236.71f, 0f),
                new Vector3(-506.5f, 90.7f, 0f),
                new Vector3(-326.6f, 61.7f, 0f),
                new Vector3(-68.7f, 226.2f, 0f),
            };

            for (int i = 0; i < 10; i++)
            {
                GameObject go = GameObject.Instantiate(self.E_MainRoseSkill_item);
                go.SetActive(true);
                ES_MainSkillGrid skillgrid = self.AddChild<ES_MainSkillGrid, Transform>(go.transform);
                skillgrid.SkillCancelHandler = self.ShowCancelButton;
                self.MainSkillGridList.Add(skillgrid);
                UICommonHelper.SetParent(go, self.E_MainRoseSkill_item.transform.parent.gameObject);
                go.transform.localPosition = positionList[i];
            }
        }

        public static async ETTask OnBtn_PetTarget(this ES_MainSkill self)
        {
            long lockId = self.Scene().GetComponent<LockTargetComponent>().LastLockId;
            if (lockId == 0)
            {
                return;
            }

            await BagClientNetHelper.PetTargetLock(self.Root(), lockId);
        }

        public static async ETTask OnButton_Switch(this ES_MainSkill self)
        {
            if (self.SwitchCDEndTime != 0)
            {
                return;
            }

            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            BagInfo equip_1 = bagComponent.GetEquipBySubType(ItemLocType.ItemLocEquip, (int)ItemSubTypeEnum.Wuqi);
            BagInfo equip_2 = bagComponent.GetEquipBySubType(ItemLocType.ItemLocEquip_2, (int)ItemSubTypeEnum.Wuqi);
            if (equip_1 == null || equip_2 == null)
            {
                FlyTipComponent.Instance.SpawnFlyTip("请先在对应位置装备武器！");
                return;
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Scene());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            int equipIndex = numericComponent.GetAsInt(NumericType.EquipIndex);

            M2C_ItemEquipIndexResponse response = await BagClientNetHelper.ItemEquipIndex(self.Root(), equipIndex == 0? 1 : 0);
            if (self.IsDisposed || response.Error > 0)
            {
                return;
            }

            self.SwitchCDEndTime = TimeHelper.ServerNow() + ConfigData.HunterSwichCD;

            self.OnUpdateButton();
            self.ShowSwitchCD().Coroutine();
            unit.GetComponent<AttackComponent>().UpdateComboTime();
            EventSystem.Instance.Publish(self.Root(), new DataUpdate_EquipWear());
        }

        public static async ETTask ShowSwitchCD(this ES_MainSkill self)
        {
            while (self.SwitchCDEndTime > 0)
            {
                long passTime = self.SwitchCDEndTime - TimeHelper.ServerNow();
                if (passTime < 0)
                {
                    self.SwitchCDEndTime = 0;
                    break;
                }

                float rate = passTime * 1f / ConfigData.HunterSwichCD;
                self.E_Button_Switch_CD.fillAmount = rate;
                await self.Root().GetComponent<TimerComponent>().WaitFrameAsync();
                if (self.IsDisposed)
                {
                    break;
                }
            }
        }

        public static void OnUpdateButton(this ES_MainSkill self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Scene());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            int equipIndex = numericComponent.GetAsInt(NumericType.EquipIndex);
            int occ = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Occ;
            self.E_Button_Switch_0.gameObject.SetActive(occ == 3);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, equipIndex == 0? "c12" : "c11");
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_Button_Switch_0.GetComponent<Image>().sprite = sp;
        }

        public static void OnTransform(this ES_MainSkill self, int runraceid, int cardmonsterid)
        {
            //切换技能按钮。。 变身后只有一个技能按钮，读取monsterconfig.ActSkillID.. 
            //Normal / Transforms
            if (runraceid > 0)
            {
                if (self.SkillGridBianSheng == null)
                {
                    ReferenceCollector rc = self.E_Transforms.GetComponent<ReferenceCollector>();
                    GameObject go = rc.Get<GameObject>("UI_MainRoseSkill_item_0");
                    ES_MainSkillGrid uiSkillGridComponent = self.AddChild<ES_MainSkillGrid, Transform>(go.transform);
                    uiSkillGridComponent.SkillCancelHandler = self.ShowCancelButton;
                    self.SkillGridBianSheng = uiSkillGridComponent;
                }

                MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(runraceid);
                if (monsterConfig.SkillID != null && monsterConfig.SkillID.Length > 0)
                {
                    SkillPro skillPro = new SkillPro();
                    skillPro.SkillID = monsterConfig.SkillID[0];
                    skillPro.SkillSetType = (int)SkillSetEnum.Skill;
                    self.SkillGridBianSheng.UpdateSkillInfo(skillPro);
                }

                self.E_Normal.gameObject.SetActive(false);
                self.E_Transforms.gameObject.SetActive(true);
            }
            else
            {
                self.E_Normal.gameObject.SetActive(true);
                self.E_Transforms.gameObject.SetActive(false);
            }
        }

        public static void OnUpdateAngle(this ES_MainSkill self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Scene());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            bool show_old = self.SkillGridJueXing.UITransform.gameObject.activeSelf;
            bool show_new = numericComponent.GetAsInt(NumericType.JueXingAnger) >= 500;
            self.SkillGridJueXing.UITransform.gameObject.SetActive(show_new);
            if (!show_old && show_new)
            {
                self.SkillGridJueXing.RemoveSkillInfoShow();
            }

            if (show_old && !show_new)
            {
                self.Scene().GetComponent<SkillIndicatorComponent>().RecoveryEffect();
            }
        }

        public static void CheckJingLingFunction(this ES_MainSkill self)
        {
            self.E_Btn_JingLing.gameObject.SetActive(false);
            ChengJiuComponentC chengJiuComponent = self.Root().GetComponent<ChengJiuComponentC>();
            if (chengJiuComponent.JingLingId == 0)
            {
                return;
            }

            bool showButton = false;
            JingLingConfig jingLingConfig = JingLingConfigCategory.Instance.Get(chengJiuComponent.JingLingId);
            switch (jingLingConfig.FunctionType)
            {
                case 1:
                    showButton = chengJiuComponent.RandomDrop == 0;
                    break;
                case 7:
                    showButton = true;
                    break;
                default:
                    showButton = false;
                    break;
            }

            self.E_Btn_JingLing.gameObject.SetActive(showButton);
        }

        public static async ETTask OnBtn_JingLing(this ES_MainSkill self)
        {
            ChengJiuComponentC chengJiuComponent = self.Root().GetComponent<ChengJiuComponentC>();
            if (chengJiuComponent.JingLingId == 0)
            {
                return;
            }

            JingLingConfig jingLingConfig = JingLingConfigCategory.Instance.Get(chengJiuComponent.JingLingId);
            switch (jingLingConfig.FunctionType)
            {
                case 1:
                    if (chengJiuComponent.RandomDrop == 1)
                    {
                        FlyTipComponent.Instance.SpawnFlyTipDi("每日只能获取一次奖励！");
                        return;
                    }

                    await BagClientNetHelper.JingLingDrop(self.Root());
                    chengJiuComponent.RandomDrop = 1;
                    self.CheckJingLingFunction();
                    break;
                case 7:
                    int functionId = int.Parse(jingLingConfig.FunctionValue);
                    FuntionConfig funtionConfig = FuntionConfigCategory.Instance.Get(functionId);
                    //string uipath = FunctionUI.GetUIPath(funtionConfig.Name);
                    //UIHelper.Create(self.ZoneScene(), uipath).Coroutine();
                    break;
                default:
                    break;
            }
        }

        public static void OnLockUnit(this ES_MainSkill self, Unit unitlock)
        {
            if (unitlock == null || unitlock.Type != UnitType.Monster)
            {
                self.E_Button_ZhuaPu.gameObject.SetActive(false);
                return;
            }

            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(unitlock.ConfigId);
            self.E_Button_ZhuaPu.gameObject.SetActive(monsterConfig.MonsterSonType == 58 || monsterConfig.MonsterSonType == 59);
        }

        public static void OnButton_ZhuaPu(this ES_MainSkill self)
        {
            long lockTargetId = self.Scene().GetComponent<LockTargetComponent>().LastLockId;
            if (lockTargetId == 0)
            {
                return;
            }

            Unit main = UnitHelper.GetMyUnitFromClientScene(self.Scene());
            Unit target = main.GetParent<UnitComponent>().Get(lockTargetId);
            if (target == null)
            {
                return;
            }

            if (PositionHelper.Distance2D(main.Position, target.Position) <= 3)
            {
                self.OnArriveNpc(target);
                return;
            }

            float3 dir = math.normalize(main.Position - target.Position);
            float3 position = target.Position + dir * 2f;
            self.MoveToNpc(target, position).Coroutine();
        }

        public static void OnArriveNpc(this ES_MainSkill self, Unit target)
        {
            if (target == null || target.IsDisposed)
            {
                return;
            }

            // UIHelper.CurrentNpcId = target.ConfigId;
            // UIHelper.CurrentNpcUI = UIType.UIZhuaPu;
            // UI uimain = UIHelper.GetUI(self.ZoneScene(), UIType.UIMain);
            // uimain.GetComponent<UIMainComponent>().UIJoystickMoveComponent.GameObject.SetActive(false);
            // CameraComponent cameraComponent = self.ZoneScene().CurrentScene().GetComponent<CameraComponent>();
            // cameraComponent.SetBuildEnter(target, () => { self.OnBuildEnter().Coroutine(); });
        }

        public static async ETTask MoveToNpc(this ES_MainSkill self, Unit target, Vector3 position)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Scene());
            if (ErrorCode.ERR_Success != unit.GetComponent<StateComponentC>().CanMove())
                return;

            int ret = await unit.MoveToAsync(position);
            if (ret != 0)
            {
                return;
            }

            if (PositionHelper.Distance2D(unit.Position, position) > 3f)
            {
                return;
            }

            self.OnArriveNpc(target);
        }

        public static async ETTask OnBuildEnter(this ES_MainSkill self)
        {
            await ETTask.CompletedTask;
            // UI uimain = UIHelper.GetUI(self.ZoneScene(), UIType.UIMain);
            // uimain.GetComponent<UIMainComponent>().UIJoystickMoveComponent.GameObject.SetActive(true);
            // long lockTargetId = self.ZoneScene().GetComponent<LockTargetComponent>().LastLockId;
            // if (lockTargetId == 0)
            // {
            //     return;
            // }
            // Unit unit = self.ZoneScene().CurrentScene().GetComponent<UnitComponent>().Get(lockTargetId);
            // if (unit == null || unit.Type!=UnitType.Monster)
            // {
            //     return;
            // }
            //
            // //创建UI
            // UI ui = await UIHelper.Create(self.ZoneScene(), UIType.UIZhuaPu);
            // ui.GetComponent<UIZhuaPuComponent>().OnInitUI(unit);
        }

        public static void OnBtn_NpcDuiHua(this ES_MainSkill self)
        {
            //DuiHuaHelper.MoveToNpcDialog(self.ZoneScene());
        }

        public static void OnShiquItem(this ES_MainSkill self, float distance)
        {
            if (self.Root().GetComponent<BagComponentC>().GetBagLeftCell() <= 0)
            {
                EventSystem.Instance.Publish(self.Root(), new ShowFlyTip() { Str = "背包已满!" });
                return;
            }

            Unit main = UnitHelper.GetMyUnitFromClientScene(self.Scene());
            if (main.GetComponent<SkillManagerComponentC>().IsSkillMoveTime())
            {
                return;
            }

            List<DropInfo> ids = MapHelper.GetCanShiQu(self.Scene(), distance);
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            if (ids.Count > 0)
            {
                for (int i = ids.Count - 1; i >= 0; i--)
                {
                    ItemConfig itemConfig = ItemConfigCategory.Instance.Get(ids[i].ItemID);

                    if (userInfoComponent.PickSet[0] == "1" && itemConfig.ItemQuality == 2)
                    {
                        ids.RemoveAt(i);
                        continue;
                    }

                    // 蓝色 金币除外
                    if (userInfoComponent.PickSet[1] == "1" && itemConfig.ItemQuality == 3 && itemConfig.Id != 1)
                    {
                        ids.RemoveAt(i);
                        continue;
                    }
                }

                if (ids.Count <= 0)
                {
                    return;
                }

                self.RequestShiQu(ids).Coroutine();

                //播放音效
                //UIHelper.PlayUIMusic("10004");
                return;
            }
            else
            {
                Unit unit = MapHelper.GetNearItem(self.Scene());
                if (unit != null)
                {
                    float3 dir = math.normalize(main.Position - unit.Position);
                    float3 tar = unit.Position + (dir * 1f);
                    self.MoveToShiQu(tar).Coroutine();
                    return;
                }
            }

            long chestId = MapHelper.GetChestBox(self.Scene());
            if (chestId != 0)
            {
                self.Scene().CurrentScene().GetComponent<OperaComponent>().OnClickChest(chestId);
            }
        }

        public static async ETTask RequestShiQu(this ES_MainSkill self, List<DropInfo> ids)
        {
            if (TimeHelper.ServerNow() - self.LastPickTime < 1000)
            {
                return;
            }

            self.LastPickTime = TimeHelper.ServerNow();
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Scene());
            if (!unit.GetComponent<MoveComponent>().IsArrived())
            {
                self.Root().GetComponent<ClientSenderCompnent>().Send(new C2M_Stop());
            }

            unit.GetComponent<FsmComponent>().ChangeState(FsmStateEnum.FsmShiQuItem);
            MapHelper.SendShiquItem(self.Scene(), ids).Coroutine();

            unit.GetComponent<StateComponentC>().SetNetWaitEndTime(TimeHelper.ClientNow() + 200);
            long instancId = self.InstanceId;
            await self.Root().GetComponent<TimerComponent>().WaitAsync(200);
            if (instancId != self.InstanceId)
            {
                return;
            }

            unit.GetComponent<FsmComponent>().ChangeState(FsmStateEnum.FsmIdleState);
        }

        public static async ETTask MoveToShiQu(this ES_MainSkill self, Vector3 position)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Scene());
            int value = await unit.MoveToAsync(position);
            List<DropInfo> ids = MapHelper.GetCanShiQu(self.Scene(), 3f);
            if (value == 0 && ids.Count > 0)
            {
                self.RequestShiQu(ids).Coroutine();
            }
        }

        public static void OnSkillSecond(this ES_MainSkill self, M2C_SkillSecondResult message)
        {
            for (int i = 0; i < self.MainSkillGridList.Count; i++)
            {
                if (self.MainSkillGridList[i].SkillPro == null)
                {
                    continue;
                }

                if (self.MainSkillGridList[i].SkillPro.SkillID == message.SkillId)
                {
                    self.MainSkillGridList[i].OnSkillSecondResult(message);
                }
            }
        }

        public static void OnSkillBeging(this ES_MainSkill self, string dataParams)
        {
            int skillId = int.Parse(dataParams);
            for (int i = 0; i < self.MainSkillGridList.Count; i++)
            {
                if (self.MainSkillGridList[i].SkillPro == null)
                {
                    continue;
                }

                if (self.MainSkillGridList[i].SkillPro.SkillID == skillId)
                {
                    self.MainSkillGridList[i].E_Button_Cancle.gameObject.SetActive(true);
                }
            }
        }

        public static void OnSkillFinish(this ES_MainSkill self, string dataParams)
        {
            int skillId = int.Parse(dataParams);
            for (int i = 0; i < self.MainSkillGridList.Count; i++)
            {
                if (self.MainSkillGridList[i].SkillPro == null)
                {
                    continue;
                }

                if (self.MainSkillGridList[i].SkillPro.SkillID == skillId)
                {
                    self.MainSkillGridList[i].E_Button_Cancle.gameObject.SetActive(false);
                }
            }
        }

        public static void OnSkillCDUpdate(this ES_MainSkill self)
        {
            Unit main = UnitHelper.GetMyUnitFromClientScene(self.Scene());
            SkillManagerComponentC skillManagerComponentC = main.GetComponent<SkillManagerComponentC>();
            long serverTime = TimeHelper.ServerNow();
            long pulicCd = skillManagerComponentC.SkillPublicCDTime - serverTime;
            for (int i = 0; i < self.MainSkillGridList.Count; i++)
            {
                ES_MainSkillGrid uISkillGridComponent = self.MainSkillGridList[i];
                uISkillGridComponent.OnUpdate(skillManagerComponentC.GetCdTime(uISkillGridComponent.GetSkillId(), serverTime),
                    i < 8? pulicCd : 0);
            }

            if (self.JueXingSkillId > 0)
            {
                self.SkillGridJueXing?.OnUpdate(skillManagerComponentC.GetCdTime(self.JueXingSkillId, serverTime), pulicCd);
            }

            self.SkillGridBianSheng?.OnUpdate(skillManagerComponentC.GetCdTime(self.SkillGridBianSheng.GetSkillId(), serverTime), pulicCd);
            self.MainSkillFungun?.OnUpdate(skillManagerComponentC.GetCdTime(self.MainSkillFungun.SkillId, serverTime));
        }

        public static void OnEnterScene(this ES_MainSkill self, Unit unit, int sceneType)
        {
            SkillManagerComponentC skillManagerComponent = unit.GetComponent<SkillManagerComponentC>();
            self.OnSkillCDUpdate();
            self.CheckJingLingFunction();
            self.OnUpdateButton();
            for (int i = 0; i < self.MainSkillGridList.Count; i++)
            {
                self.MainSkillGridList[i].RemoveSkillInfoShow();
            }

            self.SkillGridJueXing.RemoveSkillInfoShow();
        }

        public static void ResetUI(this ES_MainSkill self)
        {
            for (int i = 0; i < self.MainSkillGridList.Count; i++)
            {
                ES_MainSkillGrid uISkillGridComponent = self.MainSkillGridList[i];
                uISkillGridComponent.RemoveSkillInfoShow();
                uISkillGridComponent.OnUpdate(0, 0);
                uISkillGridComponent.UseSkill = false;
                uISkillGridComponent.SkillSecond = 0;
            }

            self.MainSkillFungun?.OnUpdate(0);
        }

        public static void OnLockTargetUnit(this ES_MainSkill self)
        {
            LockTargetComponent lockTargetComponent = self.Scene().GetComponent<LockTargetComponent>();
            if (TimeHelper.ServerNow() - self.LastLockTime > 5000)
            {
                lockTargetComponent.LastLockId = 0;
                lockTargetComponent.LockTargetUnit();
                self.LastLockTime = TimeHelper.ServerNow();
            }
            else
            {
                lockTargetComponent.LockTargetUnit(true);
            }
        }

        public static void ShowCancelButton(this ES_MainSkill self, bool show)
        {
            self.E_Btn_CancleSkill.gameObject.SetActive(show);
        }

        public static void OnEnterCancelButton(this ES_MainSkill self)
        {
            FlyTipComponent.Instance.SpawnFlyTip("取消技能施法");

            for (int i = 0; i < self.MainSkillGridList.Count; i++)
            {
                self.MainSkillGridList[i].OnEnterCancelButton();
            }

            self.SkillGridJueXing?.OnEnterCancelButton();
        }

        public static void OnBagItemUpdate(this ES_MainSkill self)
        {
            for (int i = 0; i < self.MainSkillGridList.Count; i++)
            {
                self.MainSkillGridList[i].UpdateItemNumber();
            }
        }

        public static void OnSkillSetUpdate(this ES_MainSkill self)
        {
            SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();
            for (int i = 0; i < 10; i++)
            {
                ES_MainSkillGrid skillgrid = self.MainSkillGridList[i];
                SkillPro skillid = skillSetComponent.GetByPosition(i + 1);
                skillgrid.UpdateSkillInfo(skillid);
            }

            int occTwo = self.Root().GetComponent<UserInfoComponentC>().UserInfo.OccTwo;
            if (occTwo == 0)
            {
                return;
            }

            // OccupationTwoConfig occupationConfigCategory = OccupationTwoConfigCategory.Instance.Get(occTwo);
            // int juexingid = occupationConfigCategory.JueXingSkill[7];
            // self.SkillGridJueXing.UpdateSkillInfo(skillSetComponent.GetSkillPro(juexingid));
            // self.JueXingSkillId = juexingid;
        }
    }
}