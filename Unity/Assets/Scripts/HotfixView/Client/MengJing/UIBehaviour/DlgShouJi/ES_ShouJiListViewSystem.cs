using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_ShouJiList))]
    [FriendOfAttribute(typeof (ES_ShouJiList))]
    public static partial class ES_ShouJiListSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ShouJiList self, Transform transform)
        {
            self.uiTransform = transform;

            self.OnUpdateUI().Coroutine();
        }

        [EntitySystem]
        private static void Destroy(this ES_ShouJiList self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnUpdateUI(this ES_ShouJiList self)
        {
            var path = ABPathHelper.GetUGUIPath("Common/UIShouJiChapter");
            var bundleGameObject = await self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(path);
            List<ShouJiConfig> shouJiConfigs = ShouJiConfigCategory.Instance.GetAll().Values.ToList();
            long instanceId = self.InstanceId;
            for (int i = 0; i < shouJiConfigs.Count; i++)
            {
                if (instanceId != self.InstanceId)
                {
                    return;
                }

                GameObject go = UnityEngine.Object.Instantiate(bundleGameObject);
                CommonViewHelper.SetParent(go, self.EG_ShoujiContentRectTransform.gameObject);
                self.AddChild<UIShouJiChapterComponent, GameObject>(go).OnInitUI(shouJiConfigs[i]).Coroutine();
                await self.Root().GetComponent<TimerComponent>().WaitAsync(200);
            }
        }
    }
}