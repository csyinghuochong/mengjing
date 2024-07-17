using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_BossRefreshSettingItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_BossRefreshSettingItem>
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_BossRefreshSettingItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Text E_NameTextText
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
     				if( this.m_E_NameTextText == null )
     				{
		    			this.m_E_NameTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_NameText");
     				}
     				return this.m_E_NameTextText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_NameText");
     			}
     		}
     	}

		public Button E_ToggleBtnButton
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
     				if( this.m_E_ToggleBtnButton == null )
     				{
		    			this.m_E_ToggleBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ToggleBtn");
     				}
     				return this.m_E_ToggleBtnButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ToggleBtn");
     			}
     		}
     	}

		public Image E_ToggleBtnImage
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
     				if( this.m_E_ToggleBtnImage == null )
     				{
		    			this.m_E_ToggleBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ToggleBtn");
     				}
     				return this.m_E_ToggleBtnImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ToggleBtn");
     			}
     		}
     	}

		public Image E_ShowTextImage
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
     				if( this.m_E_ShowTextImage == null )
     				{
		    			this.m_E_ShowTextImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ToggleBtn/E_ShowText");
     				}
     				return this.m_E_ShowTextImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ToggleBtn/E_ShowText");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_NameTextText = null;
			this.m_E_ToggleBtnButton = null;
			this.m_E_ToggleBtnImage = null;
			this.m_E_ShowTextImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Text m_E_NameTextText = null;
		private Button m_E_ToggleBtnButton = null;
		private Image m_E_ToggleBtnImage = null;
		private Image m_E_ShowTextImage = null;
		public Transform uiTransform = null;
	}
}
