using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    public static class JiaYuanData
    {
        [StaticField]
        public static long JiaYuanPurchaseRefresh = 15000;
        
        [StaticField]
        public static List<Vector3> PlanPositionList = new()
        {
            new Vector3(22.73f, 0.16f, -4.37f),
            new Vector3(22.73f, 0.16f, -4.37f - 3f),
            new Vector3(22.73f, 0.16f, -4.37f - 6f),
            new Vector3(22.73f, 0.16f, -4.37f - 9f),

            new Vector3(19.78f, 0.16f, -4.37f),
            new Vector3(19.78f, 0.16f, -4.37f - 3f),
            new Vector3(19.78f, 0.16f, -4.37f - 6f),
            new Vector3(19.78f, 0.16f, -4.37f - 9f),

            new Vector3(-2f, 0f, -31.24f - 0.5f),
            new Vector3(-2f, 0f, -33.32f - 0.5f),
            new Vector3(-2f, 0f, -35.39f - 0.5f),
            new Vector3(-2f, 0f, -37.58f - 0.5f),

            new Vector3(-4.75f, 0f, -31.24f - 0.5f),
            new Vector3(-4.75f, 0f, -33.32f - 0.5f),
            new Vector3(-4.75f, 0f, -35.39f - 0.5f),
            new Vector3(-4.75f, 0f, -37.58f - 0.5f),

            new Vector3(-7.5f, 0f, -31.24f - 0.5f),
            new Vector3(-7.5f, 0f, -33.32f - 0.5f),
            new Vector3(-7.5f, 0f, -35.39f - 0.5f),
            new Vector3(-7.5f, 0f, -37.58f - 0.5f),
        };
    }
}