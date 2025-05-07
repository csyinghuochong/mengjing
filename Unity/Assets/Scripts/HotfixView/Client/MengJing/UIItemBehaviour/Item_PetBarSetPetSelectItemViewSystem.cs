
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[FriendOf(typeof(Scroll_Item_PetBarSetPetSelectItem))]
	[EntitySystemOf(typeof(Scroll_Item_PetBarSetPetSelectItem))]
	public static partial class Scroll_Item_PetBarSetPetSelectItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_PetBarSetPetSelectItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_PetBarSetPetSelectItem self )
		{
			self.DestroyWidget();
		}
		
		public static void OnInitData(this Scroll_Item_PetBarSetPetSelectItem self, RolePetInfo rolePetInfo)
		{
			self.RolePetInfo = rolePetInfo;

			PetSkinConfig petSkinConfig = PetSkinConfigCategory.Instance.Get(rolePetInfo.SkinId);
			string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petSkinConfig.IconID.ToString());
			Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

			self.E_Img_PetHeroIonImage.sprite = sp;
			self.E_Lab_PetNameText.text = rolePetInfo.PetName;
			using (zstring.Block())
			{
				self.E_Lab_PetLvText.text = zstring.Format("{0}{1}", rolePetInfo.PetLv, LanguageComponent.Instance.LoadLocalization("级"));
			}

			self.E_Image_ProtectImage.gameObject.SetActive(rolePetInfo.IsProtect);

			self.E_ImageDiButtonButton.AddListener(self.OnClickPetItem);
		}

		private static void OnClickPetItem(this Scroll_Item_PetBarSetPetSelectItem self)
		{
			self.OnSelectPet?.Invoke(self.RolePetInfo.Id);
		}
	}
}
