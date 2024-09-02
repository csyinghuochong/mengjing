using System;
using UnityEngine;

namespace ET.Client
{
    [Invoke(TimerInvokeType.UIDigTreasureTimer)]
    public class UIDigTreasureTimer : ATimer<ES_DigTreasure>
    {
        protected override void Run(ES_DigTreasure self)
        {
            try
            {
                self.OnTimer();
            }
            catch (Exception e)
            {
                Log.Error($"move timer error: {self.Id}\n{e}");
            }
        }
    }

    [EntitySystemOf(typeof(ES_DigTreasure))]
    [FriendOfAttribute(typeof(ES_DigTreasure))]
    public static partial class ES_DigTreasureSystem
    {
        [EntitySystem]
        private static void Awake(this ES_DigTreasure self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ButtonDigButton.AddListener(self.OnButtonDig);
        }

        [EntitySystem]
        private static void Destroy(this ES_DigTreasure self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            self.DestroyWidget();
        }

        public static void OnInitUI(this ES_DigTreasure self, ItemInfo bagInfo)
        {
            self.BagInfo = bagInfo;
            self.uiTransform.gameObject.SetActive(true);
            float size = RandomHelper.RandFloat01();
            self.E_Img_PosImage.transform.localPosition = new Vector3(size * 300f, 0f, 0f);
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.UIDigTreasureTimer, self);
        }

        public static void OnButtonDig(this ES_DigTreasure self)
        {
            float distance = Vector3.Distance(self.E_Img_ChanZiImage.transform.localPosition, self.E_Img_PosImage.transform.localPosition);
            self.uiTransform.gameObject.SetActive(false);
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            BagClientNetHelper.RequestUseItem(self.Root(), self.BagInfo, distance <= 10f ? "2" : "1").Coroutine();
        }

        public static void OnTimer(this ES_DigTreasure self)
        {
            self.PassTime += Time.deltaTime;
            float posX = self.PassTime * self.MoveSpeed;
            if (posX > 300f)
            {
                posX = 0;
                self.PassTime = 0;
            }

            self.E_Img_ChanZiImage.transform.localPosition = new Vector3(posX, 0f, 0f);
        }
    }
}