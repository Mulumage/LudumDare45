using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioElement _audio;
    
    [SerializeField] private bool _playOnStart;
    [SerializeField] private bool _destroyAfterPlay;
    
    private AudioSource _source;
    
    

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        if (_playOnStart)
            PlayAudio();
    }


    public void PlayAudio()
    {
        _audio.Play(_source);

        if (_destroyAfterPlay)
            StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        while (_source.isPlaying)
            yield return null;

        Destroy(this.gameObject);
    }
}
