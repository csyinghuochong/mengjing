using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgTurtle))]
	[EnableMethod]
	public  class DlgTurtleViewComponent : Entity,IAwake,IDestroy 
	{
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Rewards/ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
     		}
     	}

		public ES_ModelShow ES_ModelShow1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_ModelShow es = this.m_es_modelshow1;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Number1/ES_ModelShow1");
		    	   this.m_es_modelshow1 = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow1;
     		}
     	}

		public Text E_WinNumText1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_WinNumText1Text == null )
     			{
		    		this.m_E_WinNumText1Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Number1/E_WinNumText1");
     			}
     			return this.m_E_WinNumText1Text;
     		}
     	}

		public Text E_SupportNumText1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SupportNumText1Text == null )
     			{
		    		this.m_E_SupportNumText1Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Number1/E_SupportNumText1");
     			}
     			return this.m_E_SupportNumText1Text;
     		}
     	}

		public Button E_Btn1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn1Button == null )
     			{
		    		this.m_E_Btn1Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Number1/E_Btn1");
     			}
     			return this.m_E_Btn1Button;
     		}
     	}

		public Image E_Btn1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn1Image == null )
     			{
		    		this.m_E_Btn1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Number1/E_Btn1");
     			}
     			return this.m_E_Btn1Image;
     		}
     	}

		public Text E_BtnText1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BtnText1Text == null )
     			{
		    		this.m_E_BtnText1Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Number1/E_Btn1/E_BtnText1");
     			}
     			return this.m_E_BtnText1Text;
     		}
     	}

		public ES_ModelShow ES_ModelShow2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_ModelShow es = this.m_es_modelshow2;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Number2/ES_ModelShow2");
		    	   this.m_es_modelshow2 = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow2;
     		}
     	}

		public Text E_WinNumText2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_WinNumText2Text == null )
     			{
		    		this.m_E_WinNumText2Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Number2/E_WinNumText2");
     			}
     			return this.m_E_WinNumText2Text;
     		}
     	}

		public Text E_SupportNumText2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SupportNumText2Text == null )
     			{
		    		this.m_E_SupportNumText2Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Number2/E_SupportNumText2");
     			}
     			return this.m_E_SupportNumText2Text;
     		}
     	}

		public Button E_Btn2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn2Button == null )
     			{
		    		this.m_E_Btn2Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Number2/E_Btn2");
     			}
     			return this.m_E_Btn2Button;
     		}
     	}

		public Image E_Btn2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn2Image == null )
     			{
		    		this.m_E_Btn2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Number2/E_Btn2");
     			}
     			return this.m_E_Btn2Image;
     		}
     	}

		public Text E_BtnText2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BtnText2Text == null )
     			{
		    		this.m_E_BtnText2Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Number2/E_Btn2/E_BtnText2");
     			}
     			return this.m_E_BtnText2Text;
     		}
     	}

		public ES_ModelShow ES_ModelShow3
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_ModelShow es = this.m_es_modelshow3;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Number3/ES_ModelShow3");
		    	   this.m_es_modelshow3 = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow3;
     		}
     	}

		public Text E_WinNumText3Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_WinNumText3Text == null )
     			{
		    		this.m_E_WinNumText3Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Number3/E_WinNumText3");
     			}
     			return this.m_E_WinNumText3Text;
     		}
     	}

		public Text E_SupportNumText3Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SupportNumText3Text == null )
     			{
		    		this.m_E_SupportNumText3Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Number3/E_SupportNumText3");
     			}
     			return this.m_E_SupportNumText3Text;
     		}
     	}

		public Button E_Btn3Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn3Button == null )
     			{
		    		this.m_E_Btn3Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Number3/E_Btn3");
     			}
     			return this.m_E_Btn3Button;
     		}
     	}

		public Image E_Btn3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn3Image == null )
     			{
		    		this.m_E_Btn3Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Number3/E_Btn3");
     			}
     			return this.m_E_Btn3Image;
     		}
     	}

		public Text E_BtnText3Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BtnText3Text == null )
     			{
		    		this.m_E_BtnText3Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Number3/E_Btn3/E_BtnText3");
     			}
     			return this.m_E_BtnText3Text;
     		}
     	}

		public Text E_TimeTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TimeTextText == null )
     			{
		    		this.m_E_TimeTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TimeText");
     			}
     			return this.m_E_TimeTextText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_es_rewardlist = null;
			this.m_es_modelshow1 = null;
			this.m_E_WinNumText1Text = null;
			this.m_E_SupportNumText1Text = null;
			this.m_E_Btn1Button = null;
			this.m_E_Btn1Image = null;
			this.m_E_BtnText1Text = null;
			this.m_es_modelshow2 = null;
			this.m_E_WinNumText2Text = null;
			this.m_E_SupportNumText2Text = null;
			this.m_E_Btn2Button = null;
			this.m_E_Btn2Image = null;
			this.m_E_BtnText2Text = null;
			this.m_es_modelshow3 = null;
			this.m_E_WinNumText3Text = null;
			this.m_E_SupportNumText3Text = null;
			this.m_E_Btn3Button = null;
			this.m_E_Btn3Image = null;
			this.m_E_BtnText3Text = null;
			this.m_E_TimeTextText = null;
			this.uiTransform = null;
		}

		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private EntityRef<ES_ModelShow> m_es_modelshow1 = null;
		private Text m_E_WinNumText1Text = null;
		private Text m_E_SupportNumText1Text = null;
		private Button m_E_Btn1Button = null;
		private Image m_E_Btn1Image = null;
		private Text m_E_BtnText1Text = null;
		private EntityRef<ES_ModelShow> m_es_modelshow2 = null;
		private Text m_E_WinNumText2Text = null;
		private Text m_E_SupportNumText2Text = null;
		private Button m_E_Btn2Button = null;
		private Image m_E_Btn2Image = null;
		private Text m_E_BtnText2Text = null;
		private EntityRef<ES_ModelShow> m_es_modelshow3 = null;
		private Text m_E_WinNumText3Text = null;
		private Text m_E_SupportNumText3Text = null;
		private Button m_E_Btn3Button = null;
		private Image m_E_Btn3Image = null;
		private Text m_E_BtnText3Text = null;
		private Text m_E_TimeTextText = null;
		public Transform uiTransform = null;
	}
}
