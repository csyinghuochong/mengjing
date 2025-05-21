
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgFirstWinBossSkill))]
	[EnableMethod]
	public  class DlgFirstWinBossSkillViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_ImageButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageButtonButton == null )
     			{
		    		this.m_E_ImageButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ImageButton");
     			}
     			return this.m_E_ImageButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_ImageButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageButtonImage == null )
     			{
		    		this.m_E_ImageButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageButton");
     			}
     			return this.m_E_ImageButtonImage;
     		}
     	}

		public UnityEngine.RectTransform EG_SkillDescriptionListNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SkillDescriptionListNodeRectTransform == null )
     			{
		    		this.m_EG_SkillDescriptionListNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Center/Scroll View/Viewport/EG_SkillDescriptionListNode");
     			}
     			return this.m_EG_SkillDescriptionListNodeRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_SkillDescriptionItemTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillDescriptionItemTextText == null )
     			{
		    		this.m_E_SkillDescriptionItemTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/Scroll View/Viewport/EG_SkillDescriptionListNode/E_SkillDescriptionItemText");
     			}
     			return this.m_E_SkillDescriptionItemTextText;
     		}
     	}

		public UnityEngine.UI.Text E_BossNameTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BossNameTextText == null )
     			{
		    		this.m_E_BossNameTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_BossNameText");
     			}
     			return this.m_E_BossNameTextText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageButtonButton = null;
			this.m_E_ImageButtonImage = null;
			this.m_EG_SkillDescriptionListNodeRectTransform = null;
			this.m_E_SkillDescriptionItemTextText = null;
			this.m_E_BossNameTextText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_ImageButtonButton = null;
		private UnityEngine.UI.Image m_E_ImageButtonImage = null;
		private UnityEngine.RectTransform m_EG_SkillDescriptionListNodeRectTransform = null;
		private UnityEngine.UI.Text m_E_SkillDescriptionItemTextText = null;
		private UnityEngine.UI.Text m_E_BossNameTextText = null;
		public Transform uiTransform = null;
	}
}
