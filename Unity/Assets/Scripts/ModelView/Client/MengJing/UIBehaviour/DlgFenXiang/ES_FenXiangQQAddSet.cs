using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_FenXiangQQAddSet : Entity,IAwake<Transform>,IDestroy 
	{
		public Button E_Button_AddQQButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_AddQQButton == null )
     			{
		    		this.m_E_Button_AddQQButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"FenXiang_QQ/E_Button_AddQQ");
     			}
     			return this.m_E_Button_AddQQButton;
     		}
     	}

		public Image E_Button_AddQQImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_AddQQImage == null )
     			{
		    		this.m_E_Button_AddQQImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"FenXiang_QQ/E_Button_AddQQ");
     			}
     			return this.m_E_Button_AddQQImage;
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
			this.m_E_Button_AddQQButton = null;
			this.m_E_Button_AddQQImage = null;
			this.m_es_rewardlist = null;
			this.uiTransform = null;
		}

		private Button m_E_Button_AddQQButton = null;
		private Image m_E_Button_AddQQImage = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		public Transform uiTransform = null;
	}
}
