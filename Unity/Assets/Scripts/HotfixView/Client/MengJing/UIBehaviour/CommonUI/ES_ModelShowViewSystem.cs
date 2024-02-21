using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_ModelShow))]
    [FriendOf(typeof (ES_ModelShow))]
    public static partial class ES_ModelShowSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ModelShow self, Transform transform)
        {
            self.uiTransform = transform;

            self.ModelParent = self.EG_RootRectTransform.Find("ModelParent");
            self.E_RenderEventTrigger.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.PointerDown(pdata as PointerEventData); });
            self.E_RenderEventTrigger.RegisterEvent(EventTriggerType.Drag, (pdata) => { self.PointerDown(pdata as PointerEventData); });
            self.E_RenderEventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.PointerUp(pdata as PointerEventData); });
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

        public static void SetPosition(this ES_ModelShow self, Vector3 position1, Vector3 position2)
        {
            self.EG_RootRectTransform.transform.localPosition = position1;
            self.EG_RootRectTransform.transform.Find("Camera").localPosition = position2;
        }

        public static void ShowPlayerModel(this ES_ModelShow self, BagInfo bagInfo, int occ, int equipIndex)
        {
            if (self.UnitModel != null)
            {
                UnityEngine.Object.Destroy(self.UnitModel);
                self.UnitModel = null;
            }

            string path = ABPathHelper.GetUnitPath($"Player/{OccupationConfigCategory.Instance.Get(occ).ModelAsset}");
            GameObject prefab = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
            GameObject go = UnityEngine.Object.Instantiate(prefab, self.ModelParent, true);
            // ChangeEquipHelper changeEquipHelper = self.GetComponent<ChangeEquipHelper>();
            // changeEquipHelper.WeaponId = self.GetWeaponId(bagInfo, occ);
            // changeEquipHelper.EquipIndex = equipIndex;
            // changeEquipHelper.UseLayer = true;
            // changeEquipHelper.LoadEquipment(go, new List<int>(), occ);
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
    }
}