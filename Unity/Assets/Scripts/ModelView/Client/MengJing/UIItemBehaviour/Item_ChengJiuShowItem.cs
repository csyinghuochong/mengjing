using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_ChengJiuShowItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_ChengJiuShowItem>
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_ChengJiuShowItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Image E_Ima_IconImage
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
     				if( this.m_E_Ima_IconImage == null )
     				{
		    			this.m_E_Ima_IconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Ima_Icon");
     				}
     				return this.m_E_Ima_IconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Ima_Icon");
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

		public Text E_Lab_ProValueText
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
     				if( this.m_E_Lab_ProValueText == null )
     				{
		    			this.m_E_Lab_ProValueText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_ProValue");
     				}
     				return this.m_E_Lab_ProValueText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_ProValue");
     			}
     		}
     	}

		public Text E_Lab_ChengJiuNumText
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
     				if( this.m_E_Lab_ChengJiuNumText == null )
     				{
		    			this.m_E_Lab_ChengJiuNumText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_ChengJiuNum");
     				}
     				return this.m_E_Lab_ChengJiuNumText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_ChengJiuNum");
     			}
     		}
     	}

		public Text E_Lab_TaskDesText
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
     				if( this.m_E_Lab_TaskDesText == null )
     				{
		    			this.m_E_Lab_TaskDesText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_TaskDes");
     				}
     				return this.m_E_Lab_TaskDesText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_TaskDes");
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
			this.m_E_Ima_IconImage = null;
			this.m_E_Ima_CompleteTaskImage = null;
			this.m_E_Lab_ProValueText = null;
			this.m_E_Lab_ChengJiuNumText = null;
			this.m_E_Lab_TaskDesText = null;
			this.m_E_Lab_TaskNameText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Image m_E_Ima_IconImage = null;
		private Image m_E_Ima_CompleteTaskImage = null;
		private Text m_E_Lab_ProValueText = null;
		private Text m_E_Lab_ChengJiuNumText = null;
		private Text m_E_Lab_TaskDesText = null;
		private Text m_E_Lab_TaskNameText = null;
		public Transform uiTransform = null;
	}
}
