using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[FriendOf(typeof(DlgSingleHappyMain))]
	public static  class DlgSingleHappyMainSystem
	{

		public static void RegisterUIEvent(this DlgSingleHappyMain self)
		{
			
			self.View.E_ButtonMove_1Button.AddListenerAsync( self.OnuttonMove_1Button );
			self.View.E_ButtonMove_2Button.AddListenerAsync( self.OnuttonMove_2Button );
			self.View.E_ButtonMove_3Button.AddListenerAsync( self.OnuttonMove_3Button );
			self.View.E_ButtonExplain.AddListener( self.OnButtonExplain );
		 
		}
		
		public static void ShowWindow(this DlgSingleHappyMain self, Entity contextData = null)
		{
		}

		private static async ETTask OnuttonMove_1Button(this DlgSingleHappyMain self)
		{
			
		}
		
		private static async ETTask OnuttonMove_2Button(this DlgSingleHappyMain self)
		{
			
		}

		private static async ETTask OnuttonMove_3Button(this DlgSingleHappyMain self)
		{
			
		}
        
		private static void OnButtonExplain(this DlgSingleHappyMain self)
		{
			
		}
		 

	}
}
