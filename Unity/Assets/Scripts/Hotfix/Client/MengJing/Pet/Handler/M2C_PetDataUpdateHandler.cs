namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_PetDataUpdateHandler: MessageHandler<Scene, M2C_PetDataUpdate>
    {
        protected override async ETTask Run(Scene root, M2C_PetDataUpdate message)
        {
            switch (message.UpdateType)
            {
                case (int)UserDataType.Lv:
                    RolePetInfo rolePetInfo = root.GetComponent<PetComponentC>().GetPetInfoByID(message.PetId);
                    if (rolePetInfo != null && rolePetInfo.Id == message.PetId)
                    {
                        rolePetInfo.AddPropretyNum += (int.Parse(message.UpdateTypeValue) - rolePetInfo.PetLv) * 5;
                        rolePetInfo.PetLv = int.Parse(message.UpdateTypeValue);
                    }

                    break;
                case (int)UserDataType.Exp:
                    rolePetInfo = root.GetComponent<PetComponentC>().GetPetInfoByID(message.PetId);
                    if (rolePetInfo != null && rolePetInfo.Id == message.PetId)
                    {
                        rolePetInfo.PetExp = int.Parse(message.UpdateTypeValue);
                    }

                    break;
                case (int)UserDataType.PetStatus:
                    rolePetInfo = root.GetComponent<PetComponentC>().GetPetInfoByID(message.PetId);
                    if (rolePetInfo != null)
                    {
                        rolePetInfo.PetStatus = int.Parse(message.UpdateTypeValue);
                    }

                    break;
                case (int)UserDataType.Name:
                    rolePetInfo = root.GetComponent<PetComponentC>().GetPetInfoByID(message.PetId);
                    if (rolePetInfo != null)
                    {
                        rolePetInfo.PetName = message.UpdateTypeValue;
                    }

                    break;
                default:
                    break;
            }

            await ETTask.CompletedTask;
        }
    }
}