
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ZuoQiShow : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public Dictionary<int, EntityRef<Scroll_Item_ZuoQiShowItem>> ScrollItemZuoQiShowItems = new();
		public List<ZuoQiShowConfig> ShowZuoQiShowConfigs = new();
		public ZuoQiShowConfig ZuoQiConfig;
		public List<string> AssetList { get; set; } = new();
		
		public UnityEngine.UI.ScrollRect E_ZuoQiShowItemsScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ZuoQiShowItemsScrollRect == null )
     			{
		    		this.m_E_ZuoQiShowItemsScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.ScrollRect>(this.uiTransform.gameObject,"Left/E_ZuoQiShowItems");
     			}
     			return this.m_E_ZuoQiShowItemsScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_ZuoQiShowItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ZuoQiShowItemsImage == null )
     			{
		    		this.m_E_ZuoQiShowItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_ZuoQiShowItems");
     			}
     			return this.m_E_ZuoQiShowItemsImage;
     		}
     	}

		public ES_ModelShow ES_ModelShow
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_ModelShow es = this.m_es_modelshow;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_ModelShow");
		    	   this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow;
     		}
     	}

		public UnityEngine.UI.Text E_TextNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextNameText == null )
     			{
		    		this.m_E_TextNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_TextName");
     			}
     			return this.m_E_TextNameText;
     		}
     	}

		public UnityEngine.UI.Text E_DesText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DesText == null )
     			{
		    		this.m_E_DesText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Des");
     			}
     			return this.m_E_DesText;
     		}
     	}

		public UnityEngine.UI.Text E_LabProDesText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LabProDesText == null )
     			{
		    		this.m_E_LabProDesText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_LabProDes");
     			}
     			return this.m_E_LabProDesText;
     		}
     	}

		public UnityEngine.UI.Text E_LabDesText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LabDesText == null )
     			{
		    		this.m_E_LabDesText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_LabDes");
     			}
     			return this.m_E_LabDesText;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_LaiYuanText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_LaiYuanText == null )
     			{
		    		this.m_E_Lab_LaiYuanText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Lab_LaiYuan");
     			}
     			return this.m_E_Lab_LaiYuanText;
     		}
     	}

		public UnityEngine.UI.Text E_YesText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_YesText == null )
     			{
		    		this.m_E_YesText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Yes");
     			}
     			return this.m_E_YesText;
     		}
     	}

		public UnityEngine.UI.Text E_NoText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NoText == null )
     			{
		    		this.m_E_NoText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_No");
     			}
     			return this.m_E_NoText;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonFightButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonFightButton == null )
     			{
		    		this.m_E_ButtonFightButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ButtonFight");
     			}
     			return this.m_E_ButtonFightButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonFightImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonFightImage == null )
     			{
		    		this.m_E_ButtonFightImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ButtonFight");
     			}
     			return this.m_E_ButtonFightImage;
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
			this.m_E_ZuoQiShowItemsScrollRect = null;
			this.m_E_ZuoQiShowItemsImage = null;
			this.m_es_modelshow = null;
			this.m_E_TextNameText = null;
			this.m_E_DesText = null;
			this.m_E_LabProDesText = null;
			this.m_E_LabDesText = null;
			this.m_E_Lab_LaiYuanText = null;
			this.m_E_YesText = null;
			this.m_E_NoText = null;
			this.m_E_ButtonFightButton = null;
			this.m_E_ButtonFightImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.ScrollRect m_E_ZuoQiShowItemsScrollRect = null;
		private UnityEngine.UI.Image m_E_ZuoQiShowItemsImage = null;
		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private UnityEngine.UI.Text m_E_TextNameText = null;
		private UnityEngine.UI.Text m_E_DesText = null;
		private UnityEngine.UI.Text m_E_LabProDesText = null;
		private UnityEngine.UI.Text m_E_LabDesText = null;
		private UnityEngine.UI.Text m_E_Lab_LaiYuanText = null;
		private UnityEngine.UI.Text m_E_YesText = null;
		private UnityEngine.UI.Text m_E_NoText = null;
		private UnityEngine.UI.Button m_E_ButtonFightButton = null;
		private UnityEngine.UI.Image m_E_ButtonFightImage = null;
		public Transform uiTransform = null;
	}
}
