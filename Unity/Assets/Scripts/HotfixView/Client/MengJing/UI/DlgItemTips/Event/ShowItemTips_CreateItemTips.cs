using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class ShowItemTips_CreateItemTips: AEvent<Scene, ShowItemTips>
    {
        protected override async ETTask Run(Scene root, ShowItemTips args)
        {
            int itemWidth = 462;
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(args.BagInfo.ItemID);
            if (args.ItemOperateEnum == ItemOperateEnum.XiangQianBag)
            {
                // if (itemConfig.ItemType == (int)ItemTypeEnum.PetHeXin)
                // {
                //     return;
                // }
                //
                // if (args.bagInfo.IfJianDing)
                // {
                //     return;
                // }
            }

            if (args.ItemOperateEnum == ItemOperateEnum.Juese)
            {
                // UI uirole = UIHelper.GetUI(args.ZoneScene, UIType.UIRole);
                // UIRoleComponent roleComponent = uirole.GetComponent<UIRoleComponent>();
                // bool rolegem = roleComponent.UIPageButton.CurrentIndex == (int)RolePageEnum.RoleGem;
                // if (rolegem)
                // {
                //     uirole.GetComponent<UIRoleComponent>().OnClickXiangQianItem(args.bagInfo);
                //     return;
                // }
            }

            if (args.ItemOperateEnum == ItemOperateEnum.XiangQianBag
                && itemConfig.ItemType == (int)ItemTypeEnum.Equipment)
            {
                // UI uirole = UIHelper.GetUI(args.ZoneScene, UIType.UIRole);
                // uirole.GetComponent<UIRoleComponent>().OnClickXiangQianItem(args.bagInfo);
                // return;
            }

            if (itemConfig.ItemType == (int)ItemTypeEnum.Equipment)
            {
                BagInfo haveEquip = null;
                if (itemConfig.EquipType == 301)
                {
                    // UI uI1 = UIHelper.GetUI(args.ZoneScene, UIType.UIPet);
                    // haveEquip = uI1 != null? uI1.GetComponent<UIPetComponent>().GetEquipBySubType(itemConfig.ItemSubType) : null;
                }
                else
                {
                    haveEquip = root.GetComponent<BagComponentClient>().GetEquipBySubType(ItemLocType.ItemLocEquip, itemConfig.ItemSubType);
                }

                await root.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_EquipDuiBiTips);
                if (haveEquip != null && (args.ItemOperateEnum == ItemOperateEnum.Bag || args.ItemOperateEnum == ItemOperateEnum.PaiMaiBuy ||
                        args.ItemOperateEnum == ItemOperateEnum.PetEquipBag))
                {
                    root.GetComponent<UIComponent>().GetDlgLogic<DlgEquipDuiBiTips>()
                            .OnUpdateDuiBiUI(haveEquip, args, itemWidth, args.ItemOperateEnum);
                }
                else if (args.BagInfo.IfJianDing == false)
                {
                    //鉴定后或无需鉴定的
                    root.GetComponent<UIComponent>().GetDlgLogic<DlgEquipDuiBiTips>().OnUpdateEquipUI(args).Coroutine();
                    root.GetComponent<UIComponent>().GetDlgLogic<DlgEquipDuiBiTips>().View.EG_Tips1RectTransform.GetComponent<RectTransform>()
                                    .anchoredPosition =
                            ReturnX(root, args, itemWidth);
                }
                else
                {
                    //显示未鉴定
                    root.GetComponent<UIComponent>().GetDlgLogic<DlgEquipDuiBiTips>().OnUpdateAppraisalUI(args);
                    root.GetComponent<UIComponent>().GetDlgLogic<DlgEquipDuiBiTips>().View.EG_Tips1RectTransform.GetComponent<RectTransform>()
                                    .anchoredPosition =
                            ReturnX(root, args, itemWidth);
                }
            }
            else
            {
                UIComponent uiComponent = root.GetComponent<UIComponent>();
                await uiComponent.ShowWindowAsync(WindowID.WindowID_ItemTips);
                uiComponent.GetDlgLogic<DlgItemTips>().SetPosition(ReturnX(root, args, itemWidth));
                uiComponent.GetDlgLogic<DlgItemTips>().RefreshInfo(args.BagInfo, args.ItemOperateEnum);
            }
        }

        private Vector2 ReturnX(Scene root, ShowItemTips args, float weight)
        {
            Vector2 vectorPoint;
            GlobalComponent globalComponent = root.GetComponent<GlobalComponent>();
            RectTransform canvas = globalComponent.NormalRoot.GetComponent<RectTransform>();
            Camera uiCamera = globalComponent.UICamera.GetComponent<Camera>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, new Vector2(x: args.InputPoint.x, y: args.InputPoint.y), uiCamera,
                out vectorPoint);

            if (vectorPoint.x <= 0)
            {
                vectorPoint.x += (int)(weight * 0.5 + 50f);
            }
            else
            {
                vectorPoint.x -= (int)(weight * 0.5 + 50f);
            }

            vectorPoint.y = 0f;
            return vectorPoint;
        }
    }
}