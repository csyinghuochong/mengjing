using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    public static partial class GlobalData
    {
        [StaticField]
        public static Dictionary<string, Shader> ShaderList = new();
                
        [StaticField]
        public static List<string> ES_MapMiniType = new()
        {
            "1",  "2",  "3",  "4",  "5",  "6"
        };
		
        [StaticField]
        public static Vector3  ES_MapMiniNoVisie = new Vector3(-2000, 0, -2000);

    }
}