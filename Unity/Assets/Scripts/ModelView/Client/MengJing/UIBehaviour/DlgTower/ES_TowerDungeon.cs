using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_TowerDungeon : Entity,IAwake<Transform>,IDestroy 
	{
		public int FubenDifficulty;
		
		public Button E_Btn_EnterButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_EnterButton == null )
     			{
		    		this.m_E_Btn_EnterButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/E_Btn_Enter");
     			}
     			return this.m_E_Btn_EnterButton;
     		}
     	}

		public Image E_Btn_EnterImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_EnterImage == null )
     			{
		    		this.m_E_Btn_EnterImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_Btn_Enter");
     			}
     			return this.m_E_Btn_EnterImage;
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
     			if( es ==null  )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
     		}
     	}

		public Button E_ButtonSelect_1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonSelect_1Button == null )
     			{
		    		this.m_E_ButtonSelect_1Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Left/GameObject/E_ButtonSelect_1");
     			}
     			return this.m_E_ButtonSelect_1Button;
     		}
     	}

		public Image E_ButtonSelect_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonSelect_1Image == null )
     			{
		    		this.m_E_ButtonSelect_1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/GameObject/E_ButtonSelect_1");
     			}
     			return this.m_E_ButtonSelect_1Image;
     		}
     	}

		public Text E_TextLevelJianyi_1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextLevelJianyi_1Text == null )
     			{
		    		this.m_E_TextLevelJianyi_1Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Left/GameObject/E_TextLevelJianyi_1");
     			}
     			return this.m_E_TextLevelJianyi_1Text;
     		}
     	}

		public Button E_ButtonSelect_2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonSelect_2Button == null )
     			{
		    		this.m_E_ButtonSelect_2Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Left/GameObject (1)/E_ButtonSelect_2");
     			}
     			return this.m_E_ButtonSelect_2Button;
     		}
     	}

		public Image E_ButtonSelect_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonSelect_2Image == null )
     			{
		    		this.m_E_ButtonSelect_2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/GameObject (1)/E_ButtonSelect_2");
     			}
     			return this.m_E_ButtonSelect_2Image;
     		}
     	}

		public Text E_TextLevelJianyi_2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextLevelJianyi_2Text == null )
     			{
		    		this.m_E_TextLevelJianyi_2Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Left/GameObject (1)/E_TextLevelJianyi_2");
     			}
     			return this.m_E_TextLevelJianyi_2Text;
     		}
     	}

		public Button E_ButtonSelect_3Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonSelect_3Button == null )
     			{
		    		this.m_E_ButtonSelect_3Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Left/GameObject (2)/E_ButtonSelect_3");
     			}
     			return this.m_E_ButtonSelect_3Button;
     		}
     	}

		public Image E_ButtonSelect_3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonSelect_3Image == null )
     			{
		    		this.m_E_ButtonSelect_3Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/GameObject (2)/E_ButtonSelect_3");
     			}
     			return this.m_E_ButtonSelect_3Image;
     		}
     	}

		public Text E_TextLevelJianyi_3Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextLevelJianyi_3Text == null )
     			{
		    		this.m_E_TextLevelJianyi_3Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Left/GameObject (2)/E_TextLevelJianyi_3");
     			}
     			return this.m_E_TextLevelJianyi_3Text;
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
			this.m_E_Btn_EnterButton = null;
			this.m_E_Btn_EnterImage = null;
			this.m_es_rewardlist = null;
			this.m_E_ButtonSelect_1Button = null;
			this.m_E_ButtonSelect_1Image = null;
			this.m_E_TextLevelJianyi_1Text = null;
			this.m_E_ButtonSelect_2Button = null;
			this.m_E_ButtonSelect_2Image = null;
			this.m_E_TextLevelJianyi_2Text = null;
			this.m_E_ButtonSelect_3Button = null;
			this.m_E_ButtonSelect_3Image = null;
			this.m_E_TextLevelJianyi_3Text = null;
			this.uiTransform = null;
		}

		private Button m_E_Btn_EnterButton = null;
		private Image m_E_Btn_EnterImage = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private Button m_E_ButtonSelect_1Button = null;
		private Image m_E_ButtonSelect_1Image = null;
		private Text m_E_TextLevelJianyi_1Text = null;
		private Button m_E_ButtonSelect_2Button = null;
		private Image m_E_ButtonSelect_2Image = null;
		private Text m_E_TextLevelJianyi_2Text = null;
		private Button m_E_ButtonSelect_3Button = null;
		private Image m_E_ButtonSelect_3Image = null;
		private Text m_E_TextLevelJianyi_3Text = null;
		public Transform uiTransform = null;
	}
}
