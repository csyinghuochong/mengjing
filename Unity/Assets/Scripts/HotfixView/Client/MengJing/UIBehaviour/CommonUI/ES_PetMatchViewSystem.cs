
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
			self.RequestSetPlan(index).Coroutine();
		}

		private static async ETTask RequestSetPlan(this ES_PetMatch self, int index)
		{
			long instanceid = self.InstanceId;
			int error = await PetNetHelper.RequestPetMeleePlan(self.Root(), SceneTypeEnum.PetMatch, index);
			if (instanceid != self.InstanceId || error != ErrorCode.ERR_Success)
			{
				return;
			}

			self.UpdateMyTeamInfo();
		}

		private static async ETTask OnButton_TeamButton(this ES_PetMatch self)
		{
			await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetFormation);
			DlgPetFormation dlgPetFormation = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetFormation>();
			dlgPetFormation.OnInitUI(SceneTypeEnum.PetMatch, self.UpdateMyTeamInfo);
		}

		
		public static void UpdateMyTeamInfo(this ES_PetMatch self)
		{
			PetComponentC petComponentC = self.Root().GetComponent<PetComponentC>();
			int number = 0;
			int combat = 0;
			List<long> petList = self.Root().GetComponent<PetComponentC>().GetPetFormatList(SceneTypeEnum.PetMatch);
			for (int i = 0; i < petList.Count; i++)
			{
				if (petList[i] == 0 )
				{
					continue;
				}

				RolePetInfo rankPetInfo = petComponentC.GetPetInfoByID(petList[i]);
				PetConfig petConfig = PetConfigCategory.Instance.Get(rankPetInfo.ConfigId);
				string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petConfig.HeadIcon);
				Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

				self.ImageIconList[number].SetActive(true);
				self.ImageIconList[number].GetComponent<Image>().sprite = sp;
				number++;
			}
            
			for (int i = number; i < ConfigData.PetMatchPetLimit; i++)
			{
				self.ImageIconList[i].SetActive(false);
			}

		}

		public static void OnUpdateUI(this ES_PetMatch self)
		{
			self.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
		}

	}


}
