using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(ES_CostList))]
    [EntitySystemOf(typeof(ES_PetBarUpgrade))]
    [FriendOfAttribute(typeof(ES_PetBarUpgrade))]
    public static partial class ES_PetBarUpgradeSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetBarUpgrade self, Transform transform)
        {
            self.uiTransform = transform;

            self.ES_PetUpgradeItem_1.E_TouchButton.AddListener(() => { self.OnClickPetBarIcon(1); });
            self.ES_PetUpgradeItem_2.E_TouchButton.AddListener(() => { self.OnClickPetBarIcon(2); });
            self.ES_PetUpgradeItem_3.E_TouchButton.AddListener(() => { self.OnClickPetBarIcon(3); });
            self.ES_PetUpgradeItem_1.EPetBarIconSelectImageImage.gameObject.SetActive(false);
            self.ES_PetUpgradeItem_2.EPetBarIconSelectImageImage.gameObject.SetActive(false);
            self.ES_PetUpgradeItem_3.EPetBarIconSelectImageImage.gameObject.SetActive(false);
            self.E_UpgradeButton.AddListenerAsync(self.OnUpgrade);

            self.EG_RightRectTransform.gameObject.SetActive(false);
            self.UpdateLeftInfo();
            
            self.OnClickPetBarIcon(1);
        }

        [EntitySystem]
        private static void Destroy(this ES_PetBarUpgrade self)
        {
            self.DestroyWidget();
        }

        private static async ETTask OnUpgrade(this ES_PetBarUpgrade self)
        {
            int error = await PetNetHelper.RequestPetBarUpgrade(self.Root(), self.Index);
            if (error == ErrorCode.ERR_Success)
            {
                FlyTipComponent.Instance.ShowFlyTip("升级成功！");
                self.UpdateLeftInfo();
                self.UpdateRightInfo();
            }
        }

        private static void OnClickPetBarIcon(this ES_PetBarUpgrade self, int index)
        {
            self.Index = index;
            self.UpdateRightInfo();
            
            self.ES_PetUpgradeItem_1.EPetBarIconSelectImageImage.gameObject.SetActive(index == 1);
            self.ES_PetUpgradeItem_2.EPetBarIconSelectImageImage.gameObject.SetActive(index == 2);
            self.ES_PetUpgradeItem_3.EPetBarIconSelectImageImage.gameObject.SetActive(index == 3);
        }

        private static void UpdateLeftInfo(this ES_PetBarUpgrade self)
        {
            PetComponentC petComponentC = self.Root().GetComponent<PetComponentC>();
            self.ES_PetUpgradeItem_1.OnInit(petComponentC.PetBarConfigList[0]);
            self.ES_PetUpgradeItem_2.OnInit(petComponentC.PetBarConfigList[1]);
            self.ES_PetUpgradeItem_3.OnInit(petComponentC.PetBarConfigList[2]);
        }

        private static void UpdateRightInfo(this ES_PetBarUpgrade self)
        {
            self.EG_RightRectTransform.gameObject.SetActive(true);

            self.E_PetBarIconImage.sprite = self.Index switch
            {
                1 => self.ES_PetUpgradeItem_1.E_PetBarIconImage.sprite,
                2 => self.ES_PetUpgradeItem_2.E_PetBarIconImage.sprite,
                3 => self.ES_PetUpgradeItem_3.E_PetBarIconImage.sprite,
                _ => self.E_PetBarIconImage.sprite
            };

            PetComponentC petComponentC = self.Root().GetComponent<PetComponentC>();
            int nowConfig = petComponentC.PetBarConfigList[self.Index - 1];
            PetBarConfig petBarConfig = PetBarConfigCategory.Instance.Get(nowConfig);

            self.E_PetBarNameText.text = petBarConfig.Name;
            using (zstring.Block())
            {
                self.E_PetBarLvText.text = zstring.Format("等级:{0}", petBarConfig.Level);
            }

            if (!PetBarConfigCategory.Instance.Contain(nowConfig + 1))
            {
                self.ES_CostList.uiTransform.gameObject.SetActive(false);
                self.E_UpgradeButton.gameObject.SetActive(false);
                self.E_MaxText.gameObject.SetActive(true);
            }
            else
            {
                self.ES_CostList.uiTransform.gameObject.SetActive(true);
                self.ES_CostList.Refresh(PetBarConfigCategory.Instance.Get(nowConfig + 1).CostItems);
                self.E_UpgradeButton.gameObject.SetActive(true);
                self.E_MaxText.gameObject.SetActive(false);
            }
        }
    }
}