using System;

namespace ET
{
	[Flags]
	public enum SceneType: long
	{
		None = 0,
		Main = 1, // 主纤程,一个进程一个, 初始化从这里开始
		NetInner = 1 << 2, // 负责进程间消息通信
		Realm = 1 << 3,
		Gate = 1 << 4,
		Http = 1 << 5,
		Location = 1 << 6,
		Map = 1 << 7,
		Router = 1 << 8,
		RouterManager = 1 << 9,
		Robot = 1 << 10,
		BenchmarkClient = 1 << 11,
		BenchmarkServer = 1 << 12,
		Match = 1 << 13,
		Room = 1 << 14,
		LockStepClient = 1 << 15,
		LockStepServer = 1 << 16,
		RoomRoot = 1 << 17,
		Watcher = 1 << 18,
        Account = 1 << 19,
        Activity = 1 << 20,
        Battle = 1 << 21,
        Chat = 1 << 22,
        DBCache = 1 << 23,
        EMail = 1 << 24,
        Friend = 1 << 25,
        FubenCenter = 1 << 26,
        JiaYuan = 1 << 27,
        LocalDungeon = 1L << 28,
        PaiMai = 1L << 29,
        Popularize = 1L << 30,
        Queue = 1L << 31,
        Rank = 1L << 32,
        Team = 1L << 33,
        Union = 1L << 34,
        Solo = 1L << 35,
        BigCenter = 1L << 36,
        LoginCenter = 1L << 37,
        AccountCenter = 1L << 38,
        ReCharge = 1L << 39,

        // 客户端
        Demo = 1L << 50,
		Current = 1L << 51,
		LockStep = 1L << 52,
		LockStepView = 1L << 53,
		DemoView = 1L << 54,
		NetClient = 1L << 55,

        All = long.MaxValue,
	}

	public static class SceneTypeHelper
	{
		public static bool HasSameFlag(this SceneType a, SceneType b)
		{
			if (((ulong) a & (ulong) b) == 0)
			{
				return false;
			}
			return true;
		}
	}
}