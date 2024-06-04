
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_EquipSetItem : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public List<BagInfo> EquipIdList = new List<BagInfo>();
		public BagInfo BagInfo;
		public int Occ;
		public Action<BagInfo> OnClickAction;

		public ItemOperateEnum itemOperateEnum = ItemOperateEnum.Juese;
		
		public UnityEngine.UI.Image E_EquipBackImage
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
		    		this.m_E_EquipBackImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_EquipBack");
     			}
     			return this.m_E_EquipBackImage;
     		}
     	}

		public UnityEngine.UI.Image E_EquipBackTextImage
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
		    		this.m_E_EquipBackTextImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_EquipBackText");
     			}
     			return this.m_E_EquipBackTextImage;
     		}
     	}

		public UnityEngine.UI.Image E_EquipQualityImage
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
		    		this.m_E_EquipQualityImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_EquipQuality");
     			}
     			return this.m_E_EquipQualityImage;
     		}
     	}

		public UnityEngine.UI.Image E_EquipIconImage
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
		    		this.m_E_EquipIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_EquipIcon");
     			}
     			return this.m_E_EquipIconImage;
     		}
     	}

		public UnityEngine.RectTransform EG_BangDingRectTransform
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
		    		this.m_EG_BangDingRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_BangDing");
     			}
     			return this.m_EG_BangDingRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_EquipButton
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
		    		this.m_E_EquipButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Equip");
     			}
     			return this.m_E_EquipButton;
     		}
     	}

		public UnityEngine.UI.Image E_EquipImage
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
		    		this.m_E_EquipImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Equip");
     			}
     			return this.m_E_EquipImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_EquipEventTrigger
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
		    		this.m_E_EquipEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"E_Equip");
     			}
     			return this.m_E_EquipEventTrigger;
     		}
     	}

		public UnityEngine.UI.Text E_QiangHuaNameText
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
		    		this.m_E_QiangHuaNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_QiangHuaName");
     			}
     			return this.m_E_QiangHuaNameText;
     		}
     	}

		public UnityEngine.UI.Text E_QiangHuaLvText
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
		    		this.m_E_QiangHuaLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_QiangHuaLv");
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

		private UnityEngine.UI.Image m_E_EquipBackImage = null;
		private UnityEngine.UI.Image m_E_EquipBackTextImage = null;
		private UnityEngine.UI.Image m_E_EquipQualityImage = null;
		private UnityEngine.UI.Image m_E_EquipIconImage = null;
		private UnityEngine.RectTransform m_EG_BangDingRectTransform = null;
		private UnityEngine.UI.Button m_E_EquipButton = null;
		private UnityEngine.UI.Image m_E_EquipImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_EquipEventTrigger = null;
		private UnityEngine.UI.Text m_E_QiangHuaNameText = null;
		private UnityEngine.UI.Text m_E_QiangHuaLvText = null;
		public Transform uiTransform = null;
	}
}
