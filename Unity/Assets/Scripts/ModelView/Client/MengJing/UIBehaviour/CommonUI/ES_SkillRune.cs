
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_SkillRune : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		/// <summary>
		/// 当前打开的是哪个技能的孔位
		/// </summary>
		public int SkillId;

		/// <summary>
		/// 当前打开的是第几个孔位（0 开始）
		/// </summary>
		public int SlotIndex;

		/// <summary>
		/// 符文列表里选中的符文id（SkillRuneInfo.Id），0 表示没选中
		/// </summary>
		public long SelectRuneId;

		/// <summary>
		/// 符文列表条目，按序号复用，多出来的隐藏
		/// </summary>
		public List<EntityRef<Scroll_Item_SkillRuneItem>> RuneItems = new();

		/// <summary>
		/// 加载过的资源，面板销毁时统一卸载
		/// </summary>
		public List<string> AssetList = new List<string>();

		public UnityEngine.UI.Image E_CloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseImage == null )
     			{
		    		this.m_E_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Close");
     			}
     			return this.m_E_CloseImage;
     		}
     	}

		public UnityEngine.UI.ScrollRect E_SkillRuneItemsScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillRuneItemsScrollRect == null )
     			{
		    		this.m_E_SkillRuneItemsScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.ScrollRect>(this.uiTransform.gameObject,"Left/E_SkillRuneItems");
     			}
     			return this.m_E_SkillRuneItemsScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_SkillRuneItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillRuneItemsImage == null )
     			{
		    		this.m_E_SkillRuneItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_SkillRuneItems");
     			}
     			return this.m_E_SkillRuneItemsImage;
     		}
     	}

		public UnityEngine.UI.Text E_RuneNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RuneNameText == null )
     			{
		    		this.m_E_RuneNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/E_RuneName");
     			}
     			return this.m_E_RuneNameText;
     		}
     	}

		public UnityEngine.UI.Text E_RuneLvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RuneLvText == null )
     			{
		    		this.m_E_RuneLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/E_RuneLv");
     			}
     			return this.m_E_RuneLvText;
     		}
     	}

		public UnityEngine.UI.Text E_RuneDesText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RuneDesText == null )
     			{
		    		this.m_E_RuneDesText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/E_RuneDes");
     			}
     			return this.m_E_RuneDesText;
     		}
     	}

		public UnityEngine.UI.Button E_UnequipRuneButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UnequipRuneButton == null )
     			{
		    		this.m_E_UnequipRuneButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_UnequipRune");
     			}
     			return this.m_E_UnequipRuneButton;
     		}
     	}

		public UnityEngine.UI.Image E_UnequipRuneImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UnequipRuneImage == null )
     			{
		    		this.m_E_UnequipRuneImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_UnequipRune");
     			}
     			return this.m_E_UnequipRuneImage;
     		}
     	}

		public UnityEngine.UI.Button E_EquipRuneButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipRuneButton == null )
     			{
		    		this.m_E_EquipRuneButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_EquipRune");
     			}
     			return this.m_E_EquipRuneButton;
     		}
     	}

		public UnityEngine.UI.Image E_EquipRuneImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipRuneImage == null )
     			{
		    		this.m_E_EquipRuneImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_EquipRune");
     			}
     			return this.m_E_EquipRuneImage;
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
			this.m_E_CloseImage = null;
			this.m_E_SkillRuneItemsScrollRect = null;
			this.m_E_SkillRuneItemsImage = null;
			this.m_E_RuneNameText = null;
			this.m_E_RuneLvText = null;
			this.m_E_RuneDesText = null;
			this.m_E_UnequipRuneButton = null;
			this.m_E_UnequipRuneImage = null;
			this.m_E_EquipRuneButton = null;
			this.m_E_EquipRuneImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_E_CloseImage = null;
		private UnityEngine.UI.ScrollRect m_E_SkillRuneItemsScrollRect = null;
		private UnityEngine.UI.Image m_E_SkillRuneItemsImage = null;
		private UnityEngine.UI.Text m_E_RuneNameText = null;
		private UnityEngine.UI.Text m_E_RuneLvText = null;
		private UnityEngine.UI.Text m_E_RuneDesText = null;
		private UnityEngine.UI.Button m_E_UnequipRuneButton = null;
		private UnityEngine.UI.Image m_E_UnequipRuneImage = null;
		private UnityEngine.UI.Button m_E_EquipRuneButton = null;
		private UnityEngine.UI.Image m_E_EquipRuneImage = null;
		public Transform uiTransform = null;
	}
}
