using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgJiaYuanPetFeed))]
	[EnableMethod]
	public  class DlgJiaYuanPetFeedViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_Btn_CloseDiButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CloseDiButton == null )
     			{
		    		this.m_E_Btn_CloseDiButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_CloseDi");
     			}
     			return this.m_E_Btn_CloseDiButton;
     		}
     	}

		public Image E_Btn_CloseDiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CloseDiImage == null )
     			{
		    		this.m_E_Btn_CloseDiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_CloseDi");
     			}
     			return this.m_E_Btn_CloseDiImage;
     		}
     	}

		public Button E_ImageCloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageCloseButton == null )
     			{
		    		this.m_E_ImageCloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ImageClose");
     			}
     			return this.m_E_ImageCloseButton;
     		}
     	}

		public Image E_ImageCloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageCloseImage == null )
     			{
		    		this.m_E_ImageCloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageClose");
     			}
     			return this.m_E_ImageCloseImage;
     		}
     	}

		public ES_ModelShow ES_ModelShow
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_ModelShow es = this.m_es_modelshow;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_ModelShow");
		    	   this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow;
     		}
     	}

		public Text E_Text_PetNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_PetNameText == null )
     			{
		    		this.m_E_Text_PetNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_PetName");
     			}
     			return this.m_E_Text_PetNameText;
     		}
     	}

		public LoopVerticalScrollRect E_BagItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_BagItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_BagItems");
     			}
     			return this.m_E_BagItemsLoopVerticalScrollRect;
     		}
     	}

		public ES_CommonItem ES_CommonItem_0
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_CommonItem es = this.m_es_commonitem_0;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem_0");
		    	   this.m_es_commonitem_0 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem_0;
     		}
     	}

		public ES_CommonItem ES_CommonItem_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_CommonItem es = this.m_es_commonitem_1;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem_1");
		    	   this.m_es_commonitem_1 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem_1;
     		}
     	}

		public ES_CommonItem ES_CommonItem_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_CommonItem es = this.m_es_commonitem_2;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem_2");
		    	   this.m_es_commonitem_2 = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem_2;
     		}
     	}

		public Button E_ButtonEatButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonEatButton == null )
     			{
		    		this.m_E_ButtonEatButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonEat");
     			}
     			return this.m_E_ButtonEatButton;
     		}
     	}

		public Image E_ButtonEatImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonEatImage == null )
     			{
		    		this.m_E_ButtonEatImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonEat");
     			}
     			return this.m_E_ButtonEatImage;
     		}
     	}

		public Image E_Image_Mood_0Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Image_Mood_0Image == null )
     			{
		    		this.m_E_Image_Mood_0Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Image_Mood_0");
     			}
     			return this.m_E_Image_Mood_0Image;
     		}
     	}

		public Image E_Image_Mood_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Image_Mood_1Image == null )
     			{
		    		this.m_E_Image_Mood_1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Image_Mood_1");
     			}
     			return this.m_E_Image_Mood_1Image;
     		}
     	}

		public Image E_Image_Mood_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Image_Mood_2Image == null )
     			{
		    		this.m_E_Image_Mood_2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Image_Mood_2");
     			}
     			return this.m_E_Image_Mood_2Image;
     		}
     	}

		public Image E_Image_Mood_3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Image_Mood_3Image == null )
     			{
		    		this.m_E_Image_Mood_3Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Image_Mood_3");
     			}
     			return this.m_E_Image_Mood_3Image;
     		}
     	}

		public Image E_Image_Mood_4Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Image_Mood_4Image == null )
     			{
		    		this.m_E_Image_Mood_4Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Image_Mood_4");
     			}
     			return this.m_E_Image_Mood_4Image;
     		}
     	}

		public Text E_Text_HourExpText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_HourExpText == null )
     			{
		    		this.m_E_Text_HourExpText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_HourExp");
     			}
     			return this.m_E_Text_HourExpText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Btn_CloseDiButton = null;
			this.m_E_Btn_CloseDiImage = null;
			this.m_E_ImageCloseButton = null;
			this.m_E_ImageCloseImage = null;
			this.m_es_modelshow = null;
			this.m_E_Text_PetNameText = null;
			this.m_E_BagItemsLoopVerticalScrollRect = null;
			this.m_es_commonitem_0 = null;
			this.m_es_commonitem_1 = null;
			this.m_es_commonitem_2 = null;
			this.m_E_ButtonEatButton = null;
			this.m_E_ButtonEatImage = null;
			this.m_E_Image_Mood_0Image = null;
			this.m_E_Image_Mood_1Image = null;
			this.m_E_Image_Mood_2Image = null;
			this.m_E_Image_Mood_3Image = null;
			this.m_E_Image_Mood_4Image = null;
			this.m_E_Text_HourExpText = null;
			this.uiTransform = null;
		}

		private Button m_E_Btn_CloseDiButton = null;
		private Image m_E_Btn_CloseDiImage = null;
		private Button m_E_ImageCloseButton = null;
		private Image m_E_ImageCloseImage = null;
		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private Text m_E_Text_PetNameText = null;
		private LoopVerticalScrollRect m_E_BagItemsLoopVerticalScrollRect = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_0 = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_1 = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_2 = null;
		private Button m_E_ButtonEatButton = null;
		private Image m_E_ButtonEatImage = null;
		private Image m_E_Image_Mood_0Image = null;
		private Image m_E_Image_Mood_1Image = null;
		private Image m_E_Image_Mood_2Image = null;
		private Image m_E_Image_Mood_3Image = null;
		private Image m_E_Image_Mood_4Image = null;
		private Text m_E_Text_HourExpText = null;
		public Transform uiTransform = null;
	}
}
