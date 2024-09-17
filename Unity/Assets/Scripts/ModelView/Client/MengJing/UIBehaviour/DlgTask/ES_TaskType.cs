using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_TaskType : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public float Height;
		public Dictionary<int, EntityRef<Scroll_Item_TaskTypeItem>> ScrollItemTaskTypeItems;
		public List<TaskPro> ShowTaskPros = new();
		public bool IsExpand { get; set; }
		public int TaskType;
		
		public Image E_HighlightImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HighlightImage == null )
     			{
		    		this.m_E_HighlightImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Highlight");
     			}
     			return this.m_E_HighlightImage;
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
		    		this.m_E_TaskTypeNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TaskTypeName");
     			}
     			return this.m_E_TaskTypeNameText;
     		}
     	}

		public Button E_SelectButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectButton == null )
     			{
		    		this.m_E_SelectButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Select");
     			}
     			return this.m_E_SelectButton;
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
     			if( this.m_E_SelectImage == null )
     			{
		    		this.m_E_SelectImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Select");
     			}
     			return this.m_E_SelectImage;
     		}
     	}

		public LoopVerticalScrollRect E_TaskTypeItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TaskTypeItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_TaskTypeItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_TaskTypeItems");
     			}
     			return this.m_E_TaskTypeItemsLoopVerticalScrollRect;
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
			this.m_E_HighlightImage = null;
			this.m_E_TaskTypeNameText = null;
			this.m_E_SelectButton = null;
			this.m_E_SelectImage = null;
			this.m_E_TaskTypeItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private Image m_E_HighlightImage = null;
		private Text m_E_TaskTypeNameText = null;
		private Button m_E_SelectButton = null;
		private Image m_E_SelectImage = null;
		private LoopVerticalScrollRect m_E_TaskTypeItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
