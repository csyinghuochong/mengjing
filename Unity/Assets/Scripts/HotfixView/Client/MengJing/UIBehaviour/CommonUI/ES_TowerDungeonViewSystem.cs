using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_TowerDungeon))]
    [FriendOfAttribute(typeof (ES_TowerDungeon))]
    public static partial class ES_TowerDungeonSystem
    {
        [EntitySystem]
        private static void Awake(this ES_TowerDungeon self, Transform transform)
        {
            self.uiTransform = transform;
        }

        [EntitySystem]
        private static void Destroy(this ES_TowerDungeon self)
        {
            self.DestroyWidget();
        }

        public static void OnButtonSelect(this ES_TowerDungeon self, int difficulty)
        {
            Color color_1 = new(255, 255, 255, 150);
            Color color_2 = new(255, 255, 255, 0);
            self.E_ButtonSelect_3Image.color = difficulty == FubenDifficulty.DiYu? color_1 : color_2;
            self.E_ButtonSelect_2Image.color = difficulty == FubenDifficulty.TiaoZhan? color_1 : color_2;
            self.E_ButtonSelect_1Image.color = difficulty == FubenDifficulty.Normal? color_1 : color_2;
            self.FubenDifficulty = difficulty;
        }

        public static async ETTask OnBtn_Enter(this ES_TowerDungeon self)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(62);
            string[] jianyiLevel = globalValueConfig.Value.Split(';');
            if (userInfoComponent.UserInfo.Lv < int.Parse(jianyiLevel[self.FubenDifficulty - 1]))
            {
                FlyTipComponent.Instance.SpawnFlyTipDi($"{jianyiLevel[self.FubenDifficulty - 1]}级进入！");
                return;
            }

            int sceneId = BattleHelper.GetSceneIdByType(SceneTypeEnum.Tower);
            int errorCode = await EnterMapHelper.RequestTransfer(self.Root(), SceneTypeEnum.Tower, sceneId, self.FubenDifficulty);
            if (errorCode == ErrorCode.ERR_Success)
            {
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Tower);
            }
        }
    }
}