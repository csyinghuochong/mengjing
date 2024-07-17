using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetEggListItem : Entity,IAwake<Transform>,IDestroy 
	{
		public KeyValuePairInt RolePetEgg;
		public Action<int, PointerEventData> BeginDragHandler;
		public Action<int, PointerEventData> DragingHandler;
		public Action<int, PointerEventData> EndDragHandler;
		public long Timer;
		public int Index;
		
		public RectTransform EG_Node0RectTransform
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
		    		this.m_EG_Node0RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Node0");
     			}
     			return this.m_EG_Node0RectTransform;
     		}
     	}

		public RectTransform EG_Node1RectTransform
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
		    		this.m_EG_Node1RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Node1");
     			}
     			return this.m_EG_Node1RectTransform;
     		}
     	}

		public Image E_PetEggIconImage
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
		    		this.m_E_PetEggIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Node1/E_PetEggIcon");
     			}
     			return this.m_E_PetEggIconImage;
     		}
     	}

		public EventTrigger E_PetEggIconEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetEggIconEventTrigger == null )
     			{
		    		this.m_E_PetEggIconEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"EG_Node1/E_PetEggIcon");
     			}
     			return this.m_E_PetEggIconEventTrigger;
     		}
     	}

		public Button E_ButtonOpenButton
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
		    		this.m_E_ButtonOpenButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Node1/E_ButtonOpen");
     			}
     			return this.m_E_ButtonOpenButton;
     		}
     	}

		public Image E_ButtonOpenImage
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
		    		this.m_E_ButtonOpenImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Node1/E_ButtonOpen");
     			}
     			return this.m_E_ButtonOpenImage;
     		}
     	}

		public Button E_ButtonFuHuaButton
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
		    		this.m_E_ButtonFuHuaButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Node1/E_ButtonFuHua");
     			}
     			return this.m_E_ButtonFuHuaButton;
     		}
     	}

		public Image E_ButtonFuHuaImage
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
		    		this.m_E_ButtonFuHuaImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Node1/E_ButtonFuHua");
     			}
     			return this.m_E_ButtonFuHuaImage;
     		}
     	}

		public Button E_ButtonGetButton
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
		    		this.m_E_ButtonGetButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Node1/E_ButtonGet");
     			}
     			return this.m_E_ButtonGetButton;
     		}
     	}

		public Image E_ButtonGetImage
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
		    		this.m_E_ButtonGetImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Node1/E_ButtonGet");
     			}
     			return this.m_E_ButtonGetImage;
     		}
     	}

		public Text E_Text_TimeText
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
		    		this.m_E_Text_TimeText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Node1/E_Text_Time");
     			}
     			return this.m_E_Text_TimeText;
     		}
     	}

		public Text E_Text_NameText
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
		    		this.m_E_Text_NameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Node1/E_Text_Name");
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
			this.m_EG_Node1RectTransform = null;
			this.m_E_PetEggIconImage = null;
			this.m_E_PetEggIconEventTrigger = null;
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

		private RectTransform m_EG_Node0RectTransform = null;
		private RectTransform m_EG_Node1RectTransform = null;
		private Image m_E_PetEggIconImage = null;
		private EventTrigger m_E_PetEggIconEventTrigger = null;
		private Button m_E_ButtonOpenButton = null;
		private Image m_E_ButtonOpenImage = null;
		private Button m_E_ButtonFuHuaButton = null;
		private Image m_E_ButtonFuHuaImage = null;
		private Button m_E_ButtonGetButton = null;
		private Image m_E_ButtonGetImage = null;
		private Text m_E_Text_TimeText = null;
		private Text m_E_Text_NameText = null;
		public Transform uiTransform = null;
	}
}
