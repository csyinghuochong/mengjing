
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_CommonItem : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_CommonItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public ES_CommonItem ES_CommonItem
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_commonitem == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem");
		    	   this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem;
     		}

	        set
	        {
		        this.m_es_commonitem = value;
	        }
     	}

		public void DestroyWidget()
		{
			this.m_es_commonitem = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		public Transform uiTransform = null;
	}
}
