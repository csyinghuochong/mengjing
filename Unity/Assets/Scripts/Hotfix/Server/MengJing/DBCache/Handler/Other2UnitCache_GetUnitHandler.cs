using System;
using System.Collections.Generic;
using ET;

namespace ET.Server
{
    [FriendOf(typeof(UnitCacheComponent))]
    [MessageHandler(SceneType.DBCache)]
    public class Other2UnitCache_GetUnitHandler : MessageHandler<Scene, Other2UnitCache_GetUnit, UnitCache2Other_GetUnit>
    {
        protected override async ETTask Run(Scene scene, Other2UnitCache_GetUnit request, UnitCache2Other_GetUnit response)
        {
            UnitCacheComponent unitCacheComponent = scene.GetComponent<UnitCacheComponent>();
            Dictionary<string, Entity> dictionary = ObjectPool.Instance.Fetch(typeof(Dictionary<string, Entity>)) as Dictionary<string, Entity>;
            try
            {
                if (request.ComponentNameList.Count == 0)
                {
                    dictionary.Add(nameof(Unit), null);
                    foreach (string s in unitCacheComponent.UnitCacheKeyList)
                    {
                        dictionary.Add(s, null);
                    }
                }
                else
                {
                    foreach (string s in request.ComponentNameList)
                    {
                        dictionary.Add(s, null);
                    }
                }

                foreach (var key in dictionary.Keys)
                {
                    Entity entity = await unitCacheComponent.Get(request.UnitId, key);
                    dictionary[key] = entity;
                }

                response.ComponentNameList.AddRange(dictionary.Keys);
                response.EntityList.AddRange(dictionary.Values);
            }
            finally
            {
                dictionary.Clear();
                ObjectPool.Instance.Recycle(dictionary);
            }

            await ETTask.CompletedTask;
        }
    }
}