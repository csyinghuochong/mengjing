
using System.Collections.Generic;
using UnityEngine;
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
		public int PropertyType;
		public Dictionary<int, EntityRef<Scroll_Item_RolePropertyTeShuItem>> ScrollItemRolePropertyTeShuItems;
		public Dictionary<int, EntityRef<Scroll_Item_RolePropertyBaseItem>> ScrollItemRolePropertyBaseItems;
		public List<ShowPropertyList> ShowPropertyList_Base = new();
		public List<ShowPropertyList> ShowPropertyList_TeShu = new();
		public List<ShowPropertyList> ShowPropertyList_KangXing = new();
		public List<ShowPropertyList> ShowPropertyLists;
		public List<int> PointList = new();
		public List<int> PointInit = new();
		public int PointRemain;
		public bool IsHoldDown;
		
		public UnityEngine.RectTransform EG_AttributeNodeRectTransform
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
		    		this.m_EG_AttributeNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_AttributeNode");
     			}
     			return this.m_EG_AttributeNodeRectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_PiLaoImgImage
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
		    		this.m_E_PiLaoImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_AttributeNode/ProSet/TiLi/E_PiLaoImg");
     			}
     			return this.m_E_PiLaoImgImage;
     		}
     	}

		public UnityEngine.UI.Text E_PiLaoTextText
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
		    		this.m_E_PiLaoTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_AttributeNode/ProSet/TiLi/E_PiLaoText");
     			}
     			return this.m_E_PiLaoTextText;
     		}
     	}

		public UnityEngine.UI.Image E_BaoShiDuImgImage
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
		    		this.m_E_BaoShiDuImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_AttributeNode/ProSet/Satiety/E_BaoShiDuImg");
     			}
     			return this.m_E_BaoShiDuImgImage;
     		}
     	}

		public UnityEngine.UI.Text E_BaoShiDuTextText
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
		    		this.m_E_BaoShiDuTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_AttributeNode/ProSet/Satiety/E_BaoShiDuText");
     			}
     			return this.m_E_BaoShiDuTextText;
     		}
     	}

		public UnityEngine.UI.ToggleGroup E_BtnItemTypeSetToggleGroup
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
		    		this.m_E_BtnItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Right/EG_AttributeNode/E_BtnItemTypeSet");
     			}
     			return this.m_E_BtnItemTypeSetToggleGroup;
     		}
     	}

		public UnityEngine.UI.Image E_RolePropertyBaseItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RolePropertyBaseItemsImage == null )
     			{
		    		this.m_E_RolePropertyBaseItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_AttributeNode/E_RolePropertyBaseItems");
     			}
     			return this.m_E_RolePropertyBaseItemsImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_RolePropertyBaseItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RolePropertyBaseItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_RolePropertyBaseItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/EG_AttributeNode/E_RolePropertyBaseItems");
     			}
     			return this.m_E_RolePropertyBaseItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_RolePropertyTeShuItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RolePropertyTeShuItemsImage == null )
     			{
		    		this.m_E_RolePropertyTeShuItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_AttributeNode/E_RolePropertyTeShuItems");
     			}
     			return this.m_E_RolePropertyTeShuItemsImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_RolePropertyTeShuItemsLoopVerticalScrollRect
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
		    		this.m_E_RolePropertyTeShuItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/EG_AttributeNode/E_RolePropertyTeShuItems");
     			}
     			return this.m_E_RolePropertyTeShuItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_LuckExplainButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LuckExplainButton == null )
     			{
		    		this.m_E_LuckExplainButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_AttributeNode/E_LuckExplain");
     			}
     			return this.m_E_LuckExplainButton;
     		}
     	}

		public UnityEngine.UI.Image E_LuckExplainImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LuckExplainImage == null )
     			{
		    		this.m_E_LuckExplainImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_AttributeNode/E_LuckExplain");
     			}
     			return this.m_E_LuckExplainImage;
     		}
     	}

		public UnityEngine.UI.Button E_AddPointButton
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
		    		this.m_E_AddPointButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_AttributeNode/E_AddPoint");
     			}
     			return this.m_E_AddPointButton;
     		}
     	}

		public UnityEngine.UI.Image E_AddPointImage
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
		    		this.m_E_AddPointImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_AttributeNode/E_AddPoint");
     			}
     			return this.m_E_AddPointImage;
     		}
     	}

		public UnityEngine.RectTransform EG_RoleAddPointRectTransform
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
		    		this.m_EG_RoleAddPointRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint");
     			}
     			return this.m_EG_RoleAddPointRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_ShengYuNumText
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
		    		this.m_E_ShengYuNumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/E_ShengYuNum");
     			}
     			return this.m_E_ShengYuNumText;
     		}
     	}

		public UnityEngine.UI.Button E_AddPointConfirmButton
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
		    		this.m_E_AddPointConfirmButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/E_AddPointConfirm");
     			}
     			return this.m_E_AddPointConfirmButton;
     		}
     	}

		public UnityEngine.UI.Image E_AddPointConfirmImage
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
		    		this.m_E_AddPointConfirmImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/E_AddPointConfirm");
     			}
     			return this.m_E_AddPointConfirmImage;
     		}
     	}

		public UnityEngine.UI.Button E_CloseAddPointButton
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
		    		this.m_E_CloseAddPointButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/E_CloseAddPoint");
     			}
     			return this.m_E_CloseAddPointButton;
     		}
     	}

		public UnityEngine.UI.Image E_CloseAddPointImage
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
		    		this.m_E_CloseAddPointImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/E_CloseAddPoint");
     			}
     			return this.m_E_CloseAddPointImage;
     		}
     	}

		public UnityEngine.UI.Text E_Value_LiLiangText
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
		    		this.m_E_Value_LiLiangText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_LiLiang/E_Value_LiLiang");
     			}
     			return this.m_E_Value_LiLiangText;
     		}
     	}

		public UnityEngine.UI.Button E_Add_LiLiangButton
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
		    		this.m_E_Add_LiLiangButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_LiLiang/E_Add_LiLiang");
     			}
     			return this.m_E_Add_LiLiangButton;
     		}
     	}

		public UnityEngine.UI.Image E_Add_LiLiangImage
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
		    		this.m_E_Add_LiLiangImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_LiLiang/E_Add_LiLiang");
     			}
     			return this.m_E_Add_LiLiangImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Add_LiLiangEventTrigger
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
		    		this.m_E_Add_LiLiangEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_LiLiang/E_Add_LiLiang");
     			}
     			return this.m_E_Add_LiLiangEventTrigger;
     		}
     	}

		public UnityEngine.UI.Button E_Cost_LiLiangButton
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
		    		this.m_E_Cost_LiLiangButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_LiLiang/E_Cost_LiLiang");
     			}
     			return this.m_E_Cost_LiLiangButton;
     		}
     	}

		public UnityEngine.UI.Image E_Cost_LiLiangImage
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
		    		this.m_E_Cost_LiLiangImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_LiLiang/E_Cost_LiLiang");
     			}
     			return this.m_E_Cost_LiLiangImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Cost_LiLiangEventTrigger
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
		    		this.m_E_Cost_LiLiangEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_LiLiang/E_Cost_LiLiang");
     			}
     			return this.m_E_Cost_LiLiangEventTrigger;
     		}
     	}

		public UnityEngine.UI.Text E_Value_ZhiLiText
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
		    		this.m_E_Value_ZhiLiText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_ZhiLi/E_Value_ZhiLi");
     			}
     			return this.m_E_Value_ZhiLiText;
     		}
     	}

		public UnityEngine.UI.Button E_Add_ZhiLiButton
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
		    		this.m_E_Add_ZhiLiButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_ZhiLi/E_Add_ZhiLi");
     			}
     			return this.m_E_Add_ZhiLiButton;
     		}
     	}

		public UnityEngine.UI.Image E_Add_ZhiLiImage
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
		    		this.m_E_Add_ZhiLiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_ZhiLi/E_Add_ZhiLi");
     			}
     			return this.m_E_Add_ZhiLiImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Add_ZhiLiEventTrigger
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
		    		this.m_E_Add_ZhiLiEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_ZhiLi/E_Add_ZhiLi");
     			}
     			return this.m_E_Add_ZhiLiEventTrigger;
     		}
     	}

		public UnityEngine.UI.Button E_Cost_ZhiLiButton
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
		    		this.m_E_Cost_ZhiLiButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_ZhiLi/E_Cost_ZhiLi");
     			}
     			return this.m_E_Cost_ZhiLiButton;
     		}
     	}

		public UnityEngine.UI.Image E_Cost_ZhiLiImage
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
		    		this.m_E_Cost_ZhiLiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_ZhiLi/E_Cost_ZhiLi");
     			}
     			return this.m_E_Cost_ZhiLiImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Cost_ZhiLiEventTrigger
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
		    		this.m_E_Cost_ZhiLiEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_ZhiLi/E_Cost_ZhiLi");
     			}
     			return this.m_E_Cost_ZhiLiEventTrigger;
     		}
     	}

		public UnityEngine.UI.Text E_Value_TiZhiText
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
		    		this.m_E_Value_TiZhiText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_TiZhi/E_Value_TiZhi");
     			}
     			return this.m_E_Value_TiZhiText;
     		}
     	}

		public UnityEngine.UI.Button E_Add_TiZhiButton
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
		    		this.m_E_Add_TiZhiButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_TiZhi/E_Add_TiZhi");
     			}
     			return this.m_E_Add_TiZhiButton;
     		}
     	}

		public UnityEngine.UI.Image E_Add_TiZhiImage
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
		    		this.m_E_Add_TiZhiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_TiZhi/E_Add_TiZhi");
     			}
     			return this.m_E_Add_TiZhiImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Add_TiZhiEventTrigger
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
		    		this.m_E_Add_TiZhiEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_TiZhi/E_Add_TiZhi");
     			}
     			return this.m_E_Add_TiZhiEventTrigger;
     		}
     	}

		public UnityEngine.UI.Button E_Cost_TiZhiButton
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
		    		this.m_E_Cost_TiZhiButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_TiZhi/E_Cost_TiZhi");
     			}
     			return this.m_E_Cost_TiZhiButton;
     		}
     	}

		public UnityEngine.UI.Image E_Cost_TiZhiImage
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
		    		this.m_E_Cost_TiZhiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_TiZhi/E_Cost_TiZhi");
     			}
     			return this.m_E_Cost_TiZhiImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Cost_TiZhiEventTrigger
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
		    		this.m_E_Cost_TiZhiEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_TiZhi/E_Cost_TiZhi");
     			}
     			return this.m_E_Cost_TiZhiEventTrigger;
     		}
     	}

		public UnityEngine.UI.Text E_Value_NaiLiText
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
		    		this.m_E_Value_NaiLiText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_NaiLi/E_Value_NaiLi");
     			}
     			return this.m_E_Value_NaiLiText;
     		}
     	}

		public UnityEngine.UI.Button E_Add_NaiLiButton
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
		    		this.m_E_Add_NaiLiButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_NaiLi/E_Add_NaiLi");
     			}
     			return this.m_E_Add_NaiLiButton;
     		}
     	}

		public UnityEngine.UI.Image E_Add_NaiLiImage
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
		    		this.m_E_Add_NaiLiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_NaiLi/E_Add_NaiLi");
     			}
     			return this.m_E_Add_NaiLiImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Add_NaiLiEventTrigger
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
		    		this.m_E_Add_NaiLiEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_NaiLi/E_Add_NaiLi");
     			}
     			return this.m_E_Add_NaiLiEventTrigger;
     		}
     	}

		public UnityEngine.UI.Button E_Cost_NaiLiButton
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
		    		this.m_E_Cost_NaiLiButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_NaiLi/E_Cost_NaiLi");
     			}
     			return this.m_E_Cost_NaiLiButton;
     		}
     	}

		public UnityEngine.UI.Image E_Cost_NaiLiImage
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
		    		this.m_E_Cost_NaiLiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_NaiLi/E_Cost_NaiLi");
     			}
     			return this.m_E_Cost_NaiLiImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Cost_NaiLiEventTrigger
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
		    		this.m_E_Cost_NaiLiEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_NaiLi/E_Cost_NaiLi");
     			}
     			return this.m_E_Cost_NaiLiEventTrigger;
     		}
     	}

		public UnityEngine.UI.Text E_Value_MingJieText
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
		    		this.m_E_Value_MingJieText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_MingJie/E_Value_MingJie");
     			}
     			return this.m_E_Value_MingJieText;
     		}
     	}

		public UnityEngine.UI.Button E_Add_MingJieButton
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
		    		this.m_E_Add_MingJieButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_MingJie/E_Add_MingJie");
     			}
     			return this.m_E_Add_MingJieButton;
     		}
     	}

		public UnityEngine.UI.Image E_Add_MingJieImage
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
		    		this.m_E_Add_MingJieImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_MingJie/E_Add_MingJie");
     			}
     			return this.m_E_Add_MingJieImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Add_MingJieEventTrigger
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
		    		this.m_E_Add_MingJieEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_MingJie/E_Add_MingJie");
     			}
     			return this.m_E_Add_MingJieEventTrigger;
     		}
     	}

		public UnityEngine.UI.Button E_Cost_MingJieButton
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
		    		this.m_E_Cost_MingJieButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_MingJie/E_Cost_MingJie");
     			}
     			return this.m_E_Cost_MingJieButton;
     		}
     	}

		public UnityEngine.UI.Image E_Cost_MingJieImage
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
		    		this.m_E_Cost_MingJieImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_MingJie/E_Cost_MingJie");
     			}
     			return this.m_E_Cost_MingJieImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Cost_MingJieEventTrigger
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
		    		this.m_E_Cost_MingJieEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/AddProperty_MingJie/E_Cost_MingJie");
     			}
     			return this.m_E_Cost_MingJieEventTrigger;
     		}
     	}

		public UnityEngine.UI.Button E_RecommendAddPointButton
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
		    		this.m_E_RecommendAddPointButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/E_RecommendAddPoint");
     			}
     			return this.m_E_RecommendAddPointButton;
     		}
     	}

		public UnityEngine.UI.Image E_RecommendAddPointImage
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
		    		this.m_E_RecommendAddPointImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_RoleAddPoint/E_RecommendAddPoint");
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
			this.m_E_RolePropertyBaseItemsImage = null;
			this.m_E_RolePropertyBaseItemsLoopVerticalScrollRect = null;
			this.m_E_RolePropertyTeShuItemsImage = null;
			this.m_E_RolePropertyTeShuItemsLoopVerticalScrollRect = null;
			this.m_E_LuckExplainButton = null;
			this.m_E_LuckExplainImage = null;
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

		private UnityEngine.RectTransform m_EG_AttributeNodeRectTransform = null;
		private UnityEngine.UI.Image m_E_PiLaoImgImage = null;
		private UnityEngine.UI.Text m_E_PiLaoTextText = null;
		private UnityEngine.UI.Image m_E_BaoShiDuImgImage = null;
		private UnityEngine.UI.Text m_E_BaoShiDuTextText = null;
		private UnityEngine.UI.ToggleGroup m_E_BtnItemTypeSetToggleGroup = null;
		private UnityEngine.UI.Image m_E_RolePropertyBaseItemsImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_RolePropertyBaseItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Image m_E_RolePropertyTeShuItemsImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_RolePropertyTeShuItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_LuckExplainButton = null;
		private UnityEngine.UI.Image m_E_LuckExplainImage = null;
		private UnityEngine.UI.Button m_E_AddPointButton = null;
		private UnityEngine.UI.Image m_E_AddPointImage = null;
		private UnityEngine.RectTransform m_EG_RoleAddPointRectTransform = null;
		private UnityEngine.UI.Text m_E_ShengYuNumText = null;
		private UnityEngine.UI.Button m_E_AddPointConfirmButton = null;
		private UnityEngine.UI.Image m_E_AddPointConfirmImage = null;
		private UnityEngine.UI.Button m_E_CloseAddPointButton = null;
		private UnityEngine.UI.Image m_E_CloseAddPointImage = null;
		private UnityEngine.UI.Text m_E_Value_LiLiangText = null;
		private UnityEngine.UI.Button m_E_Add_LiLiangButton = null;
		private UnityEngine.UI.Image m_E_Add_LiLiangImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Add_LiLiangEventTrigger = null;
		private UnityEngine.UI.Button m_E_Cost_LiLiangButton = null;
		private UnityEngine.UI.Image m_E_Cost_LiLiangImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Cost_LiLiangEventTrigger = null;
		private UnityEngine.UI.Text m_E_Value_ZhiLiText = null;
		private UnityEngine.UI.Button m_E_Add_ZhiLiButton = null;
		private UnityEngine.UI.Image m_E_Add_ZhiLiImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Add_ZhiLiEventTrigger = null;
		private UnityEngine.UI.Button m_E_Cost_ZhiLiButton = null;
		private UnityEngine.UI.Image m_E_Cost_ZhiLiImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Cost_ZhiLiEventTrigger = null;
		private UnityEngine.UI.Text m_E_Value_TiZhiText = null;
		private UnityEngine.UI.Button m_E_Add_TiZhiButton = null;
		private UnityEngine.UI.Image m_E_Add_TiZhiImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Add_TiZhiEventTrigger = null;
		private UnityEngine.UI.Button m_E_Cost_TiZhiButton = null;
		private UnityEngine.UI.Image m_E_Cost_TiZhiImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Cost_TiZhiEventTrigger = null;
		private UnityEngine.UI.Text m_E_Value_NaiLiText = null;
		private UnityEngine.UI.Button m_E_Add_NaiLiButton = null;
		private UnityEngine.UI.Image m_E_Add_NaiLiImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Add_NaiLiEventTrigger = null;
		private UnityEngine.UI.Button m_E_Cost_NaiLiButton = null;
		private UnityEngine.UI.Image m_E_Cost_NaiLiImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Cost_NaiLiEventTrigger = null;
		private UnityEngine.UI.Text m_E_Value_MingJieText = null;
		private UnityEngine.UI.Button m_E_Add_MingJieButton = null;
		private UnityEngine.UI.Image m_E_Add_MingJieImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Add_MingJieEventTrigger = null;
		private UnityEngine.UI.Button m_E_Cost_MingJieButton = null;
		private UnityEngine.UI.Image m_E_Cost_MingJieImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Cost_MingJieEventTrigger = null;
		private UnityEngine.UI.Button m_E_RecommendAddPointButton = null;
		private UnityEngine.UI.Image m_E_RecommendAddPointImage = null;
		public Transform uiTransform = null;
	}
}
