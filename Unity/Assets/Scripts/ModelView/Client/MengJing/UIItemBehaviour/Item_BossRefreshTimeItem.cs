using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_BossRefreshTimeItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_BossRefreshTimeItem>
	{
		public long RefreshTime;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_BossRefreshTimeItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Image E_PhotoImage
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
     				if( this.m_E_PhotoImage == null )
     				{
		    			this.m_E_PhotoImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Photo");
     				}
     				return this.m_E_PhotoImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Photo");
     			}
     		}
     	}

		public Text E_NameText
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
     				if( this.m_E_NameText == null )
     				{
		    			this.m_E_NameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Name");
     				}
     				return this.m_E_NameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Name");
     			}
     		}
     	}

		public Text E_TimeText
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
     				if( this.m_E_TimeText == null )
     				{
		    			this.m_E_TimeText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Time");
     				}
     				return this.m_E_TimeText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Time");
     			}
     		}
     	}

		public Text E_MapText
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
     				if( this.m_E_MapText == null )
     				{
		    			this.m_E_MapText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Map");
     				}
     				return this.m_E_MapText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Map");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_PhotoImage = null;
			this.m_E_NameText = null;
			this.m_E_TimeText = null;
			this.m_E_MapText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Image m_E_PhotoImage = null;
		private Text m_E_NameText = null;
		private Text m_E_TimeText = null;
		private Text m_E_MapText = null;
		public Transform uiTransform = null;
	}
}
