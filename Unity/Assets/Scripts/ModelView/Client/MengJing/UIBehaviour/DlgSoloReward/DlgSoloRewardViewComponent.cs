using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgSoloReward))]
	[EnableMethod]
	public  class DlgSoloRewardViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_Btn_ReturnButton
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
		    		this.m_E_Btn_ReturnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_Return");
     			}
     			return this.m_E_Btn_ReturnButton;
     		}
     	}

		public Image E_Btn_ReturnImage
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
		    		this.m_E_Btn_ReturnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_Return");
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
     		}
     	}

		public Text E_Text_CengText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_CengText == null )
     			{
		    		this.m_E_Text_CengText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Ceng");
     			}
     			return this.m_E_Text_CengText;
     		}
     	}

		public Text E_Text_ReturnTimeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_ReturnTimeText == null )
     			{
		    		this.m_E_Text_ReturnTimeText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_ReturnTime");
     			}
     			return this.m_E_Text_ReturnTimeText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Btn_ReturnButton = null;
			this.m_E_Btn_ReturnImage = null;
			this.m_es_rewardlist = null;
			this.m_E_Text_CengText = null;
			this.m_E_Text_ReturnTimeText = null;
			this.uiTransform = null;
		}

		private Button m_E_Btn_ReturnButton = null;
		private Image m_E_Btn_ReturnImage = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private Text m_E_Text_CengText = null;
		private Text m_E_Text_ReturnTimeText = null;
		public Transform uiTransform = null;
	}
}
