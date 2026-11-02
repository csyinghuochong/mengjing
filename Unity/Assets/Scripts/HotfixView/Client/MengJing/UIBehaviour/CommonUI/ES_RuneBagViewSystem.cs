
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_RuneBag))]
	[FriendOfAttribute(typeof(ES_RuneBag))]
	public static partial class ES_RuneBagSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_RuneBag self,Transform transform)
		{
			self.uiTransform = transform;

			self.E_ReturnButton.AddListener(self.OnReturnButton);
		}

		[EntitySystem]
		private static void Destroy(this ES_RuneBag self)
		{
			self.DestroyWidget();
		}

		/// <summary>
		/// 点 E_Return 回到符文主界面
		/// </summary>
		private static void OnReturnButton(this ES_RuneBag self)
		{
			self.GetParent<ES_Rune>().CloseRuneBag();
		}
	}


}
