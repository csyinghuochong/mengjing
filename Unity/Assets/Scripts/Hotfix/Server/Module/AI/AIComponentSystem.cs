using System;
using System.Collections.Generic;
using ET.Server;
using Unity.Mathematics;

namespace ET
{
    [EntitySystemOf(typeof(AIComponent))]
    [FriendOf(typeof(AIComponent))]
    [FriendOf(typeof(AIDispatcherComponent))]
    public static partial class AIComponentSystem
    {
        [Invoke(TimerInvokeType.AITimer)]
        public class AITimer : ATimer<AIComponent>
        {
            protected override void Run(AIComponent self)
            {
                try
                {
                    self.Check();
                }
                catch (Exception e)
                {
                    Log.Error($"move timer error: {self.Id}\n{e}");
                }
            }
        }

        [EntitySystem]
        private static void Awake(this AIComponent self, int aiConfigId)
        {
            self.AIConfigId = aiConfigId;
            self.IsRetreat = false;
            self.PatrolRange = 0f;
            self.AISkillIDList.Clear();
            self.TargetPoint.Clear();
            self.TargetZhuiJi = float3.zero;
            self.SceneType = self.Scene().GetComponent<MapComponent>().MapType;
        }

        [EntitySystem]
        private static void Destroy(this AIComponent self)
        {
            self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
            self.CancellationToken?.Cancel();
            self.CancellationToken = null;
            self.Current = 0;
        }

        private static void Check(this AIComponent self)
        {
            Fiber fiber = self.Fiber();
            if (self.Parent == null)
            {
                fiber.Root.GetComponent<TimerComponent>().Remove(ref self.Timer);
                return;
            }
            
            if ( self.AIDelay >= 0)
            {
                self.AIDelay -= 500;
                return;
            }

            var oneAI = AIConfigCategory.Instance.AIConfigs[self.AIConfigId];

            foreach (AIConfig aiConfig in oneAI.Values)
            {
                AAIHandler aaiHandler = AIDispatcherComponent.Instance.Get(aiConfig.Name);

                if (aaiHandler == null)
                {
                    Log.Error($"not found aihandler: {aiConfig.Name}");
                    continue;
                }

                int ret = aaiHandler.Check(self, aiConfig);
                if (ret != 0)
                {
                    continue;
                }

                if (self.Current == aiConfig.Id)
                {
                    break;
                }

                self.Cancel(); // 取消之前的行为
                ETCancellationToken cancellationToken = new();
                self.CancellationToken = cancellationToken;
                self.Current = aiConfig.Id;

                aaiHandler.Execute(self, aiConfig, cancellationToken).Coroutine();
                return;
            }
        }

        public static void ChangeTarget(this AIComponent self, long targetId)
        {
            if (!self.IsRetreat)
            {
                self.TargetID = targetId;
            }
        }

        private static void Cancel(this AIComponent self)
        {
            self.CancellationToken?.Cancel();
            self.Current = 0;
            self.CancellationToken = null;
        }

        //初始化
        public static void InitMonster(this AIComponent self, int monsteConfigId)
        {
            MonsterConfig MonsterCof = MonsterConfigCategory.Instance.Get(monsteConfigId);
            //初始化AI组件的一些东西
            self.ActRange = (float)MonsterCof.ActRange +
                    self.GetParent<Unit>().GetComponent<NumericComponentS>().GetAsInt(NumericType.Now_MonsterDis); //5-10  与主角距离小于此值时,向主角发动追击
            self.ChaseRange = (float)MonsterCof.ChaseRange; //超出会返回到出生点
            self.ActDistance = (float)MonsterCof.ActDistance; //2    小于转攻击
            self.PatrolRange = (float)MonsterCof.PatrolRange;
            self.AIDelay = MonsterCof.AIDelay;
            self.AISkillIDList.Add(MonsterCof.ActSkillID);
            self.TargetPoint.Clear();
            self.InitTargetPoints(MonsterCof.AIParameter);
        }
        
        public static void InitPetMeleeMonster(this AIComponent self, int monsteConfigId)
        {
            MonsterConfig MonsterCof = MonsterConfigCategory.Instance.Get(monsteConfigId);
            //初始化AI组件的一些东西
            self.ActRange = (float)MonsterCof.ActDistance; // 在攻击范围内追击
            self.ChaseRange = (float)MonsterCof.ChaseRange; //超出会返回到出生点
            self.ActDistance = (float)MonsterCof.ActDistance; //2    小于转攻击
            self.PatrolRange = (float)MonsterCof.PatrolRange;
            self.AIDelay = MonsterCof.AIDelay;
            self.AISkillIDList.Add(MonsterCof.ActSkillID);
            self.TargetPoint.Clear();
            self.InitTargetPoints(MonsterCof.AIParameter);
        }

        public static void InitTargetPoints(this AIComponent self, string aIParameter)
        {
            if (aIParameter == null || aIParameter.Length == 0)
            {
                return;
            }

            try
            {
                string[] targetpoints = aIParameter.Split('@');
                for (int i = 0; i < targetpoints.Length; i++)
                {
                    string[] potioninfo = targetpoints[i].Split(';');
                    float x = float.Parse(potioninfo[0]);
                    float y = float.Parse(potioninfo[1]);
                    float z = float.Parse(potioninfo[2]);
                    self.TargetPoint.Add(new float3(x, y, z));
                }
            }
            catch (Exception ex)
            {
                Log.Debug(ex.ToString());
            }
        }

        public static void InitTempFollower(this AIComponent self, int monsteConfigId)
        {
            MonsterConfig MonsterCof = MonsterConfigCategory.Instance.Get(monsteConfigId);
            //初始化AI组件的一些东西
            self.ActRange = (float)MonsterCof.ActRange; //5-10  与主角距离小于此值时,向主角发动追击
            self.ChaseRange = (float)MonsterCof.ChaseRange; //超出会返回到出生点
            self.ActDistance = (float)MonsterCof.ActDistance; //2    小于转攻击
            self.AISkillIDList.Add(MonsterCof.ActSkillID);
        }

        /// <summary>
        /// 初始化宠物副本宠物AI参数
        /// </summary>
        /// <param name="self"></param>
        /// <param name="petConfigId"></param>
        public static void InitTianTiPet(this AIComponent self, int petConfigId)
        {
            PetConfig petConfig = PetConfigCategory.Instance.Get(petConfigId);
            self.ChaseRange = 100;
            self.ActRange = 100;
            self.ActDistance = (float)petConfig.ActDistance;

            self.ActDistance += self.ActDistance * 0.5f;

            self.AISkillIDList.Add(petConfig.ActSkillID);
        }
        
        /// <summary>
        /// 初始化宠物副本怪物AI参数
        /// </summary>
        /// <param name="self"></param>
        /// <param name="monsteConfigId"></param>
        public static void InitPetFubenMonster(this AIComponent self, int monsteConfigId)
        {
            MonsterConfig MonsterCof = MonsterConfigCategory.Instance.Get(monsteConfigId);
            //初始化AI组件的一些东西
            self.ActRange = 100; //5-10  与主角距离小于此值时,向主角发动追击
            self.ChaseRange = 100; //超出会返回到出生点
            self.ActDistance = (float)MonsterCof.ActDistance; //2    小于转攻击

            self.ActDistance += 1f;

            self.AISkillIDList.Add(MonsterCof.ActSkillID);
        }

        public static void InitNpc(this AIComponent self, int npcid)
        {
            NpcConfig MonsterCof = NpcConfigCategory.Instance.Get(npcid);
            self.InitTargetPoints(MonsterCof.MovePosition);
        }

        public static void InitPasture(this AIComponent self)
        {
        }

        public static void InitJingLing(this AIComponent self, int jinglingid)
        {
            self.ChaseRange = 100;
            self.ActRange = 5;
            self.AISkillIDList.Add(66001012);
            self.ActDistance = 6;
        }

        public static void InitJiaYuanPet(this AIComponent self)
        {
        }

        /// <summary>
        /// 相关数据也可以传入Unit. 从Unit获取
        /// </summary>
        /// <param name="self"></param>
        /// <param name="petConfigId"></param>
        /// 
        public static void InitPet(this AIComponent self, RolePetInfo rolePetInfo)
        {
            PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);
            self.ChaseRange = 100;
            self.ActRange = petConfig.ChaseRange;

            int haveMagic = 0;
            for (int i = 0; i < rolePetInfo.PetSkill.Count; i++)
            {
                if (CommonHelp.PetMagicSkill().Contains(rolePetInfo.PetSkill[i]))
                {
                    haveMagic = rolePetInfo.PetSkill[i];
                    break;
                }
            }

            if (haveMagic > 0)
            {
                self.AISkillIDList.Add(haveMagic);
                self.ActDistance = 6;
            }
            else
            {
                self.AISkillIDList.Add(petConfig.ActSkillID);
                self.ActDistance = (float)petConfig.ActDistance;
            }
        }

        public static bool HaveSkillId(this AIComponent self, int skillId)
        {
            return self.AISkillIDList.Contains(skillId);
        }

        public static int GetActSkillId(this AIComponent self)
        {
            return self.AISkillIDList[RandomHelper.RandomNumber(0, self.AISkillIDList.Count)];
        }

        public static void BeAttacking(this AIComponent self, Unit attack)
        {
            Unit main = self.GetParent<Unit>();
            if (!main.IsCanAttackUnit(attack))
            {
                return;
            }
            
            //0.1的概率概率转移仇恨
            float moveActPro = 0.1f;
            moveActPro = moveActPro * (1 + attack.GetComponent<NumericComponentS>().GetAsFloat(NumericType.Now_ChaoFengPro));
            if (moveActPro <= 0 && self.TargetID > 0)
            {
                return;
            }
            
            long serverTime = TimeHelper.ServerNow();
            if (serverTime - self.LastChangeTime < 6000)
            {
                return;
            }

            self.LastChangeTime = serverTime;
            if (main.Type == UnitType.Pet)
            {
                bool gaiLv = RandomHelper.RandFloat01() < 0.1f;
                if (self.TargetID != 0 && gaiLv)
                {
                    self.ChangeTarget(attack.Id);
                }

                if (self.TargetID == 0)
                {
                    self.ChangeTarget(attack.Id);
                }
            }
            else
            {
                //怪物
                //1.首先攻击默认攻击他的目标。
                //2.攻击时有概率转换自己为攻击目标（近战攻击10 %，远程攻击5 %）。
                //3.如果转换攻击目标，6秒内不在转换攻击目标
                float gaiLv = RandomHelper.RandFloat01();
                if (self.TargetID != 0 && self.ActDistance <= 4 && gaiLv <= 0.1f)
                {
                    self.ChangeTarget(attack.Id);
                }

                if (self.TargetID != 0 && self.ActDistance > 4 && gaiLv <= 0.05f)
                {
                    self.ChangeTarget(attack.Id);
                }

                if (self.TargetID == 0)
                {
                    self.ChangeTarget(attack.Id);
                }
            }
        }

        public static void Begin(this AIComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            NumericComponentS numericComponent = self.GetParent<Unit>().GetComponent<NumericComponentS>();
            if (numericComponent.GetAsInt(NumericType.Now_Dead) != 0)
            {
                return;
            }

            self.AIDelay -= 500;
            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(500, TimerInvokeType.AITimer, self);
        }

        public static void Stop(this AIComponent self)
        {
            self.TargetID = 0;
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static void Stop_2(this AIComponent self)
        {
            self.Cancel();
            self.Current = -1;
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static float GetActRange(this AIComponent self)
        {
            return self.ActRange;
        }
    }
}