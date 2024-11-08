using System.Collections.Generic;
using System.Linq;

namespace ET.Client
{
    [EntitySystemOf(typeof (ChengJiuComponentC))]
    [FriendOf(typeof (ChengJiuComponentC))]
    public static partial class ChengJiuComponentCSystem
    {
        [EntitySystem]
        private static void Awake(this ChengJiuComponentC self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ChengJiuComponentC self)
        {
        }

        public static void OnGetChengJiuList(this ChengJiuComponentC self, M2C_ChengJiuListResponse r2C_Respose)
        {
            self.ChengJiuCompleteList = r2C_Respose.ChengJiuCompleteList;
            self.TotalChengJiuPoint = r2C_Respose.TotalChengJiuPoint;
            self.AlreadReceivedId = r2C_Respose.AlreadReceivedId;
            self.RandomDrop = r2C_Respose.RandomDrop;
            self.JingLingId = r2C_Respose.JingLingId;

            self.ChengJiuProgessList.Clear();
            for (int i = 0; i < r2C_Respose.ChengJiuProgessList.Count; i++)
            {
                self.ChengJiuProgessList.Add(r2C_Respose.ChengJiuProgessList[i].ChengJiuID, r2C_Respose.ChengJiuProgessList[i]);
            }
            
            self.JingLingList.Clear();
            foreach (var jinlinginfo in  self.JingLingList)
            {
                self.JingLingList.Add(jinlinginfo.Key, jinlinginfo.Value);
            }
        }

        public static List<int> GetChaptersByType(this ChengJiuComponentC self, int type)
        {
            return ChengJiuConfigCategory.Instance.ChengJiuTypeData[type].ChengJiuChapterTask.Keys.ToList();
        }

        public static List<int> GetTasksByChapter(this ChengJiuComponentC self, int typeid, int subType)
        {
            return ChengJiuConfigCategory.Instance.ChengJiuTypeData[typeid].ChengJiuChapterTask[subType];
        }

        public static void OnActiveJingLing(this ChengJiuComponentC self, int jid)
        {
            EventSystem.Instance.Publish(self.Root(), new JingLingGet { JingLingId = jid });
            
            if (self.JingLingList.ContainsKey(jid))
            {
                return;
            }

            self.JingLingList[jid].Progess++;
        }
    }
}