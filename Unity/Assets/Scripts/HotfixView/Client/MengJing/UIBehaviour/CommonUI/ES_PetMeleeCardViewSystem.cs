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

            if (!string.IsNullOrEmpty(self.UnitAssetsPath) && self.UnitGameObject != null)
            {
                self.Root().GetComponent<GameObjectLoadComponent>().RecoverGameObject(self.UnitAssetsPath, self.UnitGameObject);
            }

            self.PetMeleeCardInfo = cardInfo;
            self.UnitGameObject = null;
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
                    PetConfig petTuJianConfig = PetConfigCategory.Instance.Get(self.PetMeleeCardInfo.ConfigId);

                    self.E_IconImage.sprite = self.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petTuJianConfig.HeadIcon.ToString()));
                    self.E_Icon2Image.sprite = self.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, "Image_163"));
                    self.E_BackImage.sprite = self.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, "Image_157"));
                    self.E_Cost_ActiveText.text = GlobalValueConfigCategory.Instance.Get(121).Value;
                    self.E_Cost_InactiveText.text = GlobalValueConfigCategory.Instance.Get(121).Value;
                    self.E_TypeText.text = "辅战卡";
                    self.E_NameText.text = petTuJianConfig.PetName;

                    self.UnitAssetsPath = ABPathHelper.GetUnitPath("Pet/" + petTuJianConfig.PetModel);

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
                    if (skillConfig.SkillTargetType == SkillTargetType.FixedPosition)
                    {
                        self.UnitAssetsPath = ABPathHelper.GetEffetPath("SkillZhishi/Skill_Position");
                    }
                    else if (skillConfig.SkillTargetType == SkillTargetType.TargetOnly)
                    {
                        self.UnitAssetsPath = ABPathHelper.GetEffetPath("SkillZhishi/Skill_TargetOnly");
                    }

                    break;
                }
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

            if (self.UnitGameObject != null)
            {
                Log.Error($" self.GameObject !=null:   {self.UnitGameObject.name}    {go.name}   {self.InstanceId}   {formId}");
                return;
            }

            self.UnitGameObject = go;
            self.UnitGameObject.transform.SetParent(GlobalComponent.Instance.Unit);

            switch (self.PetMeleeCardInfo.Type)
            {
                case (int)PetMeleeCarType.MainPet:
                case (int)PetMeleeCarType.AssistPet:
                    self.UnitGameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
                    break;

                case (int)PetMeleeCarType.Magic:
                {
                    PetMagicCardConfig petMagicCardConfig = PetMagicCardConfigCategory.Instance.Get(self.PetMeleeCardInfo.ConfigId);
                    SkillConfig skillConfig = SkillConfigCategory.Instance.Get(petMagicCardConfig.SkillId);
                    if (skillConfig.SkillTargetType == SkillTargetType.FixedPosition)
                    {
                        float innerRadius = (float)skillConfig.DamgeRange[0] * 2f;
                        self.UnitGameObject.Get<GameObject>("Skill_InnerArea").transform.localScale = Vector3.one * innerRadius;
                        self.UnitGameObject.Get<GameObject>("Skill_Area").SetActive(false);
                    }
                    else if (skillConfig.SkillTargetType == SkillTargetType.TargetOnly)
                    {
                        self.UnitGameObject.Get<GameObject>("Skill_Area").SetActive(false);
                        self.UnitGameObject.Get<GameObject>("Skill_Target").transform.localPosition = Vector3.zero;
                        self.UnitGameObject.Get<GameObject>("Skill_InnerArea").SetActive(false);
                        self.UnitGameObject.Get<GameObject>("Skill_Dir").SetActive(false);
                    }

                    break;
                }
            }

            self.UnitGameObject.SetActive(false);
        }

        private static bool IsShowCardDrag(this ES_PetMeleeCard self, double range)
        {
            // 伤害范围半径覆盖整个场景，或者没有则拖动卡牌的时候卡牌也要跟着鼠标动
            if (range <= 0 || range >= 15)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void BeginDrag(this ES_PetMeleeCard self, PointerEventData pdata)
        {
            if (!string.IsNullOrEmpty(self.UnitAssetsPath) && self.UnitGameObject == null)
            {
                self.Root().GetComponent<GameObjectLoadComponent>().AddLoadQueue(self.UnitAssetsPath, self.InstanceId, true, self.OnLoadGameObject);
            }
            
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
                    if (skillConfig.SkillTargetType == SkillTargetType.FixedPosition)
                    {
                        if (self.IsShowCardDrag(skillConfig.DamgeRange[0]))
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
                    else if (skillConfig.SkillTargetType == SkillTargetType.TargetOnly)
                    {
                        self.uiTransform.localScale = new Vector3(1.1f, 1.1f, 1f);
                    }

                    break;
                }
            }

            self.uiTransform.GetComponent<CanvasGroup>().alpha = 0.8f;

            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
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

            if (self.CardIconGameObject == null)
            {
                self.CardIconGameObject = UnityEngine.Object.Instantiate(self.uiTransform.gameObject, self.uiTransform.parent.parent);
                self.CardIconGameObject.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
                self.CardIconGameObject.GetComponent<CanvasGroup>().alpha = 1f;
                self.CardIconGameObject.GetComponent<CanvasGroup>().blocksRaycasts = false; // 防止拖动到丢弃按钮上时，出现些小问题
            }

            if (dlgPetMeleeMain.IsDisposeCard)
            {
                // 在丢弃按钮位置显示一个卡牌Icon
                self.CardIconGameObject.SetActive(true);
                self.UpdateCardIconGOPos();
            }
            else
            {
                if (self.CardIconGameObject != null)
                {
                    self.CardIconGameObject.SetActive(false);
                }
            }

            switch (self.PetMeleeCardInfo.Type)
            {
                case (int)PetMeleeCarType.MainPet:
                case (int)PetMeleeCarType.AssistPet:
                {
                    GameObject GridCanvas = GameObject.Find("/GridCanvas");
                    GameObject BackgroundImage = GridCanvas.transform.Find("Background Image").gameObject;
                    GameObject CellIndicator = GridCanvas.transform.Find("Cell Indicator").gameObject;

                    if (dlgPetMeleeMain.IsCancelCard || dlgPetMeleeMain.IsDisposeCard)
                    {
                        if (self.UnitGameObject != null)
                        {
                            CellIndicator.SetActive(false);
                            self.UnitGameObject.gameObject.SetActive(false);
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
                    float rightPetX = self.CellSize * ( self.BattleCamp == CampEnum.CampPlayer_1 ? -1f : 1f );
                    foreach (Unit unit in units)
                    {
                        if (unit.Type == UnitType.Player)
                        {
                            continue;
                        }
                        
                        if (PositionHelper.Distance2D(unit.Position, self.TargetPos) < self.CellSize / 2)
                        {
                            haveUnit = true;
                        }

                        if (unit.Type != UnitType.Pet)
                        {
                            continue;
                        }

                        if (  self.BattleCamp == CampEnum.CampPlayer_1)
                        {
                            rightPetX = unit.Position.x > rightPetX ? unit.Position.x : rightPetX;
                        }
                        if (  self.BattleCamp == CampEnum.CampPlayer_2)
                        {
                            rightPetX = unit.Position.x < rightPetX ? unit.Position.x : rightPetX;
                        }
                    }

                    bool canmove = (self.BattleCamp == CampEnum.CampPlayer_1 && self.TargetPos.x <= rightPetX)
                            ||(self.BattleCamp == CampEnum.CampPlayer_2 && self.TargetPos.x >= rightPetX) ;
                    
                    if (!haveObstruct && !haveUnit && canmove)
                    {
                        self.CanPlace = true;
                        CellIndicator.GetComponent<Image>().color = Color.green;
                    }
                    else
                    {
                        self.CanPlace = false;
                        CellIndicator.GetComponent<Image>().color = Color.red;
                    }

                    if (self.UnitGameObject != null)
                    {
                        self.UnitGameObject.gameObject.SetActive(true);
                        self.UnitGameObject.transform.position = self.TargetPos;
                    }

                    break;
                }
                case (int)PetMeleeCarType.Magic:
                {
                    PetMagicCardConfig petMagicCardConfig = PetMagicCardConfigCategory.Instance.Get(self.PetMeleeCardInfo.ConfigId);
                    SkillConfig skillConfig = SkillConfigCategory.Instance.Get(petMagicCardConfig.SkillId);
                    if (skillConfig.SkillTargetType == SkillTargetType.FixedPosition)
                    {
                        if (self.IsShowCardDrag(skillConfig.DamgeRange[0]))
                        {
                            self.uiTransform.gameObject.SetActive(!dlgPetMeleeMain.IsDisposeCard);

                            Vector2 localPoint = new Vector2();
                            RectTransform canvas = self.uiTransform.parent.GetComponent<RectTransform>();
                            Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
                            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, Input.mousePosition, uiCamera, out localPoint);
                            self.uiTransform.localPosition = localPoint;
                        }

                        self.TargetPos = hitPoint;
                        self.CanPlace = true;

                        if (self.UnitGameObject != null)
                        {
                            self.UnitGameObject.gameObject.SetActive(true);
                            self.UnitGameObject.transform.position = self.TargetPos;
                        }
                    }
                    else if (skillConfig.SkillTargetType == SkillTargetType.TargetOnly)
                    {
                        self.CardIconGameObject.SetActive(true);
                        self.UpdateCardIconGOPos();

                        List<EntityRef<Unit>> units = self.Root().CurrentScene().GetComponent<UnitComponent>().GetAll();
                        Unit nearestUnit = null;
                        float maxDistance = 2f; //技能指示器吸附范围
                        float nearestDistance = float.MaxValue;

                        SkillBuffConfig skillBuffConfig = null;
                        if (skillConfig.BuffID.Length > 0 && skillConfig.BuffID[0] != 0)
                        {
                            skillBuffConfig = SkillBuffConfigCategory.Instance.Get(skillConfig.BuffID[0]);
                        }

                        int effectType = 1;
                        Unit myUnit = UnitHelper.GetMyUnitFromClientScene(self.Root());
                        foreach (Unit uu in units)
                        {
                            int type = 1;
                            // 根据技能目标类型，筛选出符合条件的unit
                            if (skillBuffConfig != null)
                            {
                                bool canBuff = false;
                                switch (skillBuffConfig.TargetType)
                                {
                                    // //对自己释放
                                    // case 1:
                                    //     canBuff = uu.Id == self.TheUnitFrom.Id;
                                    //     if (uu.Type == UnitType.JingLing)
                                    //     {
                                    //         long masterid = uu.GetMasterId();
                                    //         uu = uu.GetParent<UnitComponent>().Get(masterid);
                                    //         if (uu == null || uu.IsDisposed)
                                    //         {
                                    //             return;
                                    //         }
                                    //     }
                                    //
                                    //     break;
                                    case 2:
                                        type = 1;
                                        PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
                                        canBuff = myUnit.IsSameTeam(uu) || myUnit.IsMasterOrPet(uu, petComponent);
                                        //if (canBuff && skillBuffConfig.Id == 92000032 && uu.Type == UnitType.Monster)
                                        //{
                                        //    Log.Console("怪物攻速！！！！");
                                        //}
                                        break;
                                    //己方 同阵营
                                    case 3:
                                        type = 1;
                                        canBuff = myUnit.GetBattleCamp() == uu.GetBattleCamp();
                                        break;
                                    //敌方
                                    case 4:
                                        type = 2;
                                        canBuff = myUnit.IsCanAttackUnit(uu);
                                        break;
                                        // //全部
                                        // case 5:
                                        //     canBuff = true;
                                        //     break;
                                        // case 6: ////6: 己方召唤兽，不包含宠物
                                        //     canBuff = uu.Type == UnitType.Monster && uu.GetMasterId() == self.TheUnitFrom.Id;
                                        //     break;
                                        // case 7: //// 7: 己方召唤兽，包含宠物
                                        //     canBuff = uu.GetMasterId() == self.TheUnitFrom.Id;
                                    default:
                                        break;
                                }

                                if (!canBuff)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                type = 2;
                                if (!myUnit.IsCanAttackUnit(uu))
                                {
                                    continue;
                                }
                            }

                            float distance = PositionHelper.Distance2D(uu.Position, hitPoint);
                            if (distance < maxDistance && distance < nearestDistance)
                            {
                                effectType = type;
                                nearestDistance = distance;
                                nearestUnit = uu;
                            }
                        }

                        if (nearestUnit != null)
                        {
                            self.TargetPos = nearestUnit.Position;
                            self.TargetUnitId = nearestUnit.Id;
                            self.CanPlace = true;

                            if (self.UnitGameObject != null)
                            {
                                self.UnitGameObject.gameObject.SetActive(true);
                                self.UnitGameObject.Get<GameObject>("Skill_Target_1").SetActive(effectType == 1);
                                self.UnitGameObject.Get<GameObject>("Skill_Target_2").SetActive(effectType == 2);
                                self.UnitGameObject.transform.position = self.TargetPos;
                            }
                        }
                        else
                        {
                            self.TargetPos = hitPoint;
                            self.TargetUnitId = 0;
                            self.CanPlace = false;

                            if (self.UnitGameObject != null)
                            {
                                self.UnitGameObject.gameObject.SetActive(false);
                            }
                        }
                    }

                    break;
                }
            }

            if (dlgPetMeleeMain.IsCancelCard || dlgPetMeleeMain.IsDisposeCard)
            {
                self.CanPlace = false;

                if (self.UnitGameObject != null)
                {
                    self.UnitGameObject.gameObject.SetActive(false);
                }
            }
        }

        private static void UpdateCardIconGOPos(this ES_PetMeleeCard self)
        {
            Vector2 localPoint = new Vector2();
            RectTransform canvas = self.uiTransform.parent.parent.GetComponent<RectTransform>();
            Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, Input.mousePosition, uiCamera, out localPoint);
            self.CardIconGameObject.transform.localPosition = localPoint;
        }

        private static void EndDrag(this ES_PetMeleeCard self, PointerEventData pdata)
        {
            if (!string.IsNullOrEmpty(self.UnitAssetsPath) && self.UnitGameObject != null)
            {
                self.Root().GetComponent<GameObjectLoadComponent>().RecoverGameObject(self.UnitAssetsPath, self.UnitGameObject);
                self.UnitGameObject = null;
            }
            
            switch (self.PetMeleeCardInfo.Type)
            {
                case (int)PetMeleeCarType.MainPet:
                case (int)PetMeleeCarType.AssistPet:
                    break;
                case (int)PetMeleeCarType.Magic:
                {
                    PetMagicCardConfig petMagicCardConfig = PetMagicCardConfigCategory.Instance.Get(self.PetMeleeCardInfo.ConfigId);
                    SkillConfig skillConfig = SkillConfigCategory.Instance.Get(petMagicCardConfig.SkillId);
                    if (skillConfig.SkillTargetType == SkillTargetType.FixedPosition)
                    {
                        if (self.IsShowCardDrag(skillConfig.DamgeRange[0]))
                        {
                            self.uiTransform.localPosition = self.StartPos;
                        }
                    }
                    else if (skillConfig.SkillTargetType == SkillTargetType.TargetOnly)
                    {
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

            DlgPetMeleeMain dlgPetMeleeMain = self.GetParent<DlgPetMeleeMain>();

            UnityEngine.Object.Destroy(self.CardIconGameObject);

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
                dlgPetMeleeMain.UseCard(self, self.TargetPos, self.TargetUnitId).Coroutine();
            }
        }
    }
}