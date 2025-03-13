
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_TrialDungeon : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public int TowerId;
		
		public ES_ModelShow ES_ModelShow
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_ModelShow es = this.m_es_modelshow;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_ModelShow");
		    	   this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_SubButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_SubButton == null )
     			{
		    		this.m_E_Btn_SubButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_Btn_Sub");
     			}
     			return this.m_E_Btn_SubButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_SubImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_SubImage == null )
     			{
		    		this.m_E_Btn_SubImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_Btn_Sub");
     			}
     			return this.m_E_Btn_SubImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_AddButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_AddButton == null )
     			{
		    		this.m_E_Btn_AddButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_Btn_Add");
     			}
     			return this.m_E_Btn_AddButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_AddImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_AddImage == null )
     			{
		    		this.m_E_Btn_AddImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_Btn_Add");
     			}
     			return this.m_E_Btn_AddImage;
     		}
     	}

		public UnityEngine.UI.Text E_TextLayerText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextLayerText == null )
     			{
		    		this.m_E_TextLayerText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/E_TextLayer");
     			}
     			return this.m_E_TextLayerText;
     		}
     	}

		public UnityEngine.UI.Text E_TextMonsterHPText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextMonsterHPText == null )
     			{
		    		this.m_E_TextMonsterHPText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/E_TextMonsterHP");
     			}
     			return this.m_E_TextMonsterHPText;
     		}
     	}

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

		public UnityEngine.UI.Button E_Btn_ReceiveButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ReceiveButton == null )
     			{
		    		this.m_E_Btn_ReceiveButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_Receive");
     			}
     			return this.m_E_Btn_ReceiveButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ReceiveImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ReceiveImage == null )
     			{
		    		this.m_E_Btn_ReceiveImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_Receive");
     			}
     			return this.m_E_Btn_ReceiveImage;
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
     		}
     	}

		public UnityEngine.UI.Image E_Hint_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Hint_1Image == null )
     			{
		    		this.m_E_Hint_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Hint_1");
     			}
     			return this.m_E_Hint_1Image;
     		}
     	}

		public UnityEngine.UI.Image E_Hint_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Hint_2Image == null )
     			{
		    		this.m_E_Hint_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Hint_2");
     			}
     			return this.m_E_Hint_2Image;
     		}
     	}

		public UnityEngine.UI.Image E_Hint_3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Hint_3Image == null )
     			{
		    		this.m_E_Hint_3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Hint_3");
     			}
     			return this.m_E_Hint_3Image;
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
			this.m_es_modelshow = null;
			this.m_E_Btn_SubButton = null;
			this.m_E_Btn_SubImage = null;
			this.m_E_Btn_AddButton = null;
			this.m_E_Btn_AddImage = null;
			this.m_E_TextLayerText = null;
			this.m_E_TextMonsterHPText = null;
			this.m_E_Btn_EnterButton = null;
			this.m_E_Btn_EnterImage = null;
			this.m_E_Btn_ReceiveButton = null;
			this.m_E_Btn_ReceiveImage = null;
			this.m_es_rewardlist = null;
			this.m_E_Hint_1Image = null;
			this.m_E_Hint_2Image = null;
			this.m_E_Hint_3Image = null;
			this.uiTransform = null;
		}

		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private UnityEngine.UI.Button m_E_Btn_SubButton = null;
		private UnityEngine.UI.Image m_E_Btn_SubImage = null;
		private UnityEngine.UI.Button m_E_Btn_AddButton = null;
		private UnityEngine.UI.Image m_E_Btn_AddImage = null;
		private UnityEngine.UI.Text m_E_TextLayerText = null;
		private UnityEngine.UI.Text m_E_TextMonsterHPText = null;
		private UnityEngine.UI.Button m_E_Btn_EnterButton = null;
		private UnityEngine.UI.Image m_E_Btn_EnterImage = null;
		private UnityEngine.UI.Button m_E_Btn_ReceiveButton = null;
		private UnityEngine.UI.Image m_E_Btn_ReceiveImage = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private UnityEngine.UI.Image m_E_Hint_1Image = null;
		private UnityEngine.UI.Image m_E_Hint_2Image = null;
		private UnityEngine.UI.Image m_E_Hint_3Image = null;
		public Transform uiTransform = null;
	}
}
