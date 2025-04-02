
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_PetMatch))]
	[FriendOfAttribute(typeof(ES_PetMatch))]
	public static partial class ES_PetMatchSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_PetMatch self,Transform transform)
		{
			self.uiTransform = transform;
			
			self.E_Button_TeamButton.AddListenerAsync(self.OnButton_TeamButton);
		}

		[EntitySystem]
		private static void Destroy(this ES_PetMatch self)
		{
			self.DestroyWidget();
		}

		private static async ETTask OnButton_TeamButton(this ES_PetMatch self)
		{
			await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetFormation);
			DlgPetFormation dlgPetFormation = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetFormation>();
			dlgPetFormation.OnInitUI(SceneTypeEnum.PetMatch, self.UpdateMyTeamInfo);
		}

		public static void UpdateMyTeamInfo(this ES_PetMatch self)
		{
			
		}

		public static void OnUpdateUI(this ES_PetMatch self)
		{
			
		}

	}


}
