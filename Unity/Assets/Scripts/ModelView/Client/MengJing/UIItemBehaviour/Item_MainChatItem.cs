using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class Scroll_Item_MainChatItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_MainChatItem>
	{
		public ChatInfo ChatInfo;
		public GameObject[] TitleList = new GameObject[ChannelEnum.Number];
		public bool UpdateHeight;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_MainChatItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Text E_ChatTextText
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
     				if( this.m_E_ChatTextText == null )
     				{
		    			this.m_E_ChatTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_ChatText");
     				}
     				return this.m_E_ChatTextText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_ChatText");
     			}
     		}
     	}

		public Button E_ClickButton
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
		    			this.m_E_ClickButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Click");
     				}
     				return this.m_E_ClickButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Click");
     			}
     		}
     	}

		public Image E_ClickImage
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
		    			this.m_E_ClickImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Click");
     				}
     				return this.m_E_ClickImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Click");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ChatTextText = null;
			this.m_E_ClickButton = null;
			this.m_E_ClickImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Text m_E_ChatTextText = null;
		private Button m_E_ClickButton = null;
		private Image m_E_ClickImage = null;
		public Transform uiTransform = null;
	}
}
