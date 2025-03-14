﻿using System;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_UnionListItem))]
    [EntitySystemOf(typeof(Scroll_Item_UnionListItem))]
    public static partial class Scroll_Item_UnionListItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_UnionListItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_UnionListItem self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnButtonApply(this Scroll_Item_UnionListItem self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            long unionId = numericComponent.GetAsLong(NumericType.UnionId_0);
            if (unionId != 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("请先退出公会");
                return;
            }

            long leaveTime = numericComponent.GetAsLong(NumericType.UnionIdLeaveTime);
            if (TimeHelper.ServerNow() - leaveTime < TimeHelper.Hour * 8)
            {
                string tip = TimeHelper.ShowLeftTime(TimeHelper.Hour * 8 - (TimeHelper.ServerNow() - leaveTime));
                using (zstring.Block())
                {
                    FlyTipComponent.Instance.ShowFlyTip(zstring.Format("{0} 后才能加入家族！", tip));
                }

                return;
            }

            await UnionNetHelper.UnionApplyRequest(self.Root(), self.UnionListItem.UnionId, unit.Id);
            if (self.IsDisposed)
            {
                return;
            }

            FlyTipComponent.Instance.ShowFlyTip("已申请加入");
        }

        public static void Refresh(this Scroll_Item_UnionListItem self, UnionListItem unionListItem)
        {
            self.E_ButtonApplyButton.AddListenerAsync(self.OnButtonApply);

            self.UnionListItem = unionListItem;
            unionListItem.UnionLevel = Math.Max(unionListItem.UnionLevel, 1);
            int peopleMax = UnionConfigCategory.Instance.Get(unionListItem.UnionLevel).PeopleNum;
            self.E_Text_RequestText.text = "等级达到1级";
            using (zstring.Block())
            {
                self.E_Text_NumberText.text = zstring.Format("人数 {0}/{1}", unionListItem.PlayerNumber, peopleMax);
            }

            self.E_Text_NameText.text = unionListItem.UnionName;
            self.E_Text_LeaderText.text = unionListItem.UnionLeader;
            self.E_Text_LevelText.text = unionListItem.UnionLevel.ToString();
        }
    }
}