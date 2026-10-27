
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_GemTalent))]
	[FriendOfAttribute(typeof(ES_GemTalent))]
	public static partial class ES_GemTalentSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_GemTalent self,Transform transform)
		{
			self.uiTransform = transform;

			self.E_ReturnButton.AddListener(self.OnReturnButton);
		}

		[EntitySystem]
		private static void Destroy(this ES_GemTalent self)
		{
			self.DestroyWidget();
		}

		private static void OnReturnButton(this ES_GemTalent self)
		{
			self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgRole>()?.CloseGemTalent();
		}
	}


}
