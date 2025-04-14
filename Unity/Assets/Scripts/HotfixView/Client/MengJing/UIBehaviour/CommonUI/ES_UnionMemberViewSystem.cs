using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ET.Client
{
	[FriendOf(typeof(Scroll_Item_UnionMemberItem))]
	[EntitySystemOf(typeof(ES_UnionMember))]
	[FriendOfAttribute(typeof(ES_UnionMember))]
	public static partial class ES_UnionMemberSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_UnionMember self,Transform transform)
		{
			self.uiTransform = transform;
			self.E_UnionMyItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnUnionMyItemsRefresh);

		}

		[EntitySystem]
		private static void Destroy(this ES_UnionMember self)
		{
			self.DestroyWidget();
		}
		
		public static async ETTask OnUpdateUI(this ES_UnionMember self)
		{
			U2C_UnionMyInfoResponse response = await UnionNetHelper.UnionMyInfo(self.Root());

			self.UnionInfo = response.UnionMyInfo;
			self.OnLinePlayer = response.OnLinePlayer;
			
			self.UpdateMyUnion();
		}
		
		private static void OnUnionMyItemsRefresh(this ES_UnionMember self, Transform transform, int index)
		{
			foreach (Scroll_Item_UnionMemberItem item in self.ScrollItemUnionMyItems.Values)
			{
				if (item.uiTransform == transform)
				{
					item.uiTransform = null;
				}
			}
			
			Scroll_Item_UnionMemberItem scrollItemUnionMyItem = self.ScrollItemUnionMyItems[index].BindTrans(transform);
			scrollItemUnionMyItem.OnUpdateUI(self.UnionInfo, self.ShowUnionPlayerInfos[index]);
		}
        
		  public static void UpdateMyUnion(this ES_UnionMember self)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            UnionPlayerInfo mainPlayerInfo = UnionHelper.GetUnionPlayerInfo(self.UnionInfo.UnionPlayerList, userInfoComponent.UserInfo.UserId);
            UnionConfig unionCof = UnionConfigCategory.Instance.Get(self.UnionInfo.Level);
            bool leader = userInfoComponent.UserInfo.UserId == self.UnionInfo.LeaderId;
         
            List<Entity> childs = self.Children.Values.ToList();
            self.UnionInfo.UnionPlayerList.Sort(delegate(UnionPlayerInfo a, UnionPlayerInfo b)
            {
                //int leaderida = (a.UserID == self.UnionInfo.LeaderId) ? 1 : 0;
                //int leaderidb = (b.UserID == self.UnionInfo.LeaderId) ? 1 : 0;
                //return (leaderidb - leaderida);
                int positiona = a.Position == 0 ? 10 : a.Position;
                int positionb = b.Position == 0 ? 10 : b.Position;
                return positiona - positionb;
            });

            self.ShowUnionPlayerInfos.Clear();
            for (int i = 0; i < self.UnionInfo.UnionPlayerList.Count; i++)
            {
                UnionPlayerInfo unionPlayerInfo = self.UnionInfo.UnionPlayerList[i];
                self.ShowUnionPlayerInfos.Add(unionPlayerInfo);
            }

            self.AddUIScrollItems(ref self.ScrollItemUnionMyItems, self.ShowUnionPlayerInfos.Count);
            self.E_UnionMyItemsLoopVerticalScrollRect.SetVisible(true, self.ShowUnionPlayerInfos.Count);
        }
	}


}
