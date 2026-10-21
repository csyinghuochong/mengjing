
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_SkillLongYin : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public List<EntityRef<ES_SkillLongYinItem>> Items = new();
		public int SelectLongYinId;

		public UnityEngine.RectTransform EG_LongYinContentRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_LongYinContentRectTransform == null )
     			{
		    		this.m_EG_LongYinContentRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/EG_LongYinContent");
     			}
     			return this.m_EG_LongYinContentRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_LongYinRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_LongYinRectTransform == null )
     			{
		    		this.m_EG_LongYinRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_LongYin");
     			}
     			return this.m_EG_LongYinRectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_LongYinIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LongYinIconImage == null )
     			{
		    		this.m_E_LongYinIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LongYin/E_LongYinIcon");
     			}
     			return this.m_E_LongYinIconImage;
     		}
     	}

		public UnityEngine.UI.Text E_LongYinNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LongYinNameText == null )
     			{
		    		this.m_E_LongYinNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_LongYin/E_LongYinName");
     			}
     			return this.m_E_LongYinNameText;
     		}
     	}

		public UnityEngine.UI.Text E_LongYinDescText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LongYinDescText == null )
     			{
		    		this.m_E_LongYinDescText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_LongYin/E_LongYinDesc");
     			}
     			return this.m_E_LongYinDescText;
     		}
     	}

		public UnityEngine.UI.Text E_LongYinLevelText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LongYinLevelText == null )
     			{
		    		this.m_E_LongYinLevelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_LongYin/E_LongYinLevel");
     			}
     			return this.m_E_LongYinLevelText;
     		}
     	}

		public UnityEngine.UI.Text E_NeedKillBossText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NeedKillBossText == null )
     			{
		    		this.m_E_NeedKillBossText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_LongYin/E_NeedKillBoss");
     			}
     			return this.m_E_NeedKillBossText;
     		}
     	}

		public UnityEngine.UI.Button E_ActiveLongYinButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ActiveLongYinButton == null )
     			{
		    		this.m_E_ActiveLongYinButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_LongYin/E_ActiveLongYin");
     			}
     			return this.m_E_ActiveLongYinButton;
     		}
     	}

		public UnityEngine.UI.Image E_ActiveLongYinImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ActiveLongYinImage == null )
     			{
		    		this.m_E_ActiveLongYinImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LongYin/E_ActiveLongYin");
     			}
     			return this.m_E_ActiveLongYinImage;
     		}
     	}

		public UnityEngine.UI.Text E_LongYinPointText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LongYinPointText == null )
     			{
		    		this.m_E_LongYinPointText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_LongYin/E_LongYinPoint");
     			}
     			return this.m_E_LongYinPointText;
     		}
     	}

		public UnityEngine.UI.Button E_ReSetTianFuButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ReSetTianFuButton == null )
     			{
		    		this.m_E_ReSetTianFuButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_LongYin/E_ReSetTianFu");
     			}
     			return this.m_E_ReSetTianFuButton;
     		}
     	}

		public UnityEngine.UI.Image E_ReSetTianFuImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ReSetTianFuImage == null )
     			{
		    		this.m_E_ReSetTianFuImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LongYin/E_ReSetTianFu");
     			}
     			return this.m_E_ReSetTianFuImage;
     		}
     	}

		public UnityEngine.RectTransform EG_LongYinNumRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_LongYinNumRectTransform == null )
     			{
		    		this.m_EG_LongYinNumRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_LongYinNum");
     			}
     			return this.m_EG_LongYinNumRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_LongYinNumNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LongYinNumNameText == null )
     			{
		    		this.m_E_LongYinNumNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_LongYinNum/E_LongYinNumName");
     			}
     			return this.m_E_LongYinNumNameText;
     		}
     	}

		public UnityEngine.UI.Text E_LongYinNumDescText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LongYinNumDescText == null )
     			{
		    		this.m_E_LongYinNumDescText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_LongYinNum/E_LongYinNumDesc");
     			}
     			return this.m_E_LongYinNumDescText;
     		}
     	}

		public UnityEngine.UI.Button E_ActiveLongYinNumButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ActiveLongYinNumButton == null )
     			{
		    		this.m_E_ActiveLongYinNumButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_LongYinNum/E_ActiveLongYinNum");
     			}
     			return this.m_E_ActiveLongYinNumButton;
     		}
     	}

		public UnityEngine.UI.Image E_ActiveLongYinNumImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ActiveLongYinNumImage == null )
     			{
		    		this.m_E_ActiveLongYinNumImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_LongYinNum/E_ActiveLongYinNum");
     			}
     			return this.m_E_ActiveLongYinNumImage;
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
			this.m_EG_LongYinContentRectTransform = null;
			this.m_EG_LongYinRectTransform = null;
			this.m_E_LongYinIconImage = null;
			this.m_E_LongYinNameText = null;
			this.m_E_LongYinDescText = null;
			this.m_E_LongYinLevelText = null;
			this.m_E_NeedKillBossText = null;
			this.m_E_ActiveLongYinButton = null;
			this.m_E_ActiveLongYinImage = null;
			this.m_E_LongYinPointText = null;
			this.m_E_ReSetTianFuButton = null;
			this.m_E_ReSetTianFuImage = null;
			this.m_EG_LongYinNumRectTransform = null;
			this.m_E_LongYinNumNameText = null;
			this.m_E_LongYinNumDescText = null;
			this.m_E_ActiveLongYinNumButton = null;
			this.m_E_ActiveLongYinNumImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_LongYinContentRectTransform = null;
		private UnityEngine.RectTransform m_EG_LongYinRectTransform = null;
		private UnityEngine.UI.Image m_E_LongYinIconImage = null;
		private UnityEngine.UI.Text m_E_LongYinNameText = null;
		private UnityEngine.UI.Text m_E_LongYinDescText = null;
		private UnityEngine.UI.Text m_E_LongYinLevelText = null;
		private UnityEngine.UI.Text m_E_NeedKillBossText = null;
		private UnityEngine.UI.Button m_E_ActiveLongYinButton = null;
		private UnityEngine.UI.Image m_E_ActiveLongYinImage = null;
		private UnityEngine.UI.Text m_E_LongYinPointText = null;
		private UnityEngine.UI.Button m_E_ReSetTianFuButton = null;
		private UnityEngine.UI.Image m_E_ReSetTianFuImage = null;
		private UnityEngine.RectTransform m_EG_LongYinNumRectTransform = null;
		private UnityEngine.UI.Text m_E_LongYinNumNameText = null;
		private UnityEngine.UI.Text m_E_LongYinNumDescText = null;
		private UnityEngine.UI.Button m_E_ActiveLongYinNumButton = null;
		private UnityEngine.UI.Image m_E_ActiveLongYinNumImage = null;
		public Transform uiTransform = null;
	}
}
