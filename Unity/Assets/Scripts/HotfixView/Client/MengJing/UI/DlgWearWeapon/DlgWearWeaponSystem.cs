using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgWearWeapon))]
    public static class DlgWearWeaponSystem
    {
        public static void RegisterUIEvent(this DlgWearWeapon self)
        {
            self.View.E_ButtonCloseButton.AddListener(self.OnButtonClose);
            self.View.E_ImgCloseButton.AddListener(self.OnButtonClose);
            
            self.OnInitUI();
        }

        public static void ShowWindow(this DlgWearWeapon self, Entity contextData = null)
        {
        }

        public static void OnButtonClose(this DlgWearWeapon self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_WearWeapon);
        }

        public static void OnInitUI(this DlgWearWeapon self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int weaponid = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.Now_Weapon);
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(weaponid);

            string tip = string.Empty;

            tip = itemConfig.ItemName;
            self.View.E_TextTip3Text.text = $"恭喜你获得了{tip}!\n它可以让你的技能产生变化!\n不同类型的武器对应不同的技能哦!";

            if (!CommonHelp.IfNull(itemConfig.ItemModelID))
            {
                //显示模型
                self.View.ES_ModelShow.ShowOtherModel("ItemModel/" + itemConfig.ItemModelID).Coroutine();

                self.View.ES_ModelShow.SetCameraPosition(new Vector3(5.4f, 40.2f, 214.8f));
                self.View.ES_ModelShow.Camera.fieldOfView = 25;
                self.View.ES_ModelShow.SetModelParentPosition(new Vector2(10000, 0));
                self.View.ES_ModelShow.SetModelParentRotation(Quaternion.Euler(0f, -45f, 0f));
            }
        }
    }
}