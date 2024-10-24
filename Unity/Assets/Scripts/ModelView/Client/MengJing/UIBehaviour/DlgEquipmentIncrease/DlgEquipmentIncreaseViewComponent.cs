﻿using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgEquipmentIncrease))]
	[EnableMethod]
	public  class DlgEquipmentIncreaseViewComponent : Entity,IAwake,IDestroy 
	{
		public RectTransform EG_SubViewRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SubViewRectTransform == null )
     			{
		    		this.m_EG_SubViewRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_SubView");
     			}
     			return this.m_EG_SubViewRectTransform;
     		}
     	}

		public ES_EquipmentIncreaseShow ES_EquipmentIncreaseShow
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_EquipmentIncreaseShow es = this.m_es_equipmentincreaseshow;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_EquipmentIncreaseShow");
		    	   this.m_es_equipmentincreaseshow = this.AddChild<ES_EquipmentIncreaseShow,Transform>(subTrans);
     			}
     			return this.m_es_equipmentincreaseshow;
     		}
     	}

		public ES_EquipmentIncreaseTransfer ES_EquipmentIncreaseTransfer
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_EquipmentIncreaseTransfer es = this.m_es_equipmentincreasetransfer;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_EquipmentIncreaseTransfer");
		    	   this.m_es_equipmentincreasetransfer = this.AddChild<ES_EquipmentIncreaseTransfer,Transform>(subTrans);
     			}
     			return this.m_es_equipmentincreasetransfer;
     		}
     	}

		public ToggleGroup E_FunctionSetBtnToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FunctionSetBtnToggleGroup == null )
     			{
		    		this.m_E_FunctionSetBtnToggleGroup = UIFindHelper.FindDeepChild<ToggleGroup>(this.uiTransform.gameObject,"E_FunctionSetBtn");
     			}
     			return this.m_E_FunctionSetBtnToggleGroup;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_es_equipmentincreaseshow = null;
			this.m_es_equipmentincreasetransfer = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_SubViewRectTransform = null;
		private EntityRef<ES_EquipmentIncreaseShow> m_es_equipmentincreaseshow = null;
		private EntityRef<ES_EquipmentIncreaseTransfer> m_es_equipmentincreasetransfer = null;
		private ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		public Transform uiTransform = null;
	}
}
