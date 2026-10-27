
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_GemTalent : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		/// <summary>
		/// 天赋树上的节点，按 Left 下的 GemTalentItem_xxxxx 静态节点创建
		/// </summary>
		public List<EntityRef<ES_GemTalentItem>> GemTalentItems = new();
		/// <summary>
		/// 当前选中的天赋节点id（GemTalentConfig.Id），0表示未选中
		/// </summary>
		public int SelectGemTalentId;
		/// <summary>
		/// 区域遮罩节点，按区域id-1索引
		/// </summary>
		public RectTransform[] AreaLockRectTransforms = new RectTransform[3];
		/// <summary>
		/// 区域遮罩上的解锁条件文本（累计N宝石点数解锁）
		/// </summary>
		public Text[] AreaLockNameTexts = new Text[3];

		public UnityEngine.UI.Button E_ReturnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ReturnButton == null )
     			{
		    		this.m_E_ReturnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_Return");
     			}
     			return this.m_E_ReturnButton;
     		}
     	}

		public UnityEngine.UI.Image E_ReturnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ReturnImage == null )
     			{
		    		this.m_E_ReturnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_Return");
     			}
     			return this.m_E_ReturnImage;
     		}
     	}

		public UnityEngine.RectTransform EG_AreaLock_1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_AreaLock_1RectTransform == null )
     			{
		    		this.m_EG_AreaLock_1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_AreaLock_1");
     			}
     			return this.m_EG_AreaLock_1RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_AreaLock_2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_AreaLock_2RectTransform == null )
     			{
		    		this.m_EG_AreaLock_2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_AreaLock_2");
     			}
     			return this.m_EG_AreaLock_2RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_AreaLock_3RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_AreaLock_3RectTransform == null )
     			{
		    		this.m_EG_AreaLock_3RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_AreaLock_3");
     			}
     			return this.m_EG_AreaLock_3RectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_AllPointText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AllPointText == null )
     			{
		    		this.m_E_AllPointText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/E_AllPoint");
     			}
     			return this.m_E_AllPointText;
     		}
     	}

		public UnityEngine.UI.Text E_LeftPointText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LeftPointText == null )
     			{
		    		this.m_E_LeftPointText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/E_LeftPoint");
     			}
     			return this.m_E_LeftPointText;
     		}
     	}

		public UnityEngine.UI.Image E_GemTalentIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GemTalentIconImage == null )
     			{
		    		this.m_E_GemTalentIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_GemTalentIcon");
     			}
     			return this.m_E_GemTalentIconImage;
     		}
     	}

		public UnityEngine.UI.Text E_GemTalentNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GemTalentNameText == null )
     			{
		    		this.m_E_GemTalentNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_GemTalentName");
     			}
     			return this.m_E_GemTalentNameText;
     		}
     	}

		public UnityEngine.UI.Text E_GemTalentDescText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GemTalentDescText == null )
     			{
		    		this.m_E_GemTalentDescText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_GemTalentDesc");
     			}
     			return this.m_E_GemTalentDescText;
     		}
     	}

		public UnityEngine.UI.Text E_CostPointText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CostPointText == null )
     			{
		    		this.m_E_CostPointText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_CostPoint");
     			}
     			return this.m_E_CostPointText;
     		}
     	}

		public UnityEngine.UI.Button E_ActiveGemTalentButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ActiveGemTalentButton == null )
     			{
		    		this.m_E_ActiveGemTalentButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ActiveGemTalent");
     			}
     			return this.m_E_ActiveGemTalentButton;
     		}
     	}

		public UnityEngine.UI.Image E_ActiveGemTalentImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ActiveGemTalentImage == null )
     			{
		    		this.m_E_ActiveGemTalentImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ActiveGemTalent");
     			}
     			return this.m_E_ActiveGemTalentImage;
     		}
     	}

		public UnityEngine.UI.Button E_ReSetButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ReSetButton == null )
     			{
		    		this.m_E_ReSetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ReSet");
     			}
     			return this.m_E_ReSetButton;
     		}
     	}

		public UnityEngine.UI.Image E_ReSetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ReSetImage == null )
     			{
		    		this.m_E_ReSetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ReSet");
     			}
     			return this.m_E_ReSetImage;
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
			this.m_E_ReturnButton = null;
			this.m_E_ReturnImage = null;
			this.m_EG_AreaLock_1RectTransform = null;
			this.m_EG_AreaLock_2RectTransform = null;
			this.m_EG_AreaLock_3RectTransform = null;
			this.m_E_AllPointText = null;
			this.m_E_LeftPointText = null;
			this.m_E_GemTalentIconImage = null;
			this.m_E_GemTalentNameText = null;
			this.m_E_GemTalentDescText = null;
			this.m_E_CostPointText = null;
			this.m_E_ActiveGemTalentButton = null;
			this.m_E_ActiveGemTalentImage = null;
			this.m_E_ReSetButton = null;
			this.m_E_ReSetImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_ReturnButton = null;
		private UnityEngine.UI.Image m_E_ReturnImage = null;
		private UnityEngine.RectTransform m_EG_AreaLock_1RectTransform = null;
		private UnityEngine.RectTransform m_EG_AreaLock_2RectTransform = null;
		private UnityEngine.RectTransform m_EG_AreaLock_3RectTransform = null;
		private UnityEngine.UI.Text m_E_AllPointText = null;
		private UnityEngine.UI.Text m_E_LeftPointText = null;
		private UnityEngine.UI.Image m_E_GemTalentIconImage = null;
		private UnityEngine.UI.Text m_E_GemTalentNameText = null;
		private UnityEngine.UI.Text m_E_GemTalentDescText = null;
		private UnityEngine.UI.Text m_E_CostPointText = null;
		private UnityEngine.UI.Button m_E_ActiveGemTalentButton = null;
		private UnityEngine.UI.Image m_E_ActiveGemTalentImage = null;
		private UnityEngine.UI.Button m_E_ReSetButton = null;
		private UnityEngine.UI.Image m_E_ReSetImage = null;
		public Transform uiTransform = null;
	}
}
