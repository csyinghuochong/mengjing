using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{

    [EntitySystemOf(typeof(GameObjectLoadComponent))]
    [FriendOf(typeof(GameObjectLoadComponent))]
    public static partial class GameObjectLoadComponentSystem
    {
        
        [Invoke(TimerInvokeType.GameObjectPoolTimer)]
        public class GameObjectPoolTimer: ATimer<GameObjectLoadComponent>
        {
            protected override void Run(GameObjectLoadComponent self)
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
        
        [EntitySystem]
        private static void Awake(this ET.Client.GameObjectLoadComponent self)
        {

        }

        [EntitySystem]
        private static void Destroy(this ET.Client.GameObjectLoadComponent self)
        {

        }

        public static async ETTask<string> PreLoadQueue(this GameObjectLoadComponent self, string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return path;
            }

            if (GameObjectPoolHelper.HaveObject(path))
            {
                return path;
            }

            await  self.LoadAssetSync(path, 0, null);
            return path;
        }

        public static void AddLoadQueue(this GameObjectLoadComponent self, string path, long formId, bool autoActive, Action<GameObject, long> action)
        {
            //Log.Debug($"self.GameObject !=null:  {path}  {formId}");

            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            if (GameObjectPoolHelper.HaveObject(path))
            {
                //Debug.LogError($"资源加载11：  {path}  +   {TimeHelper.ServerNow()}");
                if (action!=null)
                {
                    GameObject gameObject = GameObjectPoolHelper.GetObjectFromPool(path, autoActive);
                    action?.Invoke(gameObject, formId);
                }
                return;
            }


            // GameObjectLoad load = self.AddChild<GameObjectLoad>(true);
            // load.Path = path;
            // load.FormId = formId;
            // load.LoadHandler = action;
            // self.WaitLoadingList.Insert(0, load);
            // self.AddTimer();
            
            //Debug.LogError($"资源加载22：  {path}  +   {TimeHelper.ServerNow()}");
            self.LoadAssetSync(path, formId, action).Coroutine();
        }
        
        public static async ETTask<string> LoadAssetSync(this GameObjectLoadComponent self,  string path, long formId, Action<GameObject, long> action)
        {
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            GameObject prefab = await resourcesLoaderComponent.LoadAssetAsync<GameObject>(path);
            GameObjectPoolHelper.InitPoolFormGamObjectAsync(path, prefab, 3);
            if (action != null)
            {
                GameObject  gameObject = GameObjectPoolHelper.GetObjectFromPool(path);
                action?.Invoke(gameObject, formId);
            }

            return path;
        }
        
         public static void OnUpdate(this GameObjectLoadComponent self)
         {
             // if (self.WaitLoadingList.Count == 0)
             // {
             //     self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
             //     return;
             // }
        
             //int number = Math.Min(self.WaitLoadingList.Count, 10);
             for (int i = self.WaitLoadingList.Count - 1; i>= 0; i-- )
             {
                 GameObjectLoad load = self.WaitLoadingList[i];
                 
                 Debug.Log(($"OnUpdateOnUpdate: {load.Path}"));
                 
                 if (self.LoadingList.Contains(load.Path))
                 {
                     continue;
                 }
                 
                 self.WaitLoadingList.RemoveAt(i);
                 self.LoadGameObject(load).Coroutine();
             }
         }
        
         public static void AddTimer(this GameObjectLoadComponent self)
         {
             if (self.Timer == 0)
             {
                 self.Timer =  self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.GameObjectPoolTimer, self);
                 self.OnUpdate();
             }
         }

         public static async ETTask LoadGameObject(this GameObjectLoadComponent self, GameObjectLoad load)
         {
             string path = load.Path;
                         
             GameObject gameObject = null;
             if (GameObjectPoolHelper.HaveObject(path))
             {
                 //Debug.LogError($"资源加载11：  {path}  +   {TimeHelper.ServerNow()}");
                 gameObject = GameObjectPoolHelper.GetObjectFromPool(path);
                 load.LoadHandler(gameObject, load.FormId);
                 load.Dispose();
                 return;
             }

             if (!self.LoadingList.Contains(load.Path))
             {
                 self.LoadingList.Add(load.Path);
             }
             
             Debug.Log(($"OnUpdateOnUpdate1111: {load.Path}"));
             
             ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
             GameObject prefab = await resourcesLoaderComponent.LoadAssetAsync<GameObject>(path);
             GameObjectPoolHelper.InitPoolFormGamObjectAsync(path, prefab, 3);
             
             Debug.Log(($"OnUpdateOnUpdate22222: {load.Path}"));
             
             self.LoadingList.Remove(load.Path);
             gameObject = GameObjectPoolHelper.GetObjectFromPool(path);
             if (gameObject != null)
             {
                 load.LoadHandler(gameObject, load.FormId);
             }
             load.Dispose();
         }

        public static void RecoverGameObject(this GameObjectLoadComponent self, string path, GameObject gameObject, bool active = false)
        {
            if (string.IsNullOrEmpty(path) || gameObject == null)
            {
                return;
            }

            GameObjectPoolHelper.ReturnObjectToPool(gameObject);
        }

        public static void DisposeUnUse(this GameObjectLoadComponent self)
        {
            Debug.LogWarning($"DisposeUnUse: {Time.time}");
            
            List<string> assets = GameObjectPoolHelper.DisposeUnUse();
            foreach (var VARIABLE in assets)
            {
                self.Root().GetComponent<ResourcesLoaderComponent>().UnLoadAsset(VARIABLE);
                
                Debug.LogWarning($"DisposeUnUse :  {VARIABLE}");
            }
        }

        public static void DisposeAll(this GameObjectLoadComponent self)
        {
            Debug.LogWarning($"DisposeAll: {Time.time}");
            
            List<string> assets = GameObjectPoolHelper.DisposeAll();
            foreach (var VARIABLE in assets)
            {
                self.Root().GetComponent<ResourcesLoaderComponent>().UnLoadAsset(VARIABLE);
                
                Debug.LogWarning($"DisposeAll: {VARIABLE}");
            }
        }
    }
}