using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [Invoke(TimerInvokeType.RoleXiLianLevel)]
    public class RoleXiLianLevelTimer: ATimer<ES_RoleXiLianLevel>
    {
        protected override void Run(ES_RoleXiLianLevel self)
        {
            try
            {
                self.OnUpdate();
            }
            catch (Exception e)
            {
                Log.Error($"move timer error: {self.Id}\n{e}");
            }
        }
    }

    [FriendOf(typeof (ES_RoleXiLianLevelItem))]
    [EntitySystemOf(typeof (ES_RoleXiLianLevel))]
    [FriendOfAttribute(typeof (ES_RoleXiLianLevel))]
    public static partial class ES_RoleXiLianLevelSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RoleXiLianLevel self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_Button_RightButton.AddListener(self.OnButton_Right);
            self.E_Button_LeftButton.AddListener(self.OnButton_Left);

            self.UIRoleXiLianLevels.Add(self.ES_RoleXiLianLevelItem_0);
            self.UIRoleXiLianLevels.Add(self.ES_RoleXiLianLevelItem_1);
            self.UIRoleXiLianLevels.Add(self.ES_RoleXiLianLevelItem_2);

            self.InitItemUIList();
        }

        [EntitySystem]
        private static void Destroy(this ES_RoleXiLianLevel self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            self.DestroyWidget();
        }

        public static void OnUpdateUI(this ES_RoleXiLianLevel self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int xiliandu = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.ItemXiLianDu);
            int xilianLevel = XiLianHelper.GetXiLianId(xiliandu);
            xilianLevel = xilianLevel != 0? xilianLevel : EquipXiLianConfigCategory.Instance.EquipXiLianLevelList[1].Id;
            self.OnUpdateButton(xilianLevel);
            self.UIRoleXiLianLevels[1].OnUpdateUI(xilianLevel);
        }

        private static void InitItemUIList(this ES_RoleXiLianLevel self)
        {
            for (int i = 0; i < 3; i++)
            {
                self.UIRoleXiLianLevels[i].uiTransform.localPosition = new Vector3((i - 1) * self.ItemWidth, 0f, 0f);
            }
        }

        public static void SetPosition(this ES_RoleXiLianLevel self)
        {
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            timerComponent.Remove(ref self.Timer);
            self.UIRoleXiLianLevels[0].PostionY = self.ItemWidth * -1f;
            self.UIRoleXiLianLevels[1].PostionY = 0f;
            self.UIRoleXiLianLevels[2].PostionY = self.ItemWidth;
            float offset = self.UIRoleXiLianLevels[1].uiTransform.localPosition.x;
            if (Mathf.Abs(offset) < self.MoveSpeed + 1f)
            {
                self.UIRoleXiLianLevels[0].uiTransform.localPosition = new Vector3(self.ItemWidth * -1f, 0f, 0f);
                self.UIRoleXiLianLevels[1].uiTransform.localPosition = new Vector3(0f, 0f, 0f);
                self.UIRoleXiLianLevels[2].uiTransform.localPosition = new Vector3(self.ItemWidth, 0f, 0f);
            }
            else
            {
                self.Timer = timerComponent.NewFrameTimer(TimerInvokeType.RoleXiLianLevel, self);
            }
        }

        public static void MoveToPositon(this ES_RoleXiLianLevel self, GameObject gameObject, float movedis)
        {
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + movedis,
                gameObject.transform.localPosition.y,
                gameObject.transform.localPosition.z);
        }

        public static void OnUpdate(this ES_RoleXiLianLevel self)
        {
            float offset = self.UIRoleXiLianLevels[1].uiTransform.localPosition.x;
            float movedis = offset < 0? self.MoveSpeed : -self.MoveSpeed;

            self.MoveToPositon(self.UIRoleXiLianLevels[0].uiTransform.gameObject, movedis);
            self.MoveToPositon(self.UIRoleXiLianLevels[1].uiTransform.gameObject, movedis);
            self.MoveToPositon(self.UIRoleXiLianLevels[2].uiTransform.gameObject, movedis);

            if (Mathf.Abs(offset) < self.MoveSpeed + 1f)
            {
                self.UIRoleXiLianLevels[0].uiTransform.localPosition = new Vector3(self.ItemWidth * -1f, 0f, 0f);
                self.UIRoleXiLianLevels[1].uiTransform.localPosition = new Vector3(0f, 0f, 0f);
                self.UIRoleXiLianLevels[2].uiTransform.localPosition = new Vector3(self.ItemWidth, 0f, 0f);
                self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            }
        }

        public static void OnButton_Left(this ES_RoleXiLianLevel self)
        {
            if (self.Timer != 0)
            {
                return;
            }

            ES_RoleXiLianLevelItem esRoleXiLianLevelItem = self.UIRoleXiLianLevels[2];
            self.UIRoleXiLianLevels.RemoveAt(2);
            self.UIRoleXiLianLevels.Insert(0, esRoleXiLianLevelItem);

            self.UIRoleXiLianLevels[1].OnUpdateUI(self.EquipXilianId - 1);
            self.OnUpdateButton(self.EquipXilianId - 1);
            self.SetPosition();
        }

        public static void OnButton_Right(this ES_RoleXiLianLevel self)
        {
            if (self.Timer != 0)
            {
                return;
            }

            ES_RoleXiLianLevelItem esRoleXiLianLevelItem = self.UIRoleXiLianLevels[0];
            self.UIRoleXiLianLevels.RemoveAt(0);
            self.UIRoleXiLianLevels.Add(esRoleXiLianLevelItem);

            self.UIRoleXiLianLevels[1].OnUpdateUI(self.EquipXilianId + 1);
            self.OnUpdateButton(self.EquipXilianId + 1);
            self.SetPosition();
        }

        public static void OnUpdateButton(this ES_RoleXiLianLevel self, int xilianLevel)
        {
            self.EquipXilianId = xilianLevel;

            List<EquipXiLianConfig> equipXiLianConfigs = EquipXiLianConfigCategory.Instance.EquipXiLianLevelList;
            self.E_Button_LeftButton.gameObject.SetActive(xilianLevel > equipXiLianConfigs[1].Id);
            self.E_Button_RightButton.gameObject.SetActive(xilianLevel != equipXiLianConfigs[equipXiLianConfigs.Count - 1].Id);
        }
    }
}