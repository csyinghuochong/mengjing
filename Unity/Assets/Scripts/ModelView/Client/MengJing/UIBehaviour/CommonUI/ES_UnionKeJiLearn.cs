
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_UnionKeJiLearn : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.LoopVerticalScrollRect E_UnionKeJiLearnItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UnionKeJiLearnItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_UnionKeJiLearnItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_UnionKeJiLearnItems");
     			}
     			return this.m_E_UnionKeJiLearnItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_HeadImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HeadImgImage == null )
     			{
		    		this.m_E_HeadImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_HeadImg");
     			}
     			return this.m_E_HeadImgImage;
     		}
     	}

		public UnityEngine.UI.Text E_NameTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NameTextText == null )
     			{
		    		this.m_E_NameTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_NameText");
     			}
     			return this.m_E_NameTextText;
     		}
     	}

		public UnityEngine.UI.Text E_LvTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LvTextText == null )
     			{
		    		this.m_E_LvTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_LvText");
     			}
     			return this.m_E_LvTextText;
     		}
     	}

		public ES_CostList ES_CostList
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_costlist == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CostList");
		    	   this.m_es_costlist = this.AddChild<ES_CostList,Transform>(subTrans);
     			}
     			return this.m_es_costlist;
     		}
     	}

		public UnityEngine.UI.Button E_StartBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StartBtnButton == null )
     			{
		    		this.m_E_StartBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_StartBtn");
     			}
     			return this.m_E_StartBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_StartBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StartBtnImage == null )
     			{
		    		this.m_E_StartBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_StartBtn");
     			}
     			return this.m_E_StartBtnImage;
     		}
     	}

		public UnityEngine.UI.Text E_AttributeTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AttributeTextText == null )
     			{
		    		this.m_E_AttributeTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_AttributeText");
     			}
     			return this.m_E_AttributeTextText;
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
			this.m_E_UnionKeJiLearnItemsLoopVerticalScrollRect = null;
			this.m_E_HeadImgImage = null;
			this.m_E_NameTextText = null;
			this.m_E_LvTextText = null;
			this.m_es_costlist = null;
			this.m_E_StartBtnButton = null;
			this.m_E_StartBtnImage = null;
			this.m_E_AttributeTextText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_E_UnionKeJiLearnItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Image m_E_HeadImgImage = null;
		private UnityEngine.UI.Text m_E_NameTextText = null;
		private UnityEngine.UI.Text m_E_LvTextText = null;
		private EntityRef<ES_CostList> m_es_costlist = null;
		private UnityEngine.UI.Button m_E_StartBtnButton = null;
		private UnityEngine.UI.Image m_E_StartBtnImage = null;
		private UnityEngine.UI.Text m_E_AttributeTextText = null;
		public Transform uiTransform = null;
	}
}
