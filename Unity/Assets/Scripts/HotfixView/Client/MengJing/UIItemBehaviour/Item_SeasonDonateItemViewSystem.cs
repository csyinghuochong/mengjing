
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
			await UserInfoNetHelper.SeasonDonateRewardRequest(self.Root(), self.Times);
			self.UpdateReveivedState();
		}

		private static void UpdateReveivedState(this Scroll_Item_SeasonDonateItem self)
		{
			UserInfoComponentC userInfoComponentC = self.Root().GetComponent<UserInfoComponentC>();
			self.E_ImageReveivedImage.gameObject.SetActive(userInfoComponentC.UserInfo.SeasonDonateRewardIds.Contains(self.Times));
		}

		public static void OnInitData(this Scroll_Item_SeasonDonateItem self, int time, string reward)
		{
			self.Times = time;
			self.ES_RewardList.Refresh(reward);
			self.UpdateReveivedState();
		
			self.E_ButtonReveiveButton.AddListenerAsync( self.OnButtonReveiveButton );
		}
	}
}
