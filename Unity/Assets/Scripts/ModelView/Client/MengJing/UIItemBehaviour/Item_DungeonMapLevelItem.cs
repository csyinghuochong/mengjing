
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

		public UnityEngine.UI.Image E_IconImage
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
		    			this.m_E_IconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Icon");
     				}
     				return this.m_E_IconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Icon");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_LevelNameText
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
		    			this.m_E_LevelNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_LevelName");
     				}
     				return this.m_E_LevelNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_LevelName");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_EnterLevelText
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
		    			this.m_E_EnterLevelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_EnterLevel");
     				}
     				return this.m_E_EnterLevelText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_EnterLevel");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_NanDu_1Button
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
     				if( this.m_E_NanDu_1Button == null )
     				{
		    			this.m_E_NanDu_1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_NanDu_1");
     				}
     				return this.m_E_NanDu_1Button;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_NanDu_1");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_NanDu_1Image
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
		    			this.m_E_NanDu_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_NanDu_1");
     				}
     				return this.m_E_NanDu_1Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_NanDu_1");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_NanDu_2Button
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
     				if( this.m_E_NanDu_2Button == null )
     				{
		    			this.m_E_NanDu_2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_NanDu_2");
     				}
     				return this.m_E_NanDu_2Button;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_NanDu_2");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_NanDu_2Image
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
		    			this.m_E_NanDu_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_NanDu_2");
     				}
     				return this.m_E_NanDu_2Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_NanDu_2");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_NanDu_3Button
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
     				if( this.m_E_NanDu_3Button == null )
     				{
		    			this.m_E_NanDu_3Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_NanDu_3");
     				}
     				return this.m_E_NanDu_3Button;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_NanDu_3");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_NanDu_3Image
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
		    			this.m_E_NanDu_3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_NanDu_3");
     				}
     				return this.m_E_NanDu_3Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_NanDu_3");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_SelectImage
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
		    			this.m_E_SelectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Select");
     				}
     				return this.m_E_SelectImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Select");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_IconImage = null;
			this.m_E_LevelNameText = null;
			this.m_E_EnterLevelText = null;
			this.m_E_NanDu_1Button = null;
			this.m_E_NanDu_1Image = null;
			this.m_E_NanDu_2Button = null;
			this.m_E_NanDu_2Image = null;
			this.m_E_NanDu_3Button = null;
			this.m_E_NanDu_3Image = null;
			this.m_E_SelectImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Image m_E_IconImage = null;
		private UnityEngine.UI.Text m_E_LevelNameText = null;
		private UnityEngine.UI.Text m_E_EnterLevelText = null;
		private UnityEngine.UI.Button m_E_NanDu_1Button = null;
		private UnityEngine.UI.Image m_E_NanDu_1Image = null;
		private UnityEngine.UI.Button m_E_NanDu_2Button = null;
		private UnityEngine.UI.Image m_E_NanDu_2Image = null;
		private UnityEngine.UI.Button m_E_NanDu_3Button = null;
		private UnityEngine.UI.Image m_E_NanDu_3Image = null;
		private UnityEngine.UI.Image m_E_SelectImage = null;
		public Transform uiTransform = null;
	}
}
