
using System;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_DungeonItem : Entity,IAwake,IDestroy,IUIScrollItem 
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

		public UnityEngine.RectTransform EG_MoveRectTransform
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
		    			this.m_EG_MoveRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Move");
     				}
     				return this.m_EG_MoveRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Move");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_Image_DIButton
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
		    			this.m_E_Image_DIButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Move/E_Image_DI");
     				}
     				return this.m_E_Image_DIButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Move/E_Image_DI");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_Image_DIImage
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
		    			this.m_E_Image_DIImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Move/E_Image_DI");
     				}
     				return this.m_E_Image_DIImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Move/E_Image_DI");
     			}
     		}
     	}

		public UnityEngine.RectTransform EG_Node_1RectTransform
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
		    			this.m_EG_Node_1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Move/EG_Node_1");
     				}
     				return this.m_EG_Node_1RectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Move/EG_Node_1");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Text_NameText
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
		    			this.m_E_Text_NameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Move/EG_Node_1/E_Text_Name");
     				}
     				return this.m_E_Text_NameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Move/EG_Node_1/E_Text_Name");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Text_IndexText
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
		    			this.m_E_Text_IndexText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Move/EG_Node_1/E_Text_Index");
     				}
     				return this.m_E_Text_IndexText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Move/EG_Node_1/E_Text_Index");
     			}
     		}
     	}

		public UnityEngine.RectTransform EG_UnLockRectTransform
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
		    			this.m_EG_UnLockRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Move/EG_UnLock");
     				}
     				return this.m_EG_UnLockRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Move/EG_UnLock");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Text_UnlockLevelText
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
		    			this.m_E_Text_UnlockLevelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Move/EG_UnLock/E_Text_UnlockLevel");
     				}
     				return this.m_E_Text_UnlockLevelText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Move/EG_UnLock/E_Text_UnlockLevel");
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

		private UnityEngine.RectTransform m_EG_MoveRectTransform = null;
		private UnityEngine.UI.Button m_E_Image_DIButton = null;
		private UnityEngine.UI.Image m_E_Image_DIImage = null;
		private UnityEngine.RectTransform m_EG_Node_1RectTransform = null;
		private UnityEngine.UI.Text m_E_Text_NameText = null;
		private UnityEngine.UI.Text m_E_Text_IndexText = null;
		private UnityEngine.RectTransform m_EG_UnLockRectTransform = null;
		private UnityEngine.UI.Text m_E_Text_UnlockLevelText = null;
		public Transform uiTransform = null;
	}
}
