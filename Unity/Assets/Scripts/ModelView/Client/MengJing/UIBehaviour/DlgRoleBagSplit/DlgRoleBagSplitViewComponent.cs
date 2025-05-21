
using UnityEngine;
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Center/ES_CommonItem");
		    	   this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_SplitButton
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
		    		this.m_E_Btn_SplitButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Btn_Split");
     			}
     			return this.m_E_Btn_SplitButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_SplitImage
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
		    		this.m_E_Btn_SplitImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Btn_Split");
     			}
     			return this.m_E_Btn_SplitImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_AddNumButton
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
		    		this.m_E_Btn_AddNumButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Btn_AddNum");
     			}
     			return this.m_E_Btn_AddNumButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_AddNumImage
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
		    		this.m_E_Btn_AddNumImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Btn_AddNum");
     			}
     			return this.m_E_Btn_AddNumImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Btn_AddNumEventTrigger
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
		    		this.m_E_Btn_AddNumEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Center/E_Btn_AddNum");
     			}
     			return this.m_E_Btn_AddNumEventTrigger;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_CostNumButton
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
		    		this.m_E_Btn_CostNumButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Btn_CostNum");
     			}
     			return this.m_E_Btn_CostNumButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_CostNumImage
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
		    		this.m_E_Btn_CostNumImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Btn_CostNum");
     			}
     			return this.m_E_Btn_CostNumImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Btn_CostNumEventTrigger
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
		    		this.m_E_Btn_CostNumEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Center/E_Btn_CostNum");
     			}
     			return this.m_E_Btn_CostNumEventTrigger;
     		}
     	}

		public UnityEngine.UI.InputField E_InputFieldInputField
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
		    		this.m_E_InputFieldInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"Center/E_InputField");
     			}
     			return this.m_E_InputFieldInputField;
     		}
     	}

		public UnityEngine.UI.Image E_InputFieldImage
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
		    		this.m_E_InputFieldImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_InputField");
     			}
     			return this.m_E_InputFieldImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonCloseButton
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
		    		this.m_E_ButtonCloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_ButtonClose");
     			}
     			return this.m_E_ButtonCloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonCloseImage
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
		    		this.m_E_ButtonCloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_ButtonClose");
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
		private UnityEngine.UI.Button m_E_Btn_SplitButton = null;
		private UnityEngine.UI.Image m_E_Btn_SplitImage = null;
		private UnityEngine.UI.Button m_E_Btn_AddNumButton = null;
		private UnityEngine.UI.Image m_E_Btn_AddNumImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Btn_AddNumEventTrigger = null;
		private UnityEngine.UI.Button m_E_Btn_CostNumButton = null;
		private UnityEngine.UI.Image m_E_Btn_CostNumImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Btn_CostNumEventTrigger = null;
		private UnityEngine.UI.InputField m_E_InputFieldInputField = null;
		private UnityEngine.UI.Image m_E_InputFieldImage = null;
		private UnityEngine.UI.Button m_E_ButtonCloseButton = null;
		private UnityEngine.UI.Image m_E_ButtonCloseImage = null;
		public Transform uiTransform = null;
	}
}
