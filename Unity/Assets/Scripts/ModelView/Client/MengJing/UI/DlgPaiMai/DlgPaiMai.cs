using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgPaiMaiViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgPaiMai : Entity, IAwake, IUILogic
    {
        public DlgPaiMaiViewComponent View
        {
            get => this.GetComponent<DlgPaiMaiViewComponent>();
        }

        public Dictionary<long, PaiMaiShopItemInfo> PaiMaiShopItemInfos { get; set; } = new();

        private EntityRef<ES_PaiMaiShop> m_es_paimaishop = null;

        public ES_PaiMaiShop ES_PaiMaiShop
        {
            get
            {
                ES_PaiMaiShop es = this.m_es_paimaishop;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_PaiMaiShop.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_paimaishop = this.AddChild<ES_PaiMaiShop, Transform>(go.transform);
                }

                return this.m_es_paimaishop;
            }
        }

        private EntityRef<ES_PaiMaiBuy> m_es_paimaibuy = null;

        public ES_PaiMaiBuy ES_PaiMaiBuy
        {
            get
            {
                ES_PaiMaiBuy es = this.m_es_paimaibuy;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_PaiMaiBuy.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_paimaibuy = this.AddChild<ES_PaiMaiBuy, Transform>(go.transform);
                }

                return this.m_es_paimaibuy;
            }
        }

        private EntityRef<ES_PaiMaiSell> m_es_paimaisell = null;

        public ES_PaiMaiSell ES_PaiMaiSell
        {
            get
            {
                ES_PaiMaiSell es = this.m_es_paimaisell;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_PaiMaiSell.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_paimaisell = this.AddChild<ES_PaiMaiSell, Transform>(go.transform);
                }

                return this.m_es_paimaisell;
            }
        }

        private EntityRef<ES_PaiMaiDuiHuan> m_es_paimaiduihuan = null;

        public ES_PaiMaiDuiHuan ES_PaiMaiDuiHuan
        {
            get
            {
                ES_PaiMaiDuiHuan es = this.m_es_paimaiduihuan;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_PaiMaiDuiHuan.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_paimaiduihuan = this.AddChild<ES_PaiMaiDuiHuan, Transform>(go.transform);
                }

                return this.m_es_paimaiduihuan;
            }
        }
    }
}