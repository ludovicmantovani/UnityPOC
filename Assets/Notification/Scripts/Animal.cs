using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] private float _initialHappyness = 10f;
    [SerializeField] private float _currentHappyness;
    [SerializeField] private float _growindHappynessFactor = 10f;
    [SerializeField] private float _reproductionHappynessThreshold = 100f;


    private float nextActionTime = 0.0f;
    private bool _canReproduce = false;
    void Start()
    {
        _currentHappyness = _initialHappyness;
    }

    void Update()
    {
        UpdateHapyness();
        if (!_canReproduce)
        {
            CanReproduce();
        }
    }

    void UpdateHapyness()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += 1;
            _currentHappyness += _growindHappynessFactor;
        }
        
    }

    void CanReproduce()
    {
        if (_currentHappyness >= _reproductionHappynessThreshold)
        {
            Debug.Log(gameObject.name + " can reproduce");
            _canReproduce = true;
        }
    }
}
