
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgBattleRecruit))]
	[EnableMethod]
	public  class DlgBattleRecruitViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Text E_CurrentNumberTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CurrentNumberTextText == null )
     			{
		    		this.m_E_CurrentNumberTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_CurrentNumberText");
     			}
     			return this.m_E_CurrentNumberTextText;
     		}
     	}

		public UnityEngine.UI.LoopHorizontalScrollRect E_BattleRecruitItemsLoopHorizontalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BattleRecruitItemsLoopHorizontalScrollRect == null )
     			{
		    		this.m_E_BattleRecruitItemsLoopHorizontalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopHorizontalScrollRect>(this.uiTransform.gameObject,"E_BattleRecruitItems");
     			}
     			return this.m_E_BattleRecruitItemsLoopHorizontalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_Img_buttonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_buttonButton == null )
     			{
		    		this.m_E_Img_buttonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Img_button");
     			}
     			return this.m_E_Img_buttonButton;
     		}
     	}

		public UnityEngine.UI.Image E_Img_buttonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_buttonImage == null )
     			{
		    		this.m_E_Img_buttonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Img_button");
     			}
     			return this.m_E_Img_buttonImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_CurrentNumberTextText = null;
			this.m_E_BattleRecruitItemsLoopHorizontalScrollRect = null;
			this.m_E_Img_buttonButton = null;
			this.m_E_Img_buttonImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Text m_E_CurrentNumberTextText = null;
		private UnityEngine.UI.LoopHorizontalScrollRect m_E_BattleRecruitItemsLoopHorizontalScrollRect = null;
		private UnityEngine.UI.Button m_E_Img_buttonButton = null;
		private UnityEngine.UI.Image m_E_Img_buttonImage = null;
		public Transform uiTransform = null;
	}
}
