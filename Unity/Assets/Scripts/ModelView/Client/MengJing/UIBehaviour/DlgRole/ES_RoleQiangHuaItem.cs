using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_RoleQiangHuaItem : Entity,IAwake<Transform>,IDestroy 
	{
		public int ItemSubType;
		public Action<int> ClickHandler;
		
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

		public Text E_QiangHuaText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_QiangHuaText == null )
     			{
		    		this.m_E_QiangHuaText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_QiangHua");
     			}
     			return this.m_E_QiangHuaText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_EquipBackImage = null;
			this.m_E_EquipBackTextImage = null;
			this.m_E_EquipQualityImage = null;
			this.m_E_EquipIconImage = null;
			this.m_E_EquipButton = null;
			this.m_E_EquipImage = null;
			this.m_E_EquipEventTrigger = null;
			this.m_E_QiangHuaText = null;
			this.uiTransform = null;
		}

		private Image m_E_EquipBackImage = null;
		private Image m_E_EquipBackTextImage = null;
		private Image m_E_EquipQualityImage = null;
		private Image m_E_EquipIconImage = null;
		private Button m_E_EquipButton = null;
		private Image m_E_EquipImage = null;
		private EventTrigger m_E_EquipEventTrigger = null;
		private Text m_E_QiangHuaText = null;
		public Transform uiTransform = null;
	}
}
