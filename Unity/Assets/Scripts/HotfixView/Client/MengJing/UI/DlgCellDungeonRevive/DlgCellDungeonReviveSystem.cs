using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgCellDungeonRevive))]
    public static class DlgCellDungeonReviveSystem
    {
        public static void RegisterUIEvent(this DlgCellDungeonRevive self)
        {
            self.View.E_Button_ReviveButton.AddListener(self.OnButton_ReviveButton);
            self.View.E_Button_ExitButton.AddListener(self.OnButton_ExitButton);
            self.View.E_Button_DamageButton.AddListenerAsync(self.OnButton_DamageButton);
        }

        public static void ShowWindow(this DlgCellDungeonRevive self, Entity contextData = null)
        {
        }

        public static bool IsNoAutoExit(this DlgCellDungeonRevive self, int sceneType)
        {
            return sceneType == MapTypeEnum.TeamDungeon
                    || sceneType == MapTypeEnum.Battle
                    || sceneType == MapTypeEnum.BaoZang
                    || sceneType == MapTypeEnum.MiJing
                    || sceneType == MapTypeEnum.UnionRace;
        }

        public static void Check(this DlgCellDungeonRevive self, int leftTime)
        {
            self.LeftTime = leftTime;
            using (zstring.Block())
            {
                self.View.E_Text_ExitTipText.text = zstring.Format("{0}秒后退出副本", leftTime);
            }

            if (leftTime <= 0)
            {
                self.OnAuto_Exit();
            }
        }

        public static async ETTask BegingTimer(this DlgCellDungeonRevive self)
        {
            self.Check(self.LeftTime);
            long instanceId = self.InstanceId;
            for (int i = self.LeftTime - 1; i >= 0; i--)
            {
                await self.Root().GetComponent<TimerComponent>().WaitAsync(1000);
                if (instanceId != self.InstanceId)
                {
                    return;
                }

                self.Check(i);
            }
        }

        public static void OnInitUI(this DlgCellDungeonRevive self, int seneTypeEnum)
        {
            self.SceneType = seneTypeEnum;
            self.LeftTime = seneTypeEnum == MapTypeEnum.TeamDungeon ? 3 : 10;

            self.BegingTimer().Coroutine();

            string reviveCost = GlobalValueConfigCategory.Instance.Get(5).Value;
            string[] needList = reviveCost.Split(';');

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(int.Parse(needList[0]));
            self.View.E_Text_CostNameText.text = itemConfig.ItemName;

            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.View.E_ImageCostImage.sprite = sp;

            //显示副本
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            long selfNum = bagComponent.GetItemNumber(int.Parse(needList[0]));
            long needNum = int.Parse(needList[1]);
            if (selfNum >= needNum)
            {
                using (zstring.Block())
                {
                    self.View.E_Text_CostText.text = zstring.Format("{0}/{1}", selfNum, needNum);
                }

                self.View.E_Text_CostText.color = Color.green;
            }
            else
            {
                using (zstring.Block())
                {
                    self.View.E_Text_CostText.text = zstring.Format("{0}/{1}(道具不足)", selfNum, needNum);
                }

                self.View.E_Text_CostText.color = Color.yellow;
            }

            if (self.SceneType != MapTypeEnum.LocalDungeon)
            {
                self.View.E_Text_ExitDesText.text = "返回出生点";
            }
            if (self.SceneType == MapTypeEnum.CellDungeon || self.SceneType == MapTypeEnum.DragonDungeon)
            {
                self.View.E_Text_ExitDesText.text = "返回主城";
            }
            
            self.RequestDamageValueList().Coroutine();  
        }

        private static async ETTask RequestDamageValueList(this DlgCellDungeonRevive self)
        {
            long instanceid = self.InstanceId;  
            M2C_DamageValueListResponse damageValueListResponse = await CellDungeonNetHelper.RequestDamageValueList( self.Root() );
            if (instanceid != self.InstanceId || damageValueListResponse == null)
            {
                return;
            }
            //最后一条数据即为被击杀的怪物或者玩家

            if (damageValueListResponse.DamageValueList.Count > 0)
            {
                DamageValueInfo damageValueInfo = damageValueListResponse.DamageValueList[damageValueListResponse.DamageValueList.Count - 1];
                
                using (zstring.Block())
                {
                    switch (damageValueInfo.UnitType)
                    {
                        case UnitType.Monster:
                            self.View.E_Text_Damage_Record_0Text.text = zstring.Format("被击杀怪物:{0}",  MonsterConfigCategory.Instance.Get(damageValueInfo.ConfigId).MonsterName);
                            break;  
                        default:
                            self.View.E_Text_Damage_Record_0Text.text = zstring.Format("被击杀玩家:{0}", damageValueInfo.UnitName);
                            break;
                    }
                    self.View.E_Text_Damage_Record_1Text.text = zstring.Format("最后一击技能:{0}", SkillConfigCategory.Instance.Get(damageValueInfo.SkillId).SkillName);
                    self.View.E_Text_Damage_Record_2Text.text = zstring.Format("最后一击伤害:{0}",  damageValueInfo.DamageValue);
                }
            }
            self.M2C_DamageValueListResponse = damageValueListResponse; 
        }

        public static async ETTask OnButton_DamageButton(this DlgCellDungeonRevive self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_DamageValue);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgDamageValue>().OnInitUI(self.M2C_DamageValueListResponse);
            await ETTask.CompletedTask;
        }

        public static void OnButton_ReviveButton(this DlgCellDungeonRevive self)
        {
            string reviveCost = GlobalValueConfigCategory.Instance.Get(5).Value;
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            bool success = bagComponent.CheckNeedItem(reviveCost);
            if (!success)
            {
                FlyTipComponent.Instance.ShowFlyTip("道具不足");
                return;
            }

            if (self.SceneType == MapTypeEnum.UnionRace)
            {
                FlyTipComponent.Instance.ShowFlyTip("不支持复活");
                return;
            }

            EnterMapHelper.SendReviveRequest(self.Root(), true).Coroutine();
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_CellDungeonRevive);
        }

        public static void OnAuto_Exit(this DlgCellDungeonRevive self)
        {
            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            if (self.IsNoAutoExit(mapComponent.MapType))
            {
                return;
            }
            

            EnterMapHelper.RequestQuitFuben(self.Root());
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_CellDungeonRevive);
        }

        public static void OnButton_ExitButton(this DlgCellDungeonRevive self)
        {
            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            if (mapComponent.MapType == MapTypeEnum.MainCityScene)
            {
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_CellDungeonRevive);
                return;
            }
            
            if (self.IsNoAutoExit(mapComponent.MapType))
            {
                if (self.LeftTime > 0)
                {
                    using (zstring.Block())
                    {
                        if (self.SceneType == MapTypeEnum.LocalDungeon || self.SceneType == MapTypeEnum.CellDungeon|| self.SceneType == MapTypeEnum.DragonDungeon)
                        {
                            FlyTipComponent.Instance.ShowFlyTip(zstring.Format("{0}秒后可返回主城！", self.LeftTime));
                        }
                        else
                        {
                            FlyTipComponent.Instance.ShowFlyTip(zstring.Format("{0}秒后可返回出生点！", self.LeftTime));
                        }
                    }
                }
                else
                {
                    EnterMapHelper.SendReviveRequest(self.Root(), false).Coroutine();
                    self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_CellDungeonRevive);
                }
            }
            else
            {
                EnterMapHelper.RequestQuitFuben(self.Root());
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_CellDungeonRevive);
            }
        }
    }
}