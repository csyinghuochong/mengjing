using UnityEngine;

namespace ET.Client
{
    public static class HoreseHelper
    {
        public static float GetRoleScale(GameObject horse, int horseId)
        {
            Transform Model = horse.transform.Find("Model");
            if (Model != null)
            {
                return 1f / Model.transform.localScale.x;
            }

            switch (horseId)
            {
                case 10001:
                    return 1f / 6;
                default:
                    return 1f / 6;
            }
        }

        public static GameObject GetHorseNode(GameObject ObjectHorse)
        {
            return ObjectHorse.Get<GameObject>("Head");
        }
    }
}