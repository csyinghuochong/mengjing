
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_UnionWishItem))]
	[FriendOfAttribute(typeof(ES_UnionWishItem))]
	public static partial class ES_UnionWishItemSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_UnionWishItem self,Transform transform)
		{
			self.uiTransform = transform;
			
			self.E_ButtonGetButton.AddListenerAsync(self.OnClickGetButton );
		}

		[EntitySystem]
		private static void Destroy(this ES_UnionWishItem self)
		{
			self.DestroyWidget();
		}

		private static async ETTask OnClickGetButton(this ES_UnionWishItem self)
		{
			Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
			NumericComponentC numericComponentC = unit.GetComponent<NumericComponentC>();
			if (numericComponentC.GetAsInt(NumericType.UnionWishGet) > 0)
			{
				FlyTipComponent.Instance.ShowFlyTip("当天已经领取过祝福！");
				return;
			}
			UserInfoComponentC userInfoComponentC = self.Root().GetComponent<UserInfoComponentC>();
			if (self.WishType == 2 && userInfoComponentC.UserInfo.Gold < ConfigData.UnionWishGetGoldCost)
			{
				FlyTipComponent.Instance.ShowFlyTip("金币不足！");
				return;
			}

			if (self.WishType == 3 && userInfoComponentC.UserInfo.Diamond < ConfigData.UnionWishGetDiamondCost)
			{
				FlyTipComponent.Instance.ShowFlyTip("钻石不足！");
				return;
			}

			M2C_UnionWishGetResponse response = await  UnionNetHelper.UnionWishGetRequest(self.Root(), self.WishType);
		}

		public static void OnInitType(this ES_UnionWishItem self, int type)
		{
			self.WishType  = type;	
			switch (type)
			{
				case 2:
					self.E_Text_WishCost.text = ConfigData.UnionWishGetGoldCost.ToString();
					break;
				case 3:
					self.E_Text_WishCost.text = ConfigData.UnionWishGetDiamondCost.ToString();
					break;	
				default:
					break;		
			}
			
			string reward = ConfigData.UnionWishRewardForType[type];
			self.ES_RewardList.Refresh(reward);
		}
	}


}
