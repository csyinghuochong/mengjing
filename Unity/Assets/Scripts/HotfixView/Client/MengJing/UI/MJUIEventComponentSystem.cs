using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (UI))]
    [FriendOf(typeof (MJUIEventComponent))]
    [EntitySystemOf(typeof (MJUIEventComponent))]
    public static partial class MJUIEventComponentSystem
    {
        [EntitySystem]
        private static void Awake(this MJUIEventComponent self)
        {
            MJUIEventComponent.Instance = self;

            GameObject uiRoot = GameObject.Find("/Global/UI");
            ReferenceCollector referenceCollector = uiRoot.GetComponent<ReferenceCollector>();

            self.UILayers.Add((int)UILayer.Hidden, referenceCollector.Get<GameObject>(UILayer.Hidden.ToString()).transform);
            self.UILayers.Add((int)UILayer.Low, referenceCollector.Get<GameObject>(UILayer.Low.ToString()).transform);
            self.UILayers.Add((int)UILayer.Mid, referenceCollector.Get<GameObject>(UILayer.Mid.ToString()).transform);
            self.UILayers.Add((int)UILayer.High, referenceCollector.Get<GameObject>(UILayer.High.ToString()).transform);

            GameObject blood = referenceCollector.Get<GameObject>(UILayer.Blood.ToString());
            self.UILayers.Add((int)UILayer.Blood, blood.transform);

            self.BloodPlayer = new GameObject("BloodPlayer");
            self.BloodPlayer.AddComponent<RectTransform>();
            UICommonHelper.SetParent(self.BloodPlayer, blood);
            self.BloodMonster = new GameObject("BloodMonster");
            self.BloodMonster.AddComponent<RectTransform>();
            UICommonHelper.SetParent(self.BloodMonster, blood);
            self.BloodText = new GameObject("BloodText");
            self.BloodText.AddComponent<RectTransform>();
            UICommonHelper.SetParent(self.BloodText, blood);
            //血条下面分三个小层级
            //BloodPlayer = 11,           //玩家血条
            //BloodMonster = 12,          //怪物血条
            //BloodFloat = 13,            //伤害飘字

            var uiEvents = CodeTypes.Instance.GetTypes(typeof (UIEventAttribute));
            foreach (Type type in uiEvents)
            {
                object[] attrs = type.GetCustomAttributes(typeof (UIEventAttribute), false);
                if (attrs.Length == 0)
                {
                    continue;
                }

                UIEventAttribute uiEventAttribute = attrs[0] as UIEventAttribute;
                AUIEvent aUIEvent = Activator.CreateInstance(type) as AUIEvent;
                self.UIEvents.Add(uiEventAttribute.UIType, aUIEvent);
            }
        }

        [EntitySystem]
        private static void Destroy(this MJUIEventComponent self)
        {
            self.UILayers = new Dictionary<int, Transform>();
            self.UIEvents = new Dictionary<string, AUIEvent>();

            UnityEngine.Object.Destroy(self.BloodPlayer);
            UnityEngine.Object.Destroy(self.BloodMonster);
            UnityEngine.Object.Destroy(self.BloodText);
        }

        public static async ETTask<UI> OnCreate(this MJUIEventComponent self, MJUIComponent uiComponent, string uiType)
        {
            try
            {
                long instanceId = self.InstanceId;
                if (!self.UIEvents.ContainsKey(uiType))
                {
                    return null;
                }

                UI ui = await self.UIEvents[uiType].OnCreate(uiComponent);
                if (instanceId != self.InstanceId)
                {
                    return null;
                }

                UILayer uiLayer = ui.GameObject.GetComponent<UILayerScript>().UILayer;
                ui.GameObject.transform.SetParent(self.UILayers[(int)uiLayer]);
                ui.GameObject.transform.localPosition = Vector3.zero;
                ui.GameObject.transform.localScale = Vector3.one;

                //多语言
                // GameSettingLanguge.TransformText(ui.GameObject.transform);
                // GameSettingLanguge.TransformImage(ui.GameObject.transform);

                if (ui.GameObject.GetComponent<UILayerScript>().UIType == UIEnum.FullScreen)
                {
                    ui.GameObject.transform.GetComponent<RectTransform>().offsetMax = Vector2.zero;
                    ui.GameObject.transform.GetComponent<RectTransform>().offsetMin = Vector2.zero;
                }

                return ui;
            }
            catch (Exception e)
            {
                throw new Exception($"on create ui error: {uiType}", e);
            }
        }

        public static void OnRemove(this MJUIEventComponent self, MJUIComponent uiComponent, string uiType)
        {
            try
            {
                self.UIEvents[uiType].OnRemove(uiComponent);
            }
            catch (Exception e)
            {
                throw new Exception($"on remove ui error: {uiType}", e);
            }
        }
    }
}