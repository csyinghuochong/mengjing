using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (DlgEnterMapHint))]
    public static class DlgEnterMapHintSystem
    {
        public static void RegisterUIEvent(this DlgEnterMapHint self)
        {
            CommonViewHelper.CrossFadeAlpha(self.View.EG_LeftRectTransform, 0f, 0.1f);
            self.OnInitUI().Coroutine();
        }

        public static void ShowWindow(this DlgEnterMapHint self, Entity contextData = null)
        {
        }

        public static async ETTask OnInitUI(this DlgEnterMapHint self)
        {
            M2C_FindJingLingResponse response = await JingLingNetHelper.FindJingLingRequest(self.Root());
            if (response.MonsterID != 0)
            {
                // 找到精灵
                self.View.EG_JingLingShowSetRectTransform.gameObject.SetActive(true);
            }
            else
            {
                // 找到精灵
                self.View.EG_JingLingShowSetRectTransform.gameObject.SetActive(false);
            }

            CommonViewHelper.CrossFadeAlpha(self.View.EG_LeftRectTransform, 1f, 1f);
            CommonViewHelper.DOLocalMove(self.Root(), self.View.EG_LeftRectTransform, Vector3.zero, 0.75f).Coroutine();

            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            int dungeonId = mapComponent.SceneId;
            if (mapComponent.MapType == MapTypeEnum.LocalDungeon)
            {
                int fubenType = mapComponent.FubenDifficulty;
                if (fubenType == FubenDifficulty.DiYu)
                {
                    //地狱难度
                }

                self.View.E_titleTextText.text = DungeonConfigCategory.Instance.Get(dungeonId).ChapterName;
            }

            if (mapComponent.MapType == MapTypeEnum.TeamDungeon)
            {
                int fubenType = mapComponent.FubenDifficulty;
                if (fubenType == TeamFubenType.ShenYuan)
                {
                    //深渊模式
                    self.View.EG_ShenYuanSetRectTransform.gameObject.SetActive(true);
                }

                self.View.E_titleTextText.text = SceneConfigCategory.Instance.Get(dungeonId).Name;
            }

            long instanceId = self.InstanceId;
            await self.Root().GetComponent<TimerComponent>().WaitAsync(2000);
            if (instanceId != self.InstanceId)
            {
                return;
            }

            CommonViewHelper.CrossFadeAlpha(self.View.EG_LeftRectTransform, 0f, 1f);
            CommonViewHelper.DOLocalMove(self.Root(), self.View.EG_LeftRectTransform, new(2000, 0, 0), 0.75f).Coroutine();

            await self.Root().GetComponent<TimerComponent>().WaitAsync(1000);
            if (instanceId != self.InstanceId)
            {
                return;
            }

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_EnterMapHint);
        }
    }
}
