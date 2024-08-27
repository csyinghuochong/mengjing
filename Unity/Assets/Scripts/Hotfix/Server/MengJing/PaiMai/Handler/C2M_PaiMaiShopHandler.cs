using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public  class C2M_PaiMaiShopHandler : MessageLocationHandler<Unit, C2M_PaiMaiShopRequest, M2C_PaiMaiShopResponse>
    {
		//拍卖快捷列表购买道具
		protected override async ETTask Run(Unit unit, C2M_PaiMaiShopRequest request, M2C_PaiMaiShopResponse response)
		{
			if(!PaiMaiSellConfigCategory.Instance.Contain(request.PaiMaiId))
			{
                response.Error = ErrorCode.ERR_ItemNotExist;
                return;
            }

			PaiMaiSellConfig paiMaiSellConfig = PaiMaiSellConfigCategory.Instance.Get(request.PaiMaiId);
			if (paiMaiSellConfig == null)
			{
				response.Error = ErrorCode.ERR_NetWorkError;
				return;
			}

			ItemConfig itemConfig = ItemConfigCategory.Instance.Get(paiMaiSellConfig.ItemID);
			int cell = (int)math.ceil(request.BuyNum * 1f / itemConfig.ItemPileSum);
			if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) < cell)
			{
				response.Error = ErrorCode.ERR_BagIsFull;
				return;
			}
			if (request.BuyNum < 0 || request.BuyNum > 1000)
			{
				response.Error = ErrorCode.ERR_MysteryItem_Max;
				return;
			}

            Log.Warning($"拍卖行购买请求 : {unit.Id}  {paiMaiSellConfig.ItemID}  {request.BuyNum}  {cell}");

            using (await unit.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Buy, unit.Id))
            {

	            M2P_PaiMaiShopRequest m2P_PaiMaiShopRequest = M2P_PaiMaiShopRequest.Create();
	            m2P_PaiMaiShopRequest.ItemID = paiMaiSellConfig.ItemID;
	            m2P_PaiMaiShopRequest.BuyNum = request.BuyNum;
	            //m2P_PaiMaiShopRequest.//Price = r_PaiMaiShopResponse.PaiMaiShopItemInfo.Price,
	            m2P_PaiMaiShopRequest.ActorId = unit.GetComponent<UserInfoComponentS>().UserInfo.Gold;

				ActorId paimaiServerId = StartSceneConfigCategory.Instance.GetBySceneName(unit.Zone(), "PaiMai").ActorId;
				P2M_PaiMaiShopResponse r_PaiMaiShopResponse = (P2M_PaiMaiShopResponse)await unit.Root().GetComponent<MessageSender>().Call(paimaiServerId, m2P_PaiMaiShopRequest);

				if (r_PaiMaiShopResponse.Error != ErrorCode.ERR_Success)
				{
					response.Error = r_PaiMaiShopResponse.Error;
					return;
				}

				//消耗金币
				long costGold = (long)r_PaiMaiShopResponse.PaiMaiShopItemInfo.Price * request.BuyNum;
				if (costGold > 0 && unit.GetComponent<UserInfoComponentS>().UserInfo.Gold >= costGold)
				{
					//发送金币
					unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneySub(UserDataType.Gold, (costGold * -1).ToString(), true, ItemGetWay.PaiMaiShop);

					//添加道具
					List<RewardItem> rewardItems = new List<RewardItem>();
					rewardItems.Add(new RewardItem() { ItemID = paiMaiSellConfig.ItemID, ItemNum = request.BuyNum });
					bool result =  unit.GetComponent<BagComponentS>().OnAddItemData(rewardItems, string.Empty, $"{ItemGetWay.PaiMaiShop}_{TimeHelper.ServerNow()}");
					Log.Warning($"拍卖行购买道具 : {unit.Id}  {paiMaiSellConfig.ItemID}  {request.BuyNum}  {r_PaiMaiShopResponse.PaiMaiShopItemInfo.Price} {cell} {result}");
				}
				else
				{
					response.Error = ErrorCode.ERR_GoldNotEnoughError;
				}
			}
			await ETTask.CompletedTask;
		}

	}
}
