using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public class ES_UnionKeJiResearchItem : Entity, ET.IAwake<UnityEngine.Transform>, IDestroy
	{
		public int Position { get; set; }

		public UnityEngine.UI.Button E_ImageIconButton
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}

				if (this.m_E_ImageIconButton == null)
				{
					this.m_E_ImageIconButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject, "E_ImageIcon");
				}

				return this.m_E_ImageIconButton;
			}
		}

		public UnityEngine.UI.Image E_ImageIconImage
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}

				if (this.m_E_ImageIconImage == null)
				{
					this.m_E_ImageIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject, "E_ImageIcon");
				}

				return this.m_E_ImageIconImage;
			}
		}

		public RectTransform EG_SelectRectTransform
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}

				if (this.m_EG_SelectRectTransform == null)
				{
					this.m_EG_SelectRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject, "EG_Select");
				}

				return this.m_EG_SelectRectTransform;
			}
		}
		
		public UnityEngine.UI.Text E_PointText
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}

				if (this.m_E_PointText == null)
				{
					this.m_E_PointText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject, "E_Point");
				}

				return this.m_E_PointText;
			}
		}

		public UnityEngine.UI.Text E_NameText
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}

				if (this.m_E_NameText == null)
				{
					this.m_E_NameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject, "E_NameText");
				}

				return this.m_E_NameText;
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
			this.m_E_ImageIconButton = null;
			this.m_E_ImageIconImage = null;
			this.m_E_PointText = null;
			this.m_E_NameText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_ImageIconButton = null;
		private UnityEngine.UI.Image m_E_ImageIconImage = null;
		private RectTransform m_EG_SelectRectTransform = null;
		private UnityEngine.UI.Text m_E_PointText = null;
		private UnityEngine.UI.Text m_E_NameText = null;
		public Transform uiTransform = null;
	}
}