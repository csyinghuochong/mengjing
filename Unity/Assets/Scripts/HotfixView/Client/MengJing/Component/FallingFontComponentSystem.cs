using System;
using UnityEngine;

namespace ET.Client
{
    # region 注册事件

    [Event(SceneType.Demo)]
    public class GetDrop_ShowFallingFont : AEvent<Scene, GetDrop>
    {
        protected override async ETTask Run(Scene scene, GetDrop args)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(scene);

            if (unit.IsDisposed)
            {
                return;
            }

            UIPlayerHpComponent heroHeadBarComponent = unit.GetComponent<UIPlayerHpComponent>();
            if (heroHeadBarComponent != null)
            {
                // 获取掉落物品、金币
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(args.ItemId);
                using (zstring.Block())
                {
                    scene.GetComponent<FallingFontComponent>()?.Play(heroHeadBarComponent.GameObject, unit,
                        zstring.Format("{0}x{1}", itemConfig.ItemName, args.ItemNum), FallingFontType.Drop_Item, Vector3.one, BloodTextLayer.Layer_1,
                        FallingFontExecuteType.Type_1, true);
                }
            }

            await ETTask.CompletedTask;
        }
    }

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
                    // 获得经验
                    scene.GetComponent<FallingFontComponent>()?.Play(heroHeadBarComponent.GameObject, unit,
                        zstring.Format("经验+ {0}", args.ChangeValue), FallingFontType.Drop_Exp, Vector3.one, BloodTextLayer.Layer_1,
                        FallingFontExecuteType.Type_1);
                }
            }

            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class UpdateUserDataLv_ShowFallingFont : AEvent<Scene, UpdateUserDataLv>
    {
        protected override async ETTask Run(Scene scene, UpdateUserDataLv args)
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
                    scene.GetComponent<FallingFontComponent>()?.Play(heroHeadBarComponent.GameObject, unit,
                        zstring.Format("升到{0}级", args.UpdateValue), FallingFontType.UpLv, Vector3.one, BloodTextLayer.Layer_1,
                        FallingFontExecuteType.Type_2);
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
                    scene.GetComponent<FallingFontComponent>()?.Play(heroHeadBarComponent.GameObject, unit,
                        zstring.Format("接取任务：{0}", taskConfig.TaskName), FallingFontType.TaskGet, Vector3.one, BloodTextLayer.Layer_1,
                        FallingFontExecuteType.Type_3);
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
                    scene.GetComponent<FallingFontComponent>()?.Play(heroHeadBarComponent.GameObject, unit,
                        zstring.Format("完成任务：{0}", taskConfig.TaskName), FallingFontType.TaskComplete, Vector3.one, BloodTextLayer.Layer_1,
                        FallingFontExecuteType.Type_2);
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

            // buff
            scene.GetComponent<FallingFontComponent>()?.Play(HpGameObject, args.Unit, showText, FallingFontType.BuffAdd, Vector3.one,
                BloodTextLayer.Layer_0, FallingFontExecuteType.Type_0);

            await ETTask.CompletedTask;
        }
    }

    # endregion

    [EntitySystemOf(typeof(FallingFontComponent))]
    [FriendOf(typeof(FallingFontComponent))]
    public static partial class FallingFontComponentSystem
    {
        [Invoke(TimerInvokeType.FallingFont)]
        public class FallingFontTimer : ATimer<FallingFontComponent>
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
                fallingFontShowComponent?.Dispose();
            }

            self.FallingFontShows = null;
            self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
        }

        private static void OnAwake(this FallingFontComponent self)
        {
            self.FallingFontShows = new();
        }

        /// <summary>
        /// 播放飘字
        /// </summary>
        /// <param name="self"></param>
        /// <param name="HeadBar"></param>
        /// <param name="unit"></param>
        /// <param name="showText">内容</param>
        /// <param name="fontType">字体类型</param>
        /// <param name="startScale">开始的大小</param>
        /// <param name="bloodTextLayer">层级</param>
        /// <param name="fallingFontExecuteType">执行逻辑</param>
        /// <param name="addQueue">依次出现</param>
        public static void Play(this FallingFontComponent self, GameObject HeadBar, Unit unit, string showText, FallingFontType fontType,
        Vector3 startScale, BloodTextLayer bloodTextLayer, FallingFontExecuteType fallingFontExecuteType, bool addQueue = false)
        {
            if (addQueue)
            {
                self.FallingFontQueue.Enqueue(new FallingFont()
                {
                    HeadBar = HeadBar,
                    Unit = unit,
                    ShowText = showText,
                    FallingFontType = fontType,
                    StartScale = startScale,
                    BloodTextLayer = bloodTextLayer,
                    FallingFontExecuteType = fallingFontExecuteType
                });
            }
            else
            {
                FallingFontShowComponent fallingFont = self.AddChild<FallingFontShowComponent>();
                fallingFont.OnInitData(HeadBar, unit, showText, fontType, startScale, bloodTextLayer, fallingFontExecuteType);
                self.FallingFontShows.Add(fallingFont);
            }

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

            long time = TimeInfo.Instance.ClientNow();

            if (self.FallingFontQueue.Count > 0)
            {
                if (time - self.LastTime >= self.Interval)
                {
                    self.LastTime = time;
                    FallingFont fallingFont = self.FallingFontQueue.Dequeue();
                    self.Play(fallingFont.HeadBar, fallingFont.Unit, fallingFont.ShowText, fallingFont.FallingFontType, fallingFont.StartScale,
                        fallingFont.BloodTextLayer, fallingFont.FallingFontExecuteType);
                }
            }

            if (self.FallingFontShows.Count == 0 && self.FallingFontQueue.Count == 0 && self.Timer != 0)
            {
                self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
            }
        }
    }
}