using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    public static class FunctionUI
    {
        //传入道具ID显示名称及品质颜色
        public static void ItemObjShowName(GameObject itemObj, int itemID)
        {
            ItemConfig itemCof = ItemConfigCategory.Instance.Get(itemID);
            itemObj.GetComponent<Text>().text = itemCof.ItemName;
            itemObj.GetComponent<Text>().color = QualityReturnColor(itemCof.ItemQuality);
        }

        public static async ETTask OpenFunctionUI(Scene root, int npcid, int functionid)
        {
            if (functionid < 10)
            {
                return;
            }

            FuntionConfig funtionOpenConfig = FuntionConfigCategory.Instance.Get(functionid);
            // bool functionOn = FunctionHelp.CheckFuncitonOn(root, funtionOpenConfig);
            // if (!functionOn)
            // {
            //     FlyTipComponent.Instance.SpawnFlyTipDi(FunctionHelp.GetFunctionContion(root, funtionOpenConfig));
            //     return;
            // }

            bool gm = GMData.GmAccount.Contains(root.GetComponent<PlayerComponent>().Account);
            if (!gm && functionid == 1048)
            {
                return;
            }

            //if (functionid != 1003 && functionid != 1004)
            //{
            //    await UIHelper.Create(zoneScene, uipath);
            //    return true;
            //}
            Unit unit = UnitHelper.GetMyUnitFromClientScene(root);
            System.Numerics.Vector3 unitPosi = new(unit.Position.x, unit.Position.y, unit.Position.z);
            Unit npc = TaskHelper.GetNpcByConfigId(root, unitPosi, npcid);
            if (npc == null)
            {
                return;
            }

            // UIHelper.CurrentNpcId = npcid;
            // UIHelper.CurrentNpcUI = GetUIPath(funtionOpenConfig.Name);

            WindowID windowID = GetUIPath(funtionOpenConfig.Name);
            if (windowID == WindowID.WindowID_Invaild)
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("该NPC没有要打开的UI");
                return;
            }

            UIComponent uiComponent = root.GetComponent<UIComponent>();
            uiComponent.CurrentNpcId = npcid;
            uiComponent.CurrentNpcUI = windowID;
            await root.GetComponent<UIComponent>().ShowWindowAsync(windowID);
            // DlgMain dlgMain = root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>();
            // dlgMain.View.EG_JoystickMoveRectTransform.gameObject.SetActive(false);
            //
            // MJCameraComponent cameraComponent = root.CurrentScene().GetComponent<MJCameraComponent>();
            // cameraComponent.SetBuildEnter(npc, () => { OnBuildEnter(npcid); });
        }

        public static WindowID GetUIPath(string uitype)
        {
            return uitype switch
            {
                "UITaskGet" => WindowID.WindowID_TaskGet,
                "UIWarehouse" => WindowID.WindowID_Warehouse,
                "UIMail" => WindowID.WindowID_Mail,
                "UIRoleXiLian" => WindowID.WindowID_RoleXiLian,
                "UIStore" => WindowID.WindowID_Store,
                "UIMystery" => WindowID.WindowID_Mystery,
                "UIPetEgg" => WindowID.WindowID_PetEgg,
                "UIChouKa" => WindowID.WindowID_ChouKa,
                "UIRank" => WindowID.WindowID_Rank,
                "UIMakeLearn" => WindowID.WindowID_MakeLearn,
                "UIOccTwo" => WindowID.WindowID_OccTwo,
                "UIPaiMai" => WindowID.WindowID_PaiMai,
                "UIGemMake" => WindowID.WindowID_GemMake,
                "UIShenQiMake" => WindowID.WindowID_ShenQiMake,
                "UIShouJi" => WindowID.WindowID_ShouJi,
                "UITower" => WindowID.WindowID_Tower,
                _ => WindowID.WindowID_Invaild
            };
        }

        public static Color QualityReturnColorDi(int ItenQuality)
        {
            Color color = new Color(1, 1, 1);
            switch (ItenQuality)
            {
                case 1:
                    color = new Color(70f / 255f, 70f / 255f, 70f / 255f);
                    break;
                case 2:
                    color = new Color(0, 110f / 255f, 0);
                    break;
                case 3:
                    color = new Color(0f, 110f / 255f, 110f / 255f);
                    break;

                case 4:
                    color = new Color(221f / 255f, 43f / 255f, 186f / 255f);
                    break;
                case 5:
                    color = new Color(200f / 255f, 96f / 255f, 0);
                    break;
                case 6:
                    color = new Color(245f / 255f, 43f / 255f, 96f / 255f);
                    break;
            }

            return color;
        }

        //传入值获取属性名称
        public static string ReturnEquipNeedPropertyName(string proprety)
        {
            string propertyName = "";
            switch (proprety)
            {
                case "1":
                    propertyName = "攻击";
                    break;

                case "2":
                    propertyName = "物防";
                    break;

                case "3":
                    propertyName = "魔防";
                    break;
            }

            return propertyName;
        }

        /// <summary>
        /// 根据品质返回品质字符串
        /// 根据道具品质返回对应的品质框
        /// ItemQuality  道具品质
        /// </summary>
        /// <param name="itemQuality"></param>
        /// <returns></returns>
        public static string ItemQualiytoPath(int itemQuality)
        {
            string path = "";
            switch (itemQuality)
            {
                case 1:
                    path = "ItemQuality_1";
                    break;
                case 2:
                    path = "ItemQuality_2";
                    break;
                case 3:
                    path = "ItemQuality_3";
                    break;
                case 4:
                    path = "ItemQuality_4";
                    break;
                case 5:
                    path = "ItemQuality_5";
                    break;
                case 6:
                    path = "ItemQuality_6";
                    break;
            }

            return path;
        }

        public static string ItemQualityLine(int itemQuality)
        {
            return $"QuaDiline_{itemQuality}";
        }

        public static string ItemQualityBack(int ItemQuality)
        {
            return $"QuaDi_{ItemQuality}";
        }

        //根据品质返回一个Color
        public static Color QualityReturnColor(int ItenQuality)
        {
            Color color = new Color(1, 1, 1);
            switch (ItenQuality)
            {
                case 1:
                    color = new Color(1, 1, 1);
                    break;
                case 2:
                    color = new Color(0, 1, 0);
                    break;
                case 3:
                    color = new Color(0.047f, 0.76f, 0.847f);
                    break;

                case 4:
                    color = new Color(0.937f, 0.5f, 1.0f);
                    break;
                case 5:
                    color = new Color(1, 0.49f, 0);
                    break;
                case 6:
                    color = new Color(245f / 255f, 43f / 255f, 96f / 255f);
                    break;
            }

            return color;
        }

        //weizhi 0 -12
        public static int GetItemSubtypeByWeizhi(int weizhi)
        {
            if (weizhi < 4)
            {
                return weizhi + 1;
            }

            if (weizhi == 4 || weizhi == 5 || weizhi == 6)
            {
                return 5;
            }

            if (weizhi > 6)
            {
                return weizhi - 1;
            }

            return weizhi;
        }
    }
}