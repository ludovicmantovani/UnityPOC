using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour
{
    [SerializeField] private float _initialHappyness = 10f;
    [SerializeField] private float _maxHappyness = 150f;
    [SerializeField] private Slider _currentHappynessSlider;
    [SerializeField] private Image _heartImage;

    [SerializeField] private float _currentHappyness;
    [SerializeField] private float _growindHappynessFactor = 10f;
    [SerializeField] private float _reproductionHappynessThreshold = 150f;

    [SerializeField] private Event _readyToReproduceEvent;

    private float _nextActionTime = 0.0f;
    private bool _canReproduce = false;
    void Start()
    {
        _heartImage.enabled = false;
        _currentHappyness = _initialHappyness;
    }

    void Update()
    {
        UpdateHapyness();
        CanReproduce();
    }

    void UpdateHapyness()
    {
        if (_currentHappyness < _maxHappyness)
        {
            if (Time.time > _nextActionTime)
            {
                _nextActionTime += 1;
                _currentHappyness += _growindHappynessFactor;
            }
        }
        _currentHappynessSlider.value = _currentHappyness / _maxHappyness;
        
    }

    void CanReproduce()
    {
        if (!_canReproduce && _currentHappyness >= _reproductionHappynessThreshold)
        {
            Debug.Log(gameObject.name + " can reproduce");
            _canReproduce = true;
            _heartImage.enabled = true;
            _readyToReproduceEvent.Occured(gameObject);
        }
    }
}
