using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ChengJiuShow : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public List<int> ShowTask = new();
		public Dictionary<int, EntityRef<Scroll_Item_ChengJiuShowItem>> ScrollItemChengJiuShowItems;
		public List<EntityRef<UIChengJiuShowType>> UIChengJiuShowTypes = new();
		public GameObject LeftContent;
		public GameObject UIChengJiuShowType;
		public GameObject UIChengJiuShowChapterItemListNode;
		public Button E_ImageButtonButton
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
		    		this.m_E_ImageButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/LeftContent/UIChengJiuShowType/E_ImageButton");
     			}
     			return this.m_E_ImageButtonButton;
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
     			if( this.m_E_ImageButtonImage == null )
     			{
		    		this.m_E_ImageButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/LeftContent/UIChengJiuShowType/E_ImageButton");
     			}
     			return this.m_E_ImageButtonImage;
     		}
     	}

		public Image E_CheckmarkImage
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
		    		this.m_E_CheckmarkImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/LeftContent/UIChengJiuShowType/E_Checkmark");
     			}
     			return this.m_E_CheckmarkImage;
     		}
     	}

		public Text E_TaskTypeNameText
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
		    		this.m_E_TaskTypeNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/LeftContent/UIChengJiuShowType/E_TaskTypeName");
     			}
     			return this.m_E_TaskTypeNameText;
     		}
     	}

		public LoopVerticalScrollRect E_ChengJiuTypeItemItemsLoopVerticalScrollRect
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
		    		this.m_E_ChengJiuTypeItemItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/LeftContent/UIChengJiuShowType/E_ChengJiuTypeItemItems");
     			}
     			return this.m_E_ChengJiuTypeItemItemsLoopVerticalScrollRect;
     		}
     	}

		public Button E_Ima_DiButton
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
		    		this.m_E_Ima_DiButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/LeftContent/UIChengJiuShowChapterItemListNode/UIChengJiuShowChapterItem/E_Ima_Di");
     			}
     			return this.m_E_Ima_DiButton;
     		}
     	}

		public Image E_Ima_DiImage
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
		    		this.m_E_Ima_DiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/LeftContent/UIChengJiuShowChapterItemListNode/UIChengJiuShowChapterItem/E_Ima_Di");
     			}
     			return this.m_E_Ima_DiImage;
     		}
     	}

		public Image E_Ima_SelectStatusImage
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
		    		this.m_E_Ima_SelectStatusImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/LeftContent/UIChengJiuShowChapterItemListNode/UIChengJiuShowChapterItem/E_Ima_SelectStatus");
     			}
     			return this.m_E_Ima_SelectStatusImage;
     		}
     	}

		public Image E_Ima_ItemQulityImage
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
		    		this.m_E_Ima_ItemQulityImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/LeftContent/UIChengJiuShowChapterItemListNode/UIChengJiuShowChapterItem/E_Ima_ItemQulity");
     			}
     			return this.m_E_Ima_ItemQulityImage;
     		}
     	}

		public Image E_Ima_ItemIconImage
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
		    		this.m_E_Ima_ItemIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/LeftContent/UIChengJiuShowChapterItemListNode/UIChengJiuShowChapterItem/E_Ima_ItemIcon");
     			}
     			return this.m_E_Ima_ItemIconImage;
     		}
     	}

		public Image E_Ima_ProgressImage
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
		    		this.m_E_Ima_ProgressImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/LeftContent/UIChengJiuShowChapterItemListNode/UIChengJiuShowChapterItem/E_Ima_Progress");
     			}
     			return this.m_E_Ima_ProgressImage;
     		}
     	}

		public Image E_Ima_CompleteTaskImage
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
		    		this.m_E_Ima_CompleteTaskImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/LeftContent/UIChengJiuShowChapterItemListNode/UIChengJiuShowChapterItem/E_Ima_CompleteTask");
     			}
     			return this.m_E_Ima_CompleteTaskImage;
     		}
     	}

		public Text E_Lab_TaskNumText
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
		    		this.m_E_Lab_TaskNumText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/LeftContent/UIChengJiuShowChapterItemListNode/UIChengJiuShowChapterItem/E_Lab_TaskNum");
     			}
     			return this.m_E_Lab_TaskNumText;
     		}
     	}

		public Text E_Lab_TaskNameText
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
		    		this.m_E_Lab_TaskNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/LeftContent/UIChengJiuShowChapterItemListNode/UIChengJiuShowChapterItem/E_Lab_TaskName");
     			}
     			return this.m_E_Lab_TaskNameText;
     		}
     	}

		public Image E_ChengJiuShowItemsImage
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
		    		this.m_E_ChengJiuShowItemsImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_ChengJiuShowItems");
     			}
     			return this.m_E_ChengJiuShowItemsImage;
     		}
     	}

		public LoopVerticalScrollRect E_ChengJiuShowItemsLoopVerticalScrollRect
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
		    		this.m_E_ChengJiuShowItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_ChengJiuShowItems");
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

		private Button m_E_ImageButtonButton = null;
		private Image m_E_ImageButtonImage = null;
		private Image m_E_CheckmarkImage = null;
		private Text m_E_TaskTypeNameText = null;
		private LoopVerticalScrollRect m_E_ChengJiuTypeItemItemsLoopVerticalScrollRect = null;
		private Button m_E_Ima_DiButton = null;
		private Image m_E_Ima_DiImage = null;
		private Image m_E_Ima_SelectStatusImage = null;
		private Image m_E_Ima_ItemQulityImage = null;
		private Image m_E_Ima_ItemIconImage = null;
		private Image m_E_Ima_ProgressImage = null;
		private Image m_E_Ima_CompleteTaskImage = null;
		private Text m_E_Lab_TaskNumText = null;
		private Text m_E_Lab_TaskNameText = null;
		private Image m_E_ChengJiuShowItemsImage = null;
		private LoopVerticalScrollRect m_E_ChengJiuShowItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
