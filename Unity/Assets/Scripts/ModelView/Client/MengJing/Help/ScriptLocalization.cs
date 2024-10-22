using UnityEngine;
using I2.Loc;

namespace ET.Client
{
   // 该脚本由工具自动生成，请勿修改
	public static class ScriptLocalization
	{

        [StaticField]
		public static string Test 		{ get{ return LocalizationManager.GetTranslation ("Test"); } }
        [StaticField]
		public static string UnityWhite 		{ get{ return LocalizationManager.GetTranslation ("UnityWhite"); } }
        [StaticField]
		public static string 你好_123 		{ get{ return LocalizationManager.GetTranslation ("你好 123"); } }
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
		public const string 你好_123 = "你好 123";
		public const string 加油 = "加油";
		public const string 成功 = "成功";
		public const string 测试 = "测试";
	}
}