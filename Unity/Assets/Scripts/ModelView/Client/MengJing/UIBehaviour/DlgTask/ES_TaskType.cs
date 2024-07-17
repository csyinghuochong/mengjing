using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_TaskType : Entity,IAwake<Transform>,IDestroy ,IUILogic
	{
		public Dictionary<int, EntityRef<Scroll_Item_TaskTypeItem>> ScrollItemTaskTypeItems;
		public List<TaskPro> ShowTaskPros = new();
		public bool IsExpand;
		public int TaskType;
		
		public Button E_SelectButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectButton == null )
     			{
		    		this.m_E_SelectButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Select");
     			}
     			return this.m_E_SelectButton;
     		}
     	}

		public Image E_SelectImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectImage == null )
     			{
		    		this.m_E_SelectImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Select");
     			}
     			return this.m_E_SelectImage;
     		}
     	}

		public Text E_TaskTypeNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TaskTypeNameText == null )
     			{
		    		this.m_E_TaskTypeNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TaskTypeName");
     			}
     			return this.m_E_TaskTypeNameText;
     		}
     	}

		public LoopVerticalScrollRect E_TaskTypeItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TaskTypeItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_TaskTypeItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_TaskTypeItems");
     			}
     			return this.m_E_TaskTypeItemsLoopVerticalScrollRect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_SelectButton = null;
			this.m_E_SelectImage = null;
			this.m_E_TaskTypeNameText = null;
			this.m_E_TaskTypeItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private Button m_E_SelectButton = null;
		private Image m_E_SelectImage = null;
		private Text m_E_TaskTypeNameText = null;
		private LoopVerticalScrollRect m_E_TaskTypeItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
