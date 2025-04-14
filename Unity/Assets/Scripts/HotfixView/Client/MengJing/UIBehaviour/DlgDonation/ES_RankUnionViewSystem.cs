using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_RankUnionTaskItem))]
    [FriendOf(typeof(Scroll_Item_RunRaceItem))]
    [EntitySystemOf(typeof(ES_RankUnion))]
    [FriendOfAttribute(typeof(ES_RankUnion))]
    public static partial class ES_RankUnionSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RankUnion self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_RunRaceItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnRunRaceItemsRefresh);
            self.E_RankUnionTaskItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnRankUnionTaskItemsRefresh);

            self.EG_UIRankUnionItemRectTransform.gameObject.SetActive(false);
            self.UpdateRanking().Coroutine();
            self.ShowHuntRewards();
            self.UpdateTaskCountrys();
        }

        [EntitySystem]
        private static void Destroy(this ES_RankUnion self)
        {
            self.DestroyWidget();
        }

        private static void OnRunRaceItemsRefresh(this ES_RankUnion self, Transform transform, int index)
        {
            foreach (Scroll_Item_RunRaceItem item in self.ScrollItemRunRaceItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_RunRaceItem scrollItemRunRaceItem = self.ScrollItemRunRaceItems[index].BindTrans(transform);
            scrollItemRunRaceItem.OnUpdate(self.ShowRankRewardConfigs[index]);
        }

        private static void OnRankUnionTaskItemsRefresh(this ES_RankUnion self, Transform transform, int index)
        {
            foreach (Scroll_Item_RankUnionTaskItem item in self.ScrollItemRankUnionTaskItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_RankUnionTaskItem scrollItemRankUnionTaskItem = self.ScrollItemRankUnionTaskItems[index].BindTrans(transform);
            scrollItemRankUnionTaskItem.OnUpdateData(self.ShowTaskPros[index]);
        }

        public static async ETTask UpdateRanking(this ES_RankUnion self)
        {
            long instacnid = self.InstanceId;
            R2C_RankUnionRaceResponse response = await RankNetHelper.RankUnionRaceRequest(self.Root());

            // 测试数据
            // response.RankList.Add(new RankShouLieInfo() { PlayerName = "测试角色1", KillNumber = 300 });
            // response.RankList.Add(new RankShouLieInfo() { PlayerName = "测试角色2", KillNumber = 200 });

            if (response.RankList == null || response.RankList.Count < 1)
            {
                return;
            }

            if (instacnid != self.InstanceId)
            {
                return;
            }

            response.RankList.Sort((x, y) => (int)(y.KillNumber - x.KillNumber));

            using (zstring.Block())
            {
                for (int i = 0; i < response.RankList.Count; i++)
                {
                    GameObject go = UnityEngine.Object.Instantiate(self.EG_UIRankUnionItemRectTransform.gameObject);
                    CommonViewHelper.SetParent(go, self.EG_RankingListNodeRectTransform.gameObject);
                    go.SetActive(true);
                    ReferenceCollector rc = go.GetComponent<ReferenceCollector>();
                    rc.Get<GameObject>("NameText").GetComponent<Text>().text = zstring.Format("   {0}    {1}", i + 1, response.RankList[i].PlayerName);
                    rc.Get<GameObject>("NumText").GetComponent<Text>().text = response.RankList[i].KillNumber.ToString();
                }
            }
        }

        public static void ShowHuntRewards(this ES_RankUnion self)
        {
            self.ShowRankRewardConfigs = RankHelper.GetTypeRankRewards(4);

            self.AddUIScrollItems(ref self.ScrollItemRunRaceItems, self.ShowRankRewardConfigs.Count);
            self.E_RunRaceItemsLoopVerticalScrollRect.SetVisible(true, self.ShowRankRewardConfigs.Count);
        }

        public static void UpdateTaskCountrys(this ES_RankUnion self)
        {
            List<TaskPro> taskPros = self.Root().GetComponent<TaskComponentC>().RoleTaskList;

            taskPros.Sort(delegate(TaskPro a, TaskPro b)
            {
                int commita = a.taskStatus == (int)TaskStatuEnum.Commited ? 1 : 0;
                int commitb = b.taskStatus == (int)TaskStatuEnum.Commited ? 1 : 0;
                int completea = a.taskStatus == (int)TaskStatuEnum.Completed ? 1 : 0;
                int completeb = b.taskStatus == (int)TaskStatuEnum.Completed ? 1 : 0;

                if (commita == commitb)
                    return completeb - completea; //可以领取的在前
                else
                    return commitb - commita; //已经完成的在前
            });

            self.ShowTaskPros.Clear();
            for (int i = 0; i < taskPros.Count; i++)
            {
                TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskPros[i].taskID);
                if (taskConfig.TaskType != TaskTypeEnum.UnionRace)
                {
                    continue;
                }

                self.ShowTaskPros.Add(taskPros[i]);
            }

            // 测试数据
            // self.ShowTaskPros.Add(new TaskPro() { taskID = 400001, taskStatus = (int)TaskStatuEnum.Completed });
            // self.ShowTaskPros.Add(new TaskPro() { taskID = 400002, taskStatus = (int)TaskStatuEnum.Accepted });

            self.AddUIScrollItems(ref self.ScrollItemRankUnionTaskItems, self.ShowTaskPros.Count);
            self.E_RankUnionTaskItemsLoopVerticalScrollRect.SetVisible(true, self.ShowTaskPros.Count);
        }
    }
}
