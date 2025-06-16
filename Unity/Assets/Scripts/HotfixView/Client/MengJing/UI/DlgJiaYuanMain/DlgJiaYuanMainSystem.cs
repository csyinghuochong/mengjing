using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class DataUpdate_BeforeMove_DlgJiaYuanMainRefesh : AEvent<Scene, BeforeMove>
    {
        protected override async ETTask Run(Scene root, BeforeMove args)
        {
            root.GetComponent<UIComponent>().GetDlgLogic<DlgJiaYuanMain>()?.OnSelectCancel();
            await ETTask.CompletedTask;
        }
    }

    [Invoke(TimerInvokeType.JiaYuanPetWalk)]
    public class JiaYuanPetWalk : ATimer<DlgJiaYuanMain>
    {
        protected override void Run(DlgJiaYuanMain self)
        {
            try
            {
                self.ReqestStartPet().Coroutine();
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

    [FriendOf(typeof(DlgJiaYuanMainViewComponent))]
    [FriendOf(typeof(ES_JiaYuaVisit))]
    [FriendOf(typeof(DlgJiaYuanMain))]
    public static class DlgJiaYuanMainSystem
    {
        public static void RegisterUIEvent(this DlgJiaYuanMain self)
        {
            self.View.E_ButtonWarehouseButton.AddListener(() =>
            {
                self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_JiaYuanWarehouse).Coroutine();
            });

            self.View.E_ButtonReturnButton.AddListener(() => { self.OnButtonReturnButton().Coroutine(); });

            self.View.E_ButtonMyJiaYuanButton.gameObject.SetActive(false);
            self.View.E_ButtonMyJiaYuanButton.AddListener(self.OnButtonMyJiaYuanButton);

            self.View.ES_JiaYuaVisit.uiTransform.gameObject.SetActive(false);

            self.View.E_Btn_ShouSuoButton.AddListener(self.OnBtn_ShouSuoButton);

            self.View.E_ButtonOneKeyPlantButton.AddListener(() =>
            {
                self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_JiaYuanOneKeyPlant).Coroutine();
            });
            self.View.E_ButtonGatherButton.AddListener(() => { self.OnButtonGather(); });
            self.View.E_ButtonTalkButton.AddListener(() => { self.OnButtonTalk(); });
            self.View.E_ButtonTargetButton.AddListener(() => { self.OnButtonTarget(); });
            
            self.OnInit().Coroutine();
        }

        public static void ShowWindow(this DlgJiaYuanMain self, Entity contextData = null)
        {
        }

        public static void WaitPetWalk(this DlgJiaYuanMain self, JiaYuanPet jiaYuanPet)
        {
            self.JiaYuanPet = jiaYuanPet;
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            timerComponent?.Remove(ref self.PetTimer);
            self.PetTimer = timerComponent.NewOnceTimer(TimeHelper.ServerNow() + 5000, TimerInvokeType.JiaYuanPetWalk, self);
        }

        public static void HideWindow(this DlgJiaYuanMain self)
        {
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            timerComponent.Remove(ref self.PetTimer);
        }

        public static void SetShow(this DlgJiaYuanMain self, bool value)
        {
            self.View.uiTransform.gameObject.SetActive(value);
        }

        public static async ETTask ReqestStartPet(this DlgJiaYuanMain self)
        {
            JiaYuanPet jiaYuanPet = self.JiaYuanPet;
            if (jiaYuanPet == null)
            {
                return;
            }

            await JiaYuanNetHelper.JiaYuanPetOperateRequest(self.Root(), jiaYuanPet.unitId, 1);
        }

        public static void OnBtn_ShouSuoButton(this DlgJiaYuanMain self)
        {
            bool activeSelf = self.View.ES_JiaYuaVisit.uiTransform.gameObject.activeSelf;
            self.View.ES_JiaYuaVisit.uiTransform.gameObject.SetActive(!activeSelf);

            self.View.E_Btn_ShouSuoButton.transform.localPosition = activeSelf ? new Vector3(-51f, -142f, 0f) : new Vector3(-551f, -142f, 0f);
            self.View.E_Btn_ShouSuoButton.transform.localScale = activeSelf ? new Vector3(-1f, 1f, 1f) : new Vector3(1f, 1f, 1f);
        }

        public static void OnButtonMyJiaYuanButton(this DlgJiaYuanMain self)
        {
            if (self.MyJiaYuan)
            {
                return;
            }

            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>().OnJiaYuanButton();
        }

        public static async ETTask OnButtonReturnButton(this DlgJiaYuanMain self)
        {
            string tipStr = "请选择返回主城或自己家园？";
            await PopupTipHelp.OpenPopupTip(self.Root(), "", LanguageComponent.Instance.LoadLocalization(tipStr),
                () => { EnterMapHelper.RequestQuitFuben(self.Root()); },
                self.OnButtonMyJiaYuanButton);
            DlgPopupTip dlgPopupTip = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPopupTip>();
            dlgPopupTip.View.E_FalseButton.transform.Find("Text").GetComponent<Text>().text = "返回家园";
            dlgPopupTip.View.E_TrueButton.transform.Find("Text").GetComponent<Text>().text = "返回主城";
        }

        public static async ETTask OnClickPet(this DlgJiaYuanMain self, long unitid)
        {
            self.JiaYuanPet = null;
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            Unit unitmonster = unit.GetParent<UnitComponent>().Get(unitid);
            JiaYuanPet jiaYuanPet = self.Root().GetComponent<JiaYuanComponentC>().GetJiaYuanPet(unitid);
            if (jiaYuanPet == null)
            {
                return;
            }

            await JiaYuanNetHelper.JiaYuanPetOperateRequest(self.Root(), unitid, 0);

            if (PositionHelper.Distance2D(unit.Position, unitmonster.Position) < 2)
            {
                self.LockTargetPet(unitid).Coroutine();
            }
            else
            {
                Vector3 unitPos = unit.Position;
                Vector3 position = unitmonster.Position;
                Vector3 dir = (unitPos - position).normalized;
                position += dir * 2f;
                int ret = await unit.MoveToAsync(position);
                if (ret != 0)
                {
                    return;
                }

                self.LockTargetPet(unitid).Coroutine();
            }
        }

        public static async ETTask LockTargetPet(this DlgJiaYuanMain self, long unitid)
        {
            RolePetInfo rolePetInfo = self.Root().GetComponent<PetComponentC>().GetPetInfoByID(unitid);
            if (rolePetInfo == null)
            {
                return;
            }

            JiaYuanPet jiaYuanPet = self.Root().GetComponent<JiaYuanComponentC>().GetJiaYuanPet(unitid);
            if (jiaYuanPet == null)
            {
                return;
            }

            // FlyTipComponent.Instance.ShowFlyTip("UIJiaYuanPetFeed暂未开放");
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_JiaYuanPetFeed);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgJiaYuanPetFeed>().OnInitUI(jiaYuanPet);
        }

        public static async ETTask OnInit(this DlgJiaYuanMain self)
        {
            JiaYuanComponentC jiaYuanComponentC = self.Root().GetComponent<JiaYuanComponentC>();
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();

            M2C_JiaYuanInitResponse response = await JiaYuanNetHelper.JiaYuanInitRequest(self.Root(), jiaYuanComponentC.MasterId);
            jiaYuanComponentC.PlanOpenList_7 = response.PlanOpenList;
            jiaYuanComponentC.PurchaseItemList_7 = response.PurchaseItemList;
            jiaYuanComponentC.LearnMakeIds_7 = response.LearnMakeIds;
            jiaYuanComponentC.JiaYuanPastureList_7 = response.JiaYuanPastureList;
            jiaYuanComponentC.JiaYuanProList_7 = response.JiaYuanProList;
            jiaYuanComponentC.JiaYuanDaShiTime_1 = response.JiaYuanDaShiTime;
            jiaYuanComponentC.JiaYuanPetList_2 = response.JiaYuanPetList;
            if (self.IsDisposed)
            {
                return;
            }

            self.MyJiaYuan = jiaYuanComponentC.MasterId == userInfoComponent.UserInfo.UserId;
            self.JiaYuanLv = self.MyJiaYuan ? userInfoComponent.UserInfo.JiaYuanLv : response.JiaYuanLv;
            JiaYuanConfig jiayuanCof = JiaYuanConfigCategory.Instance.Get(self.JiaYuanLv);

            self.View.E_RenKouTextText.text = jiaYuanComponentC.GetPeopleNumber() + "/" + jiayuanCof.PeopleNumMax;
            self.View.E_GengDiTextText.text = jiaYuanComponentC.GetOpenPlanNumber() + "/" + jiayuanCof.FarmNumMax;

            self.OnInitPlan();
            self.InitEffect();
            self.UpdateName(response.MasterName);
            self.View.ES_JiaYuaVisit.OnInitUI(0).Coroutine();

            if (!self.MyJiaYuan)
            {
                using (zstring.Block())
                {
                    self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>().View.ES_MapMini
                            .ShowMapName(zstring.Format("{0}的家园", response.MasterName));
                }
            }
        }

        public static void OnUpdatePlanNumber(this DlgJiaYuanMain self)
        {
            JiaYuanComponentC jiaYuanComponentC = self.Root().GetComponent<JiaYuanComponentC>();
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            self.JiaYuanLv = userInfoComponent.UserInfo.JiaYuanLv;
            JiaYuanConfig jiayuanCof = JiaYuanConfigCategory.Instance.Get(self.JiaYuanLv);
            using (zstring.Block())
            {
                self.View.E_RenKouTextText.text = zstring.Format("{0}/{1}", jiaYuanComponentC.GetPeopleNumber(), jiayuanCof.PeopleNumMax);
                self.View.E_GengDiTextText.text = zstring.Format("{0}/{1}", jiaYuanComponentC.GetOpenPlanNumber(), jiayuanCof.FarmNumMax);
            }
        }

        public static async ETTask OnGatherSelf(this DlgJiaYuanMain self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());

            List<Unit> units = MapHelper.GetCanShiQu(self.Root(), self.GatherRange);
            if (units.Count > 0)
            {
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>().View.ES_MainSkill.OnShiquItem(self.GatherRange);
                return;
            }

            int gatherNumber = 0;
            long instanceid = self.InstanceId;
            self.GatherTime = TimeHelper.ClientNow();
            List<Unit> planlist = UnitHelper.GetUnitList(self.Root().CurrentScene(), UnitType.Plant);
            for (int i = planlist.Count - 1; i >= 0; i--)
            {
                if (PositionHelper.Distance2D(unit.Position, planlist[i].Position) > self.GatherRange)
                {
                    continue;
                }

                NumericComponentC numericComponent = planlist[i].GetComponent<NumericComponentC>();
                long StartTime = numericComponent.GetAsLong(NumericType.StartTime);
                int GatherNumber = numericComponent.GetAsInt(NumericType.GatherNumber);
                long LastGameTime = numericComponent.GetAsLong(NumericType.GatherLastTime);
                int cellIndex = numericComponent.GetAsInt(NumericType.GatherCellIndex);
                int getcode = ET.JiaYuanHelper.GetPlanShouHuoItem(planlist[i].ConfigId, StartTime, GatherNumber, LastGameTime);
                if (getcode == ErrorCode.ERR_Success)
                {
                    gatherNumber++;

                    await JiaYuanNetHelper.JiaYuanGatherRequest(self.Root(), cellIndex, planlist[i].Id, 1);
                }

                if (instanceid != self.InstanceId)
                {
                    return;
                }
            }

            // 铲除枯萎的植物，重新拿下数据，有些刚刚收获最后一次
            planlist = UnitHelper.GetUnitList(self.Root().CurrentScene(), UnitType.Plant);
            for (int i = planlist.Count - 1; i >= 0; i--)
            {
                if (PositionHelper.Distance2D(unit.Position, planlist[i].Position) > self.GatherRange)
                {
                    continue;
                }

                NumericComponentC numericComponent = planlist[i].GetComponent<NumericComponentC>();
                long StartTime = numericComponent.GetAsLong(NumericType.StartTime);
                int GatherNumber = numericComponent.GetAsInt(NumericType.GatherNumber);
                int cellIndex = numericComponent.GetAsInt(NumericType.GatherCellIndex);

                // 铲除枯萎的植物
                int state = ET.JiaYuanHelper.GetPlanStage(planlist[i].ConfigId, StartTime, GatherNumber);
                if (state < 0 || state > 3)
                {
                    await JiaYuanNetHelper.JiaYuanUprootRequest(self.Root(), cellIndex, planlist[i].Id, 1);
                }

                if (instanceid != self.InstanceId)
                {
                    return;
                }
            }

            List<Unit> pasturelist = UnitHelper.GetUnitList(self.Root().CurrentScene(), UnitType.Pasture);
            for (int i = pasturelist.Count - 1; i >= 0; i--)
            {
                if (PositionHelper.Distance2D(unit.Position, pasturelist[i].Position) > self.GatherRange)
                {
                    continue;
                }

                NumericComponentC numericComponent = pasturelist[i].GetComponent<NumericComponentC>();
                long StartTime = numericComponent.GetAsLong(NumericType.StartTime);
                int GatherNumber = numericComponent.GetAsInt(NumericType.GatherNumber);
                long LastGameTime = numericComponent.GetAsLong(NumericType.GatherLastTime);

                int getcode = ET.JiaYuanHelper.GetPastureShouHuoItem(pasturelist[i].ConfigId, StartTime, GatherNumber, LastGameTime);
                if (getcode == ErrorCode.ERR_Success)
                {
                    gatherNumber++;
                    await JiaYuanNetHelper.JiaYuanGatherRequest(self.Root(), 0, pasturelist[i].Id, 2);
                }

                if (instanceid != self.InstanceId)
                {
                    return;
                }
            }

            if (gatherNumber == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("附近没有可收获的道具！");
            }
        }

        public static async ETTask OnGatherOther(this DlgJiaYuanMain self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());

            List<Unit> units = MapHelper.GetCanShiQu(self.Root(), self.GatherRange);
            if (units.Count > 0)
            {
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>().View.ES_MainSkill.OnShiquItem(self.GatherRange);
                return;
            }

            int gatherNumber = 0;
            long instanceid = self.InstanceId;
            self.GatherTime = TimeHelper.ClientNow();
            JiaYuanComponentC jiaYuanComponentC = self.Root().GetComponent<JiaYuanComponentC>();
            List<Unit> planlist = UnitHelper.GetUnitList(self.Root().CurrentScene(), UnitType.Plant);
            for (int i = planlist.Count - 1; i >= 0; i--)
            {
                if (PositionHelper.Distance2D(unit.Position, planlist[i].Position) > self.GatherRange)
                {
                    continue;
                }

                NumericComponentC numericComponent = planlist[i].GetComponent<NumericComponentC>();
                long StartTime = numericComponent.GetAsLong(NumericType.StartTime);
                int GatherNumber = numericComponent.GetAsInt(NumericType.GatherNumber);
                long LastGameTime = numericComponent.GetAsLong(NumericType.GatherLastTime);
                int cellIndex = numericComponent.GetAsInt(NumericType.GatherCellIndex);
                int getcode = ET.JiaYuanHelper.GetPlanShouHuoItem(planlist[i].ConfigId, StartTime, GatherNumber, LastGameTime);
                if (getcode == ErrorCode.ERR_Success)
                {
                    gatherNumber++;
                    await JiaYuanNetHelper.JiaYuanGatherOtherRequest(self.Root(), cellIndex, jiaYuanComponentC.MasterId, planlist[i].Id, 1);
                }

                if (instanceid != self.InstanceId)
                {
                    return;
                }
            }

            List<Unit> pasturelist = UnitHelper.GetUnitList(self.Root().CurrentScene(), UnitType.Pasture);
            for (int i = pasturelist.Count - 1; i >= 0; i--)
            {
                if (PositionHelper.Distance2D(unit.Position, pasturelist[i].Position) > self.GatherRange)
                {
                    continue;
                }

                NumericComponentC numericComponent = pasturelist[i].GetComponent<NumericComponentC>();
                long StartTime = numericComponent.GetAsLong(NumericType.StartTime);
                int GatherNumber = numericComponent.GetAsInt(NumericType.GatherNumber);
                long LastGameTime = numericComponent.GetAsLong(NumericType.GatherLastTime);

                int getcode = ET.JiaYuanHelper.GetPastureShouHuoItem(pasturelist[i].ConfigId, StartTime, GatherNumber, LastGameTime);
                if (getcode == ErrorCode.ERR_Success)
                {
                    gatherNumber++;

                    await JiaYuanNetHelper.JiaYuanGatherOtherRequest(self.Root(), 0, jiaYuanComponentC.MasterId, pasturelist[i].Id, 2);
                }

                if (instanceid != self.InstanceId)
                {
                    return;
                }
            }

            if (gatherNumber == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("附近没有可收获的道具！");
            }
        }

        public static void OnButtonGather(this DlgJiaYuanMain self)
        {
            if (TimeHelper.ClientNow() - self.GatherTime < 2000)
            {
                return;
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (self.Root().GetComponent<JiaYuanComponentC>().IsMyJiaYuan(unit.Id))
            {
                self.OnGatherSelf().Coroutine();
            }
            else
            {
                self.OnGatherOther().Coroutine();
            }
        }

        public static void OnButtonTalk(this DlgJiaYuanMain self)
        {
            Unit main = UnitHelper.GetMyUnitFromClientScene(self.Root());
            List<EntityRef<Unit>> units = main.GetParent<UnitComponent>().GetAll();

            float mindis = float.MaxValue;
            long rubshid = 0;
            for (int i = 0; i < units.Count; i++)
            {
                Unit unit = units[i];
                if (unit.Type != UnitType.Monster)
                {
                    continue;
                }

                MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(unit.ConfigId);
                if (monsterConfig.MonsterSonType != 60)
                {
                    continue;
                }

                float t_distance = PositionHelper.Distance2D(main.Position, unit.Position);
                if (t_distance < 5f && t_distance <= mindis)
                {
                    rubshid = unit.Id;
                    mindis = t_distance;
                }
            }

            if (rubshid > 0)
            {
                self.Root().CurrentScene().GetComponent<OperaComponent>().OnClickChest(rubshid);
            }
            else
            {
                DuiHuaHelper.MoveToNpcDialog(self.Root());
            }
        }

        public static void OnButtonTarget(this DlgJiaYuanMain self)
        {
            self.LockTargetUnit().Coroutine();
        }

        public static async ETTask<int> LockTargetPasture(this DlgJiaYuanMain self)
        {
            float distance = 10f;

            Unit main = UnitHelper.GetMyUnitFromClientScene(self.Root());
            List<EntityRef<Unit>> units = main.GetParent<UnitComponent>().GetAll();
            ListComponent<UnitLockRange> UnitLockRanges = new ListComponent<UnitLockRange>();
            for (int i = 0; i < units.Count; i++)
            {
                Unit unit = units[i];
                if (!unit.IsPasture())
                {
                    continue;
                }

                float dd = PositionHelper.Distance2D(main.Position, unit.Position);
                if (dd < distance)
                {
                    UnitLockRanges.Add(new UnitLockRange() { Id = unit.Id, Range = (int)(dd * 100) });
                }
            }

            if (UnitLockRanges.Count == 0)
            {
                //取消锁定
                return -1;
            }

            UnitLockRanges.Sort(delegate(UnitLockRange a, UnitLockRange b) { return a.Range - b.Range; });

            self.LastPasureIndex++;
            if (self.LastPasureIndex >= UnitLockRanges.Count)
            {
                self.LastPasureIndex = 0;
            }

            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_JiaYuanMenu);
            Unit targetUnit = self.Root().CurrentScene().GetComponent<UnitComponent>().Get(UnitLockRanges[self.LastPasureIndex].Id);
            self.Root().GetComponent<LockTargetComponent>().LockTargetUnitId(targetUnit.Id);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgJiaYuanMenu>().OnUpdatePasture(targetUnit);
            return self.LastPasureIndex;
        }

        public static async ETTask LockTargetUnit(this DlgJiaYuanMain self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_JiaYuanMenu);
            int lastTarget = await self.LockTargetPasture();
            if (lastTarget != -1)
            {
                return;
            }

            //植物
            float distance = 2f;
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            List<UnitLockRange> UnitLockRanges = new ListComponent<UnitLockRange>();
            JiaYuanComponentC jiaYuanComponent = self.Root().GetComponent<JiaYuanComponentC>();
            for (int i = 0; i < self.JianYuanPlanUIs.Count; i++)
            {
                float dd = Vector3.Distance(unit.Position, self.JianYuanPlanUIs[i].transform.position);
                if (dd < distance && jiaYuanComponent.PlanOpenList_7.Contains(i))
                {
                    UnitLockRanges.Add(new UnitLockRange() { Id = i, Range = (int)(dd * 100) });
                }
            }

            if (UnitLockRanges.Count == 0)
            {
                return;
            }

            UnitLockRanges.Sort(delegate(UnitLockRange a, UnitLockRange b) { return a.Range - b.Range; });
            self.LastCellIndex++;
            if (self.LastCellIndex >= UnitLockRanges.Count)
            {
                self.LastCellIndex = 0;
            }

            self.OnClickPlanItem((int)UnitLockRanges[self.LastCellIndex].Id).Coroutine();
        }

        public static async ETTask RequestPlanOpen(this DlgJiaYuanMain self, int index)
        {
            M2C_JiaYuanPlanOpenResponse response = await JiaYuanNetHelper.JiaYuanPlanOpenRequest(self.Root(), index);
            if (response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            self.Root().GetComponent<JiaYuanComponentC>().PlanOpenList_7 = response.PlanOpenList;

            self.OnOpenPlan(index);
        }

        public static async ETTask OnClickPlanItem(this DlgJiaYuanMain self, int index)
        {
            JiaYuanComponentC jiaYuanComponentC = self.Root().GetComponent<JiaYuanComponentC>();
            if (jiaYuanComponentC.PlanOpenList_7.Contains(index))
            {
                self.OnSelectCell(index);
                await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_JiaYuanMenu);
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgJiaYuanMenu>().OnUpdatePlan();
                await ETTask.CompletedTask;
                return;
            }

            if (!self.MyJiaYuan)
            {
                return;
            }

            int costnumber = ConfigData.JiaYuanFarmOpen[index];
            using (zstring.Block())
            {
                string consttip = CommonViewHelper.GetNeedItemDesc(zstring.Format("13;{0}", costnumber));
                PopupTipHelp.OpenPopupTip(self.Root(), "系统提示", zstring.Format("是否花费 {0} 开启一块土地", consttip),
                    () => { self.RequestPlanOpen(index).Coroutine(); }, null).Coroutine();
            }
        }

        public static void OnOpenPlan(this DlgJiaYuanMain self, int index)
        {
            JiaYuanPlanLockComponent jiaYuanPlanLockComponent = null;
            if (self.JiaYuanPlanLocks.ContainsKey(index))
            {
                jiaYuanPlanLockComponent = self.JiaYuanPlanLocks[index];
            }

            if (jiaYuanPlanLockComponent == null)
            {
                return;
            }

            jiaYuanPlanLockComponent.SetOpenState(index, true);

            self.OnUpdatePlanNumber();
        }

        public static void CopyBuffer(this DlgJiaYuanMain self)
        {
            GUIUtility.systemCopyBuffer = "Target String";
        }

        public static void UpdateName(this DlgJiaYuanMain self, string mastername)
        {
            // Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            // System.Numerics.Vector3 unitPosi = new(unit.Position.x, unit.Position.y, unit.Position.z);
            //
            // Unit npc = TaskHelper.GetNpcByConfigId(self.Root(), unitPosi, 30000004);
            // if (npc == null)
            // {
            //     return;
            // }
            //
            // GameObjectComponent gameObjectComponent = npc.GetComponent<GameObjectComponent>();
            // if (gameObjectComponent == null || gameObjectComponent.GameObject == null)
            // {
            //     return;
            // }
            //
            // GameObject gameObject = gameObjectComponent.GameObject;
            // TextMesh textMesh = gameObject.Get<GameObject>("NewNameText").GetComponent<TextMesh>();
            // textMesh.text = mastername;
        }

        public static void InitEffect(this DlgJiaYuanMain self)
        {
            string path = ABPathHelper.GetEffetPath("ScenceEffect/Eff_JiaYuan_Select");
            GameObject prefab = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
            self.SelectEffect = UnityEngine.Object.Instantiate(prefab, self.Root().GetComponent<GlobalComponent>().Unit, true);
            self.SelectEffect.SetActive(false);
        }

        public static void OnInitPlan(this DlgJiaYuanMain self)
        {
            self.JianYuanPlanUIs.Clear();
            GameObject NongChangSet = GameObject.Find("NongChangSet");
            JiaYuanComponentC jiaYuanComponentC = self.Root().GetComponent<JiaYuanComponentC>();
            for (int i = 0; i < NongChangSet.transform.childCount; i++)
            {
                GameObject item = NongChangSet.transform.GetChild(i).gameObject;
                item.SetActive(true);
                JiaYuanPlanLockComponent jiaYuanPlanLock = self.AddChild<JiaYuanPlanLockComponent, GameObject>(item);
                self.JiaYuanPlanLocks.Add(i, jiaYuanPlanLock);
                jiaYuanPlanLock.SetOpenState(i, jiaYuanComponentC.PlanOpenList_7.Contains(i));
                self.JianYuanPlanUIs.Add(i, item);
            }
        }

        public static void OnSelectCell(this DlgJiaYuanMain self, int cell)
        {
            CommonViewHelper.SetParent(self.SelectEffect, self.JianYuanPlanUIs[cell]);
            self.CellIndex = cell;
            self.SelectEffect.SetActive(true);
            self.SelectEffect.transform.localPosition = new Vector3(0f, 0.2f, 0f);
        }

        public static void OnSelectCancel(this DlgJiaYuanMain self)
        {
            self.SelectEffect?.SetActive(false);
        }
    }
}