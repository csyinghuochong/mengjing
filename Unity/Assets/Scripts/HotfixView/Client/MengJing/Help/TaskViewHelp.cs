using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ET.Client
{
    public static class TaskViewHelp
    {
        public static void OnGoToNpc(Scene scene, int npc)
        {
            MapComponent mapComponent = scene.GetComponent<MapComponent>();
            if (mapComponent.MapType != MapTypeEnum.MainCityScene)
            {
                FlyTipComponent.Instance.ShowFlyTip("请前往主城!");
                return;
            }

            scene.CurrentScene().GetComponent<OperaComponent>().OnClickNpc(npc).Coroutine();
        }

        public delegate bool TaskExcuteDelegate(Scene scene, TaskPro taskPro, TaskConfig taskConfig);

        public delegate string TaskDescDelegate(TaskPro taskPro, TaskConfig taskConfig);

        public struct TaskLogic
        {
            public TaskExcuteDelegate taskExcute;
            public TaskDescDelegate taskProgess;
        }

        public static TaskLogic GetTaskLogic(int targetType)
        {
            switch (targetType)
            {
                case TaskTargetType.KillMonsterID_1:
                    return new TaskLogic() { taskExcute = ExcuteKillMonsterID, taskProgess = GetDescKillMonsterID };
                case TaskTargetType.ItemID_Number_2:
                    return new TaskLogic() { taskExcute = ExcuteItemId, taskProgess = GetDescItemId };
                case TaskTargetType.LookingFor_3:
                    return new TaskLogic() { taskExcute = ExcuteLookingFor, taskProgess = GetDescLookingFor };
                case TaskTargetType.PlayerLv_4:
                    return new TaskLogic() { taskExcute = ExcutePlayerLv, taskProgess = GetDescPlayerLv };
                case TaskTargetType.KillMonster_5:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = GetDescKillMonster };
                case TaskTargetType.KillBOSS_6:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = GetDescKillBOSS };
                case TaskTargetType.PassFubenID_7:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = GetDescPassFubenID };
                case TaskTargetType.ChangeOcc_8:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = GetChangeOcc };
                case TaskTargetType.JoinUnion_9:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = GetJoinUnion };
                case TaskTargetType.GiveItem_10:
                    return new TaskLogic() { taskExcute = ExcuteGiveItem_10, taskProgess = GetGiveItem };
                case TaskTargetType.PetNumber1_11:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = PetNumber1_11 };
                case TaskTargetType.MakeNumber_12:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = MakeNumber_12 };
                case TaskTargetType.EquipXiLian_13:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = EquipXiLian_13 };
                case TaskTargetType.PetTianTiNumber_14:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = PetTianTiNumber_14 };
                case TaskTargetType.DuiHuanGold_15:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = DuiHuanGold_15 };
                case TaskTargetType.EquipHuiShou_16:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = EquipHuiShou_16 };
                case TaskTargetType.QiangHuaLevel_17:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = QiangHuaLevel_17 };
                case TaskTargetType.PetNSkill_18:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = PetNSkill_18 };
                case TaskTargetType.PetFubenId_19:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = PetFubenId_19 };
                case TaskTargetType.TotalCostGold_20:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = TotalCostGold_20 };
                case TaskTargetType.KillPlayer_21:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = KillPlayer_21 };
                case TaskTargetType.JiaYuanLevel_22:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = JiaYuanLevel_22 };
                case TaskTargetType.PetHeCheng_23:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = PetHeCheng_23 };
                case TaskTargetType.PetNumber2_24:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = PetNumber2_24 };
                case TaskTargetType.GivePet_25:
                    return new TaskLogic() { taskExcute = ExcuteGivePet_25, taskProgess = GivePet_25 };
                case TaskTargetType.TreasureMapNormal_26:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = TreasureMapNormal_26 };
                case TaskTargetType.TreasureMapHigh_27:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = TreasureMapHigh_27 };
                case TaskTargetType.TowerOfSeal_28:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = TowerOfSeal_28 };
                case TaskTargetType.MakeQulityNumber_29:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = MakeQulityNumber_29 };
                case TaskTargetType.BattleUseItem_30:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = BattleUseItem_30 };
                case TaskTargetType.PetNumber_31:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = PetNumber_31 };
                case TaskTargetType.PetHeChengCombat_32:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = PetHeChengCombat_32 };
                case TaskTargetType.PetXiLian10010086_33:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = PetXiLian10010086_33 };
                case TaskTargetType.PetFuHuaNumber_34:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = PetFuHuaNumber_34 };
                case TaskTargetType.PetFuHuaId_35:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = PetFuHuaId_35 };
                case TaskTargetType.PetUseSkillBook_36:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = PetUseSkillBook_36 };
                case TaskTargetType.PetTianDiWin_37:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = PetTianDiWin_37 };
                case TaskTargetType.FuMoQulity_41:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = FuMoQulity_41 };
                case TaskTargetType.JianDingQulity_42:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = JianDingQulity_42 };
                case TaskTargetType.JianDingAttrNumber_43:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = JianDingAttrNumber_43 };
                case TaskTargetType.XiLianSkillNumber_44:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = XiLianSkillNumber_44 };
                case TaskTargetType.XiLianAttriId_45:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = XiLianAttriId_45 };
                case TaskTargetType.IncreaseNumber_46:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = IncreaseNumber_46 };
                case TaskTargetType.TrialRank_81:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = TrialRank_81 };
                case TaskTargetType.PetTianTiRank_82:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = PetTianTiRank_82 };
                case TaskTargetType.CombatRank_83:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = CombatRank_83 };
                case TaskTargetType.JiaYuanCookNumber_91:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = JiaYuanCookNumber_91 };
                case TaskTargetType.JiaYuanPlantNumber_92:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = JiaYuanPlantNumber_92 };
                case TaskTargetType.JiaYuanGatherPlant_93:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = JiaYuanGatherPlant_93 };
                case TaskTargetType.JiaYuanPastureNumber_94:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = JiaYuanPastureNumber_94 };
                case TaskTargetType.JiaYuanGatherPasture_95:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = JiaYuanGatherPasture_95 };
                case TaskTargetType.JiaYuanDashiNumber_96:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = JiaYuanDashiNumber_96 };
                case TaskTargetType.KillTiaoZhanMonsterID_101:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = GetDescKillChallengeMonsterID };
                case TaskTargetType.KillDiYuMonsterID_102:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = GetDescKillInfernalMonsterID };
                case TaskTargetType.PassTianZhanFubenID_111:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = GetDescPassChallengeFubenID };
                case TaskTargetType.PassDiYuFubenID_112:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = GetDescPassInfernalFubenID };
                case TaskTargetType.KillTianZhanMonsterNumber_121:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = GetDescKillChallengeMonsterNumber };
                case TaskTargetType.KillDiYuMonsterNumber_122:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = GetDescKillInfernalMonsterNumber };
                case TaskTargetType.KillTianZhanBossNumber_131:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = GetDescKillChallengeBossNumber };
                case TaskTargetType.KillDiYuBossNumber_132:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = GetDescKillInfernalBossNumber };
                case TaskTargetType.CombatToValue_133:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = GetDescCombatToValue };
                case TaskTargetType.TrialTowerCeng_134:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = GetTrialTowerCeng };
                case TaskTargetType.ShenYuanNumber_135:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = ShenYuanNumber_135 };
                case TaskTargetType.TeamDungeonHurt_136:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = TeamDungeonHurt_136 };
                case TaskTargetType.MineHaveNumber_401:
                    return new TaskLogic() { taskExcute = ExcuteDoNothing, taskProgess = MineHaveNumber_401 };
            }

            return default;
        }

        public static bool ExcuteTask(Scene root, TaskPro taskPro)
        {
            int curdungeonid = root.GetComponent<MapComponent>().SceneId;
            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskPro.taskID);
            int target = taskConfig.TargetType;
            int npcid = taskConfig.CompleteNpcID;
            string fubenname = "副本";
            FlyTipComponent flyTipComponent = root.GetComponent<FlyTipComponent>();
            if (taskPro.taskStatus == (int)TaskStatuEnum.Completed)
            {
                if ((taskConfig.TaskType == TaskTypeEnum.Ring || taskConfig.TaskType == TaskTypeEnum.Union ||
                        taskConfig.TaskType == TaskTypeEnum.System || taskConfig.TaskType == TaskTypeEnum.Daily ||
                        taskConfig.TaskType == TaskTypeEnum.Treasure || ConfigData.TaskCompleteDirectly.Contains(taskPro.taskID))
                    && taskConfig.TargetType != TaskTargetType.GiveItem_10
                    && taskConfig.TargetType != TaskTargetType.GivePet_25)
                {
                    TaskClientNetHelper.RequestCommitTask(root, taskPro.taskID, 0).Coroutine();
                    return true;
                }

                if (!TaskHelper.HaveNpc(root, npcid))
                {
                    int fubenId = GetFubenByNpc(npcid);

                    if (fubenId >= 0 && fubenId != curdungeonid)
                    {
                        if (GeToOtherFuben(root, fubenId, curdungeonid))
                        {
                            return true;
                        }
                    }

                    //再查找其他scene
                    if (fubenId == 0)
                    {
                        fubenId = GetSceneByNpc(taskConfig.CompleteNpcID);
                        if (fubenId > 0)
                        {
                            fubenname = SceneConfigCategory.Instance.Get(fubenId).Name;
                        }
                    }
                    else
                    {
                        fubenname = DungeonConfigCategory.Instance.Get(fubenId).ChapterName;
                    }

                    MapComponent mapComponent = root.GetComponent<MapComponent>();
                    if (mapComponent.MapType == MapTypeEnum.MainCityScene)
                    {
                        flyTipComponent.ShowFlyTip("请点击右下角探险按钮进入地图");
                    }
                    else
                    {
                        using (zstring.Block())
                        {
                            flyTipComponent.ShowFlyTip(zstring.Format("请前往{0}", fubenname));
                        }
                    }

                    return true;
                }

                flyTipComponent.ShowFlyTip("正在前往任务目标点");
                MoveToNpc(root, npcid).Coroutine();
                return false;
            }

            if (taskConfig.TargetPosition != 0)
            {
                bool excuteVAlue = MoveToTask(root, taskConfig.TargetPosition);
                if (excuteVAlue)
                {
                    flyTipComponent.ShowFlyTip("正在前往任务目标点");
                    return true;
                }
            }

            GetTaskLogic(target).taskExcute(root, taskPro, taskConfig);
            return true;
        }

        public static bool GeToOtherFuben(Scene root, int fubenId, int curdungeonid)
        {
            // int transformid = DungeonConfigCategory.Instance.GetTransformId(fubenId, curdungeonid);
            // if (transformid > 0)
            // {
            //     Unit unit = UnitHelper.GetMyUnitFromClientScene(root);
            //     DungeonTransferConfig transferConfig = DungeonTransferConfigCategory.Instance.Get(transformid);
            //     Vector3 vector3 = new Vector3(transferConfig.Position[0] * 0.01f, transferConfig.Position[1] * 0.01f, transferConfig.Position[2] * 0.01f);
            //     unit.MoveToAsync2(vector3, false).Coroutine();
            //     return true;
            // }
            return false;
        }

        private static int GetSceneByNpc(int npcId)
        {
            if (npcId == 0)
            {
                return 0;
            }

            List<SceneConfig> dungeonConfigs = SceneConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < dungeonConfigs.Count; i++)
            {
                SceneConfig dungeonConfig = dungeonConfigs[i];
                if (dungeonConfig.NpcList == null)
                {
                    continue;
                }

                if (dungeonConfig.NpcList.Contains(npcId))
                {
                    return dungeonConfig.Id;
                }
            }

            return 0;
        }

        public static async ETTask<int> MoveToNpc(Scene root, int npcid)
        {
            if (!TaskHelper.HaveNpc(root, npcid))
            {
                return ErrorCode.ERR_NotFindNpc;
            }

            Vector3 targetPos;
            NpcConfig npcConfig = NpcConfigCategory.Instance.Get(npcid);
            targetPos = new Vector3(npcConfig.Position[0] * 0.01f, npcConfig.Position[1] * 0.01f, npcConfig.Position[2] * 0.01f);
            Unit unit = UnitHelper.GetMyUnitFromClientScene(root);
            long instanceid = unit.InstanceId;
            targetPos.y = unit.Position.y;

            int ret = 0;
            if (Vector3.Distance(unit.Position, targetPos) > TaskData.NpcSpeakDistance + 0.1f)
            {
                Vector3 unitPosi = unit.Position;
                Vector3 dir = (unitPosi - targetPos).normalized;
                targetPos += dir * TaskData.NpcSpeakDistance;
                EventSystem.Instance.Publish(root, new BeforeMove() { DataParamString = "1" });
                ret = await unit.MoveToAsync(targetPos, null, true);
            }

            if (instanceid != unit.InstanceId || Vector3.Distance(unit.Position, targetPos) > TaskData.NpcSpeakDistance)
            {
                return -1;
            }

            EventSystem.Instance.Publish(unit.Scene(), new TaskNpcDialog() { NpcId = npcid, ErrorCode = ret });
            return ret;
        }

        private static bool MoveToTask(Scene zoneScene, int positionId)
        {
            TaskPositionConfig taskPositionConfig = TaskPositionConfigCategory.Instance.Get(positionId);
            MapComponent mapComponent = zoneScene.GetComponent<MapComponent>();
            if (mapComponent.MapType != (int)MapTypeEnum.LocalDungeon)
            {
                return false;
            }

            if (mapComponent.SceneId == taskPositionConfig.MapID)
            {
                MoveToTaskPosition(zoneScene, positionId);
                return true;
            }

            string[] otherMapMoves = taskPositionConfig.OtherMapMove.Split(';');
            if (otherMapMoves == null)
            {
                return false;
            }

            for (int i = 0; i < otherMapMoves.Length; i++)
            {
                if (otherMapMoves[i] == "0")
                {
                    continue;
                }

                string[] positionIds = otherMapMoves[i].Split(',');
                if (int.Parse(positionIds[0]) == mapComponent.SceneId)
                {
                    MoveToTaskPosition(zoneScene, int.Parse(positionIds[1]));
                    return true;
                }
            }

            return false;
        }

        private static void MoveToTaskPosition(Scene root, int taskPositionId)
        {
            TaskPositionConfig taskPositionConfig = TaskPositionConfigCategory.Instance.Get(taskPositionId);
            GameObject gameObject;
            using (zstring.Block())
            {
                gameObject = GameObject.Find((zstring)"ScenceRosePositionSet/" + taskPositionConfig.PositionName);
            }

            if (gameObject == null)
            {
                return;
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(root);
            EventSystem.Instance.Publish(root, new BeforeMove() { DataParamString = String.Empty });
            unit.MoveToAsync(gameObject.transform.position).Coroutine();
        }

        private static bool ExcuteKillMonsterID(Scene root, TaskPro taskPro, TaskConfig taskConfig)
        {
            int monsterId = taskConfig.Target[0];
            int fubenId = SceneConfigHelper.GetFubenByMonster(monsterId);
            fubenId = taskPro.FubenId > 0 ? taskPro.FubenId : fubenId;
            
            
            MapComponent mapComponent = root.GetComponent<MapComponent>();
            if (mapComponent.MapType != MapTypeEnum.LocalDungeon)
            {
                if (fubenId == 0)
                {
                    return false;
                }
                FlyTipComponent.Instance.ShowFlyTip($"请前往 {DungeonConfigCategory.Instance.Get(fubenId).ChapterName}");
                return false;
            }
            if (mapComponent.SceneId != fubenId)
            {
                if (GeToOtherFuben(root, fubenId, mapComponent.SceneId))
                {
                    return true;
                }
            
                fubenId = mapComponent.SceneId;
            }
            int wave = taskPro.FubenId > 0 ? taskPro.WaveId : -1;
            string[] position = SceneConfigHelper.GetPostionMonster(fubenId, monsterId, wave);
            if (position == null)
            {
                FlyTipComponent.Instance.ShowFlyTip("请手动前往");
                return false;
            }
            
            Unit unit = UnitHelper.GetMyUnitFromClientScene(root);
            Vector3 target = new Vector3(float.Parse(position[0]), float.Parse(position[1]), float.Parse(position[2]));
            Vector3 unitPos = unit.Position;
            Vector3 dir = unitPos - target;
            Vector3 ttt = target + dir.normalized * 1f;
            unit.MoveToAsync(ttt).Coroutine();
            return true;
        }

        private static string GetDescKillMonsterID(TaskPro taskPro, TaskConfig taskConfig)
        {
            string desc = "";
            string progress = "击败{0} {1}/{2} {3}";

            for (int i = 0; i < taskConfig.Target.Length; i++)
            {
                int monsterId = taskConfig.Target[i];
                int fubenId = SceneConfigHelper.GetFubenByMonster(monsterId);
                fubenId = taskPro.FubenId > 0 ? taskPro.FubenId : fubenId;
                string fubenName = fubenId > 0 ? " (地图:" + DungeonConfigCategory.Instance.Get(fubenId).ChapterName + ")" : "";

                if (!MonsterConfigCategory.Instance.Contain(monsterId))
                {
                    Log.Error($"MonsterConfig not contain {monsterId}");
                    return desc;
                }
                
                MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(monsterId);

                string text1 = "";
                if (i == 0)
                {
                    using (zstring.Block())
                    {
                        text1 = zstring.Format(progress, monsterConfig.MonsterName, taskPro.taskTargetNum_1, taskConfig.TargetValue[i], fubenName);
                    }
                }

                if (i == 1)
                {
                    using (zstring.Block())
                    {
                        text1 = zstring.Format(progress, monsterConfig.MonsterName, taskPro.taskTargetNum_2, taskConfig.TargetValue[i], fubenName);
                    }
                }

                desc = desc + text1 + "\n";
            }

            return desc;
        }

        private static bool ExcuteItemId(Scene root, TaskPro taskPro, TaskConfig taskConfig)
        {
            return true;
        }

        private static string GetDescItemId(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("寻找道具{0} {1}/{2}");
            int itemId = taskConfig.Target[0];
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itemId);
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, itemConfig.ItemName, taskPro.taskTargetNum_1, taskConfig.TargetValue[0]);
            }

            return text1;
        }

        private static bool ExcuteLookingFor(Scene root, TaskPro taskPro, TaskConfig taskConfig)
        {
            // int fubenId = GetFubenByNpc(taskConfig.Target[0]);
            // if (fubenId == 0)
            // {
            //     return false;
            // }
            // FloatTipManager.Instance.ShowFloatTip($"请前往 {DungeonConfigCategory.Instance.Get(fubenId).ChapterName}");
            return true;
        }

        private static string GetDescLookingFor(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("找 {0} 谈一谈 {1}");

            int fubenId = GetFubenByNpc(taskConfig.Target[0]);
            string fubenName = fubenId > 0 ? " (地图:" + DungeonConfigCategory.Instance.Get(fubenId).ChapterName + ")" : "";

            NpcConfig npcConfig = NpcConfigCategory.Instance.Get(taskConfig.Target[0]);
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, npcConfig.Name, fubenName);
            }

            return text1;
        }

        private static bool ExcutePlayerLv(Scene root, TaskPro taskPro, TaskConfig taskConfig)
        {
            // FloatTipManager.Instance.ShowFloatTip("请提升到相对的等级");
            return true;
        }

        private static string GetDescPlayerLv(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("等级提升至{0}级 {1}/{2}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskConfig.TargetValue[0], taskPro.taskTargetNum_1, taskConfig.TargetValue[0]);
            }

            return text1;
        }

        private static bool ExcuteDoNothing(Scene root, TaskPro taskPro, TaskConfig taskConfig)
        {
            return true;
        }

        private static string GetDescKillMonster(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("击败任意怪物 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, taskConfig.TargetValue[0]);
            }

            return text1;
        }

        private static string GetDescKillBOSS(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("击败任意领主级怪物 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, taskConfig.TargetValue[0]);
            }

            return text1;
        }

        private static string GetDescPassFubenID(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("通关副本{0} {1}/{2}");
            string fubenName = CellGenerateConfigCategory.Instance.Get(taskConfig.Target[0]).ChapterName;
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, fubenName, taskPro.taskTargetNum_1, taskConfig.TargetValue[0]);
            }

            return text1;
        }

        private static string GetChangeOcc(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("进行转职{0} {1}/{2}");
            string fubenName = "";
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, fubenName, taskPro.taskTargetNum_1, taskConfig.TargetValue[0]);
            }

            return text1;
        }

        private static bool ExcuteGiveItem_10(Scene root, TaskPro taskPro, TaskConfig taskConfig)
        {
            if (taskConfig.CompleteNpcID == 0)
            {
                OpenUIGiveTask(root, taskPro).Coroutine();
            }
            else
            {
                ExcuteMoveTo(root, taskPro, taskConfig);
            }

            return true;
        }

        private static bool ExcuteMoveTo(Scene root, TaskPro taskPro, TaskConfig taskConfig)
        {
            // int curdungeonid = zoneScene.GetComponent<MapComponent>().SceneId;
            // int npcid = taskConfig.CompleteNpcID;
            // string fubenname = "副本";
            // if (!TaskHelper.HaveNpc(zoneScene, npcid))
            // {
            //     int fubenId = TaskViewHelp.Instance.GetFubenByNpc(npcid);
            //
            //     if (fubenId >= 0 && fubenId != curdungeonid)
            //     {
            //         if (GeToOtherFuben(zoneScene, fubenId, curdungeonid))
            //         {
            //             return true;
            //         }
            //     }
            //
            //     //再查找其他scene
            //     if (fubenId == 0)
            //     {
            //         fubenId = TaskViewHelp.Instance.GetSceneByNpc(taskConfig.CompleteNpcID);
            //         if (fubenId > 0)
            //         {
            //             fubenname = SceneConfigCategory.Instance.Get(fubenId).Name;
            //         }
            //     }
            //     else
            //     {
            //         fubenname = DungeonConfigCategory.Instance.Get(fubenId).ChapterName;
            //     }
            //
            //     FloatTipManager.Instance.ShowFloatTip($"请前往{fubenname}");
            //     return true;
            // }
            //
            // FloatTipManager.Instance.ShowFloatTip("正在前往任务目标点");
            // TaskViewHelp.Instance.MoveToNpc(zoneScene, npcid).Coroutine();
            return true;
        }

        private static string GetGiveItem(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("给予符合要求的道具 {0}/{1}");

            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string PetNumber1_11(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("获得宠物数量 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string MakeNumber_12(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("制造道具数量 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string EquipXiLian_13(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("装备洗练次数 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string PetTianTiNumber_14(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("宠物天梯次数 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string DuiHuanGold_15(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("兑换金币次数 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string EquipHuiShou_16(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("装备回收次数 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string QiangHuaLevel_17(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("最大强化等级 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string PetNSkill_18(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization(taskConfig.TargetValue[0] + "技能宠物 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string PetFubenId_19(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("宠物探险通关{0} {1}/{2}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskConfig.TargetValue[0], taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string TotalCostGold_20(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("消耗金币 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string KillPlayer_21(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("击杀玩家数量 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string JiaYuanLevel_22(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("家园等级 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string PetHeCheng_23(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("宠物合成次数 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string PetNumber2_24(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("拥有宠物数量 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static bool ExcuteGivePet_25(Scene root, TaskPro taskPro, TaskConfig taskConfig)
        {
            if (taskConfig.CompleteNpcID == 0)
            {
                OpenUIGivePet(root, taskPro).Coroutine();
            }
            else
            {
                ExcuteMoveTo(root, taskPro, taskConfig);
            }

            return true;
        }

        private static string GivePet_25(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("给予一个宠物 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string TreasureMapNormal_26(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("使用普通藏宝图 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string TreasureMapHigh_27(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("使用高级藏宝图 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string TowerOfSeal_28(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("封印之塔挑战 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string MakeQulityNumber_29(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("制造道具数量 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string BattleUseItem_30(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("使用药剂或者合剂次数 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string PetNumber_31(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("获得X只新的宠物 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string PetHeChengCombat_32(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("合成1只战力达到X点的宠物 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string PetXiLian10010086_33(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("宠物使用宠之晶洗练宠物次数 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string PetFuHuaNumber_34(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("在孵化系统中孵化成功宠物 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string PetFuHuaId_35(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("在孵化系统中孵化指定的宠物蛋成功 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string PetUseSkillBook_36(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("宠物使用技能书次数 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string PetTianDiWin_37(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("宠物天梯战斗胜利次数 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string FuMoQulity_41(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("使用N点品质的鉴定附魔道具给装备附魔 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string JianDingQulity_42(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("使用N点品质的鉴定道具给装备鉴定 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string JianDingAttrNumber_43(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("鉴定装备时出一个大于N条属性的装备 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string XiLianSkillNumber_44(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("洗练出带有任何隐藏技能的装备 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string XiLianAttriId_45(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("洗练出带有指定属性的装备 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string IncreaseNumber_46(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("增幅装备次数 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string TrialRank_81(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("试炼之地的输出排行榜进入前 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string PetTianTiRank_82(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("宠物天梯进入排行榜前 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string CombatRank_83(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("战力排行榜进入前 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string JiaYuanCookNumber_91(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("家园烹饪次数 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string JiaYuanPlantNumber_92(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("家园种地种植次数 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string JiaYuanGatherPlant_93(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("家园种地收获次数 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string JiaYuanPastureNumber_94(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("家园牧场饲养次数 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string JiaYuanGatherPasture_95(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("家园牧场收货次数 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string JiaYuanDashiNumber_96(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("家园美味品尝次数 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, 1);
            }

            return text1;
        }

        private static string GetJoinUnion(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("加入公会 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, taskConfig.TargetValue[0]);
            }

            return text1;
        }

        private static string GetDescKillChallengeMonsterID(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("击败挑战级的 {0} {1}/{2}");
            string monsterName = MonsterConfigCategory.Instance.Get(taskConfig.Target[0]).MonsterName;
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, monsterName, taskPro.taskTargetNum_1, taskConfig.TargetValue[0]);
            }

            return text1;
        }

        private static string GetDescKillInfernalMonsterID(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("击败地狱级的 {0} {1}/{2}");
            string monsterName = MonsterConfigCategory.Instance.Get(taskConfig.Target[0]).MonsterName;
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, monsterName, taskPro.taskTargetNum_1, taskConfig.TargetValue[0]);
            }

            return text1;
        }

        private static string GetDescPassChallengeFubenID(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("通关挑战级-{0}副本 {1}/{2}");
            string chapterName = CellGenerateConfigCategory.Instance.Get(taskConfig.Target[0]).ChapterName;
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, chapterName, taskPro.taskTargetNum_1, taskConfig.TargetValue[0]);
            }

            return text1;
        }

        private static string GetDescPassInfernalFubenID(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("通关地狱级-{0}副本 {1}/{2}");
            string chapterName = CellGenerateConfigCategory.Instance.Get(taskConfig.Target[0]).ChapterName;
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, chapterName, taskPro.taskTargetNum_1, taskConfig.TargetValue[0]);
            }

            return text1;
        }

        private static string GetDescKillChallengeMonsterNumber(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("击败挑战级任意怪物{0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, taskConfig.TargetValue[0]);
            }

            return text1;
        }

        private static string GetDescKillInfernalMonsterNumber(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("击败地狱级任意怪物{0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, taskConfig.TargetValue[0]);
            }

            return text1;
        }

        private static string GetDescKillChallengeBossNumber(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("击败挑战级任意领主怪物{0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, taskConfig.TargetValue[0]);
            }

            return text1;
        }

        private static string GetDescCombatToValue(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("战力提升至{0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, taskConfig.TargetValue[0]);
            }

            return text1;
        }

        private static string GetTrialTowerCeng(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("通关试练塔{0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, taskConfig.TargetValue[0]);
            }

            return text1;
        }

        private static string ShenYuanNumber_135(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("挑战深渊模式的副本 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, taskConfig.TargetValue[0]);
            }

            return text1;
        }

        private static string TeamDungeonHurt_136(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("组队副本伤害值 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, taskConfig.TargetValue[0]);
            }

            return text1;
        }

        private static string MineHaveNumber_401(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("矿场占领次数 {0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, taskConfig.TargetValue[0]);
            }

            return text1;
        }

        private static string GetDescKillInfernalBossNumber(TaskPro taskPro, TaskConfig taskConfig)
        {
            string progress = LanguageComponent.Instance.LoadLocalization("击败地狱级任意领主怪物{0}/{1}");
            string text1;
            using (zstring.Block())
            {
                text1 = zstring.Format(progress, taskPro.taskTargetNum_1, taskConfig.TargetValue[0]);
            }

            return text1;
        }

        private static async ETTask OpenUIGivePet(Scene root, TaskPro taskPro)
        {
            await root.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_GivePet);

            root.GetComponent<UIComponent>().GetDlgLogic<DlgGivePet>().InitTask(taskPro.taskID);
            root.GetComponent<UIComponent>().GetDlgLogic<DlgGivePet>().OnUpdateUI();
        }

        private static async ETTask OpenUIGiveTask(Scene root, TaskPro taskPro)
        {
            await root.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_GiveTask);

            root.GetComponent<UIComponent>().GetDlgLogic<DlgGiveTask>().InitTask(taskPro.taskID);
        }

        public static int GetFubenByNpc(int npcId)
        {
            if (npcId == 0)
            {
                return 0;
            }

            foreach (var VARIABLE in ConfigData.FubenToNpcList)
            {
                if (VARIABLE.Value.Contains(npcId))
                {
                    return VARIABLE.Key;
                }
            }
            return 0;
        }

        public static string GetTaskProgessDesc(TaskPro taskPro)
        {
            int taskId = taskPro.taskID;
            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskId);
            int TargetType = taskConfig.TargetType;
            TaskLogic taskLogic = GetTaskLogic(TargetType);

            if (taskLogic.taskProgess == null)
            {
                Log.Debug($"taskLogic.taskProgess == null:  {taskConfig.Id}");
                return string.Empty;
            }

            return taskLogic.taskProgess(taskPro, taskConfig);
        }
    }
}
