
using System;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_MapBigNpcItem : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public Action<int, int> ClickHandler;
		public int ConfigId;
		public int UnitType;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_MapBigNpcItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Button E_ImageDiButton
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
     				if( this.m_E_ImageDiButton == null )
     				{
		    			this.m_E_ImageDiButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ImageDi");
     				}
     				return this.m_E_ImageDiButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ImageDi");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ImageDiImage
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
     				if( this.m_E_ImageDiImage == null )
     				{
		    			this.m_E_ImageDiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageDi");
     				}
     				return this.m_E_ImageDiImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageDi");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_TextNameText
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
		    			this.m_E_TextNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextName");
     				}
     				return this.m_E_TextNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextName");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageDiButton = null;
			this.m_E_ImageDiImage = null;
			this.m_E_TextNameText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Button m_E_ImageDiButton = null;
		private UnityEngine.UI.Image m_E_ImageDiImage = null;
		private UnityEngine.UI.Text m_E_TextNameText = null;
		public Transform uiTransform = null;
	}
}
