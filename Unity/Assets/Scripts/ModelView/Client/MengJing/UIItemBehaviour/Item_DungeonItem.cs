using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_DungeonItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_DungeonItem> 
	{
		public Action<int> ClickHandler;
		public int ChapterId;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_DungeonItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public RectTransform EG_MoveRectTransform
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
     				if( this.m_EG_MoveRectTransform == null )
     				{
		    			this.m_EG_MoveRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Move");
     				}
     				return this.m_EG_MoveRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Move");
     			}
     		}
     	}

		public Button E_Image_DIButton
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
     				if( this.m_E_Image_DIButton == null )
     				{
		    			this.m_E_Image_DIButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Move/E_Image_DI");
     				}
     				return this.m_E_Image_DIButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Move/E_Image_DI");
     			}
     		}
     	}

		public Image E_Image_DIImage
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
     				if( this.m_E_Image_DIImage == null )
     				{
		    			this.m_E_Image_DIImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Move/E_Image_DI");
     				}
     				return this.m_E_Image_DIImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Move/E_Image_DI");
     			}
     		}
     	}

		public RectTransform EG_Node_1RectTransform
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
     				if( this.m_EG_Node_1RectTransform == null )
     				{
		    			this.m_EG_Node_1RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Move/EG_Node_1");
     				}
     				return this.m_EG_Node_1RectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Move/EG_Node_1");
     			}
     		}
     	}

		public Text E_Text_NameText
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
     				if( this.m_E_Text_NameText == null )
     				{
		    			this.m_E_Text_NameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Move/EG_Node_1/E_Text_Name");
     				}
     				return this.m_E_Text_NameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Move/EG_Node_1/E_Text_Name");
     			}
     		}
     	}

		public Text E_Text_IndexText
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
     				if( this.m_E_Text_IndexText == null )
     				{
		    			this.m_E_Text_IndexText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Move/EG_Node_1/E_Text_Index");
     				}
     				return this.m_E_Text_IndexText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Move/EG_Node_1/E_Text_Index");
     			}
     		}
     	}

		public RectTransform EG_UnLockRectTransform
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
     				if( this.m_EG_UnLockRectTransform == null )
     				{
		    			this.m_EG_UnLockRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Move/EG_UnLock");
     				}
     				return this.m_EG_UnLockRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Move/EG_UnLock");
     			}
     		}
     	}

		public Text E_Text_UnlockLevelText
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
     				if( this.m_E_Text_UnlockLevelText == null )
     				{
		    			this.m_E_Text_UnlockLevelText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Move/EG_UnLock/E_Text_UnlockLevel");
     				}
     				return this.m_E_Text_UnlockLevelText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Move/EG_UnLock/E_Text_UnlockLevel");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_MoveRectTransform = null;
			this.m_E_Image_DIButton = null;
			this.m_E_Image_DIImage = null;
			this.m_EG_Node_1RectTransform = null;
			this.m_E_Text_NameText = null;
			this.m_E_Text_IndexText = null;
			this.m_EG_UnLockRectTransform = null;
			this.m_E_Text_UnlockLevelText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private RectTransform m_EG_MoveRectTransform = null;
		private Button m_E_Image_DIButton = null;
		private Image m_E_Image_DIImage = null;
		private RectTransform m_EG_Node_1RectTransform = null;
		private Text m_E_Text_NameText = null;
		private Text m_E_Text_IndexText = null;
		private RectTransform m_EG_UnLockRectTransform = null;
		private Text m_E_Text_UnlockLevelText = null;
		public Transform uiTransform = null;
	}
}
