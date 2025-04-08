
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetMeleeCard : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public PetMeleeCardInfo PetMeleeCardInfo;
		public GameObject UnitGameObject; // 拖动卡牌时跟随的宠物模型、技能指示器
		public string UnitAssetsPath;
		public float CellSize = 3.33f;
		public bool CanPlace;
		
		public Vector3 TargetPos;
		public long TargetUnitId;
		
		public int MapTypeEnum { get; set; }

		public int BattleCamp { get; set; }
		
		
		public long Timer;
		public Vector2 StartPos;
		public GameObject CardIconGameObject;
		
		public UnityEngine.UI.Image E_BackImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BackImage == null )
     			{
		    		this.m_E_BackImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Back");
     			}
     			return this.m_E_BackImage;
     		}
     	}

		public UnityEngine.UI.Text E_Cost_ActiveText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Cost_ActiveText == null )
     			{
		    		this.m_E_Cost_ActiveText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Cost_Active");
     			}
     			return this.m_E_Cost_ActiveText;
     		}
     	}

		public UnityEngine.UI.Text E_Cost_InactiveText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Cost_InactiveText == null )
     			{
		    		this.m_E_Cost_InactiveText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Cost_Inactive");
     			}
     			return this.m_E_Cost_InactiveText;
     		}
     	}

		public UnityEngine.UI.Text E_NameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NameText == null )
     			{
		    		this.m_E_NameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Name");
     			}
     			return this.m_E_NameText;
     		}
     	}

		public UnityEngine.UI.Text E_TypeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TypeText == null )
     			{
		    		this.m_E_TypeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Type");
     			}
     			return this.m_E_TypeText;
     		}
     	}

		public UnityEngine.UI.Image E_IconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_IconImage == null )
     			{
		    		this.m_E_IconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Img_Mask/E_Icon");
     			}
     			return this.m_E_IconImage;
     		}
     	}

		public UnityEngine.UI.Image E_Icon2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Icon2Image == null )
     			{
		    		this.m_E_Icon2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Icon2");
     			}
     			return this.m_E_Icon2Image;
     		}
     	}

		public UnityEngine.UI.Image E_TouchImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TouchImage == null )
     			{
		    		this.m_E_TouchImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Touch");
     			}
     			return this.m_E_TouchImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_TouchEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TouchEventTrigger == null )
     			{
		    		this.m_E_TouchEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"E_Touch");
     			}
     			return this.m_E_TouchEventTrigger;
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
			this.m_E_BackImage = null;
			this.m_E_Cost_ActiveText = null;
			this.m_E_Cost_InactiveText = null;
			this.m_E_NameText = null;
			this.m_E_TypeText = null;
			this.m_E_IconImage = null;
			this.m_E_Icon2Image = null;
			this.m_E_TouchImage = null;
			this.m_E_TouchEventTrigger = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_E_BackImage = null;
		private UnityEngine.UI.Text m_E_Cost_ActiveText = null;
		private UnityEngine.UI.Text m_E_Cost_InactiveText = null;
		private UnityEngine.UI.Text m_E_NameText = null;
		private UnityEngine.UI.Text m_E_TypeText = null;
		private UnityEngine.UI.Image m_E_IconImage = null;
		private UnityEngine.UI.Image m_E_Icon2Image = null;
		private UnityEngine.UI.Image m_E_TouchImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_TouchEventTrigger = null;
		public Transform uiTransform = null;
	}
}
