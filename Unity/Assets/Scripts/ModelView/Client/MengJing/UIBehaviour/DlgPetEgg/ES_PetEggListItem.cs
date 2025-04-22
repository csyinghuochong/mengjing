
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetEggListItem : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public KeyValuePairLong4 RolePetEgg;
		public long Timer;
		public int Index;
		
		public UnityEngine.RectTransform EG_Node0RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_Node0RectTransform == null )
     			{
		    		this.m_EG_Node0RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Node0");
     			}
     			return this.m_EG_Node0RectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_Text_OpenSlotValueText
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_Text_OpenSlotValueText == null )
				{
					this.m_E_Text_OpenSlotValueText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Node0/E_Text_OpenSlotValue");
				}
				return this.m_E_Text_OpenSlotValueText;
			}
		}
		
		public UnityEngine.UI.Button E_OpenSlotButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_OpenSlotButton == null )
     			{
		    		this.m_E_OpenSlotButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Node0/E_OpenSlot");
     			}
     			return this.m_E_OpenSlotButton;
     		}
     	}

		public UnityEngine.UI.Image E_OpenSlotImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_OpenSlotImage == null )
     			{
		    		this.m_E_OpenSlotImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node0/E_OpenSlot");
     			}
     			return this.m_E_OpenSlotImage;
     		}
     	}

		public UnityEngine.RectTransform EG_Node1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_Node1RectTransform == null )
     			{
		    		this.m_EG_Node1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Node1");
     			}
     			return this.m_EG_Node1RectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_ShowPetEggListButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ShowPetEggListButton == null )
     			{
		    		this.m_E_ShowPetEggListButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Node1/E_ShowPetEggList");
     			}
     			return this.m_E_ShowPetEggListButton;
     		}
     	}

		public UnityEngine.UI.Image E_ShowPetEggListImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ShowPetEggListImage == null )
     			{
		    		this.m_E_ShowPetEggListImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node1/E_ShowPetEggList");
     			}
     			return this.m_E_ShowPetEggListImage;
     		}
     	}

		public UnityEngine.RectTransform EG_Node2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_Node2RectTransform == null )
     			{
		    		this.m_EG_Node2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Node2");
     			}
     			return this.m_EG_Node2RectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_PetEggIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetEggIconImage == null )
     			{
		    		this.m_E_PetEggIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node2/E_PetEggIcon");
     			}
     			return this.m_E_PetEggIconImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonOpenButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonOpenButton == null )
     			{
		    		this.m_E_ButtonOpenButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Node2/E_ButtonOpen");
     			}
     			return this.m_E_ButtonOpenButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonOpenImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonOpenImage == null )
     			{
		    		this.m_E_ButtonOpenImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node2/E_ButtonOpen");
     			}
     			return this.m_E_ButtonOpenImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonFuHuaButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonFuHuaButton == null )
     			{
		    		this.m_E_ButtonFuHuaButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Node2/E_ButtonFuHua");
     			}
     			return this.m_E_ButtonFuHuaButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonFuHuaImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonFuHuaImage == null )
     			{
		    		this.m_E_ButtonFuHuaImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node2/E_ButtonFuHua");
     			}
     			return this.m_E_ButtonFuHuaImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonGetButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonGetButton == null )
     			{
		    		this.m_E_ButtonGetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Node2/E_ButtonGet");
     			}
     			return this.m_E_ButtonGetButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonGetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonGetImage == null )
     			{
		    		this.m_E_ButtonGetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node2/E_ButtonGet");
     			}
     			return this.m_E_ButtonGetImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_TimeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_TimeText == null )
     			{
		    		this.m_E_Text_TimeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Node2/E_Text_Time");
     			}
     			return this.m_E_Text_TimeText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_NameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_NameText == null )
     			{
		    		this.m_E_Text_NameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Node2/E_Text_Name");
     			}
     			return this.m_E_Text_NameText;
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
			this.m_EG_Node0RectTransform = null;
			this.m_E_Text_OpenSlotValueText = null;
			this.m_E_OpenSlotButton = null;
			this.m_E_OpenSlotImage = null;
			this.m_EG_Node1RectTransform = null;
			this.m_E_ShowPetEggListButton = null;
			this.m_E_ShowPetEggListImage = null;
			this.m_EG_Node2RectTransform = null;
			this.m_E_PetEggIconImage = null;
			this.m_E_ButtonOpenButton = null;
			this.m_E_ButtonOpenImage = null;
			this.m_E_ButtonFuHuaButton = null;
			this.m_E_ButtonFuHuaImage = null;
			this.m_E_ButtonGetButton = null;
			this.m_E_ButtonGetImage = null;
			this.m_E_Text_TimeText = null;
			this.m_E_Text_NameText = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_Node0RectTransform = null;
		private UnityEngine.UI.Text m_E_Text_OpenSlotValueText = null;
		private UnityEngine.UI.Button m_E_OpenSlotButton = null;
		private UnityEngine.UI.Image m_E_OpenSlotImage = null;
		private UnityEngine.RectTransform m_EG_Node1RectTransform = null;
		private UnityEngine.UI.Button m_E_ShowPetEggListButton = null;
		private UnityEngine.UI.Image m_E_ShowPetEggListImage = null;
		private UnityEngine.RectTransform m_EG_Node2RectTransform = null;
		private UnityEngine.UI.Image m_E_PetEggIconImage = null;
		private UnityEngine.UI.Button m_E_ButtonOpenButton = null;
		private UnityEngine.UI.Image m_E_ButtonOpenImage = null;
		private UnityEngine.UI.Button m_E_ButtonFuHuaButton = null;
		private UnityEngine.UI.Image m_E_ButtonFuHuaImage = null;
		private UnityEngine.UI.Button m_E_ButtonGetButton = null;
		private UnityEngine.UI.Image m_E_ButtonGetImage = null;
		private UnityEngine.UI.Text m_E_Text_TimeText = null;
		private UnityEngine.UI.Text m_E_Text_NameText = null;
		public Transform uiTransform = null;
	}
}
