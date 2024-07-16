using System;
using System.Collections.Generic;
using System.Linq;

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
                    Type tttt = typeof (Unit);
                    string nbaaa = tttt.FullName;
                    dictionary.Add(nbaaa, null);
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

                List<string> entityKeys = dictionary.Keys.ToList();
                foreach (var key in entityKeys)
                {
                    Entity entity = await unitCacheComponent.Get(request.UnitId, key);

                    try
                    {
                        dictionary[key] = entity;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Log.Debug(e.ToString());
                        throw;
                    }
                }
                
                response.ComponentNameList.AddRange(dictionary.Keys);
                foreach (var VARIABLE in dictionary.Values)
                {
                    if (VARIABLE != null)
                    { 
                        response.EntityList.Add(VARIABLE.ToBson()  );
                    }
                }
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