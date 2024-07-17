using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_BattleEnter : Entity,IAwake<Transform>,IDestroy 
	{
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

		public Button E_ButtonEnterButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonEnterButton == null )
     			{
		    		this.m_E_ButtonEnterButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonEnter");
     			}
     			return this.m_E_ButtonEnterButton;
     		}
     	}

		public Image E_ButtonEnterImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonEnterImage == null )
     			{
		    		this.m_E_ButtonEnterImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonEnter");
     			}
     			return this.m_E_ButtonEnterImage;
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
			this.m_es_rewardlist = null;
			this.m_E_ButtonEnterButton = null;
			this.m_E_ButtonEnterImage = null;
			this.uiTransform = null;
		}

		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private Button m_E_ButtonEnterButton = null;
		private Image m_E_ButtonEnterImage = null;
		public Transform uiTransform = null;
	}
}
