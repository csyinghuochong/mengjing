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
                    self.E_Icon2Image.sprite = self.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, "Image_164"));
                    self.E_BackImage.sprite = self.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, "Image_160"));
                    self.E_Cost_ActiveText.text = ConfigData.PetMeleeMainPetCost.ToString();
                    self.E_Cost_InactiveText.text = ConfigData.PetMeleeMainPetCost.ToString();
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
                    self.E_Icon2Image.sprite = self.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, "Image_163"));
                    self.E_BackImage.sprite = self.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, "Image_157"));
                    self.E_Cost_ActiveText.text = petTuJianConfig.Cost.ToString();
                    self.E_Cost_InactiveText.text = petTuJianConfig.Cost.ToString();
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
                    self.E_Icon2Image.sprite = self.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, "Image_165"));
                    self.E_BackImage.sprite = self.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, "Image_161"));
                    self.E_Cost_ActiveText.text = petMagicCardConfig.Cost.ToString();
                    self.E_Cost_InactiveText.text = petMagicCardConfig.Cost.ToString();
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

        public static void UpdateCostText(this ES_PetMeleeCard self, int cost)
        {
            int myCost = int.Parse(self.E_Cost_ActiveText.text);
            self.E_Cost_ActiveText.gameObject.SetActive(myCost <= cost);
            self.E_Cost_InactiveText.gameObject.SetActive(myCost > cost);
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
            switch (self.PetMeleeCardInfo.Type)
            {
                case (int)PetMeleeCarType.MainPet:
                case (int)PetMeleeCarType.AssistPet:
                {
                    self.uiTransform.localScale = new Vector3(1.1f, 1.1f, 1f);
                    break;
                }
                case (int)PetMeleeCarType.Magic:
                {
                    PetMagicCardConfig petMagicCardConfig = PetMagicCardConfigCategory.Instance.Get(self.PetMeleeCardInfo.ConfigId);
                    SkillConfig skillConfig = SkillConfigCategory.Instance.Get(petMagicCardConfig.SkillId);
                    if (skillConfig.SkillZhishiType == SkillZhishiType.Position)
                    {
                        if ((float)skillConfig.DamgeRange[0] >= self.MaxDamageRange)
                        {
                            // 伤害范围半径覆盖整个场景，卡牌直接拖动
                            self.StartPos = self.uiTransform.localPosition;
                            self.uiTransform.localScale = new Vector3(0.75f, 0.75f, 1f);
                        }
                        else
                        {
                            self.uiTransform.localScale = new Vector3(1.1f, 1.1f, 1f);
                        }
                    }

                    break;
                }
            }

            self.uiTransform.GetComponent<CanvasGroup>().alpha = 0.8f;

            self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.PetMeleeCardTimer, self);

            DlgPetMeleeMain dlgPetMeleeMain = self.GetParent<DlgPetMeleeMain>();
            dlgPetMeleeMain.View.E_CancelCardAreaImage.gameObject.SetActive(true);
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

            DlgPetMeleeMain dlgPetMeleeMain = self.GetParent<DlgPetMeleeMain>();

            switch (self.PetMeleeCardInfo.Type)
            {
                case (int)PetMeleeCarType.MainPet:
                case (int)PetMeleeCarType.AssistPet:
                {
                    GameObject GridCanvas = GameObject.Find("/GridCanvas");
                    GameObject BackgroundImage = GridCanvas.transform.Find("Background Image").gameObject;
                    GameObject CellIndicator = GridCanvas.transform.Find("Cell Indicator").gameObject;

                    if (dlgPetMeleeMain.IsCancelCard)
                    {
                        if (self.GameObject != null)
                        {
                            CellIndicator.SetActive(false);
                            self.GameObject.gameObject.SetActive(false);
                        }

                        return;
                    }

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
                    Collider[] colliders = Physics.OverlapSphere(self.TargetPos, self.CellSize / 2f - 0.2f,
                        1 << LayerMask.NameToLayer(LayerEnum.Obstruct.ToString()));
                    bool haveObstruct = colliders.Length > 0;

                    // 获取所有unit的位置，判断这个格子内是否有unit
                    List<EntityRef<Unit>> units = self.Root().CurrentScene().GetComponent<UnitComponent>().GetAll();
                    bool haveUnit = false;
                    float rightPetX = self.CellSize * -1;
                    foreach (Unit unit in units)
                    {
                        if (PositionHelper.Distance2D(unit.Position, self.TargetPos) < self.CellSize / 2)
                        {
                            haveUnit = true;
                        }

                        if (unit.Type == UnitType.Pet)
                        {
                            rightPetX = unit.Position.x > rightPetX ? unit.Position.x : rightPetX;
                        }
                    }

                    if (!haveObstruct && !haveUnit && self.TargetPos.x <= rightPetX)
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
                    PetMagicCardConfig petMagicCardConfig = PetMagicCardConfigCategory.Instance.Get(self.PetMeleeCardInfo.ConfigId);
                    SkillConfig skillConfig = SkillConfigCategory.Instance.Get(petMagicCardConfig.SkillId);
                    if (skillConfig.SkillZhishiType == SkillZhishiType.Position)
                    {
                        if ((float)skillConfig.DamgeRange[0] >= self.MaxDamageRange)
                        {
                            Vector2 localPoint = new Vector2();
                            RectTransform canvas = self.uiTransform.parent.GetComponent<RectTransform>();
                            Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
                            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, Input.mousePosition, uiCamera, out localPoint);
                            self.uiTransform.localPosition = localPoint;
                        }
                    }

                    if (dlgPetMeleeMain.IsCancelCard)
                    {
                        if (self.GameObject != null)
                        {
                            self.GameObject.gameObject.SetActive(false);
                        }

                        return;
                    }

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
            switch (self.PetMeleeCardInfo.Type)
            {
                case (int)PetMeleeCarType.MainPet:
                case (int)PetMeleeCarType.AssistPet:
                    break;
                case (int)PetMeleeCarType.Magic:
                {
                    PetMagicCardConfig petMagicCardConfig = PetMagicCardConfigCategory.Instance.Get(self.PetMeleeCardInfo.ConfigId);
                    SkillConfig skillConfig = SkillConfigCategory.Instance.Get(petMagicCardConfig.SkillId);
                    if (skillConfig.SkillZhishiType == SkillZhishiType.Position)
                    {
                        if ((float)skillConfig.DamgeRange[0] >= self.MaxDamageRange)
                        {
                            self.uiTransform.localPosition = self.StartPos;
                        }
                    }

                    break;
                }
            }

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

            DlgPetMeleeMain dlgPetMeleeMain = self.GetParent<DlgPetMeleeMain>();

            dlgPetMeleeMain.View.E_CancelCardAreaImage.gameObject.SetActive(false);
            if (dlgPetMeleeMain.IsCancelCard)
            {
                return;
            }

            if (dlgPetMeleeMain.IsDisposeCard)
            {
                dlgPetMeleeMain.DisposeCard(self).Coroutine();
                return;
            }

            if (self.CanPlace)
            {
                dlgPetMeleeMain.UseCard(self, self.TargetPos).Coroutine();
            }
        }
    }
}