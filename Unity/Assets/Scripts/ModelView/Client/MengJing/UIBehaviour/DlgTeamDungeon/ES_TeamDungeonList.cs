using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_TeamDungeonList : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public List<TeamInfo> ShowTeamInfos = new();
		public Dictionary<int, EntityRef<Scroll_Item_TeamDungeonItem>> ScrollItemTeamDungeonItems;
		
		public Button E_Button_CreateButton
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
		    		this.m_E_Button_CreateButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button_Create");
     			}
     			return this.m_E_Button_CreateButton;
     		}
     	}

		public Image E_Button_CreateImage
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
		    		this.m_E_Button_CreateImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button_Create");
     			}
     			return this.m_E_Button_CreateImage;
     		}
     	}

		public LoopVerticalScrollRect E_TeamDungeonItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TeamDungeonItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_TeamDungeonItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_TeamDungeonItems");
     			}
     			return this.m_E_TeamDungeonItemsLoopVerticalScrollRect;
     		}
     	}

		public Text E_Text_LeftTimeText
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
		    		this.m_E_Text_LeftTimeText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_LeftTime");
     			}
     			return this.m_E_Text_LeftTimeText;
     		}
     	}

		public Text E_Text_XieZhuNumText
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
		    		this.m_E_Text_XieZhuNumText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_XieZhuNum");
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
			this.m_E_TeamDungeonItemsLoopVerticalScrollRect = null;
			this.m_E_Text_LeftTimeText = null;
			this.m_E_Text_XieZhuNumText = null;
			this.uiTransform = null;
		}

		private Button m_E_Button_CreateButton = null;
		private Image m_E_Button_CreateImage = null;
		private LoopVerticalScrollRect m_E_TeamDungeonItemsLoopVerticalScrollRect = null;
		private Text m_E_Text_LeftTimeText = null;
		private Text m_E_Text_XieZhuNumText = null;
		public Transform uiTransform = null;
	}
}
