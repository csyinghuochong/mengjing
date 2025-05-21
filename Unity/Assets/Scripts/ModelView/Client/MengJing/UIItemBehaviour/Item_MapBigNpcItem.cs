using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_MapBigNpcItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_MapBigNpcItem>
	{
		public Action<int, int> ClickHandler;
		public Action<int, int> FlyToHandler;
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

		public Button E_ImageDiButton
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
		    			this.m_E_ImageDiButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ImageDi");
     				}
     				return this.m_E_ImageDiButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ImageDi");
     			}
     		}
     	}

		public Button E_FlyToButton
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
					if( this.m_E_FlyToButton == null )
					{
						this.m_E_FlyToButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_FlyToButton");
					}
					return this.m_E_FlyToButton;
				}
				else
				{
					return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_FlyToButton");
				}
			}
		}
		
		public Image E_ImageDi_npc
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
					if( this.m_E_ImageDi_npc == null )
					{
						this.m_E_ImageDi_npc = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageDi_npc");
					}
					return this.m_E_ImageDi_npc;
				}
				else
				{
					return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageDi_npc");
				}
			}
		}

		public Image E_ImageDi_boss
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
					if( this.m_E_ImageDi_boss == null )
					{
						this.m_E_ImageDi_boss = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageDi_boss");
					}
					return this.m_E_ImageDi_boss;
				}
				else
				{
					return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageDi_boss");
				}
			}
		}
		
		public Image E_ImageDiImage
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
		    			this.m_E_ImageDiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageDi");
     				}
     				return this.m_E_ImageDiImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageDi");
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
		    			this.m_E_TextNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextName");
     				}
     				return this.m_E_TextNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextName");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageDiButton = null;
			this.m_E_ImageDiImage = null;
			this.m_E_TextNameText = null;
			this.m_E_FlyToButton = null;
			this.m_E_ImageDi_npc = null;
			this.m_E_ImageDi_boss = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Button m_E_ImageDiButton = null;
		private Button m_E_FlyToButton = null;	
		private Image m_E_ImageDiImage = null;
		private Image m_E_ImageDi_npc = null;
		private Image m_E_ImageDi_boss = null;
		private Text m_E_TextNameText = null;
		public Transform uiTransform = null;
	}
}
