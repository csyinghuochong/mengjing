using System;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_JiaYuanPetWalkItem))]
    [EntitySystemOf(typeof(Scroll_Item_JiaYuanPetWalkItem))]
    public static partial class Scroll_Item_JiaYuanPetWalkItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_JiaYuanPetWalkItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_JiaYuanPetWalkItem self)
        {
            self.DestroyWidget();
        }

        public static void SetClickAddHandler(this Scroll_Item_JiaYuanPetWalkItem self, Action<int> action)
        {
            self.ClickAddHandler = action;
        }

        public static void SetClickStopHandler(this Scroll_Item_JiaYuanPetWalkItem self, Action action)
        {
            self.ClickStopHandler = action;
        }

        public static async ETTask OnButton_Add(this Scroll_Item_JiaYuanPetWalkItem self)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            JiaYuanConfig jiayuanCof = JiaYuanConfigCategory.Instance.Get(userInfoComponent.UserInfo.JiaYuanLv);

            if (self.Position == 1 && jiayuanCof.Lv < 10)
            {
                FlyTipComponent.Instance.ShowFlyTip("10级开启！");
                return;
            }

            if (self.Position == 2 && jiayuanCof.Lv < 20)
            {
                FlyTipComponent.Instance.ShowFlyTip("20级开启！");
                return;
            }

            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetSelect);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetSelect>().OnSetType(PetOperationType.JiaYuan_Walk);
            self.ClickAddHandler?.Invoke(self.Position);
        }

        public static async ETTask OnButton_Stop(this Scroll_Item_JiaYuanPetWalkItem self)
        {
            long instanceid = self.InstanceId;
            C2M_JiaYuanPetWalkRequest request = new() { PetStatus = 0, PetId = self.RolePetInfo.Id };
            M2C_JiaYuanPetWalkResponse response = (M2C_JiaYuanPetWalkResponse)await self.Root().GetComponent<ClientSenderCompnent>().Call(request);
            if (instanceid != self.InstanceId)
            {
                return;
            }

            self.Root().GetComponent<JiaYuanComponentC>().JiaYuanPetList_2 = response.JiaYuanPetList;
            self.ClickStopHandler?.Invoke();
        }

        public static void OnUpdateUI(this Scroll_Item_JiaYuanPetWalkItem self, RolePetInfo rolePetInfo, JiaYuanPet jiaYuanPet)
        {
            self.E_Button_StopButton.AddListenerAsync(self.OnButton_Stop);
            self.ImageMood_List[0] = self.E_ImageMood_0Image.gameObject;
            self.ImageMood_List[1] = self.E_ImageMood_1Image.gameObject;
            self.ImageMood_List[2] = self.E_ImageMood_2Image.gameObject;
            self.ImageMood_List[3] = self.E_ImageMood_3Image.gameObject;
            self.ImageMood_List[4] = self.E_ImageMood_4Image.gameObject;
            self.E_Button_AddButton.AddListenerAsync(self.OnButton_Add);

            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            JiaYuanConfig jiayuanCof = JiaYuanConfigCategory.Instance.Get(userInfoComponent.UserInfo.JiaYuanLv);

            if (self.Position == 0)
            {
                self.E_Image_LockImage.gameObject.SetActive(false);
                self.EG_SetRectTransform.gameObject.SetActive(true);
            }

            if (self.Position == 1)
            {
                self.E_Image_LockImage.gameObject.SetActive(jiayuanCof.Lv < 10);
                self.EG_SetRectTransform.gameObject.SetActive(!(jiayuanCof.Lv < 10));
                self.E_OpenLvText.text = "10级家园开启";
            }

            if (self.Position == 2)
            {
                self.E_Image_LockImage.gameObject.SetActive(jiayuanCof.Lv < 20);
                self.EG_SetRectTransform.gameObject.SetActive(!(jiayuanCof.Lv < 20));
                self.E_OpenLvText.text = "20级家园开启";
            }

            if (jiaYuanPet == null)
            {
                self.E_Button_AddButton.gameObject.SetActive(true);

                self.E_Text_TotalExpText.text = String.Empty;
                self.E_Button_WalkButton.gameObject.SetActive(false);
                self.E_Button_StopButton.gameObject.SetActive(false);
            }
            else
            {
                self.E_Button_AddButton.gameObject.SetActive(false);
                self.RolePetInfo = rolePetInfo;
                self.E_Text_TotalExpText.text = jiaYuanPet.CurExp.ToString();

                for (int i = 0; i < self.ImageMood_List.Length; i++)
                {
                    self.ImageMood_List[i].SetActive(i < ET.JiaYuanHelper.GetPetMoodStar(jiaYuanPet.MoodValue));
                }

                using (zstring.Block())
                {
                    self.E_Text_LevelText.text = zstring.Format("等级：{0}", rolePetInfo.PetLv);
                }

                self.E_Text_NameText.text = rolePetInfo.PetName;

                PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);
                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petConfig.HeadIcon);
                Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

                self.E_ImagePetIconImage.sprite = sp;

                long walkTime = jiaYuanPet.StartTime > 0 ? TimeHelper.ServerNow() - jiaYuanPet.StartTime : 0;
                using (zstring.Block())
                {
                    self.E_Text_Tip_121Text.text = zstring.Format("已经散步:{0}", TimeHelper.ShowLeftTime(walkTime));
                }

                self.E_Button_WalkButton.gameObject.SetActive(self.RolePetInfo.PetStatus == 0);
                self.E_Button_StopButton.gameObject.SetActive(self.RolePetInfo.PetStatus == 2);

                using (zstring.Block())
                {
                    self.E_Text_TotalExpHourText.text =
                            zstring.Format("{0}/小时", CommonHelp.GetJiaYuanPetExp(rolePetInfo.PetLv, jiaYuanPet.MoodValue));
                }
            }
        }
    }
}