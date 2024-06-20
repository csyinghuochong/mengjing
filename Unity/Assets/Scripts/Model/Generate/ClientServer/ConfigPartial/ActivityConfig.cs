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
                if (activityConfig.ActivityType != 101)
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
            
            foreach (ActivityConfig functionConfig in this.GetAll().Values)
            {
                if (functionConfig.ActivityType == 34)
                {
                    PulicSerialList.Add(functionConfig.Par_2, functionConfig.Id);
                }
            }
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

        public int GetPulicSerial(string serial)
        { 
            int activityid = 0;
            PulicSerialList.TryGetValue(serial, out activityid);
            return activityid;
        }
    }
}