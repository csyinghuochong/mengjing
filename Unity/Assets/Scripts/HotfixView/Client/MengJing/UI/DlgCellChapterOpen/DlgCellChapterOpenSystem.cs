using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [Invoke(TimerInvokeType.UICellChapterOpen)]
    public class UICellChapterOpen : ATimer<DlgCellChapterOpen>
    {
        protected override void Run(DlgCellChapterOpen self)
        {
            try
            {
                self.Update();
            }
            catch (Exception e)
            {
                using (zstring.Block())
                {
                    Log.Error(zstring.Format("move timer error: {0}\n{1}", self.Id, e.ToString()));
                }
            }
        }
    }

    [FriendOf(typeof(DlgCellChapterOpen))]
    public static class DlgCellChapterOpenSystem
    {
        public static void RegisterUIEvent(this DlgCellChapterOpen self)
        {
        }

        public static void ShowWindow(this DlgCellChapterOpen self, Entity contextData = null)
        {
            self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.UICellChapterOpen, self);
        }

        public static void BeforeUnload(this DlgCellChapterOpen self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static void Update(this DlgCellChapterOpen self)
        {
            self.PassTime += TimeInfo.Instance.DeltaTime;
            if (self.PassTime < 2f)
            {
                float colorValue = 0.3f - 0.3f * self.PassTime / 2f;
                self.View.E_ImageDiImage.color = new Color(0, 0, 0, colorValue);
                self.View.E_Lab_ChapterNameText.color = new Color(1, 1, 1, 1 - self.PassTime / 2f);
                return;
            }

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_CellChapterOpen);
        }

        public static void OnUpdateUI(this DlgCellChapterOpen self)
        {
            //self.Lab_ChapterName.GetComponent<Text>().text = "新关卡开启！";
        }
    }
}