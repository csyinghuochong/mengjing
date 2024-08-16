using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_JingXuanItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_JingXuanItem> 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_JingXuanItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Text E_Lab_IndexText
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
     				if( this.m_E_Lab_IndexText == null )
     				{
		    			this.m_E_Lab_IndexText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_Index");
     				}
     				return this.m_E_Lab_IndexText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_Index");
     			}
     		}
     	}

		public Text E_Lab_NameText
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
     				if( this.m_E_Lab_NameText == null )
     				{
		    			this.m_E_Lab_NameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_Name");
     				}
     				return this.m_E_Lab_NameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_Name");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Lab_IndexText = null;
			this.m_E_Lab_NameText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Text m_E_Lab_IndexText = null;
		private Text m_E_Lab_NameText = null;
		public Transform uiTransform = null;
	}
}
