using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ET.Client
{
	[EntitySystemOf(typeof(ES_SeasonBoss))]
	[FriendOfAttribute(typeof(ES_SeasonBoss))]
	public static partial class ES_SeasonBossSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_SeasonBoss self,Transform transform)
		{
			self.uiTransform = transform;
			
			self.E_DonationBtnButton.AddListenerAsync( self.OnDonationBtn );
			self.E_RewardBtnButton.AddListener( self.OnRewardBtn );
		}

		[EntitySystem]
		private static void Destroy(this ES_SeasonBoss self)
		{
			self.DestroyWidget();
		}

		private static async ETTask OnDonationBtn(this ES_SeasonBoss self)
		{
			long instanceid = self.InstanceId;
			M2C_SeasonDonateResponse infoResponse = await ActivityNetHelper.SeasonDonateRequest(self.Root());
			if (instanceid != self.InstanceId || infoResponse == null || infoResponse.Error != ErrorCode.ERR_Success)
			{
				return;
			}

			self.UpdateBossInfo(infoResponse.CommonSeasonBossLevel, infoResponse.CommonSeasonBossExp);
			await ETTask.CompletedTask;
		}
        
		private static void OnRewardBtn(this ES_SeasonBoss self)
		{
			self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_SeasonDonateReward).Coroutine();
		}

		private static void UpdateBossInfo(this ES_SeasonBoss self, int bosslv, int bossexp)
		{
			KeyValuePairInt keyValuePairInt = ConfigData.CommonSeasonBossList[bosslv];

			float rate = (bossexp * 1f / keyValuePairInt.Value);
			rate = Mathf.Min(1f, rate);
			self.E_Img_LodingValueImage.fillAmount = rate;
			
			
			List<RewardItem> droplist = new List<RewardItem>();
			droplist = DropHelper.DropIDToShowItem(GlobalValueConfigCategory.Instance.CommonSeasonDonateGetItem, 1);
			string itemList = "";
			for (int i = 0; i < droplist.Count; i++)
			{
				itemList += droplist[i].ItemID + ";" + 1 + "@";
			}
			
			self.ES_RewardList.Refresh(droplist,1f,false);

			Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
			NumericComponentC numericComponentC = unit.GetComponent<NumericComponentC>();
			using (zstring.Block())
			{
				if (self.LastSeasonBossLevel != bosslv)
				{
					int bossid = keyValuePairInt.KeyId;
					MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(bossid);
					
					string[] strs = null;
					if (!CommonHelp.IfNull(monsterConfig.ModelShowPosi))
					{
						strs = monsterConfig.ModelShowPosi.Split(',');
					}
					if (strs != null && strs.Length >= 5)
					{
						self.ES_ModelShow.Camera.fieldOfView = float.Parse(strs[3]);
						self.ES_ModelShow.SetCameraPosition(new Vector3(float.Parse(strs[0]), float.Parse(strs[1]), float.Parse(strs[2])));
						self.ES_ModelShow.RotationY = float.Parse(strs[4]); 
					}
					else
					{
						self.ES_ModelShow.SetCameraPosition(new Vector3(0f, 40f, 150f));
					}
					
					self.ES_ModelShow.ShowOtherModel(zstring.Format("Monster/{0}", monsterConfig.MonsterModelID)).Coroutine();
				}

				self.E_SeasonExperienceTextText.text = zstring.Format("{0}/{1}", bossexp, keyValuePairInt.Value);

				if (bosslv >= ConfigData.CommonSeasonBossList.Count - 1 && bossexp >=keyValuePairInt.Value )
				{
					self.E_SeasonExperienceTextText.text = "已满级";
				}

				self.E_SeasonBossLevelText.text = zstring.Format("{0}级", bosslv + 1);
				self.E_SeasonDonateTimesText.text = zstring.Format("当前您已捐献<color=#C7FF40>{0}</color>次", numericComponentC.GetAsInt(NumericType.CommonSeasonDonateTimes));
			}

			self.ES_CostItem.UpdateItem( GlobalValueConfigCategory.Instance.CommonSeasonDonateItemId, 1, true );
			
			self.LastSeasonBossLevel = bosslv;
		}

		public static async ETTask OnInitUI(this ES_SeasonBoss self)
		{
			long instanceid = self.InstanceId;
			A2C_CommonSeasonBossInfoResponse infoResponse = await ActivityNetHelper.GetCommonSeasonBossInfo(self.Root());

			if (instanceid != self.InstanceId || infoResponse == null)
			{
				return;
			}
			
			self.UpdateBossInfo(infoResponse.CommonSeasonBossLevel, infoResponse.CommonSeasonBossExp);
			await ETTask.CompletedTask;
		}

    }


}
