
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgMiJingMain))]
	[EnableMethod]
	public  class DlgMiJingMainViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EG_DamageListNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_DamageListNodeRectTransform == null )
     			{
		    		this.m_EG_DamageListNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_DamageListNode");
     			}
     			return this.m_EG_DamageListNodeRectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_ImageHeadImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageHeadImage == null )
     			{
		    		this.m_E_ImageHeadImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/EG_DamageListNode/Item_MainTeamItem1/E_ImageHead");
     			}
     			return this.m_E_ImageHeadImage;
     		}
     	}

		public UnityEngine.UI.Image E_ImageHeadImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageHeadImage == null )
     			{
		    		this.m_E_ImageHeadImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/EG_DamageListNode/Item_MainTeamItem2/E_ImageHead");
     			}
     			return this.m_E_ImageHeadImage;
     		}
     	}

		public UnityEngine.UI.Image E_ImageHeadImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageHeadImage == null )
     			{
		    		this.m_E_ImageHeadImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/EG_DamageListNode/Item_MainTeamItem3/E_ImageHead");
     			}
     			return this.m_E_ImageHeadImage;
     		}
     	}

		public UnityEngine.UI.Image E_ImageHeadImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageHeadImage == null )
     			{
		    		this.m_E_ImageHeadImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/EG_DamageListNode/Item_MainTeamItem4/E_ImageHead");
     			}
     			return this.m_E_ImageHeadImage;
     		}
     	}

		public UnityEngine.UI.Image E_ImageHeadImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageHeadImage == null )
     			{
		    		this.m_E_ImageHeadImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/EG_DamageListNode/Item_MainTeamItem5/E_ImageHead");
     			}
     			return this.m_E_ImageHeadImage;
     		}
     	}

		public UnityEngine.UI.Image E_ImageBooldValueImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageBooldValueImage == null )
     			{
		    		this.m_E_ImageBooldValueImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/EG_DamageListNode/Item_MainTeamItem1/ImageBooldDi/E_ImageBooldValue");
     			}
     			return this.m_E_ImageBooldValueImage;
     		}
     	}

		public UnityEngine.UI.Image E_ImageBooldValueImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageBooldValueImage == null )
     			{
		    		this.m_E_ImageBooldValueImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/EG_DamageListNode/Item_MainTeamItem2/ImageBooldDi/E_ImageBooldValue");
     			}
     			return this.m_E_ImageBooldValueImage;
     		}
     	}

		public UnityEngine.UI.Image E_ImageBooldValueImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageBooldValueImage == null )
     			{
		    		this.m_E_ImageBooldValueImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/EG_DamageListNode/Item_MainTeamItem3/ImageBooldDi/E_ImageBooldValue");
     			}
     			return this.m_E_ImageBooldValueImage;
     		}
     	}

		public UnityEngine.UI.Image E_ImageBooldValueImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageBooldValueImage == null )
     			{
		    		this.m_E_ImageBooldValueImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/EG_DamageListNode/Item_MainTeamItem4/ImageBooldDi/E_ImageBooldValue");
     			}
     			return this.m_E_ImageBooldValueImage;
     		}
     	}

		public UnityEngine.UI.Image E_ImageBooldValueImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageBooldValueImage == null )
     			{
		    		this.m_E_ImageBooldValueImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/EG_DamageListNode/Item_MainTeamItem5/ImageBooldDi/E_ImageBooldValue");
     			}
     			return this.m_E_ImageBooldValueImage;
     		}
     	}

		public UnityEngine.UI.Text E_PlayerLvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PlayerLvText == null )
     			{
		    		this.m_E_PlayerLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/EG_DamageListNode/Item_MainTeamItem1/E_PlayerLv");
     			}
     			return this.m_E_PlayerLvText;
     		}
     	}

		public UnityEngine.UI.Text E_PlayerLvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PlayerLvText == null )
     			{
		    		this.m_E_PlayerLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/EG_DamageListNode/Item_MainTeamItem2/E_PlayerLv");
     			}
     			return this.m_E_PlayerLvText;
     		}
     	}

		public UnityEngine.UI.Text E_PlayerLvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PlayerLvText == null )
     			{
		    		this.m_E_PlayerLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/EG_DamageListNode/Item_MainTeamItem3/E_PlayerLv");
     			}
     			return this.m_E_PlayerLvText;
     		}
     	}

		public UnityEngine.UI.Text E_PlayerLvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PlayerLvText == null )
     			{
		    		this.m_E_PlayerLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/EG_DamageListNode/Item_MainTeamItem4/E_PlayerLv");
     			}
     			return this.m_E_PlayerLvText;
     		}
     	}

		public UnityEngine.UI.Text E_PlayerLvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PlayerLvText == null )
     			{
		    		this.m_E_PlayerLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/EG_DamageListNode/Item_MainTeamItem5/E_PlayerLv");
     			}
     			return this.m_E_PlayerLvText;
     		}
     	}

		public UnityEngine.UI.Text E_PlayerNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PlayerNameText == null )
     			{
		    		this.m_E_PlayerNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/EG_DamageListNode/Item_MainTeamItem1/E_PlayerName");
     			}
     			return this.m_E_PlayerNameText;
     		}
     	}

		public UnityEngine.UI.Text E_PlayerNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PlayerNameText == null )
     			{
		    		this.m_E_PlayerNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/EG_DamageListNode/Item_MainTeamItem2/E_PlayerName");
     			}
     			return this.m_E_PlayerNameText;
     		}
     	}

		public UnityEngine.UI.Text E_PlayerNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PlayerNameText == null )
     			{
		    		this.m_E_PlayerNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/EG_DamageListNode/Item_MainTeamItem3/E_PlayerName");
     			}
     			return this.m_E_PlayerNameText;
     		}
     	}

		public UnityEngine.UI.Text E_PlayerNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PlayerNameText == null )
     			{
		    		this.m_E_PlayerNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/EG_DamageListNode/Item_MainTeamItem4/E_PlayerName");
     			}
     			return this.m_E_PlayerNameText;
     		}
     	}

		public UnityEngine.UI.Text E_PlayerNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PlayerNameText == null )
     			{
		    		this.m_E_PlayerNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/EG_DamageListNode/Item_MainTeamItem5/E_PlayerName");
     			}
     			return this.m_E_PlayerNameText;
     		}
     	}

		public UnityEngine.UI.Text E_DamageValueText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DamageValueText == null )
     			{
		    		this.m_E_DamageValueText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/EG_DamageListNode/Item_MainTeamItem1/E_DamageValue");
     			}
     			return this.m_E_DamageValueText;
     		}
     	}

		public UnityEngine.UI.Text E_DamageValueText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DamageValueText == null )
     			{
		    		this.m_E_DamageValueText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/EG_DamageListNode/Item_MainTeamItem2/E_DamageValue");
     			}
     			return this.m_E_DamageValueText;
     		}
     	}

		public UnityEngine.UI.Text E_DamageValueText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DamageValueText == null )
     			{
		    		this.m_E_DamageValueText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/EG_DamageListNode/Item_MainTeamItem3/E_DamageValue");
     			}
     			return this.m_E_DamageValueText;
     		}
     	}

		public UnityEngine.UI.Text E_DamageValueText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DamageValueText == null )
     			{
		    		this.m_E_DamageValueText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/EG_DamageListNode/Item_MainTeamItem4/E_DamageValue");
     			}
     			return this.m_E_DamageValueText;
     		}
     	}

		public UnityEngine.UI.Text E_DamageValueText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DamageValueText == null )
     			{
		    		this.m_E_DamageValueText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/EG_DamageListNode/Item_MainTeamItem5/E_DamageValue");
     			}
     			return this.m_E_DamageValueText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_DamageListNodeRectTransform = null;
			this.m_E_ImageHeadImage = null;
			this.m_E_ImageHeadImage = null;
			this.m_E_ImageHeadImage = null;
			this.m_E_ImageHeadImage = null;
			this.m_E_ImageHeadImage = null;
			this.m_E_ImageBooldValueImage = null;
			this.m_E_ImageBooldValueImage = null;
			this.m_E_ImageBooldValueImage = null;
			this.m_E_ImageBooldValueImage = null;
			this.m_E_ImageBooldValueImage = null;
			this.m_E_PlayerLvText = null;
			this.m_E_PlayerLvText = null;
			this.m_E_PlayerLvText = null;
			this.m_E_PlayerLvText = null;
			this.m_E_PlayerLvText = null;
			this.m_E_PlayerNameText = null;
			this.m_E_PlayerNameText = null;
			this.m_E_PlayerNameText = null;
			this.m_E_PlayerNameText = null;
			this.m_E_PlayerNameText = null;
			this.m_E_DamageValueText = null;
			this.m_E_DamageValueText = null;
			this.m_E_DamageValueText = null;
			this.m_E_DamageValueText = null;
			this.m_E_DamageValueText = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_DamageListNodeRectTransform = null;
		private UnityEngine.UI.Image m_E_ImageHeadImage = null;
		private UnityEngine.UI.Image m_E_ImageHeadImage = null;
		private UnityEngine.UI.Image m_E_ImageHeadImage = null;
		private UnityEngine.UI.Image m_E_ImageHeadImage = null;
		private UnityEngine.UI.Image m_E_ImageHeadImage = null;
		private UnityEngine.UI.Image m_E_ImageBooldValueImage = null;
		private UnityEngine.UI.Image m_E_ImageBooldValueImage = null;
		private UnityEngine.UI.Image m_E_ImageBooldValueImage = null;
		private UnityEngine.UI.Image m_E_ImageBooldValueImage = null;
		private UnityEngine.UI.Image m_E_ImageBooldValueImage = null;
		private UnityEngine.UI.Text m_E_PlayerLvText = null;
		private UnityEngine.UI.Text m_E_PlayerLvText = null;
		private UnityEngine.UI.Text m_E_PlayerLvText = null;
		private UnityEngine.UI.Text m_E_PlayerLvText = null;
		private UnityEngine.UI.Text m_E_PlayerLvText = null;
		private UnityEngine.UI.Text m_E_PlayerNameText = null;
		private UnityEngine.UI.Text m_E_PlayerNameText = null;
		private UnityEngine.UI.Text m_E_PlayerNameText = null;
		private UnityEngine.UI.Text m_E_PlayerNameText = null;
		private UnityEngine.UI.Text m_E_PlayerNameText = null;
		private UnityEngine.UI.Text m_E_DamageValueText = null;
		private UnityEngine.UI.Text m_E_DamageValueText = null;
		private UnityEngine.UI.Text m_E_DamageValueText = null;
		private UnityEngine.UI.Text m_E_DamageValueText = null;
		private UnityEngine.UI.Text m_E_DamageValueText = null;
		public Transform uiTransform = null;
	}
}
