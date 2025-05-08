using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using HighlightPlus;
// 通过代码动态修改（示例）

public class RenderScaleController : MonoBehaviour
{
    private UniversalRenderPipelineAsset urpAsset;

    private HighlightPlusRenderPassFeature highlightPlusRenderPassFeature;

    public HighlightPlusRenderPassFeature HighlightPlusRenderPassFeature
    {
        get { return this.highlightPlusRenderPassFeature; }
        set { this.highlightPlusRenderPassFeature = value; }
    }

    public void ChangeRenderPassEvent(bool value)
    {
        highlightPlusRenderPassFeature.renderPassEvent = value ? RenderPassEvent.BeforeRenderingShadows : RenderPassEvent.AfterRenderingTransparents;
    }

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
       urpAsset.renderScale = 1f;
       // this.urpAsset.scriptableRendererData;

       // 通过反射获取 m_RendererDataList 字段（存储 renderer 相关数据）
       FieldInfo fieldInfo = urpAsset.GetType().GetField("m_RendererDataList", BindingFlags.Instance | BindingFlags.NonPublic);
       if (fieldInfo != null)
       {
           ScriptableRendererData[] rendererDataList = (ScriptableRendererData[])fieldInfo.GetValue(urpAsset);
           if (rendererDataList != null && rendererDataList.Length > 0)
           {
               foreach (var rendererData in rendererDataList)
               {
                   // 处理每个 rendererData（如 UniversalRendererData 等）
                   if (rendererData is UniversalRendererData universalData)
                   {
                       List<ScriptableRendererFeature> rendererFeatures = rendererData.rendererFeatures;
                       highlightPlusRenderPassFeature = (HighlightPlusRenderPassFeature) rendererFeatures[0];
                       Debug.Log($"Renderer 名称: {universalData.name}");
                       break;
                   }
               }
           }
       }
       else
       {
           Debug.LogError("反射获取 m_RendererDataList 失败");
       }
       
        // 强制更新
        QualitySettings.renderPipeline = urpAsset;
    }
}