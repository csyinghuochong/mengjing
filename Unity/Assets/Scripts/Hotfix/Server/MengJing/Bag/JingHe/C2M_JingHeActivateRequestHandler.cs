namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_JingHeActivateRequestHandler : MessageLocationHandler<Unit, C2M_JingHeActivateRequest, M2C_JingHeActivateResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_JingHeActivateRequest request, M2C_JingHeActivateResponse response)
        {
            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
            ItemInfo bagInfoJinHe = bagComponent.GetItemByLoc(ItemLocType.ItemLocBag, request.BagInfoId);
            if (bagInfoJinHe == null)
            {
                response.Error = ErrorCode.ERR_ItemNotExist;
                return;
            }
            //通知客户端背包刷新
            M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();

            bagInfoJinHe.XiLianHideProLists.Clear();
            HideProList hideProList = ItemHelper.GetJingHeHidePro(bagInfoJinHe.ItemID, int.Parse(bagInfoJinHe.ItemPar));
            if (hideProList != null)
            {
                bagInfoJinHe.XiLianHideProLists.Add(hideProList);
            }
            else
            {
                Log.Console($"晶核激活失败: {bagInfoJinHe.ItemID}");
            }
            bagInfoJinHe.IfJianDing = false;
            m2c_bagUpdate.BagInfoUpdate.Add(bagInfoJinHe.ToMessage());
            MapMessageHelper.SendToClient(unit, m2c_bagUpdate);
            await ETTask.CompletedTask;
        }
    }
}
