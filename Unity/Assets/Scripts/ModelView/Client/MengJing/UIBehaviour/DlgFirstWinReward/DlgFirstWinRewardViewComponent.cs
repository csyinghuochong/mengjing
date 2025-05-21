
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgFirstWinReward))]
	[EnableMethod]
	public  class DlgFirstWinRewardViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_ImageButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageButtonButton == null )
     			{
		    		this.m_E_ImageButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ImageButton");
     			}
     			return this.m_E_ImageButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_ImageButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageButtonImage == null )
     			{
		    		this.m_E_ImageButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageButton");
     			}
     			return this.m_E_ImageButtonImage;
     		}
     	}

		public ES_RewardList ES_RewardList_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_RewardList es = this.m_es_rewardlist_1;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Center/ES_RewardList_1");
		    	   this.m_es_rewardlist_1 = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist_1;
     		}
     	}

		public ES_RewardList ES_RewardList_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_RewardList es = this.m_es_rewardlist_2;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Center/ES_RewardList_2");
		    	   this.m_es_rewardlist_2 = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist_2;
     		}
     	}

		public ES_RewardList ES_RewardList_3
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_RewardList es = this.m_es_rewardlist_3;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Center/ES_RewardList_3");
		    	   this.m_es_rewardlist_3 = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist_3;
     		}
     	}

		public UnityEngine.UI.Button E_Button_Get_1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_Get_1Button == null )
     			{
		    		this.m_E_Button_Get_1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Button_Get_1");
     			}
     			return this.m_E_Button_Get_1Button;
     		}
     	}

		public UnityEngine.UI.Image E_Button_Get_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_Get_1Image == null )
     			{
		    		this.m_E_Button_Get_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Button_Get_1");
     			}
     			return this.m_E_Button_Get_1Image;
     		}
     	}

		public UnityEngine.UI.Image E_Button_Complete_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_Complete_1Image == null )
     			{
		    		this.m_E_Button_Complete_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Button_Complete_1");
     			}
     			return this.m_E_Button_Complete_1Image;
     		}
     	}

		public UnityEngine.UI.Button E_Button_Get_2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_Get_2Button == null )
     			{
		    		this.m_E_Button_Get_2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Button_Get_2");
     			}
     			return this.m_E_Button_Get_2Button;
     		}
     	}

		public UnityEngine.UI.Image E_Button_Get_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_Get_2Image == null )
     			{
		    		this.m_E_Button_Get_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Button_Get_2");
     			}
     			return this.m_E_Button_Get_2Image;
     		}
     	}

		public UnityEngine.UI.Image E_Button_Complete_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_Complete_2Image == null )
     			{
		    		this.m_E_Button_Complete_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Button_Complete_2");
     			}
     			return this.m_E_Button_Complete_2Image;
     		}
     	}

		public UnityEngine.UI.Button E_Button_Get_3Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_Get_3Button == null )
     			{
		    		this.m_E_Button_Get_3Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Button_Get_3");
     			}
     			return this.m_E_Button_Get_3Button;
     		}
     	}

		public UnityEngine.UI.Image E_Button_Get_3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_Get_3Image == null )
     			{
		    		this.m_E_Button_Get_3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Button_Get_3");
     			}
     			return this.m_E_Button_Get_3Image;
     		}
     	}

		public UnityEngine.UI.Image E_Button_Complete_3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_Complete_3Image == null )
     			{
		    		this.m_E_Button_Complete_3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Button_Complete_3");
     			}
     			return this.m_E_Button_Complete_3Image;
     		}
     	}

		public UnityEngine.UI.Text E_TextTip_TitleText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextTip_TitleText == null )
     			{
		    		this.m_E_TextTip_TitleText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_TextTip_Title");
     			}
     			return this.m_E_TextTip_TitleText;
     		}
     	}

		public UnityEngine.UI.Text E_TextHintTipsText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextHintTipsText == null )
     			{
		    		this.m_E_TextHintTipsText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_TextHintTips");
     			}
     			return this.m_E_TextHintTipsText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageButtonButton = null;
			this.m_E_ImageButtonImage = null;
			this.m_es_rewardlist_1 = null;
			this.m_es_rewardlist_2 = null;
			this.m_es_rewardlist_3 = null;
			this.m_E_Button_Get_1Button = null;
			this.m_E_Button_Get_1Image = null;
			this.m_E_Button_Complete_1Image = null;
			this.m_E_Button_Get_2Button = null;
			this.m_E_Button_Get_2Image = null;
			this.m_E_Button_Complete_2Image = null;
			this.m_E_Button_Get_3Button = null;
			this.m_E_Button_Get_3Image = null;
			this.m_E_Button_Complete_3Image = null;
			this.m_E_TextTip_TitleText = null;
			this.m_E_TextHintTipsText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_ImageButtonButton = null;
		private UnityEngine.UI.Image m_E_ImageButtonImage = null;
		private EntityRef<ES_RewardList> m_es_rewardlist_1 = null;
		private EntityRef<ES_RewardList> m_es_rewardlist_2 = null;
		private EntityRef<ES_RewardList> m_es_rewardlist_3 = null;
		private UnityEngine.UI.Button m_E_Button_Get_1Button = null;
		private UnityEngine.UI.Image m_E_Button_Get_1Image = null;
		private UnityEngine.UI.Image m_E_Button_Complete_1Image = null;
		private UnityEngine.UI.Button m_E_Button_Get_2Button = null;
		private UnityEngine.UI.Image m_E_Button_Get_2Image = null;
		private UnityEngine.UI.Image m_E_Button_Complete_2Image = null;
		private UnityEngine.UI.Button m_E_Button_Get_3Button = null;
		private UnityEngine.UI.Image m_E_Button_Get_3Image = null;
		private UnityEngine.UI.Image m_E_Button_Complete_3Image = null;
		private UnityEngine.UI.Text m_E_TextTip_TitleText = null;
		private UnityEngine.UI.Text m_E_TextHintTipsText = null;
		public Transform uiTransform = null;
	}
}
