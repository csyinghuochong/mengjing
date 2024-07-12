
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

		public UnityEngine.UI.Button E_ImageIcon1Button
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
		    			this.m_E_ImageIcon1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ImageIcon1");
     				}
     				return this.m_E_ImageIcon1Button;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ImageIcon1");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ImageIcon1Image
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
		    			this.m_E_ImageIcon1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageIcon1");
     				}
     				return this.m_E_ImageIcon1Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageIcon1");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_ImageIcon2Button
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
		    			this.m_E_ImageIcon2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ImageIcon2");
     				}
     				return this.m_E_ImageIcon2Button;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ImageIcon2");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ImageIcon2Image
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
		    			this.m_E_ImageIcon2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageIcon2");
     				}
     				return this.m_E_ImageIcon2Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageIcon2");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_ImageIcon3Button
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
		    			this.m_E_ImageIcon3Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ImageIcon3");
     				}
     				return this.m_E_ImageIcon3Button;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ImageIcon3");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ImageIcon3Image
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
		    			this.m_E_ImageIcon3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageIcon3");
     				}
     				return this.m_E_ImageIcon3Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageIcon3");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_TextLvText
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
		    			this.m_E_TextLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextLv");
     				}
     				return this.m_E_TextLvText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextLv");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_TextName1Text
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
		    			this.m_E_TextName1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextName1");
     				}
     				return this.m_E_TextName1Text;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextName1");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_TextName2Text
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
		    			this.m_E_TextName2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextName2");
     				}
     				return this.m_E_TextName2Text;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextName2");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_TextName3Text
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
		    			this.m_E_TextName3Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextName3");
     				}
     				return this.m_E_TextName3Text;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextName3");
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

		private UnityEngine.UI.Button m_E_ImageIcon1Button = null;
		private UnityEngine.UI.Image m_E_ImageIcon1Image = null;
		private UnityEngine.UI.Button m_E_ImageIcon2Button = null;
		private UnityEngine.UI.Image m_E_ImageIcon2Image = null;
		private UnityEngine.UI.Button m_E_ImageIcon3Button = null;
		private UnityEngine.UI.Image m_E_ImageIcon3Image = null;
		private UnityEngine.UI.Text m_E_TextLvText = null;
		private UnityEngine.UI.Text m_E_TextName1Text = null;
		private UnityEngine.UI.Text m_E_TextName2Text = null;
		private UnityEngine.UI.Text m_E_TextName3Text = null;
		public Transform uiTransform = null;
	}
}
