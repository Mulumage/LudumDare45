using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _heartPrefab;
    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;

    [SerializeField] private float distanceX;
    [SerializeField] private float distanceY;
    
    private float _time;

    private void Start()
    {
        RandomizeTime();
    }

    private void Update()
    {
        _time -= Time.deltaTime;

        if (_time > 0)
            return;

        RandomizeTime();   
        SpawnHeart();
    }

    private void RandomizeTime()
    {
        _time = Random.Range(minTime, maxTime);
    }


    private void SpawnHeart()
    {
        var xPos = Random.Range(-distanceX, distanceX);
        var yPos = Random.Range(-distanceY, distanceY);
        
        var postion = new Vector2(xPos, yPos);
        var go = Instantiate(_heartPrefab);
        go.transform.position = postion;
    }
}
