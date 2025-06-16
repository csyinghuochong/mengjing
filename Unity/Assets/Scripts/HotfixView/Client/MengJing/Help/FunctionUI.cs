using System;
using UnityEngine;
using UnityEngine.UI;
using Vector3 = System.Numerics.Vector3;

namespace ET.Client
{
    [FriendOf(typeof(ES_JoystickMove))]
    public static class FunctionUI
    {
        //传入道具ID显示名称及品质颜色
        public static void ItemObjShowName(GameObject itemObj, int itemID)
        {
            ItemConfig itemCof = ItemConfigCategory.Instance.Get(itemID);
            itemObj.GetComponent<Text>().text = itemCof.ItemName;
            itemObj.GetComponent<Text>().color = QualityReturnColor(itemCof.ItemQuality);
        }

        public static void OpenFunctionUI(Scene root, int npcid, int functionid)
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

            bool gm = GMData.GmAccount.Contains(root.GetComponent<PlayerInfoComponent>().Account);
            if (!gm && functionid == 1048)
            {
                return;
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(root);
            Vector3 unitPosi = new(unit.Position.x, unit.Position.y, unit.Position.z);
            Unit npc = TaskHelper.GetNpcByConfigId(root, unitPosi, npcid);
            if (npc == null)
            {
                return;
            }

            WindowID windowID = GetUIPath(funtionOpenConfig.Name);
            if (windowID == WindowID.WindowID_Invaild)
            {
                // FlyTipComponent.Instance.ShowFlyTip($"请添加NPC对应 {funtionOpenConfig.Name}");
                return;
            }

            UIComponent uiComponent = root.GetComponent<UIComponent>();
            uiComponent.CurrentNpcId = npcid;
            uiComponent.CurrentNpcUI = windowID;
            root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>().View.ES_JoystickMove.uiTransform.gameObject.SetActive(false);

            MJCameraComponent cameraComponent = root.CurrentScene().GetComponent<MJCameraComponent>();
            cameraComponent.SetBuildEnter(npc, CameraBuildType.Type_0, () => { OnBuildEnter(root, npcid, windowID); });
        }

        public static void OnBuildEnter(Scene root, int npcid, WindowID windowID)
        {
            int FunctionId = NpcConfigCategory.Instance.Get(npcid).NpcType;
            FuntionConfig funtionOpenConfig = FuntionConfigCategory.Instance.Get(FunctionId);

            root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>().View.ES_JoystickMove.uiTransform.gameObject.SetActive(true);

            root.GetComponent<UIComponent>().ShowWindowAsync(windowID).Coroutine();
        }

        public static WindowID GetUIPath(string uitype)
        {
            string type = "WindowID_" + uitype.Substring(2);
            if (Enum.TryParse(type, out WindowID windowID))
            {
                return windowID;
            }
            else
            {
                return WindowID.WindowID_Invaild;
            }
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
        
        public static string ItemQualiytoPath_2(int itemQuality)
        {
            string path = "";
            switch (itemQuality)
            {
                case 1:
                    path = "ItemQuality2_1";
                    break;
                case 2:
                    path = "ItemQuality2_2";
                    break;
                case 3:
                    path = "ItemQuality2_3";
                    break;
                case 4:
                    path = "ItemQuality2_4";
                    break;
                case 5:
                    path = "ItemQuality2_5";
                    break;
                case 6:
                    path = "ItemQuality2_6";
                    break;
            }

            return path;
        }

        //ItemQualityBig_2
        public static string BigItemQualiytoPath(int itemQuality)
        {
            string path = "";
            switch (itemQuality)
            {
                case 1:
                    path = "ItemQualityBig_1";
                    break;
                case 2:
                    path = "ItemQualityBig_2";
                    break;
                case 3:
                    path = "ItemQualityBig_3";
                    break;
                case 4:
                    path = "ItemQualityBig_4";
                    break;
                case 5:
                    path = "ItemQualityBig_5";
                    break;
                case 6:
                    path = "ItemQualityBig_6";
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
            else if (weizhi >= 4 && weizhi < 4 + ConfigData.EquipShiPingMax)
            {
                return 5;
            }
            else
            {
                return weizhi - (ConfigData.EquipShiPingMax - 2);
            }
            
        }
    }
}