﻿using UnityEngine;
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

            bool gm = GMData.GmAccount.Contains(root.GetComponent<PlayerComponent>().Account);
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
                FlyTipComponent.Instance.ShowFlyTip($"请添加NPC对应 {funtionOpenConfig.Name}");
                return;
            }

            UIComponent uiComponent = root.GetComponent<UIComponent>();
            uiComponent.CurrentNpcId = npcid;
            uiComponent.CurrentNpcUI = windowID;
            root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>().View.ES_JoystickMove.uiTransform.gameObject.SetActive(false);

            MJCameraComponent cameraComponent = root.CurrentScene().GetComponent<MJCameraComponent>();
            cameraComponent.SetBuildEnter(npc, () => { OnBuildEnter(root, npcid, windowID); });
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
                "UITowerDungeon" => WindowID.WindowID_Tower,
                "UITrial" => WindowID.WindowID_Trial,
                "UIZuoQi" => WindowID.WindowID_ZuoQi,
                "UIProtect" => WindowID.WindowID_Protect,
                "UITowerOfSeal" => WindowID.WindowID_TowerOfSeal,
                "UIJiaYuanBag" => WindowID.WindowID_JiaYuanBag,
                "UIJiaYuanChouKa" => WindowID.WindowID_JiaYuanChouKa,
                "UIJiaYuanDaShi" => WindowID.WindowID_JiaYuanDaShi,
                "UIJiaYuanFood" => WindowID.WindowID_JiaYuanFood,
                "UIUIJiaYuanMystery" => WindowID.WindowID_JiaYuanMystery,
                "UIJiaYuanPasture" => WindowID.WindowID_JiaYuanPasture,
                "UIJiaYuanPet" => WindowID.WindowID_JiaYuanPet,
                "UIJiaYuanRecord" => WindowID.WindowID_JiaYuanRecord,
                "UIJiaYuanTreasureMapStorage" => WindowID.WindowID_JiaYuanTreasureMapStorage,
                "UIJiaYuanUpLv" => WindowID.WindowID_JiaYuanUpLv,
                "UIJiaYuanWarehouse" => WindowID.WindowID_JiaYuanWarehouse,
                "UIUnionDonation" => WindowID.WindowID_UnionDonation,
                "UIUnionKeJi" => WindowID.WindowID_UnionKeJi,
                "UIUnionMystery" => WindowID.WindowID_UnionMystery,
                "UIFriend" => WindowID.WindowID_Friend,
                "UIUnionXiuLian" => WindowID.WindowID_UnionXiuLian,
                "UITurtle" => WindowID.WindowID_Turtle,
                "UIEquipmentIncrease" => WindowID.WindowID_EquipmentIncrease,
                "UIJueXing" => WindowID.WindowID_JueXing,
                "UIBattleRecruit" => WindowID.WindowID_BattleRecruit,
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