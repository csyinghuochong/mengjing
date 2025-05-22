using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_DonationUnion : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public List<UnionListItem> UnionListItems = new();
		
		public UnityEngine.UI.Text E_Text_Open_TimeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Open_TimeText == null )
     			{
		    		this.m_E_Text_Open_TimeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_Text_Open_Time");
     			}
     			return this.m_E_Text_Open_TimeText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_BonusText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_BonusText == null )
     			{
		    		this.m_E_Text_BonusText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_Text_Bonus");
     			}
     			return this.m_E_Text_BonusText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_Tip_1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Tip_1Text == null )
     			{
		    		this.m_E_Text_Tip_1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_Text_Tip_1");
     			}
     			return this.m_E_Text_Tip_1Text;
     		}
     	}

		public UnityEngine.UI.Text E_Text_Tip_5Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Tip_5Text == null )
     			{
		    		this.m_E_Text_Tip_5Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_Text_Tip_5");
     			}
     			return this.m_E_Text_Tip_5Text;
     		}
     	}

		public UnityEngine.UI.Button E_Button_SignupButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_SignupButton == null )
     			{
		    		this.m_E_Button_SignupButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Button_Signup");
     			}
     			return this.m_E_Button_SignupButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_SignupImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_SignupImage == null )
     			{
		    		this.m_E_Button_SignupImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Button_Signup");
     			}
     			return this.m_E_Button_SignupImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_RaceButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_RaceButton == null )
     			{
		    		this.m_E_Button_RaceButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Button_Race");
     			}
     			return this.m_E_Button_RaceButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_RaceImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_RaceImage == null )
     			{
		    		this.m_E_Button_RaceImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Button_Race");
     			}
     			return this.m_E_Button_RaceImage;
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
			this.m_E_Text_Open_TimeText = null;
			this.m_E_Text_BonusText = null;
			this.m_E_Text_Tip_1Text = null;
			this.m_E_Text_Tip_5Text = null;
			this.m_E_Button_SignupButton = null;
			this.m_E_Button_SignupImage = null;
			this.m_E_Button_RaceButton = null;
			this.m_E_Button_RaceImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Text m_E_Text_Open_TimeText = null;
		private UnityEngine.UI.Text m_E_Text_BonusText = null;
		private UnityEngine.UI.Text m_E_Text_Tip_1Text = null;
		private UnityEngine.UI.Text m_E_Text_Tip_5Text = null;
		private UnityEngine.UI.Button m_E_Button_SignupButton = null;
		private UnityEngine.UI.Image m_E_Button_SignupImage = null;
		private UnityEngine.UI.Button m_E_Button_RaceButton = null;
		private UnityEngine.UI.Image m_E_Button_RaceImage = null;
		public Transform uiTransform = null;
	}
}
