using System.Collections.Generic;
using HighlightPlus;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ET.Client
{
    [FriendOf(typeof(ChangeEquipHelper))]
    [EntitySystemOf(typeof(ES_ModelShow))]
    [FriendOf(typeof(ES_ModelShow))]
    public static partial class ES_ModelShowSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ModelShow self, Transform transform)
        {
            self.uiTransform = transform;

            self.Camera = self.EG_RootRectTransform.transform.Find("Camera");
            self.ModelParent = self.EG_RootRectTransform.Find("ModelParent");

            self.AddComponent<ChangeEquipHelper>();
            self.E_RenderButton.AddListener(self.OnRenderButton);
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
            self.ClickHandler?.Invoke();
        }

        public static void SetPosition(this ES_ModelShow self, Vector3 rootPos, Vector3 cameraPos)
        {
            self.EG_RootRectTransform.transform.localPosition = rootPos;
            self.EG_RootRectTransform.transform.Find("Camera").localPosition = cameraPos;
        }

        public static void SetRootPosition(this ES_ModelShow self, Vector3 vector3)
        {
            self.EG_RootRectTransform.transform.localPosition = vector3;
        }

        public static void SetModelRotation(this ES_ModelShow self, Quaternion quaternion)
        {
            self.EG_RootRectTransform.transform.Find("ModelParent").localRotation = quaternion;
        }

        public static void SetCameraPosition(this ES_ModelShow self, Vector3 vector3)
        {
            self.EG_RootRectTransform.transform.Find("Camera").localPosition = vector3;
        }

        public static void RemoveModel(this ES_ModelShow self)
        {
            if (self.Model != null)
            {
                for (int i = 0; i < self.Model.Count; i++)
                {
                    UnityEngine.Object.Destroy(self.Model[i]);
                }
            }

            self.Model.Clear();
        }

        public static void ChangeWeapon(this ES_ModelShow self, ItemInfo bagInfo, int occ)
        {
            self.GetComponent<ChangeEquipHelper>().ChangeWeapon(self.GetWeaponId(bagInfo, occ));
        }

        public static void ShowPlayerModel(this ES_ModelShow self, ItemInfo bagInfo, int occ, int equipIndex, List<int> fashionids,
        bool canDrag = true)
        {
            self.RemoveModel();

            self.E_RenderEventTrigger.triggers.Clear();
            if (canDrag)
            {
                self.E_RenderEventTrigger.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.PointerDown(pdata as PointerEventData); });
                self.E_RenderEventTrigger.RegisterEvent(EventTriggerType.Drag, (pdata) => { self.Drag(pdata as PointerEventData); });
                self.E_RenderEventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.PointerUp(pdata as PointerEventData); });
            }

            self.ReSetTexture();

            using (zstring.Block())
            {
                string path = ABPathHelper.GetUnitPath(zstring.Format("Player/{0}", OccupationConfigCategory.Instance.Get(occ).ModelAsset));
                GameObject prefab = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);

                GameObject go = UnityEngine.Object.Instantiate(prefab, self.ModelParent, true);
                ChangeEquipHelper changeEquipHelper = self.GetComponent<ChangeEquipHelper>();
                changeEquipHelper.WeaponId = self.GetWeaponId(bagInfo, occ);
                changeEquipHelper.EquipIndex = equipIndex;
                changeEquipHelper.UseLayer = true;
                changeEquipHelper.LoadEquipment(go, fashionids, occ);
                Animator animator = go.GetComponentInChildren<Animator>();
                if (animator != null)
                {
                    animator.Play("ShowIdel");
                }

                LayerHelp.ChangeLayerAll(go.transform, LayerEnum.RenderTexture);
                go.transform.localScale = Vector3.one;
                go.transform.localPosition = Vector3.zero;
                go.transform.localEulerAngles = Vector3.zero;

                self.Model.Add(go);
            }
        }

        public static void ShowPlayerPreviewModel(this ES_ModelShow self, ItemInfo bagInfo, List<int> fashionids, int occ, bool canDrag = true)
        {
            self.RemoveModel();

            self.E_RenderEventTrigger.triggers.Clear();
            if (canDrag)
            {
                self.E_RenderEventTrigger.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.PointerDown(pdata as PointerEventData); });
                self.E_RenderEventTrigger.RegisterEvent(EventTriggerType.Drag, (pdata) => { self.Drag(pdata as PointerEventData); });
                self.E_RenderEventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.PointerUp(pdata as PointerEventData); });
            }

            self.ReSetTexture();

            using (zstring.Block())
            {
                var path = ABPathHelper.GetUnitPath(zstring.Format("Player/{0}", OccupationConfigCategory.Instance.Get(occ).ModelAsset));
                GameObject prefab = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                GameObject go = UnityEngine.Object.Instantiate(prefab, self.ModelParent, true);
                ChangeEquipHelper changeEquipHelper = self.GetComponent<ChangeEquipHelper>();
                changeEquipHelper.WeaponId = self.GetWeaponId(bagInfo, occ);
                changeEquipHelper.EquipIndex = 0;
                changeEquipHelper.UseLayer = true;
                changeEquipHelper.LoadEquipment(go, fashionids, occ);

                Animator animator = go.GetComponentInChildren<Animator>();
                if (animator != null)
                {
                    animator.Play("ShowIdel");
                }

                LayerHelp.ChangeLayerAll(go.transform, LayerEnum.RenderTexture);
                go.transform.localScale = Vector3.one;
                go.transform.localPosition = Vector3.zero;
                go.transform.localEulerAngles = Vector3.zero;

                self.Model.Add(go);
            }
        }

        private static int GetWeaponId(this ES_ModelShow self, ItemInfo bagInfo, int occ)
        {
            int weaponId = 0;
            if (bagInfo != null && bagInfo.ItemID != 0)
            {
                weaponId = bagInfo.ItemID;
            }

            return weaponId;
        }

        public static async ETTask ShowOtherModel(this ES_ModelShow self, string assetPath, bool isPet = false, bool canDrag = true)
        {
            self.RemoveModel();
            self.ModelParent.transform.localEulerAngles = Vector3.zero;
            self.E_RenderEventTrigger.triggers.Clear();
            if (canDrag)
            {
                self.E_RenderEventTrigger.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.PointerDown(pdata as PointerEventData); });
                self.E_RenderEventTrigger.RegisterEvent(EventTriggerType.Drag, (pdata) => { self.Drag(pdata as PointerEventData); });
                self.E_RenderEventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.PointerUp(pdata as PointerEventData); });
            }

            self.ReSetTexture();

            string path = ABPathHelper.GetUnitPath(assetPath);
            GameObject prefab = await self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(path);
            if (prefab == null)
            {
                using (zstring.Block())
                {
                    Log.Error(zstring.Format("prefab == null: {0}", path));
                }
            }

            GameObject go = UnityEngine.Object.Instantiate(prefab, self.ModelParent, true);
            LayerHelp.ChangeLayerAll(go.transform, LayerEnum.RenderTexture);

            go.transform.localScale = Vector3.one;
            go.transform.localPosition = Vector3.zero;
            go.transform.localEulerAngles = new Vector3(0, self.RotationY, 0);

            if (isPet)
            {
                Animator[] animator = go.GetComponentsInChildren<Animator>();
                for (int i = 0; i < animator.Length; i++)
                {
                    animator[i].Play(RandomHelper.RandFloat01() >= 0.5 ? "Skill_1" : "Skill_2");
                }
            }

            self.Model.Add(go);
        }

        public static async ETTask ShowModelList(this ES_ModelShow self, string initpath, List<string> assetPath)
        {
            self.RemoveModel();
            long instanceId = self.InstanceId;

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < assetPath.Count; i++)
            {
                var path = ABPathHelper.GetUnitPath(initpath + assetPath[i]);
                GameObject prefab = await resourcesLoaderComponent.LoadAssetAsync<GameObject>(path);
                if (instanceId != self.InstanceId)
                {
                    return;
                }

                GameObject go = UnityEngine.Object.Instantiate(prefab, self.ModelParent, true);
                LayerHelp.ChangeLayerAll(go.transform, LayerEnum.RenderTexture);
                go.transform.SetParent(self.ModelParent);
                go.transform.localScale = Vector3.one;
                go.transform.localPosition = Vector3.zero;
                go.transform.localEulerAngles = Vector3.zero;

                self.Model.Add(go);
            }
        }

        public static void ReSetTexture(this ES_ModelShow self)
        {
            if (self.RenderTexture != null)
            {
                self.RenderTexture.Release();
            }

            RenderTexture renderTexture = new RenderTexture(512, 512, 16, RenderTextureFormat.ARGB32);
            renderTexture.Create();
            self.RenderTexture = renderTexture;
            self.E_RenderRawImage.texture = renderTexture;
            self.EG_RootRectTransform.transform.Find("Camera").GetComponent<Camera>().targetTexture = renderTexture;
        }

        public static void PlayShowIdelAnimate(this ES_ModelShow self)
        {
            if (self.Model.Count == 0)
            {
                return;
            }

            Animator animator = self.Model[0].GetComponentInChildren<Animator>();
            if (animator != null)
            {
                animator.Play("ShowIdel");
            }
        }

        public static void SetShow(this ES_ModelShow self, bool isShow)
        {
            self.uiTransform.gameObject.SetActive(isShow);
        }
        public static void OnRenderButton(this ES_ModelShow self)
        {
        }

        public static void SetHighlight(this ES_ModelShow self, bool isHighlight)
        {
            if (self.Model.Count == 0)
            {
                return;
            }

            foreach (GameObject gameObject in self.Model)
            {
                HighlightEffect effect = gameObject.GetComponent<HighlightEffect>();
                if (effect == null)
                {
                    effect = gameObject.AddComponent<HighlightEffect>();

                    // 一些物体不用高亮描边
                    effect.excludeNameFilter = new[] { "BackDi" };
                    
                    // 描边
                    effect.outline = 1;
                    effect.outlineColor = new Color(255f, 235f, 0f, 255f);
                    effect.outlineWidth = 1.5f;

                    // 发出微弱的光
                    effect.glow = 1f;
                    effect.glowWidth = 0.2f;
                    effect.SetGlowColor(new Color(255f, 235f, 0f, 255f));
                    effect.glowDownsampling = 1;
                    effect.glowAnimationSpeed = 1f;
                    
                    effect.innerGlow = 0.5f;
                    effect.innerGlowColor = new Color(1f, 1f, 1f, 1f);
                    effect.innerGlowWidth = 1f;
                    
                    // 表面的颜色
                    effect.overlay = 0.1f;
                    effect.overlayColor = new Color(255f, 235f, 0f, 255f);
                    
                    effect.UpdateMaterialProperties();
                }

                effect.SetHighlighted(isHighlight);
            }
        }
    }
}
