using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Fictions/Audio Element")]
public class AudioElement : ScriptableObject
{
    [SerializeField] private float _minPitch = 1;
    [SerializeField] private float _maxPitch = 1;
    
    [SerializeField] private float _minVolume = 1;
    [SerializeField] private float _maxVolume = 1;
    
    [SerializeField] private AudioClip _clip;
    

    public void Play(AudioSource source)
    {
        var pitch = Random.Range(_minPitch, _maxPitch);
        var volume = Random.Range(_minVolume, _maxVolume);

        source.pitch = pitch;
        source.volume = volume;
        
        source.PlayOneShot(_clip);
    }
}
