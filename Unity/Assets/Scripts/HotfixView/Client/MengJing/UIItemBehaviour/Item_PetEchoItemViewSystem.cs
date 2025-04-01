using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{

    [FriendOf(typeof(Scroll_Item_PetEchoItem))]
    [EntitySystemOf(typeof(Scroll_Item_PetEchoItem))]
	public static partial class Scroll_Item_PetEchoItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_PetEchoItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_PetEchoItem self )
		{
			self.DestroyWidget();
		}

        public static void SetClickHandler(this Scroll_Item_PetEchoItem self, Action<int> action)
        {
            self.ClickPetEchoHandler = action;
        }

        public static void OnClickPetItem(this Scroll_Item_PetEchoItem self)
        {
            self.ClickPetEchoHandler?.Invoke(self.Index);
        }

        public static void OnSelectUI(this Scroll_Item_PetEchoItem self, int index)
        {
            self.E_ImageSelectImage.gameObject.SetActive(self.Index == index);
            self.ES_ModelShow.SetHighlight(self.Index == index);
        }

        public static void UpdatePetSet(this Scroll_Item_PetEchoItem self)
        {
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            RolePetInfo rolePetInfo = petComponent.GetPetInfoByID(petComponent.PetEchoList[self.Index].Value);

            string pname = ItemViewHelp.GetAttributeName(ConfigData.PetEchoAttri[self.Index].KeyId);
            if (rolePetInfo == null)
            {
                self.ES_ModelShow.SetShow(false);
                using (zstring.Block())
                {
                    self.E_Text_ComabtText.text = "战力：0";
                    self.E_Text_AttriText.text = zstring.Format("{0}提升+0%", pname);
                }
                return;
            }

            int fightNum = 0;
            for (int i = 0; i < petComponent.PetEchoList.Count; i++)
            {
                RolePetInfo rolePetInfoNow = petComponent.GetPetInfoByID(petComponent.PetEchoList[i].Value);
                if (rolePetInfoNow != null)
                {
                    fightNum += rolePetInfoNow.PetPingFen;
                }
            }

            PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);
            self.ES_ModelShow.SetShow(true);
            using (zstring.Block())
            {
                self.ES_ModelShow.ShowOtherModel(zstring.Format("Pet/{0}", petConfig.PetModel)).Coroutine();
            }

            self.ES_ModelShow.SetCameraPosition(new Vector3(0f, 100f, 450f));
            self.ES_ModelShow.Camera.fieldOfView = 30;
            // self.ES_ModelShow.SetRootPosition(new Vector2(self.Index * 1000 + 10000, 0));
            self.ES_ModelShow.SetModelParentRotation(Quaternion.Euler(0f, -45f, 0f));

            using (zstring.Block())
            {
                self.E_Text_ComabtText.text = zstring.Format("战力：{0}", rolePetInfo.PetPingFen);
                self.E_Text_AttriText.text  = zstring.Format("{0}提升+{1}%",pname, (CommonHelp.GetPetShouHuPro(rolePetInfo.PetPingFen, fightNum) * 100).ToString("F2"));
            }
        }

        public static void UpdateOpenStatus(this Scroll_Item_PetEchoItem self)
        {
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            KeyValuePairInt keyValuePairInt = petComponent.PetEchoList[self.Index]; 
            bool open = keyValuePairInt.KeyId == 1;
            self.E_Image_Add.gameObject.SetActive(open && keyValuePairInt.Value == 0);
            self.E_Image_Lock.gameObject.SetActive(!open);
            
            CommonViewHelper.SetImageGray(self.Root(), self.E_ImageButtonButton.gameObject, !open);
        }

        //new KeyValuePair() { KeyId = 200101, Value = "力量之源1", Value2 = "10&1025008;1@1025009;1" }, //暴击
        public static void OnInitData(this Scroll_Item_PetEchoItem self, KeyValuePair data, int index)
		{
            self.Index = index;
			self.E_ImageButtonButton.AddListener(self.OnClickPetItem);
            self.OnSelectUI(-1);

            self.E_Text_NameText.text = data.Value;
            self.UpdateOpenStatus();
            self.UpdatePetSet();
        }

    }
}
