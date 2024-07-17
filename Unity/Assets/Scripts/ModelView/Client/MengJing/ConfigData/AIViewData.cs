using UnityEngine;

namespace ET.Client
{
    public static class AIViewData
    {
        
        //摄像机位置
        [StaticField]
        public static readonly Vector3 FuBenCameraPosition = new Vector3(14, 22f, 0f);

        [StaticField]
        public static readonly Quaternion FuBenCameraRotation = Quaternion.Euler(60f, -90f, 0);

        //拖动位置
        [StaticField]
        public static readonly float FuBenCameraPositionMin_X = -50f;
        [StaticField]
        public static readonly float FuBenCameraPositionMax_X = 50f;
        [StaticField]
        public static readonly float FuBenCameraPositionMin_Z = -50f;
        [StaticField]
        public static readonly float FuBenCameraPositionMax_Z = 50f;
    }
}