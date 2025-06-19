using System;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class ShakeCameraEvent : AEvent<Scene, ShakeCamera>
    {
        protected override async ETTask Run(Scene root, ShakeCamera args)
        {
            root.CurrentScene()?.GetComponent<MJCameraComponent>()?.SetShakeCamera((ShakeCameraType)args.ShakeCameraType, args.ShakeDuration);

            await ETTask.CompletedTask;
        }
    }

    [EntitySystemOf(typeof(MJCameraComponent))]
    [FriendOf(typeof(MJCameraComponent))]
    public static partial class MJCameraComponentSystem
    {
        [EntitySystem]
        private static void Awake(this MJCameraComponent self)
        {
            self.SetView();
            self.MainCamera = Camera.main;
            //GameObject.Find("Global/MainCamera").GetComponent<Camera>();
            self.PullRate = 1f;
            self.CameraMoveType = CameraMoveType.Normal;
            self.LookAtUnit = UnitHelper.GetMyUnitFromClientScene(self.Root());

            self.OnEnterScene(self.Root().GetComponent<MapComponent>().MapType);
        }

        [EntitySystem]
        private static void LateUpdate(this MJCameraComponent self)
        {
            if (self.CameraMoveType == CameraMoveType.PetFuben)
            {
                return;
            }

            if (self.CameraMoveType == CameraMoveType.BuildEnter)
            {
                self.CameraMoveTime += Time.deltaTime * 2f;
                self.BuildEnterMove();
                return;
            }

            if (self.CameraMoveType == CameraMoveType.BuildExit)
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

            if (self.CameraMoveType == CameraMoveType.Shake)
            {
                self.ShakeCamera();
                return;
            }

            //if (self.MainCamera.GetComponent<CameraFollow>() != null)
            //{
            //	self.OffsetPostion = self.MainCamera.GetComponent<CameraFollow>().OffsetPostion;
            //}
            if (self.IsRotateing)
            {
                self.CalculateOffset();
                PlayerPrefsHelp.SetFloat(PlayerPrefsHelp.OffsetPostion_X, self.OffsetPosition.x);
                PlayerPrefsHelp.SetFloat(PlayerPrefsHelp.OffsetPostion_Y, self.OffsetPosition.y);
                PlayerPrefsHelp.SetFloat(PlayerPrefsHelp.OffsetPostion_Z, self.OffsetPosition.z);
            }

            self.MainCamera.transform.position = self.LookAtUnit.Position + self.OffsetPosition * self.LenDepth;
            self.LookAt();
        }

        public static void SetView(this MJCameraComponent self)
        {
            self.LenDepth = PlayerPrefsHelp.GetFloat(PlayerPrefsHelp.LenDepth, PlayerPrefsHelp.LenDepth_Default);
            self.OffsetPosition =
                    new(PlayerPrefsHelp.GetFloat(PlayerPrefsHelp.OffsetPostion_X, PlayerPrefsHelp.OffsetPostion_X_Default),
                        PlayerPrefsHelp.GetFloat(PlayerPrefsHelp.OffsetPostion_Y, PlayerPrefsHelp.OffsetPostion_Y_Default),
                        PlayerPrefsHelp.GetFloat(PlayerPrefsHelp.OffsetPostion_Z, PlayerPrefsHelp.OffsetPostion_Z_Default));
            self.HorizontalOffset =
                    PlayerPrefsHelp.GetFloat(PlayerPrefsHelp.CameraHorizontalOffset, PlayerPrefsHelp.CameraHorizontalOffset_Default);
            self.VerticalOffset =
                    PlayerPrefsHelp.GetFloat(PlayerPrefsHelp.CameraVerticalOffset, PlayerPrefsHelp.CameraVerticalOffset_Default);
        }

        private static void LookAt(this MJCameraComponent self)
        {
            Vector3 unitPos = self.LookAtUnit.Position;
            Vector3 dre = unitPos - self.MainCamera.transform.position;
            self.MainCamera.transform.rotation = Quaternion.LookRotation(dre);
            Vector3 camPos = self.MainCamera.transform.position;
            camPos += self.MainCamera.transform.up * self.VerticalOffset;
            camPos += self.MainCamera.transform.right * self.HorizontalOffset;
            self.MainCamera.transform.position = camPos;
        }

        public static void BuildEnterMove(this MJCameraComponent self)
        {
            if (self.CameraMoveTime > 0.8f && self.OnBuildEnter != null)
            {
                self.OnBuildEnter();
                self.OnBuildEnter = null;
                MapViewHelper.ShowOtherUnit(self.Root(), false, self.NoHideIds);
                GlobalComponent globalComponent = self.Root().GetComponent<GlobalComponent>();
                globalComponent.BloodRoot.gameObject.SetActive(false);
                self.NoHideIds.Clear();
            }

            if (self.BuildUnit == null)
            {
                return;
            }

            switch (self.CameraBuildType)
            {
                case CameraBuildType.Type_0:
                case CameraBuildType.Type_1:
                {
                    self.TargetPosition = self.BuildUnit.Position + self.BuildUnit.Forward * 4f;
                    self.TargetPosition.y += 2f;
                    break;
                }
                case CameraBuildType.Type_2:
                case CameraBuildType.Type_3:
                case CameraBuildType.Type_4:
                {
                    self.TargetPosition = self.BuildUnit.Position + self.BuildUnit.Forward * 4f;
                    self.TargetPosition.y += 1f;
                    break;
                }
            }

            Vector3 unitPos = self.BuildUnit.Position;
            self.MainCamera.transform.position = Vector3.Lerp(unitPos + self.OldCameraDirection, self.TargetPosition, self.CameraMoveTime);

            switch (self.CameraBuildType)
            {
                case CameraBuildType.Type_0:
                {
                    self.MainCamera.transform.LookAt(self.BuildUnit.Position + new float3(0, 1f, 0));
                    break;
                }
                case CameraBuildType.Type_1:
                {
                    self.MainCamera.transform.LookAt(self.BuildUnit.Position + new float3(0, 0.5f, 0));
                    break;
                }
                case CameraBuildType.Type_2:
                {
                    self.MainCamera.transform.LookAt(self.BuildUnit.Position + math.mul(self.BuildUnit.Rotation, math.left()) * 1f +
                        new float3(0, 1f, 0));
                    break;
                }
                case CameraBuildType.Type_3:
                {
                    self.MainCamera.transform.LookAt(self.BuildUnit.Position + new float3(0, 1f, 0));
                    break;
                }
                case CameraBuildType.Type_4:
                {
                    Vector3 targetPos = self.BuildUnit.Position + math.mul(self.BuildUnit.Rotation, math.left()) * 1f + new float3(0, 1f, 0);
                    Quaternion targetRotation = Quaternion.LookRotation(targetPos - self.MainCamera.transform.position);
                    self.MainCamera.transform.rotation = Quaternion.Slerp(self.MainCamera.transform.rotation, targetRotation, self.CameraMoveTime);
                    break;
                }
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
                return;
            }

            if (self.BuildUnit == null || self.BuildUnit.IsDisposed)
            {
                self.CameraMoveType = CameraMoveType.Normal;
                return;
            }

            Vector3 chaV3 = self.OldCameraPostion + (self.TargetPosition - self.OldCameraPostion) * self.CameraMoveTime;
            self.MainCamera.transform.position = chaV3;
            Vector3 lookPosition = self.BuildUnit.Position + (unit.Position - self.BuildUnit.Position) * self.CameraMoveTime;
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
            self.MainCamera.transform.position = self.LookAtUnit.Position + self.OffsetPosition * self.PullRate;
            self.LookAt();
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
            self.MainCamera.transform.position = self.LookAtUnit.Position + self.OffsetPosition * self.PullRate;
            self.LookAt();
        }

        public static void SetShakeCamera(this MJCameraComponent self, ShakeCameraType shakeCameraType, float shakeDuration)
        {
            self.CameraMoveType = CameraMoveType.Shake;
            self.ShakeCameraType = shakeCameraType;
            self.ShakeDurationTime = shakeDuration;
            self.ShakeCount = 0;
        }

        public static void ShakeCamera(this MJCameraComponent self)
        {
            if (self.ShakeDurationTime <= 0)
            {
                self.CameraMoveType = CameraMoveType.Normal;
                return;
            }

            Vector3 start = self.LookAtUnit.Position + self.OffsetPosition * self.LenDepth;
            Vector3 shakeOffset = Vector3.zero;
            if (Time.time >= self.NextShakeTime)
            {
                float shakeStrength = 1; // 震动强度
                float shakeFrequency = 30; // 震动频率，控制每秒的震动更新次数
                switch (self.ShakeCameraType)
                {
                    case ShakeCameraType.Type_1:
                    {
                        shakeStrength = 0.5f;
                        shakeFrequency = 20f;

                        // 向任意方向震动一下
                        shakeOffset = Random.insideUnitSphere * shakeStrength;
                        break;
                    }
                    case ShakeCameraType.Type_2:
                    {
                        shakeStrength = 0.8f;
                        shakeFrequency = 20f;

                        // 例如 可以自定义 前10下震动Y轴，之后震动X轴 等等
                        if (self.ShakeCount < 10)
                        {
                            shakeOffset.y = Random.Range(-1, 1) * shakeStrength;
                        }
                        else
                        {
                            shakeOffset.x = Random.Range(-1, 1) * shakeStrength;
                        }

                        break;
                    }
                }

                self.NextShakeTime = Time.time + (1f / shakeFrequency);
                self.ShakeCount++;
            }

            self.MainCamera.transform.localPosition = start + shakeOffset;

            self.ShakeDurationTime -= Time.deltaTime;
        }

        public static void SetBuildEnter(this MJCameraComponent self, Unit unit, CameraBuildType cameraBuildType, Action action)
        {
            if (unit == null || unit.IsDisposed)
            {
                return;
            }

            self.BuildUnit = unit;
            self.CameraBuildType = cameraBuildType;
            self.CameraMoveTime = 0f;
            self.CameraMoveType = CameraMoveType.BuildEnter;

            self.OldCameraPostion = self.MainCamera.transform.position;
            Vector3 unitPos = unit.Position;
            self.OldCameraDirection = self.MainCamera.transform.position - unitPos;
            self.OnBuildEnter = action;
            self.NoHideIds.Clear();
        }

        public static void SetBuildExit(this MJCameraComponent self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            self.CameraMoveTime = 0f;
            self.CameraMoveType = CameraMoveType.BuildExit;
            self.OldCameraPostion = self.MainCamera.transform.localPosition;
            self.TargetPosition = unit.Position + self.OffsetPosition;
            MapViewHelper.ShowOtherUnit(self.Root(), true, null);
            GlobalComponent globalComponent = self.Root().GetComponent<GlobalComponent>();
            globalComponent.BloodRoot.gameObject.SetActive(true);
        }

        public static void OnEnterScene(this MJCameraComponent self, int sceneTypeEnum)
        {
            switch (sceneTypeEnum)
            {
                case MapTypeEnum.PetTianTi:
                    self.CameraMoveType = CameraMoveType.PetFuben;
                    self.MainCamera.transform.position = ConfigData.FuBenCameraPosition;
                    self.MainCamera.transform.localRotation = Quaternion.Euler(ConfigData.FuBenCameraRotation);
                    break;
                case MapTypeEnum.PetDungeon:
                    self.CameraMoveType = CameraMoveType.PetFuben;
                    self.MainCamera.transform.position = ConfigData.FuBenCameraPosition;
                    self.MainCamera.transform.localRotation = Quaternion.Euler(ConfigData.FuBenCameraRotation);
                    break;
                case MapTypeEnum.PetMing:
                    self.CameraMoveType = CameraMoveType.PetFuben;
                    self.MainCamera.transform.position = ConfigData.FuBenCameraPosition;
                    self.MainCamera.transform.localRotation = Quaternion.Euler(ConfigData.FuBenCameraRotation);
                    break;
                case MapTypeEnum.PetMelee:
                case MapTypeEnum.PetMatch:
                    self.CameraMoveType = CameraMoveType.PetFuben;
                    self.MainCamera.transform.position = ConfigData.PetMeleeFuBenCameraPosition;
                    self.MainCamera.transform.localRotation = Quaternion.Euler(ConfigData.PetMeleeFuBenCameraRotation);
                    break;
                default:
                    self.CameraMoveType = CameraMoveType.Normal;
                    break;
            }
        }

        public static void ApplyCameraPos_X(this MJCameraComponent self, float x, float min, float max)
        {
            Vector3 pos = self.MainCamera.transform.position;
            pos.x = Mathf.Clamp(pos.x + x, min, max);
            self.MainCamera.transform.position = pos;
        }

        public static void CalculateOffset(this MJCameraComponent self)
        {
            Vector3 pos = new Vector3(0, 0, 0);
            pos.y = self.Distance * Mathf.Sin(self.OffsetAngleY * self.ANGLE_CONVERTER);
            float newRadius = self.Distance * Mathf.Cos(self.OffsetAngleY * self.ANGLE_CONVERTER);
            pos.x = newRadius * Mathf.Sin(self.OffsetAngleX * self.ANGLE_CONVERTER);
            pos.z = -newRadius * Mathf.Cos(self.OffsetAngleX * self.ANGLE_CONVERTER);
            self.OffsetPosition = pos;
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

        public static void StartLookAtPet(this MJCameraComponent self, Unit pet)
        {
            self.LookAtUnit = pet;
        }

        public static void EndLookAtPet(this MJCameraComponent self)
        {
            self.LookAtUnit = UnitHelper.GetMyUnitFromClientScene(self.Root());
        }
    }
}