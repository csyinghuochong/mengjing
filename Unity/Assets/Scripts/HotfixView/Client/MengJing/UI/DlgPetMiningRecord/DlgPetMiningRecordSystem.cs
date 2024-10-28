using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgPetMiningRecord))]
    public static class DlgPetMiningRecordSystem
    {
        public static void RegisterUIEvent(this DlgPetMiningRecord self)
        {
            self.View.E_ImageCloseButton.AddListener(self.OnImageCloseButton);
            
            self.View.EG_UIPetMiningRecordItemRectTransform.gameObject.SetActive(false);
            self.OnInitUI().Coroutine();
        }

        public static void ShowWindow(this DlgPetMiningRecord self, Entity contextData = null)
        {
        }

        public static void OnImageCloseButton(this DlgPetMiningRecord self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetMiningRecord);
        }

        public static async ETTask OnInitUI(this DlgPetMiningRecord self)
        {
            long instanceid = self.InstanceId;
            C2M_PetMingRecordRequest request = new();
            M2C_PetMingRecordResponse response = (M2C_PetMingRecordResponse)await self.Root().GetComponent<ClientSenderCompnent>().Call(request);
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
                using (zstring.Block())
                {
                    string content = zstring.Format("玩家 {0} {1} 占领了你的{2}",
                        response.PetMingRecords[i].WinPlayer, TimeInfo.Instance.ToDateTime(petMingRecord.Time).ToString(), mineBattleConfig.Name);
                    gameObject.transform.Find("Text").GetComponent<Text>().text = content;
                }

                CommonViewHelper.SetParent(gameObject, self.View.EG_BuildingList2RectTransform.gameObject);
            }
        }
    }
}
