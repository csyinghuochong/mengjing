
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgDamageValue))]
	[EnableMethod]
	public  class DlgDamageValueViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.LoopVerticalScrollRect E_RankShowItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RankShowItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_RankShowItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_RankShowItems");
     			}
     			return this.m_E_RankShowItemsLoopVerticalScrollRect;
     		}
     	}

		public Button E_ButtonCloseButton
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_ButtonClose == null )
				{
					this.m_E_ButtonClose = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonClose");
				}
				return this.m_E_ButtonClose;
			}
		}
                
		
		public void DestroyWidget()
		{
			this.m_E_RankShowItemsLoopVerticalScrollRect = null;
			this.m_E_ButtonClose = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_E_RankShowItemsLoopVerticalScrollRect = null;
		private Button m_E_ButtonClose = null;
		public Transform uiTransform = null;
	}
}
