using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ChildOf]
    [EnableMethod]
    public class ES_PetHeChengInfoShow : Entity,IAwake<Transform>,IDestroy,IUILogic
    {
        public GameObject[] PetZiZhiItemList = new GameObject[6];
		public int Weizhi; //-1左 1 右边
		public PetOperationType BagOperationType;
		public RolePetInfo RolePetInfo;
		public Dictionary<int, EntityRef<Scroll_Item_CommonSkillItem>> ScrollItemCommonSkillItems;
		public List<int> ShowPetSkills = new();
		
		public RectTransform EG_PetZiZhiItem1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiItem1RectTransform == null )
     			{
		    		this.m_EG_PetZiZhiItem1RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Left/EG_PetZiZhiItem1");
     			}
     			return this.m_EG_PetZiZhiItem1RectTransform;
     		}
     	}

		public RectTransform EG_PetZiZhiItem2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiItem2RectTransform == null )
     			{
		    		this.m_EG_PetZiZhiItem2RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Left/EG_PetZiZhiItem2");
     			}
     			return this.m_EG_PetZiZhiItem2RectTransform;
     		}
     	}

		public RectTransform EG_PetZiZhiItem3RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiItem3RectTransform == null )
     			{
		    		this.m_EG_PetZiZhiItem3RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Left/EG_PetZiZhiItem3");
     			}
     			return this.m_EG_PetZiZhiItem3RectTransform;
     		}
     	}

		public RectTransform EG_PetZiZhiItem4RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiItem4RectTransform == null )
     			{
		    		this.m_EG_PetZiZhiItem4RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Left/EG_PetZiZhiItem4");
     			}
     			return this.m_EG_PetZiZhiItem4RectTransform;
     		}
     	}

		public RectTransform EG_PetZiZhiItem5RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiItem5RectTransform == null )
     			{
		    		this.m_EG_PetZiZhiItem5RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Left/EG_PetZiZhiItem5");
     			}
     			return this.m_EG_PetZiZhiItem5RectTransform;
     		}
     	}

		public RectTransform EG_PetZiZhiItem6RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiItem6RectTransform == null )
     			{
		    		this.m_EG_PetZiZhiItem6RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Left/EG_PetZiZhiItem6");
     			}
     			return this.m_EG_PetZiZhiItem6RectTransform;
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
			        Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_ModelShow");
			        this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
		        }
		        return this.m_es_modelshow;
	        }
        }
		
		public LoopVerticalScrollRect E_CommonSkillItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CommonSkillItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_CommonSkillItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_CommonSkillItems");
     			}
     			return this.m_E_CommonSkillItemsLoopVerticalScrollRect;
     		}
     	}

        public Image E_TipImage
        {
	        get
	        {
		        if (this.uiTransform == null)
		        {
			        Log.Error("uiTransform is null.");
			        return null;
		        }
		        if( this.m_E_TipImage == null )
		        {
			        this.m_E_TipImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_Tip");
		        }
		        return this.m_E_TipImage;
	        }
        }
        
        public Button E_TipButton
        {
	        get
	        {
		        if (this.uiTransform == null)
		        {
			        Log.Error("uiTransform is null.");
			        return null;
		        }
		        if( this.m_E_TipButton == null )
		        {
			        this.m_E_TipButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Left/E_Tip");
		        }
		        return this.m_E_TipButton;
	        }
        }
		
		public Button E_AddButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AddButton == null )
     			{
		    		this.m_E_AddButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Left/E_Add");
     			}
     			return this.m_E_AddButton;
     		}
     	}

        public Image E_AddImage
        {
	        get
	        {
		        if (this.uiTransform == null)
		        {
			        Log.Error("uiTransform is null.");
			        return null;
		        }
		        if( this.m_E_AddImage == null )
		        {
			        this.m_E_AddImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_Add");
		        }
		        return this.m_E_AddImage;
	        }
        }
		
        public Image E_ImageExpDiImage
        {
	        get
	        {
		        if (this.uiTransform == null)
		        {
			        Log.Error("uiTransform is null.");
			        return null;
		        }
		        if( this.m_E_ImageExpDiImage == null )
		        {
			        this.m_E_ImageExpDiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_ImageExpDi");
		        }
		        return this.m_E_ImageExpDiImage;
	        }
        }
        
		public Image E_ImageExpValueImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageExpValueImage == null )
     			{
		    		this.m_E_ImageExpValueImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_ImageExpDi/E_ImageExpValue");
     			}
     			return this.m_E_ImageExpValueImage;
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
		    		this.m_E_Text_PetNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Left/E_Text_PetName");
     			}
     			return this.m_E_Text_PetNameText;
     		}
     	}

		public Text E_Text_PetLevelText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_PetLevelText == null )
     			{
		    		this.m_E_Text_PetLevelText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Left/E_Text_PetLevel");
     			}
     			return this.m_E_Text_PetLevelText;
     		}
     	}

		public Text E_Text_PetExpText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_PetExpText == null )
     			{
		    		this.m_E_Text_PetExpText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Left/E_Text_PetExp");
     			}
     			return this.m_E_Text_PetExpText;
     		}
     	}
		
		public Text E_Text_PetPingFen
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_Text_PetPingFen == null )
				{
					this.m_E_Text_PetPingFen = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Left/E_Text_PetPingFen");
				}
				return this.m_E_Text_PetPingFen;
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
			this.m_EG_PetZiZhiItem1RectTransform = null;
			this.m_EG_PetZiZhiItem2RectTransform = null;
			this.m_EG_PetZiZhiItem3RectTransform = null;
			this.m_EG_PetZiZhiItem4RectTransform = null;
			this.m_EG_PetZiZhiItem5RectTransform = null;
			this.m_EG_PetZiZhiItem6RectTransform = null;
			this.m_es_modelshow = null;
			this.m_E_CommonSkillItemsLoopVerticalScrollRect = null;
			this.m_E_TipImage = null;
			this.m_E_TipButton = null;
			this.m_E_AddButton = null;
			this.m_E_AddImage = null;
			this.m_E_ImageExpDiImage = null;
			this.m_E_ImageExpValueImage = null;
			this.m_E_Text_PetNameText = null;
			this.m_E_Text_PetLevelText = null;
			this.m_E_Text_PetExpText = null;
			this.m_E_Text_PetPingFen = null;
			this.uiTransform = null;
		}
		
		private RectTransform m_EG_PetZiZhiItem1RectTransform = null;
		private RectTransform m_EG_PetZiZhiItem2RectTransform = null;
		private RectTransform m_EG_PetZiZhiItem3RectTransform = null;
		private RectTransform m_EG_PetZiZhiItem4RectTransform = null;
		private RectTransform m_EG_PetZiZhiItem5RectTransform = null;
		private RectTransform m_EG_PetZiZhiItem6RectTransform = null;
		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private LoopVerticalScrollRect m_E_CommonSkillItemsLoopVerticalScrollRect = null;
		private Image m_E_TipImage = null;
		private Button m_E_TipButton = null;
		private Button m_E_AddButton = null;
		private Image m_E_AddImage = null;
		private Image m_E_ImageExpDiImage = null;
		private Image m_E_ImageExpValueImage = null;
		private Text m_E_Text_PetNameText = null;
		private Text m_E_Text_PetLevelText = null;
		private Text m_E_Text_PetExpText = null;
		private Text m_E_Text_PetPingFen = null;
		public Transform uiTransform = null;
	}
}