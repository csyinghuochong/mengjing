using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    public static class GameObjectLoadHelper
    {
        public static void AddLoadQueue(Scene root, string path, long formId, Action<GameObject, long> action)
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
            LoadAssetSync(root, path, formId, action).Coroutine();
        }

        public static async ETTask LoadAssetSync(Scene root, string path, long formId, Action<GameObject, long> action)
        {
            ResourcesLoaderComponent resourcesLoaderComponent = root.GetComponent<ResourcesLoaderComponent>();
            GameObject prefab = await resourcesLoaderComponent.LoadAssetAsync<GameObject>(path);
            await GameObjectPoolHelper.InitPoolFormGamObjectAsync(path, prefab, 3);
            GameObject gameObject = GameObjectPoolHelper.GetObjectFromPool(path);
            
            if (gameObject != null)
            {
                action(gameObject, formId);
                return;
            }
        }

        public static void RecoverGameObject(string path, GameObject gameObject, bool active = false)
        {
            if (string.IsNullOrEmpty(path) || gameObject == null)
            {
                return;
            }

            GameObjectPoolHelper.ReturnObjectToPool(gameObject);
        }

        public static void DisposeUnUse(Scene root)
        {
            Log.Warning($"DisposeUnUse: {Time.time}");

            List<string> assets = GameObjectPoolHelper.DisposeUnUse();
            foreach (var VARIABLE in assets)
            {
                root.GetComponent<ResourcesLoaderComponent>().UnLoadAsset(VARIABLE);
            }
        }
        
        public static void DisposeAll(Scene root)
        {
            Log.Warning($"DisposeAll: {Time.time}");

            List<string> assets = GameObjectPoolHelper.DisposeAll();
            foreach (var VARIABLE in assets)
            {
                root.GetComponent<ResourcesLoaderComponent>().UnLoadAsset(VARIABLE);
            }
            
        }
    }
}