using System;
using Unity.Mathematics;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(MJCameraComponent))]
    [FriendOf(typeof(MJCameraComponent))]
    public static partial class MJCameraComponentSystem
    {
        [EntitySystem]
        private static void Awake(this MJCameraComponent self)
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
        private static void LateUpdate(this MJCameraComponent self)
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

            if (self.CameraMoveType == CameraMoveType.Pull)
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

        public static void BuildEnterMove(this MJCameraComponent self)
        {
            if (self.CameraMoveTime > 0.8f && self.OnBuildEnter != null)
            {
                self.OnBuildEnter();
                self.OnBuildEnter = null;
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
                self.MainCamera.transform.LookAt(self.NpcUnit.Position + new float3(0, 0.5f, 0));
            }
            else
            {
                self.MainCamera.transform.LookAt(self.NpcUnit.Position + new float3(0, 1f, 0));
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

        public static void SetPullCamera(this MJCameraComponent self)
        {
            self.PullRate = 1f;
            self.CameraMoveType = CameraMoveType.Pull;
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

        public static void SetBuildEnter(this MJCameraComponent self, Unit npc, Action action)
        {
            self.NpcUnit = npc;
            self.CameraMoveTime = 0f;
            self.CameraMoveType = (npc != null) ? CameraMoveType.NpcEnter : CameraMoveType.Normal;

            self.TargetPosition = npc.Position + npc.Forward * 4f;
            self.TargetPosition.y += 2f;

            self.OldCameraPostion = self.MainCamera.transform.position;
            self.OnBuildEnter = action;

            UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<UIPlayerHpComponent>()?.ShowHearBar(false);
        }

        public static void SetBuildExit(this MJCameraComponent self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            self.CameraMoveTime = 0f;
            self.CameraMoveType = CameraMoveType.NpcExit;
            self.OldCameraPostion = self.MainCamera.transform.localPosition;
            self.TargetPosition = unit.Position + self.OffsetPostion;
        }
        
        public static void OnEnterScene(this MJCameraComponent self, int sceneTypeEnum)
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

        public static void CalculateOffset(this MJCameraComponent self)
        {
            self.OffsetPostion.y = self.Distance * Mathf.Sin(self.OffsetAngleY * self.ANGLE_CONVERTER);
            float newRadius = self.Distance * Mathf.Cos(self.OffsetAngleY * self.ANGLE_CONVERTER);
            self.OffsetPostion.x = newRadius * Mathf.Sin(self.OffsetAngleX * self.ANGLE_CONVERTER);
            self.OffsetPostion.z = -newRadius * Mathf.Cos(self.OffsetAngleX * self.ANGLE_CONVERTER);
        }

        //开始旋转，纪录当前偏移角度，用于复原
        public static void StartRotate(this MJCameraComponent self)
        {
            self.IsRotateing = true;

            self.RecordAngleX = self.OffsetAngleX;
            self.RecordAngleY = self.OffsetAngleY;
        }

        //旋转，修改偏移角度的值，屏幕左右滑动即修改m_offsetAngleX，上下滑动修改m_offsetAngleY
        public static void Rotate(this MJCameraComponent self, float x, float y)
        {
            if (x != 0)
            {
                self.OffsetAngleX += x;
            }

            if (y != 0)
            {
                self.OffsetAngleY += y;
                self.OffsetAngleY = self.OffsetAngleY > self.MAX_ANGLE_Y ? self.MAX_ANGLE_Y : self.OffsetAngleY;
                self.OffsetAngleY = self.OffsetAngleY < self.MIN_ANGLE_Y ? self.MIN_ANGLE_Y : self.OffsetAngleY;
            }
        }

        //旋转结束，如需要复原镜头则，偏移角度还原并计算偏移坐标
        public static void EndRotate(this MJCameraComponent self, bool isNeedReset = false)
        {
            self.IsRotateing = false;

            if (isNeedReset)
            {
                self.OffsetAngleY = self.RecordAngleY;
                self.OffsetAngleX = self.RecordAngleX;
                self.CalculateOffset();
            }
        }
    }
}