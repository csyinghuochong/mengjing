using UnityEngine;
using I2.Loc;

namespace ET.Client
{
	public static class ScriptLocalization
	{

        [StaticField]
		public static string Test 		{ get{ return LocalizationManager.GetTranslation ("Test"); } }
        [StaticField]
		public static string UnityWhite 		{ get{ return LocalizationManager.GetTranslation ("UnityWhite"); } }
        [StaticField]
		public static string 加油 		{ get{ return LocalizationManager.GetTranslation ("加油"); } }
        [StaticField]
		public static string 成功 		{ get{ return LocalizationManager.GetTranslation ("成功"); } }
        [StaticField]
		public static string 测试 		{ get{ return LocalizationManager.GetTranslation ("测试"); } }
	}

    public static class ScriptTerms
	{

		public const string Test = "Test";
		public const string UnityWhite = "UnityWhite";
		public const string 加油 = "加油";
		public const string 成功 = "成功";
		public const string 测试 = "测试";
	}
}