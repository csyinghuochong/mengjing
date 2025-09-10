using System.Collections.Generic;
using System.Reflection;
using EPOOutline;
using Unified.UniversalBlur.Runtime;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
// 通过代码动态修改（示例）

public class RenderScaleController : MonoBehaviour
{
    private UniversalRenderPipelineAsset urpAsset;

    private UniversalBlurFeature universalBlurFeature;

    private URPOutlineFeature urpOutlineFeature;

    public UniversalBlurFeature UniversalBlurFeature
    {
        get { return this.universalBlurFeature; }
        set { this.universalBlurFeature = value; }
    }
    
    
    public URPOutlineFeature UrpOutlineFeature
    {
        get { return this.urpOutlineFeature; }
        set { this.urpOutlineFeature = value; }
    }
    

   // GameObject.Find("Global").GetComponent<RenderScaleController>().ChangeRenderPassEvent(changerender);
    public void ChangeUniversalBlurFeature(bool value)
    {
        Debug.Log("ChangeUniversalBlurFeature:  " + value);

        this.universalBlurFeature.SetActive(value); 
    }

    public void ChangeURPOutlineFeature(bool value)
    {
        //this.urpOutlineFeature.SetActive(value); 
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

                       foreach (var rendererFeatureItem in rendererFeatures)
                       {
                           if (rendererFeatureItem.name.Contains("UniversalBlurFeature"))
                           {
                               this.universalBlurFeature = (UniversalBlurFeature) rendererFeatureItem;
                               Debug.Log($"Renderer.Feature 名称: {universalBlurFeature.name}");
                           }
                           if (rendererFeatureItem.name.Contains("URPOutlineFeature"))
                           {
                               this.urpOutlineFeature = (URPOutlineFeature) rendererFeatureItem;
                               Debug.Log($"Renderer.Feature 名称: {urpOutlineFeature.name}");
                           }
                       }
                       
                       Debug.Log($"Renderer 名称: {rendererData.name}");
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