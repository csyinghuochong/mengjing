
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgDungeonMap))]
	[EnableMethod]
	public  class DlgDungeonMapViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Image E_MapPanelImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MapPanelImage == null )
     			{
		    		this.m_E_MapPanelImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_MapPanel");
     			}
     			return this.m_E_MapPanelImage;
     		}
     	}

		public UnityEngine.UI.Button E_Map0Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Map0Button == null )
     			{
		    		this.m_E_Map0Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_MapPanel/E_Map0");
     			}
     			return this.m_E_Map0Button;
     		}
     	}

		public UnityEngine.UI.Image E_Map0Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Map0Image == null )
     			{
		    		this.m_E_Map0Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_MapPanel/E_Map0");
     			}
     			return this.m_E_Map0Image;
     		}
     	}

		public UnityEngine.UI.Button E_Map1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Map1Button == null )
     			{
		    		this.m_E_Map1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_MapPanel/E_Map1");
     			}
     			return this.m_E_Map1Button;
     		}
     	}

		public UnityEngine.UI.Image E_Map1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Map1Image == null )
     			{
		    		this.m_E_Map1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_MapPanel/E_Map1");
     			}
     			return this.m_E_Map1Image;
     		}
     	}

		public UnityEngine.UI.Button E_Map2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Map2Button == null )
     			{
		    		this.m_E_Map2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_MapPanel/E_Map2");
     			}
     			return this.m_E_Map2Button;
     		}
     	}

		public UnityEngine.UI.Image E_Map2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Map2Image == null )
     			{
		    		this.m_E_Map2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_MapPanel/E_Map2");
     			}
     			return this.m_E_Map2Image;
     		}
     	}

		public UnityEngine.UI.Button E_Map3Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Map3Button == null )
     			{
		    		this.m_E_Map3Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_MapPanel/E_Map3");
     			}
     			return this.m_E_Map3Button;
     		}
     	}

		public UnityEngine.UI.Image E_Map3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Map3Image == null )
     			{
		    		this.m_E_Map3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_MapPanel/E_Map3");
     			}
     			return this.m_E_Map3Image;
     		}
     	}

		public UnityEngine.UI.Button E_Map4Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Map4Button == null )
     			{
		    		this.m_E_Map4Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_MapPanel/E_Map4");
     			}
     			return this.m_E_Map4Button;
     		}
     	}

		public UnityEngine.UI.Image E_Map4Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Map4Image == null )
     			{
		    		this.m_E_Map4Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_MapPanel/E_Map4");
     			}
     			return this.m_E_Map4Image;
     		}
     	}

		public UnityEngine.UI.Button E_Map5Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Map5Button == null )
     			{
		    		this.m_E_Map5Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_MapPanel/E_Map5");
     			}
     			return this.m_E_Map5Button;
     		}
     	}

		public UnityEngine.UI.Image E_Map5Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Map5Image == null )
     			{
		    		this.m_E_Map5Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_MapPanel/E_Map5");
     			}
     			return this.m_E_Map5Image;
     		}
     	}

		public UnityEngine.UI.Button E_Map6Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Map6Button == null )
     			{
		    		this.m_E_Map6Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_MapPanel/E_Map6");
     			}
     			return this.m_E_Map6Button;
     		}
     	}

		public UnityEngine.UI.Image E_Map6Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Map6Image == null )
     			{
		    		this.m_E_Map6Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_MapPanel/E_Map6");
     			}
     			return this.m_E_Map6Image;
     		}
     	}

		public UnityEngine.UI.Button E_Map7Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Map7Button == null )
     			{
		    		this.m_E_Map7Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_MapPanel/E_Map7");
     			}
     			return this.m_E_Map7Button;
     		}
     	}

		public UnityEngine.UI.Image E_Map7Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Map7Image == null )
     			{
		    		this.m_E_Map7Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_MapPanel/E_Map7");
     			}
     			return this.m_E_Map7Image;
     		}
     	}

		public UnityEngine.UI.Button E_Map8Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Map8Button == null )
     			{
		    		this.m_E_Map8Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_MapPanel/E_Map8");
     			}
     			return this.m_E_Map8Button;
     		}
     	}

		public UnityEngine.UI.Image E_Map8Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Map8Image == null )
     			{
		    		this.m_E_Map8Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_MapPanel/E_Map8");
     			}
     			return this.m_E_Map8Image;
     		}
     	}

		public UnityEngine.UI.Button E_CloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseButton == null )
     			{
		    		this.m_E_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Close");
     			}
     			return this.m_E_CloseButton;
     		}
     	}

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

		public void DestroyWidget()
		{
			this.m_E_MapPanelImage = null;
			this.m_E_Map0Button = null;
			this.m_E_Map0Image = null;
			this.m_E_Map1Button = null;
			this.m_E_Map1Image = null;
			this.m_E_Map2Button = null;
			this.m_E_Map2Image = null;
			this.m_E_Map3Button = null;
			this.m_E_Map3Image = null;
			this.m_E_Map4Button = null;
			this.m_E_Map4Image = null;
			this.m_E_Map5Button = null;
			this.m_E_Map5Image = null;
			this.m_E_Map6Button = null;
			this.m_E_Map6Image = null;
			this.m_E_Map7Button = null;
			this.m_E_Map7Image = null;
			this.m_E_Map8Button = null;
			this.m_E_Map8Image = null;
			this.m_E_CloseButton = null;
			this.m_E_CloseImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_E_MapPanelImage = null;
		private UnityEngine.UI.Button m_E_Map0Button = null;
		private UnityEngine.UI.Image m_E_Map0Image = null;
		private UnityEngine.UI.Button m_E_Map1Button = null;
		private UnityEngine.UI.Image m_E_Map1Image = null;
		private UnityEngine.UI.Button m_E_Map2Button = null;
		private UnityEngine.UI.Image m_E_Map2Image = null;
		private UnityEngine.UI.Button m_E_Map3Button = null;
		private UnityEngine.UI.Image m_E_Map3Image = null;
		private UnityEngine.UI.Button m_E_Map4Button = null;
		private UnityEngine.UI.Image m_E_Map4Image = null;
		private UnityEngine.UI.Button m_E_Map5Button = null;
		private UnityEngine.UI.Image m_E_Map5Image = null;
		private UnityEngine.UI.Button m_E_Map6Button = null;
		private UnityEngine.UI.Image m_E_Map6Image = null;
		private UnityEngine.UI.Button m_E_Map7Button = null;
		private UnityEngine.UI.Image m_E_Map7Image = null;
		private UnityEngine.UI.Button m_E_Map8Button = null;
		private UnityEngine.UI.Image m_E_Map8Image = null;
		private UnityEngine.UI.Button m_E_CloseButton = null;
		private UnityEngine.UI.Image m_E_CloseImage = null;
		public Transform uiTransform = null;
	}
}
