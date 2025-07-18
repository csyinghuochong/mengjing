using System;
using UnityEngine;

namespace ET.Client
{
    [Invoke(TimerInvokeType.OpenBoxTimer)]
    public class OpenBoxTimer : ATimer<ES_OpenBox>
    {
        protected override void Run(ES_OpenBox self)
        {
            try
            {
                self.OnUpdate();
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

    [EntitySystemOf(typeof(ES_OpenBox))]
    [FriendOfAttribute(typeof(ES_OpenBox))]
    public static partial class ES_OpenBoxSystem
    {
        [EntitySystem]
        private static void Awake(this ES_OpenBox self, Transform transform)
        {
            self.uiTransform = transform;
        }

        [EntitySystem]
        private static void Destroy(this ES_OpenBox self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            self.DestroyWidget();
        }

        public static void OnUpdate(this ES_OpenBox self)
        {
            if (self.BoxUnitId == 0)
            {
                self.OnOpenBox(null);
                return;
            }

            if (self.Root().CurrentScene().GetComponent<UnitComponent>().Get(self.BoxUnitId) == null)
            {
                self.OnOpenBox(null);
                return;
            }

            long leftTime = self.EndTime - TimeHelper.ClientNow();
            if (leftTime <= 0)
            {
                self.SendOpenBox().Coroutine();
                self.OnOpenBox(null);
                return;
            }

            self.E_Img_ProgressImage.transform.localScale = new Vector3((self.TotalTime - leftTime) * 1f / self.TotalTime, 1f, 1f);
        }

        public static void OnOpenBox(this ES_OpenBox self, Unit box)
        {
            self.EndTime = 0;
            self.BoxUnitId = box != null ? box.Id : 0;
            self.uiTransform.gameObject.SetActive(box != null);
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);

            if (box == null)
            {
                return;
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());

            int monsterid = box.ConfigId;
            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(monsterid);

            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            if (userInfo.PiLao <= 0 && monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_56)
            {
                FlyTipComponent.Instance.ShowFlyTip("体力不足，无法拾取。");
                return;
            }

            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            if (bagComponent.GetBagLeftCell(ItemLocType.ItemLocBag) < 1 && monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_57)
            {
                FlyTipComponent.Instance.ShowFlyTip("背包空间不足，无法拾取。");
                return;
            }

            string itemneeds = "";
            if (monsterConfig.Parameter != null && monsterConfig.Parameter.Length > 0
                && monsterConfig.Parameter[0] > 0)
            {
                itemneeds = $"{monsterConfig.Parameter[0]};{monsterConfig.Parameter[1]}";
            }

            if (itemneeds.Length > 2 && !bagComponent.CheckNeedItem(itemneeds))
            {
                self.uiTransform.gameObject.SetActive(false);
                using (zstring.Block())
                {
                    FlyTipComponent.Instance.ShowFlyTip(zstring.Format("道具不足，需要道具 {0}！", CommonViewHelper.GetNeedItemDesc(itemneeds)));
                }

                return;
            }

            if (box != null)
            {
                self.EndTime = TimeHelper.ClientNow() + self.TotalTime;
                self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.OpenBoxTimer, self);

                Vector3 direction = box.Position - unit.Position;
                int ange = Mathf.FloorToInt(Mathf.Rad2Deg * Mathf.Atan2(direction.x, direction.z));
                unit.GetComponent<StateComponentC>().SendUpdateState(1, StateTypeEnum.OpenBox, ange.ToString());
            }
            else
            {
                unit.GetComponent<StateComponentC>().SendUpdateState(2, StateTypeEnum.OpenBox, "0");
            }
        }

        public static async ETTask SendOpenBox(this ES_OpenBox self)
        {
            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            if (mapComponent.MapType == MapTypeEnum.JiaYuan)
            {
                long masterid = self.Root().GetComponent<JiaYuanComponentC>().MasterId;

                await JiaYuanNetHelper.JiaYuanPickRequest(self.Root(), self.BoxUnitId, masterid);
            }
            else
            {
                Unit zhupuUnit = self.Root().CurrentScene().GetComponent<UnitComponent>().Get(self.BoxUnitId);
                if (zhupuUnit == null)
                {
                    return;
                }

                MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(zhupuUnit.ConfigId);
                if (monsterConfig.MonsterType == 5 && monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_58)
                {
                    Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
                    UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
                    int petexpendNumber = unit.GetComponent<NumericComponentC>()
                            .GetAsInt(NumericType.PetExtendNumber);
                    int maxNum = PetHelper.GetPetMaxNumber(userInfo.Lv, petexpendNumber);
                    if (PetHelper.GetBagPetNum(self.Root().GetComponent<PetComponentC>().RolePetInfos) >= maxNum)
                    {
                        FlyTipComponent.Instance.ShowFlyTip("宠物格子不足！");
                        return;
                    }
                }

                await PetNetHelper.OpenBoxRequest(self.Root(), self.BoxUnitId);
            }
        }
    }
}
