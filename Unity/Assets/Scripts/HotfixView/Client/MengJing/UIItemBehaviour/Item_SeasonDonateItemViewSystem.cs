
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_SeasonDonateItem))]
	public static partial class Scroll_Item_SeasonDonateItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_SeasonDonateItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_SeasonDonateItem self )
		{
			self.DestroyWidget();
		}

		private static async ETTask OnButtonReveiveButton(this Scroll_Item_SeasonDonateItem self)
		{
			Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
			NumericComponentC numericComponentC = unit.GetComponent<NumericComponentC>();
			int donateTimes = numericComponentC.GetAsInt(NumericType.CommonSeasonDonateTimes);
			UserInfoComponentC userInfoComponentC = self.Root().GetComponent<UserInfoComponentC>();
			if (userInfoComponentC.UserInfo.SeasonDonateRewardIds.Contains(self.Times))
			{
				return;
			}

			if (donateTimes < self.Times)
			{
				FlyTipComponent.Instance.ShowFlyTip("捐献次数不足！");
				return;
			}

			await UserInfoNetHelper.SeasonDonateRewardRequest(self.Root(), self.Times);
			self.UpdateReveivedState();
		}

		private static void UpdateReveivedState(this Scroll_Item_SeasonDonateItem self)
		{
			UserInfoComponentC userInfoComponentC = self.Root().GetComponent<UserInfoComponentC>();
			self.E_ImageReveivedImage.gameObject.SetActive(userInfoComponentC.UserInfo.SeasonDonateRewardIds.Contains(self.Times));
		}

		public static void OnInitData(this Scroll_Item_SeasonDonateItem self, int times, string reward)
		{
			self.Times = times;
			self.ES_RewardList.Refresh(reward);
			self.UpdateReveivedState();

			self.E_TextTimeText.text = $"{times}次";
			self.E_ButtonReveiveButton.AddListenerAsync( self.OnButtonReveiveButton );
		}
	}
}
