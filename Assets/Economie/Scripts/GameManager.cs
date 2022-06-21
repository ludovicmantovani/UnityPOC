using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerInventory _playerInventory;

    private Zones _lastTypeZone = Zones.NONE;

    void Start()
    {
        if (_playerInventory)
        {
            _playerInventory.Graine = 5;
        }
    }

    void Update()
    {
        
    }

    public void OnZoneEnter(Zones typeZone)
    {
        if (_lastTypeZone == Zones.NONE || _lastTypeZone != typeZone)
        {
            _lastTypeZone = typeZone;
            Debug.Log("Entree en zone " + Enum.GetName(typeof(Zones), typeZone));
        }
    }
}
