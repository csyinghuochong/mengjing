using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgRoleBagSplit))]
	[EnableMethod]
	public  class DlgRoleBagSplitViewComponent : Entity,IAwake,IDestroy 
	{
		public ES_CommonItem ES_CommonItem
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_CommonItem es = this.m_es_commonitem;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem");
		    	   this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem;
     		}
     	}

		public Button E_Btn_SplitButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_SplitButton == null )
     			{
		    		this.m_E_Btn_SplitButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_Split");
     			}
     			return this.m_E_Btn_SplitButton;
     		}
     	}

		public Image E_Btn_SplitImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_SplitImage == null )
     			{
		    		this.m_E_Btn_SplitImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_Split");
     			}
     			return this.m_E_Btn_SplitImage;
     		}
     	}

		public Button E_Btn_AddNumButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_AddNumButton == null )
     			{
		    		this.m_E_Btn_AddNumButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_AddNum");
     			}
     			return this.m_E_Btn_AddNumButton;
     		}
     	}

		public Image E_Btn_AddNumImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_AddNumImage == null )
     			{
		    		this.m_E_Btn_AddNumImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_AddNum");
     			}
     			return this.m_E_Btn_AddNumImage;
     		}
     	}

		public EventTrigger E_Btn_AddNumEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_AddNumEventTrigger == null )
     			{
		    		this.m_E_Btn_AddNumEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"E_Btn_AddNum");
     			}
     			return this.m_E_Btn_AddNumEventTrigger;
     		}
     	}

		public Button E_Btn_CostNumButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CostNumButton == null )
     			{
		    		this.m_E_Btn_CostNumButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_CostNum");
     			}
     			return this.m_E_Btn_CostNumButton;
     		}
     	}

		public Image E_Btn_CostNumImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CostNumImage == null )
     			{
		    		this.m_E_Btn_CostNumImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_CostNum");
     			}
     			return this.m_E_Btn_CostNumImage;
     		}
     	}

		public EventTrigger E_Btn_CostNumEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CostNumEventTrigger == null )
     			{
		    		this.m_E_Btn_CostNumEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"E_Btn_CostNum");
     			}
     			return this.m_E_Btn_CostNumEventTrigger;
     		}
     	}

		public InputField E_InputFieldInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputFieldInputField == null )
     			{
		    		this.m_E_InputFieldInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"E_InputField");
     			}
     			return this.m_E_InputFieldInputField;
     		}
     	}

		public Image E_InputFieldImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputFieldImage == null )
     			{
		    		this.m_E_InputFieldImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_InputField");
     			}
     			return this.m_E_InputFieldImage;
     		}
     	}

		public Button E_ButtonCloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonCloseButton == null )
     			{
		    		this.m_E_ButtonCloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonClose");
     			}
     			return this.m_E_ButtonCloseButton;
     		}
     	}

		public Image E_ButtonCloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonCloseImage == null )
     			{
		    		this.m_E_ButtonCloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonClose");
     			}
     			return this.m_E_ButtonCloseImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_es_commonitem = null;
			this.m_E_Btn_SplitButton = null;
			this.m_E_Btn_SplitImage = null;
			this.m_E_Btn_AddNumButton = null;
			this.m_E_Btn_AddNumImage = null;
			this.m_E_Btn_AddNumEventTrigger = null;
			this.m_E_Btn_CostNumButton = null;
			this.m_E_Btn_CostNumImage = null;
			this.m_E_Btn_CostNumEventTrigger = null;
			this.m_E_InputFieldInputField = null;
			this.m_E_InputFieldImage = null;
			this.m_E_ButtonCloseButton = null;
			this.m_E_ButtonCloseImage = null;
			this.uiTransform = null;
		}

		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private Button m_E_Btn_SplitButton = null;
		private Image m_E_Btn_SplitImage = null;
		private Button m_E_Btn_AddNumButton = null;
		private Image m_E_Btn_AddNumImage = null;
		private EventTrigger m_E_Btn_AddNumEventTrigger = null;
		private Button m_E_Btn_CostNumButton = null;
		private Image m_E_Btn_CostNumImage = null;
		private EventTrigger m_E_Btn_CostNumEventTrigger = null;
		private InputField m_E_InputFieldInputField = null;
		private Image m_E_InputFieldImage = null;
		private Button m_E_ButtonCloseButton = null;
		private Image m_E_ButtonCloseImage = null;
		public Transform uiTransform = null;
	}
}
