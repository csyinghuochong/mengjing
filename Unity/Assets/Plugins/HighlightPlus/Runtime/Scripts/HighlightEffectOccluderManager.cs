﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace HighlightPlus {


    public partial class HighlightEffect : MonoBehaviour {

        static readonly List<HighlightSeeThroughOccluder> occluders = new List<HighlightSeeThroughOccluder>();
        static readonly Dictionary<Camera, int> occludersFrameCount = new Dictionary<Camera, int>();
        static Material fxMatSeeThroughOccluder, fxMatDepthWrite;
        static RaycastHit[] hits;

        /// <summary>
        /// True if the see-through is cancelled by an occluder using raycast method
        /// </summary>
        public bool IsSeeThroughOccluded(Camera cam) {

            if (rms == null) return false;

            // Compute bounds
            Bounds bounds = new Bounds();
            for (int r = 0; r < rms.Length; r++) {
                if (rms[r].renderer != null) {
                    if (bounds.size.x == 0) {
                        bounds = rms[r].renderer.bounds;
                    } else {
                        bounds.Encapsulate(rms[r].renderer.bounds);
                    }
                }
            }
            Vector3 pos = bounds.center;
            Vector3 camPos = cam.transform.position;
            Vector3 offset = pos - camPos;
            float maxDistance = Vector3.Distance(pos, camPos);
            if (hits == null || hits.Length == 0) {
                hits = new RaycastHit[64];
            }
            int occludersCount = occluders.Count;
            int hitCount = Physics.BoxCastNonAlloc(pos - offset, bounds.extents * 0.9f, offset.normalized, hits, Quaternion.identity, maxDistance);
            for (int k = 0; k < hitCount; k++) {
                for (int j = 0; j < occludersCount; j++) {
                    if (hits[k].collider.transform == occluders[j].transform) {
                        return true;
                    }
                }
            }
            return false;
        }

        public static void RegisterOccluder(HighlightSeeThroughOccluder occluder) {
            if (!occluders.Contains(occluder)) {
                occluders.Add(occluder);
            }
        }

        public static void UnregisterOccluder(HighlightSeeThroughOccluder occluder) {
            if (occluders.Contains(occluder)) {
                occluders.Remove(occluder);
            }
        }

        /// <summary>
        /// Test see-through occluders.
        /// </summary>
        /// <param name="cam">The camera to be tested</param>
        /// <returns>Returns true if there's no raycast-based occluder cancelling the see-through effect</returns>
        public bool RenderSeeThroughOccluders(CommandBuffer cb, Camera cam) {

            int occludersCount = occluders.Count;
            if (occludersCount == 0 || rmsCount == 0) return true;

            bool useRayCastCheck = false;
            // Check if raycast method is needed
            for (int k = 0; k < occludersCount; k++) {
                HighlightSeeThroughOccluder occluder = occluders[k];
                if (occluder == null || !occluder.isActiveAndEnabled) continue;
                if (occluder.mode == OccluderMode.BlocksSeeThrough && occluder.detectionMethod == DetectionMethod.RayCast) {
                    useRayCastCheck = true;
                    break;
                }
            }
            if (useRayCastCheck) {
                if (IsSeeThroughOccluded(cam)) return false;
            }

            // do not render see-through occluders more than once this frame per camera (there can be many highlight effect scripts in the scene, we only need writing to stencil once)
            int lastFrameCount;
            occludersFrameCount.TryGetValue(cam, out lastFrameCount);
            int currentFrameCount = Time.frameCount;
            if (currentFrameCount == lastFrameCount) return true;
            occludersFrameCount[cam] = currentFrameCount;

            if (fxMatSeeThroughOccluder == null) {
                InitMaterial(ref fxMatSeeThroughOccluder, "HighlightPlus/Geometry/SeeThroughOccluder");
                if (fxMatSeeThroughOccluder == null) return true;
            }
            if (fxMatDepthWrite == null) {
                InitMaterial(ref fxMatDepthWrite, "HighlightPlus/Geometry/JustDepth");
                if (fxMatDepthWrite == null) return true;
            }

            for (int k = 0; k < occludersCount; k++) {
                HighlightSeeThroughOccluder occluder = occluders[k];
                if (occluder == null || !occluder.isActiveAndEnabled) continue;
                if (occluder.detectionMethod == DetectionMethod.Stencil) {
                    if (occluder.meshData == null) continue;
                    int meshDataLength = occluder.meshData.Length;
                    // Per renderer
                    for (int m = 0; m < meshDataLength; m++) {
                        // Per submesh
                        Renderer renderer = occluder.meshData[m].renderer;
                        if (renderer.isVisible) {
                            for (int s = 0; s < occluder.meshData[m].subMeshCount; s++) {
                                cb.DrawRenderer(renderer, occluder.mode == OccluderMode.BlocksSeeThrough ? fxMatSeeThroughOccluder : fxMatDepthWrite, s);
                            }
                        }
                    }
                }
            }
            return true;
        }

        bool CheckOcclusion(Camera cam) {

            if (!perCameraOcclusionData.TryGetValue(cam, out PerCameraOcclusionData occlusionData)) {
                occlusionData = new PerCameraOcclusionData();
                perCameraOcclusionData[cam] = occlusionData;
            }

            float now = GetTime();
            int frameCount = Time.frameCount; // ensure all cameras are checked this frame

            if (now - occlusionData.checkLastTime < seeThroughOccluderCheckInterval && Application.isPlaying && occlusionData.occlusionRenderFrame != frameCount) return occlusionData.lastOcclusionTestResult;

            occlusionData.cachedOccluders.Clear();
            occlusionData.cachedOccluderCollider = null;

            if (rms == null || rms.Length == 0 || rms[0].renderer == null) return false;

            occlusionData.checkLastTime = now;
            occlusionData.occlusionRenderFrame = frameCount;

            Vector3 camPos = cam.transform.position;

            if (seeThroughOccluderCheckIndividualObjects) {
                for (int r = 0; r < rms.Length; r++) {
                    if (rms[r].renderer != null) {
                        Bounds bounds = rms[r].renderer.bounds;
                        Vector3 pos = bounds.center;
                        float maxDistance = Vector3.Distance(pos, camPos);
                        if (Physics.BoxCast(pos, bounds.extents * seeThroughOccluderThreshold, (camPos - pos).normalized, out RaycastHit hitInfo, Quaternion.identity, maxDistance, seeThroughOccluderMask)) {
                            occlusionData.cachedOccluderCollider = hitInfo.collider;
                            occlusionData.lastOcclusionTestResult = true;
                            return true;
                        }
                    }
                }
                occlusionData.lastOcclusionTestResult = false;
                return false;
            } else {
                // Compute combined bounds
                Bounds bounds = rms[0].renderer.bounds;
                for (int r = 1; r < rms.Length; r++) {
                    if (rms[r].renderer != null) {
                        bounds.Encapsulate(rms[r].renderer.bounds);
                    }
                }
                Vector3 pos = bounds.center;
                float maxDistance = Vector3.Distance(pos, camPos);
                occlusionData.lastOcclusionTestResult = Physics.BoxCast(pos, bounds.extents * seeThroughOccluderThreshold, (camPos - pos).normalized, out RaycastHit hitInfo, Quaternion.identity, maxDistance, seeThroughOccluderMask);
                occlusionData.cachedOccluderCollider = hitInfo.collider;
                return occlusionData.lastOcclusionTestResult;
            }
        }


        const int MAX_OCCLUDER_HITS = 50;
        static RaycastHit[] occluderHits;

        void AddWithoutRepetition(List<Renderer> target, List<Renderer> source, LayerMask layerMask) {
            int sourceCount = source.Count;
            for (int k = 0; k < sourceCount; k++) {
                Renderer entry = source[k];
                if (entry != null && !target.Contains(entry) && ValidRenderer(entry) && ((1<<entry.gameObject.layer) & layerMask) != 0) {
                    target.Add(entry);
                }
            }
        }

        void CheckOcclusionAccurate(CommandBuffer cbuf, Camera cam) {

            if (!perCameraOcclusionData.TryGetValue(cam, out PerCameraOcclusionData occlusionData)) {
                occlusionData = new PerCameraOcclusionData();
                perCameraOcclusionData[cam] = occlusionData;
            }

            float now = GetTime();
            int frameCount = Time.frameCount; // ensure all cameras are checked this frame
            bool reuse = now - occlusionData.checkLastTime < seeThroughOccluderCheckInterval && Application.isPlaying && occlusionData.occlusionRenderFrame != frameCount;

            if (!reuse) {

                occlusionData.cachedOccluders.Clear();
                occlusionData.cachedOccluderCollider = null;

                if (rms == null || rms.Length == 0 || rms[0].renderer == null) return;

                occlusionData.checkLastTime = now;
                occlusionData.occlusionRenderFrame = frameCount;
                Quaternion quaternionIdentity = Quaternion.identity;
                Vector3 camPos = cam.transform.position;

                if (occluderHits == null || occluderHits.Length < MAX_OCCLUDER_HITS) {
                    occluderHits = new RaycastHit[MAX_OCCLUDER_HITS];
                }

                if (seeThroughOccluderCheckIndividualObjects) {
                    for (int r = 0; r < rms.Length; r++) {
                        if (rms[r].renderer != null) {
                            Bounds bounds = rms[r].renderer.bounds;
                            Vector3 pos = bounds.center;
                            float maxDistance = Vector3.Distance(pos, camPos);
                            int numOccluderHits = Physics.BoxCastNonAlloc(pos, bounds.extents * seeThroughOccluderThreshold, (camPos - pos).normalized, occluderHits, quaternionIdentity, maxDistance, seeThroughOccluderMask);
                            for (int k = 0; k < numOccluderHits; k++) {
                                occluderHits[k].collider.transform.root.GetComponentsInChildren(tempRR);
                                AddWithoutRepetition(occlusionData.cachedOccluders, tempRR, seeThroughOccluderMask);
                            }
                        }
                    }
                } else {
                    // Compute combined bounds
                    Bounds bounds = rms[0].renderer.bounds;
                    for (int r = 1; r < rms.Length; r++) {
                        if (rms[r].renderer != null) {
                            bounds.Encapsulate(rms[r].renderer.bounds);
                        }
                    }
                    Vector3 pos = bounds.center;
                    float maxDistance = Vector3.Distance(pos, camPos);
                    int numOccluderHits = Physics.BoxCastNonAlloc(pos, bounds.extents * seeThroughOccluderThreshold, (camPos - pos).normalized, occluderHits, quaternionIdentity, maxDistance, seeThroughOccluderMask);
                    for (int k = 0; k < numOccluderHits; k++) {
                        occluderHits[k].collider.transform.root.GetComponentsInChildren(tempRR);
                        AddWithoutRepetition(occlusionData.cachedOccluders, tempRR, seeThroughOccluderMask);
                    }
                }
            }

            // render occluders
            int occluderRenderersCount = occlusionData.cachedOccluders.Count;
            if (occluderRenderersCount > 0) {
                for (int k = 0; k < occluderRenderersCount; k++) {
                    Renderer r = occlusionData.cachedOccluders[k];
                    if (r != null) {
                        cbuf.DrawRenderer(r, fxMatSeeThroughMask);
                    }
                }
            }
        }

        public void GetOccluders(Camera camera, List<Transform> occluders) {
            occluders.Clear();
            if (perCameraOcclusionData.TryGetValue(camera, out PerCameraOcclusionData occlusionData)) {
                if (occlusionData.cachedOccluderCollider != null) {
                    occluders.Add(occlusionData.cachedOccluderCollider.transform);
                    return;
                }
                foreach (Renderer r in occlusionData.cachedOccluders) {
                    if (r != null) {
                        occluders.Add(r.transform);
                    }
                }
            }
        }
    }
}
