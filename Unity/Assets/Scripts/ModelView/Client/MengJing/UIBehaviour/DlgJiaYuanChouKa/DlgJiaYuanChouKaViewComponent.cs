using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgJiaYuanChouKa))]
	[EnableMethod]
	public  class DlgJiaYuanChouKaViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_Btn_ChouKaOneButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ChouKaOneButton == null )
     			{
		    		this.m_E_Btn_ChouKaOneButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_ChouKaOne");
     			}
     			return this.m_E_Btn_ChouKaOneButton;
     		}
     	}

		public Image E_Btn_ChouKaOneImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ChouKaOneImage == null )
     			{
		    		this.m_E_Btn_ChouKaOneImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_ChouKaOne");
     			}
     			return this.m_E_Btn_ChouKaOneImage;
     		}
     	}

		public Button E_Btn_ChouKaTenButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ChouKaTenButton == null )
     			{
		    		this.m_E_Btn_ChouKaTenButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_ChouKaTen");
     			}
     			return this.m_E_Btn_ChouKaTenButton;
     		}
     	}

		public Image E_Btn_ChouKaTenImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ChouKaTenImage == null )
     			{
		    		this.m_E_Btn_ChouKaTenImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_ChouKaTen");
     			}
     			return this.m_E_Btn_ChouKaTenImage;
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

		public void DestroyWidget()
		{
			this.m_E_Btn_ChouKaOneButton = null;
			this.m_E_Btn_ChouKaOneImage = null;
			this.m_E_Btn_ChouKaTenButton = null;
			this.m_E_Btn_ChouKaTenImage = null;
			this.m_es_rewardlist = null;
			this.uiTransform = null;
		}

		private Button m_E_Btn_ChouKaOneButton = null;
		private Image m_E_Btn_ChouKaOneImage = null;
		private Button m_E_Btn_ChouKaTenButton = null;
		private Image m_E_Btn_ChouKaTenImage = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		public Transform uiTransform = null;
	}
}
