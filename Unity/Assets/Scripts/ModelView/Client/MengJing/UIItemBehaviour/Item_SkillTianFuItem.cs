using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_SkillTianFuItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_SkillTianFuItem>
	{
		public List<int> TianFuList;
		public Action<int> ClickHandler;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_SkillTianFuItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Button E_ImageIcon1Button
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
     				if( this.m_E_ImageIcon1Button == null )
     				{
		    			this.m_E_ImageIcon1Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ImageIcon1");
     				}
     				return this.m_E_ImageIcon1Button;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ImageIcon1");
     			}
     		}
     	}

		public Image E_ImageIcon1Image
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
     				if( this.m_E_ImageIcon1Image == null )
     				{
		    			this.m_E_ImageIcon1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageIcon1");
     				}
     				return this.m_E_ImageIcon1Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageIcon1");
     			}
     		}
     	}

		public Button E_ImageIcon2Button
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
     				if( this.m_E_ImageIcon2Button == null )
     				{
		    			this.m_E_ImageIcon2Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ImageIcon2");
     				}
     				return this.m_E_ImageIcon2Button;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ImageIcon2");
     			}
     		}
     	}

		public Image E_ImageIcon2Image
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
     				if( this.m_E_ImageIcon2Image == null )
     				{
		    			this.m_E_ImageIcon2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageIcon2");
     				}
     				return this.m_E_ImageIcon2Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageIcon2");
     			}
     		}
     	}

		public Button E_ImageIcon3Button
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
     				if( this.m_E_ImageIcon3Button == null )
     				{
		    			this.m_E_ImageIcon3Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ImageIcon3");
     				}
     				return this.m_E_ImageIcon3Button;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ImageIcon3");
     			}
     		}
     	}

		public Image E_ImageIcon3Image
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
     				if( this.m_E_ImageIcon3Image == null )
     				{
		    			this.m_E_ImageIcon3Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageIcon3");
     				}
     				return this.m_E_ImageIcon3Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageIcon3");
     			}
     		}
     	}

		public Text E_TextLvText
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
     				if( this.m_E_TextLvText == null )
     				{
		    			this.m_E_TextLvText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextLv");
     				}
     				return this.m_E_TextLvText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextLv");
     			}
     		}
     	}

		public Text E_TextName1Text
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
     				if( this.m_E_TextName1Text == null )
     				{
		    			this.m_E_TextName1Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextName1");
     				}
     				return this.m_E_TextName1Text;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextName1");
     			}
     		}
     	}

		public Text E_TextName2Text
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
     				if( this.m_E_TextName2Text == null )
     				{
		    			this.m_E_TextName2Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextName2");
     				}
     				return this.m_E_TextName2Text;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextName2");
     			}
     		}
     	}

		public Text E_TextName3Text
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
     				if( this.m_E_TextName3Text == null )
     				{
		    			this.m_E_TextName3Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextName3");
     				}
     				return this.m_E_TextName3Text;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextName3");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageIcon1Button = null;
			this.m_E_ImageIcon1Image = null;
			this.m_E_ImageIcon2Button = null;
			this.m_E_ImageIcon2Image = null;
			this.m_E_ImageIcon3Button = null;
			this.m_E_ImageIcon3Image = null;
			this.m_E_TextLvText = null;
			this.m_E_TextName1Text = null;
			this.m_E_TextName2Text = null;
			this.m_E_TextName3Text = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Button m_E_ImageIcon1Button = null;
		private Image m_E_ImageIcon1Image = null;
		private Button m_E_ImageIcon2Button = null;
		private Image m_E_ImageIcon2Image = null;
		private Button m_E_ImageIcon3Button = null;
		private Image m_E_ImageIcon3Image = null;
		private Text m_E_TextLvText = null;
		private Text m_E_TextName1Text = null;
		private Text m_E_TextName2Text = null;
		private Text m_E_TextName3Text = null;
		public Transform uiTransform = null;
	}
}
