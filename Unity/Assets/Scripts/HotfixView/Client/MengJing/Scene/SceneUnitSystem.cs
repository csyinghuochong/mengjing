using UnityEngine;

namespace ET.Client
{

    [EntitySystemOf(typeof(SceneUnit))]
    [FriendOf(typeof(SceneUnit))]
    public static partial class SceneUnitSystem
    {


        public static void InitSceneUnit(this SceneUnit self, string name, string parentname, string prefabname, string tag, string layer, Vector3 pos, Vector3 rot, Vector3 scale)
        {
            self.Name = name;
            self.Parentname = parentname;
            self.Prefabname = prefabname;
            self.Tag = tag;
            self.Layer = layer;
            self.Position = pos;
            self.Rotation = rot;
            self.Scale = scale;

            self.State = LoadState.None;
            self.Go = null;
            self.ParentGo = null;
        }

        public static void Type(this SceneUnit self)
        {

        }
        [EntitySystem]
        private static void Awake(this ET.Client.SceneUnit self)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Client.SceneUnit self)
        {

        }
    }
}