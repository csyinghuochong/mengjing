using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace UniFramework.Event
{
	internal static class UniLogger
	{
		[Conditional("DEBUG")]
		public static void Log(string info)
		{
			Debug.Log(info);
		}
		public static void Warning(string info)
		{
			Debug.LogWarning(info);
		}
		public static void Error(string info)
		{
			Debug.LogError(info);
		}
	}
}