
using System.Collections.Generic;
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
			self.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
			
			self.ImageIconList = new GameObject[ConfigData.PetMatchPetLimit];
			self.ImageIconList[0] = self.E_ImageIcon1Image.gameObject;
			self.ImageIconList[1] = self.E_ImageIcon2Image.gameObject;
			self.ImageIconList[2] = self.E_ImageIcon3Image.gameObject;
			self.ImageIconList[3] = self.E_ImageIcon4Image.gameObject;
			self.ImageIconList[4] = self.E_ImageIcon5Image.gameObject;
			self.ImageIconList[5] = self.E_ImageIcon6Image.gameObject;
		}

		[EntitySystem]
		private static void Destroy(this ES_PetMatch self)
		{
			self.DestroyWidget();
		}

		private static void OnFunctionSetBtn(this ES_PetMatch self, int index)
		{
			
		}

		private static async ETTask RequestSetPlan(this ES_PetMatch self, int index)
		{
			
		}

		private static async ETTask OnButton_TeamButton(this ES_PetMatch self)
		{
			
		}

		
		public static void UpdateMyTeamInfo(this ES_PetMatch self)
		{
			
		}

		public static void OnUpdateUI(this ES_PetMatch self)
		{
			self.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
		}

	}


}
