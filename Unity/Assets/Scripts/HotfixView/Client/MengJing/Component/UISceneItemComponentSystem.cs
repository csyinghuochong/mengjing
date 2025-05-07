using System;
using UnityEngine;
using UnityEngine.UI;


namespace ET.Client
{

    [FriendOf(typeof(UISceneItemComponent))]
    [EntitySystemOf(typeof(UISceneItemComponent))]
    public static partial class UISceneItemComponentSystem
    {

        [EntitySystem]
        private static void Awake(this ET.Client.UISceneItemComponent self)
        {
            self.HeadBar = null;
            self.UICamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            self.MainCamera = self.Root().GetComponent<GlobalComponent>().MainCamera.GetComponent<Camera>();
        }
        [EntitySystem]
        private static void Destroy(this ET.Client.UISceneItemComponent self)
        {
            self.RecoverGameObject(self.GameObject);
        }

        public static void RecoverGameObject(this UISceneItemComponent self, GameObject gameobject)
        {
            if (gameobject != null)
            {
                gameobject.GetComponent<HeadBarUI>().enabled = false;
                self.Root().GetComponent<GameObjectLoadComponent>().RecoverGameObject(self.HeadBarPath, gameobject);
                self.GameObject = null;
            }
        }

        public static void OnLoadGameObject(this UISceneItemComponent self, GameObject gameObject, long formId)
        {
            if (self.IsDisposed)
            {
                GameObject.DestroyImmediate(gameObject);
                return;
            }

            self.GameObject = gameObject;
            self.GameObject.transform.SetParent(GlobalComponent.Instance.BloodMonster.transform);
            self.GameObject.transform.localScale = Vector3.one;
            if (self.GameObject.GetComponent<HeadBarUI>() == null)
            {
                self.GameObject.AddComponent<HeadBarUI>();
            }
            self.HeadBarUI = self.GameObject.GetComponent<HeadBarUI>();
            self.HeadBarUI.enabled = true;
            self.HeadBarUI.HeadPos = self.UIPosition;
            self.HeadBarUI.HeadBar = self.GameObject;
            self.GameObject.transform.SetAsFirstSibling();
            Unit unit = self.GetParent<Unit>();
            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(unit.ConfigId);
             switch (monsterConfig.MonsterSonType)
             {
                 case 52:
                     NumericComponentC numericComponent = self.GetParent<Unit>().GetComponent<NumericComponentC>();
                     int energySkillId = numericComponent.GetAsInt(NumericType.EnergySkillId);
                     SkillConfig skillConfig = SkillConfigCategory.Instance.Get(energySkillId);
                     self.GameObject.Get<GameObject>("Lal_Name").GetComponent<Text>().text = skillConfig.SkillName;
                     self.GameObject.Get<GameObject>("Lal_Desc").GetComponent<Text>().text = skillConfig.SkillDescribe;
                     break;
                 case 54:
                 case 55:
                 case 56:
                 case 57:
                 case 60:
                     self.GameObject.Get<GameObject>("Lal_Name").GetComponent<Text>().text = monsterConfig.MonsterName;
                     break;
                 case 58:
                     self.GameObject.Get<GameObject>("Lal_Name").GetComponent<Text>().text = monsterConfig.MonsterName;
                     self.GameObject.Get<GameObject>("Lal_Desc").GetComponent<Text>().text = CommonViewHelper.ZhuaPuProToStr(monsterConfig.Parameter[1]);
                     self.GameObject.Get<GameObject>("Lal_Name").GetComponent<Text>().color = new Color(184f / 255f, 255f / 255f, 66f / 255f);
                     break;
                 case 59:
                     self.GameObject.Get<GameObject>("Lal_Name").GetComponent<Text>().text = monsterConfig.MonsterName;
                     self.GameObject.Get<GameObject>("Lal_Desc").GetComponent<Text>().text = CommonViewHelper.ZhuaPuProToStr(monsterConfig.Parameter[1]);
                     self.GameObject.Get<GameObject>("Lal_Name").GetComponent<Text>().color = new Color(255f / 255f, 199f / 255f, 66f / 255f);
                     break;
                 case 61:
                     self.GameObject.Get<GameObject>("Lal_Name").GetComponent<Text>().text = monsterConfig.MonsterName;
                     self.GameObject.Get<GameObject>("Lal_Desc").GetComponent<Text>().text = string.Empty;
                     break;
                 default:
                     break;
             }
        }

         public static  void OnInitUI(this UISceneItemComponent self)
         {
             Unit unit = self.GetParent<Unit>();
             int configId = unit.ConfigId;
             MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(configId);

             //51 场景怪 有AI 不显示名称
             //52 能量台子 无AI
             //54 场景怪 有AI 显示名称
             //55 宝箱类 无AI
             var path = "";
             if (monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_52)
             {
                 path = ABPathHelper.GetUGUIPath("Blood/UISceneItem");
                 //self.UIPosition = unit.GetComponent<GameObjectComponent>().GameObject.transform.Find("UIPosition");
                 self.UIPosition = unit.GetComponent<HeroTransformComponent>().GetTranform(PosType.Head);
             }
             else if (monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_54 || monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_60)
             {
                 path = ABPathHelper.GetUGUIPath("Blood/UISceneItem");
                 self.UIPosition = unit.GetComponent<GameObjectComponent>().GameObject.transform.Find("UIPosition");
             }
             else if (unit.IsChest() || monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_58 || monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_59 || monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_61)
             {
                 path = ABPathHelper.GetUGUIPath("Blood/UISceneItem");
                 self.UIPosition = unit.GetComponent<GameObjectComponent>().GameObject.transform.Find("RoleBoneSet/Head");
             }

             self.HeadBarPath = path;
             self.Root().GetComponent<GameObjectLoadComponent>().AddLoadQueue( self.HeadBarPath, self.InstanceId,true, self.OnLoadGameObject);
         }
    }
}