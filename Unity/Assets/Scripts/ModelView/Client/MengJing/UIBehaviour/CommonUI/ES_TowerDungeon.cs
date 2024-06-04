
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_TowerDungeon : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.Button E_Btn_EnterButton
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
		    		this.m_E_Btn_EnterButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_Enter");
     			}
     			return this.m_E_Btn_EnterButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_EnterImage
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
		    		this.m_E_Btn_EnterImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_Enter");
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
     			if( this.m_es_rewardlist == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonSelect_1Button
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
		    		this.m_E_ButtonSelect_1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/GameObject/E_ButtonSelect_1");
     			}
     			return this.m_E_ButtonSelect_1Button;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonSelect_1Image
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
		    		this.m_E_ButtonSelect_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/GameObject/E_ButtonSelect_1");
     			}
     			return this.m_E_ButtonSelect_1Image;
     		}
     	}

		public UnityEngine.UI.Text E_TextLevelJianyi_1Text
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
		    		this.m_E_TextLevelJianyi_1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/GameObject/E_TextLevelJianyi_1");
     			}
     			return this.m_E_TextLevelJianyi_1Text;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonSelect_2Button
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
		    		this.m_E_ButtonSelect_2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/GameObject (1)/E_ButtonSelect_2");
     			}
     			return this.m_E_ButtonSelect_2Button;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonSelect_2Image
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
		    		this.m_E_ButtonSelect_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/GameObject (1)/E_ButtonSelect_2");
     			}
     			return this.m_E_ButtonSelect_2Image;
     		}
     	}

		public UnityEngine.UI.Text E_TextLevelJianyi_2Text
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
		    		this.m_E_TextLevelJianyi_2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/GameObject (1)/E_TextLevelJianyi_2");
     			}
     			return this.m_E_TextLevelJianyi_2Text;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonSelect_3Button
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
		    		this.m_E_ButtonSelect_3Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/GameObject (2)/E_ButtonSelect_3");
     			}
     			return this.m_E_ButtonSelect_3Button;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonSelect_3Image
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
		    		this.m_E_ButtonSelect_3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/GameObject (2)/E_ButtonSelect_3");
     			}
     			return this.m_E_ButtonSelect_3Image;
     		}
     	}

		public UnityEngine.UI.Text E_TextLevelJianyi_3Text
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
		    		this.m_E_TextLevelJianyi_3Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/GameObject (2)/E_TextLevelJianyi_3");
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

		private UnityEngine.UI.Button m_E_Btn_EnterButton = null;
		private UnityEngine.UI.Image m_E_Btn_EnterImage = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private UnityEngine.UI.Button m_E_ButtonSelect_1Button = null;
		private UnityEngine.UI.Image m_E_ButtonSelect_1Image = null;
		private UnityEngine.UI.Text m_E_TextLevelJianyi_1Text = null;
		private UnityEngine.UI.Button m_E_ButtonSelect_2Button = null;
		private UnityEngine.UI.Image m_E_ButtonSelect_2Image = null;
		private UnityEngine.UI.Text m_E_TextLevelJianyi_2Text = null;
		private UnityEngine.UI.Button m_E_ButtonSelect_3Button = null;
		private UnityEngine.UI.Image m_E_ButtonSelect_3Image = null;
		private UnityEngine.UI.Text m_E_TextLevelJianyi_3Text = null;
		public Transform uiTransform = null;
	}
}
