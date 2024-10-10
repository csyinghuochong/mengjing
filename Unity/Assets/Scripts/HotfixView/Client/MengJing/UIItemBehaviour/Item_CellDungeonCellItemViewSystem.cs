using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CellDungeonCellItem))]
    [EntitySystemOf(typeof(Scroll_Item_CellDungeonCellItem))]
    public static partial class Scroll_Item_CellDungeonCellItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_CellDungeonCellItem self)
        {
            self.ShowOpen = false;
            self.PassTime = 0f;
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_CellDungeonCellItem self)
        {
            self.DestroyWidget();
        }

        public static void UpdateOpenEffect(this Scroll_Item_CellDungeonCellItem self)
        {
            if (!self.ShowOpen)
                return;

            self.PassTime += 1;
            self.CrossFadeAlpha(self.PassTime % 2);
        }

        public static void CrossFadeAlpha(this Scroll_Item_CellDungeonCellItem self, float alpha)
        {
            for (int i = 0; i < self.uiTransform.childCount; i++)
            {
                Image image = self.uiTransform.GetChild(i).gameObject.GetComponent<Image>();

                if (image == null)
                {
                    continue;
                }

                image.CrossFadeAlpha(alpha, 1f, false);
            }
        }

        public static void OnChapterOpen(this Scroll_Item_CellDungeonCellItem self, bool open)
        {
            if (!open)
            {
                self.ShowOpen = false;
                self.CrossFadeAlpha(1f);
                return;
            }

            CellDungeonComponentC fubenComponent = self.Root().GetComponent<CellDungeonComponentC>();

            CellGenerateConfig cellGenerateConfig = CellGenerateConfigCategory.Instance.Get(fubenComponent.ChapterId);
            CellDungeonInfo cellDungeonInfo = self.fubenCellInfo;
            int cellIndex = fubenComponent.GetCellIndex(cellDungeonInfo.row, cellDungeonInfo.line);
            int[] size = cellGenerateConfig.InitSize;

            bool benext = Mathf.Abs(cellIndex - fubenComponent.SonFubenInfo.CurrentCell) == 1 &&
                    (cellDungeonInfo.line == (int)(fubenComponent.SonFubenInfo.CurrentCell / size[0]))
                    || Mathf.Abs(cellIndex - fubenComponent.SonFubenInfo.CurrentCell) == size[0];

            self.ShowOpen = benext && (cellDungeonInfo.ctype == (byte)CellDungeonStatu.Passable ||
                cellDungeonInfo.ctype == (byte)CellDungeonStatu.Start || cellDungeonInfo.ctype == (byte)CellDungeonStatu.End);
        }

        public static void OnUpdateUI(this Scroll_Item_CellDungeonCellItem self, CellDungeonInfo fubenCellInfo)
        {
            self.fubenCellInfo = fubenCellInfo;
            CellDungeonComponentC cellDungeonComponentC = self.Root().GetComponent<CellDungeonComponentC>();
            CellGenerateConfig cellGenerateConfig = CellGenerateConfigCategory.Instance.Get(cellDungeonComponentC.ChapterId);

            int[] size = cellGenerateConfig.InitSize;
            int cellIndex = cellDungeonComponentC.GetCellIndex(fubenCellInfo.row, fubenCellInfo.line);
            bool ifCurCell = cellDungeonComponentC.SonFubenInfo.CurrentCell == cellIndex;
            self.E_liangButton.gameObject.SetActive(ifCurCell); //获取自身所在的格子
            self.E_impassableButton.gameObject.SetActive(fubenCellInfo.ctype == (byte)CellDungeonStatu.Impassable);
            self.E_passableButton.gameObject.SetActive((fubenCellInfo.ctype == (byte)CellDungeonStatu.Passable) && ifCurCell == false);

            if (fubenCellInfo.ctype == (byte)CellDungeonStatu.Start)
            {
                //获取自己的行和列位置
                int row = cellDungeonComponentC.SonFubenInfo.CurrentCell % size[0];
                int line = cellDungeonComponentC.SonFubenInfo.CurrentCell / size[0];

                int rowCha = Mathf.Abs(row - fubenCellInfo.row);
                int lineCha = Mathf.Abs(line - fubenCellInfo.line);

                Log.Info("rowCha = " + rowCha + "lineCha = " + lineCha);

                if (rowCha <= 1 && lineCha <= 1 && rowCha != lineCha)
                {
                    self.E_passableButton.gameObject.SetActive(true);
                }
            }

            self.E_startImage.gameObject.SetActive(fubenCellInfo.ctype == (byte)CellDungeonStatu.Start);
            self.E_huiButton.gameObject.SetActive(true);

            if (fubenCellInfo.ctype == (byte)CellDungeonStatu.Passable || fubenCellInfo.ctype == (byte)CellDungeonStatu.Impassable)
            {
                self.E_endImage.gameObject.SetActive(false);
                self.E_walkedButton.gameObject.SetActive(false);
            }
            else
            {
                self.E_endImage.gameObject.SetActive(fubenCellInfo.ctype == (byte)CellDungeonStatu.End);
                self.E_walkedButton.gameObject.SetActive(fubenCellInfo.pass);
            }

            self.E_TeShu_ShenMiImage.gameObject.SetActive(cellDungeonComponentC.HaveFubenCellNpc(CellDungeonNpc.ShenMiNpc, cellIndex));
            self.E_TeShu_HuiFuImage.gameObject.SetActive(cellDungeonComponentC.HaveFubenCellNpc(CellDungeonNpc.HuiFuItem, cellIndex) &&
                fubenCellInfo.ctype != (byte)CellDungeonStatu.Impassable);
            self.E_TeShu_ChestImage.gameObject.SetActive(cellDungeonComponentC.HaveFubenCellNpc(CellDungeonNpc.ChestList, cellIndex) &&
                fubenCellInfo.ctype != (byte)CellDungeonStatu.Impassable);
            self.E_TeShu_MoNengImage.gameObject.SetActive(cellDungeonComponentC.HaveFubenCellNpc(CellDungeonNpc.MoLengRoom, cellIndex, 101) &&
                fubenCellInfo.ctype != (byte)CellDungeonStatu.Impassable);

            //精英副本关卡
            bool ifShowJingYingStatus = cellDungeonComponentC.HaveFubenCellNpc(CellDungeonNpc.MoLengRoom, cellIndex, 201) &&
                    fubenCellInfo.ctype != (byte)CellDungeonStatu.Impassable;

            if (ifShowJingYingStatus == false && cellDungeonComponentC.HaveFubenCellNpc(CellDungeonNpc.MoLengRoom, cellIndex, 202) &&
                fubenCellInfo.ctype != (byte)CellDungeonStatu.Impassable)
            {
                ifShowJingYingStatus = true;
            }

            if (ifShowJingYingStatus == false && cellDungeonComponentC.HaveFubenCellNpc(CellDungeonNpc.MoLengRoom, cellIndex, 203) &&
                fubenCellInfo.ctype != (byte)CellDungeonStatu.Impassable)
            {
                ifShowJingYingStatus = true;
            }

            if (ifShowJingYingStatus == false && cellDungeonComponentC.HaveFubenCellNpc(CellDungeonNpc.MoLengRoom, cellIndex, 204) &&
                fubenCellInfo.ctype != (byte)CellDungeonStatu.Impassable)
            {
                ifShowJingYingStatus = true;
            }

            self.E_TeShu_JingYingImage.gameObject.SetActive(ifShowJingYingStatus);

            // 当前格子
            if (ifCurCell && cellDungeonComponentC.HaveFubenCellNpc(CellDungeonNpc.HuiFuItem, cellIndex))
            {
                List<EntityRef<Unit>> unitList = self.Root().CurrentScene().GetComponent<UnitComponent>().GetAll();
                bool ifCostStatus = true;
                for (int i = 0; i < unitList.Count; i++)
                {
                    Unit unit = unitList[i];
                    if (unit.Type == UnitType.Monster)
                    {
                        if (unit.ConfigId == 80000001)
                        {
                            ifCostStatus = false;
                        }

                        if (ifCostStatus)
                        {
                            self.E_TeShu_HuiFuImage.gameObject.SetActive(false);
                        }
                    }
                }
            }
        }
    }
}