using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_DonationShowItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_DonationShowItem>
	{
		public RankingInfo RankingInfo;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_DonationShowItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Image E_ImageHeadIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_ImageHeadIconImage == null )
     				{
		    			this.m_E_ImageHeadIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageHeadIcon");
     				}
     				return this.m_E_ImageHeadIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageHeadIcon");
     			}
     		}
     	}

		public Text E_Text_RankText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_Text_RankText == null )
     				{
		    			this.m_E_Text_RankText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Rank");
     				}
     				return this.m_E_Text_RankText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Rank");
     			}
     		}
     	}

		public Text E_Text_NameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_Text_NameText == null )
     				{
		    			this.m_E_Text_NameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Name");
     				}
     				return this.m_E_Text_NameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Name");
     			}
     		}
     	}

		public Text E_Text_DonationText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_Text_DonationText == null )
     				{
		    			this.m_E_Text_DonationText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Donation");
     				}
     				return this.m_E_Text_DonationText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Donation");
     			}
     		}
     	}

		public Text E_Text_CombatText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_Text_CombatText == null )
     				{
		    			this.m_E_Text_CombatText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Combat");
     				}
     				return this.m_E_Text_CombatText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Combat");
     			}
     		}
     	}

		public Button E_Button_WatchEquipButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_Button_WatchEquipButton == null )
     				{
		    			this.m_E_Button_WatchEquipButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button_WatchEquip");
     				}
     				return this.m_E_Button_WatchEquipButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button_WatchEquip");
     			}
     		}
     	}

		public Image E_Button_WatchEquipImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_Button_WatchEquipImage == null )
     				{
		    			this.m_E_Button_WatchEquipImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button_WatchEquip");
     				}
     				return this.m_E_Button_WatchEquipImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button_WatchEquip");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageHeadIconImage = null;
			this.m_E_Text_RankText = null;
			this.m_E_Text_NameText = null;
			this.m_E_Text_DonationText = null;
			this.m_E_Text_CombatText = null;
			this.m_E_Button_WatchEquipButton = null;
			this.m_E_Button_WatchEquipImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Image m_E_ImageHeadIconImage = null;
		private Text m_E_Text_RankText = null;
		private Text m_E_Text_NameText = null;
		private Text m_E_Text_DonationText = null;
		private Text m_E_Text_CombatText = null;
		private Button m_E_Button_WatchEquipButton = null;
		private Image m_E_Button_WatchEquipImage = null;
		public Transform uiTransform = null;
	}
}
