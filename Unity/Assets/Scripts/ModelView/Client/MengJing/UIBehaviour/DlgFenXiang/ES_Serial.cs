using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_Serial : Entity,IAwake<Transform>,IDestroy 
	{
		public float LastTime;
		
		public Button E_ButtonOkButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonOkButton == null )
     			{
		    		this.m_E_ButtonOkButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonOk");
     			}
     			return this.m_E_ButtonOkButton;
     		}
     	}

		public Image E_ButtonOkImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonOkImage == null )
     			{
		    		this.m_E_ButtonOkImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonOk");
     			}
     			return this.m_E_ButtonOkImage;
     		}
     	}

		public Button E_ButtonGetButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonGetButton == null )
     			{
		    		this.m_E_ButtonGetButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonGet");
     			}
     			return this.m_E_ButtonGetButton;
     		}
     	}

		public Image E_ButtonGetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonGetImage == null )
     			{
		    		this.m_E_ButtonGetImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonGet");
     			}
     			return this.m_E_ButtonGetImage;
     		}
     	}

		public InputField E_InputField_CodeInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputField_CodeInputField == null )
     			{
		    		this.m_E_InputField_CodeInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"E_InputField_Code");
     			}
     			return this.m_E_InputField_CodeInputField;
     		}
     	}

		public Image E_InputField_CodeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputField_CodeImage == null )
     			{
		    		this.m_E_InputField_CodeImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_InputField_Code");
     			}
     			return this.m_E_InputField_CodeImage;
     		}
     	}

		public ES_RewardList ES_RewardList
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_RewardList es = this.m_es_rewardlist;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
     		}
     	}

		public Image E_QRImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_QRImgImage == null )
     			{
		    		this.m_E_QRImgImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_QRImg");
     			}
     			return this.m_E_QRImgImage;
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
			this.m_E_ButtonOkButton = null;
			this.m_E_ButtonOkImage = null;
			this.m_E_ButtonGetButton = null;
			this.m_E_ButtonGetImage = null;
			this.m_E_InputField_CodeInputField = null;
			this.m_E_InputField_CodeImage = null;
			this.m_es_rewardlist = null;
			this.m_E_QRImgImage = null;
			this.uiTransform = null;
		}

		private Button m_E_ButtonOkButton = null;
		private Image m_E_ButtonOkImage = null;
		private Button m_E_ButtonGetButton = null;
		private Image m_E_ButtonGetImage = null;
		private InputField m_E_InputField_CodeInputField = null;
		private Image m_E_InputField_CodeImage = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private Image m_E_QRImgImage = null;
		public Transform uiTransform = null;
	}
}
