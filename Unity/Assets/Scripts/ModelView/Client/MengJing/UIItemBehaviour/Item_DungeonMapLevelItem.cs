using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_DungeonMapLevelItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_DungeonMapLevelItem> 
	{
		public int LevelIndex;
		public int LevelId;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_DungeonMapLevelItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Image E_IconImage
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
     				if( this.m_E_IconImage == null )
     				{
		    			this.m_E_IconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Icon");
     				}
     				return this.m_E_IconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Icon");
     			}
     		}
     	}

		public Text E_LevelNameText
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
     				if( this.m_E_LevelNameText == null )
     				{
		    			this.m_E_LevelNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_LevelName");
     				}
     				return this.m_E_LevelNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_LevelName");
     			}
     		}
     	}

		public Text E_EnterLevelText
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
     				if( this.m_E_EnterLevelText == null )
     				{
		    			this.m_E_EnterLevelText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_EnterLevel");
     				}
     				return this.m_E_EnterLevelText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_EnterLevel");
     			}
     		}
     	}

		public Image E_NanDu_1Image
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
     				if( this.m_E_NanDu_1Image == null )
     				{
		    			this.m_E_NanDu_1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_NanDu_1");
     				}
     				return this.m_E_NanDu_1Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_NanDu_1");
     			}
     		}
     	}

		public Image E_NanDu_2Image
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
     				if( this.m_E_NanDu_2Image == null )
     				{
		    			this.m_E_NanDu_2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_NanDu_2");
     				}
     				return this.m_E_NanDu_2Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_NanDu_2");
     			}
     		}
     	}

		public Image E_NanDu_3Image
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
     				if( this.m_E_NanDu_3Image == null )
     				{
		    			this.m_E_NanDu_3Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_NanDu_3");
     				}
     				return this.m_E_NanDu_3Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_NanDu_3");
     			}
     		}
     	}

		public Image E_SelectImage
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
     				if( this.m_E_SelectImage == null )
     				{
		    			this.m_E_SelectImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Select");
     				}
     				return this.m_E_SelectImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Select");
     			}
     		}
     	}

		public Button E_ClickButton
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
		    			this.m_E_ClickButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Click");
     				}
     				return this.m_E_ClickButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Click");
     			}
     		}
     	}

		public Image E_ClickImage
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
		    			this.m_E_ClickImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Click");
     				}
     				return this.m_E_ClickImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Click");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_IconImage = null;
			this.m_E_LevelNameText = null;
			this.m_E_EnterLevelText = null;
			this.m_E_NanDu_1Image = null;
			this.m_E_NanDu_2Image = null;
			this.m_E_NanDu_3Image = null;
			this.m_E_SelectImage = null;
			this.m_E_ClickButton = null;
			this.m_E_ClickImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Image m_E_IconImage = null;
		private Text m_E_LevelNameText = null;
		private Text m_E_EnterLevelText = null;
		private Image m_E_NanDu_1Image = null;
		private Image m_E_NanDu_2Image = null;
		private Image m_E_NanDu_3Image = null;
		private Image m_E_SelectImage = null;
		private Button m_E_ClickButton = null;
		private Image m_E_ClickImage = null;
		public Transform uiTransform = null;
	}
}
