
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_PetFightItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_PetFightItem> 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_PetFightItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Image E_PetHPImage
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
     				if( this.m_E_PetHPImage == null )
     				{
		    			this.m_E_PetHPImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_PetHP");
     				}
     				return this.m_E_PetHPImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_PetHP");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_PetIconImage
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
     				if( this.m_E_PetIconImage == null )
     				{
		    			this.m_E_PetIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Mask/E_PetIcon");
     				}
     				return this.m_E_PetIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Mask/E_PetIcon");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_PetLvText
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
     				if( this.m_E_PetLvText == null )
     				{
		    			this.m_E_PetLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Image/E_PetLv");
     				}
     				return this.m_E_PetLvText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Image/E_PetLv");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_ClickButton
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
     				if( this.m_E_ClickButton == null )
     				{
		    			this.m_E_ClickButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Click");
     				}
     				return this.m_E_ClickButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Click");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ClickImage
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
     				if( this.m_E_ClickImage == null )
     				{
		    			this.m_E_ClickImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Click");
     				}
     				return this.m_E_ClickImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Click");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_PetHPImage = null;
			this.m_E_PetIconImage = null;
			this.m_E_PetLvText = null;
			this.m_E_ClickButton = null;
			this.m_E_ClickImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Image m_E_PetHPImage = null;
		private UnityEngine.UI.Image m_E_PetIconImage = null;
		private UnityEngine.UI.Text m_E_PetLvText = null;
		private UnityEngine.UI.Button m_E_ClickButton = null;
		private UnityEngine.UI.Image m_E_ClickImage = null;
		public Transform uiTransform = null;
	}
}
