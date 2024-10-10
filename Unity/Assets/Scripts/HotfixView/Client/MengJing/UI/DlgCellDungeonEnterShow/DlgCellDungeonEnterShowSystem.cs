﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgCellDungeonEnterShow))]
    public static class DlgCellDungeonEnterShowSystem
    {
        public static void RegisterUIEvent(this DlgCellDungeonEnterShow self)
        {
        }

        public static void ShowWindow(this DlgCellDungeonEnterShow self, Entity contextData = null)
        {
            // self.Lab_ChapterName = self.View.uiTransform.Get<GameObject>("Lab_ChapterName");
            //          self.PostionSet = self.GetParent<UI>().GameObject.Get<GameObject>("PostionSet");
            //
            //          self.ObjNanDu_1 = self.GetParent<UI>().GameObject.Get<GameObject>("NanDu_1");
            //          self.ObjNanDu_2 = self.GetParent<UI>().GameObject.Get<GameObject>("NanDu_2");
            //          self.ObjNanDu_3 = self.GetParent<UI>().GameObject.Get<GameObject>("NanDu_3");
            //          self.JingYingGuanKaShowSet = self.GetParent<UI>().GameObject.Get<GameObject>("JingYingGuanKaShowSet");
            //
            //          self.stopMoveStart = false;
            //          self.stopMoveStatus = false;
            //          self.stopMoveEnd = false;
            //          self.moveDis = 1000f;
            //          self.timeSum = 0f;
            //          self.nowDis = 0f;
            //
            //          self.PostionSet.transform.localPosition = new Vector3(self.moveDis * -1, 0, 0);
            //          self.chushiVec3 = self.PostionSet.transform.localPosition;
            //
            //          self.ObjNanDu_1.SetActive(false);
            //          self.ObjNanDu_2.SetActive(false);
            //          self.ObjNanDu_3.SetActive(false);
            //
            //          int difficulty = self.ZoneScene().GetComponent<CellDungeonComponent>().FubenDifficulty;
            //          switch (difficulty) 
            //          {
            //              case FubenDifficulty.Normal:
            //                  self.ObjNanDu_1.SetActive(true);
            //                  self.Lab_ChapterName.GetComponent<Outline>().effectColor = new Color(88f / 255f, 120f / 255f, 10f / 255f);
            //                  break;
            //
            //              case FubenDifficulty.TiaoZhan:
            //                  self.ObjNanDu_2.SetActive(true);
            //                  self.Lab_ChapterName.GetComponent<Outline>().effectColor = new Color(0f / 255f, 142f / 255f, 154f / 255f);
            //                  break;
            //
            //              case FubenDifficulty.DiYu:
            //                  self.ObjNanDu_3.SetActive(true);
            //                  self.Lab_ChapterName.GetComponent<Outline>().effectColor = new Color(154f / 255f, 117f / 255f, 0f / 255f);
            //                  break;
            //          }
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

                    self.PostionSet.transform.localPosition = new Vector3(self.nowDis, 0, 0);

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
                        self.chushiVec3 = self.PostionSet.transform.localPosition;

                        self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_EnterMapHint);
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
            // self.Lab_ChapterName.GetComponent<Text>().text = CellGenerateConfigCategory.Instance.Get(chapterId).ChapterName;
            //
            // CellDungeonComponentC fubenComponent = self.Root().GetComponent<CellDungeonComponentC>();
            // if (fubenComponent.HaveFubenCellNpc(CellDungeonNpc.MoLengRoom, 201) || fubenComponent.HaveFubenCellNpc(CellDungeonNpc.MoLengRoom, 202) ||
            //     fubenComponent.HaveFubenCellNpc(CellDungeonNpc.MoLengRoom, 203) || fubenComponent.HaveFubenCellNpc(CellDungeonNpc.MoLengRoom, 204))
            // {
            //     self.JingYingGuanKaShowSet.SetActive(true);
            // }
            // else
            // {
            //     self.JingYingGuanKaShowSet.SetActive(false);
            // }
        }
    }
}