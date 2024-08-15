namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class Item_DigForTreasure : AEvent<Scene, DigForTreasure>
    {
        protected override async ETTask Run(Scene scene, DigForTreasure args)
        {
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(args.BagInfo.ItemID);
            if (itemConfig.ItemSubType == 113)
            {
                scene.GetComponent<UIComponent>().GetDlgLogic<DlgMain>().View.ES_DigTreasure.OnInitUI(args.BagInfo);
            }

            if (itemConfig.ItemSubType == 127)
            {
                await scene.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_TreasureOpen);
                scene.GetComponent<UIComponent>().GetDlgLogic<DlgTreasureOpen>().OnInitUI(args.BagInfo);
            }
        }
    }
}