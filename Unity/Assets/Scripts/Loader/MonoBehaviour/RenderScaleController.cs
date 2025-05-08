using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
// 通过代码动态修改（示例）

public class RenderScaleController : MonoBehaviour
{
    public UniversalRenderPipelineAsset urpAsset;
    
    void Start()
    {
        urpAsset = GraphicsSettings.renderPipelineAsset as UniversalRenderPipelineAsset;

        if (urpAsset != null)
        {
            Debug.Log("成功获取 URP Asset: " + urpAsset.name);
            // 在此处使用 urpAsset 进行配置
        }
        else
        {
            Debug.LogError("当前未使用 URP 或未分配 URP Asset！");
            
            urpAsset = QualitySettings.renderPipeline as UniversalRenderPipelineAsset;

            if (urpAsset != null)
            {
                Debug.Log("当前质量级别的 URP Asset: " + urpAsset.name);
            }
            else
            {
                Debug.LogError("当前质量级别未分配 URP Asset！");
            }
        }
        
        
        // 设置渲染分辨率为原始分辨率的 50%
        urpAsset.renderScale = 0.5f; 
        
        // 强制更新
        QualitySettings.renderPipeline = urpAsset;
    }
}