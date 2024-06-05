using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (ChangeEquipComponent))]
    [EntitySystemOf(typeof (ES_ModelShow))]
    [FriendOf(typeof (ES_ModelShow))]
    public static partial class ES_ModelShowSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ModelShow self, Transform transform)
        {
            self.uiTransform = transform;

            self.ModelParent = self.EG_RootRectTransform.Find("ModelParent");

            self.AddComponent<ChangeEquipComponent>();
        }

        [EntitySystem]
        private static void Destroy(this ES_ModelShow self)
        {
            self.DestroyWidget();
        }

        private static void PointerDown(this ES_ModelShow self, PointerEventData pdata)
        {
            self.Draged = false;
            self.StartPosition = pdata.position;
        }

        private static void Drag(this ES_ModelShow self, PointerEventData pdata)
        {
            self.Draged = true;
            float eulerY = self.ModelParent.transform.localEulerAngles.y;
            if (pdata.position.x > self.StartPosition.x)
            {
                self.ModelParent.transform.localEulerAngles = new Vector3(0f, eulerY - 10, 0f);
            }
            else
            {
                self.ModelParent.transform.localEulerAngles = new Vector3(0f, eulerY + 10, 0f);
            }

            self.StartPosition = pdata.position;
        }

        private static void PointerUp(this ES_ModelShow self, PointerEventData pdata)
        {
            if (self.Draged)
                return;
            // self.ClickHandler?.Invoke();
        }

        public static void SetPosition(this ES_ModelShow self, Vector3 rootPos, Vector3 cameraPos)
        {
            self.EG_RootRectTransform.transform.localPosition = rootPos;
            self.EG_RootRectTransform.transform.Find("Camera").localPosition = cameraPos;
        }

        public static void SetModelPosition(this ES_ModelShow self, Vector3 vector3)
        {
            self.EG_RootRectTransform.transform.Find("ModelParent").localPosition = vector3;
        }

        public static void SetModelRotation(this ES_ModelShow self, Quaternion quaternion)
        {
            self.EG_RootRectTransform.transform.Find("ModelParent").localRotation = quaternion;
        }

        public static void SetCameraPosition(this ES_ModelShow self, Vector3 vector3)
        {
            self.EG_RootRectTransform.transform.Find("Camera").localPosition = vector3;
        }

        public static void ChangeWeapon(this ES_ModelShow self, BagInfo bagInfo, int occ)
        {
            self.GetComponent<ChangeEquipComponent>().ChangeWeapon(self.GetWeaponId(bagInfo, occ));
        }

        public static void ShowPlayerModel(this ES_ModelShow self, BagInfo bagInfo, int occ, int equipIndex, List<int> fashionids,
        bool canDrag = true)
        {
            self.E_RenderEventTrigger.triggers.Clear();
            if (canDrag)
            {
                self.E_RenderEventTrigger.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.PointerDown(pdata as PointerEventData); });
                self.E_RenderEventTrigger.RegisterEvent(EventTriggerType.Drag, (pdata) => { self.Drag(pdata as PointerEventData); });
                self.E_RenderEventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.PointerUp(pdata as PointerEventData); });
            }

            UICommonHelper.DestoryChild(self.ModelParent.gameObject);
            self.UnitModel = null;

            self.ReSetTexture();

            string path = ABPathHelper.GetUnitPath($"Player/{OccupationConfigCategory.Instance.Get(occ).ModelAsset}");
            GameObject prefab = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
            GameObject go = UnityEngine.Object.Instantiate(prefab, self.ModelParent, true);
            ChangeEquipComponent changeEquipComponent = self.GetComponent<ChangeEquipComponent>();
            changeEquipComponent.WeaponId = self.GetWeaponId(bagInfo, occ);
            changeEquipComponent.EquipIndex = equipIndex;
            changeEquipComponent.UseLayer = true;
            changeEquipComponent.LoadEquipment(go, fashionids, occ);
            self.UnitModel = go;
            Animator animator = self.UnitModel.GetComponentInChildren<Animator>();
            if (animator != null)
            {
                animator.Play("ShowIdel");
            }

            LayerHelp.ChangeLayerAll(go.transform, LayerEnum.RenderTexture);
            go.transform.localScale = Vector3.one;
            go.transform.localPosition = Vector3.zero;
            go.transform.localEulerAngles = Vector3.zero;
        }

        private static int GetWeaponId(this ES_ModelShow self, BagInfo bagInfo, int occ)
        {
            int weaponId = 0;
            if (bagInfo != null && bagInfo.ItemID != 0)
            {
                weaponId = bagInfo.ItemID;
            }

            return weaponId;
        }

        public static void ShowPlayerPreviewModel(this ES_ModelShow self, BagInfo bagInfo, List<int> fashionids, int occ, bool canDrag = true)
        {
            self.E_RenderEventTrigger.triggers.Clear();
            if (canDrag)
            {
                self.E_RenderEventTrigger.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.PointerDown(pdata as PointerEventData); });
                self.E_RenderEventTrigger.RegisterEvent(EventTriggerType.Drag, (pdata) => { self.Drag(pdata as PointerEventData); });
                self.E_RenderEventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.PointerUp(pdata as PointerEventData); });
            }

            UICommonHelper.DestoryChild(self.ModelParent.gameObject);
            self.UnitModel = null;

            self.ReSetTexture();

            var path = ABPathHelper.GetUnitPath($"Player/{OccupationConfigCategory.Instance.Get(occ).ModelAsset}");
            GameObject prefab = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
            GameObject go = UnityEngine.Object.Instantiate(prefab, self.ModelParent, true);
            ChangeEquipComponent changeEquipComponent = self.GetComponent<ChangeEquipComponent>();
            changeEquipComponent.WeaponId = self.GetWeaponId(bagInfo, occ);
            changeEquipComponent.EquipIndex = 0;
            changeEquipComponent.UseLayer = true;
            changeEquipComponent.LoadEquipment(go, fashionids, occ);

            self.UnitModel = go;
            Animator animator = self.UnitModel.GetComponentInChildren<Animator>();
            if (animator != null)
            {
                animator.Play("ShowIdel");
            }

            LayerHelp.ChangeLayerAll(go.transform, LayerEnum.RenderTexture);
            go.transform.localScale = Vector3.one;
            go.transform.localPosition = Vector3.zero;
            go.transform.localEulerAngles = Vector3.zero;
        }

        public static async ETTask ShowOtherModel(this ES_ModelShow self, string assetPath, bool isPet = false, bool canDrag = true)
        {
            self.E_RenderEventTrigger.triggers.Clear();
            if (canDrag)
            {
                self.E_RenderEventTrigger.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.PointerDown(pdata as PointerEventData); });
                self.E_RenderEventTrigger.RegisterEvent(EventTriggerType.Drag, (pdata) => { self.Drag(pdata as PointerEventData); });
                self.E_RenderEventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.PointerUp(pdata as PointerEventData); });
            }

            UICommonHelper.DestoryChild(self.ModelParent.gameObject);
            self.UnitModel = null;

            self.ReSetTexture();

            string path = ABPathHelper.GetUnitPath(assetPath);
            GameObject prefab = await self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(path);
            if (prefab == null)
            {
                Log.Error($"prefab == null: {path}");
            }

            GameObject go = UnityEngine.Object.Instantiate(prefab, self.ModelParent, true);
            LayerHelp.ChangeLayerAll(go.transform, LayerEnum.RenderTexture);

            self.UnitModel = go;
            go.transform.localScale = Vector3.one;
            go.transform.localPosition = Vector3.zero;
            go.transform.localEulerAngles = Vector3.zero;

            if (isPet)
            {
                Animator animator = go.GetComponentInChildren<Animator>();
                animator.Play(RandomHelper.RandFloat01() >= 0.5? "Skill_1" : "Skill_2");
            }
        }

        public static void ReSetTexture(this ES_ModelShow self)
        {
            RenderTexture renderTexture = new RenderTexture(512, 512, 16, RenderTextureFormat.ARGB32);
            renderTexture.Create();
            self.E_RenderRawImage.texture = renderTexture;
            self.EG_RootRectTransform.transform.Find("Camera").GetComponent<Camera>().targetTexture = renderTexture;
        }

        public static void PlayShowIdelAnimate(this ES_ModelShow self)
        {
            if (self.UnitModel == null)
                return;
            Animator animator = self.UnitModel.GetComponentInChildren<Animator>();
            if (animator != null)
            {
                animator.Play("ShowIdel");
            }
        }

        public static void SetShow(this ES_ModelShow self, bool isShow)
        {
            self.uiTransform.gameObject.SetActive(isShow);
        }
    }
}