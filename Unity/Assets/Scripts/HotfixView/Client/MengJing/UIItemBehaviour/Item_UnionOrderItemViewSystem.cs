
using System;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_UnionOrderItem))]
	public static partial class Scroll_Item_UnionOrderItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_UnionOrderItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_UnionOrderItem self )
		{
			self.DestroyWidget();
		}

		private static void OnClick(this Scroll_Item_UnionOrderItem self)
		{
			self.ClickCallback?.Invoke(self.TaskId);     
		}
		
		public static void Refresh(this Scroll_Item_UnionOrderItem self, int  taskid, Action<int> clickCallback)
		{
			self.TaskId  = taskid;
			self.ClickCallback = clickCallback;	
			
			self.E_ImageButtonButton.AddListener(self.OnClick);
			
			TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskid);
			string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.TaskIcon, taskConfig.TaskIcon);
			Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
			self.E_TaskIconImage.sprite = sp;

			if (taskConfig.TargetType == TaskTargetType.GiveItem_10)
			{
				ItemInfo itemInfo = new ItemInfo();
				itemInfo.ItemID  =	taskConfig.Target[0];
				itemInfo.ItemNum = taskConfig.TargetValue[0];
				self.ES_CommonItem.UpdateItem(itemInfo, ItemOperateEnum.None);
			}
			
			self.E_Text_NameText.text = taskConfig.TaskName;
		}
	}
}
