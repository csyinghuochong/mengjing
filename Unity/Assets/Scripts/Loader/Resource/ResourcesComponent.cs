﻿using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using YooAsset;

namespace ET
{
    
    // 用于字符串转换，减少GC
    [FriendOf(typeof(ResourcesComponent))]
    public static class AssetBundleHelper
    {
        public static string StringToAB(this string value)
        {
            string result =  $"Assets/Bundles/UI/Dlg/{value}.prefab";
            return result;
        }

    }
    
    
    /// <summary>
    /// 资源文件查询服务类
    /// </summary>
    public class GameQueryServices : IQueryServices
    {
        public bool QueryStreamingAssets(string packageName, string fileName)
        {
            // 注意：fileName包含文件格式
            string filePath = Path.Combine(YooAssetSettings.DefaultYooFolderName, packageName, fileName);
            return BetterStreamingAssets.FileExists(filePath);
        }
    }
    
    /// <summary>
    /// 远端资源地址查询服务类
    /// </summary>
    public class RemoteServices : IRemoteServices
    {
        private readonly string _defaultHostServer;
        private readonly string _fallbackHostServer;

        public RemoteServices(string defaultHostServer, string fallbackHostServer)
        {
            _defaultHostServer = defaultHostServer;
            _fallbackHostServer = fallbackHostServer;
        }
        string IRemoteServices.GetRemoteMainURL(string fileName)
        {
            return $"{_defaultHostServer}/{fileName}";
        }
        string IRemoteServices.GetRemoteFallbackURL(string fileName)
        {
            return $"{_fallbackHostServer}/{fileName}";
        }
    }
    
    public class ResourcesComponent: Singleton<ResourcesComponent>, ISingletonAwake
    {
        public void Awake()
        {
            YooAssets.Initialize();
            //YooAssets.SetOperationSystemMaxTimeSlice(30);
            BetterStreamingAssets.Initialize();
        }

        protected override void Destroy()
        {
            YooAssets.Destroy();
        }

        public async ETTask CreatePackageAsync(string packageName, EPlayMode ePlayMode, bool isDefault = false)
        {
            ResourcePackage package = YooAssets.CreatePackage(packageName);
            if (isDefault)
            {
                YooAssets.SetDefaultPackage(package);
            }

            // 编辑器下的模拟模式
            switch (ePlayMode)
            {
                case EPlayMode.EditorSimulateMode:
                {
                    EditorSimulateModeParameters createParameters = new();
                    createParameters.SimulateManifestFilePath = EditorSimulateModeHelper.SimulateBuild(packageName);
                    await package.InitializeAsync(createParameters).Task;
                    break;
                }
                case EPlayMode.OfflinePlayMode:
                {
                    OfflinePlayModeParameters createParameters = new();
                    await package.InitializeAsync(createParameters).Task;
                    break;
                }
                case EPlayMode.HostPlayMode:
                {
                    string defaultHostServer = GetHostServerURL();
                    string fallbackHostServer = GetHostServerURL();
                    HostPlayModeParameters createParameters = new();
                    createParameters.QueryServices = new GameQueryServices();
                    createParameters.RemoteServices = new RemoteServices(defaultHostServer, fallbackHostServer);
                    await package.InitializeAsync(createParameters).Task;
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return;

            string GetHostServerURL()
            {
                //string hostServerIP = "http://10.0.2.2"; //安卓模拟器地址
                //string hostServerIP = "http://47.94.107.92";
                string hostServerIP = "http://weijinghot.weijinggame.com";
                string appVersion = "v1.0";
                
#if UNITY_EDITOR
                if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.Android)
                    return $"{hostServerIP}/weijing1/DLCBeta/MJ/Android";
                else if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.iOS)
                    return $"{hostServerIP}/weijing1/DLCBeta/MJ/iOS";
                else if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.WebGL)
                    return $"{hostServerIP}/weijing1/DLCBeta/MJ/WebGL";
                else
                    return $"{hostServerIP}/weijing1/DLCBeta/MJ/PC";
#else
		        if (Application.platform == RuntimePlatform.Android)
		        	return $"{hostServerIP}/weijing1/DLCBeta/MJ/Android";
		        else if (Application.platform == RuntimePlatform.IPhonePlayer)
		        	return $"{hostServerIP}/weijing1/DLCBeta/MJ/iOS";
		        else if (Application.platform == RuntimePlatform.WebGLPlayer)
		        	return $"{hostServerIP}/weijing1/DLCBeta/MJ/WebGL";
		        else
		        	return $"{hostServerIP}/weijing1/DLCBeta/MJ/PC";
#endif
            }
        }
        
        public void DestroyPackage(string packageName)
        {
            ResourcePackage package = YooAssets.GetPackage(packageName);
            package.UnloadUnusedAssets();
        }
        
        /// <summary>
        /// 主要用来加载dll config aotdll，因为这时候纤程还没创建，无法使用ResourcesLoaderComponent。
        /// 游戏中的资源应该使用ResourcesLoaderComponent来加载
        /// </summary>
        public  T LoadAssetSync<T>(string location) where T: UnityEngine.Object
        {
            AssetOperationHandle handle = YooAssets.LoadAssetSync<T>(location);
            T t = (T)handle.AssetObject;
            handle.Release();
            return t;
        }

        /// <summary>
        /// 主要用来加载dll config aotdll，因为这时候纤程还没创建，无法使用ResourcesLoaderComponent。
        /// 游戏中的资源应该使用ResourcesLoaderComponent来加载
        /// </summary>
        public async ETTask<T> LoadAssetAsync<T>(string location) where T: UnityEngine.Object
        {
            AssetOperationHandle handle = YooAssets.LoadAssetAsync<T>(location);
            await handle.Task;
            T t = (T)handle.AssetObject;
            handle.Release();
            return t;
        }
        
        /// <summary>
        /// 主要用来加载dll config aotdll，因为这时候纤程还没创建，无法使用ResourcesLoaderComponent。
        /// 游戏中的资源应该使用ResourcesLoaderComponent来加载
        /// </summary>
        public async ETTask<Dictionary<string, T>> LoadAllAssetsAsync<T>(string location) where T: UnityEngine.Object
        {
            AllAssetsOperationHandle allAssetsOperationHandle = YooAssets.LoadAllAssetsAsync<T>(location);
            await allAssetsOperationHandle.Task;
            Dictionary<string, T> dictionary = new Dictionary<string, T>();
            foreach(UnityEngine.Object assetObj in allAssetsOperationHandle.AllAssetObjects)
            {    
                T t = assetObj as T;
                dictionary.Add(t.name, t);
            }
            allAssetsOperationHandle.Release();
            return dictionary;
        }
    }
}