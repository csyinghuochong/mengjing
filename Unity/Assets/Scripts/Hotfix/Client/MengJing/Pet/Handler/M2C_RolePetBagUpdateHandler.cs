using System.Collections.Generic;

namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_RolePetBagUpdateHandler: MessageHandler<Scene, M2C_RolePetBagUpdate>
    {
        protected override async ETTask Run(Scene root, M2C_RolePetBagUpdate message)
        {
            root.GetComponent<PetComponentC>().RolePetBag = message.RolePetBag;

            if (message.UpdateMode == 1)
            {
                List<KeyValuePair> oldPetSkin = root.GetComponent<PetComponentC>().GetPetSkinCopy();
                //抛出事件。 刷新UI

                EventSystem.Instance.Publish(root,
                    new RolePetAdd() { OldPetSkin = oldPetSkin, RolePetInfo = message.RolePetBag[message.RolePetBag.Count - 1] });
            }

            await ETTask.CompletedTask;
        }
    }
}