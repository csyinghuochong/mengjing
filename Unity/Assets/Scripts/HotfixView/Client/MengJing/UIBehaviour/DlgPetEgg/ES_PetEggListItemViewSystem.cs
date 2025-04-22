using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ET.Client
{
    [Invoke(TimerInvokeType.PetEggListItemTimer)]
    public class PetEggListItemTimer : ATimer<ES_PetEggListItem>
    {
        protected override void Run(ES_PetEggListItem self)
        {
            try
            {
                self.OnTimer();
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

    [EntitySystemOf(typeof(ES_PetEggListItem))]
    [FriendOfAttribute(typeof(ES_PetEggListItem))]
    public static partial class ES_PetEggListItemSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetEggListItem self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_Text_TimeText.text = "";

            self.E_ButtonOpenButton.gameObject.SetActive(false);
            self.E_ButtonGetButton.gameObject.SetActive(false);
            self.E_ButtonFuHuaButton.gameObject.SetActive(false);

            self.E_OpenSlotButton.AddListener(self.OnOpenSlotButton);
            self.E_ShowPetEggListButton.AddListener(self.OnShowPetEggListButton);
            self.E_ButtonOpenButton.AddListener(self.OnButtonOpenButton);
            self.E_ButtonGetButton.AddListener(self.OnButtonGetButton);
            self.E_ButtonFuHuaButton.AddListener(self.OnButtonFuHuaButton);
        }

        [EntitySystem]
        private static void Destroy(this ES_PetEggListItem self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            self.DestroyWidget();
        }

        private static void OnOpenSlotButton(this ES_PetEggListItem self)
        {
            self.GetParent<ES_PetEggList>().OnOpenSlotButton(self.Index);
        }
        
        private static void OnShowPetEggListButton(this ES_PetEggListItem self)
        {
            self.GetParent<ES_PetEggList>().ShowPetEggSelectList(self.Index);
        }

        private static void OnButtonOpenButton(this ES_PetEggListItem self)
        {
            self.GetParent<ES_PetEggList>().OnButtonOpenButton(self.RolePetEgg, self.Index);
        }
        
        private static void OnButtonGetButton(this ES_PetEggListItem self)
        {
            self.GetParent<ES_PetEggList>().OnButtonGetButton(self.Index).Coroutine();
        }
        
        private static void OnButtonFuHuaButton(this ES_PetEggListItem self)
        {
            self.GetParent<ES_PetEggList>().OnButtonFuHuaButton(self.Index).Coroutine();
        }

        public static void OnTimer(this ES_PetEggListItem self)
        {
            long timeNow = self.RolePetEgg.Value - TimeHelper.ServerNow();
            self.E_Text_TimeText.text = TimeHelper.ShowLeftTime(timeNow);

            if (timeNow <= 0)
            {
                self.SetFuHuaEnd();
                self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            }
        }

        private static void SetEggNoFuhua(this ES_PetEggListItem self)
        {
            self.E_ButtonFuHuaButton.gameObject.SetActive(true);

            string[] useparams = ItemConfigCategory.Instance.Get((int)self.RolePetEgg.KeyId).ItemUsePar.Split('@');
            long timeNow = long.Parse(useparams[0]);
            using (zstring.Block())
            {
                self.E_Text_TimeText.text = zstring.Format("孵化时间:{0}", TimeHelper.ShowLeftTime(timeNow * 1000));
            }

            self.E_ButtonOpenButton.gameObject.SetActive(false);
            self.E_ButtonGetButton.gameObject.SetActive(false);
        }

        private static void SetFuhua(this ES_PetEggListItem self)
        {
            self.E_ButtonFuHuaButton.gameObject.SetActive(false);
            self.E_Text_TimeText.gameObject.SetActive(true);
            self.E_ButtonOpenButton.gameObject.SetActive(true);
            self.E_ButtonGetButton.gameObject.SetActive(false);
        }

        private static void SetFuHuaEnd(this ES_PetEggListItem self)
        {
            self.E_ButtonFuHuaButton.gameObject.SetActive(false);
            self.E_Text_TimeText.gameObject.SetActive(false);
            self.E_ButtonOpenButton.gameObject.SetActive(false);
            self.E_ButtonGetButton.gameObject.SetActive(true);
        }

        public static void OnUpdateUI(this ES_PetEggListItem self, KeyValuePairLong4 rolePetEgg, int index)
        {
            self.Index = index;
            self.RolePetEgg = rolePetEgg;

            if (rolePetEgg.Value3 == 0)
            {
                self.EG_Node0RectTransform.gameObject.SetActive(true);
                string[] costItemsList = GlobalValueConfigCategory.Instance.Get(135).Value.Split('@');
                string[] costItems = costItemsList[index].Split(';');
                string itemName = ItemConfigCategory.Instance.Get(int.Parse(costItems[0])).ItemName;
                string itemNum = costItems[1];
                self.E_Text_OpenSlotValueText.text = itemNum;
            }
            else
            {
                self.EG_Node0RectTransform.gameObject.SetActive(false);
            }
            
            self.EG_Node2RectTransform.gameObject.SetActive(rolePetEgg != null && rolePetEgg.KeyId > 0);
            self.EG_Node1RectTransform.gameObject.SetActive(!self.EG_Node0RectTransform.gameObject.activeSelf && !self.EG_Node2RectTransform.gameObject.activeSelf);
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            if (!self.EG_Node2RectTransform.gameObject.activeSelf)
            {
                return;
            }

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get((int)rolePetEgg.KeyId);

            self.E_Text_NameText.text = itemConfig.ItemName;
            
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_PetEggIconImage.sprite = sp;

            if (rolePetEgg.Value == 0)
            {
                self.SetEggNoFuhua();
                return;
            }

            long timeNow = rolePetEgg.Value - TimeHelper.ServerNow();
            if (timeNow < 0)
            {
                self.SetFuHuaEnd();
                return;
            }

            self.SetFuhua();
            self.OnTimer();

            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.PetEggListItemTimer, self);
        }
    }
}