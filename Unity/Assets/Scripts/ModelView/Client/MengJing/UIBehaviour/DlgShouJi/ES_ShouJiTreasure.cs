
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ShouJiTreasure : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public GameObject[] Button_Open;
		public GameObject[] Button_Close;
		public GameObject TypeListNode;
		public GameObject UIShouJiTreasureType;
		public GameObject ItemListNode;
		public List<EntityRef<UIShouJiTreasureItemComponent>> TreasureItemList = new();
		public List<EntityRef<UIShouJiTreasureTypeComponent>> TreasureTypeList = new();
		public int ChapterId;
		public List<string> AssetList { get; set; } = new();
		
		public UnityEngine.RectTransform EG_TopNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_TopNodeRectTransform == null )
     			{
		    		this.m_EG_TopNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_TopNode");
     			}
     			return this.m_EG_TopNodeRectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_ImageProgressImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageProgressImage == null )
     			{
		    		this.m_E_ImageProgressImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_TopNode/E_ImageProgress");
     			}
     			return this.m_E_ImageProgressImage;
     		}
     	}

		public UnityEngine.UI.Image E_Img_LodingImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_LodingImage == null )
     			{
		    		this.m_E_Img_LodingImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_TopNode/E_ImageProgress/E_Img_Loding");
     			}
     			return this.m_E_Img_LodingImage;
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
     			if( this.m_E_Text_NameText == null )
     			{
		    		this.m_E_Text_NameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_TopNode/E_Text_Name");
     			}
     			return this.m_E_Text_NameText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_StarNumText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_StarNumText == null )
     			{
		    		this.m_E_Text_StarNumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_TopNode/E_Text_StarNum");
     			}
     			return this.m_E_Text_StarNumText;
     		}
     	}

		public UnityEngine.UI.Button E_Img_Chest_1_CloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_Chest_1_CloseButton == null )
     			{
		    		this.m_E_Img_Chest_1_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_TopNode/E_Img_Chest_1_Close");
     			}
     			return this.m_E_Img_Chest_1_CloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_Img_Chest_1_CloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_Chest_1_CloseImage == null )
     			{
		    		this.m_E_Img_Chest_1_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_TopNode/E_Img_Chest_1_Close");
     			}
     			return this.m_E_Img_Chest_1_CloseImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Img_Chest_1_CloseEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_Chest_1_CloseEventTrigger == null )
     			{
		    		this.m_E_Img_Chest_1_CloseEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Right/EG_TopNode/E_Img_Chest_1_Close");
     			}
     			return this.m_E_Img_Chest_1_CloseEventTrigger;
     		}
     	}

		public UnityEngine.UI.Button E_Img_Chest_2_CloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_Chest_2_CloseButton == null )
     			{
		    		this.m_E_Img_Chest_2_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_TopNode/E_Img_Chest_2_Close");
     			}
     			return this.m_E_Img_Chest_2_CloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_Img_Chest_2_CloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_Chest_2_CloseImage == null )
     			{
		    		this.m_E_Img_Chest_2_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_TopNode/E_Img_Chest_2_Close");
     			}
     			return this.m_E_Img_Chest_2_CloseImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Img_Chest_2_CloseEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_Chest_2_CloseEventTrigger == null )
     			{
		    		this.m_E_Img_Chest_2_CloseEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Right/EG_TopNode/E_Img_Chest_2_Close");
     			}
     			return this.m_E_Img_Chest_2_CloseEventTrigger;
     		}
     	}

		public UnityEngine.UI.Button E_Img_Chest_3_CloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_Chest_3_CloseButton == null )
     			{
		    		this.m_E_Img_Chest_3_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_TopNode/E_Img_Chest_3_Close");
     			}
     			return this.m_E_Img_Chest_3_CloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_Img_Chest_3_CloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_Chest_3_CloseImage == null )
     			{
		    		this.m_E_Img_Chest_3_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_TopNode/E_Img_Chest_3_Close");
     			}
     			return this.m_E_Img_Chest_3_CloseImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Img_Chest_3_CloseEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_Chest_3_CloseEventTrigger == null )
     			{
		    		this.m_E_Img_Chest_3_CloseEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Right/EG_TopNode/E_Img_Chest_3_Close");
     			}
     			return this.m_E_Img_Chest_3_CloseEventTrigger;
     		}
     	}

		public UnityEngine.UI.Image E_Img_Chest_1_OpenImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_Chest_1_OpenImage == null )
     			{
		    		this.m_E_Img_Chest_1_OpenImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_TopNode/E_Img_Chest_1_Open");
     			}
     			return this.m_E_Img_Chest_1_OpenImage;
     		}
     	}

		public UnityEngine.UI.Image E_Img_Chest_2_OpenImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_Chest_2_OpenImage == null )
     			{
		    		this.m_E_Img_Chest_2_OpenImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_TopNode/E_Img_Chest_2_Open");
     			}
     			return this.m_E_Img_Chest_2_OpenImage;
     		}
     	}

		public UnityEngine.UI.Image E_Img_Chest_3_OpenImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_Chest_3_OpenImage == null )
     			{
		    		this.m_E_Img_Chest_3_OpenImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_TopNode/E_Img_Chest_3_Open");
     			}
     			return this.m_E_Img_Chest_3_OpenImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_Star1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Star1Text == null )
     			{
		    		this.m_E_Text_Star1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_TopNode/E_Text_Star1");
     			}
     			return this.m_E_Text_Star1Text;
     		}
     	}

		public UnityEngine.UI.Text E_Text_Star2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Star2Text == null )
     			{
		    		this.m_E_Text_Star2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_TopNode/E_Text_Star2");
     			}
     			return this.m_E_Text_Star2Text;
     		}
     	}

		public UnityEngine.UI.Text E_Text_Star3Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Star3Text == null )
     			{
		    		this.m_E_Text_Star3Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_TopNode/E_Text_Star3");
     			}
     			return this.m_E_Text_Star3Text;
     		}
     	}

		public UnityEngine.UI.Text E_Text_Attribute1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Attribute1Text == null )
     			{
		    		this.m_E_Text_Attribute1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_TopNode/E_Text_Attribute1");
     			}
     			return this.m_E_Text_Attribute1Text;
     		}
     	}

		public UnityEngine.UI.Text E_Text_Attribute2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Attribute2Text == null )
     			{
		    		this.m_E_Text_Attribute2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_TopNode/E_Text_Attribute2");
     			}
     			return this.m_E_Text_Attribute2Text;
     		}
     	}

		public UnityEngine.UI.Text E_Text_Attribute3Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Attribute3Text == null )
     			{
		    		this.m_E_Text_Attribute3Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_TopNode/E_Text_Attribute3");
     			}
     			return this.m_E_Text_Attribute3Text;
     		}
     	}

		public ES_ShouJiList ES_ShouJiList
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_ShouJiList es = this.m_es_shoujilist;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_ShouJiList");
		    	   this.m_es_shoujilist = this.AddChild<ES_ShouJiList,Transform>(subTrans);
     			}
     			return this.m_es_shoujilist;
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
			this.m_EG_TopNodeRectTransform = null;
			this.m_E_ImageProgressImage = null;
			this.m_E_Img_LodingImage = null;
			this.m_E_Text_NameText = null;
			this.m_E_Text_StarNumText = null;
			this.m_E_Img_Chest_1_CloseButton = null;
			this.m_E_Img_Chest_1_CloseImage = null;
			this.m_E_Img_Chest_1_CloseEventTrigger = null;
			this.m_E_Img_Chest_2_CloseButton = null;
			this.m_E_Img_Chest_2_CloseImage = null;
			this.m_E_Img_Chest_2_CloseEventTrigger = null;
			this.m_E_Img_Chest_3_CloseButton = null;
			this.m_E_Img_Chest_3_CloseImage = null;
			this.m_E_Img_Chest_3_CloseEventTrigger = null;
			this.m_E_Img_Chest_1_OpenImage = null;
			this.m_E_Img_Chest_2_OpenImage = null;
			this.m_E_Img_Chest_3_OpenImage = null;
			this.m_E_Text_Star1Text = null;
			this.m_E_Text_Star2Text = null;
			this.m_E_Text_Star3Text = null;
			this.m_E_Text_Attribute1Text = null;
			this.m_E_Text_Attribute2Text = null;
			this.m_E_Text_Attribute3Text = null;
			this.m_es_shoujilist = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_TopNodeRectTransform = null;
		private UnityEngine.UI.Image m_E_ImageProgressImage = null;
		private UnityEngine.UI.Image m_E_Img_LodingImage = null;
		private UnityEngine.UI.Text m_E_Text_NameText = null;
		private UnityEngine.UI.Text m_E_Text_StarNumText = null;
		private UnityEngine.UI.Button m_E_Img_Chest_1_CloseButton = null;
		private UnityEngine.UI.Image m_E_Img_Chest_1_CloseImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Img_Chest_1_CloseEventTrigger = null;
		private UnityEngine.UI.Button m_E_Img_Chest_2_CloseButton = null;
		private UnityEngine.UI.Image m_E_Img_Chest_2_CloseImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Img_Chest_2_CloseEventTrigger = null;
		private UnityEngine.UI.Button m_E_Img_Chest_3_CloseButton = null;
		private UnityEngine.UI.Image m_E_Img_Chest_3_CloseImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Img_Chest_3_CloseEventTrigger = null;
		private UnityEngine.UI.Image m_E_Img_Chest_1_OpenImage = null;
		private UnityEngine.UI.Image m_E_Img_Chest_2_OpenImage = null;
		private UnityEngine.UI.Image m_E_Img_Chest_3_OpenImage = null;
		private UnityEngine.UI.Text m_E_Text_Star1Text = null;
		private UnityEngine.UI.Text m_E_Text_Star2Text = null;
		private UnityEngine.UI.Text m_E_Text_Star3Text = null;
		private UnityEngine.UI.Text m_E_Text_Attribute1Text = null;
		private UnityEngine.UI.Text m_E_Text_Attribute2Text = null;
		private UnityEngine.UI.Text m_E_Text_Attribute3Text = null;
		private EntityRef<ES_ShouJiList> m_es_shoujilist = null;
		public Transform uiTransform = null;
	}
}
