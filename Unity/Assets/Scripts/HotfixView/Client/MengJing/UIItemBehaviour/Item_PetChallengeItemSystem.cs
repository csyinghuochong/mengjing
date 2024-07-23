using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_PetChallengeItem))]
    [EntitySystemOf(typeof(Scroll_Item_PetChallengeItem))]
    public static partial class Scroll_Item_PetChallengeItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_PetChallengeItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_PetChallengeItem self)
        {
            self.DestroyWidget();
        }

        public static void OnClickChallengeItem(this Scroll_Item_PetChallengeItem self)
        {
            self.ClickHandler(self.PetFubenId);
        }

        public static void SetSelected(this Scroll_Item_PetChallengeItem self, int petfubenId)
        {
            if (self.uiTransform == null)
            {
                Log.Debug($"self.uiTransform == null:   {self.PetFubenId}");
            }

            self.E_ImageSelect.gameObject.SetActive(self.PetFubenId == petfubenId);
        }

        public static void SetClickHandler(this Scroll_Item_PetChallengeItem self, Action<int> action)
        {
            self.ClickHandler = action;
        }

        public static void HideLines(this Scroll_Item_PetChallengeItem self)
        {
            self.E_ImageLine_1.gameObject.SetActive(false);
            self.E_ImageLine_2.gameObject.SetActive(false);
        }

        public static async ETTask OnUpdateUI(this Scroll_Item_PetChallengeItem self, PetFubenConfig petfubenConf, int index, int star, bool locked)
        {
            Button button = self.uiTransform.GetComponent<Button>();
            button.AddListener(self.OnClickChallengeItem);

            self.PetFubenId = petfubenConf.Id;
            self.E_Node_1.transform.localPosition = new Vector3(index % 2 == 0 ? -105f : -280f, 30f, 0f);
            self.E_ImageLine_1.gameObject.SetActive(index % 2 == 0);
            self.E_ImageLine_2.gameObject.SetActive(index % 2 != 0);
            self.E_TextLevel.text = petfubenConf.Name;
            using (zstring.Block())
            {
                self.E_TextCombat.text = zstring.Format("建议最低队伍等级： {0}级", petfubenConf.Lv);
            }

            self.E_Node_2.gameObject.SetActive(locked);
            self.E_StartNode.gameObject.SetActive(!locked);
            self.E_Start_2.gameObject.SetActive(star >= 3);
            self.E_Start_1.gameObject.SetActive(star >= 2);
            self.E_Start_0.gameObject.SetActive(star >= 1);

            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.MonsterIcon, petfubenConf.ShowIcon);
            Sprite sp = await self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<Sprite>(path);
            self.E_ImageIcon.sprite = sp;

            CommonViewHelper.SetImageGray(self.Root(), self.E_ImageDi.gameObject, locked);
            CommonViewHelper.SetImageGray(self.Root(), self.E_ImageIcon.gameObject, locked);
        }
    }
}