using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolver : MonoBehaviour
{
    public enum MeshesDetection
    {
        GetComponents,GetComponentsInChildren,GetComponentsInParents
    }

    public enum MeshRenderType
    {
        MeshRenderer,SkinnedMeshRenderer
    }

    private List<MeshRenderer> meshRenderers;
    private List<SkinnedMeshRenderer> skinnedMeshRenderers;
    private List<Material> materials;

    public float Duration = 2.7f;
    public MeshesDetection meshesDetection;
    public MeshRenderType meshRenderType;

    private bool m_Materialized = true;
    private bool m_Dissolved = false;
    private float m_DissolveAmount;
    private bool m_Finished = true;

    //Queue Coroutines

    public Queue<IEnumerator> coroutineQueue = new Queue<IEnumerator>();


    void Start()
    {
        StartCoroutine(CoroutineCoordinator());

        if (meshRenderType == MeshRenderType.MeshRenderer)
        {
            switch (meshesDetection)
            {
                case MeshesDetection.GetComponents:
                    meshRenderers = new List<MeshRenderer>(GetComponents<MeshRenderer>());
                    break;
                case MeshesDetection.GetComponentsInChildren:
                    meshRenderers = new List<MeshRenderer>(GetComponentsInChildren<MeshRenderer>());
                    break;
                case MeshesDetection.GetComponentsInParents:
                    meshRenderers = new List<MeshRenderer>(GetComponentsInParent<MeshRenderer>());
                    break;
            }

            materials = new List<Material>();
            foreach (var renderer in meshRenderers)
            {
                materials.AddRange(renderer.materials);
            }

        }

        else
        {
            switch (meshesDetection)
            {
                case MeshesDetection.GetComponents:
                    skinnedMeshRenderers = new List<SkinnedMeshRenderer>(GetComponents<SkinnedMeshRenderer>());
                    break;
                case MeshesDetection.GetComponentsInChildren:
                    skinnedMeshRenderers = new List<SkinnedMeshRenderer>(GetComponentsInChildren<SkinnedMeshRenderer>());
                    break;
                case MeshesDetection.GetComponentsInParents:
                    skinnedMeshRenderers = new List<SkinnedMeshRenderer>(GetComponentsInParent<SkinnedMeshRenderer>());
                    break;
            }

            materials = new List<Material>();
            foreach (var renderer in skinnedMeshRenderers)
            {
                materials.AddRange(renderer.materials);
            }
        }


        
        m_Materialized = true;
    }

    /// <summary>
    /// Operation is executed if other operations were finished. Function automatically detects which operation to choose between materialize and dissolve.
    /// </summary>
    ///<returns>
    ///True if materialize or dissolve can be performed, otherwise false when the previous action has not ended.
    ///</returns>
    public bool MaterializeDissolve()
    {
        if (!m_Finished) return false;
        m_Finished = false;

        if (m_Dissolved)
            StartCoroutine(Materialize(Duration));
        else if (m_Materialized)
            StartCoroutine(Dissolve(Duration));

        return true;
    }
    /// <summary>
    /// When called, operation is added to queue. Function automatically detects which operation to choose between materialize and dissolve.
    /// </summary>
    public void QueueMaterializeDissolve()
    {
        coroutineQueue.Enqueue(QueueMaterializeDissolve(Duration));
    }


    IEnumerator CoroutineCoordinator()
    {
        while (true)
        {
            while (coroutineQueue.Count > 0)
                yield return StartCoroutine(coroutineQueue.Dequeue());
            yield return null;
        }
    }

    private IEnumerator QueueMaterializeDissolve(float fadeDuration)
    {
        float elapsedTime = 0f;

        if(m_Dissolved)
        {

            m_Materialized = true;
            m_Dissolved = false;

            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                m_DissolveAmount = Mathf.Lerp(1, 0, elapsedTime / fadeDuration);

                foreach (var mat in materials)
                {
                    mat.SetFloat("_DissolveAmount", m_DissolveAmount);
                }
                yield return null;
            }

            m_Finished = true;
        }

        else if(m_Materialized)
        {


            m_Materialized = false;
            m_Dissolved = true;

            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                m_DissolveAmount = Mathf.Lerp(0, 1, elapsedTime / fadeDuration);
                foreach (var mat in materials)
                {
                    mat.SetFloat("_DissolveAmount", m_DissolveAmount);
                }
                yield return null;
            }


            m_Finished = true;
        }

    }

    private IEnumerator Materialize(float fadeDuration)
    {
        float elapsedTime = 0f;

        m_Materialized = true;
        m_Dissolved = false;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            m_DissolveAmount = Mathf.Lerp(1, 0,elapsedTime / fadeDuration);

            foreach (var mat in materials)
            {
                mat.SetFloat("_DissolveAmount", m_DissolveAmount);
            }
            yield return null;
        }

        m_Finished = true;
    }

    private IEnumerator Dissolve(float fadeDuration)
    {
        float elapsedTime = 0f;

        m_Materialized = false;
        m_Dissolved = true;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            m_DissolveAmount = Mathf.Lerp(0, 1, elapsedTime / fadeDuration);
            foreach (var mat in materials)
            {
                mat.SetFloat("_DissolveAmount", m_DissolveAmount);
            }
            yield return null;
        }


        m_Finished = true;
    }
}
