using System.Collections.Generic;
using System.Linq;

namespace ET.Client
{
    [EntitySystemOf(typeof(ChengJiuComponentC))]
    [FriendOf(typeof(ChengJiuComponentC))]
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

        public static void OnFightJingLing(this ChengJiuComponentC self, int jid)
        {
            foreach (JingLingInfo jingLingInfo in self.JingLingList.Values)
            {
                jingLingInfo.State = jid == jingLingInfo.JingLingID ? 1 : 0;
            }
        }

        public static List<JingLingInfo> GetActiveJingLing(this ChengJiuComponentC self, int getway)
        {
            List<JingLingInfo> jingLingInfos = new List<JingLingInfo>();
            foreach (JingLingInfo jingLingInfo in self.JingLingList.Values)
            {
                if (JingLingConfigCategory.Instance.Get(jingLingInfo.JingLingID).GetWay == getway)
                {
                    jingLingInfos.Add(jingLingInfo);
                }
            }

            return jingLingInfos;
        }
        
        public static bool IsActiveJingLing(this ChengJiuComponentC self, int jingling)
        {
            List<JingLingInfo> jingLingInfos = new List<JingLingInfo>();
            foreach (JingLingInfo jingLingInfo in self.JingLingList.Values)
            {
                if (jingLingInfo.JingLingID == jingling)
                {
                    return jingLingInfo.IsActive == 1;
                }
            }

            return false;
        }

        public static int GetFightJingLing(this ChengJiuComponentC self)
        {
            foreach (JingLingInfo jingLingInfo in self.JingLingList.Values)
            {
                if (jingLingInfo.State == 1)
                {
                    return jingLingInfo.JingLingID;
                }
            }

            return 0;
        }

        public static void OnGetChengJiuList(this ChengJiuComponentC self, M2C_ChengJiuListResponse r2C_Respose)
        {
            self.ChengJiuCompleteList = r2C_Respose.ChengJiuCompleteList;
            self.TotalChengJiuPoint = r2C_Respose.TotalChengJiuPoint;
            self.AlreadReceivedId = r2C_Respose.AlreadReceivedId;
            self.RandomDrop = r2C_Respose.RandomDrop;

            self.ChengJiuProgessList.Clear();
            for (int i = 0; i < r2C_Respose.ChengJiuProgessList.Count; i++)
            {
                self.ChengJiuProgessList.Add(r2C_Respose.ChengJiuProgessList[i].ChengJiuID, r2C_Respose.ChengJiuProgessList[i]);
            }

            self.UpdateJingLingList(r2C_Respose.JingLingList);
            self.PetTuJianActives = r2C_Respose.PetTuJianActives;
        }

        public static void UpdateJingLingList(this ChengJiuComponentC self, List<JingLingInfo> jingLingList)
        {
            self.JingLingList.Clear();
            foreach (var jinlinginfo in jingLingList)
            {
                self.JingLingList.Add(jinlinginfo.JingLingID, jinlinginfo);
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