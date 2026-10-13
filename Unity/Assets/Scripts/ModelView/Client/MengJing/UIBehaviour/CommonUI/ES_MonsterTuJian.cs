
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_MonsterTuJian : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public GameObject LeftContent;
		public GameObject ChapterTemplate;
		public GameObject MonsterListTemplate;
		public readonly Dictionary<int, GameObject> ChapterHeaders = new();
		public readonly Dictionary<int, GameObject> ChapterMonsterLists = new();
		public readonly Dictionary<int, List<int>> ChapterMonsters = new();
		public readonly Dictionary<int, List<GameObject>> MonsterItems = new();
		public readonly HashSet<int> InitializedChapters = new();
		public readonly List<EntityRef<Scroll_Item_CommonSkillItem>> SkillItems = new();
		public readonly List<EntityRef<Scroll_Item_CommonItem>> RewardItems = new();
		public int SelectedChapterId;
		public int SelectedMonsterId;

		public UnityEngine.UI.Text E_Text_NameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_NameText == null )
     			{
		    		this.m_E_Text_NameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_Name");
     			}
     			return this.m_E_Text_NameText;
     		}
     	}

		public UnityEngine.UI.Text E_MonsterTypeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MonsterTypeText == null )
     			{
		    		this.m_E_MonsterTypeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_MonsterType");
     			}
     			return this.m_E_MonsterTypeText;
     		}
     	}

		public UnityEngine.UI.Text E_BackstoryText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BackstoryText == null )
     			{
		    		this.m_E_BackstoryText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Backstory");
     			}
     			return this.m_E_BackstoryText;
     		}
     	}

		public ES_ModelShow ES_ModelShow
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_ModelShow es = this.m_es_modelshow;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_ModelShow");
		    	   this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow;
     		}
     	}

		public UnityEngine.UI.ScrollRect E_CommonSkillItemsScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CommonSkillItemsScrollRect == null )
     			{
		    		this.m_E_CommonSkillItemsScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.ScrollRect>(this.uiTransform.gameObject,"Right/E_CommonSkillItems");
     			}
     			return this.m_E_CommonSkillItemsScrollRect;
     		}
     	}

		public UnityEngine.UI.ScrollRect E_RewardListScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RewardListScrollRect == null )
     			{
		    		this.m_E_RewardListScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.ScrollRect>(this.uiTransform.gameObject,"Right/E_RewardList");
     			}
     			return this.m_E_RewardListScrollRect;
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
			this.LeftContent = null;
			this.ChapterTemplate = null;
			this.MonsterListTemplate = null;
			this.ChapterHeaders.Clear();
			this.ChapterMonsterLists.Clear();
			this.ChapterMonsters.Clear();
			this.MonsterItems.Clear();
			this.InitializedChapters.Clear();
			this.SkillItems.Clear();
			this.RewardItems.Clear();
			this.m_E_Text_NameText = null;
			this.m_E_MonsterTypeText = null;
			this.m_E_BackstoryText = null;
			this.m_es_modelshow = null;
			this.m_E_CommonSkillItemsScrollRect = null;
			this.m_E_RewardListScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Text m_E_Text_NameText = null;
		private UnityEngine.UI.Text m_E_MonsterTypeText = null;
		private UnityEngine.UI.Text m_E_BackstoryText = null;
		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private UnityEngine.UI.ScrollRect m_E_CommonSkillItemsScrollRect = null;
		private UnityEngine.UI.ScrollRect m_E_RewardListScrollRect = null;
		public Transform uiTransform = null;
	}
}
