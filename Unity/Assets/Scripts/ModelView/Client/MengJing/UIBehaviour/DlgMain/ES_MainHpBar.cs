
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_MainHpBar : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public int BossConfiId;
		public long LockBossId;
		public LockTargetComponent LockTargetComponent { get; set; }

		public long SingTimer;
		public long SingEndTime;
		public long SingTotalTime;

		public long PlayerHurt;
		public long PetHurt;

		public string DefaultString = "0";

		public long MyUnitId = 0;

		public int SceneType;
		
		public UnityEngine.RectTransform EG_BossNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_BossNodeRectTransform == null )
     			{
		    		this.m_EG_BossNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_BossNode");
     			}
     			return this.m_EG_BossNodeRectTransform;
     		}
     	}

		public ES_MainBuff ES_MainBuff
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_MainBuff es = this.m_es_mainbuff;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_BossNode/ES_MainBuff");
		    	   this.m_es_mainbuff = this.AddChild<ES_MainBuff,Transform>(subTrans);
     			}
     			return this.m_es_mainbuff;
     		}
     	}

		public UnityEngine.UI.Image E_Img_BossHpImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_BossHpImage == null )
     			{
		    		this.m_E_Img_BossHpImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_BossNode/E_Img_BossHp");
     			}
     			return this.m_E_Img_BossHpImage;
     		}
     	}

		public UnityEngine.UI.Image E_Img_BoosHpRightImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_BoosHpRightImage == null )
     			{
		    		this.m_E_Img_BoosHpRightImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_BossNode/E_Img_BossHp/E_Img_BoosHpRight");
     			}
     			return this.m_E_Img_BoosHpRightImage;
     		}
     	}

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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_BossNode/ES_ModelShow");
		    	   this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow;
     		}
     	}

		public UnityEngine.RectTransform EG_SingNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SingNodeRectTransform == null )
     			{
		    		this.m_EG_SingNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_BossNode/EG_SingNode");
     			}
     			return this.m_EG_SingNodeRectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_Img_SingValueImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_SingValueImage == null )
     			{
		    		this.m_E_Img_SingValueImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_BossNode/EG_SingNode/E_Img_SingValue");
     			}
     			return this.m_E_Img_SingValueImage;
     		}
     	}

		public UnityEngine.UI.Image E_Img_SingDiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_SingDiImage == null )
     			{
		    		this.m_E_Img_SingDiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_BossNode/EG_SingNode/E_Img_SingDi");
     			}
     			return this.m_E_Img_SingDiImage;
     		}
     	}

		public UnityEngine.RectTransform EG_HurtTextNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_HurtTextNodeRectTransform == null )
     			{
		    		this.m_EG_HurtTextNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_BossNode/EG_HurtTextNode");
     			}
     			return this.m_EG_HurtTextNodeRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_HurtTextPlayerText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HurtTextPlayerText == null )
     			{
		    		this.m_E_HurtTextPlayerText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_BossNode/EG_HurtTextNode/E_HurtTextPlayer");
     			}
     			return this.m_E_HurtTextPlayerText;
     		}
     	}

		public UnityEngine.UI.Text E_HurtTextPetText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HurtTextPetText == null )
     			{
		    		this.m_E_HurtTextPetText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_BossNode/EG_HurtTextNode/E_HurtTextPet");
     			}
     			return this.m_E_HurtTextPetText;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_BossNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_BossNameText == null )
     			{
		    		this.m_E_Lab_BossNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_BossNode/E_Lab_BossName");
     			}
     			return this.m_E_Lab_BossNameText;
     		}
     	}
		
		public UnityEngine.UI.Image E_Boss_Icon
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_Boss_Icon == null )
				{
					this.m_E_Boss_Icon = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_BossNode/Img_Di2Mask/E_Boss_Icon");
				}
				return this.m_E_Boss_Icon;
			}
		}

		public UnityEngine.UI.Text E_Lab_BossLvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_BossLvText == null )
     			{
		    		this.m_E_Lab_BossLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_BossNode/E_Lab_BossLv");
     			}
     			return this.m_E_Lab_BossLvText;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_OwnerText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_OwnerText == null )
     			{
		    		this.m_E_Lab_OwnerText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_BossNode/E_Lab_Owner");
     			}
     			return this.m_E_Lab_OwnerText;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_DeveText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_DeveText == null )
     			{
		    		this.m_E_Lab_DeveText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_BossNode/E_Lab_Deve");
     			}
     			return this.m_E_Lab_DeveText;
     		}
     	}

		public UnityEngine.RectTransform EG_MonsterNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_MonsterNodeRectTransform == null )
     			{
		    		this.m_EG_MonsterNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_MonsterNode");
     			}
     			return this.m_EG_MonsterNodeRectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_Img_MonsterHpImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_MonsterHpImage == null )
     			{
		    		this.m_E_Img_MonsterHpImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_MonsterNode/E_Img_MonsterHp");
     			}
     			return this.m_E_Img_MonsterHpImage;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_MonsterNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_MonsterNameText == null )
     			{
		    		this.m_E_Lab_MonsterNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_MonsterNode/E_Lab_MonsterName");
     			}
     			return this.m_E_Lab_MonsterNameText;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_MonsterLvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_MonsterLvText == null )
     			{
		    		this.m_E_Lab_MonsterLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_MonsterNode/E_Lab_MonsterLv");
     			}
     			return this.m_E_Lab_MonsterLvText;
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
			this.m_EG_BossNodeRectTransform = null;
			this.m_es_mainbuff = null;
			this.m_E_Img_BossHpImage = null;
			this.m_E_Img_BoosHpRightImage = null;
			this.m_es_modelshow = null;
			this.m_EG_SingNodeRectTransform = null;
			this.m_E_Img_SingValueImage = null;
			this.m_E_Img_SingDiImage = null;
			this.m_EG_HurtTextNodeRectTransform = null;
			this.m_E_HurtTextPlayerText = null;
			this.m_E_HurtTextPetText = null;
			this.m_E_Lab_BossNameText = null;
			this.m_E_Lab_BossLvText = null;
			this.m_E_Lab_OwnerText = null;
			this.m_E_Lab_DeveText = null;
			this.m_EG_MonsterNodeRectTransform = null;
			this.m_E_Img_MonsterHpImage = null;
			this.m_E_Lab_MonsterNameText = null;
			this.m_E_Lab_MonsterLvText = null;
			this.m_E_Boss_Icon = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_BossNodeRectTransform = null;
		private EntityRef<ES_MainBuff> m_es_mainbuff = null;
		private UnityEngine.UI.Image m_E_Img_BossHpImage = null;
		private UnityEngine.UI.Image m_E_Img_BoosHpRightImage = null;
		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private UnityEngine.RectTransform m_EG_SingNodeRectTransform = null;
		private UnityEngine.UI.Image m_E_Img_SingValueImage = null;
		private UnityEngine.UI.Image m_E_Img_SingDiImage = null;
		private UnityEngine.RectTransform m_EG_HurtTextNodeRectTransform = null;
		private UnityEngine.UI.Text m_E_HurtTextPlayerText = null;
		private UnityEngine.UI.Text m_E_HurtTextPetText = null;
		private UnityEngine.UI.Text m_E_Lab_BossNameText = null;
		private UnityEngine.UI.Text m_E_Lab_BossLvText = null;
		private UnityEngine.UI.Text m_E_Lab_OwnerText = null;
		private UnityEngine.UI.Text m_E_Lab_DeveText = null;
		private UnityEngine.RectTransform m_EG_MonsterNodeRectTransform = null;
		private UnityEngine.UI.Image m_E_Img_MonsterHpImage = null;
		private UnityEngine.UI.Text m_E_Lab_MonsterNameText = null;
		private UnityEngine.UI.Text m_E_Lab_MonsterLvText = null;
		private UnityEngine.UI.Image m_E_Boss_Icon = null;
		public Transform uiTransform = null;
	}
}
