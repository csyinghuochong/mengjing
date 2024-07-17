using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_SeasonDayTaskItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_SeasonDayTaskItem>
	{
		public TaskPro TaskPro;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_SeasonDayTaskItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Text E_TaskNameTextText
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
     				if( this.m_E_TaskNameTextText == null )
     				{
		    			this.m_E_TaskNameTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TaskNameText");
     				}
     				return this.m_E_TaskNameTextText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TaskNameText");
     			}
     		}
     	}

		public Text E_TaskDescTextText
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
     				if( this.m_E_TaskDescTextText == null )
     				{
		    			this.m_E_TaskDescTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TaskDescText");
     				}
     				return this.m_E_TaskDescTextText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TaskDescText");
     			}
     		}
     	}

		public Text E_ProgressTextText
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
     				if( this.m_E_ProgressTextText == null )
     				{
		    			this.m_E_ProgressTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_ProgressText");
     				}
     				return this.m_E_ProgressTextText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_ProgressText");
     			}
     		}
     	}

		public Button E_ClickBtnButton
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
     				if( this.m_E_ClickBtnButton == null )
     				{
		    			this.m_E_ClickBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ClickBtn");
     				}
     				return this.m_E_ClickBtnButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ClickBtn");
     			}
     		}
     	}

		public Image E_ClickBtnImage
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
     				if( this.m_E_ClickBtnImage == null )
     				{
		    			this.m_E_ClickBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ClickBtn");
     				}
     				return this.m_E_ClickBtnImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ClickBtn");
     			}
     		}
     	}

		public Image E_AcvityedImgImage
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
     				if( this.m_E_AcvityedImgImage == null )
     				{
		    			this.m_E_AcvityedImgImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_AcvityedImg");
     				}
     				return this.m_E_AcvityedImgImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_AcvityedImg");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_TaskNameTextText = null;
			this.m_E_TaskDescTextText = null;
			this.m_E_ProgressTextText = null;
			this.m_E_ClickBtnButton = null;
			this.m_E_ClickBtnImage = null;
			this.m_E_AcvityedImgImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Text m_E_TaskNameTextText = null;
		private Text m_E_TaskDescTextText = null;
		private Text m_E_ProgressTextText = null;
		private Button m_E_ClickBtnButton = null;
		private Image m_E_ClickBtnImage = null;
		private Image m_E_AcvityedImgImage = null;
		public Transform uiTransform = null;
	}
}
