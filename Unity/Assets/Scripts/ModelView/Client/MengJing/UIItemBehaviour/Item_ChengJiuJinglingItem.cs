
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_ChengJiuJinglingItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_ChengJiuJinglingItem> 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_ChengJiuJinglingItem BindTrans(Transform trans)
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
