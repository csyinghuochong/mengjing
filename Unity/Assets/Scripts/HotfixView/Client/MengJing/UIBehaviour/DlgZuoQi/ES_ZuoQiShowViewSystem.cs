using System.Linq;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_ZuoQiShowItem))]
    [EntitySystemOf(typeof(ES_ZuoQiShow))]
    [FriendOf(typeof(ES_ZuoQiShow))]
    public static partial class ES_ZuoQiShowSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ZuoQiShow self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ButtonFightButton.AddListener(() => { self.OnButtonFight().Coroutine(); });

            self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_ZuoQiShow self)
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

        private static void OnInitUI(this ES_ZuoQiShow self)
        {
            self.ShowZuoQiShowConfigs.Clear();
            self.ShowZuoQiShowConfigs.AddRange(ZuoQiShowConfigCategory.Instance.GetAll().Values.ToList());
            self.ShowZuoQiShowConfigs.Sort((a, b) => a.Quality - b.Quality);

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.ShowZuoQiShowConfigs.Count; i++)
            {
                if (!self.ScrollItemZuoQiShowItems.ContainsKey(i))
                {
                    Scroll_Item_ZuoQiShowItem item = self.AddChild<Scroll_Item_ZuoQiShowItem>();
                    string path = "Assets/Bundles/UI/Item/Item_ZuoQiShowItem.prefab";
                    if (!self.AssetList.Contains(path))
                    {
                        self.AssetList.Add(path);
                    }

                    GameObject prefab = resourcesLoaderComponent.LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, self.E_ZuoQiShowItemsScrollRect.transform.Find("Content").gameObject.transform);
                    item.BindTrans(go.transform);
                    self.ScrollItemZuoQiShowItems.Add(i, item);
                }

                Scroll_Item_ZuoQiShowItem scrollItemZuoQiShowItem = self.ScrollItemZuoQiShowItems[i];
                scrollItemZuoQiShowItem.uiTransform.gameObject.SetActive(true);
                scrollItemZuoQiShowItem.OnInitUI(self.ShowZuoQiShowConfigs[i]);
            }

            if (self.ScrollItemZuoQiShowItems.Count > self.ShowZuoQiShowConfigs.Count)
            {
                for (int i = self.ShowZuoQiShowConfigs.Count; i < self.ScrollItemZuoQiShowItems.Count; i++)
                {
                    Scroll_Item_ZuoQiShowItem scrollItemZuoQiShowItem = self.ScrollItemZuoQiShowItems[i];
                    scrollItemZuoQiShowItem.uiTransform.gameObject.SetActive(false);
                }
            }

            Scroll_Item_ZuoQiShowItem Item = self.ScrollItemZuoQiShowItems[0];
            Item.OnClick();
        }

        public static void UpdateInfo(this ES_ZuoQiShow self, ZuoQiShowConfig zuoQiConfig)
        {
            self.ZuoQiConfig = zuoQiConfig;

            // 虚空龙的在UI上无法显示，这里暂时替换
            string modelID = zuoQiConfig.ModelID;
            // if (zuoQiConfig.ModelID == "10010")
            // {
            //     modelID = "10010Show";
            // }
            self.ES_ModelShow.ShowOtherModel("ZuoQi/" + modelID).Coroutine();
            self.ES_ModelShow.SetCameraPosition(new Vector3(0f, 112f, 450f));
            self.ES_ModelShow.SetModelParentRotation(Quaternion.Euler(0f, -45f, 0f));

            self.E_TextNameText.text = zuoQiConfig.Name;
            
            self.E_DesText.text = self.ZuoQiConfig.Des;

            self.E_LabProDesText.text = self.ZuoQiConfig.AddPropertyDes;

            SkillBuffConfig buffCof = SkillBuffConfigCategory.Instance.Get(self.ZuoQiConfig.MoveBuffID);
            self.E_LabDesText.text = buffCof.BuffDescribe;

            self.E_Lab_LaiYuanText.text = self.ZuoQiConfig.GetDes;

            bool have = self.IsHaveZuoQi(zuoQiConfig.Id);

            self.E_YesText.gameObject.SetActive(have);
            self.E_NoText.gameObject.SetActive(!have);
            self.E_ButtonFightButton.gameObject.SetActive(have);
            self.E_TextNameText.color = FunctionUI.QualityReturnColor(zuoQiConfig.Quality);

            foreach (Scroll_Item_ZuoQiShowItem item in self.ScrollItemZuoQiShowItems.Values)
            {
                item.SetSelected(zuoQiConfig.Id);
            }
        }

        private static async ETTask OnButtonFight(this ES_ZuoQiShow self)
        {
            if (!self.IsHaveZuoQi(self.ZuoQiConfig.Id))
            {
                FlyTipComponent.Instance.ShowFlyTip("请先激活当前坐骑！");
                return;
            }

            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            if (self.ZuoQiConfig.Id == 10001 && userInfo.Lv < 25)
            {
                FlyTipComponent.Instance.ShowFlyTip("等级达到25级才可以骑乘坐骑喔！");
                return;
            }

            M2C_HorseFightResponse response = await BagClientNetHelper.HorseFight(self.Root(), self.ZuoQiConfig.Id);

            if (response.Error == ErrorCode.ERR_Success)
            {
                FlyTipComponent.Instance.ShowFlyTip("激活坐骑成功，清在主界面点击骑乘按钮即可喔！");
            }
        }

        private static bool IsHaveZuoQi(this ES_ZuoQiShow self, int zuoqiId)
        {
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            return userInfo.HorseIds.Contains(zuoqiId);
        }
    }
}
