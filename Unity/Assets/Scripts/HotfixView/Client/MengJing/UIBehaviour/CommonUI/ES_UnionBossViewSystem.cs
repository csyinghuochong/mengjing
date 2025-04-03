using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_UnionBoss))]
    [FriendOfAttribute(typeof(ES_UnionBoss))]
    public static partial class ES_UnionBossSystem
    {
        [EntitySystem]
        private static void Awake(this ES_UnionBoss self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_EnterButton.AddListener(self.OnEnter);

            self.OnInit();
        }

        [EntitySystem]
        private static void Destroy(this ES_UnionBoss self)
        {
            self.DestroyWidget();
        }

        private static void OnInit(this ES_UnionBoss self)
        {
            //获取开服天数
            int openDay = TimeHelper.GetServeOpenDay(self.Root().GetComponent<PlayerInfoComponent>().ServerItem.ServerOpenTime);

            int monsterId = FunctionHelp.GetUnionBossId(openDay);
            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(monsterId);
            self.ES_ModelShow.SetCameraPosition(new Vector3(0f, 115, 380f));
            using (zstring.Block())
            {
                self.ES_ModelShow.ShowOtherModel(zstring.Format("Monster/{0}", monsterConfig.MonsterModelID)).Coroutine();
            }

            using (zstring.Block())
            {
                FuntionConfig funtionConfig = FuntionConfigCategory.Instance.Get(1043);
                string[] openTimes = funtionConfig.OpenTime.Split('@');
                int openTime_1 = int.Parse(openTimes[0].Split(';')[0]);
                int openTime_2 = int.Parse(openTimes[0].Split(';')[1]);
                int closeTime_1 = int.Parse(openTimes[1].Split(';')[0]);
                int closeTime_2 = int.Parse(openTimes[1].Split(';')[1]);
                self.E_DesText.text = zstring.Format("每天{0}:{1}点在公会地图刷新领主怪物，怪物会携带大量的财宝，请各位少侠一定要准时参加哦！", openTime_1, openTime_2);
            }
        }

        private static void OnEnter(this ES_UnionBoss self)
        {
            // DateTime dateTime = TimeHelper.DateTimeNow();
            // long curTime = (dateTime.Hour * 60 + dateTime.Minute) * 60 + dateTime.Second;
            // long openTime = FunctionHelp.BossOpenTime();
            // long closeTime = FunctionHelp.BossCloseTime();
            // if (curTime < openTime || curTime > closeTime)
            // {
            //     FlyTipComponent.Instance.ShowFlyTip("未到时间");
            //     return;
            // }

            EnterMapHelper.RequestTransfer(self.Root(), MapTypeEnum.Union, 2000009).Coroutine();

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Union);
        }
    }
}