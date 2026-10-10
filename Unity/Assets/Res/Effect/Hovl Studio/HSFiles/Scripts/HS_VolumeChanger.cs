using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class HS_VolumeChanger : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] Transform target;

    [Header("Shake")]
    [SerializeField] Vector3 shakeAmplitude = new Vector3(0.2f, 0.2f, 0.2f);
    [SerializeField] float shakeDuration = 1f;
    [SerializeField] AnimationCurve shakeCurve = AnimationCurve.EaseInOut(0f, 1f, 1f, 0f);

    [Header("Loop")]
    [SerializeField] bool loop;
    [SerializeField] float repeatTime = 0.5f;

    [Header("Space")]
    [SerializeField] bool useLocalPosition = true;

    [Header("Lens Distortion")]
    [SerializeField] Volume volume;
    [SerializeField] bool animateLensDistortion = true;
    [SerializeField] AnimationCurve lensDistortionCurve = AnimationCurve.EaseInOut(0f, 1f, 1f, 0f);
    [SerializeField] float lensDistortionMin = 0f;
    [SerializeField] float lensDistortionMax = -0.5f;

    Vector3 startPosition;
    float timer;
    float repeatTimer;
    bool isPlaying;

    LensDistortion lensDistortion;
    class LensDistortionState
    {
        public float defaultIntensity;
        public int activeEffects;
    }

    static readonly Dictionary<LensDistortion, LensDistortionState> lensStates = new();

    LensDistortionState lensState;
    bool lensEffectRegistered;
    bool lensDistortionAvailable;

    void Awake()
    {
        /*if (target == null)
            target = transform;*/
        if (target == null && Camera.main != null)
            target = Camera.main.transform;

        startPosition = useLocalPosition ? target.localPosition : target.position;

        SetupLensDistortion();
    }


    void OnEnable()
    {
        StartEffect();
    }

    void OnDisable()
    {
        ResetPosition();
        ResetLensDistortion();

        isPlaying = false;
        timer = 0f;
        repeatTimer = 0f;
    }

    void Update()
    {
        if (isPlaying)
        {
            if (shakeDuration <= 0f)
            {
                FinishEffect();
                return;
            }

            timer += Time.deltaTime;

            float normalizedTime = Mathf.Clamp01(timer / shakeDuration);

            UpdateShake(normalizedTime);
            UpdateLensDistortion(normalizedTime);

            if (timer >= shakeDuration)
                FinishEffect();
        }
        else if (loop)
        {
            repeatTimer -= Time.deltaTime;

            if (repeatTimer <= 0f)
                StartEffect();
        }
    }

    public void StartEffect()
    {
        startPosition = useLocalPosition ? target.localPosition : target.position;
        timer = 0f;
        isPlaying = true;

        if (animateLensDistortion && lensDistortionAvailable)
        {
            lensDistortion.intensity.overrideState = true;
            RegisterLensEffect();
        }
    }

    void RegisterLensEffect()
    {
        if (lensEffectRegistered || lensState == null)
            return;

        lensState.activeEffects++;
        lensEffectRegistered = true;
    }

    void UnregisterLensEffect()
    {
        if (!lensEffectRegistered || lensState == null)
            return;

        lensState.activeEffects = Mathf.Max(0, lensState.activeEffects - 1);
        lensEffectRegistered = false;

        // Відновлюємо початкове значення лише після завершення
        // останнього активного ефекту.
        if (lensState.activeEffects == 0 && lensDistortionAvailable)
            lensDistortion.intensity.value = lensState.defaultIntensity;
    }

    public void StopEffect()
    {
        isPlaying = false;
        timer = 0f;
        repeatTimer = 0f;

        ResetPosition();
        ResetLensDistortion();
    }

    void FinishEffect()
    {
        ResetPosition();
        ResetLensDistortion();

        isPlaying = false;
        timer = 0f;

        if (loop)
            repeatTimer = repeatTime;
    }

    void UpdateShake(float normalizedTime)
    {
        float curveValue = shakeCurve.Evaluate(normalizedTime);

        Vector3 randomOffset = new Vector3(
            Random.Range(-1f, 1f) * shakeAmplitude.x,
            Random.Range(-1f, 1f) * shakeAmplitude.y,
            Random.Range(-1f, 1f) * shakeAmplitude.z
        ) * curveValue;

        ApplyPosition(startPosition + randomOffset);
    }

    void UpdateLensDistortion(float normalizedTime)
    {
        if (!animateLensDistortion || !lensDistortionAvailable)
            return;

        float curveValue = lensDistortionCurve.Evaluate(normalizedTime);
        float intensity = Mathf.Lerp(lensDistortionMin, lensDistortionMax, curveValue);
        lensDistortion.intensity.value = intensity;
    }

    void SetupLensDistortion()
    {
        lensDistortionAvailable = false;

        if (volume == null)
        {
            Camera mainCamera = Camera.main;

            if (mainCamera != null)
            {
                volume = mainCamera.GetComponent<Volume>();

                if (volume == null)
                    volume = mainCamera.GetComponentInParent<Volume>();

                if (volume == null)
                    volume = mainCamera.GetComponentInChildren<Volume>(true);
            }

            if (volume == null)
                volume = FindFirstObjectByType<Volume>();
        }

        if (volume == null)
            return;

        float originalIntensity = 0f;
        bool originalValueFound = false;

        // Спочатку читаємо незмінене значення з asset-профілю.
        if (volume.sharedProfile != null &&
            volume.sharedProfile.TryGet(out LensDistortion sharedLensDistortion))
        {
            originalIntensity = sharedLensDistortion.intensity.value;
            originalValueFound = true;
        }

        // Потім отримуємо runtime-компонент, який будемо змінювати.
        if (volume.profile == null ||
            !volume.profile.TryGet(out lensDistortion))
        {
            return;
        }

        lensDistortionAvailable = true;

        if (!lensStates.TryGetValue(lensDistortion, out lensState))
        {
            lensState = new LensDistortionState
            {
                defaultIntensity = originalValueFound
                    ? originalIntensity
                    : lensDistortion.intensity.value,

                activeEffects = 0
            };

            lensStates.Add(lensDistortion, lensState);
        }
    }

    void ApplyPosition(Vector3 pos)
    {
        if (useLocalPosition)
            target.localPosition = pos;
        else
            target.position = pos;
    }

    void ResetPosition()
    {
        ApplyPosition(startPosition);
    }

    void ResetLensDistortion()
    {
        UnregisterLensEffect();
    }
}