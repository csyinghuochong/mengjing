using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (FlyTipComponent))]
    [EntitySystemOf(typeof (FlyTipComponent))]
    public static partial class FlyTipComponentSystem
    {
        [EntitySystem]
        private static void Awake(this FlyTipComponent self)
        {
            self.OnAwake().Coroutine();
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

        private static async ETTask OnAwake(this FlyTipComponent self)
        {
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();

            GameObject flyTip = await resourcesLoaderComponent.LoadAssetAsync<GameObject>($"Assets/Bundles/UI/Other/FlyTip.prefab");
            await GameObjectPoolHelper.InitPoolFormGamObjectAsync(flyTip, 3);

            GameObject flyTipDi = await resourcesLoaderComponent.LoadAssetAsync<GameObject>($"Assets/Bundles/UI/Other/FlyTipDi.prefab");
            await GameObjectPoolHelper.InitPoolFormGamObjectAsync(flyTipDi, 3);
        }

        public static async ETTask SpawnFlyTip(this FlyTipComponent self, Vector3 startPos, string str)
        {
            GameObject FlyTipGO = GameObjectPoolHelper.GetObjectFromPool("FlyTip");
            FlyTipGO.transform.SetParent(self.Root().GetComponent<GlobalComponent>().PopUpRoot);
            self.FlyTips.Add(FlyTipGO);
            FlyTipGO.SetActive(true);

            FlyTipGO.GetComponentInChildren<Text>().text = str;
            FlyTipGO.transform.GetComponent<RectTransform>().localPosition = startPos;
            FlyTipGO.transform.GetComponent<RectTransform>().localScale = Vector3.one;

            FlyTipGO.transform.GetComponent<RectTransform>().DOMoveY(startPos.y + 4f, 1f).SetEase(Ease.OutQuad).onComplete = () =>
            {
                FlyTipGO.SetActive(false);
                self.FlyTips.Remove(FlyTipGO);
                GameObjectPoolHelper.ReturnObjectToPool(FlyTipGO);
            };
            await ETTask.CompletedTask;
        }

        public static async ETTask SpawnFlyTipDi(this FlyTipComponent self, Vector3 startPos, string str)
        {
            GameObject FlyTipDiGO = GameObjectPoolHelper.GetObjectFromPool("FlyTipDi");
            FlyTipDiGO.transform.SetParent(self.Root().GetComponent<GlobalComponent>().PopUpRoot);
            self.FlyTips.Add(FlyTipDiGO);
            FlyTipDiGO.SetActive(true);

            FlyTipDiGO.GetComponentInChildren<Text>().text = str;
            FlyTipDiGO.transform.GetComponent<RectTransform>().localPosition = startPos;
            FlyTipDiGO.transform.GetComponent<RectTransform>().localScale = Vector3.one;

            FlyTipDiGO.transform.GetComponent<RectTransform>().DOMoveY(startPos.y + 4f, 1f).SetEase(Ease.OutQuad).onComplete = () =>
            {
                FlyTipDiGO.SetActive(false);
                self.FlyTips.Remove(FlyTipDiGO);
                GameObjectPoolHelper.ReturnObjectToPool(FlyTipDiGO);
            };
            await ETTask.CompletedTask;
        }
    }
}