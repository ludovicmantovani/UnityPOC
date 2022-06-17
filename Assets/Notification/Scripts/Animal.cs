using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Animal : MonoBehaviour
{
    [SerializeField] private string _animalName = "";
    [SerializeField] private float _initialHappyness = 10f;
    [SerializeField] private float _maxHappyness = 150f;
    [SerializeField] private Slider _currentHappynessSlider;
    [SerializeField] private Image _heartImage;

    [SerializeField] private float _currentHappyness;
    [SerializeField] private float _growindHappynessFactor = 10f;
    [SerializeField] private float _reproductionHappynessThreshold = 150f;

    [SerializeField] private Event _readyToReproduceEvent;
    [SerializeField] private TMP_Text _nameUI;

    private float _nextActionTime = 0.0f;
    private bool _canReproduce = false;

    public string AnimalName
    {
        get => _animalName;
        set
        {
            _animalName = value;
            _nameUI.text = value;
        }
    }

    void Start()
    {
        _heartImage.enabled = false;
        _currentHappyness = _initialHappyness;
        if (_nameUI)
        {
            _nameUI.text = _animalName;
        }
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
