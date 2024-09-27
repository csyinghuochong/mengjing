
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	[ChildOf]
	public  class Scroll_Item_SkillTianFuItemTwo : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_SkillTianFuItemTwo> 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_SkillTianFuItemTwo BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Button E_ImageIconButton
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
     				if( this.m_E_ImageIconButton == null )
     				{
		    			this.m_E_ImageIconButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ImageIcon");
     				}
     				return this.m_E_ImageIconButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ImageIcon");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ImageIconImage
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
     				if( this.m_E_ImageIconImage == null )
     				{
		    			this.m_E_ImageIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageIcon");
     				}
     				return this.m_E_ImageIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageIcon");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_PointText
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
     				if( this.m_E_PointText == null )
     				{
		    			this.m_E_PointText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Point");
     				}
     				return this.m_E_PointText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Point");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageIconButton = null;
			this.m_E_ImageIconImage = null;
			this.m_E_PointText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Button m_E_ImageIconButton = null;
		private UnityEngine.UI.Image m_E_ImageIconImage = null;
		private UnityEngine.UI.Text m_E_PointText = null;
		public Transform uiTransform = null;
	}
}
