using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ET.Client
{
    [Invoke(TimerInvokeType.GameObjectPoolTimer)]
    public class GameObjectPoolTimer: ATimer<GameObjectPoolComponent>
    {
        protected override void Run(GameObjectPoolComponent self)
        {
            try
            {
                self.OnUpdate();
            }
            catch (Exception e)
            {
                Log.Error($"move timer error: {self.Id}\n{e}");
            }
        }
    }

    [FriendOf(typeof (GameObjectLoad))]
    [FriendOf(typeof (GameObjectPoolComponent))]
    [EntitySystemOf(typeof (GameObjectPoolComponent))]
    public static partial class GameObjectPoolComponentSystem
    {
        [EntitySystem]
        private static void Awake(this GameObjectPoolComponent self)
        {
            self.LoadingList.Clear();
            self.ExternalReferences.Clear();
            GameObjectPoolComponent.Instance = self;
        }

        [EntitySystem]
        private static void Destroy(this GameObjectPoolComponent self)
        {
            self.ExternalReferences.Clear();
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static void OnUpdate(this GameObjectPoolComponent self)
        {
            if (self.LoadingList.Count == 0)
            {
                self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
                return;
            }

            int number = Math.Max(self.LoadingList.Count - 4, 0);
            for (int i = self.LoadingList.Count - 1; i >= number; i--)
            {
                GameObjectLoad load = self.LoadingList[i];
                self.LoadingList.RemoveAt(i);
                self.LoadGameObject(load).Coroutine();
            }
        }

        public static async ETTask LoadGameObject(this GameObjectPoolComponent self, GameObjectLoad load)
        {
            string path = load.Path;
            GameObject gobjet = null;
            List<GameObject> poolGameObjects = null;
            self.ExternalReferences.TryGetValue(path, out poolGameObjects);
            if (poolGameObjects != null)
            {
                for (int i = poolGameObjects.Count - 1; i >= 0; i--)
                {
                    if (poolGameObjects[i] == null)
                    {
                        poolGameObjects.RemoveAt(i);
                    }
                }
            }

            if (poolGameObjects == null || poolGameObjects.Count == 0)
            {
                GameObject prefab = await ResourcesComponent.Instance.LoadAssetAsync<GameObject>(path);
                if (prefab == null)
                {
                    Log.Error($"GameObjectPool1 : prefab == null {path}");
                    return;
                }

                gobjet = GameObject.Instantiate(prefab);
            }
            else
            {
                gobjet = poolGameObjects[0];
                poolGameObjects.RemoveAt(0);
            }

            load.LoadHandler(gobjet, load.FormId);
            load.Dispose();
        }

        public static bool CheckHaveCache(this GameObjectPoolComponent self, string path, long formId, Action<GameObject, long> action)
        {
            List<GameObject> poolGameObjects = null;
            self.ExternalReferences.TryGetValue(path, out poolGameObjects);
            if (poolGameObjects != null)
            {
                for (int i = poolGameObjects.Count - 1; i >= 0; i--)
                {
                    if (poolGameObjects[i] == null)
                    {
                        poolGameObjects.RemoveAt(i);
                    }
                }

                if (poolGameObjects.Count > 0)
                {
                    action(poolGameObjects[0], formId);
                    poolGameObjects.RemoveAt(0);
                    return true;
                }
            }

            return false;
        }

        public static void AddLoadQueue(this GameObjectPoolComponent self, string path, long formId, Action<GameObject, long> action)
        {
            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            if (self.CheckHaveCache(path, formId, action))
            {
                return;
            }

            GameObjectLoad load = self.AddChild<GameObjectLoad>(true);
            load.Path = path;
            load.FormId = formId;
            load.LoadHandler = action;
            self.LoadingList.Insert(0, load);
            self.AddTimer();
        }

        public static void RecoverGameObject(this GameObjectPoolComponent self, string path, GameObject gameObject, bool active = false)
        {
            if (string.IsNullOrEmpty(path) || gameObject == null)
            {
                return;
            }

            if (SettingData.UsePool)
            {
                if (!self.ExternalReferences.ContainsKey(path))
                {
                    self.ExternalReferences[path] = new List<GameObject>();
                }

                self.ExternalReferences[path].Add(gameObject);
                gameObject.SetActive(active);
                gameObject.transform.SetParent(self.Root().GetComponent<GlobalComponent>().PoolRoot);
                if (self.ExternalReferences[path].Count > 300)
                {
                    Log.Error($"GameObjectPoolError: {path}:  count:{self.ExternalReferences[path].Count}");
                }
            }
            else
            {
                GameObject.Destroy(gameObject);
            }
        }

        public static void AddTimer(this GameObjectPoolComponent self)
        {
            if (self.Timer == 0)
            {
                self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.GameObjectPoolTimer, self);
            }
        }

        public static string ToString2(this GameObjectPoolComponent self)
        {
            StringBuilder sb = new StringBuilder();

            List<string> paths = self.ExternalReferences.Keys.ToList();
            for (int i = paths.Count - 1; i >= 0; i--)
            {
                List<GameObject> gameObjects;
                self.ExternalReferences.TryGetValue(paths[i], out gameObjects);
                if (gameObjects == null)
                {
                    continue;
                }

                sb.Append($"{paths[i]}:{gameObjects.Count}");
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public static void DisposeAll(this GameObjectPoolComponent self)
        {
            Log.Warning($"DisposeAll: {Time.time}");

            List<string> paths = self.ExternalReferences.Keys.ToList();
            for (int i = paths.Count - 1; i >= 0; i--)
            {
                List<GameObject> gameObjects;
                self.ExternalReferences.TryGetValue(paths[i], out gameObjects);
                if (gameObjects == null || gameObjects.Count == 0)
                {
                    continue;
                }

                for (int k = 0; k < gameObjects.Count; k++)
                {
                    if (gameObjects[k] != null)
                    {
                        GameObject.Destroy(gameObjects[k]);
                    }

                    // ResourcesComponent.Instance.LoadAssetSync<GameObject>.UnLoadAsset(paths[i]);
                }

                self.ExternalReferences.Remove(paths[i]);
            }

            Resources.UnloadUnusedAssets();
            GC.Collect();
        }
    }
}