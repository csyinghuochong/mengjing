using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_Singing))]
    [FriendOfAttribute(typeof (ES_Singing))]
    public static partial class ES_SingingSystem
    {
        [EntitySystem]
        private static void Awake(this ES_Singing self, Transform transform)
        {
            self.uiTransform = transform;
        }

        [EntitySystem]
        private static void Destroy(this ES_Singing self)
        {
            self.DestroyWidget();
        }

        public static void OnTimer(this ES_Singing self, SingingUpdate args)
        {
            if (args.TotalTime <= 0)
            {
                self.uiTransform.gameObject.SetActive(false);
                return;
            }

            if (args.Type == 1)
            {
                self.E_Img_ProgressImage.transform.localScale = new Vector3((1f * args.PassTime / args.TotalTime), 1f, 1f);
            }
            else
            {
                self.E_Img_ProgressImage.transform.localScale = new Vector3((1f - 1f * args.PassTime / args.TotalTime), 1f, 1f);
            }

            if (args.PassTime <= 100)
            {
                self.uiTransform.gameObject.SetActive(true);
            }

            if (args.PassTime >= args.TotalTime || args.PassTime <= -1)
            {
                self.uiTransform.gameObject.SetActive(false);
            }
        }
    }
}
