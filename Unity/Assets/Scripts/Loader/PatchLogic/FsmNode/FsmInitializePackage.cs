// using System;
// using System.IO;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UniFramework.Machine;
// using YooAsset;
//
// /// <summary>
// /// 初始化资源包
// /// </summary>
// internal class FsmInitializePackage: IStateNode
// {
//     private StateMachine _machine;
//
//     void IStateNode.OnCreate(StateMachine machine)
//     {
//         _machine = machine;
//     }
//
//     void IStateNode.OnEnter()
//     {
//         PatchEventDefine.PatchStatesChange.SendEventMessage("初始化资源包！");
//         GameManager.Instance.StartCoroutine(InitPackage());
//     }
//
//     void IStateNode.OnUpdate()
//     {
//     }
//
//     void IStateNode.OnExit()
//     {
//     }
//
//     private IEnumerator InitPackage()
//     {
//         var playMode = (EPlayMode)_machine.GetBlackboardValue("PlayMode");
//         var packageName = (string)_machine.GetBlackboardValue("PackageName");
//         var buildPipeline = (string)_machine.GetBlackboardValue("BuildPipeline");
//
//         // 创建资源包裹类
//         var package = YooAssets.TryGetPackage(packageName);
//         if (package == null)
//             package = YooAssets.CreatePackage(packageName);
//
//         // 编辑器下的模拟模式
//         InitializationOperation initializationOperation = null;
//         if (playMode == EPlayMode.EditorSimulateMode)
//         {
//             var createParameters = new EditorSimulateModeParameters();
//             createParameters.SimulateManifestFilePath = EditorSimulateModeHelper.SimulateBuild(packageName);
//             initializationOperation = package.InitializeAsync(createParameters);
//         }
//
//         // 单机运行模式
//         if (playMode == EPlayMode.OfflinePlayMode)
//         {
//             var createParameters = new OfflinePlayModeParameters();
//             initializationOperation = package.InitializeAsync(createParameters);
//         }
//
//         // 联机运行模式
//         if (playMode == EPlayMode.HostPlayMode)
//         {
//             string defaultHostServer = GetHostServerURL();
//             string fallbackHostServer = GetHostServerURL();
//             var createParameters = new HostPlayModeParameters();
//             createParameters.RemoteServices = new RemoteServices(defaultHostServer, fallbackHostServer);
//             initializationOperation = package.InitializeAsync(createParameters);
//         }
//
//         // WebGL运行模式
//         if (playMode == EPlayMode.WebPlayMode)
//         {
//             string defaultHostServer = GetHostServerURL();
//             string fallbackHostServer = GetHostServerURL();
//             var createParameters = new WebPlayModeParameters();
//             createParameters.RemoteServices = new RemoteServices(defaultHostServer, fallbackHostServer);
//             initializationOperation = package.InitializeAsync(createParameters);
//         }
//
//         yield return initializationOperation;
//
//         // 如果初始化失败弹出提示界面
//         if (initializationOperation.Status != EOperationStatus.Succeed)
//         {
//             Debug.LogWarning($"{initializationOperation.Error}");
//             PatchEventDefine.InitializeFailed.SendEventMessage();
//         }
//         else
//         {
//             var version = initializationOperation.PackageVersion;
//             Debug.Log($"Init resource package version : {version}");
//             _machine.ChangeState<FsmUpdatePackageVersion>();
//         }
//     }
//
//     /// <summary>
//     /// 获取资源服务器地址
//     /// </summary>
//     private string GetHostServerURL()
//     {
//         //string hostServerIP = "http://10.0.2.2"; //安卓模拟器地址
//         string hostServerIP = "http://47.94.107.92";
//         string appVersion = "2024-06-19-1038";
//         ///weijing1/DLCBeta/Test/Android
// #if UNITY_EDITOR
//         if (UnityEditor.EditorUserBuildSettings.activeBuildTarget == UnityEditor.BuildTarget.Android)
//             return $"{hostServerIP}/weijing1/DLCBeta/Test/Android/{appVersion}";
//         else if (UnityEditor.EditorUserBuildSettings.activeBuildTarget == UnityEditor.BuildTarget.iOS)
//             return $"{hostServerIP}/weijing1/DLCBeta/Test/IPhone/{appVersion}";
//         else if (UnityEditor.EditorUserBuildSettings.activeBuildTarget == UnityEditor.BuildTarget.WebGL)
//             return $"{hostServerIP}/weijing1/DLCBeta/Test/WebGL/{appVersion}";
//         else
//             return $"{hostServerIP}/weijing1/DLCBeta/Test/PC/{appVersion}";
// #else
//         if (Application.platform == RuntimePlatform.Android)
//             return $"{hostServerIP}/CDN/Android/{appVersion}";
//         else if (Application.platform == RuntimePlatform.IPhonePlayer)
//             return $"{hostServerIP}/CDN/IPhone/{appVersion}";
//         else if (Application.platform == RuntimePlatform.WebGLPlayer)
//             return $"{hostServerIP}/CDN/WebGL/{appVersion}";
//         else
//             return $"{hostServerIP}/CDN/PC/{appVersion}";
// #endif
//     }
//
//     /// <summary>
//     /// 远端资源地址查询服务类
//     /// </summary>
//     private class RemoteServices: IRemoteServices
//     {
//         private readonly string _defaultHostServer;
//         private readonly string _fallbackHostServer;
//
//         public RemoteServices(string defaultHostServer, string fallbackHostServer)
//         {
//             _defaultHostServer = defaultHostServer;
//             _fallbackHostServer = fallbackHostServer;
//         }
//
//         string IRemoteServices.GetRemoteMainURL(string fileName)
//         {
//             return $"{_defaultHostServer}/{fileName}";
//         }
//
//         string IRemoteServices.GetRemoteFallbackURL(string fileName)
//         {
//             return $"{_fallbackHostServer}/{fileName}";
//         }
//     }
//
// }
//
// public interface IBuildinQueryServices
// {
//     /// <summary>
//     /// 查询是否为应用程序内置的资源文件
//     /// </summary>
//     /// <param name="packageName">包裹名称</param>
//     /// <param name="fileName">文件名称（包含文件的后缀格式）</param>
//     /// <param name="fileCRC">文件哈希值</param>
//     /// <returns>返回查询结果</returns>
//     bool Query(string packageName, string fileName, string fileCRC);
// }
//
// public interface IWechatQueryServices
// {
//     /// <summary>
//     /// 查询是否为微信缓存的资源文件
//     /// </summary>
//     /// <param name="packageName">包裹名称</param>
//     /// <param name="fileName">文件名称（包含文件的后缀格式）</param>
//     /// <param name="fileCRC">文件哈希值</param>
//     /// <returns>返回查询结果</returns>
//     bool Query(string packageName, string fileName, string fileCRC);
// }
//
// /// <summary>
// /// WebGL运行模式的初始化参数
// /// </summary>
// public class WebPlayModeParameters : InitializeParameters
// {
//     /// <summary>
//     /// 远端资源地址查询服务类
//     /// </summary>
//     public IRemoteServices RemoteServices = null;
//
//     /// <summary>
//     /// 内置资源查询服务接口
//     /// </summary>
//     public IBuildinQueryServices BuildinQueryServices = null;
//
//     /// <summary>
//     /// 微信缓存查询服务接口
//     /// </summary>
//     public IWechatQueryServices WechatQueryServices = null;
// }
//
// /// <summary>
// /// 资源文件解密流
// /// </summary>
// public class BundleStream : FileStream
// {
//     public const byte KEY = 64;
//
//     public BundleStream(string path, FileMode mode, FileAccess access, FileShare share) : base(path, mode, access, share)
//     {
//     }
//     public BundleStream(string path, FileMode mode) : base(path, mode)
//     {
//     }
//
//     public override int Read(byte[] array, int offset, int count)
//     {
//         var index = base.Read(array, offset, count);
//         for (int i = 0; i < array.Length; i++)
//         {
//             array[i] ^= KEY;
//         }
//         return index;
//     }
// }