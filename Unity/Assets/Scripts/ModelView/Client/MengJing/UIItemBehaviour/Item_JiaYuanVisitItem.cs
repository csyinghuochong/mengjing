using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_JiaYuanVisitItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_JiaYuanVisitItem>
	{
		public JiaYuanVisit JiaYuanVisit;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_JiaYuanVisitItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Image E_ImageIconImage
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
     				if( this.m_E_ImageIconImage == null )
     				{
		    			this.m_E_ImageIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Set/E_ImageIcon");
     				}
     				return this.m_E_ImageIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Set/E_ImageIcon");
     			}
     		}
     	}

		public Button E_ButtonVisitButton
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
     				if( this.m_E_ButtonVisitButton == null )
     				{
		    			this.m_E_ButtonVisitButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Set/E_ButtonVisit");
     				}
     				return this.m_E_ButtonVisitButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Set/E_ButtonVisit");
     			}
     		}
     	}

		public Image E_ButtonVisitImage
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
     				if( this.m_E_ButtonVisitImage == null )
     				{
		    			this.m_E_ButtonVisitImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Set/E_ButtonVisit");
     				}
     				return this.m_E_ButtonVisitImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Set/E_ButtonVisit");
     			}
     		}
     	}

		public Text E_TextNameText
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
     				if( this.m_E_TextNameText == null )
     				{
		    			this.m_E_TextNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Set/E_TextName");
     				}
     				return this.m_E_TextNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Set/E_TextName");
     			}
     		}
     	}

		public Text E_TextTimes_1Text
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
     				if( this.m_E_TextTimes_1Text == null )
     				{
		    			this.m_E_TextTimes_1Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Set/E_TextTimes_1");
     				}
     				return this.m_E_TextTimes_1Text;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Set/E_TextTimes_1");
     			}
     		}
     	}

		public Text E_TextTimes_2Text
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
     				if( this.m_E_TextTimes_2Text == null )
     				{
		    			this.m_E_TextTimes_2Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Set/E_TextTimes_2");
     				}
     				return this.m_E_TextTimes_2Text;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Set/E_TextTimes_2");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageIconImage = null;
			this.m_E_ButtonVisitButton = null;
			this.m_E_ButtonVisitImage = null;
			this.m_E_TextNameText = null;
			this.m_E_TextTimes_1Text = null;
			this.m_E_TextTimes_2Text = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Image m_E_ImageIconImage = null;
		private Button m_E_ButtonVisitButton = null;
		private Image m_E_ButtonVisitImage = null;
		private Text m_E_TextNameText = null;
		private Text m_E_TextTimes_1Text = null;
		private Text m_E_TextTimes_2Text = null;
		public Transform uiTransform = null;
	}
}
