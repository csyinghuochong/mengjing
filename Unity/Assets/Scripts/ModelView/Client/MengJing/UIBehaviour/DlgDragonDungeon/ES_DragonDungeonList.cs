using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_DragonDungeonList : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public List<TeamInfo> ShowTeamInfos = new();
		public Dictionary<int, EntityRef<Scroll_Item_TeamDungeonItem>> ScrollItemTeamDungeonItems;
		
		public UnityEngine.UI.Button E_Button_CreateButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_CreateButton == null )
     			{
		    		this.m_E_Button_CreateButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Button_Create");
     			}
     			return this.m_E_Button_CreateButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_CreateImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_CreateImage == null )
     			{
		    		this.m_E_Button_CreateImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Button_Create");
     			}
     			return this.m_E_Button_CreateImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_DragonDungeonItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DragonDungeonItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_DragonDungeonItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Center/E_DragonDungeonItems");
     			}
     			return this.m_E_DragonDungeonItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Text E_Text_LeftTimeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_LeftTimeText == null )
     			{
		    		this.m_E_Text_LeftTimeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_Text_LeftTime");
     			}
     			return this.m_E_Text_LeftTimeText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_XieZhuNumText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_XieZhuNumText == null )
     			{
		    		this.m_E_Text_XieZhuNumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_Text_XieZhuNum");
     			}
     			return this.m_E_Text_XieZhuNumText;
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
			this.m_E_Button_CreateButton = null;
			this.m_E_Button_CreateImage = null;
			this.m_E_DragonDungeonItemsLoopVerticalScrollRect = null;
			this.m_E_Text_LeftTimeText = null;
			this.m_E_Text_XieZhuNumText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_Button_CreateButton = null;
		private UnityEngine.UI.Image m_E_Button_CreateImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_DragonDungeonItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Text m_E_Text_LeftTimeText = null;
		private UnityEngine.UI.Text m_E_Text_XieZhuNumText = null;
		public Transform uiTransform = null;
	}
}
