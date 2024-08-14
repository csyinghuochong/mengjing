
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgTreasureOpen))]
	[EnableMethod]
	public  class DlgTreasureOpenViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_ButtonDiButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonDiButton == null )
     			{
		    		this.m_E_ButtonDiButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonDi");
     			}
     			return this.m_E_ButtonDiButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonDiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonDiImage == null )
     			{
		    		this.m_E_ButtonDiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonDi");
     			}
     			return this.m_E_ButtonDiImage;
     		}
     	}

		public ES_RewardList ES_RewardList
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_RewardList es = this.m_es_rewardlist;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonStopButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonStopButton == null )
     			{
		    		this.m_E_ButtonStopButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonStop");
     			}
     			return this.m_E_ButtonStopButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonStopImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonStopImage == null )
     			{
		    		this.m_E_ButtonStopImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonStop");
     			}
     			return this.m_E_ButtonStopImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonOpenButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonOpenButton == null )
     			{
		    		this.m_E_ButtonOpenButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonOpen");
     			}
     			return this.m_E_ButtonOpenButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonOpenImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonOpenImage == null )
     			{
		    		this.m_E_ButtonOpenImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonOpen");
     			}
     			return this.m_E_ButtonOpenImage;
     		}
     	}

		public UnityEngine.UI.Image E_ImageSelectImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageSelectImage == null )
     			{
		    		this.m_E_ImageSelectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageSelect");
     			}
     			return this.m_E_ImageSelectImage;
     		}
     	}

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

		public void DestroyWidget()
		{
			this.m_E_ButtonDiButton = null;
			this.m_E_ButtonDiImage = null;
			this.m_es_rewardlist = null;
			this.m_E_ButtonStopButton = null;
			this.m_E_ButtonStopImage = null;
			this.m_E_ButtonOpenButton = null;
			this.m_E_ButtonOpenImage = null;
			this.m_E_ImageSelectImage = null;
			this.m_E_ButtonCloseButton = null;
			this.m_E_ButtonCloseImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_ButtonDiButton = null;
		private UnityEngine.UI.Image m_E_ButtonDiImage = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private UnityEngine.UI.Button m_E_ButtonStopButton = null;
		private UnityEngine.UI.Image m_E_ButtonStopImage = null;
		private UnityEngine.UI.Button m_E_ButtonOpenButton = null;
		private UnityEngine.UI.Image m_E_ButtonOpenImage = null;
		private UnityEngine.UI.Image m_E_ImageSelectImage = null;
		private UnityEngine.UI.Button m_E_ButtonCloseButton = null;
		private UnityEngine.UI.Image m_E_ButtonCloseImage = null;
		public Transform uiTransform = null;
	}
}
