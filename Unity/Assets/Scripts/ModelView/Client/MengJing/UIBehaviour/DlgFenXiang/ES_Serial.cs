
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_Serial : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public float LastTime;
		
		public UnityEngine.UI.Button E_ButtonOkButton
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
		    		this.m_E_ButtonOkButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonOk");
     			}
     			return this.m_E_ButtonOkButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonOkImage
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
		    		this.m_E_ButtonOkImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonOk");
     			}
     			return this.m_E_ButtonOkImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonGetButton
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
		    		this.m_E_ButtonGetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonGet");
     			}
     			return this.m_E_ButtonGetButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonGetImage
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
		    		this.m_E_ButtonGetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonGet");
     			}
     			return this.m_E_ButtonGetImage;
     		}
     	}

		public UnityEngine.UI.InputField E_InputField_CodeInputField
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
		    		this.m_E_InputField_CodeInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"E_InputField_Code");
     			}
     			return this.m_E_InputField_CodeInputField;
     		}
     	}

		public UnityEngine.UI.Image E_InputField_CodeImage
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
		    		this.m_E_InputField_CodeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_InputField_Code");
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
     			if( this.m_es_rewardlist == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
     		}
     	}

		public UnityEngine.UI.Image E_QRImgImage
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
		    		this.m_E_QRImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_QRImg");
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

		private UnityEngine.UI.Button m_E_ButtonOkButton = null;
		private UnityEngine.UI.Image m_E_ButtonOkImage = null;
		private UnityEngine.UI.Button m_E_ButtonGetButton = null;
		private UnityEngine.UI.Image m_E_ButtonGetImage = null;
		private UnityEngine.UI.InputField m_E_InputField_CodeInputField = null;
		private UnityEngine.UI.Image m_E_InputField_CodeImage = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private UnityEngine.UI.Image m_E_QRImgImage = null;
		public Transform uiTransform = null;
	}
}
