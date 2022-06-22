using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private GameObject _enclosureGO;

    private Zone _lastTypeZone = Zone.NONE;

    private bool _haveEnclosure = false;

    void Start()
    {
        if (_enclosureGO)
        {
            _enclosureGO.SetActive(_haveEnclosure);
        }
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

    public void OnZoneEnter(Zone typeZone)
    {
        if (_lastTypeZone == Zone.NONE || _lastTypeZone != typeZone)
        {
            _lastTypeZone = typeZone;
            Debug.Log("Entree en zone " + Enum.GetName(typeof(Zone), typeZone));
            MakeTransaction(typeZone);
        }
    }

    private void MakeTransaction(Zone typeZone)
    {
        switch (typeZone)
        {
            case Zone.FRUTS:
                _playerInventory.Fruit += _playerInventory.Graine;
                _playerInventory.Graine = 0;
                break;
            case Zone.WOOL:
                _playerInventory.Laine += _playerInventory.Fruit;
                _playerInventory.Fruit = 0;
                break;
            case Zone.TISSUE:
                _playerInventory.Tissu += _playerInventory.Laine;
                _playerInventory.Laine = 0;
                break;
            case Zone.SALE:
                _playerInventory.Argent += _playerInventory.Laine;
                _playerInventory.Argent += _playerInventory.Tissu;
                _playerInventory.Argent += _playerInventory.Fruit;
                _playerInventory.Laine = 0;
                _playerInventory.Tissu = 0;
                _playerInventory.Fruit = 0;
                break;
            case Zone.PURCHASE:
                _playerInventory.Graine += _playerInventory.Argent;
                _playerInventory.Argent = 0;
                break;
            default:
                Debug.Log("Default");
                break;
        }
    }
}
