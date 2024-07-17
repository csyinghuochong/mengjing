using UnityEngine;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class Scroll_Item_PetMiningTeamItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_PetMiningTeamItem>
	{
		public int TeamId = 0;   //0 1 2
		public PetComponentC PetComponent { get; set; }
		public GameObject[] PetIcon_di_List = new GameObject[5];
		public EntityRef<Scroll_Item_PetFormationItem>[] FormationItemComponents = new EntityRef<Scroll_Item_PetFormationItem>[5];
		
		public GameObject TextTip11;
		public GameObject TextTip12;
		public GameObject IconItemDrag;
		public GameObject ButtonSet;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_PetMiningTeamItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public void DestroyWidget()
		{
			this.uiTransform = null;
			this.DataId = 0;
		}

		public Transform uiTransform = null;
	}
}
