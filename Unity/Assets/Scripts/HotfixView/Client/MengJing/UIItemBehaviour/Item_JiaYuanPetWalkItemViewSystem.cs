using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_JiaYuanPetWalkItem))]
    [EntitySystemOf(typeof (Scroll_Item_JiaYuanPetWalkItem))]
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
                FlyTipComponent.Instance.ShowFlyTipDi("10级开启！");
                return;
            }

            if (self.Position == 2 && jiayuanCof.Lv < 20)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("20级开启！");
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

            self.Root().GetComponent<JiaYuanComponent>().JiaYuanPetList_2 = response.JiaYuanPetList;
            self.ClickStopHandler?.Invoke();
        }

        public static void OnUpdateUI(this Scroll_Item_JiaYuanPetWalkItem self, RolePetInfo rolePetInfo, JiaYuanPet jiaYuanPet)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            JiaYuanConfig jiayuanCof = JiaYuanConfigCategory.Instance.Get(userInfoComponent.UserInfo.JiaYuanLv);

            if (self.Position == 0)
            {
                self.E_Image_LockImage.gameObject.SetActive(false);
            }

            if (self.Position == 1)
            {
                self.E_Image_LockImage.gameObject.SetActive(jiayuanCof.Lv < 10);
                self.Set.SetActive(!(jiayuanCof.Lv < 10));
                self.OpenLv.GetComponent<Text>().text = "10级家园开启";
            }

            if (self.Position == 2)
            {
                self.Image_Lock.SetActive(jiayuanCof.Lv < 20);
                self.Set.SetActive(!(jiayuanCof.Lv < 20));
                self.OpenLv.GetComponent<Text>().text = "20级家园开启";
            }

            if (jiaYuanPet == null)
            {
                self.Button_Add.SetActive(true);

                self.Text_TotalExp.GetComponent<Text>().text = String.Empty;
                self.Button_Walk.SetActive(false);
                self.Button_Stop.SetActive(false);
            }
            else
            {
                self.Button_Add.SetActive(false);
                self.RolePetInfo = rolePetInfo;
                self.Text_TotalExp.GetComponent<Text>().text = $"{jiaYuanPet.CurExp}";

                for (int i = 0; i < self.ImageMood_List.Length; i++)
                {
                    self.ImageMood_List[i].SetActive(i < JiaYuanHelper.GetPetMoodStar(jiaYuanPet.MoodValue));
                }

                self.Text_Level.GetComponent<Text>().text = $"等级：{rolePetInfo.PetLv}";
                self.Text_Name.GetComponent<Text>().text = rolePetInfo.PetName;

                PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);
                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petConfig.HeadIcon);
                Sprite sp = ResourcesComponent.Instance.LoadAsset<Sprite>(path);
                if (!self.AssetPath.Contains(path))
                {
                    self.AssetPath.Add(path);
                }

                self.ImagePetIcon.GetComponent<Image>().sprite = sp;

                long walkTime = jiaYuanPet.StartTime > 0? TimeHelper.ServerNow() - jiaYuanPet.StartTime : 0;
                self.Text_Tip_121.GetComponent<Text>().text = $"已经散步:{TimeHelper.ShowLeftTime(walkTime)}";

                self.Button_Walk.SetActive(self.RolePetInfo.PetStatus == 0);
                self.Button_Stop.SetActive(self.RolePetInfo.PetStatus == 2);

                self.Text_TotalExpHour.GetComponent<Text>().text = ComHelp.GetJiaYuanPetExp(rolePetInfo.PetLv, jiaYuanPet.MoodValue) + "/小时";
            }
        }
    }
}