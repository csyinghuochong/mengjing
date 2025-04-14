using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_UnionKeJiLearnItem))]
    [FriendOfAttribute(typeof(ES_UnionKeJiLearnItem))]
    public static partial class ES_UnionKeJiLearnItemSystem
    {
        [EntitySystem]
        private static void Awake(this ES_UnionKeJiLearnItem self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_ImageIconButton.AddListener(self.OnImageIcon);
        }
        [EntitySystem]
        private static void Destroy(this ES_UnionKeJiLearnItem self)
        {
            self.DestroyWidget();
        }
        
        public static void Init(this ES_UnionKeJiLearnItem self, int position)
        {
            self.Position = position;
        }

        public static void Refresh(this ES_UnionKeJiLearnItem self)
        {
            int configId = self.GetParent<ES_UnionKeJiLearn>().UserInfo.UnionKeJiList[self.Position];
            UnionKeJiConfig nowUnionKeJiConfig = UnionKeJiConfigCategory.Instance.Get(configId);

            
            for (int i = 0; i < nowUnionKeJiConfig.PreId.Length; i++)
            {
                bool havePre = UnionKeJiConfigCategory.Instance.HavePreId(nowUnionKeJiConfig.PreId[i], self.GetParent<ES_UnionKeJiLearn>().UserInfo.UnionKeJiList);

                using (zstring.Block())
                {
                    self.uiTransform.Find(zstring.Format("Img_line_{0}", i))?.gameObject.SetActive(havePre);
                }
            }

            int curlv = nowUnionKeJiConfig.QiangHuaLv;
            int maxlv = UnionKeJiConfigCategory.Instance.Get(self.GetParent<ES_UnionKeJiLearn>().UnionMyInfo.UnionKeJiList[self.Position]).QiangHuaLv;

            using (zstring.Block())
            {
                self.E_PointText.text = zstring.Format("{0}/{1}", curlv, maxlv);
            }

            self.E_NameText.text =  nowUnionKeJiConfig.EquipSpaceName.Substring(0, Regex.Match(nowUnionKeJiConfig.EquipSpaceName, @"\d").Index);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, nowUnionKeJiConfig.Icon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_ImageIconImage.sprite = sp;
            CommonViewHelper.SetImageGray(self.Root(), self.E_ImageIconImage.gameObject, curlv == 0);
        }

        private static void OnImageIcon(this ES_UnionKeJiLearnItem self)
        {
            self.GetParent<ES_UnionKeJiLearn>().UpdateInfo(self.Position);
        }
    }
}