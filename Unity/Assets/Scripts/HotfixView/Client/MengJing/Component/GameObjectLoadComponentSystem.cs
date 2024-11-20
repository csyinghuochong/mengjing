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
        
        public static void AddLoadQueue(this GameObjectLoadComponent self, string path, long formId, Action<GameObject, long> action)
        {
            //Log.Debug($"self.GameObject !=null:  {path}  {formId}");

            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            if (GameObjectPoolHelper.HaveObject(path))
            {
                //Debug.LogError($"资源加载11：  {path}  +   {TimeHelper.ServerNow()}");
                GameObject gameObject = GameObjectPoolHelper.GetObjectFromPool(path);
                action(gameObject, formId);
                return;
            }

            //Debug.LogError($"资源加载22：  {path}  +   {TimeHelper.ServerNow()}");
            //LoadAssetSync(path, formId, action).Coroutine();
            
            GameObjectLoad load = self.AddChild<GameObjectLoad>(true);
            load.Path = path;
            load.FormId = formId;
            load.LoadHandler = action;
            self.WaitLoadingList.Insert(0, load);
            self.AddTimer();
        }
        
         public static void OnUpdate(this GameObjectLoadComponent self)
         {
             if (self.WaitLoadingList.Count == 0)
             {
                 self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
                 return;
             }
        
             int number = Math.Max(self.WaitLoadingList.Count - 4, 0);
             for (int i = self.WaitLoadingList.Count - 1; i>= number; i-- )
             {
                 GameObjectLoad load = self.WaitLoadingList[i];
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
             ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
             GameObject prefab = await resourcesLoaderComponent.LoadAssetAsync<GameObject>(path);
             await GameObjectPoolHelper.InitPoolFormGamObjectAsync(path, prefab, 3);
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

            List<string> assets = GameObjectPoolHelper.DisposeUnUse();
            foreach (var VARIABLE in assets)
            {
                self.Root().GetComponent<ResourcesLoaderComponent>().UnLoadAsset(VARIABLE);
            }
        }

        public static void DisposeAll(this GameObjectLoadComponent self)
        {
            Log.Warning($"DisposeAll: {Time.time}");

            List<string> assets = GameObjectPoolHelper.DisposeAll();
            foreach (var VARIABLE in assets)
            {
                self.Root().GetComponent<ResourcesLoaderComponent>().UnLoadAsset(VARIABLE);
            }
        }
    }
}