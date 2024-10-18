using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_EquipItem : Entity,IAwake<Transform>,IDestroy
	{
		public int Occ;
		private EntityRef<ItemInfo> bagInfo;
		public ItemInfo BagInfo { get => this.bagInfo; set => this.bagInfo = value; }
		public ItemOperateEnum ItemOperateEnum;
		public List<ItemInfo> EquipList { get; set; } = new();
		public Action<ItemInfo> OnClickAction { get; set; }
		
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

		public Image E_BangDingImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BangDingImage == null )
     			{
		    		this.m_E_BangDingImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_BangDing");
     			}
     			return this.m_E_BangDingImage;
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

		public void DestroyWidget()
		{
			this.m_E_EquipBackImage = null;
			this.m_E_EquipQualityImage = null;
			this.m_E_EquipIconImage = null;
			this.m_E_BangDingImage = null;
			this.m_E_EquipButton = null;
			this.m_E_EquipImage = null;
			this.m_E_EquipEventTrigger = null;
			this.uiTransform = null;
		}

		private Image m_E_EquipBackImage = null;
		private Image m_E_EquipQualityImage = null;
		private Image m_E_EquipIconImage = null;
		private Image m_E_BangDingImage = null;
		private Button m_E_EquipButton = null;
		private Image m_E_EquipImage = null;
		private EventTrigger m_E_EquipEventTrigger = null;
		public Transform uiTransform = null;
	}
}
