using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ModelShow : Entity,IAwake<Transform>,IDestroy
	{
		// 每显示一次就会+1 用于位置偏移 防止RenderTexture画面中出现几个模型
		[StaticField]
		public static int DisPlayUIIndex = 0;
		
		public Camera Camera { get; set; }
		public Transform ModelParent { get; set; }
		public List<GameObject> Model = new();
		public RenderTexture RenderTexture;
		
		public Vector2 StartPosition;
		public bool Draged = false;
		public Action ClickHandler { get; set; }

		public float RotationY { get; set; } = 0f;
		
		public Button E_RenderButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RenderButton == null )
     			{
		    		this.m_E_RenderButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Render");
     			}
     			return this.m_E_RenderButton;
     		}
     	}

		public RawImage E_RenderRawImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RenderRawImage == null )
     			{
		    		this.m_E_RenderRawImage = UIFindHelper.FindDeepChild<RawImage>(this.uiTransform.gameObject,"E_Render");
     			}
     			return this.m_E_RenderRawImage;
     		}
     	}

		public EventTrigger E_RenderEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RenderEventTrigger == null )
     			{
		    		this.m_E_RenderEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"E_Render");
     			}
     			return this.m_E_RenderEventTrigger;
     		}
     	}

		public RectTransform EG_RootRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_RootRectTransform == null )
     			{
		    		this.m_EG_RootRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"E_Render/EG_Root");
     			}
     			return this.m_EG_RootRectTransform;
     		}
     	}

		    public Transform UITransform
         {
     	    get
     	    {
     		    return this.uiTransform;
     	    }
     	    set
     	    {
     		    this.uiTransform = value;
     	    }
         }

		public void DestroyWidget()
		{
			this.m_E_RenderButton = null;
			this.m_E_RenderRawImage = null;
			this.m_E_RenderEventTrigger = null;
			this.m_EG_RootRectTransform = null;
			this.uiTransform = null;
		}

		private Button m_E_RenderButton = null;
		private RawImage m_E_RenderRawImage = null;
		private EventTrigger m_E_RenderEventTrigger = null;
		private RectTransform m_EG_RootRectTransform = null;
		public Transform uiTransform = null;
	}
}
