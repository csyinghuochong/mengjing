using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (UnitGuaJiComponent))]
    [EntitySystemOf(typeof (UnitGuaJiComponent))]
    public static partial class UnitGuaJiComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UnitGuaJiComponent self)
        {
            DlgMain dlgMain = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>();
            dlgMain.View.EG_GuaJiSetRectTransform.gameObject.SetActive(true);
            self.UIMain = dlgMain;

            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            string acttype = userInfoComponent.GetGameSettingValue(GameSettingEnum.GuaJiSell);
            self.IfSellStatus = acttype == "1";

            acttype = userInfoComponent.GetGameSettingValue(GameSettingEnum.GuaJiRang);
            self.IfGuaJiRange = acttype == "1";

            acttype = userInfoComponent.GetGameSettingValue(GameSettingEnum.GuaJiAutoUseItem);
            self.IfGuaJiAutoUseItem = acttype == "1";

            self.LockTargetComponent = self.Root().GetComponent<LockTargetComponent>();
            self.LockTargetComponent.IsGuaJi = true;

            // 触发挂机
            self.ActTarget();

            // 触发时间间隔
            self.TimeTriggerActTarget().Coroutine();

            // 初始化序列号列表
            self.InitXuHaoID();
        }

        [EntitySystem]
        private static void Destroy(this UnitGuaJiComponent self)
        {
            self.LockTargetComponent.IsGuaJi = false;
        }

        //初始化ID
        public static void InitXuHaoID(this UnitGuaJiComponent self)
        {
            self.skillXuHaoList = new List<int>();
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

                    int index = int.Parse(skill);

                    if (index == -1)
                    {
                        continue;
                    }

                    int skillid = self.UIMain.View.ES_MainSkill.UISkillGirdList_Normal[index].GetSkillId();
                    if (skillid != 0)
                    {
                        self.skillXuHaoList.Add(index);
                    }
                }
            }
        }

        //触发挂机目标
        public static bool ActTarget(this UnitGuaJiComponent self)
        {
            //获取场景,如果当前在主城自动取消
            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            if (mapComponent.SceneId == 101)
            {
                FlyTipComponent.Instance.ShowFlyTip("主城禁止挂机喔，已为你自动移除挂机!");
                self.Root().RemoveComponent<UnitGuaJiComponent>();
                return false;
            }

            //判断是否有体力,没体力不能挂机,减少服务器开销
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (unit.Root().GetComponent<UserInfoComponentC>().UserInfo.PiLao <= 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("体力已经消耗完毕，请确保体力充足喔!");
                self.Root().RemoveComponent<UnitGuaJiComponent>(); //移除体力组件
                return false;
            }

            self.UIMain.View.ES_MainSkill.ES_AttackGrid.PointerUp(null);

            self.forNum = 0;

            if (self.Root().GetComponent<LockTargetComponent>().LastLockId == 0)
            {
                //表示附近没有玩家,给服务器发送消息
                self.MoveStatus = true;
                self.MovePosition(1000).Coroutine(); //1秒后执行,防止普通攻击有冷却时间延迟
                return false;
            }
            else
            {
                //进入攻击状态
                self.FightStatus = true;
            }

            self.MoveStatus = false; //关闭自动移动状态
            return true;
        }

        public static void OnCreateUnit(this UnitGuaJiComponent self, Unit unit)
        {
            if (unit.Id != self.Root().GetComponent<LockTargetComponent>().LastLockId)
            {
                return;
            }

            MoveHelper.Stop(self.Root());
            self.Root().GetComponent<AttackComponent>().BeginAutoAttack(unit.Id);
        }

        public static async ETTask KillMonster(this UnitGuaJiComponent self)
        {
            self.Root().GetComponent<LockTargetComponent>().LastLockId = 0;
            self.FightStatus = false;

            //原地等待0.5秒拾取道具
            long instanceid = self.InstanceId;
            await self.Root().GetComponent<TimerComponent>().WaitAsync(500);
            if (instanceid != self.InstanceId)
            {
                return;
            }

            self.ShiQu();
            //执行下次攻击
            self.ActTarget();
        }

        public static bool ifBaseHpSkill(this UnitGuaJiComponent self, int useSkillID)
        {
            if (useSkillID == 60000001 || useSkillID == 60000002 || useSkillID == 60000003 || useSkillID == 60000004 || useSkillID == 60000005 ||
                useSkillID == 60000031 || useSkillID == 60000032 || useSkillID == 60000033 || useSkillID == 60000034 || useSkillID == 60000035 ||
                useSkillID == 65001001 || useSkillID == 65002001 || useSkillID == 65003001 || useSkillID == 65004001 || useSkillID == 60000035 ||
                useSkillID == 65005001 || useSkillID == 65006001)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool UseItem(this UnitGuaJiComponent self, int itemID)
        {
            BagComponentC bagCompont = self.Root().GetComponent<BagComponentC>();
            ItemInfo baginfo = bagCompont.GetBagInfo(itemID);
            if (baginfo != null)
            {
                BagClientNetHelper.RequestUseItem(self.Root(), baginfo).Coroutine();
                return true;
            }
            else
            {
                return false;
            }
        }

        //触发挂机持续执行间隔
        public static async ETTask TimeTriggerActTarget(this UnitGuaJiComponent self)
        {
            int goNum = 0;
            long instanceid = self.InstanceId;
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            for (self.forNum = 0; self.forNum < 100; self.forNum++)
            {
                //每10秒执行一次
                await timerComponent.WaitAsync(1000);
                if (instanceid != self.InstanceId)
                {
                    break;
                }

                goNum++;
                if (goNum >= 10)
                {
                    goNum = 0;
                    bool ifAct = self.ActTarget();
                    //如果当前没有攻击,就返回false
                    if (ifAct == false)
                    {
                        if (self.MoveStatus == false && self.Root().GetComponent<LockTargetComponent>().LastLockId == 0)
                        {
                            //如果当前不是移动状态,且目标ID为0
                            self.MovePosition().Coroutine();
                        }
                    }
                }

                //每秒使用一次技能
                self.UseSkill().Coroutine();
            }

            await ETTask.CompletedTask;
            return;
        }

        public static async ETTask MovePosition(this UnitGuaJiComponent self, int yanchiTime = 0)
        {
            //原地挂机不向服务器请求
            if (self.IfGuaJiRange)
            {
                return;
            }

            if (yanchiTime > 0)
            {
                await self.Root().GetComponent<TimerComponent>().WaitAsync(yanchiTime);
            }

            if (self.IsDisposed)
            {
                return;
            }

            M2C_FindNearMonsterResponse response = await SkillNetHelper.FindNearMonster(self.Root());

            if (self.IsDisposed)
            {
                return;
            }

            if (response.IfFindStatus)
            {
                self.Root().GetComponent<LockTargetComponent>().LastLockId = response.MonsterID;
                Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
                int ifSucc = await unit.MoveToAsync(new Vector3(response.x, response.y,
                    response.z));
                if (self.IsDisposed)
                {
                    return;
                }

                if (ifSucc == 0)
                {
                    self.ActTarget();
                }
            }
            else
            {
                FlyTipComponent.Instance.ShowFlyTip("附近未发现怪物");
            }
        }

        public static void ShiQu(this UnitGuaJiComponent self)
        {
            //点一下拾取按钮
            // self.UIMain.OnShiquItem(10f);

            //判断背包是否满了
            if (self.Root().GetComponent<BagComponentC>().GetBagLeftCell(ItemLocType.ItemLocBag) <= 0)
            {
                //如果满了就一键出售(此处看玩家是否勾选)
                if (self.IfSellStatus)
                {
                    //一键出售
                    BagClientNetHelper.RequestOneSell(self.Root(), ItemLocType.ItemLocBag).Coroutine();
                    FlyTipComponent.Instance.ShowFlyTip("背包已满，已自动一键出售道具!");
                }
            }
        }

        //使用技能
        public async static ETTask UseSkill(this UnitGuaJiComponent self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            float nowHp = unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.Now_Hp);
            float maxHp = unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.Now_MaxHp);
            if (self.IfGuaJiAutoUseItem)
            {
                if (nowHp / maxHp <= 0.3f) // 血量低于30%,俩个道具一起用
                {
                    //使用第8格
                    int useSkillID = self.UIMain.View.ES_MainSkill.UISkillGirdList_Normal[8].GetSkillId();
                    if (self.ifBaseHpSkill(useSkillID))
                    {
                        ES_SkillGrid uiSkillGridComponent = self.UIMain.View.ES_MainSkill.UISkillGirdList_Normal[8];
                        uiSkillGridComponent.OnPointDown(null);
                        uiSkillGridComponent.PointerUp(null);
                    }

                    //使用第9格
                    useSkillID = self.UIMain.View.ES_MainSkill.UISkillGirdList_Normal[9].GetSkillId();
                    if (self.ifBaseHpSkill(useSkillID))
                    {
                        ES_SkillGrid uiSkillGridComponent = self.UIMain.View.ES_MainSkill.UISkillGirdList_Normal[9];
                        uiSkillGridComponent.OnPointDown(null);
                        uiSkillGridComponent.PointerUp(null);
                    }
                }
                else if (nowHp / maxHp <= 0.6f) // 血量低于60%,使用第一个道具,如果道具用完，就用第二个
                {
                    bool ifUse = false;

                    //使用第8格
                    int useSkillID = self.UIMain.View.ES_MainSkill.UISkillGirdList_Normal[8].GetSkillId();
                    if (self.ifBaseHpSkill(useSkillID))
                    {
                        ES_SkillGrid uiSkillGridComponent = self.UIMain.View.ES_MainSkill.UISkillGirdList_Normal[8];
                        int itemId = uiSkillGridComponent.SkillPro?.SkillID ?? 0;
                        ItemInfo bagInfo = self.Root().GetComponent<BagComponentC>().GetBagInfo(itemId);
                        if (bagInfo != null)
                        {
                            uiSkillGridComponent.OnPointDown(null);
                            uiSkillGridComponent.PointerUp(null);
                            ifUse = true;
                        }
                    }

                    //使用第9格
                    useSkillID = self.UIMain.View.ES_MainSkill.UISkillGirdList_Normal[9].GetSkillId();
                    if (ifUse == false && self.ifBaseHpSkill(useSkillID))
                    {
                        ES_SkillGrid uiSkillGridComponent = self.UIMain.View.ES_MainSkill.UISkillGirdList_Normal[9];
                        uiSkillGridComponent.OnPointDown(null);
                        uiSkillGridComponent.PointerUp(null);
                    }
                }
            }

            if (self.FightStatus)
            {
                SkillManagerComponentC skillManagerComponent = unit.GetComponent<SkillManagerComponentC>();

                int grid = -1;
                int count = 0;
                int useSkillID = 0;
                while (count < self.skillXuHaoList.Count)
                {
                    grid = self.skillXuHaoList[self.XuHaoNum];
                    useSkillID = self.UIMain.View.ES_MainSkill.UISkillGirdList_Normal[grid].GetSkillId();
                    
                    bool canuse = true;
                    SkillConfig skillConfig = SkillConfigCategory.Instance.Get(useSkillID);
                    //如果为可打断技能 则判断当前是否存在该技能
                    if (SkillHelp.havePassiveSkillType(skillConfig.PassiveSkillType, 1) && skillManagerComponent.HaveSkillById(useSkillID))
                    {
                        canuse = false;
                    }

                    if (canuse && skillManagerComponent.CanUseSkill(0, useSkillID) == 0)
                    {
                        break;
                    }
                    
                    if (skillManagerComponent.CanUseSkill(0, useSkillID) == 0)
                    {
                        break;
                    }

                    self.XuHaoNum++;
                    if (self.XuHaoNum >= self.skillXuHaoList.Count)
                    {
                        self.XuHaoNum = 0;
                    }

                    useSkillID = 0;
                    count++;
                }

                if (useSkillID != 0)
                {
                    self.UIMain.View.ES_MainSkill.UISkillGirdList_Normal[grid].OnPointDown(null);
                    await self.Root().GetComponent<TimerComponent>().WaitAsync(100);
                    self.UIMain.View.ES_MainSkill.UISkillGirdList_Normal[grid].PointerUp(null);
                }

                self.XuHaoNum++;
                if (self.XuHaoNum >= self.skillXuHaoList.Count)
                {
                    self.XuHaoNum = 0;
                }
            }

            await ETTask.CompletedTask;
        }
    }
}
