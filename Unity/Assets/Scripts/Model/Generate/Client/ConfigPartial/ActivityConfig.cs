using System.Collections.Generic;

namespace ET
{


    public partial class ActivityConfigCategory
    {
        public Dictionary<int, List<int>> MaoXianJiaBuffs = new Dictionary<int, List<int>>();
        public Dictionary<string, int> PulicSerialList = new Dictionary<string, int>();


        public override void EndInit()
        {
            foreach (ActivityConfig activityConfig in this.GetAll().Values)
            {
                if (activityConfig.ActivityType == (int)ActivityEnum.Type_34)
                {
                    PulicSerialList.Add(activityConfig.Par_2, activityConfig.Id);
                }
                
                if (activityConfig.ActivityType != (int)ActivityEnum.Type_101)
                {
                    continue;
                }

                List<int> buffids = new List<int> ();   

                if (string.IsNullOrEmpty(activityConfig.Par_1))
                {
                    MaoXianJiaBuffs.Add(activityConfig.Id, buffids);
                    continue;
                }

                string[] buffinfos = activityConfig.Par_1.Split(',');
                for (int i = 0; i < buffinfos.Length; i++)
                {
                    int buffid = int.Parse(buffinfos[i]);
                    if (buffid != 0)
                    {
                        buffids.Add (buffid);   
                    }
                }

                MaoXianJiaBuffs.Add(activityConfig.Id, buffids);
            }
        }

        public int GetNumByType(int type)
        {
            int num = 0;
            foreach (ActivityConfig activityConfig in this.GetAll().Values)
            {
                if (activityConfig.ActivityType == type)
                {
                    num++;
                }
            }
            return num;
        }
        
        public List<ActivityConfig> GetByType(int type)
        {
            List<ActivityConfig> list = new List<ActivityConfig>();
            foreach (ActivityConfig activityConfig in this.GetAll().Values)
            {
                if (activityConfig.ActivityType == type)
                {
                    list.Add(activityConfig);
                }
            }
            return list;
        }
        
        public int GetPulicSerial(string serial)
        { 
            int activityid = 0;
            PulicSerialList.TryGetValue(serial, out activityid);
            return activityid;
        }
        
        public List<int> GetBuffIds(int activityid)
        {
            List<int> buffids = null;
            MaoXianJiaBuffs.TryGetValue (activityid, out buffids);
            if (buffids == null)
            { 
                buffids = new List<int> ();
                Log.Error($"GetBuffIds:  {activityid}");
            }
            return buffids; 
        }

    }
}