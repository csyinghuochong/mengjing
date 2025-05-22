
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgTowerFightReward))]
	[EnableMethod]
	public  class DlgTowerFightRewardViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_Btn_ReturnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ReturnButton == null )
     			{
		    		this.m_E_Btn_ReturnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Btn_Return");
     			}
     			return this.m_E_Btn_ReturnButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ReturnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ReturnImage == null )
     			{
		    		this.m_E_Btn_ReturnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Btn_Return");
     			}
     			return this.m_E_Btn_ReturnImage;
     		}
     	}

		public ES_RewardList ES_RewardList
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_RewardList es = this.m_es_rewardlist;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Center/ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
     		}
     	}

		public UnityEngine.UI.Text E_Text_ResultText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_ResultText == null )
     			{
		    		this.m_E_Text_ResultText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_Text_Result");
     			}
     			return this.m_E_Text_ResultText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Btn_ReturnButton = null;
			this.m_E_Btn_ReturnImage = null;
			this.m_es_rewardlist = null;
			this.m_E_Text_ResultText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_Btn_ReturnButton = null;
		private UnityEngine.UI.Image m_E_Btn_ReturnImage = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private UnityEngine.UI.Text m_E_Text_ResultText = null;
		public Transform uiTransform = null;
	}
}
