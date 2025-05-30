﻿
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgDamageValue))]
	[EnableMethod]
	public  class DlgDamageValueViewComponent : Entity,IAwake,IDestroy 
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
		    		this.m_E_RankShowItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Center/E_RankShowItems");
     			}
     			return this.m_E_RankShowItemsLoopVerticalScrollRect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ButtonCloseButton = null;
			this.m_E_ButtonCloseImage = null;
			this.m_E_RankShowItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_ButtonCloseButton = null;
		private UnityEngine.UI.Image m_E_ButtonCloseImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_RankShowItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
