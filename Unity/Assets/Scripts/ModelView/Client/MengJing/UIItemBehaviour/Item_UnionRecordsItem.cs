
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_UnionRecordsItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_UnionRecordsItem>
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_UnionRecordsItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Image E_HeadIconImage
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
     				if( this.m_E_HeadIconImage == null )
     				{
		    			this.m_E_HeadIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_HeadIcon");
     				}
     				return this.m_E_HeadIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_HeadIcon");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_TextContentText
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
     				if( this.m_E_TextContentText == null )
     				{
		    			this.m_E_TextContentText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextContent");
     				}
     				return this.m_E_TextContentText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextContent");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_HeadIconImage = null;
			this.m_E_TextContentText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Image m_E_HeadIconImage = null;
		private UnityEngine.UI.Text m_E_TextContentText = null;
		public Transform uiTransform = null;
	}
}
