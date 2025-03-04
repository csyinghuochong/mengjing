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

            NumericComponentC numericComponent = self.GetParent<Unit>().GetComponent<NumericComponentC>();
            int energySkillId = numericComponent.GetAsInt(NumericType.EnergySkillId);
            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(energySkillId);
            self.GameObject.Get<GameObject>("Lal_Name").GetComponent<Text>().text = skillConfig.SkillName;
            self.GameObject.Get<GameObject>("Lal_Desc").GetComponent<Text>().text = skillConfig.SkillDescribe;
        }

        public static async ETTask OnInitEnergyTableUI(this UISceneItemComponent self)
        {
            string path = ABPathHelper.GetUGUIPath("Blood/UISceneItem");
            self.HeadBarPath = path;
            Unit myUnit =self.GetParent<Unit>();
            self.UIPosition = myUnit.GetComponent<HeroTransformComponent>().GetTranform(PosType.Head);
             // GameObject prefab = await ResourcesComponent.Instance.LoadAssetAsync<GameObject>(path);
            //self.GameObject = UnityEngine.Object.Instantiate(prefab, GlobalComponent.Instance.Unit, true);
            self.Root().GetComponent<GameObjectLoadComponent>().AddLoadQueue( self.HeadBarPath, self.InstanceId, self.OnLoadGameObject);
        }
    }
}