using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgBattleRecruit))]
	[EnableMethod]
	public  class DlgBattleRecruitViewComponent : Entity,IAwake,IDestroy 
	{
		public Text E_CurrentNumberTextText
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
		    		this.m_E_CurrentNumberTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_CurrentNumberText");
     			}
     			return this.m_E_CurrentNumberTextText;
     		}
     	}

		public LoopHorizontalScrollRect E_BattleRecruitItemsLoopHorizontalScrollRect
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
		    		this.m_E_BattleRecruitItemsLoopHorizontalScrollRect = UIFindHelper.FindDeepChild<LoopHorizontalScrollRect>(this.uiTransform.gameObject,"E_BattleRecruitItems");
     			}
     			return this.m_E_BattleRecruitItemsLoopHorizontalScrollRect;
     		}
     	}

		public Button E_Img_buttonButton
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
		    		this.m_E_Img_buttonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Img_button");
     			}
     			return this.m_E_Img_buttonButton;
     		}
     	}

		public Image E_Img_buttonImage
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
		    		this.m_E_Img_buttonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Img_button");
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

		private Text m_E_CurrentNumberTextText = null;
		private LoopHorizontalScrollRect m_E_BattleRecruitItemsLoopHorizontalScrollRect = null;
		private Button m_E_Img_buttonButton = null;
		private Image m_E_Img_buttonImage = null;
		public Transform uiTransform = null;
	}
}
