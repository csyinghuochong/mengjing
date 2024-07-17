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
            new Vector3(14.35f, 0f, -5.98f),
            new Vector3(17.27f, 0f, -5.98f),
            new Vector3(20.32f, 0f, -5.98f),
            new Vector3(4f - 0.5f, 0f, -37.58f - 0.5f),

            new Vector3(1.25f - 0.5f, 0f, -31.24f - 0.5f),
            new Vector3(1.25f - 0.5f, 0f, -33.32f - 0.5f),
            new Vector3(1.25f - 0.5f, 0f, -35.39f - 0.5f),
            new Vector3(1.25f - 0.5f, 0f, -37.58f - 0.5f),

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