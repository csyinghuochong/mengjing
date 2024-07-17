using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_UnionListItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_UnionListItem>
	{
		public UnionListItem UnionListItem;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_UnionListItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Text E_Text_LevelText
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
     				if( this.m_E_Text_LevelText == null )
     				{
		    			this.m_E_Text_LevelText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Level");
     				}
     				return this.m_E_Text_LevelText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Level");
     			}
     		}
     	}

		public Text E_Text_NameText
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
     				if( this.m_E_Text_NameText == null )
     				{
		    			this.m_E_Text_NameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Name");
     				}
     				return this.m_E_Text_NameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Name");
     			}
     		}
     	}

		public Text E_Text_NumberText
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
     				if( this.m_E_Text_NumberText == null )
     				{
		    			this.m_E_Text_NumberText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Number");
     				}
     				return this.m_E_Text_NumberText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Number");
     			}
     		}
     	}

		public Text E_Text_RequestText
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
     				if( this.m_E_Text_RequestText == null )
     				{
		    			this.m_E_Text_RequestText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Request");
     				}
     				return this.m_E_Text_RequestText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Request");
     			}
     		}
     	}

		public Button E_ButtonApplyButton
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
     				if( this.m_E_ButtonApplyButton == null )
     				{
		    			this.m_E_ButtonApplyButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonApply");
     				}
     				return this.m_E_ButtonApplyButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonApply");
     			}
     		}
     	}

		public Image E_ButtonApplyImage
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
     				if( this.m_E_ButtonApplyImage == null )
     				{
		    			this.m_E_ButtonApplyImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonApply");
     				}
     				return this.m_E_ButtonApplyImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonApply");
     			}
     		}
     	}

		public Text E_Text_LeaderText
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
     				if( this.m_E_Text_LeaderText == null )
     				{
		    			this.m_E_Text_LeaderText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Leader");
     				}
     				return this.m_E_Text_LeaderText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Leader");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Text_LevelText = null;
			this.m_E_Text_NameText = null;
			this.m_E_Text_NumberText = null;
			this.m_E_Text_RequestText = null;
			this.m_E_ButtonApplyButton = null;
			this.m_E_ButtonApplyImage = null;
			this.m_E_Text_LeaderText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Text m_E_Text_LevelText = null;
		private Text m_E_Text_NameText = null;
		private Text m_E_Text_NumberText = null;
		private Text m_E_Text_RequestText = null;
		private Button m_E_ButtonApplyButton = null;
		private Image m_E_ButtonApplyImage = null;
		private Text m_E_Text_LeaderText = null;
		public Transform uiTransform = null;
	}
}
