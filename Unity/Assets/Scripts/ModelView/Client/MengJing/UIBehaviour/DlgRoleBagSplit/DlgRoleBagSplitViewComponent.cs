
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
     			if( this.m_es_commonitem ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem");
		    	   this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem;
     		}
     	}

		public UnityEngine.UI.Button E_SplitButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SplitButton == null )
     			{
		    		this.m_E_SplitButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Split");
     			}
     			return this.m_E_SplitButton;
     		}
     	}

		public UnityEngine.UI.Image E_SplitImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SplitImage == null )
     			{
		    		this.m_E_SplitImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Split");
     			}
     			return this.m_E_SplitImage;
     		}
     	}

		public UnityEngine.UI.Button E_AddNumButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AddNumButton == null )
     			{
		    		this.m_E_AddNumButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_AddNum");
     			}
     			return this.m_E_AddNumButton;
     		}
     	}

		public UnityEngine.UI.Image E_AddNumImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AddNumImage == null )
     			{
		    		this.m_E_AddNumImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_AddNum");
     			}
     			return this.m_E_AddNumImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_AddNumEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AddNumEventTrigger == null )
     			{
		    		this.m_E_AddNumEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"E_AddNum");
     			}
     			return this.m_E_AddNumEventTrigger;
     		}
     	}

		public UnityEngine.UI.Button E_CostNumButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CostNumButton == null )
     			{
		    		this.m_E_CostNumButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_CostNum");
     			}
     			return this.m_E_CostNumButton;
     		}
     	}

		public UnityEngine.UI.Image E_CostNumImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CostNumImage == null )
     			{
		    		this.m_E_CostNumImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_CostNum");
     			}
     			return this.m_E_CostNumImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_CostNumEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CostNumEventTrigger == null )
     			{
		    		this.m_E_CostNumEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"E_CostNum");
     			}
     			return this.m_E_CostNumEventTrigger;
     		}
     	}

		public UnityEngine.UI.InputField E_NumInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NumInputField == null )
     			{
		    		this.m_E_NumInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"E_Num");
     			}
     			return this.m_E_NumInputField;
     		}
     	}

		public UnityEngine.UI.Image E_NumImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NumImage == null )
     			{
		    		this.m_E_NumImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Num");
     			}
     			return this.m_E_NumImage;
     		}
     	}

		public UnityEngine.UI.Button E_CloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseButton == null )
     			{
		    		this.m_E_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Close");
     			}
     			return this.m_E_CloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_CloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseImage == null )
     			{
		    		this.m_E_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Close");
     			}
     			return this.m_E_CloseImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_es_commonitem = null;
			this.m_E_SplitButton = null;
			this.m_E_SplitImage = null;
			this.m_E_AddNumButton = null;
			this.m_E_AddNumImage = null;
			this.m_E_AddNumEventTrigger = null;
			this.m_E_CostNumButton = null;
			this.m_E_CostNumImage = null;
			this.m_E_CostNumEventTrigger = null;
			this.m_E_NumInputField = null;
			this.m_E_NumImage = null;
			this.m_E_CloseButton = null;
			this.m_E_CloseImage = null;
			this.uiTransform = null;
		}

		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private UnityEngine.UI.Button m_E_SplitButton = null;
		private UnityEngine.UI.Image m_E_SplitImage = null;
		private UnityEngine.UI.Button m_E_AddNumButton = null;
		private UnityEngine.UI.Image m_E_AddNumImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_AddNumEventTrigger = null;
		private UnityEngine.UI.Button m_E_CostNumButton = null;
		private UnityEngine.UI.Image m_E_CostNumImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_CostNumEventTrigger = null;
		private UnityEngine.UI.InputField m_E_NumInputField = null;
		private UnityEngine.UI.Image m_E_NumImage = null;
		private UnityEngine.UI.Button m_E_CloseButton = null;
		private UnityEngine.UI.Image m_E_CloseImage = null;
		public Transform uiTransform = null;
	}
}
