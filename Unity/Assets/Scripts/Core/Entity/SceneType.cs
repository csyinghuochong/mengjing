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
		Match = 1 << 14,
		Room = 1 << 15,
		LockStepClient = 1 << 16,
		LockStepServer = 1 << 17,
		RoomRoot = 1 << 18,
		Watcher = 1 << 19,
        Account = 1 << 20,
        Activity = 1 << 21,
        Arena = 1 << 22,
        Battle = 1 << 23,
        Chat = 1 << 24,
        DBCache = 1 << 25,
        EMail = 1 << 26,
        Friend = 1 << 27,
        FubenCenter = 1 << 28,
        Happy = 1 << 29,
        JiaYuan = 1 << 30,
        LocalDungeon = 1L << 31,
        PaiMai = 1L << 32,
        Popularize = 1L << 33,
        Queue = 1L << 34,
        Rank = 1L << 35,
        Solo = 1L << 36,
        Team = 1L << 37,
        Union = 1L << 38,
        BigCenter = 1L << 39,
        LoginCenter = 1L << 40,
        AccountCenter = 1L << 41,
        ReCharge = 1L << 42,

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