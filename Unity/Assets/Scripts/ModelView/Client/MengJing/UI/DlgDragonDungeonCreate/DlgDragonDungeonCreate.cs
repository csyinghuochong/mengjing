using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgDragonDungeonCreate :Entity,IAwake,IUILogic
	{

		public DlgDragonDungeonCreateViewComponent View { get => this.GetComponent<DlgDragonDungeonCreateViewComponent>();} 

		 
		public int FubenId;
		public List<int> FubenIdList = new();
		public List<Transform> ButtonList = new();
	}
}
