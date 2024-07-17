using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgUnionRecords))]
	[EnableMethod]
	public  class DlgUnionRecordsViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_ButtonCloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonCloseButton == null )
     			{
		    		this.m_E_ButtonCloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonClose");
     			}
     			return this.m_E_ButtonCloseButton;
     		}
     	}

		public Image E_ButtonCloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonCloseImage == null )
     			{
		    		this.m_E_ButtonCloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonClose");
     			}
     			return this.m_E_ButtonCloseImage;
     		}
     	}

		public LoopVerticalScrollRect E_UnionRecordsItemLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UnionRecordsItemLoopVerticalScrollRect == null )
     			{
		    		this.m_E_UnionRecordsItemLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_UnionRecordsItem");
     			}
     			return this.m_E_UnionRecordsItemLoopVerticalScrollRect;
     		}
     	}

		public Image E_HeadIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HeadIconImage == null )
     			{
		    		this.m_E_HeadIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_UnionRecordsItem/Content/Item_UnionRecordsItem/E_HeadIcon");
     			}
     			return this.m_E_HeadIconImage;
     		}
     	}

		public Text E_TextContentText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextContentText == null )
     			{
		    		this.m_E_TextContentText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_UnionRecordsItem/Content/Item_UnionRecordsItem/E_TextContent");
     			}
     			return this.m_E_TextContentText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ButtonCloseButton = null;
			this.m_E_ButtonCloseImage = null;
			this.m_E_UnionRecordsItemLoopVerticalScrollRect = null;
			this.m_E_HeadIconImage = null;
			this.m_E_TextContentText = null;
			this.uiTransform = null;
		}

		private Button m_E_ButtonCloseButton = null;
		private Image m_E_ButtonCloseImage = null;
		private LoopVerticalScrollRect m_E_UnionRecordsItemLoopVerticalScrollRect = null;
		private Image m_E_HeadIconImage = null;
		private Text m_E_TextContentText = null;
		public Transform uiTransform = null;
	}
}
