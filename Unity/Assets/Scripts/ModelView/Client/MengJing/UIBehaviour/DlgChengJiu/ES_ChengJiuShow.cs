
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ChengJiuShow : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public List<int> ShowTask = new();
		public Dictionary<int, EntityRef<Scroll_Item_ChengJiuShowItem>> ScrollItemChengJiuShowItems;
		public List<UIChengJiuShowType> UIChengJiuShowTypes = new();
		public GameObject LeftContent;
		public GameObject UIChengJiuShowType;
		public GameObject UIChengJiuShowChapterItemListNode;
		public UnityEngine.UI.Button E_ImageButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageButtonButton == null )
     			{
		    		this.m_E_ImageButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/LeftContent/UIChengJiuShowType/E_ImageButton");
     			}
     			return this.m_E_ImageButtonButton;
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
     			if( this.m_E_ImageButtonImage == null )
     			{
		    		this.m_E_ImageButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/LeftContent/UIChengJiuShowType/E_ImageButton");
     			}
     			return this.m_E_ImageButtonImage;
     		}
     	}

		public UnityEngine.UI.Image E_CheckmarkImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CheckmarkImage == null )
     			{
		    		this.m_E_CheckmarkImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/LeftContent/UIChengJiuShowType/E_Checkmark");
     			}
     			return this.m_E_CheckmarkImage;
     		}
     	}

		public UnityEngine.UI.Text E_TaskTypeNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TaskTypeNameText == null )
     			{
		    		this.m_E_TaskTypeNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/LeftContent/UIChengJiuShowType/E_TaskTypeName");
     			}
     			return this.m_E_TaskTypeNameText;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_ChengJiuTypeItemItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChengJiuTypeItemItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_ChengJiuTypeItemItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/LeftContent/UIChengJiuShowType/E_ChengJiuTypeItemItems");
     			}
     			return this.m_E_ChengJiuTypeItemItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_Ima_DiButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Ima_DiButton == null )
     			{
		    		this.m_E_Ima_DiButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/LeftContent/UIChengJiuShowChapterItemListNode/UIChengJiuShowChapterItem/E_Ima_Di");
     			}
     			return this.m_E_Ima_DiButton;
     		}
     	}

		public UnityEngine.UI.Image E_Ima_DiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Ima_DiImage == null )
     			{
		    		this.m_E_Ima_DiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/LeftContent/UIChengJiuShowChapterItemListNode/UIChengJiuShowChapterItem/E_Ima_Di");
     			}
     			return this.m_E_Ima_DiImage;
     		}
     	}

		public UnityEngine.UI.Image E_Ima_SelectStatusImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Ima_SelectStatusImage == null )
     			{
		    		this.m_E_Ima_SelectStatusImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/LeftContent/UIChengJiuShowChapterItemListNode/UIChengJiuShowChapterItem/E_Ima_SelectStatus");
     			}
     			return this.m_E_Ima_SelectStatusImage;
     		}
     	}

		public UnityEngine.UI.Image E_Ima_ItemQulityImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Ima_ItemQulityImage == null )
     			{
		    		this.m_E_Ima_ItemQulityImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/LeftContent/UIChengJiuShowChapterItemListNode/UIChengJiuShowChapterItem/E_Ima_ItemQulity");
     			}
     			return this.m_E_Ima_ItemQulityImage;
     		}
     	}

		public UnityEngine.UI.Image E_Ima_ItemIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Ima_ItemIconImage == null )
     			{
		    		this.m_E_Ima_ItemIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/LeftContent/UIChengJiuShowChapterItemListNode/UIChengJiuShowChapterItem/E_Ima_ItemIcon");
     			}
     			return this.m_E_Ima_ItemIconImage;
     		}
     	}

		public UnityEngine.UI.Image E_Ima_ProgressImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Ima_ProgressImage == null )
     			{
		    		this.m_E_Ima_ProgressImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/LeftContent/UIChengJiuShowChapterItemListNode/UIChengJiuShowChapterItem/E_Ima_Progress");
     			}
     			return this.m_E_Ima_ProgressImage;
     		}
     	}

		public UnityEngine.UI.Image E_Ima_CompleteTaskImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Ima_CompleteTaskImage == null )
     			{
		    		this.m_E_Ima_CompleteTaskImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/LeftContent/UIChengJiuShowChapterItemListNode/UIChengJiuShowChapterItem/E_Ima_CompleteTask");
     			}
     			return this.m_E_Ima_CompleteTaskImage;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_TaskNumText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_TaskNumText == null )
     			{
		    		this.m_E_Lab_TaskNumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/LeftContent/UIChengJiuShowChapterItemListNode/UIChengJiuShowChapterItem/E_Lab_TaskNum");
     			}
     			return this.m_E_Lab_TaskNumText;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_TaskNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_TaskNameText == null )
     			{
		    		this.m_E_Lab_TaskNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/LeftContent/UIChengJiuShowChapterItemListNode/UIChengJiuShowChapterItem/E_Lab_TaskName");
     			}
     			return this.m_E_Lab_TaskNameText;
     		}
     	}

		public UnityEngine.UI.Image E_ChengJiuShowItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChengJiuShowItemsImage == null )
     			{
		    		this.m_E_ChengJiuShowItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ChengJiuShowItems");
     			}
     			return this.m_E_ChengJiuShowItemsImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_ChengJiuShowItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChengJiuShowItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_ChengJiuShowItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_ChengJiuShowItems");
     			}
     			return this.m_E_ChengJiuShowItemsLoopVerticalScrollRect;
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
			this.m_E_ImageButtonButton = null;
			this.m_E_ImageButtonImage = null;
			this.m_E_CheckmarkImage = null;
			this.m_E_TaskTypeNameText = null;
			this.m_E_ChengJiuTypeItemItemsLoopVerticalScrollRect = null;
			this.m_E_Ima_DiButton = null;
			this.m_E_Ima_DiImage = null;
			this.m_E_Ima_SelectStatusImage = null;
			this.m_E_Ima_ItemQulityImage = null;
			this.m_E_Ima_ItemIconImage = null;
			this.m_E_Ima_ProgressImage = null;
			this.m_E_Ima_CompleteTaskImage = null;
			this.m_E_Lab_TaskNumText = null;
			this.m_E_Lab_TaskNameText = null;
			this.m_E_ChengJiuShowItemsImage = null;
			this.m_E_ChengJiuShowItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_ImageButtonButton = null;
		private UnityEngine.UI.Image m_E_ImageButtonImage = null;
		private UnityEngine.UI.Image m_E_CheckmarkImage = null;
		private UnityEngine.UI.Text m_E_TaskTypeNameText = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_ChengJiuTypeItemItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_Ima_DiButton = null;
		private UnityEngine.UI.Image m_E_Ima_DiImage = null;
		private UnityEngine.UI.Image m_E_Ima_SelectStatusImage = null;
		private UnityEngine.UI.Image m_E_Ima_ItemQulityImage = null;
		private UnityEngine.UI.Image m_E_Ima_ItemIconImage = null;
		private UnityEngine.UI.Image m_E_Ima_ProgressImage = null;
		private UnityEngine.UI.Image m_E_Ima_CompleteTaskImage = null;
		private UnityEngine.UI.Text m_E_Lab_TaskNumText = null;
		private UnityEngine.UI.Text m_E_Lab_TaskNameText = null;
		private UnityEngine.UI.Image m_E_ChengJiuShowItemsImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_ChengJiuShowItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
