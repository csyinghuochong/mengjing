using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_PetMeleeLevelItem))]
    [EntitySystemOf(typeof(Scroll_Item_PetMeleeLevelItem))]
    public static partial class Scroll_Item_PetMeleeLevelItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_PetMeleeLevelItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_PetMeleeLevelItem self)
        {
            self.DestroyWidget();
        }

        public static void OnInit(this Scroll_Item_PetMeleeLevelItem self, int sceneId, int index)
        {
            self.SceneId = sceneId;
            self.E_SelectedImage.gameObject.SetActive(false);
            using (zstring.Block())
            {
                self.E_NameText.text = zstring.Format("第{0}关", index + 1);
            }

            PetComponentC petComponentC = self.Root().GetComponent<PetComponentC>();
            int star = 0;
            foreach (PetMeleeFubenInfo petMeleeFubenInfo in petComponentC.PetMeleeFubenInfos)
            {
                if (petMeleeFubenInfo.PetFubenId == sceneId)
                {
                    star = petMeleeFubenInfo.Star;
                    break;
                }
            }

            for (int i = 1; i <= 3; i++)
            {
                using (zstring.Block())
                {
                    self.uiTransform.Find(zstring.Format("Start_Show_{0}", i)).gameObject.SetActive(i <= star);
                }
            }

            //SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(sceneId);
            List<int> monsterIds = MapViewHelper.GetSceneShowMonsters(sceneId);
            if (monsterIds.Count > 0)
            {
                MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(monsterIds[0]);
                self.E_IconImage.sprite = self.Root().GetComponent<ResourcesLoaderComponent>()
                       .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.MonsterIcon, monsterConfig.MonsterHeadIcon)); 
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int petMeleeDungeonId = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.PetMeleeDungeonId);
            CommonViewHelper.SetImageGray(self.Root(), self.E_IconImage.gameObject, self.SceneId > petMeleeDungeonId);
        }

        public static void SetSelected(this Scroll_Item_PetMeleeLevelItem self, int sceneId)
        {
            self.E_SelectedImage.gameObject.SetActive(self.SceneId == sceneId);
            CommonViewHelper.SetImageOutline(self.E_IconImage.gameObject, self.SceneId == sceneId);
        }
    }
}