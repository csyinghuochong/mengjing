using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgPetMiningRecord))]
    public static class DlgPetMiningRecordSystem
    {
        public static void RegisterUIEvent(this DlgPetMiningRecord self)
        {
            self.View.E_ImageCloseButton.AddListener(self.OnImageClose);
        }

        public static void ShowWindow(this DlgPetMiningRecord self, Entity contextData = null)
        {
            self.View.EG_UIPetMiningRecordItemRectTransform.gameObject.SetActive(false);

            self.OnInitUI().Coroutine();
        }

        public static void OnImageClose(this DlgPetMiningRecord self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetMiningRecord);
        }

        public static async ETTask OnInitUI(this DlgPetMiningRecord self)
        {
            long instanceid = self.InstanceId;
            C2M_PetMingRecordRequest request = new();
            M2C_PetMingRecordResponse response =
                    (M2C_PetMingRecordResponse)await self.Root().GetComponent<ClientSenderCompnent>().Call(request);
            if (instanceid != self.InstanceId)
            {
                return;
            }

            for (int i = 0; i < response.PetMingRecords.Count; i++)
            {
                PetMingRecord petMingRecord = response.PetMingRecords[i];
                GameObject gameObject = UnityEngine.Object.Instantiate(self.View.EG_UIPetMiningRecordItemRectTransform.gameObject);
                gameObject.SetActive(true);

                MineBattleConfig mineBattleConfig = MineBattleConfigCategory.Instance.Get(petMingRecord.MineType);
                string content =
                        $"玩家 {response.PetMingRecords[i].WinPlayer} {TimeInfo.Instance.ToDateTime(petMingRecord.Time)} 占领了你的{mineBattleConfig.Name}";
                gameObject.transform.Find("Text").GetComponent<Text>().text = content;
                UICommonHelper.SetParent(gameObject, self.View.EG_BuildingList2RectTransform.gameObject);
            }
        }
    }
}