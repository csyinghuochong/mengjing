﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_DonationUnion : Entity,IAwake<Transform>,IDestroy
	{
		public List<UnionListItem> UnionListItems = new();
		
		public Text E_Text_Open_TimeText
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
		    		this.m_E_Text_Open_TimeText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Open_Time");
     			}
     			return this.m_E_Text_Open_TimeText;
     		}
     	}

		public Text E_Text_BonusText
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
		    		this.m_E_Text_BonusText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Bonus");
     			}
     			return this.m_E_Text_BonusText;
     		}
     	}

		public Text E_Text_Tip_1Text
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
		    		this.m_E_Text_Tip_1Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Tip_1");
     			}
     			return this.m_E_Text_Tip_1Text;
     		}
     	}

		public Text E_Text_Tip_5Text
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
		    		this.m_E_Text_Tip_5Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Tip_5");
     			}
     			return this.m_E_Text_Tip_5Text;
     		}
     	}

		public Button E_Button_SignupButton
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
		    		this.m_E_Button_SignupButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button_Signup");
     			}
     			return this.m_E_Button_SignupButton;
     		}
     	}

		public Image E_Button_SignupImage
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
		    		this.m_E_Button_SignupImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button_Signup");
     			}
     			return this.m_E_Button_SignupImage;
     		}
     	}

		public Button E_Button_RaceButton
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
		    		this.m_E_Button_RaceButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button_Race");
     			}
     			return this.m_E_Button_RaceButton;
     		}
     	}

		public Image E_Button_RaceImage
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
		    		this.m_E_Button_RaceImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button_Race");
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

		private Text m_E_Text_Open_TimeText = null;
		private Text m_E_Text_BonusText = null;
		private Text m_E_Text_Tip_1Text = null;
		private Text m_E_Text_Tip_5Text = null;
		private Button m_E_Button_SignupButton = null;
		private Image m_E_Button_SignupImage = null;
		private Button m_E_Button_RaceButton = null;
		private Image m_E_Button_RaceImage = null;
		public Transform uiTransform = null;
	}
}
