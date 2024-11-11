
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ChengJiuJingling : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.RectTransform EG_LeftRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_LeftRectTransform == null )
     			{
		    		this.m_EG_LeftRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Left");
     			}
     			return this.m_EG_LeftRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_TotalProgressText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TotalProgressText == null )
     			{
		    		this.m_E_TotalProgressText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Left/E_TotalProgress");
     			}
     			return this.m_E_TotalProgressText;
     		}
     	}

		public UnityEngine.UI.ToggleGroup E_ItemTypeSetToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemTypeSetToggleGroup == null )
     			{
		    		this.m_E_ItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"EG_Left/E_ItemTypeSet");
     			}
     			return this.m_E_ItemTypeSetToggleGroup;
     		}
     	}

		public UnityEngine.UI.Image E_ChengJiuJinglingItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChengJiuJinglingItemsImage == null )
     			{
		    		this.m_E_ChengJiuJinglingItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Left/E_ChengJiuJinglingItems");
     			}
     			return this.m_E_ChengJiuJinglingItemsImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_ChengJiuJinglingItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChengJiuJinglingItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_ChengJiuJinglingItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_Left/E_ChengJiuJinglingItems");
     			}
     			return this.m_E_ChengJiuJinglingItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.RectTransform EG_RightRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_RightRectTransform == null )
     			{
		    		this.m_EG_RightRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right");
     			}
     			return this.m_EG_RightRectTransform;
     		}
     	}

		    public Transform UITransform
         {
     	    get
     	    {
     		    return this.uiTransform;
     	    }
     	    set
     	    {
     		    this.uiTransform = value;
     	    }
         }

		public void DestroyWidget()
		{
			this.m_EG_LeftRectTransform = null;
			this.m_E_TotalProgressText = null;
			this.m_E_ItemTypeSetToggleGroup = null;
			this.m_E_ChengJiuJinglingItemsImage = null;
			this.m_E_ChengJiuJinglingItemsLoopVerticalScrollRect = null;
			this.m_EG_RightRectTransform = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_LeftRectTransform = null;
		private UnityEngine.UI.Text m_E_TotalProgressText = null;
		private UnityEngine.UI.ToggleGroup m_E_ItemTypeSetToggleGroup = null;
		private UnityEngine.UI.Image m_E_ChengJiuJinglingItemsImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_ChengJiuJinglingItemsLoopVerticalScrollRect = null;
		private UnityEngine.RectTransform m_EG_RightRectTransform = null;
		public Transform uiTransform = null;
	}
}
