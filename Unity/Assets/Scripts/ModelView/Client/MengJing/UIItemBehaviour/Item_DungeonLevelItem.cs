
using System;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_DungeonLevelItem : Entity,IAwake,IDestroy,IUIScrollItem
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

		public UnityEngine.RectTransform EG_PostionSetRectTransform
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
		    			this.m_EG_PostionSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_PostionSet");
     				}
     				return this.m_EG_PostionSetRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_PostionSet");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Lab_ChapSonNameOutText
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
		    			this.m_E_Lab_ChapSonNameOutText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_PostionSet/E_Lab_ChapSonNameOut");
     				}
     				return this.m_E_Lab_ChapSonNameOutText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_PostionSet/E_Lab_ChapSonNameOut");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Lab_EnterLevelText
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
		    			this.m_E_Lab_EnterLevelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_PostionSet/E_Lab_EnterLevel");
     				}
     				return this.m_E_Lab_EnterLevelText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_PostionSet/E_Lab_EnterLevel");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ImageSelectImage
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
		    			this.m_E_ImageSelectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PostionSet/E_ImageSelect");
     				}
     				return this.m_E_ImageSelectImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PostionSet/E_ImageSelect");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ImageBossIconImage
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
		    			this.m_E_ImageBossIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PostionSet/E_ImageBossIcon");
     				}
     				return this.m_E_ImageBossIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PostionSet/E_ImageBossIcon");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_ImageButtonButton
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
		    			this.m_E_ImageButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_PostionSet/E_ImageButton");
     				}
     				return this.m_E_ImageButtonButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_PostionSet/E_ImageButton");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ImageButtonImage
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
		    			this.m_E_ImageButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PostionSet/E_ImageButton");
     				}
     				return this.m_E_ImageButtonImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PostionSet/E_ImageButton");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_ButtonEnterButton
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
		    			this.m_E_ButtonEnterButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_PostionSet/E_ButtonEnter");
     				}
     				return this.m_E_ButtonEnterButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_PostionSet/E_ButtonEnter");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ButtonEnterImage
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
		    			this.m_E_ButtonEnterImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PostionSet/E_ButtonEnter");
     				}
     				return this.m_E_ButtonEnterImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PostionSet/E_ButtonEnter");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Lab_ChapIndexText
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
		    			this.m_E_Lab_ChapIndexText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_PostionSet/E_Lab_ChapIndex");
     				}
     				return this.m_E_Lab_ChapIndexText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_PostionSet/E_Lab_ChapIndex");
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

		private UnityEngine.RectTransform m_EG_PostionSetRectTransform = null;
		private UnityEngine.UI.Text m_E_Lab_ChapSonNameOutText = null;
		private UnityEngine.UI.Text m_E_Lab_EnterLevelText = null;
		private UnityEngine.UI.Image m_E_ImageSelectImage = null;
		private UnityEngine.UI.Image m_E_ImageBossIconImage = null;
		private UnityEngine.UI.Button m_E_ImageButtonButton = null;
		private UnityEngine.UI.Image m_E_ImageButtonImage = null;
		private UnityEngine.UI.Button m_E_ButtonEnterButton = null;
		private UnityEngine.UI.Image m_E_ButtonEnterImage = null;
		private UnityEngine.UI.Text m_E_Lab_ChapIndexText = null;
		public Transform uiTransform = null;
	}
}
