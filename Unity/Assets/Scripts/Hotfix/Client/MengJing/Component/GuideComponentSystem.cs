﻿using System.Collections.Generic;
using System.Linq;

namespace ET.Client
{
    [FriendOf(typeof(GuideComponent))]
    [EntitySystemOf(typeof(GuideComponent))]
    public static partial class GuideComponentSystem
    {
        [EntitySystem]
        private static void Awake(this GuideComponent self)
        {
        }

        public static void SetGuideId(this GuideComponent self, int guideid)
        {
            self.GuideInfoList.Clear();
            
            List<GuideConfig> guideConfigs = GuideConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < guideConfigs.Count; i++)
            {
                if (guideConfigs[i].Id <= guideid)
                {
                    continue;
                }
            
                int groupid = guideConfigs[i].GroupId;
                if (self.GuideInfoList.ContainsKey(groupid))
                {
                    continue;
                }
            
                self.GuideInfoList.Add(groupid, guideConfigs[i].Id);
            }
        }

        public static void OnNext(this GuideComponent self, int group)
        {
            if (!self.GuideInfoList.ContainsKey(group))
            {
                return;
            }
            
            if (GuideConfigCategory.Instance.Contain(self.GuideInfoList[group] + 1))
            {
                self.GuideInfoList[group]++;
            }
            else
            {
                self.GuideInfoList.Remove(group);
            }
        }

        public static void SendUpdateGuide(this GuideComponent self, int guideId)
        {
        }

        public static void OnTrigger(this GuideComponent self, int triggerType, string triggeParasm)
        {
            if (self.GuideInfoList.Count == 0)
            {
                return;
            }
            
            int groupid = 0;
            int guideid = 0;
            foreach (var item in self.GuideInfoList)
            {
                GuideConfig guideConfig = GuideConfigCategory.Instance.Get(item.Value);
                //Log.Debug($"GuideComponent_OnTrigger : {guideConfig.Id}  {triggeParasm}");
                if (triggerType != guideConfig.TrigerType || triggeParasm != guideConfig.TrigerParams)
                {
                    continue;
                }
            
                groupid = item.Key;
                guideid = item.Value;
                break;
            }
            
            if (guideid == 20011)
            {
                if (self.Root().GetComponent<MapComponent>().SceneId != 10002)
                {
                    return;
                }
            }
            
            if (guideid != 0)
            {
                EventSystem.Instance.Publish(self.Root(), new ShowGuide() { GroupId = groupid, GuideId = guideid });
            }
        }
    }
}