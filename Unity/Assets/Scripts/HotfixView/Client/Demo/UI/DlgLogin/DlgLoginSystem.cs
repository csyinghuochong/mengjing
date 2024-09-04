using UnityEngine;

namespace ET.Client
{
	[FriendOf(typeof(DlgLogin))]
	public static  class DlgLoginSystem
	{

		public static void RegisterUIEvent(this DlgLogin self)
		{
			self.View.ELoginButton.AddListener(self.OnLogin);
			self.View.ELoopTestLoopHorizontalScrollRect.AddItemRefreshListener(self.OnLoop);
		}

		public static void ShowWindow(this DlgLogin self, Entity contextData = null)
		{
			self.AddUIScrollItems(ref self.Dictionary,100);
			self.View.ELoopTestLoopHorizontalScrollRect.SetVisible(true,100);
		}

		public static void OnLoop(this DlgLogin self, Transform transform, int index)
		{
			Scroll_Item_test test = self.Dictionary[index].BindTrans(transform);
			test.ELabel_ContentText.text = index.ToString();
		}

		public static void OnLogin(this DlgLogin self)
		{
			
		}
		 

	}
}
