using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgJiaYuanPlanWatch))]
    public static class DlgJiaYuanPlanWatchSystem
    {
        public static void RegisterUIEvent(this DlgJiaYuanPlanWatch self)
        {
            self.View.E_BtnCloseButton.AddListener(() =>
            {
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_JiaYuanPlanWatch);
            });
            
            self.OnInitUI().Coroutine();
        }

        public static void ShowWindow(this DlgJiaYuanPlanWatch self, Entity contextData = null)
        {
        }

        public static async ETTask OnInitUI(this DlgJiaYuanPlanWatch self)
        {
            DlgJiaYuanMain jiaYuanViewComponent = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgJiaYuanMain>();
            Unit unit = JiaYuanHelper.GetUnitByCellIndex(self.Root().CurrentScene(), jiaYuanViewComponent.CellIndex);
            if (unit == null)
            {
                return;
            }

            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            long StartTime = numericComponent.GetAsLong(NumericType.StartTime);
            int GatherNumber = numericComponent.GetAsInt(NumericType.GatherNumber);
            long GatherLastTime = numericComponent.GetAsLong(NumericType.GatherLastTime);

            JiaYuanFarmConfig jiaYuanFarmConfig = JiaYuanFarmConfigCategory.Instance.Get(unit.ConfigId);
            int stage = ET.JiaYuanHelper.GetPlanStage(unit.ConfigId, StartTime, GatherNumber);

            // self.View.ES_ModelShow.ShowOtherModel($"JiaYuan/{jiaYuanFarmConfig.ModelID + stage}").Coroutine();
            self.View.ES_ModelShow.ShowOtherModel($"JiaYuan/100101").Coroutine();
            self.View.ES_ModelShow.SetCameraPosition(new Vector3(1f, 11f, 150f));
            self.View.ES_ModelShow.Camera.fieldOfView = 15;
            // self.View.ES_ModelShow.SetRootPosition(new Vector2(1000, 0));
            self.View.ES_ModelShow.SetModelParentRotation(Quaternion.Euler(0f, -45f, 0f));

            self.View.E_TextNameText.text = jiaYuanFarmConfig.Name;
            self.View.E_TextStageText.text = ET.JiaYuanHelper.GetPlanStageName(stage);

            using (zstring.Block())
            {
                self.View.E_Text_Desc_1Text.text = zstring.Format("当前阶段: {0}", ET.JiaYuanHelper.GetPlanStageName(stage));

                long nextTime = ET.JiaYuanHelper.GetNextStateTime(unit.ConfigId, StartTime);
                self.View.E_Text_Desc_2Text.text =
                        zstring.Format("下一阶段: {0}", ET.JiaYuanHelper.TimeToShow(TimeInfo.Instance.ToDateTime(nextTime).ToString("f")));

                long shouhuoTime = ET.JiaYuanHelper.GetPlanNextShouHuoTime(unit.ConfigId, StartTime, GatherNumber, GatherLastTime);
                self.View.E_Text_Desc_3Text.text = zstring.Format("预计收获: {0}",
                    ET.JiaYuanHelper.TimeToShow(TimeInfo.Instance.ToDateTime(shouhuoTime).ToString("f")));
            }

            ItemInfo bagInfo = new ItemInfo();
            bagInfo.ItemID = jiaYuanFarmConfig.GetItemID;
            bagInfo.ItemNum = 1;
            self.View.ES_CommonItem.UpdateItem(bagInfo, ItemOperateEnum.None);

            JiaYuanComponentC jiaYuanComponent = self.Root().GetComponent<JiaYuanComponentC>();
            M2C_JiaYuanWatchResponse response = await JiaYuanNetHelper.JiaYuanWatchRequest(self.Root(), jiaYuanComponent.MasterId, unit.Id);

            zstring gatherrecode = string.Empty;
            for (int i = 0; i < response.JiaYuanRecord.Count; i++)
            {
                string gatherTime = TimeInfo.Instance.ToDateTime(response.JiaYuanRecord[i].Time).ToString();
                gatherTime = gatherTime.Substring(5, gatherTime.Length - 5);
                using (zstring.Block())
                {
                    gatherrecode += zstring.Format("{0} {1}收获一次 \n", gatherTime, response.JiaYuanRecord[i].PlayerName);
                }
            }

            self.View.E_Text_RecordText.text = gatherrecode;
        }
    }
}
