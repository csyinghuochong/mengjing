using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(MJCameraComponent))]
    [FriendOf(typeof(MJCameraComponent))]

    public static partial class MJCameraComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.MJCameraComponent self)
        {
            self.MainCamera = GameObject.Find("Global/Main Camera").GetComponent<Camera>();
            self.OffsetPostion = new Vector3(0, 10f, -6f);
            self.PullRate = 1f;
            self.CameraMoveType = CameraMoveType.Normal;
            self.MainUnit = UnitHelper.GetMyUnitFromClientScene(self.Root());
        }
        
        [EntitySystem]
        private static void LateUpdate(this ET.Client.MJCameraComponent self)
        {

        }

        //== SceneTypeEnum.MainCityScene
        public static  void OnEnterScene(this MJCameraComponent self, int sceneTypeEnum)
        {
            switch (sceneTypeEnum)
            {
                case SceneTypeEnum.PetTianTi:
                    self.CameraMoveType = CameraMoveType.PetFuben;
                    self.MainCamera.transform.position = AIHelp.FuBenCameraPosition();
                    self.MainCamera.transform.localRotation = Quaternion.Euler(AIHelp.FuBenCameraRotation());
                    break;
                case SceneTypeEnum.PetDungeon:
                    self.CameraMoveType = CameraMoveType.PetFuben;
                    self.MainCamera.transform.position = AIHelp.FuBenCameraPosition();
                    self.MainCamera.transform.localRotation = Quaternion.Euler(AIHelp.FuBenCameraRotation());
                    break;
                case SceneTypeEnum.PetMing:
                    self.CameraMoveType = CameraMoveType.PetFuben;
                    self.MainCamera.transform.position = AIHelp.FuBenCameraPosition();
                    self.MainCamera.transform.localRotation = Quaternion.Euler(AIHelp.FuBenCameraRotation());
                    break;
                default:
                    self.CameraMoveType = CameraMoveType.Normal;
                    break;
            }
        }

    }
}
