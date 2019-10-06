using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;
    
    public float Duration = 0.3f;
    public float Amplitude = 1.2f;
    public float Frequency = 2.0f;

    private float _time;

    public CinemachineVirtualCamera VirtualCamera;
    private CinemachineBasicMultiChannelPerlin _virtualCameraNoise;

    private void Awake()
    {
        Instance = this;
        
        if (VirtualCamera != null)
            _virtualCameraNoise =
                VirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void Shake()
    {
        StartCoroutine(ShakeRoutine());
    }

    private IEnumerator ShakeRoutine()
    {
        if (VirtualCamera == null || _virtualCameraNoise == null)
            yield break;

        _time = Duration;
        
        while (_time > 0)
        {
            _virtualCameraNoise.m_AmplitudeGain = Amplitude;
            _virtualCameraNoise.m_FrequencyGain = Frequency;

            _time -= Time.deltaTime;
            yield return null;
        }
        
        _virtualCameraNoise.m_AmplitudeGain = 0;
        _virtualCameraNoise.m_FrequencyGain = 0;
    }
}
