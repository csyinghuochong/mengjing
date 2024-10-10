using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [Invoke(TimerInvokeType.UICellDungeonGuide)]
    public class UILevelGuideTimer : ATimer<ES_CellDungeonCellMini>
    {
        protected override void Run(ES_CellDungeonCellMini self)
        {
            try
            {
                self.UpdateOpenEffect();
            }
            catch (Exception e)
            {
                Log.Error($"move timer error: {self.Id}\n{e}");
            }
        }
    }

    [FriendOf(typeof(Scroll_Item_CellDungeonCellItem))]
    [EntitySystemOf(typeof(ES_CellDungeonCellMini))]
    [FriendOf(typeof(ES_CellDungeonCellMini))]
    public static partial class ES_CellDungeonCellMiniSystem
    {
        [EntitySystem]
        private static void Awake(this ES_CellDungeonCellMini self, Transform transform)
        {
            self.uiTransform = transform;
            ReferenceCollector rc = transform.GetComponent<ReferenceCollector>();
            self.cellContainer = rc.Get<GameObject>("cellContainer");

            self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_CellDungeonCellMini self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            self.DestroyWidget();
        }

        public static void OnChapterOpen(this ES_CellDungeonCellMini self, bool show)
        {
            for (int i = 0; i < self.fubenCellUIs.Length; i++)
            {
                Scroll_Item_CellDungeonCellItem item = self.fubenCellUIs[i];
                item.OnChapterOpen(show);
            }

            if (show)
            {
                self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(500, TimerInvokeType.UICellDungeonGuide, self);
            }
            else
            {
                self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            }
        }

        public static void UpdateOpenEffect(this ES_CellDungeonCellMini self)
        {
            for (int i = 0; i < self.fubenCellUIs.Length; i++)
            {
                Scroll_Item_CellDungeonCellItem item = self.fubenCellUIs[i];
                item.UpdateOpenEffect();
            }
        }

        public static void OnInitUI(this ES_CellDungeonCellMini self)
        {
            GameObject cellItem = self.Root().GetComponent<ResourcesLoaderComponent>()
                    .LoadAssetSync<GameObject>(ABPathHelper.GetUGUIPath("Item/Item_CellDungeonCellItem"));
            for (int i = 0; i < 9; i++)
            {
                GameObject cellitem = UnityEngine.Object.Instantiate(cellItem, self.cellContainer.transform, true);
                cellitem.SetActive(true);
                cellitem.transform.localScale = Vector3.one * 0.4f;
                cellitem.transform.localPosition = Vector3.zero;
                Scroll_Item_CellDungeonCellItem item = self.AddChild<Scroll_Item_CellDungeonCellItem>();
                item.uiTransform = cellitem.transform;
                self.fubenCellUIs[i] = item;
            }
        }

        public static void OnUpdateUI(this ES_CellDungeonCellMini self)
        {
            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            CellDungeonComponentC cellDungeonComponentC = self.Root().GetComponent<CellDungeonComponentC>();

            //获取周围八个格子的状态
            CellGenerateConfig cellGenerateConfig = CellGenerateConfigCategory.Instance.Get(mapComponent.SceneId);
            int[] size = cellGenerateConfig.InitSize;

            CellDungeonInfo cellDungeonInfo = cellDungeonComponentC.GetFubenCell(cellDungeonComponentC.SonFubenInfo.CurrentCell);

            //至少显示3*3的格子，找到一个合适的起点
            int row = cellDungeonInfo.row;
            int line = cellDungeonInfo.line;

            //确定起点
            int row_start = 0;
            int line_start = 0;
            if (row == 0)
            {
                row_start = 0;
            }
            else if (row + 2 > size[0])
            {
                row_start = row - 2;
            }
            else
            {
                row_start = row - 1;
            }

            if (line == 0)
            {
                line_start = 0;
            }
            else if (line + 2 > size[1])
            {
                line_start = line - 2;
            }
            else
            {
                line_start = line - 1;
            }

            //获取格子数据
            self.fubenCellInfos[0] = cellDungeonComponentC.GetFubenCell(row_start, line_start);
            self.fubenCellInfos[1] = cellDungeonComponentC.GetFubenCell(row_start + 1, line_start);
            self.fubenCellInfos[2] = cellDungeonComponentC.GetFubenCell(row_start + 2, line_start);
            self.fubenCellInfos[3] = cellDungeonComponentC.GetFubenCell(row_start, line_start + 1);
            self.fubenCellInfos[4] = cellDungeonComponentC.GetFubenCell(row_start + 1, line_start + 1);
            self.fubenCellInfos[5] = cellDungeonComponentC.GetFubenCell(row_start + 2, line_start + 1);
            self.fubenCellInfos[6] = cellDungeonComponentC.GetFubenCell(row_start, line_start + 2);
            self.fubenCellInfos[7] = cellDungeonComponentC.GetFubenCell(row_start + 1, line_start + 2);
            self.fubenCellInfos[8] = cellDungeonComponentC.GetFubenCell(row_start + 2, line_start + 2);

            for (int i = 0; i < self.fubenCellUIs.Length; i++)
            {
                Scroll_Item_CellDungeonCellItem item = self.fubenCellUIs[i];
                item.OnUpdateUI(self.fubenCellInfos[i]);
            }

            self.OnChapterOpen(false);
        }
    }
}