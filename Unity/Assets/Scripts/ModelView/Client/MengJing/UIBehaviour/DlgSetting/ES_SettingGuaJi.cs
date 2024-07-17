using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_SettingGuaJi : Entity,IAwake<Transform>,IDestroy
	{
		public List<int> SkillSet = new();
		public List<GameObject> SkillSetIconRightList = new();
		
		public Button E_Btn_Click_0Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_Click_0Button == null )
     			{
		    		this.m_E_Btn_Click_0Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"UIGameSetting/ShiQuSet/E_Btn_Click_0");
     			}
     			return this.m_E_Btn_Click_0Button;
     		}
     	}

		public Image E_Btn_Click_0Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_Click_0Image == null )
     			{
		    		this.m_E_Btn_Click_0Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"UIGameSetting/ShiQuSet/E_Btn_Click_0");
     			}
     			return this.m_E_Btn_Click_0Image;
     		}
     	}

		public Image E_Image_Click_0Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Image_Click_0Image == null )
     			{
		    		this.m_E_Image_Click_0Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"UIGameSetting/ShiQuSet/E_Image_Click_0");
     			}
     			return this.m_E_Image_Click_0Image;
     		}
     	}

		public Button E_Btn_StartGuajIButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_StartGuajIButton == null )
     			{
		    		this.m_E_Btn_StartGuajIButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"UIGameSetting/E_Btn_StartGuajI");
     			}
     			return this.m_E_Btn_StartGuajIButton;
     		}
     	}

		public Image E_Btn_StartGuajIImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_StartGuajIImage == null )
     			{
		    		this.m_E_Btn_StartGuajIImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"UIGameSetting/E_Btn_StartGuajI");
     			}
     			return this.m_E_Btn_StartGuajIImage;
     		}
     	}

		public Button E_Btn_StopGuaJiButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_StopGuaJiButton == null )
     			{
		    		this.m_E_Btn_StopGuaJiButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"UIGameSetting/E_Btn_StopGuaJi");
     			}
     			return this.m_E_Btn_StopGuaJiButton;
     		}
     	}

		public Image E_Btn_StopGuaJiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_StopGuaJiImage == null )
     			{
		    		this.m_E_Btn_StopGuaJiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"UIGameSetting/E_Btn_StopGuaJi");
     			}
     			return this.m_E_Btn_StopGuaJiImage;
     		}
     	}

		public Button E_Btn_GuaJiRangeButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_GuaJiRangeButton == null )
     			{
		    		this.m_E_Btn_GuaJiRangeButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"UIGameSetting/GuaJiRangSetting/E_Btn_GuaJiRange");
     			}
     			return this.m_E_Btn_GuaJiRangeButton;
     		}
     	}

		public Image E_Btn_GuaJiRangeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_GuaJiRangeImage == null )
     			{
		    		this.m_E_Btn_GuaJiRangeImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"UIGameSetting/GuaJiRangSetting/E_Btn_GuaJiRange");
     			}
     			return this.m_E_Btn_GuaJiRangeImage;
     		}
     	}

		public Image E_Click_GuaJiRangeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Click_GuaJiRangeImage == null )
     			{
		    		this.m_E_Click_GuaJiRangeImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"UIGameSetting/GuaJiRangSetting/E_Click_GuaJiRange");
     			}
     			return this.m_E_Click_GuaJiRangeImage;
     		}
     	}

		public Button E_Btn_GuaJiAutoUseItemButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_GuaJiAutoUseItemButton == null )
     			{
		    		this.m_E_Btn_GuaJiAutoUseItemButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"UIGameSetting/AutoUseItemSetting/E_Btn_GuaJiAutoUseItem");
     			}
     			return this.m_E_Btn_GuaJiAutoUseItemButton;
     		}
     	}

		public Image E_Btn_GuaJiAutoUseItemImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_GuaJiAutoUseItemImage == null )
     			{
		    		this.m_E_Btn_GuaJiAutoUseItemImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"UIGameSetting/AutoUseItemSetting/E_Btn_GuaJiAutoUseItem");
     			}
     			return this.m_E_Btn_GuaJiAutoUseItemImage;
     		}
     	}

		public Image E_Click_GuaJiAutoUseItemImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Click_GuaJiAutoUseItemImage == null )
     			{
		    		this.m_E_Click_GuaJiAutoUseItemImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"UIGameSetting/AutoUseItemSetting/E_Click_GuaJiAutoUseItem");
     			}
     			return this.m_E_Click_GuaJiAutoUseItemImage;
     		}
     	}

		public RectTransform EG_SkillIconItemRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SkillIconItemRectTransform == null )
     			{
		    		this.m_EG_SkillIconItemRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"UIGameSetting/AutoUseSkillSetting/EG_SkillIconItem");
     			}
     			return this.m_EG_SkillIconItemRectTransform;
     		}
     	}

		public RectTransform EG_SkillIPositionSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SkillIPositionSetRectTransform == null )
     			{
		    		this.m_EG_SkillIPositionSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"UIGameSetting/AutoUseSkillSetting/EG_SkillIPositionSet");
     			}
     			return this.m_EG_SkillIPositionSetRectTransform;
     		}
     	}

		public Button E_Btn_EditSkillButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_EditSkillButton == null )
     			{
		    		this.m_E_Btn_EditSkillButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"UIGameSetting/AutoUseSkillSetting/E_Btn_EditSkill");
     			}
     			return this.m_E_Btn_EditSkillButton;
     		}
     	}

		public Image E_Btn_EditSkillImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_EditSkillImage == null )
     			{
		    		this.m_E_Btn_EditSkillImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"UIGameSetting/AutoUseSkillSetting/E_Btn_EditSkill");
     			}
     			return this.m_E_Btn_EditSkillImage;
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
			this.m_E_Btn_Click_0Button = null;
			this.m_E_Btn_Click_0Image = null;
			this.m_E_Image_Click_0Image = null;
			this.m_E_Btn_StartGuajIButton = null;
			this.m_E_Btn_StartGuajIImage = null;
			this.m_E_Btn_StopGuaJiButton = null;
			this.m_E_Btn_StopGuaJiImage = null;
			this.m_E_Btn_GuaJiRangeButton = null;
			this.m_E_Btn_GuaJiRangeImage = null;
			this.m_E_Click_GuaJiRangeImage = null;
			this.m_E_Btn_GuaJiAutoUseItemButton = null;
			this.m_E_Btn_GuaJiAutoUseItemImage = null;
			this.m_E_Click_GuaJiAutoUseItemImage = null;
			this.m_EG_SkillIconItemRectTransform = null;
			this.m_EG_SkillIPositionSetRectTransform = null;
			this.m_E_Btn_EditSkillButton = null;
			this.m_E_Btn_EditSkillImage = null;
			this.uiTransform = null;
		}

		private Button m_E_Btn_Click_0Button = null;
		private Image m_E_Btn_Click_0Image = null;
		private Image m_E_Image_Click_0Image = null;
		private Button m_E_Btn_StartGuajIButton = null;
		private Image m_E_Btn_StartGuajIImage = null;
		private Button m_E_Btn_StopGuaJiButton = null;
		private Image m_E_Btn_StopGuaJiImage = null;
		private Button m_E_Btn_GuaJiRangeButton = null;
		private Image m_E_Btn_GuaJiRangeImage = null;
		private Image m_E_Click_GuaJiRangeImage = null;
		private Button m_E_Btn_GuaJiAutoUseItemButton = null;
		private Image m_E_Btn_GuaJiAutoUseItemImage = null;
		private Image m_E_Click_GuaJiAutoUseItemImage = null;
		private RectTransform m_EG_SkillIconItemRectTransform = null;
		private RectTransform m_EG_SkillIPositionSetRectTransform = null;
		private Button m_E_Btn_EditSkillButton = null;
		private Image m_E_Btn_EditSkillImage = null;
		public Transform uiTransform = null;
	}
}
