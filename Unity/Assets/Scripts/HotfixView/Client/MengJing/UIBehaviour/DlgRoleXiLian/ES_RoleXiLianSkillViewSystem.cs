using System.Linq;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_RoleXiLianSkillItem))]
    [EntitySystemOf(typeof(ES_RoleXiLianSkill))]
    [FriendOfAttribute(typeof(ES_RoleXiLianSkill))]
    public static partial class ES_RoleXiLianSkillSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RoleXiLianSkill self, Transform transform)
        {
            self.uiTransform = transform;
            self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_RoleXiLianSkill self)
        {
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.AssetList.Count; i++)
            {
                resourcesLoaderComponent.UnLoadAsset(self.AssetList[i]);
            }

            self.AssetList.Clear();
            self.AssetList = null;

            self.DestroyWidget();
        }

        public static int GetXiLianLevel(this ES_RoleXiLianSkill self, Unit unit)
        {
            int xiliandu = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.ItemXiLianDu);
            int xilianLevel = XiLianHelper.GetXiLianId(xiliandu);
            xilianLevel = xilianLevel != 0 ? EquipXiLianConfigCategory.Instance.Get(xilianLevel).XiLianLevel : 0;
            return xilianLevel;
        }

        public static void OnInitUI(this ES_RoleXiLianSkill self)
        {
            self.ShouJiConfigs = EquipXiLianConfigCategory.Instance.GetAll().Values.ToList();
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            self.XilianLevel = self.GetXiLianLevel(unit);

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.ShouJiConfigs.Count; i++)
            {
                if (!self.ScrollItemRoleXiLianSkillItems.ContainsKey(i))
                {
                    Scroll_Item_RoleXiLianSkillItem item = self.AddChild<Scroll_Item_RoleXiLianSkillItem>();
                    string path = "Assets/Bundles/UI/Item/Item_RoleXiLianSkillItem.prefab";
                    if (!self.AssetList.Contains(path))
                    {
                        self.AssetList.Add(path);
                    }

                    GameObject prefab = resourcesLoaderComponent.LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab,
                        self.E_RoleXiLianSkillItemsScrollRect.transform.Find("Content").gameObject.transform);
                    item.BindTrans(go.transform);
                    self.ScrollItemRoleXiLianSkillItems.Add(i, item);
                }

                Scroll_Item_RoleXiLianSkillItem scrollItemRoleXiLianSkillItem = self.ScrollItemRoleXiLianSkillItems[i];
                scrollItemRoleXiLianSkillItem.uiTransform.gameObject.SetActive(true);
                scrollItemRoleXiLianSkillItem.OnInitUI(self.ShouJiConfigs[i]);
                scrollItemRoleXiLianSkillItem.OnUpdateUI(self.XilianLevel);
            }

            if (self.ScrollItemRoleXiLianSkillItems.Count > self.ShouJiConfigs.Count)
            {
                for (int i = self.ScrollItemRoleXiLianSkillItems.Count; i < self.ScrollItemRoleXiLianSkillItems.Count; i++)
                {
                    Scroll_Item_RoleXiLianSkillItem scrollItemRoleXiLianSkillItem = self.ScrollItemRoleXiLianSkillItems[i];
                    scrollItemRoleXiLianSkillItem.uiTransform.gameObject.SetActive(false);
                }
            }

            self.OnUpdateUI();
        }

        public static void OnUpdateUI(this ES_RoleXiLianSkill self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int xilianLevel = self.GetXiLianLevel(unit);

            if (self.ScrollItemRoleXiLianSkillItems != null)
            {
                foreach (Scroll_Item_RoleXiLianSkillItem item in self.ScrollItemRoleXiLianSkillItems.Values)
                {
                    if (item.uiTransform != null)
                    {
                        item.OnUpdateUI(xilianLevel);
                    }
                }
            }
        }
    }
}