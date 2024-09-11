﻿using System;
using System.Collections;
using CommandLine;
using UnityEngine;
using YooAsset;

namespace ET
{
	
	[EnableClass]
	public class Init: MonoBehaviour
	{
		public bool EditorMode;
		public int VersionMode = ET.VersionMode.Alpha;
		
		private void Start()
		{
			this.StartAsync().Coroutine();
		}
		
		private async ETTask StartAsync()
		{
			DontDestroyOnLoad(gameObject);
			
			AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
			{
				Log.Error(e.ExceptionObject.ToString());
			};

			// 命令行参数
			string[] args = "".Split(" ");
			Parser.Default.ParseArguments<Options>(args)
				.WithNotParsed(error => throw new Exception($"命令行格式错误! {error}"))
				.WithParsed((o)=>World.Instance.AddSingleton(o));
			Options.Instance.StartConfig = $"StartConfig/Localhost";
            
			Options.Instance.Develop = VersionMode == ET.VersionMode.Beta ?0 : 1;
			Options.Instance.LogLevel = VersionMode == ET.VersionMode.Beta ?6 : 1;
			
			World.Instance.AddSingleton<Logger>().Log = new UnityLogger();
			ETTask.ExceptionHandler += Log.Error;
			
			World.Instance.AddSingleton<TimeInfo>();
			World.Instance.AddSingleton<FiberManager>();
			
			GlobalConfig globalConfig = Resources.Load<GlobalConfig>("GlobalConfig");
			EPlayMode ePlayMode = globalConfig.EPlayMode;
			
#if UNITY_EDITOR
			ePlayMode = globalConfig.EPlayMode;
			//ePlayMode = EPlayMode.EditorSimulateMode;
#else
			ePlayMode = EPlayMode.HostPlayMode;
#endif

			await World.Instance.AddSingleton<ResourcesComponent>().CreatePackageAsync("DefaultPackage",ePlayMode, true);
			
			// 游戏管理器
			GameManager.Instance.Behaviour = this;
			GameObject.Find("Global/UI/PopUpRoot/PatchWindow").gameObject.SetActive(true);
			// 开始补丁更新流程
			StartCoroutine(StartUpdate(ePlayMode));
		}

		IEnumerator StartUpdate(EPlayMode ePlayMode)
		{
			// 开始补丁更新流程
			PatchOperation operation = new PatchOperation("DefaultPackage", EDefaultBuildPipeline.BuiltinBuildPipeline.ToString(), ePlayMode);
			operation.UpdateDownHandler = () => { OnUpdaterDone().Coroutine(); };
			YooAssets.StartOperation(operation);
			yield return operation;
		}

		public void TogglePatchWindow(bool show)
		{
			GameObject.Find("Global/UI/PopUpRoot/PatchWindow").gameObject.SetActive(show);
		}

		public async ETTask OnUpdaterDone()
		{
			CodeLoader codeLoader = World.Instance.AddSingleton<CodeLoader>();
			await codeLoader.DownloadAsync();

			codeLoader.Start();
		}

		private void Update()
		{
			TimeInfo.Instance.Update();
			FiberManager.Instance.Update();
		}

		private void LateUpdate()
		{
			FiberManager.Instance.LateUpdate();
		}

		private void OnApplicationQuit()
		{
			World.Instance.Dispose();
		}
	}
	
	
}