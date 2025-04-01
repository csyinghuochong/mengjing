
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
			await ETTask.CompletedTask;
		}

		public static void OnInitData(this Scroll_Item_SeasonDonateItem self, int time, string reward)
		{
			self.Time = time;
			self.ES_RewardList.Refresh(reward);
			
			self.E_ButtonReveiveButton.AddListenerAsync( self.OnButtonReveiveButton );
		}
	}
}
