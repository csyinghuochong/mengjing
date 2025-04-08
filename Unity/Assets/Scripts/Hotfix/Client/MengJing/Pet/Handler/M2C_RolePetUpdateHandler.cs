using System.Collections.Generic;

namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_RolePetUpdateHandler: MessageHandler<Scene, M2C_RolePetUpdate>
    {
        protected override async ETTask Run(Scene root, M2C_RolePetUpdate message)
        {
            PetComponentC petComponent = root.GetComponent<PetComponentC>();
            List<KeyValuePair> oldPetSkin = petComponent.GetPetSkinCopy();

            petComponent.OnRecvRolePetUpdate(message);

            if (message.PetInfoAdd.Count > 0 && (message.GetWay == ItemGetWay.TakeOutBag || message.GetWay == ItemGetWay.PickItem ) )
            {
                PetSkinConfig petSkinConfig = PetSkinConfigCategory.Instance.Get(message.PetInfoAdd[0].SkinId);
                HintHelp.ShowHint(root, $"获得{petSkinConfig.Name}宠物!");
                return;
            }

            if (message.PetInfoAdd.Count > 0)
            {
                EventSystem.Instance.Publish(root, new RolePetAdd() { OldPetSkin = oldPetSkin, RolePetInfo = message.PetInfoAdd[0] });
            }

            await ETTask.CompletedTask;
        }
    }
}