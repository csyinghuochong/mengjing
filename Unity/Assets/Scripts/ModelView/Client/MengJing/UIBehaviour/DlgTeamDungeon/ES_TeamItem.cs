using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_TeamItem : Entity,IAwake<Transform>,IDestroy 
	{
		public TeamPlayerInfo TeamPlayerInfo;
		
		public RectTransform EG_RootShowSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_RootShowSetRectTransform == null )
     			{
		    		this.m_EG_RootShowSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_RootShowSet");
     			}
     			return this.m_EG_RootShowSetRectTransform;
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_ModelShow");
		    	   this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow;
     		}
     	}

		public Text E_TextNameText
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
		    		this.m_E_TextNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextName");
     			}
     			return this.m_E_TextNameText;
     		}
     	}

		public Text E_TextLevelText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextLevelText == null )
     			{
		    		this.m_E_TextLevelText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextLevel");
     			}
     			return this.m_E_TextLevelText;
     		}
     	}

		public Text E_Text_Wait_2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Wait_2Text == null )
     			{
		    		this.m_E_Text_Wait_2Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Wait_2");
     			}
     			return this.m_E_Text_Wait_2Text;
     		}
     	}

		public Text E_TextCombatText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextCombatText == null )
     			{
		    		this.m_E_TextCombatText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextCombat");
     			}
     			return this.m_E_TextCombatText;
     		}
     	}

		public Text E_TextOccText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextOccText == null )
     			{
		    		this.m_E_TextOccText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextOcc");
     			}
     			return this.m_E_TextOccText;
     		}
     	}
		
		public Image E_Image_Add
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_Image_Add == null )
				{
					this.m_E_Image_Add = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Image_Add");
				}
				return this.m_E_Image_Add;
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
			this.m_EG_RootShowSetRectTransform = null;
			this.m_es_modelshow = null;
			this.m_E_TextNameText = null;
			this.m_E_TextLevelText = null;
			this.m_E_Text_Wait_2Text = null;
			this.m_E_TextCombatText = null;
			this.m_E_TextOccText = null;
			this.m_E_Image_Add = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_RootShowSetRectTransform = null;
		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private Text m_E_TextNameText = null;
		private Text m_E_TextLevelText = null;
		private Text m_E_Text_Wait_2Text = null;
		private Text m_E_TextCombatText = null;
		private Text m_E_TextOccText = null;
		private Image m_E_Image_Add = null;
		public Transform uiTransform = null;
	}
}
