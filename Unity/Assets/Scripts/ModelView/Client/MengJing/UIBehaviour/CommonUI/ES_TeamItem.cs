
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_TeamItem : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public TeamPlayerInfo TeamPlayerInfo;
		
		public UnityEngine.RectTransform EG_RootShowSetRectTransform
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
		    		this.m_EG_RootShowSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_RootShowSet");
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
     			if( this.m_es_modelshow == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_ModelShow");
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
		    		this.m_E_TextNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextName");
     			}
     			return this.m_E_TextNameText;
     		}
     	}

		public UnityEngine.UI.Text E_TextLevelText
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
		    		this.m_E_TextLevelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextLevel");
     			}
     			return this.m_E_TextLevelText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_Wait_2Text
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
		    		this.m_E_Text_Wait_2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Wait_2");
     			}
     			return this.m_E_Text_Wait_2Text;
     		}
     	}

		public UnityEngine.UI.Text E_TextCombatText
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
		    		this.m_E_TextCombatText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextCombat");
     			}
     			return this.m_E_TextCombatText;
     		}
     	}

		public UnityEngine.UI.Text E_TextOccText
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
		    		this.m_E_TextOccText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextOcc");
     			}
     			return this.m_E_TextOccText;
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
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_RootShowSetRectTransform = null;
		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private UnityEngine.UI.Text m_E_TextNameText = null;
		private UnityEngine.UI.Text m_E_TextLevelText = null;
		private UnityEngine.UI.Text m_E_Text_Wait_2Text = null;
		private UnityEngine.UI.Text m_E_TextCombatText = null;
		private UnityEngine.UI.Text m_E_TextOccText = null;
		public Transform uiTransform = null;
	}
}
