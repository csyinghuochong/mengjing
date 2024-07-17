using System;
using ET.Client;

namespace UnityEngine.UI
{
    public interface LoopScrollPrefabSource
    {
        GameObject GetObject(int index);

        void ReturnObject(Transform trans,bool isDestroy = false);
    }
    
    
    
    [Serializable]
    public class LoopScrollPrefabSourceInstance : LoopScrollPrefabSource
    {
        public string prefabName;
        public int poolSize = 5;

        private bool inited = false;
        public virtual GameObject GetObject(int index)
        {
            try
            {
                string poolName = $"Assets/Bundles/UI/Item/{prefabName}.prefab";
                if(!inited)
                {
                    GameObjectPoolHelper.InitPool(poolName, poolSize);
                    inited = true;
                }
                return GameObjectPoolHelper.GetObjectFromPool(poolName);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                return null;
            }
        }
        
        public virtual void ReturnObject(Transform go , bool isDestroy = false)
        {
            try
            {
                if (isDestroy)
                {
                    GameObject.Destroy(go.gameObject);
                }
                else
                {
                    GameObjectPoolHelper.ReturnObjectToPool(go.gameObject);
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
    }
    
}
