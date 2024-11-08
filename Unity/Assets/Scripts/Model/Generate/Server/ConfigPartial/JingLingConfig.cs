using System.Collections.Generic;

namespace ET
{
    public partial class JingLingConfigCategory
    {

        public Dictionary<int, List<int>> JingLingActive = new Dictionary<int, List<int>>();


        public override void EndInit()
        {
            foreach (JingLingConfig jingLingConfig in this.GetAll().Values)
            {

                if (jingLingConfig.GetWay !=2 )
                {
                    continue;
                }

                for (int i = 0; i < jingLingConfig.GetValue.Length; i++)
                {

                    int monsterid = jingLingConfig.GetValue[i];


                    if (!JingLingActive.ContainsKey(monsterid))
                    {
                        JingLingActive.Add( monsterid, new List<int>() );
                    }
                    
                    JingLingActive[monsterid].Add(jingLingConfig.Id);
                    
                }
            }
        }
    }
}
