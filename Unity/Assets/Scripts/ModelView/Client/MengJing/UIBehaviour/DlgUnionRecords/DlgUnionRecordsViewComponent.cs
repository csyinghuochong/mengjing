
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgUnionRecords))]
	[EnableMethod]
	public  class DlgUnionRecordsViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_ButtonCloseButton
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
		    		this.m_E_ButtonCloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonClose");
     			}
     			return this.m_E_ButtonCloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonCloseImage
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
		    		this.m_E_ButtonCloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonClose");
     			}
     			return this.m_E_ButtonCloseImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_UnionRecordsItemLoopVerticalScrollRect
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
		    		this.m_E_UnionRecordsItemLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_UnionRecordsItem");
     			}
     			return this.m_E_UnionRecordsItemLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_HeadIconImage
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
		    		this.m_E_HeadIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_UnionRecordsItem/Content/Item_UnionRecordsItem/E_HeadIcon");
     			}
     			return this.m_E_HeadIconImage;
     		}
     	}

		public UnityEngine.UI.Text E_TextContentText
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
		    		this.m_E_TextContentText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_UnionRecordsItem/Content/Item_UnionRecordsItem/E_TextContent");
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

		private UnityEngine.UI.Button m_E_ButtonCloseButton = null;
		private UnityEngine.UI.Image m_E_ButtonCloseImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_UnionRecordsItemLoopVerticalScrollRect = null;
		private UnityEngine.UI.Image m_E_HeadIconImage = null;
		private UnityEngine.UI.Text m_E_TextContentText = null;
		public Transform uiTransform = null;
	}
}
