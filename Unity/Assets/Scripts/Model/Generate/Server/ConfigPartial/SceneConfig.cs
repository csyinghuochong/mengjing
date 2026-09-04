using System.Collections.Generic;

namespace ET
{

    public partial class SceneConfigCategory
    {

        public List<int> NpcIdList = new List<int>();

        partial void PostInit()
        {
            foreach (SceneConfig sceneConfig in this.GetAll().Values)
            {
                if (sceneConfig.Id == 101)
                {
                    InitMainNpc(sceneConfig);
                }
            }
        }

        public void InitMainNpc(SceneConfig sceneConfig)
        {
            int[] npcids = sceneConfig.NpcList;
            for (int i = 0; i < npcids.Length; i++)
            {
                NpcIdList.Add(npcids[i]);
            }
        }
    }
}