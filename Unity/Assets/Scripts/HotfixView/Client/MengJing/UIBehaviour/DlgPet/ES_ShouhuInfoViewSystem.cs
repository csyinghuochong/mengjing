using System;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_ShouhuInfo))]
    [FriendOfAttribute(typeof(ES_ShouhuInfo))]
    public static partial class ES_ShouhuInfoSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ShouhuInfo self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ImageButtonButton.AddListener(self.OnImageButtonButton);
            self.E_ImageSelectButton.AddListener(self.OnImageSelectButton);
        }

        [EntitySystem]
        private static void Destroy(this ES_ShouhuInfo self)
        {
            self.DestroyWidget();
        }

        public static void OnImageButtonButton(this ES_ShouhuInfo self)
        {
            self.SelectHandler?.Invoke(self.Index);
        }

        public static void SetSelectHandler(this ES_ShouhuInfo self, int index, Action<int> action)
        {
            self.Index = index;
            self.SelectHandler = action;
        }

        public static void OnUpdateUI(this ES_ShouhuInfo self, int index)
        {
            using (zstring.Block())
            {
                if (index < 0 || index >= ConfigData.PetShouHuAttri.Count)
                {
                    Log.Error(zstring.Format("index < 0 || index >= ConfigHelper.PetShouHuAttri.Count:  {0}", index));
                    return;
                }

                self.Index = index;
                self.E_Text_NameText.text = ConfigData.PetShouHuAttri[index].Value;
                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, zstring.Format("ShouHu_{0}", index));
                Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

                self.E_ImageIconImage.sprite = sp;

                PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
                if (index >= petComponent.PetShouHuList.Count)
                {
                    return;
                }

                RolePetInfo rolePetInfo = petComponent.GetPetInfoByID(petComponent.PetShouHuList[index]);
                if (rolePetInfo == null)
                {
                    self.ES_ModelShow.SetShow(false);
                    return;
                }

                PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);
                self.ES_ModelShow.SetShow(true);
                self.ES_ModelShow.ShowOtherModel(zstring.Format("Pet/{0}", petConfig.PetModel)).Coroutine();
                self.ES_ModelShow.SetCameraPosition(new Vector3(0f, 100f, 450f));
                self.ES_ModelShow.Camera.fieldOfView = 30;
                // self.ES_ModelShow.SetRootPosition(new Vector2(index * 1000 + 10000, 0));
                self.ES_ModelShow.SetModelParentRotation(Quaternion.Euler(0f, -45f, 0f));

                int fightNum = 0;
                for (int i = 0; i < 4; i++)
                {
                    RolePetInfo rolePetInfoNow = petComponent.GetPetInfoByID(petComponent.PetShouHuList[i]);
                    if (rolePetInfoNow != null)
                    {
                        fightNum = fightNum + rolePetInfoNow.PetPingFen;
                    }
                }

                switch (index)
                {
                    case 0:
                        self.E_Text_AttriText.text = zstring.Format("暴击率附加{0}%",
                            (CommonHelp.GetPetShouHuPro(rolePetInfo.PetPingFen, fightNum) * 100).ToString("F2"));
                        break;

                    case 1:
                        self.E_Text_AttriText.text = zstring.Format("抗暴率附加{0}%",
                            (CommonHelp.GetPetShouHuPro(rolePetInfo.PetPingFen, fightNum) * 100).ToString("F2"));
                        break;

                    case 2:
                        self.E_Text_AttriText.text = zstring.Format("命中率附加{0}%",
                            (CommonHelp.GetPetShouHuPro(rolePetInfo.PetPingFen, fightNum) * 100).ToString("F2"));
                        break;

                    case 3:
                        self.E_Text_AttriText.text = zstring.Format("闪避率附加{0}%",
                            (CommonHelp.GetPetShouHuPro(rolePetInfo.PetPingFen, fightNum) * 100).ToString("F2"));
                        break;
                }
            }
        }
        public static void OnImageSelectButton(this ES_ShouhuInfo self)
        {
        }
    }
}
