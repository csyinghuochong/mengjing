using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [Invoke(TimerInvokeType.UICellDungeonEnterShow)]
    public class UICellDungeonEnterShow : ATimer<DlgCellDungeonEnterShow>
    {
        protected override void Run(DlgCellDungeonEnterShow self)
        {
            try
            {
                self.Update();
            }
            catch (Exception e)
            {
                Log.Error($"move timer error: {self.Id}\n{e}");
            }
        }
    }

    [FriendOf(typeof(DlgCellDungeonEnterShow))]
    public static class DlgCellDungeonEnterShowSystem
    {
        public static void RegisterUIEvent(this DlgCellDungeonEnterShow self)
        {
            self.stopMoveStart = false;
            self.stopMoveStatus = false;
            self.stopMoveEnd = false;
            self.moveDis = 1000f;
            self.timeSum = 0f;
            self.nowDis = 0f;

            self.View.EG_PostionSetRectTransform.localPosition = new Vector3(self.moveDis * -1, 0, 0);
            self.chushiVec3 = self.View.EG_PostionSetRectTransform.localPosition;

            self.View.EG_NanDu_1RectTransform.gameObject.SetActive(false);
            self.View.EG_NanDu_2RectTransform.gameObject.SetActive(false);
            self.View.EG_NanDu_3RectTransform.gameObject.SetActive(false);

            int difficulty = self.Root().GetComponent<CellDungeonComponentC>().FubenDifficulty;
            switch (difficulty)
            {
                case FubenDifficulty.Normal:
                    self.View.EG_NanDu_1RectTransform.gameObject.SetActive(true);
                    self.View.E_Lab_ChapterNameText.transform.GetComponent<Outline>().effectColor = new Color(88f / 255f, 120f / 255f, 10f / 255f);
                    break;

                case FubenDifficulty.TiaoZhan:
                    self.View.EG_NanDu_2RectTransform.gameObject.SetActive(true);
                    self.View.E_Lab_ChapterNameText.transform.GetComponent<Outline>().effectColor = new Color(0f / 255f, 142f / 255f, 154f / 255f);
                    break;

                case FubenDifficulty.DiYu:
                    self.View.EG_NanDu_3RectTransform.gameObject.SetActive(true);
                    self.View.E_Lab_ChapterNameText.transform.GetComponent<Outline>().effectColor = new Color(154f / 255f, 117f / 255f, 0f / 255f);
                    break;
            }

            self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.UICellDungeonEnterShow, self);
        }

        public static void ShowWindow(this DlgCellDungeonEnterShow self, Entity contextData = null)
        {
        }

        public static void BeforeUnload(this DlgCellDungeonEnterShow self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static void Update(this DlgCellDungeonEnterShow self)
        {
            if (self.stopMoveStart)
            {
                if (!self.stopMoveStatus)
                {
                    self.timeSum = self.timeSum + Time.deltaTime * 1.5f;
                    self.nowDis = self.chushiVec3.x + self.moveDis * self.timeSum;

                    if (!self.stopMoveEnd)
                    {
                        if (self.nowDis >= 0)
                        {
                            self.nowDis = 0;
                        }
                    }

                    self.View.EG_PostionSetRectTransform.localPosition = new Vector3(self.nowDis, 0, 0);

                    if (self.timeSum >= 1)
                    {
                        self.stopMoveStatus = true;
                        self.timeSum = 0;
                    }
                }
                else
                {
                    self.stopMoveEnd = true;
                    self.timeSum = self.timeSum + Time.deltaTime * 1.5f;
                    //停顿3秒
                    if (self.timeSum >= 2.5f)
                    {
                        self.stopMoveStatus = false;
                        self.timeSum = 0;
                        self.chushiVec3 = self.View.EG_PostionSetRectTransform.localPosition;

                        self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_CellDungeonEnterShow);
                    }
                }
            }
            else
            {
                //实例化后 延迟2秒显示
                self.timeSum = self.timeSum + Time.deltaTime;
                if (self.timeSum >= 0f)
                {
                    self.timeSum = 0;
                    self.stopMoveStart = true;
                }
            }
        }

        public static void OnUpdateUI(this DlgCellDungeonEnterShow self, int chapterId)
        {
            self.View.E_Lab_ChapterNameText.text = CellGenerateConfigCategory.Instance.Get(chapterId).ChapterName;

            CellDungeonComponentC fubenComponent = self.Root().GetComponent<CellDungeonComponentC>();
            if (fubenComponent.HaveFubenCellNpc(CellDungeonNpc.MoLengRoom, 201) || fubenComponent.HaveFubenCellNpc(CellDungeonNpc.MoLengRoom, 202) ||
                fubenComponent.HaveFubenCellNpc(CellDungeonNpc.MoLengRoom, 203) || fubenComponent.HaveFubenCellNpc(CellDungeonNpc.MoLengRoom, 204))
            {
                self.View.EG_JingYingGuanKaShowSetRectTransform.gameObject.SetActive(true);
            }
            else
            {
                self.View.EG_JingYingGuanKaShowSetRectTransform.gameObject.SetActive(false);
            }
        }
    }
}