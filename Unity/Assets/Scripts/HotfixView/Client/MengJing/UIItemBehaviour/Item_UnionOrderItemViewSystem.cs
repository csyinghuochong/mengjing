
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
			self.ClickCallback?.Invoke(self.TaskInfo);     
		}

		public static void UpdateTaskStatus(this Scroll_Item_UnionOrderItem self)
		{
			TaskComponentC taskComponentC = self.Root().GetComponent<TaskComponentC>();
			self.TaskInfo = taskComponentC.GetTaskById(self.TaskInfo.taskID);
			self.E_Image_Completed.gameObject.SetActive(self.TaskInfo.taskStatus == (int)TaskStatuEnum.Commited);
		}

		public static void Refresh(this Scroll_Item_UnionOrderItem self, TaskPro  taskPro, Action<TaskPro> clickCallback)
		{
			self.TaskInfo  = taskPro;
			self.ClickCallback = clickCallback;	
			
			self.E_ImageButtonButton.AddListener(self.OnClick);
			
			TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskPro.taskID);
			string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.TaskIcon, taskConfig.TaskIcon);
			Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
			self.E_TaskIconImage.sprite = sp;

			if (taskConfig.TargetType == TaskTargetType.ItemID_Number_2)
			{
				ItemInfo itemInfo = new ItemInfo();
				itemInfo.ItemID  =	taskConfig.Target[0];
				itemInfo.ItemNum = taskConfig.TargetValue[0];
				self.ES_CommonItem.UpdateItem(itemInfo, ItemOperateEnum.None);
			}
			
			self.E_Text_NameText.text = taskConfig.TaskName;
			self.E_Image_Completed.gameObject.SetActive(taskPro.taskStatus == (int)TaskStatuEnum.Commited);
		}
	}
}
