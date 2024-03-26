using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[FriendOf(typeof (DlgPet))]
	public static class DlgPetSystem
	{
		public static void RegisterUIEvent(this DlgPet self)
		{

		}

		public static void ShowWindow(this DlgPet self, Entity contextData = null)
		{
		}
	}
}
