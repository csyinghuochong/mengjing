// // 后处理脚本示例（简化版）
// using UnityEngine;
//
// public class GaussianBlurPostProcess : MonoBehaviour
// {
//     public Shader blurShader;
//     private Material blurMaterial;
//     private RenderTexture tempRT;
//
//     void OnRenderImage(RenderTexture source, RenderTexture destination)
//     {
//         if (blurMaterial == null)
//             blurMaterial = new Material(blurShader);
//         
//         int iterations = blurMaterial.GetInt("_BlurIterations");
//         tempRT = RenderTexture.GetTemporary(source.width, source.height);
//         
//         // 水平模糊
//         Graphics.Blit(source, tempRT, blurMaterial, 0);
//         
//         // 垂直模糊（迭代应用）
//         for (int i = 0; i < iterations; i++)
//         {
//             RenderTexture tempRT2 = RenderTexture.GetTemporary(source.width, source.height);
//             Graphics.Blit(tempRT, tempRT2, blurMaterial, 1);
//             RenderTexture.ReleaseTemporary(tempRT);
//             tempRT = tempRT2;
//         }
//         
//         Graphics.Blit(tempRT, destination);
//         RenderTexture.ReleaseTemporary(tempRT);
//     }
// }