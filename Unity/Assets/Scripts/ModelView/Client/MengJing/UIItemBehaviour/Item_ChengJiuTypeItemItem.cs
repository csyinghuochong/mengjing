using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_ChengJiuTypeItemItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_ChengJiuTypeItemItem>
	{
		public Action<int> ClickHandler;
		public int SubTypeId;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_ChengJiuTypeItemItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Button E_Ima_DiButton
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
     				if( this.m_E_Ima_DiButton == null )
     				{
		    			this.m_E_Ima_DiButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Ima_Di");
     				}
     				return this.m_E_Ima_DiButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Ima_Di");
     			}
     		}
     	}

		public Image E_Ima_DiImage
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
     				if( this.m_E_Ima_DiImage == null )
     				{
		    			this.m_E_Ima_DiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Ima_Di");
     				}
     				return this.m_E_Ima_DiImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Ima_Di");
     			}
     		}
     	}

		public Image E_Ima_SelectStatusImage
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
     				if( this.m_E_Ima_SelectStatusImage == null )
     				{
		    			this.m_E_Ima_SelectStatusImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Ima_SelectStatus");
     				}
     				return this.m_E_Ima_SelectStatusImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Ima_SelectStatus");
     			}
     		}
     	}

		public Image E_Ima_ItemQulityImage
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
     				if( this.m_E_Ima_ItemQulityImage == null )
     				{
		    			this.m_E_Ima_ItemQulityImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Ima_ItemQulity");
     				}
     				return this.m_E_Ima_ItemQulityImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Ima_ItemQulity");
     			}
     		}
     	}

		public Image E_Ima_ItemIconImage
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
     				if( this.m_E_Ima_ItemIconImage == null )
     				{
		    			this.m_E_Ima_ItemIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Ima_ItemIcon");
     				}
     				return this.m_E_Ima_ItemIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Ima_ItemIcon");
     			}
     		}
     	}

		public Image E_Ima_ProgressImage
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
     				if( this.m_E_Ima_ProgressImage == null )
     				{
		    			this.m_E_Ima_ProgressImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Ima_Progress");
     				}
     				return this.m_E_Ima_ProgressImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Ima_Progress");
     			}
     		}
     	}

		public Image E_Ima_CompleteTaskImage
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
     				if( this.m_E_Ima_CompleteTaskImage == null )
     				{
		    			this.m_E_Ima_CompleteTaskImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Ima_CompleteTask");
     				}
     				return this.m_E_Ima_CompleteTaskImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Ima_CompleteTask");
     			}
     		}
     	}

		public Text E_Lab_TaskNumText
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
     				if( this.m_E_Lab_TaskNumText == null )
     				{
		    			this.m_E_Lab_TaskNumText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_TaskNum");
     				}
     				return this.m_E_Lab_TaskNumText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_TaskNum");
     			}
     		}
     	}

		public Text E_Lab_TaskNameText
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
     				if( this.m_E_Lab_TaskNameText == null )
     				{
		    			this.m_E_Lab_TaskNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_TaskName");
     				}
     				return this.m_E_Lab_TaskNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_TaskName");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Ima_DiButton = null;
			this.m_E_Ima_DiImage = null;
			this.m_E_Ima_SelectStatusImage = null;
			this.m_E_Ima_ItemQulityImage = null;
			this.m_E_Ima_ItemIconImage = null;
			this.m_E_Ima_ProgressImage = null;
			this.m_E_Ima_CompleteTaskImage = null;
			this.m_E_Lab_TaskNumText = null;
			this.m_E_Lab_TaskNameText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Button m_E_Ima_DiButton = null;
		private Image m_E_Ima_DiImage = null;
		private Image m_E_Ima_SelectStatusImage = null;
		private Image m_E_Ima_ItemQulityImage = null;
		private Image m_E_Ima_ItemIconImage = null;
		private Image m_E_Ima_ProgressImage = null;
		private Image m_E_Ima_CompleteTaskImage = null;
		private Text m_E_Lab_TaskNumText = null;
		private Text m_E_Lab_TaskNameText = null;
		public Transform uiTransform = null;
	}
}
