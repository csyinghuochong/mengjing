using System.Collections.Generic;
using System.Linq;
using EPOOutline;
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

            self.Camera = self.EG_RootRectTransform.transform.Find("Camera").GetComponent<Camera>();
            self.ModelParent = self.EG_RootRectTransform.Find("ModelParent");

            self.AddComponent<ChangeEquipHelper>();
            self.E_RenderButton.AddListener(self.OnRenderButton);
            
            ES_ModelShow.DisPlayUIIndex += 1;
            if (ES_ModelShow.DisPlayUIIndex >= 100)
            {
                ES_ModelShow.DisPlayUIIndex = 0;
            }
            self.SetRootPosition(new Vector3(0, ES_ModelShow.DisPlayUIIndex * 1000.0f, 0));
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

        public static void SetRootPosition(this ES_ModelShow self, Vector3 vector3)
        {
            self.EG_RootRectTransform.transform.localPosition = vector3;
        }

        public static void SetModelParentPosition(this ES_ModelShow self, Vector3 vector3)
        {
            self.ModelParent.localPosition = vector3;
        }
        
        public static void SetModelParentRotation(this ES_ModelShow self, Quaternion quaternion)
        {
            self.ModelParent.localRotation = quaternion;
        }

        public static void SetCameraPosition(this ES_ModelShow self, Vector3 vector3)
        {
            self.Camera.transform.localPosition = vector3;
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
            
            CommonViewHelper.DestoryChild(self.ModelParent.gameObject);
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

            if (self.Camera.gameObject.GetComponent<Outliner>() == null)
            {
                self.Camera.gameObject.AddComponent<Outliner>();
            }

            foreach (GameObject gameObject in self.Model)
            {
                Outlinable outlinable = gameObject.GetComponent<Outlinable>();
                if (outlinable == null)
                {
                    outlinable = gameObject.AddComponent<Outlinable>();
                
                    MeshRenderer[] meshRenderers = gameObject.GetComponentsInChildren<MeshRenderer>();
                    SkinnedMeshRenderer[] skinnedMeshRenderers = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();

                    string[] excludeNameFilter = new[] { "BackDi", "fake shadow (5)", "Rose_BackDi" };
            
                    foreach (var mr in meshRenderers)
                    {
                        if (excludeNameFilter.Contains(mr.gameObject.name))
                        {
                            continue;
                        }
            
                        outlinable.AddRenderer(mr);
                    }
            
                    foreach (var smr in skinnedMeshRenderers)
                    {
                        if (excludeNameFilter.Contains(smr.gameObject.name))
                        {
                            continue;
                        }
            
                        outlinable.AddRenderer(smr);
                    }
                }
                outlinable.OutlineParameters.Color = new Color(255 / 255f, 235 / 255f, 0 / 255f, 255 / 255f);
                outlinable.OutlineParameters.BlurShift = 0.2f;
                outlinable.OutlineParameters.DilateShift = 0.2f;
            
                outlinable.OutlineParameters.Enabled = isHighlight;
            }
        }
    }
}
