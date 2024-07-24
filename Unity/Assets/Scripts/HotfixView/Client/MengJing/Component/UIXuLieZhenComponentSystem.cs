using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(UIXuLieZhenComponent))]
    [FriendOf(typeof(UIXuLieZhenComponent))]
    public static partial class UIXuLieZhenComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIXuLieZhenComponent self, GameObject gameObject)
        {
            self.GameObject = gameObject;
        }

        [EntitySystem]
        private static void Destroy(this UIXuLieZhenComponent self)
        {
        }

        public static async ETTask OnUpdateTitle(this UIXuLieZhenComponent self, int titleId)
        {
            if (titleId <= 0)
            {
                self.GameObject.SetActive(false);
                return;
            }

            self.GameObject.SetActive(true);
            self.XuLieZhen = self.GameObject.GetComponent<XuLieZhen>();
            if (self.XuLieZhen == null)
            {
                self.XuLieZhen = self.GameObject.AddComponent<XuLieZhen>();
            }

            TitleConfig titleConfig = TitleConfigCategory.Instance.Get(titleId);

            long instanceId = self.InstanceId;
            List<Sprite> Sprites = new List<Sprite>();
            for (int i = 0; i < titleConfig.AnimatorNumber; i++)
            {
                using (zstring.Block())
                {
                    var path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ChengHaoIcon, zstring.Format("{0}/{1}", 10001, i + 1));
                    Sprite sprite = await self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<Sprite>(path);
                    if (instanceId != self.InstanceId)
                    {
                        return;
                    }

                    if (i == 0)
                    {
                        self.XuLieZhen.SetSize(sprite, Vector2.one * (float)titleConfig.size,
                            new Vector3((float)titleConfig.MoveX, 75 + (float)titleConfig.MoveY, self.GameObject.transform.localPosition.z));
                        self.XuLieZhen.Index = 0;
                    }

                    Sprites.Add(sprite);
                }
            }

            self.XuLieZhen.SetSprites(Sprites);
        }
    }
}