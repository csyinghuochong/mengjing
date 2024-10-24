﻿using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgUnionXiuLian))]
	[EnableMethod]
	public  class DlgUnionXiuLianViewComponent : Entity,IAwake,IDestroy 
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

		public ES_UnionRoleXiuLian ES_UnionRoleXiuLian
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_UnionRoleXiuLian es = this.m_es_unionrolexiulian;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_UnionRoleXiuLian");
		    	   this.m_es_unionrolexiulian = this.AddChild<ES_UnionRoleXiuLian,Transform>(subTrans);
     			}
     			return this.m_es_unionrolexiulian;
     		}
     	}

		public ES_UnionPetXiuLian ES_UnionPetXiuLian
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_UnionPetXiuLian es = this.m_es_unionpetxiulian;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_UnionPetXiuLian");
		    	   this.m_es_unionpetxiulian = this.AddChild<ES_UnionPetXiuLian,Transform>(subTrans);
     			}
     			return this.m_es_unionpetxiulian;
     		}
     	}

		public ES_UnionBloodStone ES_UnionBloodStone
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_UnionBloodStone es = this.m_es_unionbloodstone;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_UnionBloodStone");
		    	   this.m_es_unionbloodstone = this.AddChild<ES_UnionBloodStone,Transform>(subTrans);
     			}
     			return this.m_es_unionbloodstone;
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
			this.m_es_unionrolexiulian = null;
			this.m_es_unionpetxiulian = null;
			this.m_es_unionbloodstone = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_SubViewRectTransform = null;
		private EntityRef<ES_UnionRoleXiuLian> m_es_unionrolexiulian = null;
		private EntityRef<ES_UnionPetXiuLian> m_es_unionpetxiulian = null;
		private EntityRef<ES_UnionBloodStone> m_es_unionbloodstone = null;
		private ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		public Transform uiTransform = null;
	}
}
