using System;
using UnityEngine;

namespace ET.Client
{
    # region 注册事件

    [Event(SceneType.Demo)]
    public class UpdateUserDataExp_ShowFallingFont : AEvent<Scene, UpdateUserDataExp>
    {
        protected override async ETTask Run(Scene scene, UpdateUserDataExp args)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(scene);

            if (unit.IsDisposed)
            {
                return;
            }

            UIPlayerHpComponent heroHeadBarComponent = unit.GetComponent<UIPlayerHpComponent>();
            if (heroHeadBarComponent != null)
            {
                using (zstring.Block())
                {
                    scene.GetComponent<FallingFontComponent>()?.Play1(heroHeadBarComponent.GameObject, unit,
                        zstring.Format("经验+ {0}", args.ChangeValue), FallingFont1Type.Type_0, Vector3.one);
                }
            }

            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_TaskGet_ShowFallingFont : AEvent<Scene, TaskGet>
    {
        protected override async ETTask Run(Scene scene, TaskGet args)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(scene);

            if (unit.IsDisposed)
            {
                return;
            }

            UIPlayerHpComponent heroHeadBarComponent = unit.GetComponent<UIPlayerHpComponent>();
            if (heroHeadBarComponent != null && args.TaskConfigId != 0)
            {
                TaskConfig taskConfig = TaskConfigCategory.Instance.Get(args.TaskConfigId);
                using (zstring.Block())
                {
                    scene.GetComponent<FallingFontComponent>()?.Play1(heroHeadBarComponent.GameObject, unit,
                        zstring.Format("接取任务：{0}", taskConfig.TaskName), FallingFont1Type.Type_0, Vector3.one);
                }
            }

            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_TaskComplete_ShowFallingFont : AEvent<Scene, TaskComplete>
    {
        protected override async ETTask Run(Scene scene, TaskComplete args)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(scene);

            if (unit.IsDisposed)
            {
                return;
            }

            UIPlayerHpComponent heroHeadBarComponent = unit.GetComponent<UIPlayerHpComponent>();
            if (heroHeadBarComponent != null && args.TaskConfigId != 0)
            {
                TaskConfig taskConfig = TaskConfigCategory.Instance.Get(args.TaskConfigId);
                using (zstring.Block())
                {
                    scene.GetComponent<FallingFontComponent>()?.Play1(heroHeadBarComponent.GameObject, unit,
                        zstring.Format("完成任务：{0}", taskConfig.TaskName), FallingFont1Type.Type_0, Vector3.one);
                }
            }

            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class AddBuff_ShowFallingFont : AEvent<Scene, AddBuff>
    {
        protected override async ETTask Run(Scene scene, AddBuff args)
        {
            if (args.Unit.IsDisposed)
            {
                return;
            }

            SkillBuffConfig skillBuffConfig = SkillBuffConfigCategory.Instance.Get(args.BuffId);

            if (!SkillData.BuffFallingFont.ContainsKey(skillBuffConfig.buffParameterType))
            {
                return;
            }

            string showText = string.Empty;
            if (skillBuffConfig.buffParameterValue > 0)
            {
                showText = SkillData.BuffFallingFont[skillBuffConfig.buffParameterType].Item1;
            }
            else
            {
                showText = SkillData.BuffFallingFont[skillBuffConfig.buffParameterType].Item2;
            }

            if (showText == string.Empty)
            {
                return;
            }

            GameObject HpGameObject = null;
            switch (args.Unit.Type)
            {
                case UnitType.Player:
                    UIPlayerHpComponent heroHeadBarComponent = args.Unit.GetComponent<UIPlayerHpComponent>();
                    if (heroHeadBarComponent != null)
                    {
                        HpGameObject = heroHeadBarComponent.GameObject;
                    }

                    break;
                case UnitType.Monster:
                    UIMonsterHpComponent monsterHpComponent = args.Unit.GetComponent<UIMonsterHpComponent>();
                    if (monsterHpComponent != null)
                    {
                        HpGameObject = monsterHpComponent.GameObject;
                    }

                    break;
                case UnitType.Pet:
                    UIPetHpComponent petHpComponent = args.Unit.GetComponent<UIPetHpComponent>();
                    if (petHpComponent != null)
                    {
                        HpGameObject = petHpComponent.GameObject;
                    }

                    break;
                default:
                    return;
            }

            scene.GetComponent<FallingFontComponent>()?.Play1(HpGameObject, args.Unit, showText, FallingFont1Type.Type_1, Vector3.one);

            await ETTask.CompletedTask;
        }
    }

    # endregion

    [EntitySystemOf(typeof(FallingFontComponent))]
    [FriendOf(typeof(FallingFontComponent))]
    public static partial class FallingFontComponentSystem
    {
        [Invoke(TimerInvokeType.FallingFont)]
        public class FallingFont : ATimer<FallingFontComponent>
        {
            protected override void Run(FallingFontComponent self)
            {
                try
                {
                    self.OnUpdate();
                }
                catch (Exception e)
                {
                    Log.Error($"move timer error: {self.Id}\n{e}");
                }
            }
        }

        [EntitySystem]
        private static void Awake(this FallingFontComponent self)
        {
            self.OnAwake();
        }

        [EntitySystem]
        private static void Destroy(this FallingFontComponent self)
        {
            for (int i = self.FallingFontShows.Count - 1; i >= 0; i--)
            {
                FallingFontShowComponent fallingFontShowComponent = self.FallingFontShows[i];
                self.FallingFontShows.RemoveAt(i);
                fallingFontShowComponent.Dispose();
            }

            self.FallingFontShows = null;
            self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
        }

        public static void OnAwake(this FallingFontComponent self)
        {
            self.FallingFontShows = new();
        }

        private static (string, FallingFontType, Vector3) GetBattleShowText(this FallingFontComponent self, long targetValue, Unit unit, int type)
        {
            FallingFontType fallingFontType = FallingFontType.Target;
            string showText = string.Empty;

            //根据目标Unit设定飘字字体
            string selfNull = "";
            if (unit.MainHero)
            {
                fallingFontType = FallingFontType.Self;
                selfNull = " ";
            }

            //恢复血量
            if (type == 2 || type == 11 || type == 12 || targetValue > 0)
            {
                fallingFontType = FallingFontType.Add;
            }

            //恢复暴击/重击
            if (unit.MainHero == false && type == 1 || type == 3)
            {
                fallingFontType = FallingFontType.Special;
            }

            string addStr = "";

            Vector3 startScale = Vector3.one;

            if (targetValue >= 0 && type == 2)
            {
                addStr = "+";
            }

            if (type == 1)
            {
                addStr = "暴击";
                startScale = new Vector3(1.4f, 1.4f, 1.4f);
            }

            if (type != 2 && type != 11 && type != 12 && targetValue == 0)
            {
                showText = "闪避";
            }
            else if (type == 11)
            {
                showText = "抵抗";
            }
            else if (type == 12)
            {
                showText = "免疫";
            }
            else
            {
                showText = StringBuilderHelper.GetFallText(addStr + selfNull, targetValue);
            }

            return (showText, fallingFontType, startScale);
        }

        public static void Play(this FallingFontComponent self, GameObject HeadBar, Unit unit, long targetValue, int type)
        {
            FallingFontShowComponent fallingFont = self.AddChild<FallingFontShowComponent>();
            (string, FallingFontType, Vector3) showText = GetBattleShowText(self, targetValue, unit, type);
            fallingFont.OnInitData(HeadBar, unit, showText.Item1, showText.Item2, showText.Item3);
            self.FallingFontShows.Add(fallingFont);

            if (self.Timer == 0)
            {
                self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.FallingFont, self);
            }
        }

        public static void Play1(this FallingFontComponent self, GameObject HeadBar, Unit unit, string showText,
        FallingFont1Type fallingFont1Type, Vector3 startScale)
        {
            FallingFontShow1Component fallingFont = self.AddChild<FallingFontShow1Component>();
            fallingFont.OnInitData(HeadBar, unit, showText, fallingFont1Type, startScale);
            self.FallingFontShow1s.Add(fallingFont);

            if (self.Timer == 0)
            {
                self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.FallingFont, self);
            }
        }

        private static void OnUpdate(this FallingFontComponent self)
        {
            for (int i = self.FallingFontShows.Count - 1; i >= 0; i--)
            {
                FallingFontShowComponent fallingFontShowComponent = self.FallingFontShows[i];
                bool remove = fallingFontShowComponent.LateUpdate();
                if (remove)
                {
                    self.FallingFontShows.RemoveAt(i);
                    fallingFontShowComponent.Dispose();
                }
            }

            for (int i = self.FallingFontShow1s.Count - 1; i >= 0; i--)
            {
                FallingFontShow1Component fallingFontShow1Component = self.FallingFontShow1s[i];
                bool remove = fallingFontShow1Component.LateUpdate();
                if (remove)
                {
                    self.FallingFontShow1s.RemoveAt(i);
                    fallingFontShow1Component.Dispose();
                }
            }

            if (self.FallingFontShows.Count == 0 && self.FallingFontShow1s.Count == 0 && self.Timer != 0)
            {
                self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
            }
        }
    }
}