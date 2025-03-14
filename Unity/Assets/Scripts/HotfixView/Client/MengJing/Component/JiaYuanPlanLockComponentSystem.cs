using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (JiaYuanPlanLockComponent))]
    [EntitySystemOf(typeof (JiaYuanPlanLockComponent))]
    public static partial class JiaYuanPlanLockComponentSystem
    {
        [EntitySystem]
        private static void Awake(this JiaYuanPlanLockComponent self, GameObject gameObject)
        {
            self.HeadBar = null;
            self.GameObject = gameObject;
            self.UICamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            self.MainCamera = self.Root().GetComponent<GlobalComponent>().MainCamera.GetComponent<Camera>();
        }

        [EntitySystem]
        private static void Destroy(this JiaYuanPlanLockComponent self)
        {
            if (self.HeadBar != null)
            {
                UnityEngine.Object.Destroy(self.HeadBar);
                self.HeadBar = null;
            }

            if (self.PlanEffectObj != null)
            {
                self.Root().GetComponent<GameObjectLoadComponent>().RecoverGameObject(self.PlanEffectPath, self.PlanEffectObj, false);
                self.PlanEffectObj = null;
            }
        }

        public static void SetOpenState(this JiaYuanPlanLockComponent self, int index, bool open)
        {
            self.CellIndex = index;
            if (self.HeadBar != null)
            {
                UnityEngine.Object.Destroy(self.HeadBar);
                self.HeadBar = null;
            }

            if (open)
            {
                self.InitEffect();
            }
            else
            {
                self.InitHeadBar();
            }
        }

        public static void InitEffect(this JiaYuanPlanLockComponent self)
        {
            self.PlanEffectPath = ABPathHelper.GetEffetPath("ScenceEffect/Eff_JiaYuan_Active");
            self.Root().GetComponent<GameObjectLoadComponent>().AddLoadQueue( self.PlanEffectPath, self.InstanceId,true, self.OnLoadEffect);
        }

        public static void OnLoadEffect(this JiaYuanPlanLockComponent self, GameObject go, long formId)
        {
            if (self.IsDisposed)
            {
                UnityEngine.Object.Destroy(go);
                return;
            }

            self.PlanEffectObj = go;
            CommonViewHelper.SetParent(go, self.Root().GetComponent<GlobalComponent>().Unit.gameObject);
            go.transform.localPosition = ConfigData.PlanPositionList[self.CellIndex];
            go.transform.localScale = Vector3.one;
            go.SetActive(true);
        }

        public static void InitHeadBar(this JiaYuanPlanLockComponent self)
        {
            self.UIPosition = self.GameObject.transform;
            string path = ABPathHelper.GetUGUIPath("Blood/UISceneItem");
            GameObject prefab = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
            self.HeadBar = UnityEngine.Object.Instantiate(prefab, self.Root().GetComponent<GlobalComponent>().Unit, true);
            self.HeadBar.transform.SetParent(self.Root().GetComponent<GlobalComponent>().NormalRoot);
            self.HeadBar.transform.localScale = Vector3.one;
            self.HeadBarUI = self.HeadBar.GetComponent<HeadBarUI>();
            self.HeadBarUI.enabled = true;
            self.HeadBarUI.HeadPos = self.UIPosition;
            self.HeadBarUI.HeadBar = self.HeadBar;
            self.HeadBar.transform.SetAsFirstSibling();

            self.HeadBar.Get<GameObject>("Lal_Name").GetComponent<Text>().text = "未开启";
            self.HeadBar.Get<GameObject>("Lal_Desc").GetComponent<Text>().text = String.Empty;
        }
    }
}