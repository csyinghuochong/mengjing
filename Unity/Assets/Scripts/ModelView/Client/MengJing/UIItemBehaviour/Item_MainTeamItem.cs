using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class Scroll_Item_MainTeamItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_MainTeamItem>
	{
		public TeamPlayerInfo TeamPlayerInfo;
		public long UnitId;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_MainTeamItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Image E_ImageHeadImage
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
     				if( this.m_E_ImageHeadImage == null )
     				{
		    			this.m_E_ImageHeadImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageHead");
     				}
     				return this.m_E_ImageHeadImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageHead");
     			}
     		}
     	}

		public Image E_ImageBooldValueImage
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
     				if( this.m_E_ImageBooldValueImage == null )
     				{
		    			this.m_E_ImageBooldValueImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ImageBooldDi/E_ImageBooldValue");
     				}
     				return this.m_E_ImageBooldValueImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ImageBooldDi/E_ImageBooldValue");
     			}
     		}
     	}

		public Text E_PlayerLvText
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
     				if( this.m_E_PlayerLvText == null )
     				{
		    			this.m_E_PlayerLvText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_PlayerLv");
     				}
     				return this.m_E_PlayerLvText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_PlayerLv");
     			}
     		}
     	}

		public Text E_PlayerNameText
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
     				if( this.m_E_PlayerNameText == null )
     				{
		    			this.m_E_PlayerNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_PlayerName");
     				}
     				return this.m_E_PlayerNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_PlayerName");
     			}
     		}
     	}

		public Text E_DamageValueText
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
     				if( this.m_E_DamageValueText == null )
     				{
		    			this.m_E_DamageValueText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_DamageValue");
     				}
     				return this.m_E_DamageValueText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_DamageValue");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageHeadImage = null;
			this.m_E_ImageBooldValueImage = null;
			this.m_E_PlayerLvText = null;
			this.m_E_PlayerNameText = null;
			this.m_E_DamageValueText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Image m_E_ImageHeadImage = null;
		private Image m_E_ImageBooldValueImage = null;
		private Text m_E_PlayerLvText = null;
		private Text m_E_PlayerNameText = null;
		private Text m_E_DamageValueText = null;
		public Transform uiTransform = null;
	}
}
