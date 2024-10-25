
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_PetMeleeItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_PetMeleeItem> 
	{
		public RolePetInfo RolePetInfo;
		public int CostMoLi = 90;// 魔力消耗 (暂时，之后根据公式读表)
		public long CD = 3000;// 刷新时间 (暂时，之后根据公式读表)
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

		public UnityEngine.EventSystems.EventTrigger E_IconEventTrigger
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
     				if( this.m_E_IconEventTrigger == null )
     				{
		    			this.m_E_IconEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"E_Icon");
     				}
     				return this.m_E_IconEventTrigger;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"E_Icon");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_CDImage
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
     				if( this.m_E_CDImage == null )
     				{
		    			this.m_E_CDImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_CD");
     				}
     				return this.m_E_CDImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_CD");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_MoLiText = null;
			this.m_E_IconImage = null;
			this.m_E_IconEventTrigger = null;
			this.m_E_CDImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Text m_E_MoLiText = null;
		private UnityEngine.UI.Image m_E_IconImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_IconEventTrigger = null;
		private UnityEngine.UI.Image m_E_CDImage = null;
		public Transform uiTransform = null;
	}
}
