using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableClass]
	public class ShowPropertyList
	{
		public int NumericType;
		public string Name;
		public string IconID;
		public int Type;
	}

	
	[ChildOf]
	[EnableMethod]
	public  class ES_RoleProperty : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public Dictionary<int, EntityRef<Scroll_Item_RolePropertyTeShuItem>> ScrollItemRolePropertyTeShuItems;
		public List<ShowPropertyList> ShowPropertyList_Base = new();
		public List<ShowPropertyList> ShowPropertyList_TeShu = new();
		public List<ShowPropertyList> ShowPropertyList_KangXing = new();
		public List<ShowPropertyList> ShowPropertyLists;
		public List<int> PointList = new();
		public List<int> PointInit = new();
		public int PointRemain;
		public bool IsHoldDown;
		
		public RectTransform EG_AttributeNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_AttributeNodeRectTransform == null )
     			{
		    		this.m_EG_AttributeNodeRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Right/EG_AttributeNode");
     			}
     			return this.m_EG_AttributeNodeRectTransform;
     		}
     	}

		public Image E_PiLaoImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PiLaoImgImage == null )
     			{
		    		this.m_E_PiLaoImgImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/EG_AttributeNode/ProSet/TiLi/E_PiLaoImg");
     			}
     			return this.m_E_PiLaoImgImage;
     		}
     	}

		public Text E_PiLaoTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PiLaoTextText == null )
     			{
		    		this.m_E_PiLaoTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/EG_AttributeNode/ProSet/TiLi/E_PiLaoText");
     			}
     			return this.m_E_PiLaoTextText;
     		}
     	}

		public Image E_BaoShiDuImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BaoShiDuImgImage == null )
     			{
		    		this.m_E_BaoShiDuImgImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/EG_AttributeNode/ProSet/Satiety/E_BaoShiDuImg");
     			}
     			return this.m_E_BaoShiDuImgImage;
     		}
     	}

		public Text E_BaoShiDuTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BaoShiDuTextText == null )
     			{
		    		this.m_E_BaoShiDuTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/EG_AttributeNode/ProSet/Satiety/E_BaoShiDuText");
     			}
     			return this.m_E_BaoShiDuTextText;
     		}
     	}

		public ToggleGroup E_BtnItemTypeSetToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BtnItemTypeSetToggleGroup == null )
     			{
		    		this.m_E_BtnItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<ToggleGroup>(this.uiTransform.gameObject,"Right/EG_AttributeNode/E_BtnItemTypeSet");
     			}
     			return this.m_E_BtnItemTypeSetToggleGroup;
     		}
     	}

		public LoopVerticalScrollRect E_RolePropertyTeShuItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RolePropertyTeShuItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_RolePropertyTeShuItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/EG_AttributeNode/E_RolePropertyTeShuItems");
     			}
     			return this.m_E_RolePropertyTeShuItemsLoopVerticalScrollRect;
     		}
     	}

		public Button E_AddPointButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AddPointButton == null )
     			{
		    		this.m_E_AddPointButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/EG_AttributeNode/E_AddPoint");
     			}
     			return this.m_E_AddPointButton;
     		}
     	}

		public Image E_AddPointImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AddPointImage == null )
     			{
		    		this.m_E_AddPointImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/EG_AttributeNode/E_AddPoint");
     			}
     			return this.m_E_AddPointImage;
     		}
     	}

		public RectTransform EG_RoleAddPointRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_RoleAddPointRectTransform == null )
     			{
		    		this.m_EG_RoleAddPointRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint");
     			}
     			return this.m_EG_RoleAddPointRectTransform;
     		}
     	}

		public Text E_ShengYuNumText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ShengYuNumText == null )
     			{
		    		this.m_E_ShengYuNumText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/E_ShengYuNum");
     			}
     			return this.m_E_ShengYuNumText;
     		}
     	}

		public Button E_AddPointConfirmButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AddPointConfirmButton == null )
     			{
		    		this.m_E_AddPointConfirmButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/E_AddPointConfirm");
     			}
     			return this.m_E_AddPointConfirmButton;
     		}
     	}

		public Image E_AddPointConfirmImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AddPointConfirmImage == null )
     			{
		    		this.m_E_AddPointConfirmImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/E_AddPointConfirm");
     			}
     			return this.m_E_AddPointConfirmImage;
     		}
     	}

		public Button E_CloseAddPointButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseAddPointButton == null )
     			{
		    		this.m_E_CloseAddPointButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/E_CloseAddPoint");
     			}
     			return this.m_E_CloseAddPointButton;
     		}
     	}

		public Image E_CloseAddPointImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseAddPointImage == null )
     			{
		    		this.m_E_CloseAddPointImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/E_CloseAddPoint");
     			}
     			return this.m_E_CloseAddPointImage;
     		}
     	}

		public Text E_Value_LiLiangText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Value_LiLiangText == null )
     			{
		    		this.m_E_Value_LiLiangText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_LiLiang/E_Value_LiLiang");
     			}
     			return this.m_E_Value_LiLiangText;
     		}
     	}

		public Button E_Add_LiLiangButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Add_LiLiangButton == null )
     			{
		    		this.m_E_Add_LiLiangButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_LiLiang/E_Add_LiLiang");
     			}
     			return this.m_E_Add_LiLiangButton;
     		}
     	}

		public Image E_Add_LiLiangImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Add_LiLiangImage == null )
     			{
		    		this.m_E_Add_LiLiangImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_LiLiang/E_Add_LiLiang");
     			}
     			return this.m_E_Add_LiLiangImage;
     		}
     	}

		public EventTrigger E_Add_LiLiangEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Add_LiLiangEventTrigger == null )
     			{
		    		this.m_E_Add_LiLiangEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_LiLiang/E_Add_LiLiang");
     			}
     			return this.m_E_Add_LiLiangEventTrigger;
     		}
     	}

		public Button E_Cost_LiLiangButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Cost_LiLiangButton == null )
     			{
		    		this.m_E_Cost_LiLiangButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_LiLiang/E_Cost_LiLiang");
     			}
     			return this.m_E_Cost_LiLiangButton;
     		}
     	}

		public Image E_Cost_LiLiangImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Cost_LiLiangImage == null )
     			{
		    		this.m_E_Cost_LiLiangImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_LiLiang/E_Cost_LiLiang");
     			}
     			return this.m_E_Cost_LiLiangImage;
     		}
     	}

		public EventTrigger E_Cost_LiLiangEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Cost_LiLiangEventTrigger == null )
     			{
		    		this.m_E_Cost_LiLiangEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_LiLiang/E_Cost_LiLiang");
     			}
     			return this.m_E_Cost_LiLiangEventTrigger;
     		}
     	}

		public Text E_Value_ZhiLiText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Value_ZhiLiText == null )
     			{
		    		this.m_E_Value_ZhiLiText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_ZhiLi/E_Value_ZhiLi");
     			}
     			return this.m_E_Value_ZhiLiText;
     		}
     	}

		public Button E_Add_ZhiLiButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Add_ZhiLiButton == null )
     			{
		    		this.m_E_Add_ZhiLiButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_ZhiLi/E_Add_ZhiLi");
     			}
     			return this.m_E_Add_ZhiLiButton;
     		}
     	}

		public Image E_Add_ZhiLiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Add_ZhiLiImage == null )
     			{
		    		this.m_E_Add_ZhiLiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_ZhiLi/E_Add_ZhiLi");
     			}
     			return this.m_E_Add_ZhiLiImage;
     		}
     	}

		public EventTrigger E_Add_ZhiLiEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Add_ZhiLiEventTrigger == null )
     			{
		    		this.m_E_Add_ZhiLiEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_ZhiLi/E_Add_ZhiLi");
     			}
     			return this.m_E_Add_ZhiLiEventTrigger;
     		}
     	}

		public Button E_Cost_ZhiLiButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Cost_ZhiLiButton == null )
     			{
		    		this.m_E_Cost_ZhiLiButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_ZhiLi/E_Cost_ZhiLi");
     			}
     			return this.m_E_Cost_ZhiLiButton;
     		}
     	}

		public Image E_Cost_ZhiLiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Cost_ZhiLiImage == null )
     			{
		    		this.m_E_Cost_ZhiLiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_ZhiLi/E_Cost_ZhiLi");
     			}
     			return this.m_E_Cost_ZhiLiImage;
     		}
     	}

		public EventTrigger E_Cost_ZhiLiEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Cost_ZhiLiEventTrigger == null )
     			{
		    		this.m_E_Cost_ZhiLiEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_ZhiLi/E_Cost_ZhiLi");
     			}
     			return this.m_E_Cost_ZhiLiEventTrigger;
     		}
     	}

		public Text E_Value_TiZhiText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Value_TiZhiText == null )
     			{
		    		this.m_E_Value_TiZhiText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_TiZhi/E_Value_TiZhi");
     			}
     			return this.m_E_Value_TiZhiText;
     		}
     	}

		public Button E_Add_TiZhiButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Add_TiZhiButton == null )
     			{
		    		this.m_E_Add_TiZhiButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_TiZhi/E_Add_TiZhi");
     			}
     			return this.m_E_Add_TiZhiButton;
     		}
     	}

		public Image E_Add_TiZhiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Add_TiZhiImage == null )
     			{
		    		this.m_E_Add_TiZhiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_TiZhi/E_Add_TiZhi");
     			}
     			return this.m_E_Add_TiZhiImage;
     		}
     	}

		public EventTrigger E_Add_TiZhiEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Add_TiZhiEventTrigger == null )
     			{
		    		this.m_E_Add_TiZhiEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_TiZhi/E_Add_TiZhi");
     			}
     			return this.m_E_Add_TiZhiEventTrigger;
     		}
     	}

		public Button E_Cost_TiZhiButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Cost_TiZhiButton == null )
     			{
		    		this.m_E_Cost_TiZhiButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_TiZhi/E_Cost_TiZhi");
     			}
     			return this.m_E_Cost_TiZhiButton;
     		}
     	}

		public Image E_Cost_TiZhiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Cost_TiZhiImage == null )
     			{
		    		this.m_E_Cost_TiZhiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_TiZhi/E_Cost_TiZhi");
     			}
     			return this.m_E_Cost_TiZhiImage;
     		}
     	}

		public EventTrigger E_Cost_TiZhiEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Cost_TiZhiEventTrigger == null )
     			{
		    		this.m_E_Cost_TiZhiEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_TiZhi/E_Cost_TiZhi");
     			}
     			return this.m_E_Cost_TiZhiEventTrigger;
     		}
     	}

		public Text E_Value_NaiLiText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Value_NaiLiText == null )
     			{
		    		this.m_E_Value_NaiLiText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_NaiLi/E_Value_NaiLi");
     			}
     			return this.m_E_Value_NaiLiText;
     		}
     	}

		public Button E_Add_NaiLiButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Add_NaiLiButton == null )
     			{
		    		this.m_E_Add_NaiLiButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_NaiLi/E_Add_NaiLi");
     			}
     			return this.m_E_Add_NaiLiButton;
     		}
     	}

		public Image E_Add_NaiLiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Add_NaiLiImage == null )
     			{
		    		this.m_E_Add_NaiLiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_NaiLi/E_Add_NaiLi");
     			}
     			return this.m_E_Add_NaiLiImage;
     		}
     	}

		public EventTrigger E_Add_NaiLiEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Add_NaiLiEventTrigger == null )
     			{
		    		this.m_E_Add_NaiLiEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_NaiLi/E_Add_NaiLi");
     			}
     			return this.m_E_Add_NaiLiEventTrigger;
     		}
     	}

		public Button E_Cost_NaiLiButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Cost_NaiLiButton == null )
     			{
		    		this.m_E_Cost_NaiLiButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_NaiLi/E_Cost_NaiLi");
     			}
     			return this.m_E_Cost_NaiLiButton;
     		}
     	}

		public Image E_Cost_NaiLiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Cost_NaiLiImage == null )
     			{
		    		this.m_E_Cost_NaiLiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_NaiLi/E_Cost_NaiLi");
     			}
     			return this.m_E_Cost_NaiLiImage;
     		}
     	}

		public EventTrigger E_Cost_NaiLiEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Cost_NaiLiEventTrigger == null )
     			{
		    		this.m_E_Cost_NaiLiEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_NaiLi/E_Cost_NaiLi");
     			}
     			return this.m_E_Cost_NaiLiEventTrigger;
     		}
     	}

		public Text E_Value_MingJieText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Value_MingJieText == null )
     			{
		    		this.m_E_Value_MingJieText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_MingJie/E_Value_MingJie");
     			}
     			return this.m_E_Value_MingJieText;
     		}
     	}

		public Button E_Add_MingJieButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Add_MingJieButton == null )
     			{
		    		this.m_E_Add_MingJieButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_MingJie/E_Add_MingJie");
     			}
     			return this.m_E_Add_MingJieButton;
     		}
     	}

		public Image E_Add_MingJieImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Add_MingJieImage == null )
     			{
		    		this.m_E_Add_MingJieImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_MingJie/E_Add_MingJie");
     			}
     			return this.m_E_Add_MingJieImage;
     		}
     	}

		public EventTrigger E_Add_MingJieEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Add_MingJieEventTrigger == null )
     			{
		    		this.m_E_Add_MingJieEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_MingJie/E_Add_MingJie");
     			}
     			return this.m_E_Add_MingJieEventTrigger;
     		}
     	}

		public Button E_Cost_MingJieButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Cost_MingJieButton == null )
     			{
		    		this.m_E_Cost_MingJieButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_MingJie/E_Cost_MingJie");
     			}
     			return this.m_E_Cost_MingJieButton;
     		}
     	}

		public Image E_Cost_MingJieImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Cost_MingJieImage == null )
     			{
		    		this.m_E_Cost_MingJieImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_MingJie/E_Cost_MingJie");
     			}
     			return this.m_E_Cost_MingJieImage;
     		}
     	}

		public EventTrigger E_Cost_MingJieEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Cost_MingJieEventTrigger == null )
     			{
		    		this.m_E_Cost_MingJieEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_MingJie/E_Cost_MingJie");
     			}
     			return this.m_E_Cost_MingJieEventTrigger;
     		}
     	}

		public Button E_RecommendAddPointButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RecommendAddPointButton == null )
     			{
		    		this.m_E_RecommendAddPointButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/E_RecommendAddPoint");
     			}
     			return this.m_E_RecommendAddPointButton;
     		}
     	}

		public Image E_RecommendAddPointImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RecommendAddPointImage == null )
     			{
		    		this.m_E_RecommendAddPointImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/E_RecommendAddPoint");
     			}
     			return this.m_E_RecommendAddPointImage;
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
			this.m_EG_AttributeNodeRectTransform = null;
			this.m_E_PiLaoImgImage = null;
			this.m_E_PiLaoTextText = null;
			this.m_E_BaoShiDuImgImage = null;
			this.m_E_BaoShiDuTextText = null;
			this.m_E_BtnItemTypeSetToggleGroup = null;
			this.m_E_RolePropertyTeShuItemsLoopVerticalScrollRect = null;
			this.m_E_AddPointButton = null;
			this.m_E_AddPointImage = null;
			this.m_EG_RoleAddPointRectTransform = null;
			this.m_E_ShengYuNumText = null;
			this.m_E_AddPointConfirmButton = null;
			this.m_E_AddPointConfirmImage = null;
			this.m_E_CloseAddPointButton = null;
			this.m_E_CloseAddPointImage = null;
			this.m_E_Value_LiLiangText = null;
			this.m_E_Add_LiLiangButton = null;
			this.m_E_Add_LiLiangImage = null;
			this.m_E_Add_LiLiangEventTrigger = null;
			this.m_E_Cost_LiLiangButton = null;
			this.m_E_Cost_LiLiangImage = null;
			this.m_E_Cost_LiLiangEventTrigger = null;
			this.m_E_Value_ZhiLiText = null;
			this.m_E_Add_ZhiLiButton = null;
			this.m_E_Add_ZhiLiImage = null;
			this.m_E_Add_ZhiLiEventTrigger = null;
			this.m_E_Cost_ZhiLiButton = null;
			this.m_E_Cost_ZhiLiImage = null;
			this.m_E_Cost_ZhiLiEventTrigger = null;
			this.m_E_Value_TiZhiText = null;
			this.m_E_Add_TiZhiButton = null;
			this.m_E_Add_TiZhiImage = null;
			this.m_E_Add_TiZhiEventTrigger = null;
			this.m_E_Cost_TiZhiButton = null;
			this.m_E_Cost_TiZhiImage = null;
			this.m_E_Cost_TiZhiEventTrigger = null;
			this.m_E_Value_NaiLiText = null;
			this.m_E_Add_NaiLiButton = null;
			this.m_E_Add_NaiLiImage = null;
			this.m_E_Add_NaiLiEventTrigger = null;
			this.m_E_Cost_NaiLiButton = null;
			this.m_E_Cost_NaiLiImage = null;
			this.m_E_Cost_NaiLiEventTrigger = null;
			this.m_E_Value_MingJieText = null;
			this.m_E_Add_MingJieButton = null;
			this.m_E_Add_MingJieImage = null;
			this.m_E_Add_MingJieEventTrigger = null;
			this.m_E_Cost_MingJieButton = null;
			this.m_E_Cost_MingJieImage = null;
			this.m_E_Cost_MingJieEventTrigger = null;
			this.m_E_RecommendAddPointButton = null;
			this.m_E_RecommendAddPointImage = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_AttributeNodeRectTransform = null;
		private Image m_E_PiLaoImgImage = null;
		private Text m_E_PiLaoTextText = null;
		private Image m_E_BaoShiDuImgImage = null;
		private Text m_E_BaoShiDuTextText = null;
		private ToggleGroup m_E_BtnItemTypeSetToggleGroup = null;
		private LoopVerticalScrollRect m_E_RolePropertyTeShuItemsLoopVerticalScrollRect = null;
		private Button m_E_AddPointButton = null;
		private Image m_E_AddPointImage = null;
		private RectTransform m_EG_RoleAddPointRectTransform = null;
		private Text m_E_ShengYuNumText = null;
		private Button m_E_AddPointConfirmButton = null;
		private Image m_E_AddPointConfirmImage = null;
		private Button m_E_CloseAddPointButton = null;
		private Image m_E_CloseAddPointImage = null;
		private Text m_E_Value_LiLiangText = null;
		private Button m_E_Add_LiLiangButton = null;
		private Image m_E_Add_LiLiangImage = null;
		private EventTrigger m_E_Add_LiLiangEventTrigger = null;
		private Button m_E_Cost_LiLiangButton = null;
		private Image m_E_Cost_LiLiangImage = null;
		private EventTrigger m_E_Cost_LiLiangEventTrigger = null;
		private Text m_E_Value_ZhiLiText = null;
		private Button m_E_Add_ZhiLiButton = null;
		private Image m_E_Add_ZhiLiImage = null;
		private EventTrigger m_E_Add_ZhiLiEventTrigger = null;
		private Button m_E_Cost_ZhiLiButton = null;
		private Image m_E_Cost_ZhiLiImage = null;
		private EventTrigger m_E_Cost_ZhiLiEventTrigger = null;
		private Text m_E_Value_TiZhiText = null;
		private Button m_E_Add_TiZhiButton = null;
		private Image m_E_Add_TiZhiImage = null;
		private EventTrigger m_E_Add_TiZhiEventTrigger = null;
		private Button m_E_Cost_TiZhiButton = null;
		private Image m_E_Cost_TiZhiImage = null;
		private EventTrigger m_E_Cost_TiZhiEventTrigger = null;
		private Text m_E_Value_NaiLiText = null;
		private Button m_E_Add_NaiLiButton = null;
		private Image m_E_Add_NaiLiImage = null;
		private EventTrigger m_E_Add_NaiLiEventTrigger = null;
		private Button m_E_Cost_NaiLiButton = null;
		private Image m_E_Cost_NaiLiImage = null;
		private EventTrigger m_E_Cost_NaiLiEventTrigger = null;
		private Text m_E_Value_MingJieText = null;
		private Button m_E_Add_MingJieButton = null;
		private Image m_E_Add_MingJieImage = null;
		private EventTrigger m_E_Add_MingJieEventTrigger = null;
		private Button m_E_Cost_MingJieButton = null;
		private Image m_E_Cost_MingJieImage = null;
		private EventTrigger m_E_Cost_MingJieEventTrigger = null;
		private Button m_E_RecommendAddPointButton = null;
		private Image m_E_RecommendAddPointImage = null;
		public Transform uiTransform = null;
	}
}
