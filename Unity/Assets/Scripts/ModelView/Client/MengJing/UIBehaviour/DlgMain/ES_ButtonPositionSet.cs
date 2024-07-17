using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ButtonPositionSet : Entity,IAwake<Transform>,IDestroy
	{
		public GameObject SkillIconItemCopy;
		public List<Vector2> SkillPositionList = new();
		public List<Vector2> InitPositionList = new();
		public List<Vector2> TempPositionList = new();

		public List<EntityRef<UISkillDragComponent>> UISkillDragList = new();
		public GameObject UIMain;
		public int CurDragIndex;
		
		public Image E_SkillPositionSetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillPositionSetImage == null )
     			{
		    		this.m_E_SkillPositionSetImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_SkillPositionSet");
     			}
     			return this.m_E_SkillPositionSetImage;
     		}
     	}

		public Image E_ImageSkillPositionSetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageSkillPositionSetImage == null )
     			{
		    		this.m_E_ImageSkillPositionSetImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_SkillPositionSet/E_ImageSkillPositionSet");
     			}
     			return this.m_E_ImageSkillPositionSetImage;
     		}
     	}

		public Image E_LeftBottomBtnsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LeftBottomBtnsImage == null )
     			{
		    		this.m_E_LeftBottomBtnsImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_LeftBottomBtns");
     			}
     			return this.m_E_LeftBottomBtnsImage;
     		}
     	}

		public Image E_ImageLeftBottomBtnsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageLeftBottomBtnsImage == null )
     			{
		    		this.m_E_ImageLeftBottomBtnsImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_LeftBottomBtns/E_ImageLeftBottomBtns");
     			}
     			return this.m_E_ImageLeftBottomBtnsImage;
     		}
     	}

		public Button E_Btn_SkilPositionSaveButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_SkilPositionSaveButton == null )
     			{
		    		this.m_E_Btn_SkilPositionSaveButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_SkilPositionSave");
     			}
     			return this.m_E_Btn_SkilPositionSaveButton;
     		}
     	}

		public Image E_Btn_SkilPositionSaveImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_SkilPositionSaveImage == null )
     			{
		    		this.m_E_Btn_SkilPositionSaveImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_SkilPositionSave");
     			}
     			return this.m_E_Btn_SkilPositionSaveImage;
     		}
     	}

		public Button E_Btn_SkilPositionCancelButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_SkilPositionCancelButton == null )
     			{
		    		this.m_E_Btn_SkilPositionCancelButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_SkilPositionCancel");
     			}
     			return this.m_E_Btn_SkilPositionCancelButton;
     		}
     	}

		public Image E_Btn_SkilPositionCancelImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_SkilPositionCancelImage == null )
     			{
		    		this.m_E_Btn_SkilPositionCancelImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_SkilPositionCancel");
     			}
     			return this.m_E_Btn_SkilPositionCancelImage;
     		}
     	}

		public Button E_Btn_SkilPositionResetButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_SkilPositionResetButton == null )
     			{
		    		this.m_E_Btn_SkilPositionResetButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_SkilPositionReset");
     			}
     			return this.m_E_Btn_SkilPositionResetButton;
     		}
     	}

		public Image E_Btn_SkilPositionResetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_SkilPositionResetImage == null )
     			{
		    		this.m_E_Btn_SkilPositionResetImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_SkilPositionReset");
     			}
     			return this.m_E_Btn_SkilPositionResetImage;
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
			this.m_E_SkillPositionSetImage = null;
			this.m_E_ImageSkillPositionSetImage = null;
			this.m_E_LeftBottomBtnsImage = null;
			this.m_E_ImageLeftBottomBtnsImage = null;
			this.m_E_Btn_SkilPositionSaveButton = null;
			this.m_E_Btn_SkilPositionSaveImage = null;
			this.m_E_Btn_SkilPositionCancelButton = null;
			this.m_E_Btn_SkilPositionCancelImage = null;
			this.m_E_Btn_SkilPositionResetButton = null;
			this.m_E_Btn_SkilPositionResetImage = null;
			this.uiTransform = null;
		}

		private Image m_E_SkillPositionSetImage = null;
		private Image m_E_ImageSkillPositionSetImage = null;
		private Image m_E_LeftBottomBtnsImage = null;
		private Image m_E_ImageLeftBottomBtnsImage = null;
		private Button m_E_Btn_SkilPositionSaveButton = null;
		private Image m_E_Btn_SkilPositionSaveImage = null;
		private Button m_E_Btn_SkilPositionCancelButton = null;
		private Image m_E_Btn_SkilPositionCancelImage = null;
		private Button m_E_Btn_SkilPositionResetButton = null;
		private Image m_E_Btn_SkilPositionResetImage = null;
		public Transform uiTransform = null;
	}
}
