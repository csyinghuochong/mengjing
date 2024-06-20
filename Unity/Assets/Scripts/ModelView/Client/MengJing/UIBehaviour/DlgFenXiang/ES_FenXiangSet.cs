
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_FenXiangSet : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public string PopularizeCode;
		public int ShareType;
		
		public UnityEngine.RectTransform EG_FenXiang_QQRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_FenXiang_QQRectTransform == null )
     			{
		    		this.m_EG_FenXiang_QQRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_FenXiang_QQ");
     			}
     			return this.m_EG_FenXiang_QQRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_FenXiang_WeiXinRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_FenXiang_WeiXinRectTransform == null )
     			{
		    		this.m_EG_FenXiang_WeiXinRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_FenXiang_WeiXin");
     			}
     			return this.m_EG_FenXiang_WeiXinRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_Button_AddQQButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_AddQQButton == null )
     			{
		    		this.m_E_Button_AddQQButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_FenXiang_WeiXin/E_Button_AddQQ");
     			}
     			return this.m_E_Button_AddQQButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_AddQQImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_AddQQImage == null )
     			{
		    		this.m_E_Button_AddQQImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_FenXiang_WeiXin/E_Button_AddQQ");
     			}
     			return this.m_E_Button_AddQQImage;
     		}
     	}

		public UnityEngine.RectTransform EG_FenXiang_TikTokRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_FenXiang_TikTokRectTransform == null )
     			{
		    		this.m_EG_FenXiang_TikTokRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_FenXiang_TikTok");
     			}
     			return this.m_EG_FenXiang_TikTokRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_Button_supportButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_supportButton == null )
     			{
		    		this.m_E_Button_supportButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Button_support");
     			}
     			return this.m_E_Button_supportButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_supportImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_supportImage == null )
     			{
		    		this.m_E_Button_supportImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Button_support");
     			}
     			return this.m_E_Button_supportImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_tip1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_tip1Text == null )
     			{
		    		this.m_E_Text_tip1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_tip1");
     			}
     			return this.m_E_Text_tip1Text;
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
			this.m_EG_FenXiang_QQRectTransform = null;
			this.m_EG_FenXiang_WeiXinRectTransform = null;
			this.m_E_Button_AddQQButton = null;
			this.m_E_Button_AddQQImage = null;
			this.m_EG_FenXiang_TikTokRectTransform = null;
			this.m_E_Button_supportButton = null;
			this.m_E_Button_supportImage = null;
			this.m_E_Text_tip1Text = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_FenXiang_QQRectTransform = null;
		private UnityEngine.RectTransform m_EG_FenXiang_WeiXinRectTransform = null;
		private UnityEngine.UI.Button m_E_Button_AddQQButton = null;
		private UnityEngine.UI.Image m_E_Button_AddQQImage = null;
		private UnityEngine.RectTransform m_EG_FenXiang_TikTokRectTransform = null;
		private UnityEngine.UI.Button m_E_Button_supportButton = null;
		private UnityEngine.UI.Image m_E_Button_supportImage = null;
		private UnityEngine.UI.Text m_E_Text_tip1Text = null;
		public Transform uiTransform = null;
	}
}
