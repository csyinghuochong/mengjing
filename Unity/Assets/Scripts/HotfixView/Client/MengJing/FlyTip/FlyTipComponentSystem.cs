using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(FlyTipComponent))]
    [EntitySystemOf(typeof(FlyTipComponent))]
    public static partial class FlyTipComponentSystem
    {
        [EntitySystem]
        private static void Awake(this FlyTipComponent self)
        {
            self.OnAwake().Coroutine();
            FlyTipComponent.Instance = self;
        }

        [EntitySystem]
        private static void Destroy(this FlyTipComponent self)
        {
            foreach (GameObject flyTip in self.FlyTips)
            {
                flyTip.transform.DOKill();
                UnityEngine.Object.Destroy(flyTip);
            }

            foreach (GameObject flyTipDi in self.FlyTipDis)
            {
                flyTipDi.transform.DOKill();
                UnityEngine.Object.Destroy(flyTipDi);
            }

            self.FlyTips.Clear();
            self.FlyTipDis.Clear();
        }

        [EntitySystem]
        private static void Update(this FlyTipComponent self)
        {
            # region zstring 测试

            // Profiler.BeginSample("zstring=============concat");
            // for (int i = 0; i < 50000; i++)
            // {
            //     using (zstring.Block())
            //     {
            //         zstring.Concat("abc", 1);
            //     }
            // }
            // Profiler.EndSample();
            //
            // Profiler.BeginSample("string=============concat");
            // string.Concat("abc", 1);
            // Profiler.EndSample();
            //
            // Profiler.BeginSample("cn-zstring=============concat");
            // using (zstring.Block())
            // {
            //     zstring.Concat("abc", 1);
            // }
            // Profiler.EndSample();
            //
            //
            // Profiler.BeginSample("zstring=============format");
            // using (zstring.Block())
            // {
            //     zstring.Format("hello,{0}", 1111);
            // }
            // Profiler.EndSample();
            //
            // Profiler.BeginSample("string=============format");
            // string.Format("hello,{0}", 1111);
            // Profiler.EndSample();
            //
            // Profiler.BeginSample("cn-zstring=============format");
            // using (zstring.Block())
            // {
            //     zstring.Format("hello ,{0}", 1111);
            // }
            // Profiler.EndSample();

            # endregion

            long time = TimeInfo.Instance.ClientNow();

            if (self.FlyTipQueue.Count > 0)
            {
                if (time - self.LastSpawnFlyTipTime >= self.Interval)
                {
                    self.LastSpawnFlyTipTime = time;
                    self.SpawnFlyTip(self.FlyTipQueue.Dequeue());
                }
            }

            if (self.FlyTipDiQueue.Count > 0)
            {
                if (time - self.LastSpawnFlyTipDiTime >= self.Interval)
                {
                    self.LastSpawnFlyTipDiTime = time;
                    self.SpawnFlyTipDi(self.FlyTipDiQueue.Dequeue());
                }
            }
        }

        private static async ETTask OnAwake(this FlyTipComponent self)
        {
            await ETTask.CompletedTask;
        }

        public static void ShowFlyTip(this FlyTipComponent self, string str)
        {
            if (self.FlyTipQueue.Contains(str))
            {
                return;
            }

            self.FlyTipQueue.Enqueue(str);
        }
        
        private static void SpawnFlyTip(this FlyTipComponent self, string str)
        {
            string FlyTip = "Assets/Bundles/UI/Other/FlyTip.prefab";
            long newkey = self.FlyTipStr.Count + 1;
            self.FlyTipStr.Add(newkey, str);
            self.Root().GetComponent<GameObjectLoadComponent>().AddLoadQueue( FlyTip, newkey, true,self.SpawnFlyTip_2);
        }

        private static void SpawnFlyTip_2(this FlyTipComponent self, GameObject FlyTipGO, long formId)
        {
            Vector3 startPos = new(0, -200, 0);
            FlyTipGO.transform.SetParent(self.Root().GetComponent<GlobalComponent>().PopUpRoot);
            self.FlyTips.Add(FlyTipGO);
            FlyTipGO.SetActive(true);
        
            RectTransform rectTransform = FlyTipGO.transform.GetComponent<RectTransform>();
            rectTransform.localPosition = startPos;
            rectTransform.localScale = Vector3.one;
            long instanceid = self.InstanceId;
            rectTransform.DOLocalMoveY(0, 2f).SetEase(Ease.OutQuad).onComplete = () =>
            {
                if (instanceid != self.InstanceId)
                {
                    GameObject.DestroyImmediate(FlyTipGO);
                    return;
                }

                FlyTipGO.SetActive(false);
                self.FlyTips.Remove(FlyTipGO);
                GameObjectPoolHelper.ReturnObjectToPool(FlyTipGO);
            };
        
            Text text = FlyTipGO.GetComponentInChildren<Text>();
            text.text = self.FlyTipStr[formId];
            text.color = Color.white;
            text.DOColor(new Color(255, 255, 255, 0), 2f).SetEase(Ease.OutQuad);
        }
        
        public static void ShowFlyTipDi(this FlyTipComponent self, string str)
        {
            if (self.FlyTipDiQueue.Contains(str))
            {
                return;
            }

            self.FlyTipDiQueue.Enqueue(str);
        }

        private static void SpawnFlyTipDi(this FlyTipComponent self, string str)
        {
            string FlyTip = "Assets/Bundles/UI/Other/FlyTipDi.prefab";
            long newkey = self.FlyTipStr.Count + 1;
            self.FlyTipStr.Add(newkey, str);
            self.Root().GetComponent<GameObjectLoadComponent>().AddLoadQueue( FlyTip, newkey, true,self.SpawnFlyTipDi_2);
        }
        
        private static void SpawnFlyTipDi_2(this FlyTipComponent self, GameObject FlyTipDiGO, long formId)
        {
            Vector3 startPos = new(0, -200, 0);
            FlyTipDiGO.transform.SetParent(self.Root().GetComponent<GlobalComponent>().PopUpRoot);
            self.FlyTipDis.Add(FlyTipDiGO);
            FlyTipDiGO.SetActive(true);

            RectTransform rectTransform = FlyTipDiGO.transform.GetComponent<RectTransform>();
            rectTransform.localPosition = startPos;
            rectTransform.localScale = Vector3.one;
            long instanceid = self.InstanceId;
            rectTransform.GetComponent<RectTransform>().DOMoveY(0, 2f).SetEase(Ease.OutQuad).onComplete = () =>
            {
                if (instanceid != self.InstanceId)
                {
                    GameObject.DestroyImmediate(FlyTipDiGO);
                    return;
                }
                
                FlyTipDiGO.SetActive(false);
                self.FlyTipDis.Remove(FlyTipDiGO);
                GameObjectPoolHelper.ReturnObjectToPool(FlyTipDiGO);
            };

            Text text = FlyTipDiGO.GetComponentInChildren<Text>();
            text.text = self.FlyTipStr[formId];
            text.color = Color.white;
            text.DOColor(new Color(255, 255, 255, 0), 2f).SetEase(Ease.OutQuad);

            Image image = FlyTipDiGO.GetComponentInChildren<Image>();
            image.color = Color.white;
            image.DOColor(new Color(255, 255, 255, 0), 2f).SetEase(Ease.OutQuad);
        }
    }
}