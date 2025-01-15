using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_PetMeleeCard))]
    [FriendOf(typeof(ES_PetMeleeCard))]
    public static partial class ES_PetMeleeCardSystem
    {
        [Invoke(TimerInvokeType.PetMeleeCardTimer)]
        public class ES_PetMeleeCardTimer : ATimer<ES_PetMeleeCard>
        {
            protected override void Run(ES_PetMeleeCard self)
            {
                try
                {
                    self.Drag();
                }
                catch (Exception e)
                {
                    Log.Error(e.ToString());
                }
            }
        }

        [EntitySystem]
        private static void Awake(this ES_PetMeleeCard self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_TouchEventTrigger.RegisterEvent(EventTriggerType.BeginDrag, (pdata) => { self.BeginDrag(pdata as PointerEventData); });
            self.E_TouchEventTrigger.RegisterEvent(EventTriggerType.EndDrag, (pdata) => { self.EndDrag(pdata as PointerEventData); });
        }

        [EntitySystem]
        private static void Destroy(this ES_PetMeleeCard self)
        {
            self.DestroyWidget();
        }

        public static void InitCard(this ES_PetMeleeCard self, PetMeleeCardInfo cardInfo)
        {
            self.uiTransform.GetComponent<CanvasGroup>().alpha = 1f;

            if (!string.IsNullOrEmpty(self.UnitAssetsPath) && self.GameObject != null)
            {
                self.Root().GetComponent<GameObjectLoadComponent>().RecoverGameObject(self.UnitAssetsPath, self.GameObject);
            }

            self.PetMeleeCardInfo = cardInfo;
            self.GameObject = null;
            self.UnitAssetsPath = null;

            switch (self.PetMeleeCardInfo.Type)
            {
                case (int)PetMeleeCarType.MainPet:
                {
                    RolePetInfo rolePetInfo = self.Root().GetComponent<PetComponentC>().GetPetInfoByID(self.PetMeleeCardInfo.PetId);
                    PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);
                    PetSkinConfig petSkinConfig = PetSkinConfigCategory.Instance.Get(rolePetInfo.SkinId);

                    self.E_IconImage.sprite = self.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petSkinConfig.IconID.ToString()));
                    self.E_BackImage.sprite = self.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, "Image_160"));
                    self.E_CostText.text = ConfigData.PetMeleeMainPetCost.ToString();
                    self.E_TypeText.text = "主战卡";
                    self.E_NameText.text = rolePetInfo.PetName;

                    self.UnitAssetsPath = ABPathHelper.GetUnitPath("Pet/" + petSkinConfig.SkinID);

                    break;
                }
                case (int)PetMeleeCarType.AssistPet:
                {
                    PetTuJianConfig petTuJianConfig = PetTuJianConfigCategory.Instance.Get(self.PetMeleeCardInfo.ConfigId);

                    self.E_IconImage.sprite = self.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petTuJianConfig.Icon.ToString()));
                    self.E_BackImage.sprite = self.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, "Image_157"));
                    self.E_CostText.text = petTuJianConfig.Cost.ToString();
                    self.E_TypeText.text = "辅战卡";
                    self.E_NameText.text = petTuJianConfig.Name;

                    self.UnitAssetsPath = ABPathHelper.GetUnitPath("Pet/" + petTuJianConfig.Assets);

                    break;
                }
                case (int)PetMeleeCarType.Magic:
                {
                    PetMagicCardConfig petMagicCardConfig = PetMagicCardConfigCategory.Instance.Get(self.PetMeleeCardInfo.ConfigId);

                    self.E_IconImage.sprite = self.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, petMagicCardConfig.Icon.ToString()));
                    self.E_BackImage.sprite = self.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, "Image_161"));
                    self.E_CostText.text = petMagicCardConfig.Cost.ToString();
                    self.E_TypeText.text = "魔法卡";
                    self.E_NameText.text = petMagicCardConfig.Name;

                    SkillConfig skillConfig = SkillConfigCategory.Instance.Get(petMagicCardConfig.SkillId);
                    if (skillConfig.SkillZhishiType == SkillZhishiType.Position)
                    {
                        self.UnitAssetsPath = ABPathHelper.GetEffetPath("SkillZhishi/Skill_Position");
                    }

                    break;
                }
            }

            if (!string.IsNullOrEmpty(self.UnitAssetsPath))
            {
                self.Root().GetComponent<GameObjectLoadComponent>().AddLoadQueue(self.UnitAssetsPath, self.InstanceId, self.OnLoadGameObject);
            }
        }

        public static void OnLoadGameObject(this ES_PetMeleeCard self, GameObject go, long formId)
        {
            if (self.IsDisposed)
            {
                UnityEngine.Object.Destroy(go);
                return;
            }

            if (self.GameObject != null)
            {
                Log.Error($" self.GameObject !=null:   {self.GameObject.name}    {go.name}   {self.InstanceId}   {formId}");
                return;
            }

            self.GameObject = go;
            self.GameObject.transform.SetParent(GlobalComponent.Instance.Unit);

            switch (self.PetMeleeCardInfo.Type)
            {
                case (int)PetMeleeCarType.MainPet:
                case (int)PetMeleeCarType.AssistPet:
                    self.GameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
                    break;

                case (int)PetMeleeCarType.Magic:
                {
                    PetMagicCardConfig petMagicCardConfig = PetMagicCardConfigCategory.Instance.Get(self.PetMeleeCardInfo.ConfigId);
                    SkillConfig skillConfig = SkillConfigCategory.Instance.Get(petMagicCardConfig.SkillId);
                    if (skillConfig.SkillZhishiType == SkillZhishiType.Position)
                    {
                        float innerRadius = (float)skillConfig.DamgeRange[0] * 2f;
                        self.GameObject.Get<GameObject>("Skill_InnerArea").transform.localScale = Vector3.one * innerRadius;
                        self.GameObject.Get<GameObject>("Skill_Area").SetActive(false);
                    }

                    break;
                }
            }

            self.GameObject.SetActive(false);
        }

        private static void BeginDrag(this ES_PetMeleeCard self, PointerEventData pdata)
        {
            self.uiTransform.GetComponent<CanvasGroup>().alpha = 0.3f;

            self.uiTransform.localScale = new Vector3(1.1f, 1.1f, 1f);

            self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.PetMeleeCardTimer, self);
        }

        private static void Drag(this ES_PetMeleeCard self)
        {
            self.CanPlace = false;

            RaycastHit raycastHit;
            Ray Ray = self.Root().GetComponent<GlobalComponent>().MainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            bool hit = Physics.Raycast(Ray, out raycastHit, 100, 1 << LayerMask.NameToLayer(LayerEnum.Map.ToString()));
            if (!hit)
            {
                return;
            }

            Vector3 hitPoint = raycastHit.point;

            switch (self.PetMeleeCardInfo.Type)
            {
                case (int)PetMeleeCarType.MainPet:
                case (int)PetMeleeCarType.AssistPet:
                {
                    GameObject GridCanvas = GameObject.Find("/GridCanvas");
                    GameObject BackgroundImage = GridCanvas.transform.Find("Background Image").gameObject;
                    GameObject CellIndicator = GridCanvas.transform.Find("Cell Indicator").gameObject;
                    BackgroundImage.SetActive(true);
                    CellIndicator.SetActive(true);

                    float targetX = hitPoint.x;
                    float targetZ = hitPoint.z;
                    float nearestX = Mathf.Round(targetX / self.CellSize) * self.CellSize;
                    float nearestZ = Mathf.Round(targetZ / self.CellSize) * self.CellSize;
                    nearestX = Mathf.Clamp(nearestX, self.CellSize * -4, self.CellSize * 4); // 限制一下放置的范围
                    nearestZ = Mathf.Clamp(nearestZ, self.CellSize * -1, self.CellSize * 1);
                    self.TargetPos = new Vector3(nearestX, 0, nearestZ);
                    CellIndicator.GetComponent<RectTransform>().localPosition = new Vector2(nearestX * 10, nearestZ * 10);

                    // 在点击位置周围发射一个半径为detectionRadius的球形碰撞体，检测是否有场景障碍物
                    Collider[] colliders = Physics.OverlapSphere(self.TargetPos, self.CellSize / 2f,
                        1 << LayerMask.NameToLayer(LayerEnum.Obstruct.ToString()));
                    bool haveObstruct = colliders.Length > 0;

                    // 获取所有unit的位置，判断这个格子内是否有unit
                    List<EntityRef<Unit>> units = self.Root().CurrentScene().GetComponent<UnitComponent>().GetAll();
                    bool haveUnit = false;
                    foreach (Unit unit in units)
                    {
                        if (PositionHelper.Distance2D(unit.Position, self.TargetPos) < self.CellSize / 2)
                        {
                            haveUnit = true;
                            break;
                        }
                    }

                    if (!haveObstruct && !haveUnit)
                    {
                        self.CanPlace = true;
                        CellIndicator.GetComponent<Image>().color = Color.green;
                    }
                    else
                    {
                        CellIndicator.GetComponent<Image>().color = Color.red;
                    }

                    break;
                }
                case (int)PetMeleeCarType.Magic:
                {
                    self.TargetPos = hitPoint;
                    self.CanPlace = true;
                    break;
                }
            }

            if (self.GameObject != null)
            {
                self.GameObject.gameObject.SetActive(true);
                self.GameObject.transform.position = self.TargetPos;
            }
        }

        private static void EndDrag(this ES_PetMeleeCard self, PointerEventData pdata)
        {
            self.uiTransform.GetComponent<CanvasGroup>().alpha = 1f;

            self.uiTransform.localScale = new Vector3(1f, 1f, 1f);

            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);

            GameObject GridCanvas = GameObject.Find("/GridCanvas");
            GameObject BackgroundImage = GridCanvas.transform.Find("Background Image").gameObject;
            GameObject CellIndicator = GridCanvas.transform.Find("Cell Indicator").gameObject;
            BackgroundImage.SetActive(false);
            CellIndicator.SetActive(false);

            if (self.GameObject != null)
            {
                self.GameObject.gameObject.SetActive(false);
            }

            if (!self.CanPlace)
            {
                return;
            }

            self.GetParent<DlgPetMeleeMain>().UseCard(self, self.TargetPos).Coroutine();
        }
    }
}