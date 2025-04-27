using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public class Scroll_Item_TaskGrowUpItem : Entity, IAwake, IDestroy, IUIScrollItem<Scroll_Item_TaskGrowUpItem>
	{
		public int TaskId;

		public long DataId { get; set; }
		private bool isCacheNode = false;

		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_TaskGrowUpItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Button E_SeasonIconButton
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
					if (this.m_E_SeasonIconButton == null)
					{
						this.m_E_SeasonIconButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject, "E_SeasonIcon");
					}

					return this.m_E_SeasonIconButton;
				}
				else
				{
					return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject, "E_SeasonIcon");
				}
			}
		}

		public Image E_SeasonIconImage
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
					if (this.m_E_SeasonIconImage == null)
					{
						this.m_E_SeasonIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject, "E_SeasonIcon");
					}

					return this.m_E_SeasonIconImage;
				}
				else
				{
					return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject, "E_SeasonIcon");
				}
			}
		}

		public Transform EG_Completed
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
					if (this.m_EG_Completed == null)
					{
						this.m_EG_Completed = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "EG_Completed");
					}

					return this.m_EG_Completed;
				}
				else
				{
					return UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "EG_Completed");
				}
			}
		}
		
		public Transform EG_Lock
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
					if (this.m_EG_Lock == null)
					{
						this.m_EG_Lock = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "EG_Lock");
					}

					return this.m_EG_Lock;
				}
				else
				{
					return UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject, "EG_Lock");
				}
			}
		}
		
		public Text E_TextNameText
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
					if( this.m_E_TextNameText == null )
					{
						this.m_E_TextNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextName");
					}
					return this.m_E_TextNameText;
				}
				else
				{
					return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextName");
				}
			}
		}

		public Text E_TextText
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
     				if( this.m_E_TextText == null )
     				{
		    			this.m_E_TextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text");
     				}
     				return this.m_E_TextText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_SeasonIconButton = null;
			this.m_E_SeasonIconImage = null;
			this.m_E_TextText = null;
			this.m_E_TextNameText = null;
			this.m_EG_Completed = null;	
			this.m_EG_Lock = null;
			this.uiTransform = null;
			this.DataId = 0;
		}
		
		private Button m_E_SeasonIconButton = null;
		private Image m_E_SeasonIconImage = null;
		private Text m_E_TextText = null;
		private Text m_E_TextNameText = null;
		private Transform m_EG_Completed = null;	
		private Transform m_EG_Lock = null;
		public Transform uiTransform = null;
	}
}