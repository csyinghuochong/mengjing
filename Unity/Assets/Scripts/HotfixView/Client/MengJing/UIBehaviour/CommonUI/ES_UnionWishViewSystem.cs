
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_UnionWish))]
	[FriendOfAttribute(typeof(ES_UnionWish))]
	public static partial class ES_UnionWishSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_UnionWish self,Transform transform)
		{
			self.uiTransform = transform;
            
            self.ES_UnionWishItem_1.OnInitType(1);
            self.ES_UnionWishItem_2.OnInitType(2);
            self.ES_UnionWishItem_3.OnInitType(3);
            
            self.E_ButtonSendButton.AddListenerAsync(self.OnClickSendButton);
		}

		[EntitySystem]
		private static void Destroy(this ES_UnionWish self)
		{
			self.DestroyWidget();
		}

		private static async ETTask OnClickSendButton(this ES_UnionWish self)
		{
            U2C_UnionMyInfoResponse response = await UnionNetHelper.UnionMyInfo( self.Root() );
            if (response.Error != ErrorCode.ERR_Success)
            {
	            return;
            }
            if ( CommonHelp.GetDayByTime(TimeHelper.ServerNow()) == CommonHelp.GetDayByTime(response.UnionMyInfo.UnionWishTime))
            {
	            FlyTipComponent.Instance.ShowFlyTip("当前已经发送过祝福!");
	            return;
            }

            await  UnionNetHelper.UnionWishSendRequest(self.Root());
		}
        
		public static void OnUpdateUI(this ES_UnionWish self)
		{
			Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
			self.EG_LeaderShowRectTransform.gameObject.SetActive(unit.GetUnionId()>0 && unit.GetUnionLeader()==1);
			
            List<RewardItem> rewardItems = new List<RewardItem>();
            foreach (var rewardlist in ConfigData.UnionWishRewardForPosition.Values)
            {
	            string[] itemlist = rewardlist.Split('@');
	            string[] iteminfo = itemlist[0].Split(';');
	            int itemid = int.Parse(iteminfo[0]);
	            int itemnum = int.Parse(iteminfo[1]);	
	            
	            rewardItems.Add(new RewardItem(){ItemID = itemid,ItemNum = itemnum});
            }
            
			self.ES_RewardList.Refresh( rewardItems );
		}
	}


}
