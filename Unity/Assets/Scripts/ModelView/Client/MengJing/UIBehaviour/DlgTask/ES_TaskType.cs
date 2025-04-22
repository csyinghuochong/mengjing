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
		public Dictionary<int, EntityRef<Scroll_Item_TaskTypeItem>> ScrollItemTaskTypeItems = new();
		public List<TaskPro> ShowTaskPros = new();
		public bool IsExpand { get; set; }
		public int TaskType;
		public List<string> AssetList { get; set; } = new();
		
		public Image E_Bg1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Bg1Image == null )
     			{
		    		this.m_E_Bg1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Bg1");
     			}
     			return this.m_E_Bg1Image;
     		}
     	}
		
		public Image E_Bg2Image
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_Bg2Image == null )
				{
					this.m_E_Bg2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Bg2");
				}
				return this.m_E_Bg2Image;
			}
		}

		public Text E_TaskTypeName1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TaskTypeName1Text == null )
     			{
		    		this.m_E_TaskTypeName1Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TaskTypeName1");
     			}
     			return this.m_E_TaskTypeName1Text;
     		}
     	}
		
		public Text E_TaskTypeName2Text
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_TaskTypeName2Text == null )
				{
					this.m_E_TaskTypeName2Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TaskTypeName2");
				}
				return this.m_E_TaskTypeName2Text;
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

		public RectTransform EG_TaskTypeItemsRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TaskTypeItemsRectTransform == null )
     			{
		    		this.m_E_TaskTypeItemsRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_TaskTypeItems");
     			}
     			return this.m_E_TaskTypeItemsRectTransform;
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
			this.m_E_Bg1Image = null;
			this.m_E_Bg2Image = null;
			this.m_E_TaskTypeName1Text = null;
			this.m_E_TaskTypeName2Text = null;
			this.m_E_SelectButton = null;
			this.m_E_SelectImage = null;
			this.m_E_TaskTypeItemsRectTransform = null;
			this.uiTransform = null;
		}

		private Image m_E_Bg1Image = null;
		private Image m_E_Bg2Image = null;
		private Text m_E_TaskTypeName1Text = null;
		private Text m_E_TaskTypeName2Text = null;
		private Button m_E_SelectButton = null;
		private Image m_E_SelectImage = null;
		private RectTransform m_E_TaskTypeItemsRectTransform = null;
		public Transform uiTransform = null;
	}
}
