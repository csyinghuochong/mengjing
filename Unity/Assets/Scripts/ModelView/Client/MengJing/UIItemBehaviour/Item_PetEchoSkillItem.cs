
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_PetEchoSkillItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_PetEchoSkillItem> 
	{
		
		public int SkillId {get;set;}
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_PetEchoSkillItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Image E_ImageButtonImage
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
     				if( this.m_E_ImageButtonImage == null )
     				{
		    			this.m_E_ImageButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageButton");
     				}
     				return this.m_E_ImageButtonImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageButton");
     			}
     		}
     	}

		public ES_CommonSkillItem ES_CommonSkillItem_0
		{
			get
			{
				ES_CommonSkillItem es = this.m_ES_CommonSkillItem_0;
				if (es == null)
				{
					Transform go = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"E_SkillIcon");
					this.m_ES_CommonSkillItem_0 = this.AddChild<ES_CommonSkillItem, Transform>(go);
				}

				return this.m_ES_CommonSkillItem_0;
			}
		}
		

		public UnityEngine.UI.Image E_JianTouImage
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
     				if( this.m_E_JianTouImage == null )
     				{
		    			this.m_E_JianTouImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_JianTou");
     				}
     				return this.m_E_JianTouImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_JianTou");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Text_NameText
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
		    			this.m_E_Text_NameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Name");
     				}
     				return this.m_E_Text_NameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Name");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_Text_ComabtText
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
     				if( this.m_E_Text_ComabtText == null )
     				{
		    			this.m_E_Text_ComabtText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Comabt");
     				}
     				return this.m_E_Text_ComabtText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Comabt");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageButtonImage = null;
			this.m_E_JianTouImage = null;
			this.m_E_Text_NameText = null;
			this.m_E_Text_ComabtText = null;
			this.m_ES_CommonSkillItem_0 = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Image m_E_ImageButtonImage = null;
		private UnityEngine.UI.Image m_E_JianTouImage = null;
		private UnityEngine.UI.Text m_E_Text_NameText = null;
		private UnityEngine.UI.Text m_E_Text_ComabtText = null;
		private EntityRef<ES_CommonSkillItem> m_ES_CommonSkillItem_0 = null;
		public Transform uiTransform = null;
	}
}
