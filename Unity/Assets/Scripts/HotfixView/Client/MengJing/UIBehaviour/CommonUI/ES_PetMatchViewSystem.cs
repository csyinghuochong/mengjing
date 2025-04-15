
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	
	[Event(SceneType.Demo)]
	public class PetMeleePlanUpdate_Refresh : AEvent<Scene, PetMeleePlanUpdate>
	{
		protected override async ETTask Run(Scene scene, PetMeleePlanUpdate args)
		{
			scene.GetComponent<UIComponent>().GetDlgLogic<DlgCountry>()?.View.ES_PetMatch.OnUpdateUI();
			await ETTask.CompletedTask;
		}
	}
	[Event(SceneType.Demo)]
	public class PetMeleeSetUpdate_Refresh : AEvent<Scene, PetMeleeSetUpdate>
	{
		protected override async ETTask Run(Scene scene, PetMeleeSetUpdate args)
		{
			scene.GetComponent<UIComponent>().GetDlgLogic<DlgCountry>()?.View.ES_PetMatch.OnUpdateUI();
			await ETTask.CompletedTask;
		}
	}
	
	[EntitySystemOf(typeof(ES_PetMatch))]
	[FriendOfAttribute(typeof(ES_PetMatch))]
	public static partial class ES_PetMatchSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_PetMatch self,Transform transform)
		{
			self.uiTransform = transform;
			
			self.E_Button_TeamButton.AddListenerAsync(self.OnButton_TeamButton);
			self.E_FunctionSetBtnToggleGroup.AddListener((index) => { self.OnPlanSet(index).Coroutine(); });
			self.E_Button_RefreshButton.AddListenerAsync( self.OnRefreshButton );
			self.E_Button_RewardButton.AddListener(self.OnRewardButton);
			self.E_Button_RankButton.AddListener(self.OnRankButton);
			
			self.MainPetItem = self.EG_MainPetListRectTransform.GetChild(0).gameObject;
			self.InitItemList();
			self.RequestMyScore().Coroutine();
			//self.E_FunctionSetBtnToggleGroup.OnSelectIndex(self.Root().GetComponent<PetComponentC>().PetMeleePlan);
		}

		[EntitySystem]
		private static void Destroy(this ES_PetMatch self)
		{
			self.DestroyWidget();
		}
		
		private static void InitItemList(this ES_PetMatch self)
		{
			self.MainPetItemList.Add(self.MainPetItem);
			for (int i = 1; i < 6; i++)
			{
				GameObject go = UnityEngine.Object.Instantiate(self.MainPetItem, self.MainPetItem.transform.parent);
				self.MainPetItemList.Add(go);
			}
		}
		
		private static void RefreshItemList(this ES_PetMatch self)
		{
			PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
			for (int i = 0; i < 6; i++)
			{
				Sprite sprite = null;
				if (i < self.PetMeleeInfo.MainPetList.Count)
				{
					long petId = self.PetMeleeInfo.MainPetList[i];
					RolePetInfo rolePetInfo = petComponent.GetPetInfoByID(petId);
					PetSkinConfig petSkinConfig = PetSkinConfigCategory.Instance.Get(rolePetInfo.SkinId);
					string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petSkinConfig.IconID.ToString());
					sprite = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
				}

				GameObject go = self.MainPetItemList[i];
				if (sprite != null)
				{
					go.transform.Find("Mask/Icon").gameObject.SetActive(true);
					go.transform.Find("Mask/Icon").GetComponent<Image>().sprite = sprite;
				}
				else
				{
					go.transform.Find("Mask/Icon").gameObject.SetActive(false);
				}
			}
		}

		private static async ETTask OnPlanSet(this ES_PetMatch self, int index)
		{
			PetComponentC petComponentC = self.Root().GetComponent<PetComponentC>();

			if (petComponentC.PetMeleePlan != index)
			{
				int error = await PetNetHelper.RequestPetMeleePlan(self.Root(), MapTypeEnum.PetMelee, index);

				if (error == ErrorCode.ERR_Success)
				{
					using (zstring.Block())
					{
						FlyTipComponent.Instance.ShowFlyTip(zstring.Format("宠物乱斗切换 {0}", index));
					}
				}
			}

			// 复制一份
			if (self.PetMeleeInfo == null)
			{
				self.PetMeleeInfo = PetMeleeInfo.Create();
			}

			self.PetMeleeInfo.MainPetList.Clear();
			self.PetMeleeInfo.AssistPetList.Clear();
			self.PetMeleeInfo.MagicList.Clear();

			PetMeleeInfo petMeleeInfo = petComponentC.PetMeleeInfoList[petComponentC.PetMeleePlan];
			self.PetMeleeInfo.MainPetList.AddRange(petMeleeInfo.MainPetList);
			self.PetMeleeInfo.AssistPetList.AddRange(petMeleeInfo.AssistPetList);
			self.PetMeleeInfo.MagicList.AddRange(petMeleeInfo.MagicList);

			self.RefreshItemList();

			await ETTask.CompletedTask;
		}
		
		private static async ETTask OnButton_TeamButton(this ES_PetMatch self)
		{
			self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetMelee).Coroutine();
			await ETTask.CompletedTask;
		}

		private static void OnRewardButton(this ES_PetMatch self)
		{
			//RankRewardConfig Type == 8  ui参考宠物天梯排名界面
			self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetMatchReward).Coroutine();
		}

		private static  void OnRankButton(this ES_PetMatch self)
		{
			self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetMatchRankShow).Coroutine();
			//ui参考排行榜界面   先用假数据测试
			// await PetMatchNetHelper.RequestPetMatchRankList(self.Root());
		}

		private static async ETTask OnRefreshButton(this ES_PetMatch self)
		{
			if (!FunctionHelp.IsInTime(1074))
			{
				FlyTipComponent.Instance.ShowFlyTip("不在活动时间段内！");
				return;
			}
            
			BattleMessageComponent battleMessageComponent = self.Root().GetComponent<BattleMessageComponent>();
			long lastTime = battleMessageComponent.SoloPiPeiStartTime;
			if (TimeHelper.ServerNow() - lastTime < TimeHelper.Second * 10)
			{
				return;
			}

			battleMessageComponent.SoloPiPeiStartTime = TimeHelper.ServerNow();

			await PetMatchNetHelper.RequestPetMatch(self.Root());
			
			await ETTask.CompletedTask;
		}

		private static async ETTask RequestMyScore(this ES_PetMatch self)
		{
			self.E_Text_RankText.text = "未上榜";
			self.E_Text_ScoreText.text = "0";
			PetMatch2C_RankListResponse response = await PetMatchNetHelper.RequestPetMatchRankList(self.Root());
			if (response == null)
			{
				return;
			}

			long selfid = UnitHelper.GetMyUnitId(self.Root());
			for (int i = 0; i < response.PetMatchPlayerInfoList.Count; i++)
			{
				if (selfid == response.PetMatchPlayerInfoList[i].UnitId)
				{
					self.E_Text_RankText.text = (i + 1).ToString();
					self.E_Text_ScoreText.text = response.PetMatchPlayerInfoList[i].Score.ToString();
				}
			}
		}
		
		public static void OnUpdateUI(this ES_PetMatch self)
		{
			self.E_FunctionSetBtnToggleGroup.OnSelectIndex(self.Root().GetComponent<PetComponentC>().PetMeleePlan);
		}

	}
}
