using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_UnionBloodStone : Entity,IAwake<Transform>,IDestroy 
	{
		public Image E_IconLImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_IconLImgImage == null )
     			{
		    		this.m_E_IconLImgImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_IconLImg");
     			}
     			return this.m_E_IconLImgImage;
     		}
     	}

		public Text E_NameLTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NameLTextText == null )
     			{
		    		this.m_E_NameLTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_NameLText");
     			}
     			return this.m_E_NameLTextText;
     		}
     	}

		public Image E_IconRImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_IconRImgImage == null )
     			{
		    		this.m_E_IconRImgImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_IconRImg");
     			}
     			return this.m_E_IconRImgImage;
     		}
     	}

		public Text E_NameRTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NameRTextText == null )
     			{
		    		this.m_E_NameRTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_NameRText");
     			}
     			return this.m_E_NameRTextText;
     		}
     	}

		public Text E_PropertyTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PropertyTextText == null )
     			{
		    		this.m_E_PropertyTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_PropertyText");
     			}
     			return this.m_E_PropertyTextText;
     		}
     	}

		public ES_CostList ES_CostList
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_CostList es = this.m_es_costlist;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CostList");
		    	   this.m_es_costlist = this.AddChild<ES_CostList,Transform>(subTrans);
     			}
     			return this.m_es_costlist;
     		}
     	}

		public Button E_UpBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UpBtnButton == null )
     			{
		    		this.m_E_UpBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_UpBtn");
     			}
     			return this.m_E_UpBtnButton;
     		}
     	}

		public Image E_UpBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UpBtnImage == null )
     			{
		    		this.m_E_UpBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_UpBtn");
     			}
     			return this.m_E_UpBtnImage;
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
			this.m_E_IconLImgImage = null;
			this.m_E_NameLTextText = null;
			this.m_E_IconRImgImage = null;
			this.m_E_NameRTextText = null;
			this.m_E_PropertyTextText = null;
			this.m_es_costlist = null;
			this.m_E_UpBtnButton = null;
			this.m_E_UpBtnImage = null;
			this.uiTransform = null;
		}

		private Image m_E_IconLImgImage = null;
		private Text m_E_NameLTextText = null;
		private Image m_E_IconRImgImage = null;
		private Text m_E_NameRTextText = null;
		private Text m_E_PropertyTextText = null;
		private EntityRef<ES_CostList> m_es_costlist = null;
		private Button m_E_UpBtnButton = null;
		private Image m_E_UpBtnImage = null;
		public Transform uiTransform = null;
	}
}
