using UnityEngine;

namespace ET.Client
{

    [EntitySystemOf(typeof(SceneUnit))]
    [FriendOf(typeof(SceneUnit))]
    public static partial class SceneUnitSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.SceneUnit self)
        {

        }
        
        
        
        [EntitySystem]
        private static void Destroy(this ET.Client.SceneUnit self)
        {
            self.RecoverGameObject();
        }
        
        public static void InitSceneUnit(this SceneUnit self,  string prefabname, string tag, int layer, GameObject parentGo)
        {
            self.Prefabname = ABPathHelper.GetSceneUnitPath(prefabname);
            self.Tag = tag;
            self.Layer = layer;
            self.ParentGo = parentGo;
            self.State = LoadState.None;
        }

        public static void OnLoadGameObject(this SceneUnit self, GameObject go, long formId)
        {
            if (self.IsDisposed|| self.State != LoadState.WillLoad)
            {
                GameObject.Destroy(go);
                return;
            }
            if (self.GameObject != null)
            {
                Log.Error($" self.GameObject !=null:   {self.GameObject.name}    {go.name}   {self.InstanceId}   {formId}");
                return;
            }

            self.GameObject = go;
            self.State = LoadState.Loaded;
            CommonViewHelper.SetParent(go, self.ParentGo);
            go.transform.localPosition = self.Position;
            go.transform.localScale = self.Scale;
            go.transform.rotation = self.Rotation;
        }

        public static void RecoverGameObject(this SceneUnit self)
        {
            self.State = LoadState.WillDetroy;
            if (self.GameObject == null)
            {
                return;
            }
            self.Root().GetComponent<GameObjectLoadComponent>().RecoverGameObject(self.Prefabname, self.GameObject);
            self.GameObject = null;
        }
        
        public static void LoadGameObject(this SceneUnit self)
        {
            if (self.State == LoadState.WillLoad)
            {
                return;
            }

            if (!SettingData.ShowSceneUnit)
            {
                return;
            }

            self.State = LoadState.WillLoad;
            self.Root().GetComponent<GameObjectLoadComponent>().AddLoadQueue(self.Prefabname, self.InstanceId, true,self.OnLoadGameObject);
        }
    }
}