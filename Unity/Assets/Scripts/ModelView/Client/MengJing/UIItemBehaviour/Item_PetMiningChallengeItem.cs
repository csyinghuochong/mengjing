using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public class Scroll_Item_PetMiningChallengeItem: Entity, IAwake, IDestroy, IUIScrollItem<Scroll_Item_PetMiningChallengeItem>
	{
		public int TeamId = 0; //0 1 2
		public GameObject TextTip11;
		public GameObject TextTip12;
		public GameObject TextTip13;
		public PetComponentC PetComponent { get; set; }
		public Image[] PetIcon_List = new Image[5];
		public GameObject ButtonSelect;
		public GameObject ImageSelect;
		public Action<int> SelectHandler;
		public bool Defend;
		public int PetNumber = 0;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_PetMiningChallengeItem BindTrans(Transform trans)
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
