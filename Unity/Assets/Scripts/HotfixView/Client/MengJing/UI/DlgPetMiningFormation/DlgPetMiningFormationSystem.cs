using System;
using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof (DlgPetMiningFormation))]
    public static class DlgPetMiningFormationSystem
    {
        public static void RegisterUIEvent(this DlgPetMiningFormation self)
        {
            self.View.E_ButtonConfirmButton.AddListenerAsync(self.OnButtonConfirmButton);
            self.View.E_ButtonChallengeButton.AddListener(self.OnButtonChallengeButton);
            self.View.E_CloseButtonButton.AddListener(() =>
            {
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetMiningFormation);
            });
        }

        public static void ShowWindow(this DlgPetMiningFormation self, Entity contextData = null)
        {
        }

        public static async ETTask OnButtonConfirmButton(this DlgPetMiningFormation self)
        {
            await ETTask.CompletedTask;
        }

        public static void OnButtonChallengeButton(this DlgPetMiningFormation self)
        {
        }

        public static void OnInitUI(this DlgPetMiningFormation self, int sceneType, int teamid, Action action)
        {
            self.TeamId = teamid;
            self.SetHandler = action;
            self.SceneTypeEnum = sceneType;

            List<long> petposition = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetMiningTeam>().PetMingPosition.GetRange(teamid * 9, 9);

            self.View.ES_PetFormationSet.OnUpdateFormation(self.SceneTypeEnum, petposition, true);
            self.View.ES_PetFormationSet.DragEndHandler = self.RequestFormationSet;
        }

        public static void RequestFormationSet(this DlgPetMiningFormation self, long rolePetInfoId, int toindex, int operateType)
        {
            Log.Debug($"RequestFormationSet: {rolePetInfoId} {toindex} {operateType}");

            toindex = self.TeamId * 9 + toindex;

            List<long> petposition = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetMiningTeam>().PetMingPosition;

            //避免有多个。
            if (operateType != 2) //互换位置
            {
                return;
            }

            int oldIndex = -1;
            long oldPetid = 0;

            if (petposition[toindex] != 0)
            {
                oldPetid = petposition[toindex];
            }

            for (int i = 0; i < petposition.Count; i++)
            {
                if (petposition[i] == rolePetInfoId)
                {
                    oldIndex = i;
                }
            }

            petposition[toindex] = rolePetInfoId;
            petposition[oldIndex] = oldPetid;

            self.View.ES_PetFormationSet.OnUpdateFormation(self.SceneTypeEnum, petposition.GetRange(self.TeamId * 9, 9), true);
        }
    }
}
