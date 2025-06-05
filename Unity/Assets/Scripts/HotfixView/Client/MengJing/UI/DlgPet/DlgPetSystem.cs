using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class DataUpdate_OnPetFightSet_DlgPetRefresh : AEvent<Scene, OnPetFightSet>
    {
        protected override async ETTask Run(Scene scene, OnPetFightSet args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgPet>()?.OnPetFightSet();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_PetItemSelect_Refresh : AEvent<Scene, PetItemSelect>
    {
        protected override async ETTask Run(Scene scene, PetItemSelect args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgPet>()?.PetItemSelect(args.DataParamString);
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_PetHeChengUpdate_Refresh : AEvent<Scene, PetHeChengUpdate>
    {
        protected override async ETTask Run(Scene scene, PetHeChengUpdate args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgPet>()?.OnHeChengReturn();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DDataUpdate_PetXiLianUpdate_Refresh : AEvent<Scene, PetXiLianUpdate>
    {
        protected override async ETTask Run(Scene scene, PetXiLianUpdate args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgPet>()?.OnXiLianUpdate();
            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof(ES_PetList))]
    [FriendOf(typeof(ES_PetHeCheng))]
    [FriendOf(typeof(ES_PetXiLian))]
    [FriendOf(typeof(ES_PetShouHu))]
    [FriendOf(typeof(ES_PetEcho))]
    [FriendOf(typeof(ES_PetZhuangJia))]
    [FriendOf(typeof(DlgPet))]
    public static class DlgPetSystem
    {
        public static void RegisterUIEvent(this DlgPet self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
            
            IPHoneHelper.SetPosition(self.View.E_FunctionSetBtnToggleGroup.gameObject, new Vector2(220f, 0f));
        }

        public static void ShowWindow(this DlgPet self, Entity contextData = null)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        private static void OnFunctionSetBtn(this DlgPet self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_PetList.uiTransform.gameObject.SetActive(true);
                    self.View.ES_PetList.OnUpdateUI();
                    break;
                case 1:
                    self.View.ES_PetHeCheng.uiTransform.gameObject.SetActive(true);
                    self.View.ES_PetHeCheng.OnUpdateUI();
                    break;
                case 2:
                    self.View.ES_PetXiLian.uiTransform.gameObject.SetActive(true);
                    self.View.ES_PetXiLian.OnUpdateUI();
                    break;
                case 3:
                    self.View.ES_PetEcho.uiTransform.gameObject.SetActive(true);
                    self.View.ES_PetEcho.OnUpdateUI();
                    break;
                case 4:
                    self.View.ES_PetZhuangJia.uiTransform.gameObject.SetActive(true);
                    break;
            }
        }

        public static void PetItemSelect(this DlgPet self, string dataParams)
        {
            string[] paramsList = dataParams.Split('@');
            long petId = long.Parse(paramsList[1]);
            RolePetInfo rolePetInfo = self.Root().GetComponent<PetComponentC>().GetPetInfoByID(petId);
            if (paramsList[0] == PetOperationType.XiLian.ToString())
            {
                self.View.ES_PetXiLian.OnXiLianSelect(rolePetInfo);
            }
            else if (paramsList[0] == PetOperationType.HeCheng.ToString())
            {
                self.View.ES_PetHeCheng.OnHeChengSelect(rolePetInfo);
            }
            else if (paramsList[0] == PetOperationType.UpStar_Main.ToString())
            {
                // self.UIPageView.UISubViewList[(int)PetPageEnum.PetUpStar].GetComponent<UIPetUpStarComponent>().PetMainSelect(rolePetInfo);
            }
            else if (paramsList[0] == PetOperationType.UpStar_FuZh.ToString())
            {
                // self.UIPageView.UISubViewList[(int)PetPageEnum.PetUpStar].GetComponent<UIPetUpStarComponent>().PetItemSelect(rolePetInfo);
            }
            else if (paramsList[0] == PetOperationType.PetEcho.ToString())
            {
                self.View.ES_PetEcho.OnPetItemSelect(rolePetInfo).Coroutine();
            }
        }

        public static void OnHeChengReturn(this DlgPet self)
        {
            if (self.View.ES_PetHeCheng.uiTransform.gameObject.activeSelf)
            {
                self.View.ES_PetHeCheng.OnHeChengReturn();
            }
        }

        public static async ETTask RequestPetHeXinSelect(this DlgPet self)
        {
            if (self.View.ES_PetList.uiTransform.gameObject.activeSelf)
            {
                await self.View.ES_PetList.OnButtonEquipHeXinButton();
            }
        }

        public static void OnEquipPetHeXin(this DlgPet self)
        {
            if (self.View.ES_PetList.uiTransform.gameObject.activeSelf)
            {
                self.View.ES_PetList.OnEquipPetHeXin();
            }
        }

        public static void OnXiLianUpdate(this DlgPet self)
        {
            if (self.View.ES_PetXiLian.uiTransform.gameObject.activeSelf)
            {
                self.View.ES_PetXiLian.OnXiLianUpdate();
            }
        }

        public static void OnPetFightSet(this DlgPet self)
        {
            if (self.View.ES_PetList.uiTransform.gameObject.activeSelf)
            {
                self.View.ES_PetList.OnPetFightingSet();
            }
        }

        public static async ETTask RequestPetEquipSelect(this DlgPet self)
        {
            await self.View.ES_PetList.OnButtonEquipHeXinButton();
        }
    }
}