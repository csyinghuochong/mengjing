using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_Loading))]
    [FriendOfAttribute(typeof (ES_Loading))]
    public static partial class ES_LoadingSystem
    {
        [EntitySystem]
        private static void Awake(this ES_Loading self, Transform transform)
        {
            self.uiTransform = transform;
            self.Start = false;
            self.PassTime = 0;
        }

        [EntitySystem]
        private static void Destroy(this ES_Loading self)
        {
            self.DestroyWidget();
        }

        [EntitySystem]
        private static void Update(this ES_Loading self)
        {
            if (!self.Start)
            {
                return;
            }

            self.PassTime += Time.deltaTime;
            self.uiTransform.localRotation = Quaternion.Euler(0f, 0f, self.PassTime * self.Speed);
        }

        public static void StartRotate(this ES_Loading self, bool start)
        {
            self.Start = start;
        }
    }
}