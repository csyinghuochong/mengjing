using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ET
{
    public static class TaskHelper
    {

        public static int GetChapterByNpc(int npcId)
        {
            List<ChapterConfig> chapterList = ChapterConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < chapterList.Count; i++)
            {
                int startArea = chapterList[i].StartArea;
                ChapterSonConfig chapterSonConfig = ChapterSonConfigCategory.Instance.Get(startArea);
                if (chapterSonConfig.NpcList.Contains(npcId))
                {
                    return chapterList[i].Id;
                }
            }
            return 0;
        }


        public static bool HaveNpc(Scene zoneScene, int npcId)
        {
            List<int> npcList = new List<int>();
            MapComponent mapComponent = zoneScene.GetComponent<MapComponent>();
            if (SceneConfigHelper.UseSceneConfig(mapComponent.SceneType))
            {
                SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(mapComponent.SceneId);
                if (sceneConfig.NpcList != null)
                {
                    npcList = new List<int>(sceneConfig.NpcList);
                }
            }
            if (mapComponent.SceneType == (int)SceneTypeEnum.LocalDungeon)
            {
                DungeonConfig dungeonConfig = DungeonConfigCategory.Instance.Get(mapComponent.SceneId);
                if (dungeonConfig.NpcList != null)
                {
                    npcList = new List<int>(dungeonConfig.NpcList);
                }
            }
            return npcList.Contains(npcId);
        }


        public static int GetChapterSection(int chapterId)
        {
            List<ChapterSectionConfig> chapterSectionConfigs = ChapterSectionConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < chapterSectionConfigs.Count; i++)
            {
                List<int> RandomArea = new List<int>(chapterSectionConfigs[i].RandomArea);
                if (RandomArea.Contains(chapterId))
                {
                    return chapterSectionConfigs[i].Id;
                }
            }
            if (chapterId != 0)
            {
                Log.Error("GetChapterSection:   return 0");
            }
            return 0;
        }

        public static int GetLevelIdByMonster(int monster)
        {
            List<ChapterConfig> chapterList = ChapterConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < chapterList.Count; i++)
            {
                int startArea = chapterList[i].StartArea;
                ChapterSonConfig chapterSonConfig = ChapterSonConfigCategory.Instance.Get(startArea);
                if (chapterSonConfig.CreateMonster.Contains(monster.ToString()))
                {
                    return chapterList[i].Id;
                }
            }

            return 0;
        }

        /// <summary>
        /// �ܻ�����
        /// </summary>
        /// <param name="roleLv"></param>
        /// <returns></returns>
        public static List<int> GetTaskListByType(int taskType, int roleLv, int taskNum)
        {
            List<int> randomIds = new List<int>();

            List<int> allTaskIds = new List<int>();
            Dictionary<int, TaskConfig> keyValuePairs = TaskConfigCategory.Instance.GetAll();
            foreach (var item in keyValuePairs)
            {
                if (item.Value.TaskType == taskType
                    && roleLv >= item.Value.TaskLv
                    && roleLv <= item.Value.TaskMaxLv)
                {
                    allTaskIds.Add(item.Key);
                }
            }

            int randomNumber = allTaskIds.Count > taskNum ? taskNum : allTaskIds.Count;
            RandomHelper.GetRandListByCount(allTaskIds, randomIds, randomNumber);
            return randomIds;
        }

        public static int GetTaskIdByType(int taskType, int roleLv)
        {
            List<int> allTaskIds = new List<int>();
            List<int> allWeights = new List<int>();
            Dictionary<int, TaskConfig> keyValuePairs = TaskConfigCategory.Instance.GetAll();
            foreach (var item in keyValuePairs)
            {
                if (item.Value.TriggerType == 1 && item.Value.TriggerValue > roleLv)
                {
                    continue;
                }

                if (item.Value.TaskType == taskType
                    && roleLv >= item.Value.TaskLv
                    && roleLv <= item.Value.TaskMaxLv)
                {
                    allTaskIds.Add(item.Key);
                    allWeights.Add(item.Value.Weight);
                }
            }
            if (allTaskIds.Count == 0)
            {
                return 0;
            }
            int index = RandomHelper.RandomByWeight(allWeights);
            if (index == -1)
            {
                index = RandomHelper.RandomNumber(0, allTaskIds.Count);
            }
            return allTaskIds[index];
        }

        public static List<int> GetActivityV1Task()
        {
            List<int> taskIds = new List<int>();
            Dictionary<int, TaskCountryConfig> keyValuePairs = TaskCountryConfigCategory.Instance.GetAll();
            foreach (var item in keyValuePairs)
            {
                if (item.Value.TaskType == TaskCountryType.ActivityV1)
                {
                    taskIds.Add(item.Key);
                }
            }
            return taskIds;
        }

        /// <summary>
        /// ��Ծ����
        /// </summary>
        /// <returns></returns>
        public static List<int> GetTaskCountrys(Unit unit, int playerLv)
        {
            //��Ծ����
          
            List<int> taskCountryList = new List<int>();
            string[] dayTaskID = GlobalValueConfigCategory.Instance.Get(8).Value.Split(';');
            for (int i = 0; i < dayTaskID.Length; i++)
            {
                //��ȡ�������
                float taskRandValue = RandomHelper.RandFloat01();
                int writeTaskID = int.Parse(dayTaskID[i]);
                int writeTaskID_Next = writeTaskID;
                TaskCountryConfig taskCountryConfig = null;
                double triggerPro = 0;
                do
                {
                    writeTaskID = writeTaskID_Next;
                    taskCountryConfig = TaskCountryConfigCategory.Instance.Get(writeTaskID);

                    if (taskCountryConfig.TriggerType == 1 && playerLv < taskCountryConfig.TargetValue[0])
                    {
                        //����������
                        if (taskCountryConfig.NextTask == 0)
                        {
                            break;
                        }
                        else
                        {
                            writeTaskID_Next = taskCountryConfig.NextTask;
                            continue;
                        }
                    }


                    triggerPro = taskCountryConfig.TriggerPro;
                    writeTaskID_Next = taskCountryConfig.NextTask;

                    if (writeTaskID_Next == 0)
                    {
                        taskRandValue = -1;
                    }

                } while (taskRandValue >= triggerPro);

                taskCountryList.Add(writeTaskID);
            }

            return taskCountryList;
        }


        public static List<int> GetBattleTask()
        {
            List<int> taskIds = new List<int>();
            Dictionary<int, TaskCountryConfig> keyValuePairs = TaskCountryConfigCategory.Instance.GetAll();
            foreach (var item in keyValuePairs)
            {
                if (item.Value.TaskType == TaskCountryType.Battle)
                {
                    taskIds.Add(item.Key);
                }
            }
            return taskIds;
        }

        public static List<int> GetShowLieTask()
        {
            List<int> taskIds = new List<int>();
            Dictionary<int, TaskCountryConfig> keyValuePairs = TaskCountryConfigCategory.Instance.GetAll();
            foreach (var item in keyValuePairs)
            {
                if (item.Value.TaskType == TaskCountryType.ShowLie)
                {
                    taskIds.Add(item.Key);
                }
            }
            return taskIds;
        }

        public static List<int> GetUnionRaceTask()
        {
            List<int> taskIds = new List<int>();
            Dictionary<int, TaskCountryConfig> keyValuePairs = TaskCountryConfigCategory.Instance.GetAll();
            foreach (var item in keyValuePairs)
            {
                if (item.Value.TaskType == TaskCountryType.UnionRace)
                {
                    taskIds.Add(item.Key);
                }
            }
            return taskIds;
        }

        public static List<int> GetMineTask()
        {
            List<int> taskIds = new List<int>();
            Dictionary<int, TaskCountryConfig> keyValuePairs = TaskCountryConfigCategory.Instance.GetAll();
            foreach (var item in keyValuePairs)
            {
                if (item.Value.TaskType == TaskCountryType.Mine)
                {
                    taskIds.Add(item.Key);
                }
            }
            return taskIds;
        }

        /// <summary>
        /// ����ÿ������
        /// </summary>
        /// <returns></returns>
        public static List<int> GetSeasonTask()
        {
            List<int> taskIds = new List<int>();
          
            foreach((  int number , List<int> ids ) in TaskCountryConfigCategory.Instance.SeasonTaskList)
            {
                int[] randomids = RandomHelper.GetRandoms( number, 0, ids.Count );
                for ( int i = 0; i < randomids.Length; i++ )
                {
                    taskIds.Add(ids[randomids[i]]);
                }
            }

            return taskIds;
        }

        public static List<RewardItem> GetTaskRewards(int taskid, TaskConfig taskConfig = null)
        {
            if (taskConfig == null)
            {
                taskConfig = TaskConfigCategory.Instance.Get(taskid);
            }

            List<RewardItem> taskRewards = new List<RewardItem>();
            string ItemIDs = taskConfig.ItemID;
            string ItemNum = taskConfig.ItemNum;
            string[] ids = ItemIDs.Split(';');
            string[] nums = ItemNum.Split(';');
            for (int i = 0; i < ids.Length; i++)
            {
                if (ids[i] == "0" || ids[i] == "")
                {
                    continue;
                }
                RewardItem taskReward = new RewardItem();
                taskReward.ItemID = int.Parse(ids[i]);
                taskReward.ItemNum = int.Parse(nums[i]);
                taskRewards.Add(taskReward);
            }
            return taskRewards;
        }

        /// <summary>
        /// 1 ս��
        ///2 ��������
        ///3 ��������
        ///4 �������� 5 ħ������ 6 �������� 7 ħ������ 8 �ɳ�
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="petinfo"></param>
        /// <returns></returns>
        public static bool IsTaskGivePet(int TargetType, int[] Target, int[] TargetValue, RolePetInfo petinfo)
        {
            if (petinfo == null)
            {
                return false;
            }

            if (TargetType != (int)TaskTargetType.GivePet_25)
            {
                return false;
            }
            if (Target.Length != TargetValue.Length)
            {
                return false;
            }

            for (int i = 0; i < Target.Length; i++)
            {
                bool value = false;
                int targetType = Target[i];
                int targetValue = TargetValue[i];

                switch (targetType)
                {
                    case 1:
                        int combat = PetHelper.PetPingJia(petinfo);
                        value = combat >= targetValue;
                        break;
                    case 2:
                        value = petinfo.PetSkill.Count >= targetValue;
                        break;
                    case 3:
                        value = petinfo.ZiZhi_Hp >= targetValue;
                        break;
                    //4 �������� 5 ħ������ 6 �������� 7 ħ������ 8 �ɳ�
                    case 4:
                        value = petinfo.ZiZhi_Act >= targetValue;
                        break;
                    case 5:
                        value = petinfo.ZiZhi_MageAct >= targetValue;
                        break;
                    case 6:
                        value = petinfo.ZiZhi_Def >= targetValue;
                        break;
                    case 7:
                        value = petinfo.ZiZhi_Adf >= targetValue;
                        break;
                    case 8:
                        value = (100 * petinfo.ZiZhi_ChengZhang) >= targetValue;
                        break;
                    default:
                        break;
                }

                if (!value)
                {
                    return false;
                }
            }

            return true;
        }

        //Ŀ������Ϊ10��
        //֧�ֶ�� ����Target�ֶ�����1,3 TargetValue�ֶ�����10,3 ������һ��10������,Ʒ��Ϊ��ɫ���ϵĵ��ߡ�
        //            Ŀ��ֵ���Ӧ��ֵ
        //1.���ߵȼ�
        //2.���߲�λ
        //3.����Ʒ��
        //4:�������ID
        //5:���߼�����Ŀ��
        //6:��������  
        //7:���ؼ���
        //105101.װ��������������
        //105201.װ��������������
        //105301.װ��������������
        //105401.װ��������������
        //105501.װ��������������

        public static bool IsTaskGiveItem(int TargetType, int[] Target, int[] TargetValue, BagInfo bagInfo)
        {
            if (bagInfo == null)
            {
                return false;
            }

            if (TargetType != (int)TaskTargetType.GiveItem_10)
            {
                return false;
            }

            if (Target == null || TargetValue == null)
            {
                return false;
            }

            if (Target.Length != TargetValue.Length)
            {
                return false;
            }

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            //if (itemConfig.ItemType != ItemTypeEnum.Equipment)
            //{
            //    return false;
            //}

            for (int i = 0; i < Target.Length; i++)
            {
                bool value = false;
                int targetType = Target[i];
                int targetValue = TargetValue[i];

                switch (targetType)
                {
                    case 1:
                        value = itemConfig.UseLv >= targetValue;
                        break;
                    case 2:
                        value = itemConfig.ItemSubType == targetValue;
                        break;
                    case 3:
                        value = itemConfig.ItemQuality >= targetValue;
                        break;
                    case 4:
                        value = itemConfig.Id == targetValue;
                        break;
                    case 5:
                        value = bagInfo.HideProLists.Count >= targetValue;
                        break;
                    case 6:
                        value = itemConfig.EquipType == targetValue;
                        break;
                    case 7:
                        value = bagInfo.HideSkillLists.Count >= targetValue;
                        break;
                    case 105101:
                    case 105201:
                    case 105301:
                    case 105401:
                    case 105501:
                        value = GetJianDingValue(bagInfo, targetType) >= targetValue;
                        break;
                }

                if (!value)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// �����������������Ƿ�ȫ�����
        /// </summary>
        /// <param name="completeids"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static bool IsDayTaskComplete(List<int> completeids, int day)
        {
            List<int> daytask = ConfigHelper.WelfareTaskList()[day];
            for (int i = 0; i < daytask.Count; i++)
            {
                if (!completeids.Contains(daytask[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public static long GetJianDingValue(BagInfo bagInfo, int type)
        {
            long value = 0;
            for (int i = 0; i < bagInfo.HideProLists.Count; i++)
            {
                if (type == bagInfo.HideProLists[i].HideID)
                {
                    value += bagInfo.HideProLists[i].HideValue;
                }
            }

            return value;
        }
    }
}
