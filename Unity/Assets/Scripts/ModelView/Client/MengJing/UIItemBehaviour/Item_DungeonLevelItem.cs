using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_DungeonLevelItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_DungeonLevelItem>
	{
		public int Type;
		public int LevelIndex;
		public int ChapterId;
		public float StartPosX;
		public Action<int> ClickHandler;
		public Vector3 CurPosition;
		public float SendTime;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_DungeonLevelItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public RectTransform EG_PostionSetRectTransform
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
     				if( this.m_EG_PostionSetRectTransform == null )
     				{
		    			this.m_EG_PostionSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_PostionSet");
     				}
     				return this.m_EG_PostionSetRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_PostionSet");
     			}
     		}
     	}

		public Text E_Lab_ChapSonNameOutText
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
     				if( this.m_E_Lab_ChapSonNameOutText == null )
     				{
		    			this.m_E_Lab_ChapSonNameOutText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_PostionSet/E_Lab_ChapSonNameOut");
     				}
     				return this.m_E_Lab_ChapSonNameOutText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_PostionSet/E_Lab_ChapSonNameOut");
     			}
     		}
     	}

		public Text E_Lab_EnterLevelText
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
     				if( this.m_E_Lab_EnterLevelText == null )
     				{
		    			this.m_E_Lab_EnterLevelText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_PostionSet/E_Lab_EnterLevel");
     				}
     				return this.m_E_Lab_EnterLevelText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_PostionSet/E_Lab_EnterLevel");
     			}
     		}
     	}

		public Image E_ImageSelectImage
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
     				if( this.m_E_ImageSelectImage == null )
     				{
		    			this.m_E_ImageSelectImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PostionSet/E_ImageSelect");
     				}
     				return this.m_E_ImageSelectImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PostionSet/E_ImageSelect");
     			}
     		}
     	}

		public Image E_ImageBossIconImage
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
     				if( this.m_E_ImageBossIconImage == null )
     				{
		    			this.m_E_ImageBossIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PostionSet/E_ImageBossIcon");
     				}
     				return this.m_E_ImageBossIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PostionSet/E_ImageBossIcon");
     			}
     		}
     	}

		public Button E_ImageButtonButton
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
     				if( this.m_E_ImageButtonButton == null )
     				{
		    			this.m_E_ImageButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_PostionSet/E_ImageButton");
     				}
     				return this.m_E_ImageButtonButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_PostionSet/E_ImageButton");
     			}
     		}
     	}

		public Image E_ImageButtonImage
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
     				if( this.m_E_ImageButtonImage == null )
     				{
		    			this.m_E_ImageButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PostionSet/E_ImageButton");
     				}
     				return this.m_E_ImageButtonImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PostionSet/E_ImageButton");
     			}
     		}
     	}

		public Button E_ButtonEnterButton
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
     				if( this.m_E_ButtonEnterButton == null )
     				{
		    			this.m_E_ButtonEnterButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_PostionSet/E_ButtonEnter");
     				}
     				return this.m_E_ButtonEnterButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_PostionSet/E_ButtonEnter");
     			}
     		}
     	}

		public Image E_ButtonEnterImage
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
     				if( this.m_E_ButtonEnterImage == null )
     				{
		    			this.m_E_ButtonEnterImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PostionSet/E_ButtonEnter");
     				}
     				return this.m_E_ButtonEnterImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PostionSet/E_ButtonEnter");
     			}
     		}
     	}

		public Text E_Lab_ChapIndexText
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
     				if( this.m_E_Lab_ChapIndexText == null )
     				{
		    			this.m_E_Lab_ChapIndexText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_PostionSet/E_Lab_ChapIndex");
     				}
     				return this.m_E_Lab_ChapIndexText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_PostionSet/E_Lab_ChapIndex");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_PostionSetRectTransform = null;
			this.m_E_Lab_ChapSonNameOutText = null;
			this.m_E_Lab_EnterLevelText = null;
			this.m_E_ImageSelectImage = null;
			this.m_E_ImageBossIconImage = null;
			this.m_E_ImageButtonButton = null;
			this.m_E_ImageButtonImage = null;
			this.m_E_ButtonEnterButton = null;
			this.m_E_ButtonEnterImage = null;
			this.m_E_Lab_ChapIndexText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private RectTransform m_EG_PostionSetRectTransform = null;
		private Text m_E_Lab_ChapSonNameOutText = null;
		private Text m_E_Lab_EnterLevelText = null;
		private Image m_E_ImageSelectImage = null;
		private Image m_E_ImageBossIconImage = null;
		private Button m_E_ImageButtonButton = null;
		private Image m_E_ImageButtonImage = null;
		private Button m_E_ButtonEnterButton = null;
		private Image m_E_ButtonEnterImage = null;
		private Text m_E_Lab_ChapIndexText = null;
		public Transform uiTransform = null;
	}
}
