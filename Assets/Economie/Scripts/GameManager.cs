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
            _playerInventory.Fruit = 0;
            _playerInventory.Laine = 0;
            _playerInventory.Tissu = 0;
            _playerInventory.Argent = 0;
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
            MakeTransaction(typeZone);
        }
    }

    private void MakeTransaction(Zones typeZone)
    {
        switch (typeZone)
        {
            case Zones.FRUTS:
                _playerInventory.Fruit += _playerInventory.Graine;
                _playerInventory.Graine = 0;
                break;
            case Zones.WOOL:
                _playerInventory.Laine += _playerInventory.Fruit;
                _playerInventory.Fruit = 0;
                break;
            case Zones.TISSUE:
                _playerInventory.Tissu += _playerInventory.Laine;
                _playerInventory.Laine = 0;
                break;
            case Zones.MONEY:
                _playerInventory.Argent += _playerInventory.Laine;
                _playerInventory.Argent += _playerInventory.Tissu;
                _playerInventory.Argent += _playerInventory.Fruit;
                _playerInventory.Laine = 0;
                _playerInventory.Tissu = 0;
                _playerInventory.Fruit = 0;
                break;
            case Zones.SEED:
                _playerInventory.Graine += _playerInventory.Argent;
                _playerInventory.Argent = 0;
                break;
            default:
                Debug.Log("Default");
                break;
        }
    }
}
