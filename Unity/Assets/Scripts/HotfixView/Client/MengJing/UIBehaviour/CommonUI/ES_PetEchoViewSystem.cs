
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_PetEcho))]
	[FriendOfAttribute(typeof(ES_PetEcho))]
	public static partial class ES_PetEchoSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_PetEcho self,Transform transform)
		{
			self.uiTransform = transform;
			
			self.E_PetEchoItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPetEchoItemsRefresh);
			self.E_PetEchoSkillItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPetEchoSkillItemsRefresh);
		}
		
		private static void OnPetEchoItemsRefresh(this ES_PetEcho self, Transform transform, int index)
		{
			Scroll_Item_PetEchoItem scrollItemPetListItem = self.ScrollItemPetEchoItems[index].BindTrans(transform);
		}

		private static void OnPetEchoSkillItemsRefresh(this ES_PetEcho self, Transform transform, int index)
		{
			Scroll_Item_PetEchoSkillItem scrollItemPetListItem = self.ScrollItemPetEchoSkillItems[index].BindTrans(transform);
		}
		
		[EntitySystem]
		private static void Destroy(this ES_PetEcho self)
		{
			self.DestroyWidget();
		}

		public static void OnUpdateUI(this ES_PetEcho self)
		{
			self.InitPetEchoItemList();
			self.InitPetEchoSkillItemList();
		}

		private static void InitPetEchoItemList(this ES_PetEcho self)
		{
			self.AddUIScrollItems(ref self.ScrollItemPetEchoItems, ConfigData.PetEchoAttri.Count);
			self.E_PetEchoItemsLoopVerticalScrollRect.SetVisible(true, ConfigData.PetEchoAttri.Count);
		}
		private static void UpdatePetEchoItemList(this ES_PetEcho self)
		{
			self.AddUIScrollItems(ref self.ScrollItemPetEchoSkillItems, ConfigData.PetEchoSkill.Count);
			self.E_PetEchoSkillItemsLoopVerticalScrollRect.SetVisible(true, ConfigData.PetEchoSkill.Count);
		}
		
		private static void InitPetEchoSkillItemList(this ES_PetEcho self)
		{
			
		}
		
		private static void UpdatePetEchoSkillItemList(this ES_PetEcho self)
		{
        			
		}
	}


}
