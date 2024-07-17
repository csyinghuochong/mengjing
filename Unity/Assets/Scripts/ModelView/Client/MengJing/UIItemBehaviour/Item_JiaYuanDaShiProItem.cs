using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_JiaYuanDaShiProItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_JiaYuanDaShiProItem>
	{
		public Dictionary<int, string> jiayuanDaShi = new();
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_JiaYuanDaShiProItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Image E_ImageTo_1ValueImage
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
     				if( this.m_E_ImageTo_1ValueImage == null )
     				{
		    			this.m_E_ImageTo_1ValueImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageTo_1Value");
     				}
     				return this.m_E_ImageTo_1ValueImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageTo_1Value");
     			}
     		}
     	}

		public Text E_Text_ProgessText
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
     				if( this.m_E_Text_ProgessText == null )
     				{
		    			this.m_E_Text_ProgessText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Progess");
     				}
     				return this.m_E_Text_ProgessText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Progess");
     			}
     		}
     	}

		public Image E_ImageToLockImage
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
     				if( this.m_E_ImageToLockImage == null )
     				{
		    			this.m_E_ImageToLockImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageToLock");
     				}
     				return this.m_E_ImageToLockImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageToLock");
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

		public Image E_ImageProIconImage
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
     				if( this.m_E_ImageProIconImage == null )
     				{
		    			this.m_E_ImageProIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageProIcon");
     				}
     				return this.m_E_ImageProIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageProIcon");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageTo_1ValueImage = null;
			this.m_E_Text_ProgessText = null;
			this.m_E_ImageToLockImage = null;
			this.m_E_Text_NameText = null;
			this.m_E_ImageProIconImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Image m_E_ImageTo_1ValueImage = null;
		private Text m_E_Text_ProgessText = null;
		private Image m_E_ImageToLockImage = null;
		private Text m_E_Text_NameText = null;
		private Image m_E_ImageProIconImage = null;
		public Transform uiTransform = null;
	}
}
