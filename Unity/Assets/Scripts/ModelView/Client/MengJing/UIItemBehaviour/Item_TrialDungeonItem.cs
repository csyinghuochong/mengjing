using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_TrialDungeonItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_TrialDungeonItem>
	{
		public TowerConfig TowerConfig;
		public Action<int> ClickHandle;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_TrialDungeonItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Button E_Btn_XuanZhongButton
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
     				if( this.m_E_Btn_XuanZhongButton == null )
     				{
		    			this.m_E_Btn_XuanZhongButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_XuanZhong");
     				}
     				return this.m_E_Btn_XuanZhongButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_XuanZhong");
     			}
     		}
     	}

		public Image E_Btn_XuanZhongImage
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
     				if( this.m_E_Btn_XuanZhongImage == null )
     				{
		    			this.m_E_Btn_XuanZhongImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_XuanZhong");
     				}
     				return this.m_E_Btn_XuanZhongImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_XuanZhong");
     			}
     		}
     	}

		public Image E_ImgIconImage
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
     				if( this.m_E_ImgIconImage == null )
     				{
		    			this.m_E_ImgIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImgIcon");
     				}
     				return this.m_E_ImgIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImgIcon");
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

		public Text E_Lab_HPText
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
     				if( this.m_E_Lab_HPText == null )
     				{
		    			this.m_E_Lab_HPText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_HP");
     				}
     				return this.m_E_Lab_HPText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_HP");
     			}
     		}
     	}

		public Text E_Lab_LvText
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
     				if( this.m_E_Lab_LvText == null )
     				{
		    			this.m_E_Lab_LvText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_Lv");
     				}
     				return this.m_E_Lab_LvText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_Lv");
     			}
     		}
     	}

		public Image E_Hint_1Image
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
     				if( this.m_E_Hint_1Image == null )
     				{
		    			this.m_E_Hint_1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Hint_1");
     				}
     				return this.m_E_Hint_1Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Hint_1");
     			}
     		}
     	}

		public Image E_Hint_2Image
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
     				if( this.m_E_Hint_2Image == null )
     				{
		    			this.m_E_Hint_2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Hint_2");
     				}
     				return this.m_E_Hint_2Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Hint_2");
     			}
     		}
     	}

		public Image E_Hint_3Image
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
     				if( this.m_E_Hint_3Image == null )
     				{
		    			this.m_E_Hint_3Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Hint_3");
     				}
     				return this.m_E_Hint_3Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Hint_3");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Btn_XuanZhongButton = null;
			this.m_E_Btn_XuanZhongImage = null;
			this.m_E_ImgIconImage = null;
			this.m_E_Lab_NameText = null;
			this.m_E_Lab_HPText = null;
			this.m_E_Lab_LvText = null;
			this.m_E_Hint_1Image = null;
			this.m_E_Hint_2Image = null;
			this.m_E_Hint_3Image = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Button m_E_Btn_XuanZhongButton = null;
		private Image m_E_Btn_XuanZhongImage = null;
		private Image m_E_ImgIconImage = null;
		private Text m_E_Lab_NameText = null;
		private Text m_E_Lab_HPText = null;
		private Text m_E_Lab_LvText = null;
		private Image m_E_Hint_1Image = null;
		private Image m_E_Hint_2Image = null;
		private Image m_E_Hint_3Image = null;
		public Transform uiTransform = null;
	}
}
