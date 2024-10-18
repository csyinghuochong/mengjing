using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_EquipSetItem : Entity,IAwake<Transform>,IDestroy 
	{
		public List<ItemInfo> EquipIdList { get; set; } = new List<ItemInfo>();
		private EntityRef<ItemInfo> bagInfo;
		public ItemInfo BagInfo { get => this.bagInfo; set => this.bagInfo = value; }
		public int Occ;
		public Action<ItemInfo> OnClickAction { get; set; }

		public ItemOperateEnum itemOperateEnum = ItemOperateEnum.Juese;
		
		public Image E_EquipBackImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipBackImage == null )
     			{
		    		this.m_E_EquipBackImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_EquipBack");
     			}
     			return this.m_E_EquipBackImage;
     		}
     	}

		public Image E_EquipBackTextImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipBackTextImage == null )
     			{
		    		this.m_E_EquipBackTextImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_EquipBackText");
     			}
     			return this.m_E_EquipBackTextImage;
     		}
     	}

		public Image E_EquipQualityImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipQualityImage == null )
     			{
		    		this.m_E_EquipQualityImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_EquipQuality");
     			}
     			return this.m_E_EquipQualityImage;
     		}
     	}

		public Image E_EquipIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipIconImage == null )
     			{
		    		this.m_E_EquipIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_EquipIcon");
     			}
     			return this.m_E_EquipIconImage;
     		}
     	}

		public RectTransform EG_BangDingRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_BangDingRectTransform == null )
     			{
		    		this.m_EG_BangDingRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_BangDing");
     			}
     			return this.m_EG_BangDingRectTransform;
     		}
     	}

		public Button E_EquipButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipButton == null )
     			{
		    		this.m_E_EquipButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Equip");
     			}
     			return this.m_E_EquipButton;
     		}
     	}

		public Image E_EquipImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipImage == null )
     			{
		    		this.m_E_EquipImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Equip");
     			}
     			return this.m_E_EquipImage;
     		}
     	}

		public EventTrigger E_EquipEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipEventTrigger == null )
     			{
		    		this.m_E_EquipEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"E_Equip");
     			}
     			return this.m_E_EquipEventTrigger;
     		}
     	}

		public Text E_QiangHuaNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_QiangHuaNameText == null )
     			{
		    		this.m_E_QiangHuaNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_QiangHuaName");
     			}
     			return this.m_E_QiangHuaNameText;
     		}
     	}

		public Text E_QiangHuaLvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_QiangHuaLvText == null )
     			{
		    		this.m_E_QiangHuaLvText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_QiangHuaLv");
     			}
     			return this.m_E_QiangHuaLvText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_EquipBackImage = null;
			this.m_E_EquipBackTextImage = null;
			this.m_E_EquipQualityImage = null;
			this.m_E_EquipIconImage = null;
			this.m_EG_BangDingRectTransform = null;
			this.m_E_EquipButton = null;
			this.m_E_EquipImage = null;
			this.m_E_EquipEventTrigger = null;
			this.m_E_QiangHuaNameText = null;
			this.m_E_QiangHuaLvText = null;
			this.uiTransform = null;
		}

		private Image m_E_EquipBackImage = null;
		private Image m_E_EquipBackTextImage = null;
		private Image m_E_EquipQualityImage = null;
		private Image m_E_EquipIconImage = null;
		private RectTransform m_EG_BangDingRectTransform = null;
		private Button m_E_EquipButton = null;
		private Image m_E_EquipImage = null;
		private EventTrigger m_E_EquipEventTrigger = null;
		private Text m_E_QiangHuaNameText = null;
		private Text m_E_QiangHuaLvText = null;
		public Transform uiTransform = null;
	}
}
