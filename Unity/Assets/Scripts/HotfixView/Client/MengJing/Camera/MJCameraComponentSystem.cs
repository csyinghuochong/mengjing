using Unity.Mathematics;
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
            self.MainCamera = Camera.main;
            //GameObject.Find("Global/MainCamera").GetComponent<Camera>();
            self.OffsetPostion = new float3(0, 10f, -6f);
            self.PullRate = 1f;
            self.CameraMoveType = CameraMoveType.Normal;
            self.MainUnit = UnitHelper.GetMyUnitFromClientScene(self.Root());

            self.OnEnterScene(SceneTypeEnum.MainCityScene);
        }
        
        [EntitySystem]
        private static void LateUpdate(this ET.Client.MJCameraComponent self)
        {
            if (self.CameraMoveType == CameraMoveType.PetFuben)
            {
                return;
            }
            if (self.CameraMoveType == CameraMoveType.NpcEnter)
            {
                self.CameraMoveTime += Time.deltaTime * 2f;
                self.BuildEnterMove();
                return;
            }
            if (self.CameraMoveType == CameraMoveType.NpcExit)
            {
                self.CameraMoveTime += Time.deltaTime * 2f;
                self.BuildExitMove();
                return;
            }
            if(self.CameraMoveType == CameraMoveType.Pull)
            {
                self.PullCameraMove();
                return;
            }

            if (self.CameraMoveType == CameraMoveType.Rollback)
            {
                self.RollbackCamera();
                return;
            }
            //if (self.MainCamera.GetComponent<CameraFollow>() != null)
            //{
            //	self.OffsetPostion = self.MainCamera.GetComponent<CameraFollow>().OffsetPostion;
            //}
            if (self.IsRotateing)
            {
                self.CalculateOffset();
            }

            self.MainCamera.transform.position = self.MainUnit.Position + self.OffsetPostion * self.LenDepth;
            self.MainCamera.transform.LookAt(self.MainUnit.Position); 
        }
        
        public static void CalculateOffset(this MJCameraComponent self)
        {
            self.OffsetPostion.y = self.Distance * Mathf.Sin(self.OffsetAngleY * self.ANGLE_CONVERTER);
            float newRadius = self.Distance * Mathf.Cos(self.OffsetAngleY * self.ANGLE_CONVERTER);
            self.OffsetPostion.x = newRadius * Mathf.Sin(self.OffsetAngleX * self.ANGLE_CONVERTER);
            self.OffsetPostion.z = -newRadius * Mathf.Cos(self.OffsetAngleX * self.ANGLE_CONVERTER);
        }
        public static void BuildEnterMove(this MJCameraComponent self)
        {
            if (self.CameraMoveTime > 0.8f && self.OnBuildEnter)
            {
                self.OnBuildEnter = false;
                //抛出实践
            }
            if (self.CameraMoveTime > 1f)
            {
                return;
            }

            Vector3 chaV3 = self.OldCameraPostion + (self.TargetPosition - self.OldCameraPostion) * self.CameraMoveTime;
            self.MainCamera.transform.localPosition = chaV3;

            if (self.NpcUnit.Type == UnitType.Monster)
            {
                self.MainCamera.transform.LookAt(self.NpcUnit.Position + new float3(0,0.5f,0));
            }
            else
            {
                self.MainCamera.transform.LookAt(self.NpcUnit.Position + new float3(0,1f,0));
            }
        }
        
        public static void BuildExitMove(this MJCameraComponent self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (unit == null)
            {
                return;
            }
            if (self.CameraMoveTime > 1f)
            {
                self.CameraMoveType = CameraMoveType.Normal;
                //unit.GetComponent<UIUnitHpComponent>()?.ShowHearBar(true);
                return;
            }
            Vector3 chaV3 = self.OldCameraPostion + (self.TargetPosition - self.OldCameraPostion) * self.CameraMoveTime;
            self.MainCamera.transform.position = chaV3;
            Vector3 lookPosition = self.NpcUnit.Position + (unit.Position - self.NpcUnit.Position) * self.CameraMoveTime;
            self.MainCamera.transform.LookAt(lookPosition);
        }
        
        public static void PullCameraMove(this MJCameraComponent self)
        {
            if (self.PullRate >= 1.5f) // 最大距离
            {
                return;
            }

            self.PullRate += Time.deltaTime * 0.08f; // 速度
            self.MainCamera.transform.position = self.MainUnit.Position + self.OffsetPostion * self.PullRate;
            self.MainCamera.transform.LookAt(self.MainUnit.Position); 
        }

        /// <summary>
        /// 回位摄像机
        /// </summary>
        /// <param name="self"></param>
        public static void SetRollbackCamera(this MJCameraComponent self)
        {
            self.CameraMoveType = CameraMoveType.Rollback;
        }

        public static void RollbackCamera(this MJCameraComponent self)
        {
            if (self.PullRate <= 1f)
            {
                self.CameraMoveType = CameraMoveType.Normal;
                return;
            }
            self.PullRate -= Time.deltaTime * 0.3f;
            self.MainCamera.transform.position = self.MainUnit.Position + self.OffsetPostion * self.PullRate;
            self.MainCamera.transform.LookAt(self.MainUnit.Position); 
        }
        
        //== SceneTypeEnum.MainCityScene
        public static  void OnEnterScene(this MJCameraComponent self, int sceneTypeEnum)
        {
            switch (sceneTypeEnum)
            {
                case SceneTypeEnum.PetTianTi:
                    self.CameraMoveType = CameraMoveType.PetFuben;
                    self.MainCamera.transform.position = ConfigData.FuBenCameraPosition;
                    self.MainCamera.transform.localRotation = Quaternion.Euler(ConfigData.FuBenCameraRotation);
                    break;
                case SceneTypeEnum.PetDungeon:
                    self.CameraMoveType = CameraMoveType.PetFuben;
                    self.MainCamera.transform.position = ConfigData.FuBenCameraPosition;
                    self.MainCamera.transform.localRotation = Quaternion.Euler(ConfigData.FuBenCameraRotation);
                    break;
                case SceneTypeEnum.PetMing:
                    self.CameraMoveType = CameraMoveType.PetFuben;
                    self.MainCamera.transform.position = ConfigData.FuBenCameraPosition;
                    self.MainCamera.transform.localRotation = Quaternion.Euler(ConfigData.FuBenCameraRotation);
                    break;
                default:
                    self.CameraMoveType = CameraMoveType.Normal;
                    break;
            }
        }

    }
}
