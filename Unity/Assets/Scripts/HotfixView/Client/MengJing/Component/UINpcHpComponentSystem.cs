using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(UINpcHpComponent))]
    [EntitySystemOf(typeof(UINpcHpComponent))]
    public static partial class UINpcHpComponentSystem
    {
        
        [Invoke(TimerInvokeType.TurtleSpeak)]
        public class BuffTimer : ATimer<UINpcHpComponent>
        {
            protected override void Run(UINpcHpComponent self)
            {
                try
                {
                    self.OnTurtleSpeakFinish();
                }
                catch (Exception e)
                {
                    Log.Error($"move timer error: {self.Id}\n{e}");
                }
            }
        }
        
        [EntitySystem]
        private static void Awake(this UINpcHpComponent self)
        {
            self.HeadBarUI = null;
            self.MainUnitEnter = false;
            self.MainUnitExit = false;
            self.EnterPassTime = 0;
            self.EffectComTask[0] = null;
            self.EffectComTask[1] = null;
            self.Unit = null;

            self.Unit = self.GetParent<Unit>();
            self.NpcId = self.Unit.ConfigId;

            long instanceid = self.InstanceId;
            GameObject bundleObject = self.Root().GetComponent<ResourcesLoaderComponent>()
                    .LoadAssetSync<GameObject>(ABPathHelper.GetUGUIPath("Blood/UINpcHp"));
            if (instanceid != self.InstanceId)
            {
                return;
            }

            self.UINpcName = UnityEngine.Object.Instantiate(bundleObject);
            self.UINpcName.transform.SetParent(self.Root().GetComponent<GlobalComponent>().BloodMonster.transform);
            self.UINpcName.transform.localScale = Vector3.one;

            if (self.UINpcName.GetComponent<HeadBarUI>() == null)
            {
                self.UINpcName.AddComponent<HeadBarUI>();
            }

            self.HeadBarUI = self.UINpcName.GetComponent<HeadBarUI>();
            self.HeadBarUI.HeadPos = self.Unit.GetComponent<HeroTransformComponent>().GetTranform(PosType.Head);
            self.HeadBarUI.HeadBar = self.UINpcName;

            NpcConfig npcConfig = NpcConfigCategory.Instance.Get(self.NpcId);
            self.UINpcName.transform.Find("Lab_NpcName").GetComponent<Text>().text = npcConfig.Name;

            // 乌龟说话
            if (ConfigData.TurtleList.Contains(self.NpcId))
            {
                self.WuGuiSay().Coroutine();
            }
        }

        [EntitySystem]
        private static void Destroy(this UINpcHpComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.TurtleTimer);

            if (self.UINpcName != null)
            {
                UnityEngine.Object.Destroy(self.UINpcName);
                self.UINpcName = null;
            }

            if (self.EffectComTask[0] != null)
            {
                UnityEngine.Object.Destroy(self.EffectComTask[0]);
            }

            if (self.EffectComTask[1] != null)
            {
                UnityEngine.Object.Destroy(self.EffectComTask[1]);
            }

            self.EffectComTask[0] = null;
            self.EffectComTask[1] = null;
        }

        public static void UpdateRewardName(this UINpcHpComponent self, List<string> names)
        {
            if (names.Count == 0 || self.UINpcName == null)
            {
                return;
            }

            string name = string.Empty;
            for (int i = 0; i < names.Count; i++)
            {
                name += $"{names[i]}、";
            }

            self.UINpcName.transform.Find("NpcHeadSpeakSet").gameObject.SetActive(true);
            using (zstring.Block())
            {
                self.UINpcName.transform.Find("NpcHeadSpeakSet/Lab_HeadSpeak").GetComponent<Text>().text = zstring.Format("东西给你!{0} 不要追着我啦！", name);
            }

            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            timerComponent.Remove(ref self.TurtleTimer);
            self.TurtleTimer = timerComponent.NewOnceTimer(TimeHelper.ServerNow() + TimeHelper.Second * 5, TimerInvokeType.TurtleSpeak, self);
        }

        /// <summary>
        /// 每次讲话5秒后消失。 
        /// </summary>
        /// <param name="self"></param>
        public static void UpdateTurtleAI(this UINpcHpComponent self)
        {
            if (self.Unit == null || self.Unit.IsDisposed)
            {
                return;
            }

            int Now_TurtleAI = self.Unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.Now_TurtleAI);
            //(Now_TurtleAI == 1) //移动 2移动 3终点
            if (Now_TurtleAI == 3)
            {
                FunctionEffect.PlaySelfEffect(self.Unit, 30000003); //小龟到达终点播放特效
                return;
            }

            List<string> speaklist = null;
            ConfigData.TurtleSpeakList.TryGetValue(Now_TurtleAI, out speaklist);
            if (speaklist == null || speaklist.Count == 0)
            {
                return;
            }

            string speakcontent = speaklist[RandomHelper.RandomNumber(0, speaklist.Count)];
            self.UINpcName.transform.Find("NpcHeadSpeakSet").gameObject.SetActive(true);
            self.UINpcName.transform.Find("NpcHeadSpeakSet/Lab_HeadSpeak").GetComponent<Text>().text = speakcontent;

            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            timerComponent.Remove(ref self.TurtleTimer);
            self.TurtleTimer = timerComponent.NewOnceTimer(TimeHelper.ServerNow() + TimeHelper.Second * 5, TimerInvokeType.TurtleSpeak, self);
        }

        public static void OnTurtleSpeakFinish(this UINpcHpComponent self)
        {
            self.UINpcName.transform.Find("NpcHeadSpeakSet").gameObject.SetActive(false);
        }

        public static async ETTask WuGuiSay(this UINpcHpComponent self)
        {
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            while (!self.IsDisposed)
            {
                self.UpdateTurtleAI();
                await timerComponent.WaitAsync(30 * TimeHelper.Second);
                if (self.IsDisposed)
                {
                    break;
                }
            }
        }

        public static void OnUpdateNpcTalk(this UINpcHpComponent self, Unit mainUnit)
        {
            float distance = PositionHelper.Distance2D(mainUnit.Position, self.Unit.Position);
            if (distance < 10f && !self.MainUnitEnter)
            {
                self.MainUnitEnter = true;
                self.MainUnitExit = false;
                self.OnRecvTaskUpdate();
                NpcConfig npcConfig = NpcConfigCategory.Instance.Get(self.NpcId);
                self.UINpcName.transform.Find("NpcHeadSpeakSet").gameObject.SetActive(true);
                self.UINpcName.transform.Find("NpcHeadSpeakSet/Lab_HeadSpeak").GetComponent<Text>().text = npcConfig.SpeakText;
            }

            if (distance > 10f && !self.MainUnitExit)
            {
                self.MainUnitEnter = false;
                self.MainUnitExit = true;
                self.EnterPassTime = 0f;
                self.UINpcName.transform.Find("NpcHeadSpeakSet").gameObject.SetActive(false);
            }

            if (self.MainUnitEnter)
            {
                self.EnterPassTime += Time.deltaTime;
            }

            if (self.MainUnitEnter && self.EnterPassTime >= 10f)
            {
                self.UINpcName.transform.Find("NpcHeadSpeakSet").gameObject.SetActive(false);
            }
        }

        public static void OnRecvTaskUpdate(this UINpcHpComponent self)
        {
            TaskComponentC taskComponent = self.Root().GetComponent<TaskComponentC>();
            List<TaskPro> taskProCompleted = taskComponent.GetCompltedTaskByNpc(self.NpcId);
            List<int> canGets = taskComponent.GetOpenTaskIds(self.NpcId);
            canGets.AddRange(self.GetAddtionTaskId(self.NpcId));

            self.ShowNpcEffect(0, 200001, canGets.Count > 0 && taskProCompleted.Count == 0);
            self.ShowNpcEffect(1, 200002, taskProCompleted.Count > 0);
        }

        public static List<int> GetAddtionTaskId(this UINpcHpComponent self, int npcId)
        {
            List<int> addTaskids = new List<int>();
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            TaskComponentC taskComponent = self.Root().GetComponent<TaskComponentC>();
            if (npcId == 20000102) //公会任务
            {
                int unionTaskId = numericComponent.GetAsInt(NumericType.UnionTaskId);
                if (unionTaskId > 0 && taskComponent.GetTaskById(unionTaskId) == null)
                {
                    addTaskids.Add(unionTaskId);
                }
            }

            return addTaskids;
        }

        public static void EnterHide(this UINpcHpComponent self)
        {
            if (self.UINpcName == null)
            {
                return;
            }

            self.UINpcName.gameObject.SetActive(false);
        }

        public static void ExitHide(this UINpcHpComponent self)
        {
            if (self.UINpcName == null)
            {
                return;
            }

            self.UINpcName.gameObject.SetActive(true);
        }
        
        public static void ShowNpcEffect(this UINpcHpComponent self, int type, int effectConfigId, bool show)
        {
            GameObject go = self.EffectComTask[type];
            if (show)
            {
                if (go == null)
                {
                    EffectConfig effectConfig = EffectConfigCategory.Instance.Get(effectConfigId);
                    Transform tParent = self.GetParent<Unit>().GetComponent<HeroTransformComponent>().GetTranform(effectConfig.SkillParentPosition);

                    string path = StringBuilderHelper.GetEffectPathByConfig(effectConfig);
                    GameObject prefab = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    go = UnityEngine.Object.Instantiate(prefab, tParent, true);

                    go.transform.localPosition = new Vector3(0f, 0f, 0f);
                    self.EffectComTask[type] = go;
                }

                go.SetActive(true);
            }
            else
            {
                if (go != null)
                {
                    go.SetActive(false);
                }
            }
        }
    }
}