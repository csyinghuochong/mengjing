using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class Scroll_Item_MainTask : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_MainTask>
	{
		public TaskPro TaskPro;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_MainTask BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
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

		public Text E_TaskTargetDesText
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
     				if( this.m_E_TaskTargetDesText == null )
     				{
		    			this.m_E_TaskTargetDesText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TaskTargetDes");
     				}
     				return this.m_E_TaskTargetDesText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TaskTargetDes");
     			}
     		}
     	}

		public Text E_TaskNameText
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
     				if( this.m_E_TaskNameText == null )
     				{
		    			this.m_E_TaskNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TaskName");
     				}
     				return this.m_E_TaskNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TaskName");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ClickButton = null;
			this.m_E_ClickImage = null;
			this.m_E_TaskTargetDesText = null;
			this.m_E_TaskNameText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Button m_E_ClickButton = null;
		private Image m_E_ClickImage = null;
		private Text m_E_TaskTargetDesText = null;
		private Text m_E_TaskNameText = null;
		public Transform uiTransform = null;
	}
}
