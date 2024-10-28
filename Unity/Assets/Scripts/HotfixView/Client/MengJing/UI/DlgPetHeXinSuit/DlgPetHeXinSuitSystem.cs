using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgPetHeXinSuit))]
    public static class DlgPetHeXinSuitSystem
    {
        public static void RegisterUIEvent(this DlgPetHeXinSuit self)
        {
            self.View.E_Btn_CloseButton.AddListener(self.OnBtn_CloseButton);
            
            self.View.E_UIPetHeXinSuitItemImage.gameObject.SetActive(false);
            self.View.E_Btn_CloseButton.AddListener(() => { self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetHeXinSuit); });
        }

        public static void ShowWindow(this DlgPetHeXinSuit self, Entity contextData = null)
        {
        }

        public static void UpdateInfo(this DlgPetHeXinSuit self, int id)
        {
            foreach (KeyValuePair<int, string> valuePair in ConfigData.PetSuitProperty)
            {
                GameObject go = UnityEngine.Object.Instantiate(self.View.E_UIPetHeXinSuitItemImage.gameObject);
                self.UpdateItemInfo(go, valuePair.Key, valuePair.Key == id);
                go.SetActive(true);
                CommonViewHelper.SetParent(go, self.View.EG_UIPetHeXinSuitItemListNodeRectTransform.gameObject);
            }
        }

        public static void UpdateItemInfo(this DlgPetHeXinSuit self, GameObject gameObject, int key, bool jiHuo)
        {
            ReferenceCollector rc = gameObject.GetComponent<ReferenceCollector>();
            switch (key)
            {
                case 5:
                    rc.Get<GameObject>("NameText").GetComponent<Text>().text = "初级核心";
                    rc.Get<GameObject>("RequirementText").GetComponent<Text>().text = "穿戴3个5级以上的宠物之核";
                    break;
                case 8:
                    rc.Get<GameObject>("NameText").GetComponent<Text>().text = "中级核心";
                    rc.Get<GameObject>("RequirementText").GetComponent<Text>().text = "穿戴3个8级以上的宠物之核";
                    break;
                case 10:
                    rc.Get<GameObject>("NameText").GetComponent<Text>().text = "高级核心";
                    rc.Get<GameObject>("RequirementText").GetComponent<Text>().text = "穿戴3个10级以上的宠物之核";
                    break;
            }

            string[] proStr = ConfigData.PetSuitProperty[key].Split(';');
            for (int i = 0; i < proStr.Length; i++)
            {
                string str = String.Empty;
                string[] pro = proStr[i].Split(',');
                string proName = ItemViewHelp.GetAttributeName(int.Parse(pro[0]));
                int showType = NumericHelp.GetNumericValueType(int.Parse(pro[0]));

                if (showType == 2)
                {
                    float value = float.Parse(pro[1]) * 100;
                    str = proName + "+" + value.ToString("0.##") + "%";
                }
                else
                {
                    str = proName + "+" + float.Parse(pro[1]);
                }

                GameObject go = UnityEngine.Object.Instantiate(rc.Get<GameObject>("PropertyText"));
                go.GetComponent<Text>().text = str;
                go.SetActive(true);
                CommonViewHelper.SetParent(go, rc.Get<GameObject>("PropertyTextListNode"));
            }

            if (jiHuo)
            {
                rc.Get<GameObject>("JiHuo").SetActive(true);
                rc.Get<GameObject>("WeiJiHuo").SetActive(false);
            }
            else
            {
                rc.Get<GameObject>("JiHuo").SetActive(false);
                rc.Get<GameObject>("WeiJiHuo").SetActive(true);
            }
        }
        public static void OnBtn_CloseButton(this DlgPetHeXinSuit self)
        {
        }
    }
}
