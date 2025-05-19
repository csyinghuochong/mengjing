
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgCellDungeonRevive))]
	[EnableMethod]
	public  class DlgCellDungeonReviveViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Image E_ImageCostImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageCostImage == null )
     			{
		    		this.m_E_ImageCostImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_ImageCost");
     			}
     			return this.m_E_ImageCostImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_ExitButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ExitButton == null )
     			{
		    		this.m_E_Button_ExitButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Button_Exit");
     			}
     			return this.m_E_Button_ExitButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_ExitImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ExitImage == null )
     			{
		    		this.m_E_Button_ExitImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Button_Exit");
     			}
     			return this.m_E_Button_ExitImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_ExitDesText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_ExitDesText == null )
     			{
		    		this.m_E_Text_ExitDesText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_Button_Exit/E_Text_ExitDes");
     			}
     			return this.m_E_Text_ExitDesText;
     		}
     	}

		public UnityEngine.UI.Button E_Button_ReviveButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ReviveButton == null )
     			{
		    		this.m_E_Button_ReviveButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Button_Revive");
     			}
     			return this.m_E_Button_ReviveButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_ReviveImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_ReviveImage == null )
     			{
		    		this.m_E_Button_ReviveImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Button_Revive");
     			}
     			return this.m_E_Button_ReviveImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_DamageButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_DamageButton == null )
     			{
		    		this.m_E_Button_DamageButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Button_Damage");
     			}
     			return this.m_E_Button_DamageButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_DamageImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_DamageImage == null )
     			{
		    		this.m_E_Button_DamageImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Button_Damage");
     			}
     			return this.m_E_Button_DamageImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_ExitTipText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_ExitTipText == null )
     			{
		    		this.m_E_Text_ExitTipText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_Text_ExitTip");
     			}
     			return this.m_E_Text_ExitTipText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_Damage_TipText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Damage_TipText == null )
     			{
		    		this.m_E_Text_Damage_TipText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_Text_Damage_Tip");
     			}
     			return this.m_E_Text_Damage_TipText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_Damage_Record_0Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Damage_Record_0Text == null )
     			{
		    		this.m_E_Text_Damage_Record_0Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_Text_Damage_Record_0");
     			}
     			return this.m_E_Text_Damage_Record_0Text;
     		}
     	}

		public UnityEngine.UI.Text E_Text_Damage_Record_1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Damage_Record_1Text == null )
     			{
		    		this.m_E_Text_Damage_Record_1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_Text_Damage_Record_1");
     			}
     			return this.m_E_Text_Damage_Record_1Text;
     		}
     	}

		public UnityEngine.UI.Text E_Text_Damage_Record_2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Damage_Record_2Text == null )
     			{
		    		this.m_E_Text_Damage_Record_2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_Text_Damage_Record_2");
     			}
     			return this.m_E_Text_Damage_Record_2Text;
     		}
     	}

		public UnityEngine.UI.Text E_Text_CostText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_CostText == null )
     			{
		    		this.m_E_Text_CostText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_Text_Cost");
     			}
     			return this.m_E_Text_CostText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_CostNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_CostNameText == null )
     			{
		    		this.m_E_Text_CostNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_Text_CostName");
     			}
     			return this.m_E_Text_CostNameText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageCostImage = null;
			this.m_E_Button_ExitButton = null;
			this.m_E_Button_ExitImage = null;
			this.m_E_Text_ExitDesText = null;
			this.m_E_Button_ReviveButton = null;
			this.m_E_Button_ReviveImage = null;
			this.m_E_Button_DamageButton = null;
			this.m_E_Button_DamageImage = null;
			this.m_E_Text_ExitTipText = null;
			this.m_E_Text_Damage_TipText = null;
			this.m_E_Text_Damage_Record_0Text = null;
			this.m_E_Text_Damage_Record_1Text = null;
			this.m_E_Text_Damage_Record_2Text = null;
			this.m_E_Text_CostText = null;
			this.m_E_Text_CostNameText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_E_ImageCostImage = null;
		private UnityEngine.UI.Button m_E_Button_ExitButton = null;
		private UnityEngine.UI.Image m_E_Button_ExitImage = null;
		private UnityEngine.UI.Text m_E_Text_ExitDesText = null;
		private UnityEngine.UI.Button m_E_Button_ReviveButton = null;
		private UnityEngine.UI.Image m_E_Button_ReviveImage = null;
		private UnityEngine.UI.Button m_E_Button_DamageButton = null;
		private UnityEngine.UI.Image m_E_Button_DamageImage = null;
		private UnityEngine.UI.Text m_E_Text_ExitTipText = null;
		private UnityEngine.UI.Text m_E_Text_Damage_TipText = null;
		private UnityEngine.UI.Text m_E_Text_Damage_Record_0Text = null;
		private UnityEngine.UI.Text m_E_Text_Damage_Record_1Text = null;
		private UnityEngine.UI.Text m_E_Text_Damage_Record_2Text = null;
		private UnityEngine.UI.Text m_E_Text_CostText = null;
		private UnityEngine.UI.Text m_E_Text_CostNameText = null;
		public Transform uiTransform = null;
	}
}
