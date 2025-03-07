
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_XiLianShowEquipPropertyItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_XiLianShowEquipPropertyItem> 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_XiLianShowEquipPropertyItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Text E_PropertyText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_PropertyText == null )
     				{
		    			this.m_E_PropertyText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Property");
     				}
     				return this.m_E_PropertyText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Property");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ImageExpValueImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ImageExpValueImage == null )
     				{
		    			this.m_E_ImageExpValueImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageExpValue");
     				}
     				return this.m_E_ImageExpValueImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageExpValue");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_PropertyText = null;
			this.m_E_ImageExpValueImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Text m_E_PropertyText = null;
		private UnityEngine.UI.Image m_E_ImageExpValueImage = null;
		public Transform uiTransform = null;
	}
}
