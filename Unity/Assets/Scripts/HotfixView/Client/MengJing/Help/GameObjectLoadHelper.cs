using System;
using UnityEngine;

namespace ET.Client
{
    public static class GameObjectLoadHelper
    {
        public static void AddLoadQueue(Scene root, string path, long formId, Action<GameObject, long> action)
        {
            Log.Debug($"self.GameObject !=null:  {path}  {formId}");
            
            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            if (GameObjectPoolHelper.HaveObject(path))
            {
                GameObject gameObject = GameObjectPoolHelper.GetObjectFromPool(path);
                action(gameObject, formId);
                return;
            }

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

        public static void DisposeAll()
        {
            Log.Warning($"DisposeAll: {Time.time}");

            // GameObjectPoolHelper.DisposeAll();
            //Resources.UnloadUnusedAssets();
            //GC.Collect();
        }
    }
}