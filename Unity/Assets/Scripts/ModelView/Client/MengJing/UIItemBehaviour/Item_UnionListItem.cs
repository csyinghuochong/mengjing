using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_UnionListItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_UnionListItem>
	{
		public UnionListItem UnionListItem;
		public Action<UnionListItem> ClickCallback;
		
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
		
		public Button E_ButtonImageDI
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
					if( this.m_E_ButtonImageDI == null )
					{
						this.m_E_ButtonImageDI = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonImageDI");
					}
					return this.m_E_ButtonImageDI;
				}
				else
				{
					return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonImageDI");
				}
			}
		}

		public Transform E_ImageHighLight
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
					if( this.m_E_ImageHighLight == null )
					{
						this.m_E_ImageHighLight = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"E_ImageHighLight");
					}
					return this.m_E_ImageHighLight;
				}
				else
				{
					return UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"E_ImageHighLight");
				}
			}
		}	
        
		public void DestroyWidget()
		{
			this.m_E_Text_LevelText = null;
			this.m_E_Text_NameText = null;
			this.m_E_Text_NumberText = null;
			this.m_E_Text_LeaderText = null;
			this.m_E_ButtonImageDI = null;	
			this.m_E_ImageHighLight = null;	
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Text m_E_Text_LevelText = null;
		private Text m_E_Text_NameText = null;
		private Text m_E_Text_NumberText = null;
		private Text m_E_Text_LeaderText = null;
		private Button m_E_ButtonImageDI = null;
		private Transform m_E_ImageHighLight = null;	
		public Transform uiTransform = null;
	}
}
