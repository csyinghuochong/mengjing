
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_RoleXiLianShow : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.Text E_Text_TotalNumberText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_TotalNumberText == null )
     			{
		    		this.m_E_Text_TotalNumberText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_TotalNumber");
     			}
     			return this.m_E_Text_TotalNumberText;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_XiLianNumRewardButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_XiLianNumRewardButton == null )
     			{
		    		this.m_E_Btn_XiLianNumRewardButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_XiLianNumReward");
     			}
     			return this.m_E_Btn_XiLianNumRewardButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_XiLianNumRewardImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_XiLianNumRewardImage == null )
     			{
		    		this.m_E_Btn_XiLianNumRewardImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_XiLianNumReward");
     			}
     			return this.m_E_Btn_XiLianNumRewardImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_XiLianExplainButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_XiLianExplainButton == null )
     			{
		    		this.m_E_Btn_XiLianExplainButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_XiLianExplain");
     			}
     			return this.m_E_Btn_XiLianExplainButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_XiLianExplainImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_XiLianExplainImage == null )
     			{
		    		this.m_E_Btn_XiLianExplainImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_XiLianExplain");
     			}
     			return this.m_E_Btn_XiLianExplainImage;
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
			this.m_E_Text_TotalNumberText = null;
			this.m_E_Btn_XiLianNumRewardButton = null;
			this.m_E_Btn_XiLianNumRewardImage = null;
			this.m_E_Btn_XiLianExplainButton = null;
			this.m_E_Btn_XiLianExplainImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Text m_E_Text_TotalNumberText = null;
		private UnityEngine.UI.Button m_E_Btn_XiLianNumRewardButton = null;
		private UnityEngine.UI.Image m_E_Btn_XiLianNumRewardImage = null;
		private UnityEngine.UI.Button m_E_Btn_XiLianExplainButton = null;
		private UnityEngine.UI.Image m_E_Btn_XiLianExplainImage = null;
		public Transform uiTransform = null;
	}
}
