
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_PetMeleeItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_PetMeleeItem>
	{
		public RolePetInfo RolePetInfo;
		public int CostMoLi = 90;// 魔力消耗 (暂时，之后根据公式读表)
		public long RefreshTime = 3000;// 刷新时间 (暂时，之后根据公式读表)
		public long EndTime;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_PetMeleeItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Image E_IconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_IconImage == null )
     				{
		    			this.m_E_IconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Icon");
     				}
     				return this.m_E_IconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Icon");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_MoLiText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_MoLiText == null )
     				{
		    			this.m_E_MoLiText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_MoLi");
     				}
     				return this.m_E_MoLiText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_MoLi");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_ClickButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ClickButton == null )
     				{
		    			this.m_E_ClickButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Click");
     				}
     				return this.m_E_ClickButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Click");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ClickImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ClickImage == null )
     				{
		    			this.m_E_ClickImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Click");
     				}
     				return this.m_E_ClickImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Click");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_IconImage = null;
			this.m_E_MoLiText = null;
			this.m_E_ClickButton = null;
			this.m_E_ClickImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Image m_E_IconImage = null;
		private UnityEngine.UI.Text m_E_MoLiText = null;
		private UnityEngine.UI.Button m_E_ClickButton = null;
		private UnityEngine.UI.Image m_E_ClickImage = null;
		public Transform uiTransform = null;
	}
}
