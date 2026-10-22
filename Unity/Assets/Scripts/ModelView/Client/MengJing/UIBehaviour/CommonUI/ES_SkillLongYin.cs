
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

		public UnityEngine.RectTransform EG_LongYinAwakenRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_LongYinAwakenRectTransform == null )
     			{
		    		this.m_EG_LongYinAwakenRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_LongYinAwaken");
     			}
     			return this.m_EG_LongYinAwakenRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_LongYinAwakenNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LongYinAwakenNameText == null )
     			{
		    		this.m_E_LongYinAwakenNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_LongYinAwaken/E_LongYinAwakenName");
     			}
     			return this.m_E_LongYinAwakenNameText;
     		}
     	}

		public UnityEngine.UI.Text E_LongYinAwakenDescText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LongYinAwakenDescText == null )
     			{
		    		this.m_E_LongYinAwakenDescText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_LongYinAwaken/E_LongYinAwakenDesc");
     			}
     			return this.m_E_LongYinAwakenDescText;
     		}
     	}

		public UnityEngine.UI.Text E_YinAwakenStateText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_YinAwakenStateText == null )
     			{
		    		this.m_E_YinAwakenStateText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_LongYinAwaken/E_YinAwakenState");
     			}
     			return this.m_E_YinAwakenStateText;
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
			this.m_EG_LongYinAwakenRectTransform = null;
			this.m_E_LongYinAwakenNameText = null;
			this.m_E_LongYinAwakenDescText = null;
			this.m_E_YinAwakenStateText = null;
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
		private UnityEngine.RectTransform m_EG_LongYinAwakenRectTransform = null;
		private UnityEngine.UI.Text m_E_LongYinAwakenNameText = null;
		private UnityEngine.UI.Text m_E_LongYinAwakenDescText = null;
		private UnityEngine.UI.Text m_E_YinAwakenStateText = null;
		public Transform uiTransform = null;
	}
}
