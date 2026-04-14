点击HybridCLR -> Installer，点击安装，等待安装完成

点击Unity菜单 -> ET -> Compile(或按快捷键F6)进行编译

点击HybridCLR -> Generate -> All

点击HybridCLR -> CopyAotDlls，这一步会把需要补充元数据的dll复制到'Assets/Bundles/AotDlls'目录

打开YooAsset -> AssetBundle Builder窗口，按照以下步骤操作:

①BuildPipeline : 'ScriptableBuildPipeline'

②BuildMode : 'IncrementalBuild'

③CopyBuildinFileOption : 'ClearAndCopyAll'

④点击'Click Build'


Assets/Resources/GlobalConfig EPlayMode选择'HostPlayMode', 


打开Unity菜单 -> Custom/Build Android Taptap1


屏蔽热更新代码：
init.cs
public void OnStartGame()
{
	TogglePatchWindow(true);
	// 开始补丁更新流程
	//StartCoroutine(StartUpdate(ePlayMode));
	OnUpdaterDone().Coroutine();
}
