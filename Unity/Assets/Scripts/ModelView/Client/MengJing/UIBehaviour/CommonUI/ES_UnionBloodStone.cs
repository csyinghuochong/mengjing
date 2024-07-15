
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_UnionBloodStone : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.Image E_IconLImgImage
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
		    		this.m_E_IconLImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_IconLImg");
     			}
     			return this.m_E_IconLImgImage;
     		}
     	}

		public UnityEngine.UI.Text E_NameLTextText
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
		    		this.m_E_NameLTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_NameLText");
     			}
     			return this.m_E_NameLTextText;
     		}
     	}

		public UnityEngine.UI.Image E_IconRImgImage
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
		    		this.m_E_IconRImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_IconRImg");
     			}
     			return this.m_E_IconRImgImage;
     		}
     	}

		public UnityEngine.UI.Text E_NameRTextText
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
		    		this.m_E_NameRTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_NameRText");
     			}
     			return this.m_E_NameRTextText;
     		}
     	}

		public UnityEngine.UI.Text E_PropertyTextText
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
		    		this.m_E_PropertyTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_PropertyText");
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

		public UnityEngine.UI.Button E_UpBtnButton
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
		    		this.m_E_UpBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_UpBtn");
     			}
     			return this.m_E_UpBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_UpBtnImage
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
		    		this.m_E_UpBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_UpBtn");
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

		private UnityEngine.UI.Image m_E_IconLImgImage = null;
		private UnityEngine.UI.Text m_E_NameLTextText = null;
		private UnityEngine.UI.Image m_E_IconRImgImage = null;
		private UnityEngine.UI.Text m_E_NameRTextText = null;
		private UnityEngine.UI.Text m_E_PropertyTextText = null;
		private EntityRef<ES_CostList> m_es_costlist = null;
		private UnityEngine.UI.Button m_E_UpBtnButton = null;
		private UnityEngine.UI.Image m_E_UpBtnImage = null;
		public Transform uiTransform = null;
	}
}
