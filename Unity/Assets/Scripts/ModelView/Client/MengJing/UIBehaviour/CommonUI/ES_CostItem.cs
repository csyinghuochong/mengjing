
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_CostItem : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.Image E_ItemQualityImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemQualityImage == null )
     			{
		    		this.m_E_ItemQualityImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ItemQuality");
     			}
     			return this.m_E_ItemQualityImage;
     		}
     	}

		public UnityEngine.UI.Image E_ItemIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemIconImage == null )
     			{
		    		this.m_E_ItemIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ItemIcon");
     			}
     			return this.m_E_ItemIconImage;
     		}
     	}

		public UnityEngine.UI.Text E_ItemNumText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemNumText == null )
     			{
		    		this.m_E_ItemNumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_ItemNum");
     			}
     			return this.m_E_ItemNumText;
     		}
     	}

		public UnityEngine.UI.Text E_ItemNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemNameText == null )
     			{
		    		this.m_E_ItemNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_ItemName");
     			}
     			return this.m_E_ItemNameText;
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
			this.m_E_ItemQualityImage = null;
			this.m_E_ItemIconImage = null;
			this.m_E_ItemNumText = null;
			this.m_E_ItemNameText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_E_ItemQualityImage = null;
		private UnityEngine.UI.Image m_E_ItemIconImage = null;
		private UnityEngine.UI.Text m_E_ItemNumText = null;
		private UnityEngine.UI.Text m_E_ItemNameText = null;
		public Transform uiTransform = null;
	}
}
