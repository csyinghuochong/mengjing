namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_SerialReardHandler : MessageLocationHandler<Unit, C2M_SerialReardRequest, M2C_SerialReardResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_SerialReardRequest request, M2C_SerialReardResponse response )
        {
            if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) < 5)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            if (numericComponent.GetAsInt(NumericType.SerialNumber) >= 5)
            {
                response.Error = ErrorCode.ERR_TimesIsNot;
                return;
            }

            using (await unit.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Received, unit.Id))
            {
                M2L_SerialReardRequest m2Center_Serial = M2L_SerialReardRequest.Create();
                m2Center_Serial.SerialNumber = request.SerialNumber;
                
                ActorId centerid = UnitCacheHelper.GetLoginCenterId();
                L2M_SerialReardResponse m2m_TrasferUnitResponse = (L2M_SerialReardResponse)await unit.Root().GetComponent<MessageSender>().Call
                          (centerid, m2Center_Serial);

                response.Error = m2m_TrasferUnitResponse.Error;
                if (m2m_TrasferUnitResponse.Error == ErrorCode.ERR_Success)
                {
                    int serialIndex = int.Parse(m2m_TrasferUnitResponse.Message);
                    string reward = ConfigData.SerialReward[serialIndex];
                    unit.GetComponent<BagComponentS>().OnAddItemData(reward, $"{ItemGetWay.Serial}_{TimeHelper.ServerNow()}");
                    numericComponent.ApplyChange(NumericType.SerialNumber,  1);
                }
            }
            await ETTask.CompletedTask;
        }
    }
}
